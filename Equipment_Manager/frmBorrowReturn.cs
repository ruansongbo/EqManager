using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using DataEntity;
using DataBusiness;

namespace Equipment_Manager
{
    public partial class frmBorrowReturn : Form
    {
        private string _user;
        public string _eqno;
        private string _id;
        private string _power;
        public frmBorrowReturn()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // ��ֹ��������.
            SetStyle(ControlStyles.DoubleBuffer, true); // ˫����
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        public string ID
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        public string User
        {
            get
            {
                return this._user;
            }
            set
            {
                this._user = value;
            }
        }
        public string Power
        {
            set
            {
                this._power = value;
            }
        }
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmReturn_Load(object sender, EventArgs e)
        {
            this.LoadEqInfo();//�����ʲ��Ļ�����Ϣ
            this.btnOK.Focus();
        }
        /// <summary>
        /// �����ʲ������ϣ�
        /// </summary>
        private void LoadEqInfo()
        {
            DataTable dt = BoroowMgr.GetOneAllBorrow(_id);
            if (dt != null)
            {
                this.textSerialNO.Text = dt.Rows[0][0].ToString();
                this.textEqNO.Text = dt.Rows[0][1].ToString();
                this.textName.Text = dt.Rows[0][2].ToString();
                this.textDepartment.Text = dt.Rows[0][4].ToString();
                this.textKeepPlace.Text = dt.Rows[0][5].ToString();
                this.textKeeper.Text = dt.Rows[0][6].ToString();
                this.textBorrower.Text = dt.Rows[0][7].ToString();
                this.textBAgent.Text = dt.Rows[0][8].ToString();
                this.textBReviewer.Text = dt.Rows[0][9].ToString();
                this.textBDate.Text = dt.Rows[0][10].ToString();
                this.textBRemark.Text = dt.Rows[0][11].ToString();
                this.textRDate.Text = dt.Rows[0][14].ToString();
            }
        }

        /// <summary>
        /// ��ȡ���
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="name"></param>
        private string name2ID(DataTable dt, string value, string column)
        {
            dt.PrimaryKey = new System.Data.DataColumn[] { dt.Columns[column] };
            System.Data.DataRow row = dt.Rows.Find(value);
            return row.ItemArray[1].ToString();
        }
        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="name"></param>
        private string ID2name(DataTable dt, string value, string column)
        {
            dt.PrimaryKey = new System.Data.DataColumn[] { dt.Columns[column] };
            System.Data.DataRow row = dt.Rows.Find(value);
            return row.ItemArray[0].ToString();
        }
        /// <summary>
        /// ȷ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                Borrow br = new Borrow();
                DataTable Empdt = EmployeeMgr.GetAllName();
                br.RAgent = this.name2ID(Empdt, this._user, "name");
                br.RDate = this.dtpBDate1.Value;
                br.rRemark = this.textRRemark.Text;
                string eqno = this.textEqNO.Text;
                if (_power == "0" || _power == "1")
                {
                    bool flag = BoroowMgr.RUpdateWithoutVerify(_id, br);
                    flag = EqMgr.ReturnEq(eqno);
                    untCommon.InfoMsg("�黹�ɹ���");
                }
                else
                {
                    bool flag = BoroowMgr.RUpdate(_id, br);
                    untCommon.InfoMsg("�黹����ˡ�");
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// ȡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}