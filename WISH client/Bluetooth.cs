using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace WISH_client
{
    public class Bluetooth
    {
        public SerialPort port;

        public Bluetooth()
        {
            // Instantiate the communications
            // port with some basic settings
            port = new SerialPort("COM3", 115200, Parity.None, 8, StopBits.One);

            port.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

            //Öppna port
            port.Open();
        }

        public void transmit_byte(byte[] data)
        {
            port.Write(data, 0, 1);
        }

        //Tar emot data från seriell port.
        private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            byte[] data = new byte[sp.BytesToRead];
            sp.Read(data, 0, data.Length);

            string[] hex = new string[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                hex[i] = string.Format("{0:x}", data[i]);
            }

            for (int i = 0; i < hex.Length - 1; i = i + 2)
            {
                switch (hex[i])
                {
                    //Styrbeslut
                    case "4":
                        
                        break;
                    //Sensor
                    case "5":

                        break;
                    //Sensor
                    case "6":

                        break;
                    //Sensor
                    case "7":

                        break;
                    //Sensor
                    case "8":

                        break;
                    //Sensor
                    case "9":

                        break;
                    //Sensor
                    case "a":

                        break;
                }
            }



            //TEST!!!
            for (int i = 0; i < data.Length; i++)
            {
                if (hex[i] == "9")
                {
                    Console.WriteLine(hex[i + 1]);
                }
            }
            //*/

        }
    }
}
