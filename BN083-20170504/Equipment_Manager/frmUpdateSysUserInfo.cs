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
        private string _loginname;
        private string _name;
        public string LoginName
        {
            set
            {
                this._loginname = value;
            }
        }
        public string Names
        {
            set
            {
                this._name = value;
            }
        }


        private void chkPass_CheckedChanged(object sender, EventArgs e)
        {
            this.Eneble();
            this.Cleartxt();

        }

        /// <summary>
        /// 设置修改密码相关控件的启用状态
        /// </summary>
        private void Eneble()
        {
            this.lblOldPass.Enabled = !this.lblOldPass.Enabled;
            this.lblNewPass.Enabled = !this.lblNewPass.Enabled;
            this.lblNewPassAgain.Enabled = !this.lblNewPassAgain.Enabled;
            this.txtOldPass.Enabled = !this.txtOldPass.Enabled;
            this.txtNewPass.Enabled = !this.txtNewPass.Enabled;
            this.txtPassAgain.Enabled = !this.txtPassAgain.Enabled;

        }
        /// <summary>
        /// 清理个密码框内的字符
        /// </summary>
        private void Cleartxt()
        {
            this.txtOldPass.Text = "";
            this.txtNewPass.Text = "";
            this.txtPassAgain.Text = "";
        }

        private void frmUpdateSysUserInfo_Load(object sender, EventArgs e)
        {
            this.txtLoginname.Text = this._loginname;//加载登录名
            this.txtName.Text = this._name;     //加载真实姓名

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
                if (SysUserMgr.UpdateNoPass(this.txtLoginname.Text, this.txtName.Text))
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
                   
                    int result = SysUserMgr.UpdatePass(this.txtLoginname.Text,this.txtOldPass.Text,this.txtNewPass.Text,this.txtName.Text);
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