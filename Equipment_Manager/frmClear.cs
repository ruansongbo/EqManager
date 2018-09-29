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
    public partial class frmClear : Form
    {
        public frmClear()
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
        public frmClear(string ID, bool view_only)
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
            updata_flag = true;
            this.ID = ID;
            this.view_only = view_only;
            DataTable dt = ClearMgr.GetOneClear(ID);
            this.defaultType = dt.Rows[0][0].ToString();
            this.dtpDate.Value = Convert.ToDateTime(dt.Rows[0][1].ToString());
            this.textRemark.Text = dt.Rows[0][2].ToString();
            this._eqno = dt.Rows[0][3].ToString();
            this.frmClear_Load(null, null);
        }

        private string _user;
        private string _eqno;
        private string _power;
        private string ID;
        private string defaultType;
        private bool updata_flag = false;
        private bool view_only = true;

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
        private void InitCombo()
        {
            DataTable dtType = ClearMgr.GetAllClearType();
            this.cbxClearType.DataSource = dtType;
            this.cbxClearType.DisplayMember = "discrip";
            this.cbxClearType.ValueMember = "id";
            if (!string.IsNullOrWhiteSpace(defaultType))
            {
                this.cbxClearType.SelectedText = defaultType;
            }

        }

        private void frmClear_Load(object sender, EventArgs e)
        {
            this.LoadEqInfo();//加载资产的基本信息
            this.InitCombo();
            this.btnOk.Focus();
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
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (view_only)
            {
                untCommon.InfoMsg("当前无法修改。");
            }
            else
            {
                Clear clear = new Clear();
                clear.ID = this.textSerialNO.Text;
                clear.EqNo = this.textEqNO.Text;
                clear.EqName = this.textName.Text;
                DataTable Empdt = EmployeeMgr.GetAllName();
                DataTable Depdt = DepartMgr.GetAllDepartment();
                clear.Department = this.name2ID(Depdt, this.textDepartment.Text, "departName");
                clear.KeepPlace = this.textKeepPlace.Text;
                clear.Keeper = this.name2ID(Empdt, this.textKeeper.Text, "name");
                clear.CType = this.cbxClearType.Text;
                clear.CAgent = this.name2ID(Empdt, _user, "name");
                clear.CDate = this.dtpDate.Value;
                clear.Remark = this.textRemark.Text;
                bool flag;
                if (updata_flag)
                {
                    flag = ClearMgr.CUpdate(ID, clear);
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
                            flag = ClearMgr.AddWithoutVerify(clear);
                            untCommon.InfoMsg("注销成功。");
                        }
                        else
                        {
                            flag = ClearMgr.Add(clear);
                            untCommon.InfoMsg("注销成功待审核。");
                        }
                        flag = EqMgr.ClearEq(clear.EqNo);
                        if (!flag)
                            untCommon.InfoMsg("注销失败。");

                    }
                    else
                    {
                        untCommon.InfoMsg("该资产状态已改变，无法修改该信息。");
                    }

                }
                this.DialogResult = DialogResult.OK;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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