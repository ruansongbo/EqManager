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
    public partial class frmUpdateSysUserInfo : Form
    {
        public frmUpdateSysUserInfo()
        {
            InitializeComponent();
        }
        private string _loginid;
        //用于判断更改的是自己的资料还是别人的资料
        private bool _isother=false;

        public frmUpdateSysUserInfo(string Loginid, bool isOther)
        {
            InitializeComponent();
            this._loginid = Loginid;
            this._isother = isOther;
        }


        private void chkPass_CheckedChanged(object sender, EventArgs e)
        {
            this.Enable();
            this.Cleartxt();

        }

        /// <summary>
        /// 设置修改密码相关控件的启用状态
        /// </summary>
        private void Enable()
        {
            this.lblOldPass.Enabled = !this.lblOldPass.Enabled;
            this.lblNewPass.Enabled = !this.lblNewPass.Enabled;
            this.lblNewPassAgain.Enabled = !this.lblNewPassAgain.Enabled;
            if(!_isother)
                this.txtOldPass.Enabled = !this.txtOldPass.Enabled;
            this.txtNewPass.Enabled = !this.txtNewPass.Enabled;
            this.txtPassAgain.Enabled = !this.txtPassAgain.Enabled;

        }
        /// <summary>
        /// 清理个密码框内的字符
        /// </summary>
        private void Cleartxt()
        {
            if(!_isother)
                this.txtOldPass.Text = "";
            this.txtNewPass.Text = "";
            this.txtPassAgain.Text = "";
        }

        private void frmUpdateSysUserInfo_Load(object sender, EventArgs e)
        {
            this.txtLoginId.Text = this._loginid;//加载登录id
            DataTable dt = SysUserMgr.GetOneUser(this._loginid);
            DataTable dtDepart = DepartMgr.GetAllDepartment();
            this.cbxDepart.DataSource = dtDepart;
            this.cbxDepart.DisplayMember = dtDepart.Columns[0].ToString();
            this.cbxDepart.ValueMember = dtDepart.Columns[1].ToString();

            if (dt != null)
            {
                this.txtName.Text = dt.Rows[0][2].ToString();
                this.cbxDepart.Text = DepartMgr.GetNameFromId(dt.Rows[0][3].ToString());
                this.txtTel.Text = dt.Rows[0][4].ToString();
                this.txtEmail.Text = dt.Rows[0][5].ToString();

            }

            

            if (this._isother)
            {
                this.txtOldPass.PasswordChar = new char();
                this.txtOldPass.Text = SysUserMgr.GetPass(this._loginid);
                //自己不可更改自身所在部门，只有由其他人进行更改才行
                this.cbxDepart.Enabled = true;
            }
            

        }
        /// <summary>
        /// 检查输入是否合法
        /// </summary>
        /// <returns></returns>
        private bool checkInput()
        {
            if (this.txtName.Text.Trim() == "")
            {
                untCommon.InfoMsg("请输入真实姓名。");
                return false;
            }
            if (this.txtOldPass.Text.Trim() == "")
            {
                untCommon.InfoMsg("请输入原密码。");
                return false;
            }
            if (this.txtNewPass.Text.Trim() == "")
            {
                untCommon.InfoMsg("请输入新密码。");
                return false;
            }
            if (this.txtNewPass.Text != this.txtPassAgain.Text)
            {
                untCommon.InfoMsg("两次输入的密码不一致");
                this.txtNewPass.Text = "";
                this.txtPassAgain.Text = "";
                return false;
            }
            return true;
        }
  

        private void btnOk_Click(object sender, EventArgs e)
        {
            //修改资料（不修改密码）
            if (this.chkPass.Checked == false)
            {
                if (this.txtName.Text.Trim() == "")
                {
                    untCommon.InfoMsg("请输入真实姓名。");
                    return;
                }
                if (SysUserMgr.UpdateNoPass(this.txtLoginId.Text, this.txtName.Text,this.txtTel.Text,this.txtEmail.Text,this.cbxDepart.SelectedValue.ToString()))
                {
                    untCommon.InfoMsg("修改成功。");
                    
                }
                else
                {
                    untCommon.InfoMsg("修改失败");
                }

            }
            else
            {
                if (this.checkInput())//修改密码
                {
                   
                    int result = SysUserMgr.UpdatePass(this.txtLoginId.Text,this.txtOldPass.Text,this.txtNewPass.Text,this.txtName.Text,
                                                       this.txtTel.Text,this.txtEmail.Text,this.cbxDepart.SelectedValue.ToString());
                    if (result>0)
                    {
                        untCommon.InfoMsg("修改成功。");
                        this.Cleartxt();
                        this.chkPass.Checked = false;
                    }
                    else
                    {
                        if(result==-1)
                        {
                            untCommon.InfoMsg("原密码错误，请确认后在输入。修改失败。");
                            this.Cleartxt();
                            return;
                        }
                        untCommon.InfoMsg("修改失败");
                    }
                }
 
            }
        
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}