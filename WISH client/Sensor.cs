/* 
 * Programmerare:
 * Robin Holmbom
 * Tore Landen
 * Herman Molinder
 * 
 * Datum: 2014-05-25
 * Version 1.0
 *
 */

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

        //Listan som alla sensordvärden läggs in i.
        private List<SensorDataGraph> _sensorValues = new List<SensorDataGraph>();

        public Sensor(int ymin,int ymax,int interval)
        {
            XMax = 300;
            XMin = 0;
            YMax = ymax;
            YMin = ymin;
            Interval = interval;
        }

        //Tillhörande label som visar senaste sensorvärdet. 
        public Label Label
        {
            get { return _label; }
            set { _label = value; }
        }

        //Värdena i array ger röd bakgrund i tillhörande label
        public int[] RedValues
        {
            get { return _redValues; }
            set { _redValues = value; }
        }

        //Värdena i array ger gul bakgrund i tillhörande label
        public int[] YellowValues
        {
            get { return _yellowValues; }
            set { _yellowValues = value; }
        }

        //Värdena i array ger grön bakgrund i tillhörande label
        public int[] GreenValues
        {
            get { return _greenValues; }
            set { _greenValues = value; }
        }

        public List<SensorDataGraph> SensorData
        {
            get { return _sensorValues; }
        }

        //Min Y-värde i sensorns graf
        public int YMin
        { get; set; }

        //Max Y-värde i sensorns graf
        public int YMax
        { get; set; }

        //Min X-värde i sensorns graf
        public int XMin
        { get; set; }

        //Max X-värde i sensorns graf
        public int XMax
        { get; set; }

        //Intervallavståndet för y-axelns linjer.
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
        private void ChangeTxtBox(int data)
        {
            _label.Text = data.ToString();

            if(_redValues != null && _redValues.Contains(data))
            { _label.BackColor = Color.Red; }
            else if (_yellowValues != null && _yellowValues.Contains(data))
            { _label.BackColor = Color.Yellow; }
            else
            { _label.BackColor = Color.LightGreen; }
        }
    }
}
