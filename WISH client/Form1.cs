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

namespace WISH_client
{
    public partial class Form1 : Form
    {
        public SerialPort port;

        public Form1()
        {
            InitializeComponent();

            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Form1_KeyDownEvent);
            this.KeyUp += new KeyEventHandler(Form1_KeyUpEvent);

            // Instantiate the communications
            // port with some basic settings
            port = new SerialPort("COM3", 115200, Parity.None, 8, StopBits.One);

            port.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

            //Öppna port
            port.Open();
        }

        void Form1_KeyDownEvent(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                //q
                case Keys.Q:
                    port.Write(new byte[1] { 1 }, 0, 1);
                    port.Write(new byte[1] { 5 }, 0, 1);
                    break;
                //w
                case Keys.W:
                    port.Write(new byte[1] { 1 }, 0, 1);
                    port.Write(new byte[1] { 2 }, 0, 1);
                    break;
                //e
                case Keys.E:
                    port.Write(new byte[1] { 1 }, 0, 1);
                    port.Write(new byte[1] { 4 }, 0, 1);
                    break;
                //a
                case Keys.A:
                    port.Write(new byte[1] { 1 }, 0, 1);
                    port.Write(new byte[1] { 11 }, 0, 1);
                    break;
                //s
                case Keys.S:
                    port.Write(new byte[1] { 1 }, 0, 1);
                    port.Write(new byte[1] { 3 }, 0, 1);
                    break;
                //d
                case Keys.D:
                    port.Write(new byte[1] { 1 }, 0, 1);
                    port.Write(new byte[1] { 10 }, 0, 1);
                    break;
                case Keys.Space:
                    port.Write(new byte[1] { 1 }, 0, 1);
                    port.Write(new byte[1] { 0 }, 0, 1);
                    break;
            }
        }

        void Form1_KeyUpEvent(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                //q
                case Keys.Q:
                    port.Write(new byte[1] { 2 }, 0, 1);
                    port.Write(new byte[1] { 5 }, 0, 1);
                    break;
                //w
                case Keys.W:
                    port.Write(new byte[1] { 2 }, 0, 1);
                    port.Write(new byte[1] { 2 }, 0, 1);
                    break;
                //e
                case Keys.E:
                    port.Write(new byte[1] { 2 }, 0, 1);
                    port.Write(new byte[1] { 4 }, 0, 1);
                    break;
                //a
                case Keys.A:
                    port.Write(new byte[1] { 2 }, 0, 1);
                    port.Write(new byte[1] { 11 }, 0, 1);
                    break;
                //s
                case Keys.S:
                    port.Write(new byte[1] { 2 }, 0, 1);
                    port.Write(new byte[1] { 3 }, 0, 1);
                    break;
                //d
                case Keys.D:
                    port.Write(new byte[1] { 2 }, 0, 1);
                    port.Write(new byte[1] { 10 }, 0, 1);
                    break;
            }
        }

        //Tar emot data från seriell port.
        private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            int indata1 = sp.ReadByte();
            int indata2 = sp.ReadByte();
            //konverterar decimalt -> hexadecimalt.
            string hex1 = string.Format("{0:x}", indata1);
            string hex2 = string.Format("{0:x}", indata2);

            //Skriver ut mottagen data i konsolen
            Console.WriteLine(hex1 + " " + hex2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
