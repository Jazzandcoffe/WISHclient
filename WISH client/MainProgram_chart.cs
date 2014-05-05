using System;
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
            _cAreaPos = new ChartArea("Positive");
            _cAreaSigned = new ChartArea("Signed");
            chart.ChartAreas.Clear();
            chart.Series.Clear();
            ///Chartareans utseende för positiva värden
            _cAreaPos.AxisX.Minimum = 0;
            _cAreaPos.AxisX.Maximum = _maximumX;
            _cAreaPos.AxisX.Interval = _maximumX / 5;
            _cAreaPos.AxisY.Maximum = _maximumY;
            _cAreaPos.AxisY.Minimum = 0;
            _cAreaPos.AxisY.MajorGrid.LineColor = orgColor.Color.Blue;
            _cAreaPos.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            _cAreaPos.AxisY.Interval = _maximumY / 4;
            _cAreaPos.BackColor = orgColor.Color.White;
            _chart.ChartAreas.Add(_cAreaPos);

            //Chartareans utseende för negativa värden
            _cAreaSigned.AxisX.Minimum = 0;
            _cAreaSigned.AxisX.Maximum = _maximumX;
            _cAreaSigned.AxisX.Interval = _maximumX / 5;
            _cAreaSigned.AxisY.Maximum = 60;
            _cAreaSigned.AxisY.Minimum = -60;
            _cAreaSigned.AxisY.MajorGrid.LineColor = orgColor.Color.Blue;
            _cAreaSigned.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            _cAreaSigned.AxisY.Interval = 15;
            _cAreaSigned.BackColor = orgColor.Color.White;


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
            cmbChart.SelectedIndex = 0;
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
