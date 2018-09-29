using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DataBusiness;

namespace Equipment_Manager
{
    public partial class frmBackup : Form
    {
        public frmBackup()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            this.picLoading.Visible = true;
            backgroundWorker1.RunWorkerAsync();


        }


        private string GetBakUpPath()
        {
            return Application.StartupPath;
        }

        private void frmBackup_Load(object sender, EventArgs e)
        {
            //加载数据备份日志
            this.BindeListVeiw();
        }
        public void BindeListVeiw()
        {
            DataTable dt = SysMgr.GetBackupLog(GetBakUpPath() + @"\DataBackup\Equipment_Manage.bak");
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lvwBackup.Items.Add(dt.Rows[i][5].ToString(), dt.Rows[i][18].ToString(), 0);
                    lvwBackup.Items[i].ToolTipText = "还原到" + dt.Rows[i][18].ToString() + "的数据";
                    lvwBackup.Items[i].Tag = dt.Rows[i][5].ToString();

                }

            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            this.picLoading.Visible = true;
            backgroundWorker2.RunWorkerAsync();
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 开辟新线程备份数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //格式化备份，（删除以前的备份）
            if (this.chkDeleteBefor.Checked)
            {
                //备份数据成功。
                if (SysMgr.Backup(GetBakUpPath() + @"\DataBackup\Equipment_Manage.bak", true))
                {
                    this.picLoading.Visible = false;
                    lvwBackup.Items.Clear();
                    this.BindeListVeiw();

                }
                else//备份数据失败。
                {
                    untCommon.InfoMsg("备份数据失败。");

                }

            }
                //普通备份
            else
            {
                //备份数据成功。
                if (SysMgr.Backup(GetBakUpPath() + @"\DataBackup\Equipment_Manage.bak", false))
                {
                    this.picLoading.Visible = false;
                    lvwBackup.Items.Clear();
                    this.BindeListVeiw();

                }
                else
                {
                    this.picLoading.Visible = false;
                    untCommon.InfoMsg("备份数据失败。");

                }

            }

            
            
        }
        /// <summary>
        /// 开辟新线程还原数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            if (lvwBackup.SelectedItems.Count == 0)
            {
                untCommon.InfoMsg("请选择恢复到数据的备份日期");
                return;
            }
            string filename = GetBakUpPath() + @"\DataBackup\Equipment_Manage.bak";
            int file = int.Parse(this.lvwBackup.SelectedItems[0].Tag.ToString());
            if (SysMgr.RestoeData(filename, file))
            {
                this.picLoading.Visible = false;
                untCommon.InfoMsg("恢复数据成功。系统将自动注销，请重新登录");
                Application.Restart();

            }
            else
            {
                this.picLoading.Visible = false;
                untCommon.InfoMsg("恢复数据失败。");
            }


        }

    }

        
}