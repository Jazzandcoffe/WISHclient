using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using orgColor = System.Drawing;

namespace WISH_client
{
    public partial class MainProgram : Form
    {

        /// <summary>
        /// Fyller Dictionaryn _dictWithChartData med alla Lists som innehåller datan för olika sensorer. 
        /// </summary>
        private void FillDictWithCharts()
        {
            //Lägg in data i Dictionary för Combobox och fyll denna.
            _dictWithChartData.Clear();
            _dictWithChartData.TrimExcess();
            _dictWithChartData.Add(new DictWithCharts { Name = "Avstånd höger", Data = _dataRight });
            _dictWithChartData.Add(new DictWithCharts { Name = "Avstånd vänster", Data = _dataLeft });
            _dictWithChartData.Add(new DictWithCharts { Name = "Avstånd fram", Data = _dataFront });
            _dictWithChartData.Add(new DictWithCharts { Name = "Avstånd bak", Data = _dataBack });
            _dictWithChartData.Add(new DictWithCharts { Name = "Vänster fram", Data = _dataLeftFront });
            _dictWithChartData.Add(new DictWithCharts { Name = "Vänster bak", Data = _dataLeftBack });
            _dictWithChartData.Add(new DictWithCharts { Name = "Höger fram", Data = _dataRightFront });
            _dictWithChartData.Add(new DictWithCharts { Name = "Höger bak", Data = _dataRightBack });
            _dictWithChartData.Add(new DictWithCharts { Name = "Fram övre", Data = _dataFrontUpper });
            _dictWithChartData.Add(new DictWithCharts { Name = "Fram nedre", Data = _dataFrontLower });
            _dictWithChartData.Add(new DictWithCharts { Name = "Bak övre", Data = _dataRearUpper });
            _dictWithChartData.Add(new DictWithCharts { Name = "Bak nedre", Data = _dataRearLower });
            _dictWithChartData.Add(new DictWithCharts { Name = "Typ vänster", Data = _dataTypeLeft });
            _dictWithChartData.Add(new DictWithCharts { Name = "Typ höger", Data = _dataTypeRight });
            _dictWithChartData.Add(new DictWithCharts { Name = "Vinkel vänster", Data = _angelLeft });
            _dictWithChartData.Add(new DictWithCharts { Name = "Vinkel höger", Data = _angelRight });
            _dictWithChartData.Add(new DictWithCharts { Name = "Avvikelse mitt", Data = _deviationMid });
            _dictWithChartData.Add(new DictWithCharts { Name = "Hastighet sidled", Data = _speedDeviation });

            
        }

        /// <summary>
        /// Ordnar till Charten och har default _cAreaPos.
        /// </summary>
        /// <param name="chart">Charten som ska konfigureras</param>
        /// <param name="Data">Datan som ska knytas till grafen</param>
        private void SetupChart(ref Chart chart, ref List<SensorDataGraph> Data)
        {
            _cAreaDist = new ChartArea("Distance");
            _cAreaSigned = new ChartArea("Signed");
            _cAreaType = new ChartArea("Type");

            chart.ChartAreas.Clear();
            chart.Series.Clear();
            ///Chartareans utseende för positiva värden
            _cAreaDist.AxisX.Minimum = 0;
            _cAreaDist.AxisX.Maximum = _maximumX;
            _cAreaDist.AxisX.Interval = _maximumX / 5;
            _cAreaDist.AxisX.MajorGrid.Enabled = false;
            _cAreaDist.AxisY.Maximum = 260;
            _cAreaDist.AxisY.Minimum = 0;
            _cAreaDist.AxisY.MajorGrid.LineColor = orgColor.Color.Blue;
            _cAreaDist.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            _cAreaDist.AxisY.Interval = 65;
            _cAreaDist.BackColor = orgColor.Color.White;

            //Chartareans utseende för negativa värden
            _cAreaSigned.AxisX.Minimum = 0;
            _cAreaSigned.AxisX.Maximum = _maximumX;
            _cAreaSigned.AxisX.Interval = _maximumX / 5;
            _cAreaSigned.AxisX.MajorGrid.Enabled = false;
            _cAreaSigned.AxisY.Maximum = -40;
            _cAreaSigned.AxisY.Minimum = -40;
            _cAreaSigned.AxisY.MajorGrid.LineColor = orgColor.Color.Blue;
            _cAreaSigned.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            _cAreaSigned.AxisY.Interval = 10;
            _cAreaSigned.BackColor = orgColor.Color.White;

            //Chartareans utseende för type-värden
            _cAreaType.AxisX.Minimum = 0;
            _cAreaType.AxisX.Maximum = _maximumX;
            _cAreaType.AxisX.Interval = _maximumX / 5;
            _cAreaType.AxisX.MajorGrid.Enabled = false;
            _cAreaType.AxisY.Maximum = 4;
            _cAreaType.AxisY.Minimum = 0;
            _cAreaType.AxisY.MajorGrid.LineColor = orgColor.Color.Blue;
            _cAreaType.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            _cAreaType.AxisY.Interval = 1;
            _cAreaType.BackColor = orgColor.Color.White;

            chart.ChartAreas.Add(_cAreaDist);
            
            //Ordnar till vilken data som ska plottas. 
            chart.DataSource = Data;
            chart.Series.Add("Sensordatan");
            chart.Series[0].XValueMember = "X";
            chart.Series[0].YValueMembers = "Y";
            chart.DataBind();

            chart.Series[0].ChartType = SeriesChartType.Line;
            chart.Series[0].Color = orgColor.Color.Black;
            chart.Series[0].BorderWidth = 2;

            cmbChart.DataSource = _dictWithChartData;
            cmbChart.DisplayMember = "Name";
            
            cmbChart.SelectedIndex = 0; //Bör anropa selectedIndex changed event. 
        }
        
        /// <summary>
        /// Adderar ett datavärde till en lista med objekt SensorDataGraph.
        /// </summary>
        /// <param name="list">referens till listan</param>
        /// <param name="data">datan som ska läggas in i listan</param>
        private void AddValueToChart(ref List<SensorDataGraph> list, int data)
        {
            lock (lockerChart)
            {
                if (list.Count >= 300)
                {
                    list.Clear();
                    list.TrimExcess();
                }
                list.Add(new SensorDataGraph(list.Count, data));
                _chart.DataBind();
            }
        }
    }
}
