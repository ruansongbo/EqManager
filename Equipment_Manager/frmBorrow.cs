using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DataEntity;
using DataBusiness;

namespace Equipment_Manager
{
    public partial class frmBorrow : Form
    {

        public frmBorrow()
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
        public frmBorrow(string ID)
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
            updata_flag = true;
            this.ID = ID;
            DataTable dt = BoroowMgr.GetOneBorrow(ID);
            this.defaultBorrower = dt.Rows[0][0].ToString();
            this.dtpBDate.Value = Convert.ToDateTime(dt.Rows[0][1].ToString());
            this.dtpRDate.Value = Convert.ToDateTime(dt.Rows[0][2].ToString());
            this.textBorrowRemark.Text = dt.Rows[0][3].ToString();
            this._eqno = dt.Rows[0][4].ToString();
            this.frmBorrow_Load(null, null);
        }
        private string _user;
        public string _eqno;
        private string _power;
        private string ID;
        private string defaultBorrower;
        private bool updata_flag = false;

        public string Eqno
        {
            set
            {
                this._eqno = value;
            }
        }

        public string User
        {
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
        /// 加载资产的资料；
        /// </summary>
        private void LoadEqInfo()
        {
            DataTable dt = EqMgr.GetOneEqInfo(this._eqno);
            if (dt != null)
            {
                this.textSerialNO.Text = DateTime.Now.ToString("yyyyMMddHHmmss");
                this.textEqNO.Text = dt.Rows[0]["EqNo"].ToString();
                this.textName.Text = dt.Rows[0]["EqName"].ToString();
                this.textKeepPlace.Text = dt.Rows[0]["KeepPlace"].ToString();
                this.textDepartment.Text = DepartMgr.GetNameFromId(dt.Rows[0]["Department"].ToString());
                this.textKeeper.Text = dt.Rows[0]["EqKeeper"].ToString();
            }
        }

        private void frmBorrow_Load(object sender, EventArgs e)
        {
            this.LoadEqInfo();//加载资产的基本信息
            this.InitCombo();
            this.btnOK.Focus();
        }
        private void InitCombo()
        {
            DataTable dtEmp = EmployeeMgr.GetAllName();
            this.cbxborrower.DataSource = dtEmp;
            this.cbxborrower.DisplayMember = "name";
            this.cbxborrower.ValueMember = "empid";
            if (!string.IsNullOrWhiteSpace(defaultBorrower))
            {
                this.cbxborrower.SelectedValue = defaultBorrower;
            }
        }

        /// <summary>
        /// 进入资产领用界面
        /// </summary>
        private bool IsEqAvailable(string eqno)
        {
            DataTable dt = EqMgr.GetOneEqInfo(eqno);
            if (dt != null)
            {
                string status = dt.Rows[0]["State"].ToString();
                if (status.Equals("入库"))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        /// <summary>
        /// 领用资产
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {

            Borrow br = new Borrow();
            br.ID = this.textSerialNO.Text;
            br.EqNo = this.textEqNO.Text;
            br.EqName = this.textName.Text;
            DataTable Empdt = EmployeeMgr.GetAllName();
            DataTable Depdt = DepartMgr.GetAllDepartment();
            br.Department = this.name2ID(Depdt, this.textDepartment.Text, "departName");
            br.KeepPlace = this.textKeepPlace.Text;
            br.Keeper = this.name2ID(Empdt, this.textKeeper.Text, "name");
            br.BAgent = this.name2ID(Empdt, _user, "name");
            br.Borrower = this.cbxborrower.SelectedValue.ToString();
            br.BDate = this.dtpBDate.Value;
            br.RDate = this.dtpRDate.Value;
            br.bRemark = this.textBorrowRemark.Text;
            bool flag;
            if (updata_flag)
                flag = BoroowMgr.BUpdate(ID, br);
            else
            {
                if (IsEqAvailable(this.textEqNO.Text))
                {
                    if (_power == "0" || _power == "1")
                    {
                        flag = BoroowMgr.AddWithoutVerify(br);
                    }
                    else
                    {
                        flag = BoroowMgr.Add(br);
                    }
                    flag = EqMgr.BorrowEq(br.EqNo);
                    if (flag)
                    {
                        untCommon.InfoMsg("出借成功。");
                    }
                    else
                        untCommon.InfoMsg("出借失败。");
                }
                else
                {
                    untCommon.InfoMsg("该资产状态已改变，无法修改该信息。");
                }
            }
            this.DialogResult = DialogResult.OK;

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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }


    }
}