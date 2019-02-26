/***************
 * Zeid Al-Ameedi
 * 02/22/2019
 * CptS321 HW4 - Spreadsheet application
 * 
****************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spreadsheet
{
    static class Program
    {
        /// <summary>
        /// Main function where the logic for the GUI is developed.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
