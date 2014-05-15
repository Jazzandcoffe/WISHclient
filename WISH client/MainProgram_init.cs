using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using Microsoft.Xna.Framework;
using orgColor = System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace WISH_client
{
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
        /// Uppdaterar comboboxen i GUIet med de COM-portar datorn kan känna av just nu. 
        /// </summary>
        private void UpdateComPorts()
        {
            cmbComPorts.Items.Clear();
            cmbComPorts.Items.AddRange(SerialPort.GetPortNames());
        }

        /// <summary>
        /// Definierar alla variabler som finns i klassen.
        /// </summary>
        private void DefineVariables()
        {
            _dataFront = new Sensor(0, 260, 52);
            _dataBack = new Sensor(0, 260, 52);
            _dataRight = new Sensor(0, 260, 52);
            _dataLeft = new Sensor(0, 260, 52);
            _dataTypeRight = new Sensor(0, 4, 1);
            _dataTypeLeft = new Sensor(0, 4, 1);
            _dataTypeFront = new Sensor(0, 4, 1);
            _dataTypeBack = new Sensor(0, 4, 1);
            _angelRight = new Sensor(-40, 40, 10);
            _angelLeft = new Sensor(-40, 40, 10);
            _deviationMid = new Sensor(-30, 30, 10);
            _speedDeviation = new Sensor(-30, 30, 10);
            _dataFrontLower = new Sensor(0, 260, 52);
            _dataFrontUpper = new Sensor(0, 260, 52);
            _dataRearLower = new Sensor(0, 260, 52);
            _dataRearUpper = new Sensor(0, 260, 52);
            _dataLeftBack = new Sensor(0, 260, 52);
            _dataLeftFront = new Sensor(0, 260, 52);
            _dataRightBack = new Sensor(0, 260, 52);
            _dataRightFront = new Sensor(0, 260, 52);

            _dictWithSensors = new List<NameAndSensor>();
            _lastData = new List<int[]>();
            locker = new object();
        }

        /// <summary>
        /// Initierar alla Sensor-objekt så att de tillhör rätt Label
        /// och ställer även in vilken färg olika datavärden ger. 
        /// Default: Grönt om inget annat anges. 
        /// </summary>
        private void initSensors()
        {
            //Tilldelning av rätt label till rätt Sensor.
            _dataBack.Label = lblDistRear;
            _dataFront.Label = lblDistFront;
            _dataLeft.Label = lblDistLeft;
            _dataRight.Label = lblDistRight;
            _dataRearLower.Label = lblBackLower;
            _dataRearUpper.Label = lblBackUpper;
            _dataFrontLower.Label = lblFrontLower;
            _dataFrontUpper.Label = lblFrontUpper;
            _dataLeftBack.Label = lblLeftBack;
            _dataLeftFront.Label = lblLeftFront;
            _dataRightBack.Label = lblRightBack;
            _dataRightFront.Label = lblRightFront;
            _dataTypeBack.Label = lblRearDetect;
            _dataTypeFront.Label = lblFrontDetect;
            _dataTypeRight.Label = lblRightDetect;
            _dataTypeLeft.Label = lblLeftDetect;
            _deviationMid.Label = lblDistanceMid;
            _speedDeviation.Label = lblSpeedMid;
            _angelLeft.Label = lblAngleLeft;
            _angelRight.Label = lblAngleRight;


            _dataBack.YellowValues = new int[1] { 255 };
            _dataBack.RedValues = new int[1] { 0 };
            _dataFront.YellowValues = new int[1] { 255 };
            _dataFront.RedValues = new int[1] { 0 };
            _dataRight.YellowValues = new int[1] { 255 };
            _dataRight.RedValues = new int[1] { 0 };
            _dataLeft.YellowValues = new int[1] { 255 };
            _dataLeft.RedValues = new int[1] { 0 };
            _dataRearLower.YellowValues = new int[1] { 255 };
            _dataRearLower.RedValues = new int[1] { 0 };
            _dataRearUpper.YellowValues = new int[1] { 255 };
            _dataRearUpper.RedValues = new int[1] { 0 };
            _dataFrontLower.YellowValues = new int[1] { 255 };
            _dataFrontLower.RedValues = new int[1] { 0 };
            _dataFrontUpper.YellowValues = new int[1] { 255 };
            _dataFrontUpper.RedValues = new int[1] { 0 };
            _dataLeftBack.YellowValues = new int[1] { 255 };
            _dataLeftBack.RedValues = new int[1] { 0 };
            _dataLeftFront.YellowValues = new int[1] { 255 };
            _dataLeftFront.RedValues = new int[1] { 0 };
            _dataRightBack.YellowValues = new int[1] { 255 };
            _dataRightBack.RedValues = new int[1] { 0 };
            _dataRightFront.YellowValues = new int[1] { 255 };
            _dataRightFront.RedValues = new int[1] { 0 };
            _dataTypeBack.YellowValues = new int[2] { 1, 3 };
            _dataTypeBack.RedValues = new int[1] { 0 };
            _dataTypeFront.YellowValues = new int[2] { 1, 3 };
            _dataTypeFront.RedValues = new int[1] { 0 };
            _dataTypeLeft.YellowValues = new int[2] { 1, 3 };
            _dataTypeLeft.RedValues = new int[1] { 0 };
            _dataTypeRight.YellowValues = new int[2] { 1, 3 };
            _dataTypeRight.RedValues = new int[1] { 0 };
            _deviationMid.YellowValues = new int[1] { 127 };
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
            _ctrlDecisions.Add(1, "Påbörjar vänster sväng");
            _ctrlDecisions.Add(2, "Påbörjar höger sväng");
            _ctrlDecisions.Add(3, "Klar med sväng");
            _ctrlDecisions.Add(4, "Scannar omgivning");
            _ctrlDecisions.Add(5, "Inget detekterat");
            _ctrlDecisions.Add(6, "Påbörjar klättring");
            _ctrlDecisions.Add(7, "Avslutar klättring");
            _ctrlDecisions.Add(8, "Byter färdriktning");
            _ctrlDecisions.Add(9, "Ignorera öppning till höger");
            _ctrlDecisions.Add(10, "Ignorera öppning till vänster");
            _ctrlDecisions.Add(11, "Rotation höger");
            _ctrlDecisions.Add(12, "Rotation vänster");
        }

        /// <summary>
        /// Ordnar till Charten och har default _cAreaPos.
        /// </summary>
        /// <param name="chart">Charten som ska konfigureras</param>
        /// <param name="Data">Datan som ska knytas till grafen</param>
        private void SetupChart(ref Chart chart, ref Sensor Data)
        {
            _chartArea = new ChartArea("ChartArea");

            chart.ChartAreas.Clear();
            chart.Series.Clear();
            ///Chartareans utseende för positiva värden
            _chartArea.AxisX.Minimum = 0;
            _chartArea.AxisX.Maximum = 300;
            _chartArea.AxisX.Interval = 60;
            _chartArea.AxisX.MajorGrid.Enabled = false;
            _chartArea.AxisY.Maximum = 260;
            _chartArea.AxisY.Minimum = 0;
            _chartArea.AxisY.MajorGrid.LineColor = orgColor.Color.Blue;
            _chartArea.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            _chartArea.AxisY.Interval = 65;
            _chartArea.BackColor = orgColor.Color.White;

            chart.ChartAreas.Add(_chartArea);

            //Ordnar till vilken data som ska plottas. 
            chart.DataSource = Data.SensorData;
            chart.Series.Add("Sensordatan");
            chart.Series[0].XValueMember = "X";
            chart.Series[0].YValueMembers = "Y";
            chart.DataBind();

            chart.Series[0].ChartType = SeriesChartType.Line;
            chart.Series[0].Color = orgColor.Color.Black;
            chart.Series[0].BorderWidth = 2;

            cmbChart.DataSource = _dictWithSensors;
            cmbChart.DisplayMember = "Name";

            cmbChart.SelectedIndex = 0; //Bör anropa selectedIndex changed event. 
        }

        /// <summary>
        /// Fyller Dictionaryn _dictWithChartData med alla Lists som innehåller datan för olika sensorer. 
        /// </summary>
        private void FillDictWithCharts()
        {
            //Lägg in data i Dictionary för Combobox och fyll denna.
            _dictWithSensors.Clear();
            _dictWithSensors.TrimExcess();
            _dictWithSensors.Add(new NameAndSensor { Name = "Avvikelse mitt", Sensor = _deviationMid });
            _dictWithSensors.Add(new NameAndSensor { Name = "Hastighet sidled", Sensor = _speedDeviation });
            _dictWithSensors.Add(new NameAndSensor { Name = "Typ höger", Sensor = _dataTypeRight });
            _dictWithSensors.Add(new NameAndSensor { Name = "Typ vänster", Sensor = _dataTypeLeft });
            _dictWithSensors.Add(new NameAndSensor { Name = "Avstånd fram", Sensor = _dataFront });
            _dictWithSensors.Add(new NameAndSensor { Name = "Avstånd bak", Sensor = _dataBack });
            _dictWithSensors.Add(new NameAndSensor { Name = "Typ fram", Sensor = _dataTypeFront });
            _dictWithSensors.Add(new NameAndSensor { Name = "Typ bak", Sensor = _dataTypeBack });
            _dictWithSensors.Add(new NameAndSensor { Name = "Avstånd höger", Sensor = _dataRight });
            _dictWithSensors.Add(new NameAndSensor { Name = "Avstånd vänster", Sensor = _dataLeft });
            _dictWithSensors.Add(new NameAndSensor { Name = "Vinkel höger", Sensor = _angelRight });
            _dictWithSensors.Add(new NameAndSensor { Name = "Vinkel vänster", Sensor = _angelLeft });
            _dictWithSensors.Add(new NameAndSensor { Name = "Vänster bak", Sensor = _dataLeftBack });
            _dictWithSensors.Add(new NameAndSensor { Name = "Vänster fram", Sensor = _dataLeftFront });
            _dictWithSensors.Add(new NameAndSensor { Name = "Höger bak", Sensor = _dataRightBack });
            _dictWithSensors.Add(new NameAndSensor { Name = "Höger fram", Sensor = _dataRightFront });
            _dictWithSensors.Add(new NameAndSensor { Name = "Fram nedre", Sensor = _dataFrontLower });
            _dictWithSensors.Add(new NameAndSensor { Name = "Fram övre", Sensor = _dataFrontUpper });
            _dictWithSensors.Add(new NameAndSensor { Name = "Bak nedre", Sensor = _dataRearLower });
            _dictWithSensors.Add(new NameAndSensor { Name = "Bak övre", Sensor = _dataRearUpper });
        }
    }
    /// <summary>
    /// Klass som listan fylls med som utgör datapunkterna i grafen. 
    /// </summary>
    public class SensorDataGraph
    {

        public SensorDataGraph(int valueX, int valueY)
        {
            X = valueX;
            Y = valueY;
        }

        public int X
        { get; set; }

        public int Y
        { get; set; }
    }

    /// <summary>
    /// Klass som innehåller namn och vilket Sensor-objekt. 
    /// </summary>
    public class NameAndSensor
    {
        public Sensor Sensor
        { get; set; }

        public string Name
        { get; set; }
    }
}
