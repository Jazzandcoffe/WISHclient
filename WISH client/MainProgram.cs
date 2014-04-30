using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO.Ports;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Windows.Forms.DataVisualization.Charting;
using orgColor = System.Drawing;

namespace WISH_client
{
    /// <summary>
    /// Klassen MainProgram som sköter den GUI ruta som användaren ser. 
    /// </summary>
    public partial class MainProgram : Form
    {
        /// <summary>
        /// Klass som krävs för att på ett smidigt sätt fylla comboboxen för players på Xboxkontrollen.
        /// </summary>
        private class Players
        {
            public string Name { get; set; }
            public PlayerIndex Player { get; set; }
        }

        /// <summary>
        /// Chart variabler
        /// </summary>
        public ChartArea _cArea = new ChartArea("Chart1");
        private double _maximumX = 300;
        private double _maximumY = 200;
        private List<SensorDataGraph> _dataFront = new List<SensorDataGraph>();
        private List<SensorDataGraph> _dataRight = new List<SensorDataGraph>();
        private Dictionary<string, List<SensorDataGraph>> _dictWithChartData = new Dictionary<string,List<SensorDataGraph>>();

        

        private Bluetooth _bt; //objektet som sköter kommunikationen via bluetooth. 
        private Dictionary<string, byte[]> _ctrlCommands = new Dictionary<string,byte[]>(); //en dictionary som tolkar en sträng av ett kommando till en byte-array.
        private Dictionary<int, string> _ctrlDecisions = new Dictionary<int,string>(); //en dictionary där en textsträng till typen 5 styrbeslut enkelt kan hämtas. 
        private System.Windows.Forms.Timer _timer1; //Timern som är tänkt ticka för kontroll över vilka knappar användaren trycker ner. 
        private System.Windows.Forms.Timer _timer2; //Timern som GUI:t är tänkt att uppdateras med. 
        private List<int[]> _lastData = new List<int[]>(); //Senaste datan från bluetooth ligger i denna lista. Vid varje tick kan denna itereras igenom. 
        private List<Players> _playerList = new List<Players>();
        private Xboxkontroll _player;
        public static object locker = new object();   //Låsobjekt, för att ingen information ska visas vid låsning av access till _lastData.
        List<int[]> temp = new List<int[]>();
        int[] dataOfTypes = new int[30];

        /// <summary>
        /// Konstruktorn för klassen.
        /// </summary>
        public MainProgram()
        {
            InitializeComponent();
            InitializeGUI();
            FillControlCommandsDictionary();
            FillControlDecisionsDictionary();
            FillPlayersComboBox();
            initTimer1(ref _timer1, 100);
            initTimer2(ref _timer2, 60);

            //this.KeyPreview = true;
            //this.KeyDown += new KeyEventHandler(Form1_KeyDownEvent);
            //this.KeyUp += new KeyEventHandler(Form1_KeyUpEvent);
        }

        /// <summary>
        /// Ställer in allt som är visuellt för användaren.
        /// </summary>
        private void InitializeGUI()
        {
            UpdateComPorts();
            lblBaudRate.Text = "115200";
            lblDistanceMid.Text = String.Empty;
            lblLeftDetect.Text = String.Empty;
            lblRightDetect.Text = String.Empty;
            lblSpeedMid.Text = String.Empty;
            btnComStart.Enabled = true;
            btnComStop.Enabled = false;

            SetupChart(ref _chart, ref _dataFront);
        }

        /// <summary>
        /// Uppdaterar comboboxen i GUIet med de COM-portar datorn kan känna av just nu. 
        /// </summary>
        private void UpdateComPorts()
        {
            cmbComPorts.Items.Clear();
            cmbComPorts.Items.AddRange(SerialPort.GetPortNames());
        }

        /// <summary>
        /// Fyller combobox med spelarna. 
        /// </summary>
        private void FillPlayersComboBox()
        {
            _playerList.Add(new Players { Name = "1", Player = PlayerIndex.One });
            _playerList.Add(new Players { Name = "2", Player = PlayerIndex.Two });
            _playerList.Add(new Players { Name = "3", Player = PlayerIndex.Three });
            _playerList.Add(new Players { Name = "4", Player = PlayerIndex.Four });
            cmbPlayers.DataSource = _playerList;
            cmbPlayers.DisplayMember = "Name";
        }

