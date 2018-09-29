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
        ArrayList list = null;//保村用户原来的权限

        ArrayList Lastlist = new ArrayList();//保存用户被更改过后的权限

        private string _loginname;
        public string LoginName
        {
            set
            {
                this._loginname = value;
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
            string name = "";
            if (lstUser.SelectedIndex != -1)
            {
                name = SysUserMgr.GetANameByLoginName(lstUser.SelectedItems[0].ToString());
 
            }
            if (name!="")
            {
                this.lblnamee.Visible = true;
                this.lblName.Text = name;
            }


            this.GetFuncByUser();//得到权限

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
        private void GetFuncByUser()
        {
            this.list = SysUserMgr.GetOneListByUser(this.lstUser.SelectedItem.ToString());
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
            if (this.lstUser.SelectedItems[0].ToString() == this._loginname)
            {
                untCommon.ErrorMsg("错误,您不能设置自己的权限。");
                return;
            }
            if (this.lstUser.SelectedItems[0].ToString() == "sa")
            {
                untCommon.ErrorMsg("错误,您不能设置用户" + "sa" + "的权限。用户" + "sa" + "对本系统具有完全控制权");
                GetFuncByUser();
                return;
            }
            string loginname = this.lstUser.SelectedItem.ToString();
            //把节点的checkbox选中的节点tag放到Lastlist中（跟节点除外）
            for (int i = 0; i < tvwFunc.Nodes.Count; i++)
            {
                GetNodesLast(this.tvwFunc.Nodes[i]);
            }
            if (!untCommon.QuestionMsg("您确定要更改用户"+ loginname+ "的权限吗？"))
            {
                return;
            }
            // 如果list中的某个元素在lastlist中不存在，用户则删除了该功能
            
            for (int i = 0; i < list.Count; i++)
            {
                if (Lastlist.Contains(list[i]) == false)
                {
                    
                    if (SysUserMgr.Del(loginname, int.Parse(list[i].ToString())) == false)
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
                        if (SysUserMgr.Add(loginname, int.Parse(Lastlist[i].ToString())) == false)
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
                    GetFuncByUser();

                }
            

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
    
}