using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Security;

namespace Equipment_Manager
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
          
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmLogin fr = null;
            frmFlash flash = new frmFlash();
            if (flash.ShowDialog() == DialogResult.OK)
            {
                fr = new frmLogin();
            }
            if (fr.ShowDialog() == DialogResult.OK)
            {

                frmMain main = new frmMain();
                main.User = fr.User;
                main.LoginName = fr.LoginName;
                fr.Close();
                Application.Run(main);
                
            }
            else
            {
                Application.Exit();
    
            }
            
            
        }
    }
}