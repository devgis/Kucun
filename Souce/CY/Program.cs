using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CY
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {


            //CY.DA.email eml = new DA.email();
            //eml.SMail();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Application.Run(new CY.express.frmSGAir());
            if (new frmLogin().ShowDialog() == DialogResult.Yes)
                Application.Run(new frmMain());
        }
    }
}
