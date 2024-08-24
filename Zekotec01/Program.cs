using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zekotec01
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

            //zamanlanmış görev
           
            //Application.Run(new Form1());
            Application.Run(new Giris());
           //Application.Run(new FormResimCek());

        }
    }
}
