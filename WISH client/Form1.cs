using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WISH_client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.KeyPreview = true;
            this.KeyPress += new KeyPressEventHandler(Form1_KeyPress);
        }

        void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                //q
                case (char)113:

                    break;
                //w
                case (char)119:

                    break;
                //e
                case (char)101:

                    break;
                //a
                case (char)97:

                    break;
                //s
                case (char)115:

                    break;
                //d
                case (char)100:

                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
