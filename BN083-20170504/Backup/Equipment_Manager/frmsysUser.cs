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
    public partial class frmsysUser : Form
    {
        public frmsysUser()
        {
            InitializeComponent();
        }
        private string _loginname;
        public string LoginName
        {
            set
            {
                this._loginname = value;
            }
 
        }

            
        /// <summary>
        /// 将所有用户都绑定到listveiw上
        /// </summary>
        private void InitUser()
        {
            DataTable dt = SysUserMgr.GetAllUser();
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = dt.Rows[i][1].ToString();
                    item.Tag = dt.Rows[i][0].ToString();
                    item.ImageIndex = 0;
                    lvwUser.Items.Add(item);
                }
            }

        }

        private void frmsysUser_Load(object sender, EventArgs e)
        {
            this.InitUser();//加载系统用户列表
        }

        /// <summary>
        /// 取消添加（关闭添加用户的相关控件）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnCamcel_Click(object sender, EventArgs e)
        {
            this.groupBoxAdd.Enabled = false;
            this.cleartxt();
            
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
             ;
            if (this.checkInput())
            {
                int result=SysUserMgr.Add(this.txtUsername.Text, this.txtPass.Text, this.txtName.Text, this.chkDefaultPower.Checked);
                if (result==-2)
                {

                    untCommon.InfoMsg("添加用户失败");
                    return;
                   

                }
                if (result == -5)//只添加用户
                {
                    untCommon.InfoMsg("添加用户成功");
                    this.cleartxt(); //清空文本框
                    return;
                }
                if (result != -3)//既添加用户又 添加默认权限
                {
                    untCommon.InfoMsg("添加用户成功，并成功的设置了默认权限。");
                    this.cleartxt(); //清空文本框
                    
                    
                }
                else 
                {
                    if (untCommon.QuestionMsg("添加用户成功,但自动设置权限失败。是否要手动设置权限？"))
                    {
                        frmPowerSet power = new frmPowerSet();
                        power.ShowDialog();
                        return;
                    }
                }
               
                
            }
           
        }
        /// <summary>
        /// 清空文本框
        /// </summary>
        private void cleartxt()
        {
            this.txtUsername.Text = "";
            this.txtPass.Text = "";
            this.txtName.Text = "";
            this.txtPassAgain .Text= "";
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnDel_Click(object sender, EventArgs e)
        {
            this.Del();
        
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        private void Del()
        {
            if (this.lvwUser.SelectedItems.Count == 0)
            {
                untCommon.InfoMsg("请选择所要删除的系统用户。");
                return;
            }
            if (untCommon.QuestionMsg("您确定要删除该用户吗？"))//确认删除
            {
                if (this.lvwUser.SelectedItems[0].Tag.ToString() == this._loginname)
                {
                    untCommon.ErrorMsg("错误，您不能删除您自己。");
                    return;
                }
                if (SysUserMgr.Del(this.lvwUser.SelectedItems[0].Tag.ToString()))
                {
                    lvwUser.Items.Clear();
                    InitUser();

                }
                else
                {
                    untCommon.InfoMsg("删除失败。");
                }
            }
        }
        /// <summary>
        /// 刷新用户列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnRefresh_Click(object sender, EventArgs e)
        {
            this.lvwUser.Items.Clear();
            this.InitUser();
        }
        /// <summary>
        /// 检查文本框内是否输入数据
        /// </summary>
        /// <returns></returns>
        private bool checkInput()
        {
            if (this.txtUsername.Text.Trim() == "")
            {
                untCommon.InfoMsg("请输入登录名。");
                return false;
            }
            if (this.txtPass.Text.Trim() == "")
            {
                untCommon.InfoMsg("请输入密码。");
                return false;
            }
            if(this.txtPass.Text.Trim()!=this.txtPassAgain.Text.Trim())
            {
                untCommon.InfoMsg("发生错误，两次密码输入的不一致。");
            }
            if (this.txtName.Text.Trim() == "")
            {
                untCommon.InfoMsg("请输入真实姓名。");
                return false;
            }
            return true;
        }
        /// <summary>
        /// 关不窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToolMenu_Add_Click(object sender, EventArgs e)
        {
            this.groupBoxAdd.Enabled = true;
            this.txtUsername.Focus();

        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void ToolMenu_Del_Click(object sender, EventArgs e)
        {
            this.Del();

        }

        private void ToolMenu_Refresh_Click(object sender, EventArgs e)
        {
            this.InitUser();
        }

       

       

        
    }
}