        /// <summary>
        /// Fyller Dictionaryn _mvCommands med alla styrkommandon. 
        /// Denna form valdes för att det enkelt ska gå för utomstående att tyda vad som är tanken. 
        /// </summary>
        private void FillControlCommandsDictionary()
        {
            _ctrlCommands.Add("Rotate left", new byte[2] { 1, 5 });
            _ctrlCommands.Add("Rotate right", new byte[2] { 1, 4 });
            _ctrlCommands.Add("Forward", new byte[2] { 1, 5 });
            _ctrlCommands.Add("Back", new byte[2] { 1, 3 });
            _ctrlCommands.Add("Left", new byte[2] { 1, 11 });
            _ctrlCommands.Add("Right", new byte[2] { 1, 10 });
            _ctrlCommands.Add("Reset", new byte[2] { 1, 0 });
        }

        /// <summary>
        /// Fyller en Dictionary för att kunna tolka datan från styrmodulen. 
        /// Hämtat från Excel-dokumentet på dropbox. (Bussprotokoll.xlsx)
        /// Dessa gäller då typen är 5. 
        /// Detta gör att det går enkelt att hämta ut vad en viss data från typen 5 är i en string. 
        /// </summary>
        private void FillControlDecisionsDictionary()
        {
            _ctrlDecisions.Add(0, "Servofel, overload");
            _ctrlDecisions.Add(1, "Servofel, range");
            _ctrlDecisions.Add(2, "Servofel, overheat");
            _ctrlDecisions.Add(3, "Servofel, voltage");
            _ctrlDecisions.Add(4, "Servofel, reserv 1");
            _ctrlDecisions.Add(5, "Servofel, reserv 2");
            _ctrlDecisions.Add(6, "Servofel, reserv 3");
            _ctrlDecisions.Add(7, "Servofel, reserv 4");
            _ctrlDecisions.Add(8, "Gå framåt");
            _ctrlDecisions.Add(9, "Gå bakåt");
            _ctrlDecisions.Add(10, "Rotera moturs");
            _ctrlDecisions.Add(11, "Rotera medurs");
            _ctrlDecisions.Add(12, "Börja klättra upp");
            _ctrlDecisions.Add(13, "Börja klättra ner");
            _ctrlDecisions.Add(14, "Banan är slut, stå still");
        }

        /// <summary>
        /// Avkodar listan med int[] element och gör uppdaterar GUI korrekt efter detta. 
        /// Denna funktion ska vara en hjälpfunktion till tick-funktionen i programmet. 
        /// Funktionen kan då köras vid varje tick. 
        /// Glöm inte Dictionaryn för styrbeslut där det enkelt går att hämta rätt string för
        /// typen 5. 
        /// </summary>
        private void UpdateGUIwithListData()
        {
            //Om detta fungerar så låser den _lastData så att andra trådar måste vänta
            //tills kopieringen är klar. 
            lock (locker)
            {
               temp = new List<int[]>(_lastData);
            }
    
            foreach (int[] element in temp) 
            {
                //Provisorisk lösning för att få ut sensordata i GUI.
                //Bättre implementering möjlig.
                if (element[0] > 4 && element[0] < 15)
                    dataOfTypes[element[0]] = element[1];
            }
            lblDistanceMid.Text = dataOfTypes[5].ToString();
            lblSpeedMid.Text = dataOfTypes[6].ToString();
            lblRightDetect.Text = dataOfTypes[7].ToString();
            lblLeftDetect.Text = dataOfTypes[8].ToString();
            lblDistFront.Text = dataOfTypes[9].ToString();
            lblDistRear.Text = dataOfTypes[10].ToString();
            lblFrontDetect.Text = dataOfTypes[11].ToString();
            lblRearDetect.Text = dataOfTypes[12].ToString();
            lblDistRight.Text = dataOfTypes[13].ToString();
            lblDistLeft.Text = dataOfTypes[14].ToString();
            AddValueToChart(ref _dataFront, dataOfTypes[9]);
            AddValueToChart(ref _dataRight, dataOfTypes[13]);
        }

        /// <summary>
        /// Då vissa värden kommer vara i en byte och ska tolkas som 2Complement krävs denna funktionen. 
        /// </summary>
        /// <param name="value">Byten som ska konverteras till int med 2-komplement</param>
        /// <returns></returns>
        private int ConvertByteToInt_2Complement(byte value)
        { 
            return Convert.ToInt32(unchecked((SByte) value));
        }

