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
using System.Threading.Tasks;
using System.Windows.Forms;




namespace WISH_client
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainProgram gui = new MainProgram();
            Application.Run(gui);
        }
    }
}
