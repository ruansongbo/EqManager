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
        }
        private int _max;
        private string _user;
        public string _eqno;
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
        public int Max
        {
            set 
            {
                this._max = value;
            }
        }
        /// <summary>
        /// 加载资产的资料；
        /// </summary>
        private void LoadEqInfo()
        {
            DataTable dt = EpMgr.GetOneMostInfo(this._eqno);
            if (dt != null)
            {
                this.txtEqNO.Text = dt.Rows[0][0].ToString();
                this.txtName.Text = dt.Rows[0][1].ToString();
                this.txtType.Text = dt.Rows[0][2].ToString();
                this.txtLabel.Text = dt.Rows[0][3].ToString();
                this.txtModel.Text = dt.Rows[0][4].ToString();
                this.txtPlus.Text = dt.Rows[0][5].ToString();

                this.txtMaxNO.Text = this._max.ToString();
                this.txtBooker.Text = this._user;
            }


        }

        private void frmBorrow_Load(object sender, EventArgs e)
        {
            this.LoadEqInfo();//加载资产的基本信息

            this.Initdepart(); //加载领用部门列表

            //初始化领用人列表
            cbxDepart_SelectionChangeCommitted(null, null);

            this.btnOK.Focus();
        }
        /// <summary>
        /// 得到领用部门列表
        /// </summary>
        private void Initdepart()
        {
            DataTable dt = DepartMgr.Getdepart();
            if (dt != null)
            {
                this.cbxDepart.DataSource = dt;
                this.cbxDepart.DisplayMember = dt.Columns[1].ToString();
                this.cbxDepart.ValueMember = dt.Columns[0].ToString();     

            }

        }
        private void cbxDepart_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int id = int.Parse(this.cbxDepart.SelectedValue.ToString());
            DataTable dat = EmployeeMgr.GetEmpByDepart(id);
            if (dat != null)
            {
                cbxEmp.DataSource = dat;
                cbxEmp.DisplayMember = dat.Columns[1].ToString();
                cbxEmp.ValueMember = dat.Columns[0].ToString();
            }


        }
        /// <summary>
        /// 领用资产
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            Borrow br = new Borrow();
            if(this.nubCount.Value.ToString()=="")
            {
                untCommon.InfoMsg("请输入领用的数量。");
                return;

            }
            if(int.Parse(this.nubCount.Value.ToString())==0)
            {
                untCommon.InfoMsg("领用数量不能为0");
                return;
            }
            if (br.Count > this._max)
            {
                untCommon.InfoMsg("您领用的数量不能大于最大可领用数量。");
                return;

            }
            try
            {
                br.depart = this.cbxDepart.Text;
            }
            catch (FormatException)
            {
                untCommon.InfoMsg("领用数量请在英文输入法状态下输入数字");
                return;
            }

            br.Booker = this.txtBooker.Text;
            br.Count = int.Parse(this.nubCount.Value.ToString());
            br.Date = this.dtpDate.Value;
            
            br.EqNo = this.txtEqNO.Text;
            br.Borrower =int.Parse(this.cbxEmp.SelectedValue.ToString());
            
            if (BoroowMgr.Add(br))
            {
                untCommon.InfoMsg("您成功的领用了该笔资产。");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                untCommon.InfoMsg("领用失败。");
            }
        }
       

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }


    }
}