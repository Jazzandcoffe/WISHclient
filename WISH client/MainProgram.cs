using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        public ChartArea _cAreaDist;
        public ChartArea _cAreaSigned;
        public ChartArea _cAreaType;
        private double _maximumX = 300;
        private List<SensorDataGraph> _dataFront;
        private List<SensorDataGraph> _dataBack;
        private List<SensorDataGraph> _dataRight;
        private List<SensorDataGraph> _dataLeft;
        private List<SensorDataGraph> _dataTypeRight;
        private List<SensorDataGraph> _dataTypeLeft;
        private List<SensorDataGraph> _angelRight;
        private List<SensorDataGraph> _angelLeft;
        private List<SensorDataGraph> _deviationMid;
        private List<SensorDataGraph> _speedDeviation;

        private List<DictWithCharts> _dictWithChartData;


        private Bluetooth _bt; //objektet som sköter kommunikationen via bluetooth. 
        private Dictionary<string, byte[]> _ctrlCommands = new Dictionary<string,byte[]>(); //en dictionary som tolkar en sträng av ett kommando till en byte-array.
        private Dictionary<int, string> _ctrlDecisions = new Dictionary<int,string>(); //en dictionary där en textsträng till typen 5 styrbeslut enkelt kan hämtas. 
        private System.Windows.Forms.Timer _timer1; //Timern som är tänkt ticka för kontroll över vilka knappar användaren trycker ner. 
        private System.Windows.Forms.Timer _timer2; //Timern som GUI:t är tänkt att uppdateras med. 
        private List<int[]> _lastData; //Senaste datan från bluetooth ligger i denna lista. Vid varje tick kan denna itereras igenom. 
        private List<Players> _playerList = new List<Players>();
        private Xboxkontroll _player;
        public static object locker;   //Låsobjekt, för att ingen information ska visas vid låsning av access till _lastData.
        private object lockerChart;  //Låser chart
        List<int[]> temp = new List<int[]>();
        int[] dataOfType = new int[40];

        /// <summary>
        /// Konstruktorn för klassen.
        /// </summary>
        public MainProgram()
        {
            InitializeComponent();
            Initialize();
        }

        /// <summary>
        /// Ställer in allt som är visuellt för användaren.
        /// </summary>
        private void Initialize()
        {
            DefineVariables();
            initTimer1(ref _timer1, 100);
            initTimer2(ref _timer2, 60);
            UpdateComPorts();
            FillDictWithCharts();
            FillControlDecisionsDictionary();
            FillPlayersComboBox();
            SetupChart(ref _chart, ref _dataFront);
            lblBaudRate.Text = "115200";
            lblDistanceMid.Text = String.Empty;
            lblLeftDetect.Text = String.Empty;
            lblRightDetect.Text = String.Empty;
            lblSpeedMid.Text = String.Empty;
            lblDistFront.Text = String.Empty;
            lblDistLeft.Text = String.Empty;
            lblDistRear.Text = String.Empty;
            lblDistRight.Text = String.Empty;
            lblFrontDetect.Text = String.Empty;
            lblRearDetect.Text = String.Empty;
            lblBackUpper.Text = String.Empty;
            lblBackLower.Text = String.Empty;
            lblFrontLower.Text = String.Empty;
            lblFrontUpper.Text = String.Empty;
            lblLeftBack.Text = String.Empty;
            lblLeftFront.Text = String.Empty;
            lblRightBack.Text = String.Empty;
            lblRightFront.Text = String.Empty;

            txtKd.Text = "0";
            txtKp.Text = "0";
            btnComStart.Enabled = true;
            btnComStop.Enabled = false;
            btnManual.Enabled = false; 
            btnAutomatic.Enabled = false;
            cmbChart.Enabled = false;
            cmbPlayers.Enabled = false;
            txtKd.Enabled = false;
            txtKp.Enabled = false;
            btnSendControls.Enabled = false;
            lblPlayer.Enabled = false;
            txtOutput.Text = String.Empty;

        }

        /// <summary>
        /// Återställer programmet till sitt grundläge. 
        /// </summary>
        private void Reset()
        {
            _timer1.Tick -= new EventHandler(Timer1_Tick);
            _timer2.Tick -= new EventHandler(Timer2_Tick);
            _timer1.Stop();
            _timer2.Stop();
            Initialize();
        }

        /// <summary>
        /// Uppdaterar comboboxen i GUIet med de COM-portar datorn kan känna av just nu. 
        /// </summary>
        private void UpdateComPorts()
        {
            cmbComPorts.Items.Clear();
            cmbComPorts.Items.AddRange(SerialPort.GetPortNames());
        }

        //Definierar alla variabler som finns i klassen.
        private void DefineVariables()
        {
            _dataFront = new List<SensorDataGraph>();
            _dataBack = new List<SensorDataGraph>();
            _dataRight = new List<SensorDataGraph>();
            _dataLeft = new List<SensorDataGraph>();
            _dataTypeRight = new List<SensorDataGraph>();
            _dataTypeLeft = new List<SensorDataGraph>();
            _angelRight = new List<SensorDataGraph>();
            _angelLeft = new List<SensorDataGraph>();
            _deviationMid = new List<SensorDataGraph>();
            _speedDeviation = new List<SensorDataGraph>();

            _dictWithChartData = new List<DictWithCharts>();
            _lastData = new List<int[]>();
            locker = new object();
            lockerChart = new object();
        }

        

        /// <summary>
        /// Fyller combobox med spelarna. 
        /// </summary>
        private void FillPlayersComboBox()
        {
            _playerList.Clear();
            _playerList.TrimExcess();
            _playerList.Add(new Players { Name = "1", Player = PlayerIndex.One });
            _playerList.Add(new Players { Name = "2", Player = PlayerIndex.Two });
            _playerList.Add(new Players { Name = "3", Player = PlayerIndex.Three });
            _playerList.Add(new Players { Name = "4", Player = PlayerIndex.Four });
            cmbPlayers.DataSource = _playerList;
            cmbPlayers.DisplayMember = "Name";
        }

        /// <summary>
        /// Fyller en Dictionary för att kunna tolka datan från styrmodulen. 
        /// Hämtat från Excel-dokumentet på dropbox. (Bussprotokoll.xlsx)
        /// Dessa gäller då typen är 5. 
        /// Detta gör att det går enkelt att hämta ut vad en viss data från typen 5 är i en string. 
        /// </summary>
        private void FillControlDecisionsDictionary()
        {
            _ctrlDecisions.Clear();
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
                if (element[0] > 4 && element[0] < 40)
                    dataOfType[element[0]] = element[1];
            }

            lblDistanceMid.Text = dataOfType[5].ToString();
            lblSpeedMid.Text = dataOfType[6].ToString();
            lblRightDetect.Text = dataOfType[7].ToString();
            lblLeftDetect.Text = dataOfType[8].ToString();
            lblDistFront.Text = dataOfType[9].ToString();
            lblDistRear.Text = dataOfType[10].ToString();
            lblFrontDetect.Text = dataOfType[11].ToString();
            lblRearDetect.Text = dataOfType[12].ToString();
            lblDistRight.Text = dataOfType[13].ToString();
            lblDistLeft.Text = dataOfType[14].ToString();
            lblAngleRight.Text = dataOfType[15].ToString();
            lblAngleLeft.Text = dataOfType[16].ToString();
            lblLeftBack.Text = dataOfType[17].ToString();
            lblLeftFront.Text = dataOfType[18].ToString();
            lblRightBack.Text = dataOfType[19].ToString();
            lblRightFront.Text = dataOfType[20].ToString();
            lblFrontLower.Text = dataOfType[21].ToString();
            lblFrontUpper.Text = dataOfType[22].ToString();
            lblBackLower.Text = dataOfType[23].ToString();
            lblBackUpper.Text = dataOfType[24].ToString();
            ChangeLabelColors();

            updateTxtBox(dataOfType[32].ToString()); //Ändra typ efter protokoll  ((((EJ implementerad i Styr))))
            AddValueToChart(ref _dataFront, dataOfType[9]);
            AddValueToChart(ref _dataRight, dataOfType[13]);
            AddValueToChart(ref _dataBack, dataOfType[10]);
            AddValueToChart(ref _dataLeft, dataOfType[14]);
            AddValueToChart(ref _dataTypeLeft, dataOfType[8]);
            AddValueToChart(ref _dataTypeRight, dataOfType[7]);
            AddValueToChart(ref _deviationMid, dataOfType[5]);
            AddValueToChart(ref _speedDeviation, dataOfType[6]);
            AddValueToChart(ref _angelLeft, dataOfType[16]);
            AddValueToChart(ref _angelRight, dataOfType[15]);
        }

        /// <summary>
        /// Då vissa värden kommer vara i en byte och ska tolkas som 2Complement krävs denna funktionen. 
        /// </summary>
        /// <param name="value">Byten som ska konverteras till int med 2-komplement</param>
        /// <returns>Returnerar konverterat värde</returns>
        private int ConvertByteToInt_2Complement(byte value)
        { 
            return Convert.ToInt32(unchecked((SByte) value));
        }

        /// <summary>
        /// Konverterar ett data-fälts värde till int. 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private int ConvertDataToInt(byte type, byte data)
        {
            if (type != 5 && type != 6 && type != 15 && type != 16)
            { return Convert.ToInt32(data); }
            else
            { return Convert.ToInt32(unchecked((SByte)data)); }
        }

        /// <summary>
        /// Skapar Bluetooth objektet och öppnar porten. 
        /// Aktiverar även eventet som triggas när Bluetooth-objektet tömt inkommande buffern. 
        /// </summary>
        /// <param name="port">COM-porten som seriellporten ska öppnas mot</param>
        /// <returns>True om öppningen lyckades, false annars</returns>
        private bool OpenConnection(string port)
        {
            try
            {
                _bt = new Bluetooth(port);
                _bt.OpenPort();
                _bt.BtDataReceived += new BtDataReceivedEventHandler(bt_DataReceived);
                return true;
            }
            catch
            {
                _bt = null;
                MessageBox.Show("Kan inte öppna porten mot Bluetoothen!", "Fel", MessageBoxButtons.OK);
                return false;
            }
            
        }

        /// <summary>
        /// Stänger porten och stänger av eventet om något skulle tagits emot.
        /// </summary>
        public void CloseConnection()
        {
            try
            {   
                _bt.ClosePort();
                //Stänger av eventet så att ingen behandling görs ifall porten skulle skicka ut data.
                _bt.BtDataReceived -= bt_DataReceived;
            }
            catch
            { 
                MessageBox.Show("Kan inte stänga porten mot Bluetoothen", "Fel", MessageBoxButtons.OK);
            }
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
        /// Uppdaterar txtBox om ett nytt styrbeslut kommer.
        /// Placerar senaste styrbeslutet överst och skiftar ner de historiska besluten.
        /// </summary>
        private void updateTxtBox(string text)
        {
            string[] temp = new string[15];

            if(txtOutput.Lines.Length > 25)
            {
                Array.Copy(txtOutput.Lines, 0, temp, 0, 15);
                txtOutput.Lines = temp;
            }

            if (txtOutput.Lines.Length == 0)
            {
                txtOutput.Text = text + Environment.NewLine;
            }
            else if (txtOutput.Lines[0] != text)
            {
                txtOutput.Text = text + Environment.NewLine + txtOutput.Text + Environment.NewLine;
            }
        }

        /// <summary>
        /// Metod som läser av txtKp och txtKd. Metoden kontrollerar även
        /// att värdet i textboxarna är ett giltigt byte värde (0-255).
        /// </summary>
        /// <param name="Kp">Värdet från txtKp.Text i Byte</param>
        /// <param name="Kd">Värdet från txtKd.Text i Byte</param>
        /// <returns>True om konverteringen av båda är giltig</returns>
        private bool ReadControlValues(out Byte Kp, out Byte Kd)
        {
            Kp = 0;
            Kd = 0;
            return (Byte.TryParse(txtKp.Text, out Kp) && Byte.TryParse(txtKd.Text, out Kd));
        }

        private void ChangeLabelColors()
        {
            //Typ höger färgning
            if (dataOfType[7] == 3 || dataOfType[7] == 1)
                lblDistRight.BackColor = orgColor.Color.Yellow;
            else if (dataOfType[7] == 0)
                lblDistRight.BackColor = orgColor.Color.Green;
            else if (dataOfType[7] == 2)
                lblDistRight.BackColor = orgColor.Color.Red;

            //Typ vänster färgning
            if (dataOfType[8] == 3 || dataOfType[8] == 1)
                lblDistLeft.BackColor = orgColor.Color.Yellow;
            else if (dataOfType[7] == 0)
                lblDistLeft.BackColor = orgColor.Color.Green;
            else if (dataOfType[7] == 2)
                lblDistLeft.BackColor = orgColor.Color.Red;
        }



        
    }
}
