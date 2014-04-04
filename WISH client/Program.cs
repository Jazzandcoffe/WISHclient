using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO.Ports;

namespace WISH_client
{
    static class Program
    {   
        [STAThread]
        static void Main()
        {
            // Instantiate the communications
            // port with some basic settings
            SerialPort port = new SerialPort("COM3", 115200, Parity.None, 8, StopBits.One);

            //Vad gör denna?
            port.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

            //Öppna port
            port.Open();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            port.Close();
        }

        //Vad gör denna?
        private static void DataReceivedHandler( object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
        }
    }
}
