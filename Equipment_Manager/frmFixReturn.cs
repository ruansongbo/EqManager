using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DataEntity;
using DataBusiness;

namespace Equipment_Manager
{
    public partial class frmFixReturn : Form
    {
        private string _user;
        public string _eqno;
        private string _id;
        private string _power;
        public frmFixReturn()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
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
        /// 载入界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmFixReturn_Load(object sender, EventArgs e)
        {
            this.LoadEqInfo();//加载资产的基本信息
            this.btnOK.Focus();
        }
        /// <summary>
        /// 加载资产的资料；
        /// </summary>
        private void LoadEqInfo()
        {
            DataTable dt = FixMgr.GetOneAllFix(_id);
            if (dt != null)
            {
                this.textSerialNO.Text = dt.Rows[0][0].ToString();
                this.textEqNO.Text = dt.Rows[0][1].ToString();
                this.textName.Text = dt.Rows[0][2].ToString();
                this.textDepartment.Text = dt.Rows[0][4].ToString();
                this.textKeepPlace.Text = dt.Rows[0][5].ToString();
                this.textKeeper.Text = dt.Rows[0][6].ToString();
                this.textMaintainer.Text = dt.Rows[0][7].ToString();
                this.textMAgent.Text = dt.Rows[0][8].ToString();
                this.textMReviewer.Text = dt.Rows[0][9].ToString();
                this.textMDate.Text = dt.Rows[0][10].ToString();
                this.textRDate.Text = dt.Rows[0][14].ToString();
                this.textMRemark.Text = dt.Rows[0][11].ToString();
            }
        }

        /// <summary>
        /// 获取编号
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
        /// 获取名字
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
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                Fix fix = new Fix();
                DataTable Empdt = EmployeeMgr.GetAllName();
                fix.RAgent = this.name2ID(Empdt, this._user, "name");
                fix.EqNo = this.textEqNO.Text;
                fix.RDate = this.dtpBDate1.Value;
                fix.rRemark = this.textRRemark.Text;
                if (_power == "0" || _power == "1")
                {
                    bool flag = FixMgr.RUpdateWithoutVerify(_id, fix);
                    flag = EqMgr.ReturnEq(fix.EqNo);
                }
                else
                {
                    bool flag = FixMgr.RUpdate(_id, fix);
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
