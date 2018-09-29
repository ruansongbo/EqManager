using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using DataBusiness;

namespace Equipment_Manager
{
    public partial class frmPowerSet : Form
    {
        public frmPowerSet()
        {
            InitializeComponent();
            
        }
        ArrayList list = null;//保存用户原来的权限

        ArrayList Lastlist = new ArrayList();//保存用户被更改过后的权限

        private string _loginid;
        public string LoginId
        {
            set
            {
                this._loginid = value;
            }
        }
        public void initListbox()
        {
            DataTable dt = SysUserMgr.GetAllLoginName();
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lstUser.Items.Add(dt.Rows[i][0].ToString());
                }
                //这三个用户和sa一样是不可改动的，用于存储三个级别用户的默认权限，不对外开放
                lstUser.Items.Remove("一级用户");
                lstUser.Items.Remove("二级用户");
                lstUser.Items.Remove("三级用户");
            }
        }

        private void frmPowerSet_Load(object sender, EventArgs e)
        {
            this.initListbox();//加载用户列表
            this.BuildTree(null,0);//加载功能树
        }
        /// <summary>
        /// 选中不同的用户，得到用户的真实姓名
        /// 并且得到用户的权限
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = "";
            if (lstUser.SelectedIndex != -1)
            {
                id = SysUserMgr.GetIdByLoginName(lstUser.SelectedItems[0].ToString());
 
            }
            if (id!="")
            {
                this.label3.Visible = true;
                this.lblid.Text = id;
            }

            this.panelCheck.Enabled = true;
            this.rbtnFree.Checked = true;
            this.GetFuncByUser(this.lblid.Text);//得到权限

        }
        /// <summary>
        /// 构造树
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="parentid"></param>
        private void BuildTree(TreeNode parentNode, int parentid)
        {
            DataTable dt = SysUserMgr.GetFuncList(parentid);
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TreeNode node = new TreeNode();
                    node.Text = dt.Rows[i][1].ToString();
                    node.Tag = dt.Rows[i][0].ToString();
                   // node.Nodes.Add("正在加载...");
                    tvwFunc.Nodes.Add(node);
                    this.Buildfunc(tvwFunc.Nodes[i]);
                    this.tvwFunc.ExpandAll();

                }
               
            }
            
 
        }
        /// <summary>
        /// 构造功能节点
        /// </summary>
        /// <param name="parent"></param>
        private void Buildfunc(TreeNode parent)
        {
            int menuid = int.Parse(parent.Tag.ToString());
            DataTable dt = SysUserMgr.GetFuncList(menuid);
            if (dt != null)
            {

                for (int i = 0; i< dt.Rows.Count; i++)
                {
                    TreeNode node = new TreeNode();
                    node.Text = dt.Rows[i][1].ToString();
                    node.Tag = dt.Rows[i][0].ToString();
                    parent.Nodes.Add(node);
                }

            }
 
        }
        /// <summary>
        /// 如果一个节点选中，如果有子节点，所有子节点选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvwFunc_AfterCheck(object sender, TreeViewEventArgs e)
        {
            bool ischecked = e.Node.Checked;
            for (int i = 0; i < e.Node.Nodes.Count; i++)
            {
                e.Node.Nodes[i].Checked = ischecked;
            }
        }
        /// <summary>
        /// 得到某用户的权限（所能做的操作），并表现出来
        /// </summary>
        private void GetFuncByUser(string id)
        {
            this.list = SysUserMgr.GetOneListByUser(id);
            for (int i = 0; i < tvwFunc.Nodes.Count; i++)
            {
                tvwFunc.Nodes[i].Checked = false;

            }

            for (int i = 0; i < tvwFunc.Nodes.Count;i++ )
            {
                this.GetNodes(this.tvwFunc.Nodes[i]);
               
            }

           
        }
        /// <summary>
        /// 遍历树，如果发现节点的tag的值和权限列表 list 里的值（功能编号）相同，
        /// 就把该节点的checkbox选中
        /// </summary>
        /// <param name="tnParent"></param>
        private void GetNodes(TreeNode tnParent)
        {
            if (tnParent != null)
            {
                foreach (TreeNode tn in tnParent.Nodes)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        //如果发现节点的tag的值和权限列表 list 里的值（功能编号）相同，
                        // 就把该节点的checkbox选中
                        if (tn.Tag.ToString() == list[i].ToString())
                        {
                            tn.Checked = true;
                        }
                    }
                   
                }
            }
        }
        /// <summary>
        /// 遍历树，如果发现节点的checkbox选中，
        /// 就把该节点的tag放到Lastlist中（跟节点除外）
        /// </summary>
        /// <param name="tnParent"></param>
        private void GetNodesLast(TreeNode tnParent)
        {
            if (tnParent != null)
            {
                foreach (TreeNode tn in tnParent.Nodes)
                {
                    if (tn.Checked)
                    {
                        if (tn.Parent != null)
                        {
                          
                            Lastlist.Add(tn.Tag);

                        }
                    }
                    
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int error = 0;
            
            if (this.lstUser.SelectedIndex == -1)
            {
                untCommon.InfoMsg("请选择用户。");
                return;
            }
            if (this.lstUser.SelectedItems[0].ToString() == this._loginid)
            {
                untCommon.ErrorMsg("错误,您不能设置自己的权限。");
                return;
            }
            if (this.lstUser.SelectedItems[0].ToString() == "sa")
            {
                untCommon.ErrorMsg("错误,您不能设置用户" + "sa" + "的权限。用户" + "sa" + "对本系统具有完全控制权");
                GetFuncByUser(this.lblid.Text);
                return;
            }
            string loginid = this.lblid.Text;
            //把节点的checkbox选中的节点tag放到Lastlist中（跟节点除外）
            for (int i = 0; i < tvwFunc.Nodes.Count; i++)
            {
                GetNodesLast(this.tvwFunc.Nodes[i]);
            }
            if (!untCommon.QuestionMsg("您确定要更改用户"+ this.lstUser.SelectedItem.ToString()+ "的权限吗？"))
            {
                return;
            }
            // 如果list中的某个元素在lastlist中不存在，用户则删除了该功能
            
            for (int i = 0; i < list.Count; i++)
            {
                if (Lastlist.Contains(list[i]) == false)
                {
                    
                    if (SysUserMgr.Del(loginid, int.Parse(list[i].ToString())) == false)
                    {
                        
                        error++;//发生错误
                    }
   
                }
               

            }
            
            //如果lastlistt中的某个元素在list中不存在，用户则添加了该功能
            
                for (int i = 0; i < Lastlist.Count; i++)
                {
                    if (list.Contains(Lastlist[i]) == false)
                    {
                        if (SysUserMgr.Add(loginid, int.Parse(Lastlist[i].ToString())) == false)
                        {
                            error++;//发生错误
                        }

                    }
                }
                if (error == 0)
                {

                    untCommon.InfoMsg("权限更改成功。");

                }
                else
                {
                    untCommon.InfoMsg("权限更改失败。");
                    error = 0;
                    GetFuncByUser(this.lblid.Text);

                }
            

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 根据权限选项的不同赋予不同权限
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioBtn_CheckedChange(object sender, EventArgs e)
        {
            if (!((RadioButton)sender).Checked)
            {
                return;
            }
            string rechargeMoney = string.Empty;
            switch (((RadioButton)sender).Text.ToString())
            {
                case "自选":
                    this.GetFuncByUser(this.lblid.Text);//得到权限
                    break;
                case "一级用户":
                    this.GetFuncByUser("999991");//得到一级权限
                    break;
                case "二级用户":
                    this.GetFuncByUser("999992");//得到二级权限
                    break;
                case "三级用户":
                    this.GetFuncByUser("999993");//得到三级权限
                    break;
                default:
                    break;
            }
        }

    }
    
}