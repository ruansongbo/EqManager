using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Security;

using DataBusiness;

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
            string user;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmLogin fr = null;

            fr = new frmLogin();

            if (fr.ShowDialog() == DialogResult.OK)
            {

                frmMain main = new frmMain();
                main.User = fr.User;
                user=fr.User;
                main.LoginID = fr.LoginID;
                main.DepartId = fr.Depart;
                main.Power = fr.Power;
                frmAudit faudit = new frmAudit(fr.User, fr.LoginID, fr.Depart, fr.Power);
                faudit.ShowDialog();
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