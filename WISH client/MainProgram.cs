using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace WISH_client
{
    /// <summary>
    /// Klassen MainProgram som sköter den GUI ruta som användaren ser. 
    /// </summary>
    public partial class MainProgram : Form
    {
        private class Players
        {
            public string Name { get; set; }
            public PlayerIndex Player { get; set; }
        }

        private Bluetooth _bt; //objektet som sköter kommunikationen via bluetooth. 
        private Dictionary<string, byte[]> _ctrlCommands = new Dictionary<string,byte[]>(); //en dictionary som tolkar en sträng av ett kommando till en byte-array.
        private Dictionary<int, string> _ctrlDecisions = new Dictionary<int,string>(); //en dictionary där en textsträng till typen 5 styrbeslut enkelt kan hämtas. 
        private Timer _timer1; //Timern som är tänkt ticka för kontroll över vilka knappar användaren trycker ner. 
        private Timer _timer2; //Timern som GUI:t är tänkt att uppdateras med. 
        private List<int[]> _lastData = new List<int[]>(); //Senaste datan från bluetooth ligger i denna lista. Vid varje tick kan denna itereras igenom. 
        private List<Players> _playerList = new List<Players>();
        private Xboxkontroll _player;

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
            initTimer1(ref _timer1, 1);

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
            btnComStart.Enabled = true;
            btnComStop.Enabled = false; 
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
            _ctrlCommands.Add("Forward", new byte[2] { 1, 2 });
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
            foreach (int[] element in _lastData)
            { 
                //Kod här, element är varje "paket" som ska uppdatera GUI någonstanns
                //index 0 i element är typen, index 1 är datan. 
            }
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
            if (type != 5 || type != 6)
                return Convert.ToInt32(data);
            else
                return Convert.ToInt32(unchecked((SByte)data));
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
        private void initTimer1(ref Timer timer, int tickInMs)
        {
            timer = new Timer();
            timer.Tick += new EventHandler(Timer1_Tick);
            timer.Interval = tickInMs;
        }

        /// <summary>
        /// Initierar timer2 och ställer in rätt intervall för eventet Timer2_Tick
        /// </summary>
        /// <param name="timer"></param>
        /// <param name="tickInMs"></param>
        private void initTimer2(ref Timer timer, int tickInMs)
        {
            timer = new Timer();
            timer.Tick += new EventHandler(Timer2_Tick);
            timer.Interval = tickInMs;
            timer.Start();
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
            
        }

        /// <summary>
        /// Läser av Xboxkontrollen och sänder detta till roboten.
        /// </summary>
        private void SendCommands()
        {
            if (_player.APressedDown())
            {
                _bt.transmit_byte(new byte[2] { 3, 0 });
            }
            else
            {
                byte forward = unchecked((byte)_player.GetLeftY());
                byte sideways = unchecked((byte)_player.GetLeftX());
                byte rotation = unchecked((byte)_player.GetRightX());

                _bt.transmit_byte(new byte[2] { 0, forward });
                _bt.transmit_byte(new byte[2] { 1, sideways });
                _bt.transmit_byte(new byte[2] { 2, rotation });
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
            CloseConnection();
        }

        /// <summary>
        /// Eventet då Timer1 når sitt inställda värde för tick. 
        /// </summary>
        private void Timer1_Tick(object sender, EventArgs e)
        {
            _player.TickUpdate();
            SendCommands();
        }

        /// <summary>
        /// Eventet då Timer1 når sitt inställda värde för tick. 
        /// </summary>
        private void Timer2_Tick(object sender, EventArgs e)
        { 
            
        }

        /// <summary>
        /// Eventet som körs då bt tagit emot data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="Args"></param>
        void bt_DataReceived(object sender, BtDataReceivedEventArgs Args)
        {
            _lastData.Clear();
            for (int i = 0; i < Args.btData.Length - 1; i = i + 2)
            {
                byte type = Args.btData[i];
                int data = ConvertDataToInt(type, Args.btData[i + 1]);
                _lastData.Add(new int[2] { Convert.ToInt32(type), data });
                Console.WriteLine("Weee tar mig hit");
            }
        }

        /// <summary>
        /// Eventet som tar hand om vad som ska hända då en knapp tryckts ner. 
        /// Ticks ska införas så att den kan kontrollera vilka knappar som är nedtrycka
        /// vid vissa tidpunkter. På det sättet kan fler än en knapp tryckas ned. 
        /// KeyUp- och KeyDownEvent blir då meningslösa.
        /// Måste kollas upp med styrgruppen om styrmodulen klarar av att få ett gå framåt kommando
        /// när den redan går, innan implementation. 
        /// </summary>
        //void Form1_KeyDownEvent(object sender, KeyEventArgs e)
        //{
        //    switch (e.KeyCode)
        //    {
        //        case Keys.Q:
        //            _bt.transmit_byte(_ctrlCommands["Rotate left"]);
        //            break;

        //        case Keys.W:
        //            _bt.transmit_byte(_ctrlCommands["Forward"]);
        //            break;

        //        case Keys.E:
        //            _bt.transmit_byte(_ctrlCommands["Rotate right"]);
        //            break;

        //        case Keys.A:
        //            _bt.transmit_byte(_ctrlCommands["Left"]);
        //            break;

        //        case Keys.S:
        //            _bt.transmit_byte(_ctrlCommands["Back"]);
        //            break;

        //        case Keys.D:
        //            _bt.transmit_byte(_ctrlCommands["Right"]);
        //            break;

        //        case Keys.Space:
        //            _bt.transmit_byte(_ctrlCommands["Reset"]);
        //            break;

        //        ///<summary>
        //        ///Knapparna D1, D2, D3, D4 ska implementeras i GUI där man kan välja hastighet
        //        ///Låter därför denna koden finnas kvar. 
        //        ///</summary>
        //        //1
        //        case Keys.D1:
        //            _bt.transmit_byte(new byte[1] { 3 });
        //            _bt.transmit_byte(new byte[1] { 0 });
        //            break;
        //        //2
        //        case Keys.D2:
        //            _bt.transmit_byte(new byte[1] { 3 });
        //            _bt.transmit_byte(new byte[1] { 1 });
        //            break;
        //        //3
        //        case Keys.D3:
        //            _bt.transmit_byte(new byte[1] { 3 });
        //            _bt.transmit_byte(new byte[1] { 2 });
        //            break;
        //        //4
        //        case Keys.D4:
        //            _bt.transmit_byte(new byte[1] { 3 });
        //            _bt.transmit_byte(new byte[1] { 3 });
        //            break;
        //    }
        //}

        /// <summary>
        /// se kommentar på KeyDownEvent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //void Form1_KeyUpEvent(object sender, KeyEventArgs e)
        //{
        //    switch (e.KeyCode)
        //    {
        //        //q
        //        case Keys.Q:
        //            _bt.transmit_byte(new byte[1] { 2 });
        //            _bt.transmit_byte(new byte[1] { 5 });
        //            break;
        //        //w
        //        case Keys.W:
        //            _bt.transmit_byte(new byte[1] { 2 });
        //            _bt.transmit_byte(new byte[1] { 2 });
        //            break;
        //        //e
        //        case Keys.E:
        //            _bt.transmit_byte(new byte[1] { 2 });
        //            _bt.transmit_byte(new byte[1] { 4 });
        //            break;
        //        //a
        //        case Keys.A:
        //            _bt.transmit_byte(new byte[1] { 2 });
        //            _bt.transmit_byte(new byte[1] { 11 });
        //            break;
        //        //s
        //        case Keys.S:
        //            _bt.transmit_byte(new byte[1] { 2 });
        //            _bt.transmit_byte(new byte[1] { 3 });
        //            break;
        //        //d
        //        case Keys.D:
        //            _bt.transmit_byte(new byte[1] { 2 });
        //            _bt.transmit_byte(new byte[1] { 10 });
        //            break;
        //    }
        //}


        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
