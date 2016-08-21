using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DiamondNotepad
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string dd = "";
            if (args != null && args.Length > 0)
            {
                dd = args[args.Length - 1];
            }
            else
            {

                MessageBox.Show("hello");
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(dd));
        }
    }
}