        private int ConvertDataToInt(byte type, byte data)
        {
            if (type != 5 && type != 6)
            { return Convert.ToInt32(data); }
            else
            { return Convert.ToInt32(unchecked((SByte)data)); }
        }

        /// <summary>
        /// Skapar Bluetooth objektet och öppnar porten. 
        /// Aktiverar även eventet som triggas när Bluetooth-objektet tömt inkommande buffern. 
        /// </summary>
        /// <param name="port">COM-porten som seriellporten ska öppnas mot</param>
        private void OpenConnection(string port)
        {
            _bt = new Bluetooth(port);
            try
            {   _bt.OpenPort();    }
            catch
            {
                MessageBox.Show("Kan inte öppna porten mot Bluetoothen!", "Fel", MessageBoxButtons.OK);
                return;
            }
            _bt.BtDataReceived += new BtDataReceivedEventHandler(bt_DataReceived);
        }

        /// <summary>
        /// Stänger porten och stänger av eventet om något skulle tagits emot.
        /// </summary>
        public void CloseConnection()
        {
            try
            {   _bt.ClosePort();   }
            catch
            { 
                MessageBox.Show("Kan inte stänga porten mot Bluetoothen", "Fel", MessageBoxButtons.OK);
                return;
            }
            //Stänger av eventet så att ingen behandling görs ifall porten skulle skicka ut data.
            _bt.BtDataReceived -= bt_DataReceived;
        }

        /// <summary>
        /// Initierar timer1 och ställer in rätt intervall för eventet Timer1_Tick
        /// </summary>
        /// <param name="timer">referens till timern som ska vara Timer1</param>
        /// <param name="tickInMs">Antalet millisekunder varje tick ska vara</param>
        private void initTimer1(ref System.Windows.Forms.Timer timer, int tickInMs)
        {
            timer = new System.Windows.Forms.Timer();
            timer.Tick += new EventHandler(Timer1_Tick);
            timer.Interval = tickInMs;
        }

        /// <summary>
        /// Initierar timer2 och ställer in rätt intervall för eventet Timer2_Tick
        /// </summary>
        /// <param name="timer"></param>
        /// <param name="tickInMs"></param>
        private void initTimer2(ref System.Windows.Forms.Timer timer, int tickInMs)
        {
            timer = new System.Windows.Forms.Timer();
            timer.Tick += new EventHandler(Timer2_Tick);
            timer.Interval = tickInMs;
        }

        /// <summary>
        /// Då Start-knappen för bluetooth-kommunikationen klickas på kontrolleras att en COM port är vald. 
        /// </summary>
        private void btnComStart_Click(object sender, EventArgs e)
        {
            if (cmbComPorts.SelectedIndex == -1)
            {
                MessageBox.Show("Vänligen välj en COM port", "Fel", MessageBoxButtons.OK);
                return;
            }

            btnComStart.Enabled = false;
            btnComStop.Enabled = true;
            PlayerIndex temp = ((Players)cmbPlayers.SelectedItem).Player;

            if (GamePad.GetState(temp).IsConnected)
            {
                _player = new Xboxkontroll(temp);
            }
            else
            { MessageBox.Show("Kan inte få kontakt med den valda kontrollen", "ERROR!", MessageBoxButtons.OK); }

            OpenConnection(cmbComPorts.Text);
            _timer1.Start();
            _timer2.Start();
            
        }

        /// <summary>
        /// Läser av Xboxkontrollen och sänder detta till roboten.
        /// Lämpligt att byta namn på metoden vid full implementering. 
        /// </summary>
        private void SendCommands()
        {
            byte[] dataToSend = new byte[6];
            if (!_player.APressedDown())
            {
                dataToSend[0] = 1;
                dataToSend[2] = 2;
                dataToSend[4] = 3;
                dataToSend[1] = unchecked((byte)_player.GetLeftY());
                dataToSend[3] = unchecked((byte)_player.GetLeftX());
                dataToSend[5] = unchecked((byte)_player.GetRightX());
                _bt.transmit_byte(dataToSend);
            }
            else
            {
                _bt.transmit_byte(new byte[2] { 4, 0 });
            }
        }

