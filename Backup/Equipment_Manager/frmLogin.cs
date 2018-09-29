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
        //得到系统运行需要配置数据库环境的相关数据文件的路径
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

            this.skinEngine1.SkinFile = @"mp10.ssk";//使用第三方皮肤控件

            //如果系统没有配置运行环境（第一次使用），就自动的配置运行环境
           /* if (!File.Exists(@"C:\Solut_EquipentMgr_Data\Equipment_Manage_dat.mdf"))
            {
               // this.backgroundWorker1.RunWorkerAsync();
                th = new Thread(new ThreadStart(SysConfig));

                th.Start();//新开线程配置运行环境


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
                        untCommon.InfoMsg("用户名或密码错误，请核实以后再输入");
                    }
                }
                else
                {
                    untCommon.ErrorMsg("登录失败。\r\n信息：连接不到服务器。");

                }

            }

        }
        /// <summary>
        /// 检查输入是否合法
        /// </summary>
        /// <returns></returns>
        private bool checkInput()
        {
            if (this.txtUser.Text.Trim() == "")
            {
                untCommon.InfoMsg("请输入用户名");
                return false;
 
            }
            if (this.txtPass.Text == "")
            {
                untCommon.InfoMsg("请输入用密码");
                return false;
 
            }
            return true;
        }
        /// <summary>
        /// 配置运行环境
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SysConfig()
        {
            Directory.CreateDirectory(@"C:\Solut_EquipentMgr_Data");//在C目录下创建Solut_EquipentMgr_Data目录
            //文件复制
            File.Copy(pathdat, @"C:\Solut_EquipentMgr_Data\Equipment_Manage_dat.mdf");
            File.Copy(pathlog, @"C:\Solut_EquipentMgr_Data\Equipment_Manage_log.ldf");
            File.Copy(pathbuidDatabase, @"C:\Solut_EquipentMgr_Data\BuidDatabase.sql");
            File.Copy(pathKillProcessProcedure, @"C:\Solut_EquipentMgr_Data\KillProcessProcedure.sql");



            Process process = new Process();
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.FileName = Application.StartupPath + @"\Data\SysConfig.bat";//执行批处理文件
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