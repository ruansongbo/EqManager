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
        static bool isAddSub = false;


        
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
        ArrayList newsubdepartlist = new ArrayList();
        
        private void BuidTree()
        {
            tvwDepart.Nodes.Clear();
            DataTable dt = CompanyInfoMgr.GetInfo();
            if (dt != null)
            {
                tvwDepart.Nodes.Clear();
                RootNode = new TreeNode();
                RootNode.Text = dt.Rows[0][1].ToString();//跟节点的文本为本单位的名称
                RootNode.ImageIndex = 0;
                RootNode.SelectedImageIndex = 0;
                tvwDepart.Nodes.Add(RootNode);
                
                this.BuildSecondDepart(RootNode);//加载部门节点
    

            }
 
        }
        /// <summary>
        /// 构造本单位树的二级部门节点
        /// </summary>
        /// <param name="parent"></param>
        ///   
        private void BuildSecondDepart(TreeNode parent)
        {
            DataTable dt = DepartMgr.GetSecondOrder();
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

                    this.BuildThirdDepart(RootNode.Nodes[i]);
                }
                tvwDepart.ExpandAll();
            }
        }
        /// <summary>
        /// 构造本单位树的三级部门节点
        /// </summary>
        /// <param name="parent"></param>
        private void BuildThirdDepart(TreeNode parent)
        {
            string parentId = parent.Tag.ToString();
            DataTable dt = DepartMgr.GetThirdOrder(parentId);
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
            btnAddSub.Enabled = false;


            

            TreeNode newdepart = new TreeNode();
            newdepart.Text = "请输入新部门名称";
            newdepart.ImageIndex = 1;
            newdepart.SelectedImageIndex = 1;
            newdepart.Tag = "new";
            RootNode.Nodes.Add(newdepart);

            newdepart.BeginEdit();
 
        }

        public void AddSubNodes()
        {
            isAdd = true;
            isAddSub = true;

            tvwDepart.LabelEdit = true;//开启节点编辑
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnUpdate.Enabled = false;
            btnDel.Enabled = false;
            btnAdd.Enabled = false;

            TreeNode newsubdepart = new TreeNode();
            newsubdepart.Text = "请输入新部门名称";
            newsubdepart.ImageIndex = 1;
            newsubdepart.SelectedImageIndex = 1;
            newsubdepart.Tag = "newsub";
            
            //RootNode.Nodes.Add(newsubdepart);
            if (tvwDepart.SelectedNode != null)
            {
                tvwDepart.SelectedNode.Nodes.Add(newsubdepart);
                tvwDepart.SelectedNode.Expand();
            }
            else
                untCommon.ErrorMsg("请选择主节点");
            newsubdepart.BeginEdit();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (isAdd)//如果是添加
            {
                GetNodes(RootNode);
                this.AddSecondDepart();
                if (isAddSub)
                {
                    this.AddThdDepart();
                }

            }
            else
            {
                this.Updatedepart();//是修改
            }

            this.BuidTree();
        }
        private void AddSecondDepart()
        {
            int flag = 0;
            string departId = "";
            
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
                    departId = string.Format("{0:00}", DepartMgr.SecondCount() + 1) + "000";

                    //循环向数据库中添加
                    if (DepartMgr.Add(departId,newdepartlist[i].ToString(),"0"))
                    {
                        flag = 0;
                        tvwDepart.LabelEdit = false;//关闭节点编辑
                        tvwDepart.Nodes.Clear();
                        btnCancel.Enabled = false;
                        btnSave.Enabled = false;
                        btnUpdate.Enabled = true;
                        btnDel.Enabled = true;
                        btnAddSub.Enabled = true;

                        this.BuidTree();

                    }
                    else
                    {
                        untCommon.InfoMsg(newdepartlist[i].ToString() + "  添加失败。");
                    }

                }
            }
 
        }

        private void AddThdDepart()
        {
            int flag = 0;
            string departId = "";
            string parentId = "";
            //GetNodes(RootNode);
            for (int i = 0; i < newsubdepartlist.Count; i++)
            {
                if (newsubdepartlist[i].ToString() == "请输入新部门名称")
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

                for (int i = 0; i < newsubdepartlist.Count; i+=2)
                {
                    parentId = newsubdepartlist[i+1].ToString(); 
                    departId = string.Format("{0:000}", DepartMgr.ThirdCount() + 1);
                    departId = parentId.Substring(0, 2) + departId;

                    //循环向数据库中添加
                    if (DepartMgr.Add(departId, newsubdepartlist[i].ToString(),parentId ))
                    {
                        flag = 0;
                        tvwDepart.LabelEdit = false;//关闭节点编辑
                        tvwDepart.Nodes.Clear();
                        btnCancel.Enabled = false;
                        btnSave.Enabled = false;
                        btnUpdate.Enabled = true;
                        btnDel.Enabled = true;
                        btnAddSub.Enabled = true;

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
                    if (tn.Tag.ToString() == "newsub")
                    {
                        newsubdepartlist.Add(tn.Text);
                        newsubdepartlist.Add(tn.Parent.Tag.ToString());
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
            btnAddSub.Enabled = false;
            btnDel.Enabled = false;

        }
        /// <summary>
        /// 向数据库中跟新数据
        /// </summary>
        private void Updatedepart()
        {

            selecttxt = tvwDepart.SelectedNode.Text;
            if (DepartMgr.Update(tvwDepart.SelectedNode.Text, tvwDepart.SelectedNode.Tag.ToString()))
            {
               // untCommon.InfoMsg("修改成功。");
                btnSave.Enabled = false;
                btnUpdate.Enabled = true;
                btnAdd.Enabled = true;
                btnAddSub.Enabled = true;
                tvwDepart.LabelEdit = false;
                btnDel.Enabled = true;

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

                if (DepartMgr.Del(tvwDepart.SelectedNode.Tag.ToString()))
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
                if (isAddSub)
                {
                    for (int j = tvwDepart.Nodes[0].Nodes[i].Nodes.Count - 1; j >= 0; j--)
                    {
                        if (this.tvwDepart.Nodes[0].Nodes[i].Nodes[j].Tag.ToString() == "newsub")
                        {
                            this.tvwDepart.Nodes.Remove(tvwDepart.Nodes[0].Nodes[i].Nodes[j]);

                        }
                    }
                }
            }


            this.btnUpdate.Enabled = true;

            this.btnSave.Enabled = false;
            btnAddSub.Enabled = true;
            btnAdd.Enabled = true;
            btnDel.Enabled = true;
            this.tvwDepart.LabelEdit = false;

            isAdd = false;
            isAddSub=false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

      

        

       

        


        private void btnAddSub_Click(object sender, EventArgs e)
        {
            //根节点返回
            if (this.tvwDepart.SelectedNode.Parent == null)
            {
                return;
            }
            //叶节点返回
            if (this.tvwDepart.SelectedNode.Parent.Parent != null)
            {
                return;
            }
            //只有枝节点才能创建下级
            this.AddSubNodes();
            this.btnAddSub.Enabled = false;
        }



    }
}