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
        /// Chart variabler
        /// </summary>
        public ChartArea _chartArea;
        private Sensor _dataFront;
        private Sensor _dataBack;
        private Sensor _dataRight;
        private Sensor _dataLeft;
        private Sensor _dataTypeRight;
        private Sensor _dataTypeLeft;
        private Sensor _angelRight;
        private Sensor _angelLeft;
        private Sensor _deviationMid;
        private Sensor _speedDeviation;
        private Sensor _dataLeftFront;
        private Sensor _dataLeftBack;
        private Sensor _dataRightFront;
        private Sensor _dataRightBack;
        private Sensor _dataFrontUpper;
        private Sensor _dataFrontLower;
        private Sensor _dataRearUpper;
        private Sensor _dataRearLower;
        private Sensor _dataTypeFront;
        private Sensor _dataTypeBack;

        private List<NameAndSensor> _dictWithSensors;


        private Bluetooth _bt; //objektet som sköter kommunikationen via bluetooth. 
        private Dictionary<int, string> _ctrlDecisions = new Dictionary<int,string>(); //en dictionary där en textsträng till typen 5 styrbeslut enkelt kan hämtas. 
        private System.Windows.Forms.Timer _timer1; //Timern som är tänkt ticka för kontroll över vilka knappar användaren trycker ner. 
        private System.Windows.Forms.Timer _timer2; //Timern som GUI:t är tänkt att uppdateras med. 
        private List<int[]> _lastData; //Senaste datan från bluetooth ligger i denna lista. Vid varje tick kan denna itereras igenom. 
        private List<Players> _playerList = new List<Players>();
        private Xboxkontroll _player;
        public static object locker;   //Låsobjekt, för att ingen information ska visas vid låsning av access till _lastData.
        List<int[]> temp = new List<int[]>();
        int[] dataOfType = new int[40];

        /// <summary>
        /// Konstruktorn för klassen.
        /// </summary>
        public MainProgram()
        {
            InitializeComponent();
            ClearGUI();
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
            SetupChart(ref _chart,ref _dataFront);
            initSensors();
            lblBaudRate.Text = "115200";
            DisableGUI();
        }

        /// <summary>
        /// Gör alla kontroller utom konfigureringen för COM Porten disabled. 
        /// Ska anropas vid reset och då Stop-knappen används för COM porten. 
        /// </summary>
        private void DisableGUI()
        {
            btnComStart.Enabled = true;
            btnComStop.Enabled = false;
            btnManual.Enabled = false;
            btnAutomatic.Enabled = false;
            btnStop.Enabled = false;
            cmbChart.Enabled = false;
            cmbPlayers.Enabled = false;
            lblPlayer.Enabled = false;
            rbtnSpeed1.Checked = true;
            rbtnSpeed2.Checked = false;
            rbtnSpeed3.Checked = false;
            rbtnSpeed4.Checked = false;
            rbtnSpeed1.Enabled = false;
            rbtnSpeed2.Enabled = false;
            rbtnSpeed3.Enabled = false;
            rbtnSpeed4.Enabled = false;
            btnSend.Enabled = false;
        }

        /// <summary>
        /// Gör alla kontroller tillgängliga till användaren. Anropas av Reset och när Start knappen används. 
        /// </summary>
        private void EnableGUI()
        {
            btnComStart.Enabled = false;
            btnComStop.Enabled = true;
            btnAutomatic.Enabled = true;
            btnManual.Enabled = true;
            cmbPlayers.Enabled = true;
            cmbChart.Enabled = true;
            lblPlayer.Enabled = true;
            rbtnSpeed1.Enabled = true;
            rbtnSpeed2.Enabled = true;
            rbtnSpeed3.Enabled = true;
            rbtnSpeed4.Enabled = true;
            btnStop.Enabled = true;
            btnSend.Enabled = true;
            txtOutput.Text = "------------Start------------" + Environment.NewLine;
        }

        /// <summary>
        /// Rensar alla labels från data, bör endast anropas vid start. 
        /// Ifall återställning sker är det bekvämt att kunna se senaste värden. 
        /// Därför används inte denna av Reset. 
        /// </summary>
        private void ClearGUI()
        {
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
            lblAngleLeft.Text = String.Empty;
            lblAngleRight.Text = String.Empty;
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
        /// Avkodar listan med int[] element och gör uppdaterar GUI korrekt efter detta. 
        /// Denna funktion ska vara en hjälpfunktion till tick-funktionen i programmet. 
        /// Funktionen kan då köras vid varje tick. 
        /// Glöm inte Dictionaryn för styrbeslut där det enkelt går att hämta rätt string för
        /// typen 5. 
        /// </summary>
        private void UpdateGUIwithListData()
        {
            //bt_DataReceived sätter denna till true, har snabbare tick än denna metod.
            //Om isConnected skulle vara false betyder det att kontakten via bluetooth brutits eller är felaktig.
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

            _dictWithSensors[0].Sensor.AddValue(dataOfType[5]);
            _dictWithSensors[1].Sensor.AddValue(dataOfType[6]);
            _dictWithSensors[2].Sensor.AddValue(dataOfType[7]);
            _dictWithSensors[3].Sensor.AddValue(dataOfType[8]);
            _dictWithSensors[4].Sensor.AddValue(dataOfType[9]);
            _dictWithSensors[5].Sensor.AddValue(dataOfType[10]);
            _dictWithSensors[6].Sensor.AddValue(dataOfType[11]);
            _dictWithSensors[7].Sensor.AddValue(dataOfType[12]);
            _dictWithSensors[8].Sensor.AddValue(dataOfType[13]);
            _dictWithSensors[9].Sensor.AddValue(dataOfType[14]);
            _dictWithSensors[10].Sensor.AddValue(dataOfType[15]);
            _dictWithSensors[11].Sensor.AddValue(dataOfType[16]);
            _dictWithSensors[12].Sensor.AddValue(dataOfType[17]);
            _dictWithSensors[13].Sensor.AddValue(dataOfType[18]);
            _dictWithSensors[14].Sensor.AddValue(dataOfType[19]);
            _dictWithSensors[15].Sensor.AddValue(dataOfType[20]);
            _dictWithSensors[16].Sensor.AddValue(dataOfType[21]);
            _dictWithSensors[17].Sensor.AddValue(dataOfType[22]);
            _dictWithSensors[18].Sensor.AddValue(dataOfType[23]);
            _dictWithSensors[19].Sensor.AddValue(dataOfType[24]);

            updateTxtBox(dataOfType[32]); 

            _chart.DataBind();
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
        private void updateTxtBox(int data)
        {
            if (data > _ctrlDecisions.Count || data == 0)
                return;

            string[] temp = new string[15];
            string text = _ctrlDecisions[data];

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
    }
}
