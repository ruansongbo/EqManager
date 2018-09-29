using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;

using DataBusiness;


namespace Equipment_Manager
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        Thread th = null;
        private string _user;
        //�õ�ϵͳ������Ҫ�������ݿ⻷������������ļ���·��
        string pathdat = Application.StartupPath + @"\Data\Equipment_Manage_dat.mdf";
        string pathlog = Application.StartupPath + @"\Data\Equipment_Manage_log.ldf";
        string pathbuidDatabase = Application.StartupPath + @"\Data\BuidDatabase.sql";
        string pathKillProcessProcedure = Application.StartupPath + @"\Data\KillProcessProcedure.sql";

        
        public string LoginName
        {
            get
            {
                return this.txtUser.Text;
            }
        }

        
        public string User
        {
            get
            {
                return this._user;
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

            this.skinEngine1.SkinFile = @"mp10.ssk";//ʹ�õ�����Ƥ���ؼ�

            //���ϵͳû���������л�������һ��ʹ�ã������Զ����������л���
           /* if (!File.Exists(@"C:\Solut_EquipentMgr_Data\Equipment_Manage_dat.mdf"))
            {
               // this.backgroundWorker1.RunWorkerAsync();
                th = new Thread(new ThreadStart(SysConfig));

                th.Start();//�¿��߳��������л���


            }*/
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (checkInput())
            {
                _user = SysUserMgr.Login(this.txtUser.Text, txtPass.Text);
                if (_user != null)
                {
                    if (_user != "-1")
                    {
                        this.DialogResult = DialogResult.OK;

                    }
                    else
                    {
                        untCommon.InfoMsg("�û���������������ʵ�Ժ�������");
                    }
                }
                else
                {
                    untCommon.ErrorMsg("��¼ʧ�ܡ�\r\n��Ϣ�����Ӳ�����������");

                }

            }

        }
        /// <summary>
        /// ��������Ƿ�Ϸ�
        /// </summary>
        /// <returns></returns>
        private bool checkInput()
        {
            if (this.txtUser.Text.Trim() == "")
            {
                untCommon.InfoMsg("�������û���");
                return false;
 
            }
            if (this.txtPass.Text == "")
            {
                untCommon.InfoMsg("������������");
                return false;
 
            }
            return true;
        }
        /// <summary>
        /// �������л���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SysConfig()
        {
            Directory.CreateDirectory(@"C:\Solut_EquipentMgr_Data");//��CĿ¼�´���Solut_EquipentMgr_DataĿ¼
            //�ļ�����
            File.Copy(pathdat, @"C:\Solut_EquipentMgr_Data\Equipment_Manage_dat.mdf");
            File.Copy(pathlog, @"C:\Solut_EquipentMgr_Data\Equipment_Manage_log.ldf");
            File.Copy(pathbuidDatabase, @"C:\Solut_EquipentMgr_Data\BuidDatabase.sql");
            File.Copy(pathKillProcessProcedure, @"C:\Solut_EquipentMgr_Data\KillProcessProcedure.sql");



            Process process = new Process();
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.FileName = Application.StartupPath + @"\Data\SysConfig.bat";//ִ���������ļ�
            try
            {
                process.Start();
            }
            catch (Exception e)
            {
                untCommon.ErrorMsg(e.ToString());
            }
            th.Abort();
        }
     
    }
}