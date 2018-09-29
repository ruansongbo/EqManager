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
            //�������ݱ�����־
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
                    lvwBackup.Items[i].ToolTipText = "��ԭ��" + dt.Rows[i][18].ToString() + "������";
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
        /// �������̱߳�������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //��ʽ�����ݣ���ɾ����ǰ�ı��ݣ�
            if (this.chkDeleteBefor.Checked)
            {
                //�������ݳɹ���
                if (SysMgr.Backup(GetBakUpPath() + @"\DataBackup\Equipment_Manage.bak", true))
                {
                    this.picLoading.Visible = false;
                    lvwBackup.Items.Clear();
                    this.BindeListVeiw();

                }
                else//��������ʧ�ܡ�
                {
                    untCommon.InfoMsg("��������ʧ�ܡ�");

                }

            }
                //��ͨ����
            else
            {
                //�������ݳɹ���
                if (SysMgr.Backup(GetBakUpPath() + @"\DataBackup\Equipment_Manage.bak", false))
                {
                    this.picLoading.Visible = false;
                    lvwBackup.Items.Clear();
                    this.BindeListVeiw();

                }
                else
                {
                    this.picLoading.Visible = false;
                    untCommon.InfoMsg("��������ʧ�ܡ�");

                }

            }

            
            
        }
        /// <summary>
        /// �������̻߳�ԭ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            if (lvwBackup.SelectedItems.Count == 0)
            {
                untCommon.InfoMsg("��ѡ��ָ������ݵı�������");
                return;
            }
            string filename = GetBakUpPath() + @"\DataBackup\Equipment_Manage.bak";
            int file = int.Parse(this.lvwBackup.SelectedItems[0].Tag.ToString());
            if (SysMgr.RestoeData(filename, file))
            {
                this.picLoading.Visible = false;
                untCommon.InfoMsg("�ָ����ݳɹ���ϵͳ���Զ�ע���������µ�¼");
                Application.Restart();

            }
            else
            {
                this.picLoading.Visible = false;
                untCommon.InfoMsg("�ָ�����ʧ�ܡ�");
            }


        }

    }

        
}