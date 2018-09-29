using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using DataBusiness;

namespace Equipment_Manager
{
    public partial class frmsysUser : Form
    {
        public frmsysUser()
        {
            InitializeComponent();
        }
        private string _loginId;
        public string LoginId
        {
            set
            {
                this._loginId = value;
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

                    //这三个用户时为了保存默认权限所设置的，并不对外开放
                    if (item.Text == "一级用户" || item.Text == "二级用户" || item.Text == "三级用户")
                        continue;
                    lvwUser.Items.Add(item);
                }
                
            }

        }

        private void InitDepart()
        {
            DataTable dt = DepartMgr.GetAll();
            if (dt != null)
            {
                this.cbxDepart.Items.Clear();
                this.cbxDepart.DataSource = dt;
                this.cbxDepart.DisplayMember = dt.Columns[1].ToString();
                this.cbxDepart.ValueMember = dt.Columns[0].ToString();
            }
        }

        private void frmsysUser_Load(object sender, EventArgs e)
        {
            this.InitUser();//加载系统用户列表
            this.InitDepart();//初始化部门选项
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
            
            if (this.checkInput())
            {
                int result=SysUserMgr.Add(this.txtUserId.Text, this.txtPass.Text, this.txtName.Text,this.cbxDepart.SelectedValue.ToString()
                    ,this.txtTel.Text,this.txtEmail.Text,this.cbxPower.Text);
                if (result==-1)
                {

                    untCommon.InfoMsg("添加用户失败");
                    return;
                   

                }
                if (result != -2)//既添加用户又 添加默认权限
                {
                    untCommon.InfoMsg("添加用户成功，并成功的设置了权限。");
                    this.cleartxt(); //清空文本框
                    this.lvwUser.Items.Clear();
                    this.InitUser();
                    
                }
                else 
                {
                    if (untCommon.QuestionMsg("添加用户成功,但自动设置权限失败。是否要手动设置权限？"))
                    {
                        this.lvwUser.Items.Clear();
                        this.InitUser();
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
            this.txtUserId.Text = "";
            this.txtPass.Text = "";
            this.txtName.Text = "";
            this.txtPassAgain .Text= "";
            this.txtTel.Text = "";
            this.txtEmail.Text = "";
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
                if (this.lvwUser.SelectedItems[0].Tag.ToString() == this._loginId)
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
            if (this.txtUserId.Text.Trim() == "")
            {
                untCommon.InfoMsg("请输入登录ID。");
                return false;
            }
            if (!IsNumber(this.txtUserId.Text))
            {
                untCommon.InfoMsg("登录ID必须为纯数字。");
                return false;
            }
            if (this.txtUserId.Text.Length != 6)
            {
                untCommon.InfoMsg("登录ID必须为6位数字。");
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
            this.txtUserId.Focus();

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
            this.lvwUser.Items.Clear();
            this.InitUser();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 判断字符串是否是数字
        /// </summary>
        private bool IsNumber(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return false;
            const string pattern = "^[0-9]*$";
            Regex rx = new Regex(pattern);
            return rx.IsMatch(s);
        }

        //lvwUser双击事件
        private void lvwUser_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.lvwUser.SelectedItems[0].Text == "sa")
            {
                untCommon.ErrorMsg("该用户为最高权限用户，只可自行更改资料");
                return;
            }
            frmUpdateSysUserInfo fuSysUser=new frmUpdateSysUserInfo(this.lvwUser.SelectedItems[0].Tag.ToString(), true);
            fuSysUser.ShowDialog();
        }

        private void ToolMenu_Update_Click(object sender, EventArgs e)
        {
            if (this.lvwUser.SelectedItems.Count > 0)
            {
                if (this.lvwUser.SelectedItems[0].Text == "sa")
                {
                    untCommon.ErrorMsg("该用户为最高权限用户，只可自行更改资料");
                    return;
                }
                frmUpdateSysUserInfo fuSysUser = new frmUpdateSysUserInfo(this.lvwUser.SelectedItems[0].Tag.ToString(), true);
                fuSysUser.ShowDialog();
            }
        }

        
    }
}