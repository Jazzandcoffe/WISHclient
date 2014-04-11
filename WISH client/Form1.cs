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
        public Bluetooth bt;

        public Form1()
        {
            InitializeComponent();

            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Form1_KeyDownEvent);
            this.KeyUp += new KeyEventHandler(Form1_KeyUpEvent);

            bt = new Bluetooth();
        }

        void Form1_KeyDownEvent(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                //q
                case Keys.Q:
                    bt.transmit_byte(new byte[1] { 1 });
                    bt.transmit_byte(new byte[1] { 5 });
                    break;
                //w
                case Keys.W:
                    bt.transmit_byte(new byte[1] { 1 });
                    bt.transmit_byte(new byte[1] { 2 });
                    break;
                //e
                case Keys.E:
                    bt.transmit_byte(new byte[1] { 1 });
                    bt.transmit_byte(new byte[1] { 4 });
                    break;
                //a
                case Keys.A:
                    bt.transmit_byte(new byte[1] { 1 });
                    bt.transmit_byte(new byte[1] { 11 });
                    break;
                //s
                case Keys.S:
                    bt.transmit_byte(new byte[1] { 1 });
                    bt.transmit_byte(new byte[1] { 3 });
                    break;
                //d
                case Keys.D:
                    bt.transmit_byte(new byte[1] { 1 });
                    bt.transmit_byte(new byte[1] { 10 });
                    break;
                //Space
                case Keys.Space:
                    bt.transmit_byte(new byte[1] { 1 });
                    bt.transmit_byte(new byte[1] { 0 });
                    break;
                //1
                case Keys.D1:
                    bt.transmit_byte(new byte[1] { 3 });
                    bt.transmit_byte(new byte[1] { 0 });
                    break;
                //2
                case Keys.D2:
                    bt.transmit_byte(new byte[1] { 3 });
                    bt.transmit_byte(new byte[1] { 1 });
                    break;
                //3
                case Keys.D3:
                    bt.transmit_byte(new byte[1] { 3 });
                    bt.transmit_byte(new byte[1] { 2 });
                    break;
                //4
                case Keys.D4:
                    bt.transmit_byte(new byte[1] { 3 });
                    bt.transmit_byte(new byte[1] { 3 });
                    break;
            }
        }

        void Form1_KeyUpEvent(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                //q
                case Keys.Q:
                    bt.transmit_byte(new byte[1] { 2 });
                    bt.transmit_byte(new byte[1] { 5 });
                    break;
                //w
                case Keys.W:
                    bt.transmit_byte(new byte[1] { 2 });
                    bt.transmit_byte(new byte[1] { 2 });
                    break;
                //e
                case Keys.E:
                    bt.transmit_byte(new byte[1] { 2 });
                    bt.transmit_byte(new byte[1] { 4 });
                    break;
                //a
                case Keys.A:
                    bt.transmit_byte(new byte[1] { 2 });
                    bt.transmit_byte(new byte[1] { 11 });
                    break;
                //s
                case Keys.S:
                    bt.transmit_byte(new byte[1] { 2 });
                    bt.transmit_byte(new byte[1] { 3 });
                    break;
                //d
                case Keys.D:
                    bt.transmit_byte(new byte[1] { 2 });
                    bt.transmit_byte(new byte[1] { 10 });
                    break;
            }
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