        /// <summary>
        /// Eventet då Uppdatera knappen vid listan med COM-porten trycks på. 
        /// Anropar uppdatering av listan
        /// </summary>
        private void btnCOMUpdate_Click(object sender, EventArgs e)
        {
            UpdateComPorts();
        }

        /// <summary>
        /// Eventet då STOP-knappen för Bluetooth trycks på.
        /// </summary>
        private void btnCOMStop_Click(object sender, EventArgs e)
        {
            btnComStop.Enabled = false;
            btnComStart.Enabled = true;
            _timer1.Stop();
            _timer2.Stop();
            CloseConnection();
        }

        /// <summary>
        /// Eventet då Timer1 når sitt inställda värde för tick. 
        /// </summary>
        private void Timer1_Tick(object sender, EventArgs e)
        {
            UpdateGUIwithListData();
        }

        /// <summary>
        /// Eventet då Timer1 når sitt inställda värde för tick. 
        /// </summary>
        private void Timer2_Tick(object sender, EventArgs e)
        {
            _player.TickUpdate();
            SendCommands();
            //_bt.transmit_byte(new byte[] { 1, 10 });
        }

        /// <summary>
        /// Eventet som körs då bt tagit emot data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="Args"></param>
        void bt_DataReceived(object sender, BtDataReceivedEventArgs Args)
        {
            //Om detta fungerar så låser den locker under tiden eventet körs.
            //Samma lås finns i UpdateGUIwithListData() då _lastData ska accessas. 
            lock (locker)
            {
                _lastData.Clear();
                for (int i = 0; i < Args.btData.Length - 1; i = i + 2)
                {
                    byte type = Args.btData[i];
                    int data = ConvertDataToInt(type, Args.btData[i + 1]);
                    _lastData.Add(new int[2] { Convert.ToInt32(type), data });
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAutomatic_Click(object sender, EventArgs e)
        {
            //Skicka bt_data för aktivering av autonomt läge
            _bt.transmit_byte(new byte[2] { 0x00, 0xFF });
        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            //Skicka bt_data för aktivering av manuellt läge
            _bt.transmit_byte(new byte[2] { 0x00, 0x00 });
        }

        

        private void SetupChart(ref Chart chart, ref List<SensorDataGraph> Data)
        {
            ///Chartareans utseende
            _cArea.AxisX.Minimum = 0;
            _cArea.AxisX.Maximum = _maximumX;
            _cArea.AxisX.MajorGrid.LineColor = orgColor.Color.White;
            _cArea.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            _cArea.AxisX.Interval = _maximumX / 5;
            _cArea.AxisY.Maximum = _maximumY;
            _cArea.AxisY.Minimum = 0;
            _cArea.AxisY.MajorGrid.LineColor = orgColor.Color.White;
            _cArea.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            _cArea.AxisY.Interval = _maximumY / 4;
            _cArea.BackColor = orgColor.Color.Black;
            chart.ChartAreas.Add(_cArea);

            //Ordnar till vilken data som ska plottas. 
            chart.DataSource = Data;
            chart.Series.Add("Sensordatan");
            chart.Series[0].XValueMember = "X";
            chart.Series[0].YValueMembers = "Y";
            chart.DataBind();

            chart.Series[0].ChartType = SeriesChartType.Line;
            chart.Series[0].Color = orgColor.Color.White;
            chart.Series[0].BorderWidth = 2;

            //Lägg in data i Dictionary för Combobox och fyll denna.
            _dictWithChartData.Add("Avstånd fram", _dataFront);
            _dictWithChartData.Add("Avstånd höger", _dataFront);

            cmbChart.DisplayMember = "Key";
            cmbChart.ValueMember = "Value";
            cmbChart.DataSource = new BindingSource(_dictWithChartData, null);
            cmbChart.SelectedValue = Data;

        }

        private void AddValueToChart(ref List<SensorDataGraph> list, int data)
        {
            if(list.Count >= 300)
            {
                list.Clear();
                list.TrimExcess();
            }
            list.Add(new SensorDataGraph(list.Count, data));
            _chart.DataBind();
        }

        private void cmbChart_SelectedIndexChanged(object sender, EventArgs e)
        {
            _chart.DataSource = (List<SensorDataGraph>)cmbChart.SelectedValue;
            _chart.DataBind();
        }


        
    }
}
