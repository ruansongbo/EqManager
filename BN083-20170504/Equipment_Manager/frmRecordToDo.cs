using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DataBusiness;
using DataEntity;

namespace Equipment_Manager
{
    public partial class frmRecordToDo : Form
    {
        public frmRecordToDo()
        {
            InitializeComponent();
        }


        DataTable dat = new DataTable("Record");

        DataView dv = null;

        private string _user;
        public string User
        {
            set
            {
                this._user = value;
            }
        }
        /// <summary>
        /// ��ʼ������豸��
        /// </summary>
        private void InitDbgRecordToDo()
        {

            dat = RecordMgr.GetToDo(_user);
            dv = new DataView(dat);
            if (dv != null)
            {
                this.dbgRecordToDo.DataSource = dv;
            }
        }

        private void frmRecord_Load(object sender, EventArgs e)
        {
            this.InitDbgRecordToDo();//���ؼ���豸��

        }

        /// <summary>
        /// ��ѯȫ����¼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnSearchAll_Click_1(object sender, EventArgs e)
        {
            this.InitDbgRecordToDo();
        }

        /// <summary>
        /// ������ѯ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string str = string.Format("{0}='{1}'", toolcbxSeachType.Text, tooltxtCondition.Text);

                dv.RowFilter = str;


            }
            catch (Exception)
            {
                untCommon.InfoMsg("û������Ҫ���ҵļ�¼��");
                return;

            }
            if (dbgRecordToDo.Rows.Count == 0)
            {
                untCommon.InfoMsg("û������Ҫ���ҵļ�¼��");
            }

        }

        private void toolbtnSearchAll_Click(object sender, EventArgs e)
        {
            this.InitDbgRecordToDo();
        }


        private void toolbtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// ������ѯ���Ľ��������Exel��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnExel_Click(object sender, EventArgs e)
        {
            untCommon.ToExel(this.dbgRecordToDo);
        }

        private void ToolMenuItem_Return_Click(object sender, EventArgs e)
        {
            /*frmReturn fr = new frmReturn();
            fr.txtbooker.Text = this._user;
            fr.txtborrower.Text = this.dbgMonitor.SelectedRows[0].Cells[5].Value.ToString();
            fr.txtEqNo.Text = this.dbgMonitor.SelectedRows[0].Cells[1].Value.ToString();//5^1^a^s^p^x
            fr.ShowDialog();*/

            string No = this.dbgRecordToDo.SelectedRows[0].Cells[0].Value.ToString();
            RecordMgr.Sign(No);
            this.InitDbgRecordToDo();

        }
        /// <summary>
        /// ������ѯ���Ľ��������Exel��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolMenuItem_Exel_Click(object sender, EventArgs e)
        {
            untCommon.ToExel(this.dbgRecordToDo);
        }
        /// <summary>
        /// ˢ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolMenuItem_Refresh_Click(object sender, EventArgs e)
        {
            this.InitDbgRecordToDo();

        }

        private void ToolMenuItem_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tooltxtCondition_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (toolcbxSeachType.Text == "�����˹���")
                {
                    string fileter = string.Format("{0} like {1}%", toolcbxSeachType.Text, int.Parse(tooltxtCondition.Text));
                    dv.RowFilter = fileter;
                    return;

                }
            }
            catch
            { return; }
            string str = string.Format("{0} like '{1}%'", toolcbxSeachType.Text, tooltxtCondition.Text);
            dv.RowFilter = str;
        }

        private void toolcbxSeachType_Click(object sender, EventArgs e)
        {

        }

        

       

        
        

    }
}