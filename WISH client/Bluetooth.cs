using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace WISH_client
{
    /// <summary>
    /// Klassen för det eventet som klassen Bluetooth kastar. 
    /// </summary>
    public class BtDataReceivedEventArgs : EventArgs
    {
        public byte[] btData{get; private set;}

        public BtDataReceivedEventArgs(byte[] data)
        {
            btData = data;
        }
    }

    public delegate void BtDataReceivedEventHandler(object sender, BtDataReceivedEventArgs Args);

    /// <summary>
    /// Klassen Bluetooth, den sköter endast kommunikationen. 
    /// Den behandlar ingen tolkning av datan som skickas. 
    /// När den får data kommer den att tömma inbuffern och därefter höja ett event 
    /// till andra objekt att ta hand om datan den tömt buffern på. 
    /// </summary>
    public class Bluetooth
    {
        private SerialPort _port;
        public event BtDataReceivedEventHandler BtDataReceived;

        /// <summary>
        /// Konstruktorn för klassen Bluetooth. 
        /// </summary>
        /// <param name="port">COM porten som ska användas</param>
        public Bluetooth(string port)
        {
            // Instantiate the communications
            // port with some basic settings
            _port = new SerialPort(port, 115200, Parity.None, 8, StopBits.One);
            _port.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
        }

        /// <summary>
        /// Event som körs när det är dags att hämta data från buffern.
        /// </summary>
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            byte[] data = new byte[sp.BytesToRead];
            sp.Read(data, 0, data.Length);

            if (BtDataReceived != null)
                BtDataReceived(this, new BtDataReceivedEventArgs(data)); //Höjer event
        }

        /// <summary>
        /// Öppnar porten.
        /// Kastar exception om något går fel. 
        /// </summary>
        public void OpenPort()
        {
            try
            { _port.Open(); }
            catch
            { throw new ArgumentException("Kan inte öppna seriellporten"); }
        }

        /// <summary>
        /// Stänger porten.
        /// Kastar exception om något går fel. 
        /// </summary>
        public void ClosePort()
        {
            try
            { _port.Close(); }
            catch
            { throw new ArgumentException("Kan inte stänga seriellporten"); }
        }
        
        /// <summary>
        /// Funktion som skickar data via porten. Den bryter ner varje byte i arrayen och skickar dessa som
        /// enskilda byte arrays då Write-funktionen kräver detta. 
        /// Default inställt att ingen offset ska användas och att det är 1 byte som ska sändas.
        /// </summary>
        /// <param name="data">En byte array med datan som ska skickas.</param>
        public void transmit_byte(byte[] data)
        {
            foreach (byte info in data)
            {
                _port.Write(new byte[] {info}, 0, 1);
            }
        }

    }
}
