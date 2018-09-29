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
    public partial class frmFix : Form
    {
        public frmFix()
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
        public frmFix(string ID)
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
            updata_flag = true;
            this.ID = ID;
            DataTable dt = FixMgr.GetOneFix(ID);
            this.cbxMaintainer.Text = dt.Rows[0][0].ToString();
            this.dtpMDate.Value = Convert.ToDateTime(dt.Rows[0][1].ToString());
            this.dtpRDate.Value = Convert.ToDateTime(dt.Rows[0][2].ToString());
            this.textFixRemark.Text = dt.Rows[0][3].ToString();
            this._eqno = dt.Rows[0][4].ToString();
            this.frmFix_Load(null, null);
        }
        private string _user;
        public string _eqno;
        private string _power;
        private string ID;
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
        private void frmFix_Load(object sender, EventArgs e)
        {
            this.LoadEqInfo();//加载资产的基本信息
            this.btnOK.Focus();

            //初始化维修商选项框
            DataTable dt = MaintainerMgr.GetAll();
            cbxMaintainer.DataSource = dt;
            cbxMaintainer.DisplayMember = dt.Columns[1].ToString();
            cbxMaintainer.ValueMember = dt.Columns[1].ToString();
            cbxMaintainer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbxMaintainer.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbxMaintainer.Text = "";
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
        private void btnOK_Click(object sender, EventArgs e)
        {

            Fix fix = new Fix();
            fix.ID = this.textSerialNO.Text;
            fix.EqNo = this.textEqNO.Text;
            fix.EqName = this.textName.Text;
            DataTable Empdt = EmployeeMgr.GetAllName();
            DataTable Depdt = DepartMgr.GetAllDepartment();
            fix.Department = this.name2ID(Depdt, this.textDepartment.Text, "departName");
            fix.KeepPlace = this.textKeepPlace.Text;
            fix.Keeper = this.name2ID(Empdt, this.textKeeper.Text, "name");
            fix.Maintainer = this.cbxMaintainer.Text;
            fix.MAgent = this.name2ID(Empdt, _user, "name");
            fix.MDate = this.dtpMDate.Value;
            fix.RDate = this.dtpRDate.Value;
            fix.mRemark = this.textFixRemark.Text;
            bool flag;
            if (updata_flag)
            {
                flag = FixMgr.MUpdate(ID, fix);
                if (flag)
                {
                    untCommon.InfoMsg("修改成功。");
                }
                else
                    untCommon.InfoMsg("修改失败。");
            }
            else
            {
                if (IsEqAvailable(this.textEqNO.Text))
                {
                    if (_power == "0" || _power == "1")
                    {
                        flag = FixMgr.AddWithoutVerify(fix);
                    }
                    else
                    {
                        flag = FixMgr.Add(fix);
                    }
                    flag = EqMgr.FixEq(fix.EqNo);
                    if (flag)
                    {
                        untCommon.InfoMsg("送修成功。");
                    }
                    else
                        untCommon.InfoMsg("送修失败。");
                }
                else
                {
                    untCommon.InfoMsg("该资产状态已改变，无法修改该信息。");
                }
            }
            this.DialogResult = DialogResult.OK;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
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


    }
}
