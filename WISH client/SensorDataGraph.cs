using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WISH_client
{
    

    /// <summary>
    /// Klass som listan fylls med som utgör datapunkterna i grafen. 
    /// </summary>
    public class SensorDataGraph
    {
        private int x;
        private int y;

        public SensorDataGraph(int valueX, int valueY)
        {
            X = valueX;
            Y = valueY;
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }
    }
}
