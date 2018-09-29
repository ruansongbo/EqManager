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
    public partial class frmDepart : Form
    {
        public frmDepart()
        {
            InitializeComponent();
        }
        static string  selecttxt = "";
        static bool isAdd = false;


        
        private void frmDepart_Load(object sender, EventArgs e)
        {
            this.BuidTree();

            

            
        }
        /// <summary>
        /// 构造树
        /// </summary>  
        /// 
        TreeNode RootNode = null;
        ArrayList newdepartlist = new ArrayList();
        
        private void BuidTree()
        {
            tvwDepart.Nodes.Clear();
            DataTable dt = ConpanyInfoMgr.GetInfo();
            if (dt != null)
            {
                tvwDepart.Nodes.Clear();
                RootNode = new TreeNode();
                RootNode.Text = dt.Rows[0][1].ToString();//跟节点的文本为本单位的名称
                RootNode.ImageIndex = 0;
                RootNode.SelectedImageIndex = 0;
                tvwDepart.Nodes.Add(RootNode);
                
                this.BuildNodesDepart(RootNode);//加载部门节点
    

            }
 
        }
        /// <summary>
        /// 构造本单位树的部门节点
        /// </summary>
        /// <param name="parent"></param>
        ///   
        private void BuildNodesDepart(TreeNode parent)
        {
            DataTable dt = DepartMgr.GetAll();
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TreeNode depart = new TreeNode();
                    depart.Text = dt.Rows[i][1].ToString();
                    depart.Tag = dt.Rows[i][0].ToString();
                    depart.ImageIndex = 1;
                    depart.SelectedImageIndex = 1;
                    parent.Nodes.Add(depart);

                }
                tvwDepart.ExpandAll();
            }
        }
        /// <summary>
        /// 添加默认节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.AddNodes();
            
            
            
        }
        /// <summary>
        /// 添加节点
        /// </summary>
        private void AddNodes()
        {
            isAdd = true;

            tvwDepart.LabelEdit = true;//开启节点编辑
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnUpdate.Enabled = false;
            btnDel.Enabled = false;
            this.contextMenuStrip1.Items[2].Enabled = false;
            this.contextMenuStrip1.Items[4].Enabled = false;

            TreeNode newdepart = new TreeNode();
            newdepart.Text = "请输入新部门名称";
            newdepart.ImageIndex = 1;
            newdepart.SelectedImageIndex = 1;
            newdepart.Tag = "new";
            RootNode.Nodes.Add(newdepart);

            newdepart.BeginEdit();
 
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (isAdd)//如果是添加
            {
                this.AddDepart();

            }
            else
            {
                this.Updatedepart();//是修改
            }
           
            
        }
        private void AddDepart()
        {
            int flag = 0;
            GetNodes(RootNode);
            for (int i = 0; i < newdepartlist.Count; i++)
            {
                if (newdepartlist[i].ToString() == "请输入新部门名称")
                {
                    flag++;
                    
                }
            }
            if (flag > 0)
            {
                untCommon.ErrorMsg("添加失败，请输入合法的部门名称。");
                return;
            }
            else
            {

                for (int i = 0; i < newdepartlist.Count; i++)
                {


                    //循环向数据库中添加
                    if (DepartMgr.Add(newdepartlist[i].ToString()))
                    {
                        flag = 0;
                        tvwDepart.LabelEdit = false;//关闭节点编辑
                        tvwDepart.Nodes.Clear();
                        btnCancel.Enabled = false;
                        btnSave.Enabled = false;
                        btnUpdate.Enabled = true;
                        btnDel.Enabled = true;
                        this.contextMenuStrip1.Items[2].Enabled = true;
                        this.contextMenuStrip1.Items[4].Enabled = true;
                        this.BuidTree();

                    }
                    else
                    {
                        untCommon.InfoMsg(newdepartlist[i].ToString() + "  添加失败。");
                    }

                }
            }
 
        }
        /// <summary>
        /// 遍历部门树，得到新添加的项
        /// </summary>
        /// <param name="tnParent"></param>
        private void GetNodes(TreeNode tnParent)
        {
            if (tnParent != null)
            {
                foreach (TreeNode tn in tnParent.Nodes)
                {
                    //如果发现新添加的部门就将新部门放到arrylist 中
                    if (tn.Tag.ToString() == "new")
                    {
                        newdepartlist.Add(tn.Text);
                    }
                    GetNodes(tn);
                }
            }
        }
        

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.updatedtree();
            
            
        }
        /// <summary>
        /// 修改树的部门节点
        /// </summary>
        private void updatedtree()
        {
            if (tvwDepart.SelectedNode == null)
            {
                untCommon.InfoMsg("请选择部门。");
                return;
            }
            if (tvwDepart.SelectedNode.Parent == null)
            {
                untCommon.InfoMsg("您不能修改该节点。");
                return;
            }
            isAdd = false;

            tvwDepart.LabelEdit = true;
            tvwDepart.SelectedNode.BeginEdit();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnAdd.Enabled = false;
            btnDel.Enabled = false;
            this.contextMenuStrip1.Items[0].Enabled = false;
            this.contextMenuStrip1.Items[2].Enabled = false;
        }
        /// <summary>
        /// 向数据库中跟新数据
        /// </summary>
        private void Updatedepart()
        {

            selecttxt = tvwDepart.SelectedNode.Text;
            if (DepartMgr.Update(tvwDepart.SelectedNode.Text, int.Parse(tvwDepart.SelectedNode.Tag.ToString())))
            {
               // untCommon.InfoMsg("修改成功。");
                btnSave.Enabled = false;
                btnUpdate.Enabled = true;
                btnAdd.Enabled = true;
                tvwDepart.LabelEdit = false;
                btnDel.Enabled = true;
                this.contextMenuStrip1.Items[0].Enabled = true;
                this.contextMenuStrip1.Items[2].Enabled = true;
            }
            else
            {
                untCommon.InfoMsg("修改失败。");
                tvwDepart.SelectedNode.Text = selecttxt;
                tvwDepart.SelectedNode.BeginEdit();

            }
 
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            this.Del();
          
       
        
        
        }
        /// <summary>
        /// 删除部门
        /// </summary>
        private void Del()
        {
            if (tvwDepart.SelectedNode == null)
            {
                untCommon.InfoMsg("请选择所要删除的部门");
                return;
            }
            if (tvwDepart.SelectedNode.Parent == null)
            {
                untCommon.InfoMsg("您不能删除该节点");
                return;

            }
            if (untCommon.QuestionMsg("您确定要删除该部门吗？"))
            {

                if (DepartMgr.Del(int.Parse(tvwDepart.SelectedNode.Tag.ToString())))
                {
                    this.tvwDepart.SelectedNode.Remove();
                    //this.BuidTree();
                }
                else
                {
                    untCommon.ErrorMsg("删除失败。");

                }

            }
        }
        /// <summary>
        /// 取消添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.CancelAdd();
           
        }
        /// <summary>
        ///  取消添加
        /// </summary>
        private void CancelAdd()
        {
            for (int i = tvwDepart.Nodes[0].Nodes.Count - 1; i >= 0; i--)
            {
                if (this.tvwDepart.Nodes[0].Nodes[i].Tag.ToString() == "new")
                {
                    this.tvwDepart.Nodes.Remove(tvwDepart.Nodes[0].Nodes[i]);

                }
            }


            this.btnUpdate.Enabled = true;
            this.contextMenuStrip1.Items[2].Enabled = true;
            this.contextMenuStrip1.Items[4].Enabled = true;
            this.contextMenuStrip1.Items[0].Enabled = true;
            this.btnSave.Enabled = false;
            btnDel.Enabled = true;
            this.tvwDepart.LabelEdit = false;

            isAdd = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToolMenuItem_Add_Click(object sender, EventArgs e)
        {
            this.AddNodes();

        }

        private void ToolMenuItem_Update_Click(object sender, EventArgs e)
        {
            this.updatedtree();;
        }

        private void ToolMenuItem_Save_Click(object sender, EventArgs e)
        {
            if (isAdd)//如果是添加
            {
                this.AddDepart();

            }
            else
            {
                this.Updatedepart();//是修改
            }
        }

        private void ToolMenuItem_del_Click(object sender, EventArgs e)
        {
            this.Del();
        }

        private void ToolMenuItem_Refresh_Click(object sender, EventArgs e)
        {
            this.BuidTree();
        }

        private void ToolMenuItem_Cancel_Click(object sender, EventArgs e)
        {
            this.CancelAdd();

        }


    }
}