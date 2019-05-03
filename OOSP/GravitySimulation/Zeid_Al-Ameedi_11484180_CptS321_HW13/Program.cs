/*******************
 * Zeid Al-Ameedi
 * 05/02/2019
 * Cpts321 HW13 Gravity Simulation
 * Collab: Nobody
 * Bonus assignment that simulates planets orbiting
 * **************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zeid_Alameedi_11484180_HW13
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
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
