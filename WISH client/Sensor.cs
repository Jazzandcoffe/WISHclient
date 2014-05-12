using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WISH_client
{
    public class Sensor
    {
        private Label _label;
        private int[] _redValues;
        private int[] _yellowValues;
        private int[] _greenValues;

        private List<SensorDataGraph> _sensorValues = new List<SensorDataGraph>();

        public Sensor(int ymin,int ymax,int interval)
        {
            XMax = 300;
            XMin = 0;
            YMax = ymax;
            YMin = ymin;
            Interval = interval;
        }

        public Label Label
        {
            get { return _label; }
            set { _label = value; }
        }

        public int[] RedValues
        {
            get { return _redValues; }
            set { _redValues = value; }
        }

        public int[] YellowValues
        {
            get { return _yellowValues; }
            set { _yellowValues = value; }
        }

        public int[] GreenValues
        {
            get { return _greenValues; }
            set { _greenValues = value; }
        }

        public List<SensorDataGraph> SensorData
        {
            get { return _sensorValues; }
        }

        public int YMin
        { get; set; }

        public int YMax
        { get; set; }

        public int XMin
        { get; set; }

        public int XMax
        { get; set; }

        public int Interval
        { get; set; }

        /// <summary>
        /// Anropas när ett nytt värde läggs in. 
        /// Denna metod uppdaterar även det värdet i textboxen, 
        /// ser även till att rätt färg visas. 
        /// </summary>
        /// <param name="data">värdet som ska läggas till</param>
        public void AddValue(int data)
        {
            if (_sensorValues.Count >= 300)
            {
                _sensorValues.Clear();
                _sensorValues.TrimExcess();
            }
            _sensorValues.Add(new SensorDataGraph(_sensorValues.Count, data));

            ChangeTxtBox(data);
        }


        /// <summary>
        /// Lägger in senaste adderade värdet i textboxen. 
        /// Ändrar även till rätt färg i textboxen. 
        /// </summary>
        /// <param name="data"></param>
        private void ChangeTxtBox(int data)
        {
            _label.Text = data.ToString();

            if(_redValues != null && _redValues.Contains(data))
            { _label.BackColor = Color.Red; }
            else if (_yellowValues != null && _yellowValues.Contains(data))
            { _label.BackColor = Color.Yellow; }
            else
            { _label.BackColor = Color.Green; }
        }
    }
}
