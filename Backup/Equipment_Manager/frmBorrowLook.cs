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
    public partial class frmBorrowLook : Form
    {
        public frmBorrowLook()
        {
            InitializeComponent();
        }
        TreeNode Root = new TreeNode();

        DataTable dat = new DataTable("Boroow");

        DataView dv = null;

        private string _user;
        public string User
        {
            set
            {
                this._user = value;
            }
        }
        /// <summary>
        /// 初始化资产领用表
        /// </summary>
        private void InitDbgBoroow()
        {
            
            dat = BoroowMgr.GetAll();
            dv = new DataView(dat);
            if (dv != null)
            {
                this.dbgBorrow.DataSource = dv;
            }
        }

        private void frmBorrowLook_Load(object sender, EventArgs e)
        {
            this.InitDbgBoroow();//加载资产领用表
            this.InitTree();//加载员工树
        }
        /// <summary>
        /// 出示化员工树
        /// </summary>
        private void InitTree()
        {
            DataTable dt = ConpanyInfoMgr.GetInfo();
            if (dt != null)//加载根节点
            {

                tvwEmp.Nodes.Clear();
                Root = new TreeNode();
                Root.Text = dt.Rows[0][1].ToString();
                Root.ImageIndex = 0;
                Root.SelectedImageIndex = 0;
                this.tvwEmp.Nodes.Add(Root);
                this.InitTreeDepart(Root);//加载树的部门节点
                Root.Expand();
                
            }


        }
        /// <summary>
        /// 出示化部门节点
        /// </summary>
        /// <param name="parent">父节点</param>
        private void InitTreeDepart(TreeNode parent)
        {
            DataTable dt = DepartMgr.GetAll();
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TreeNode deprt = new TreeNode();
                    deprt.Text = dt.Rows[i][1].ToString();
                    deprt.Tag = dt.Rows[i][0].ToString();
                    deprt.ImageIndex = 1;
                    deprt.SelectedImageIndex = 1;
                    parent.Nodes.Add(deprt);

                    this.InitEmp(int.Parse(deprt.Tag.ToString()), deprt);//加载树员工节点
                }
            }

        }
        /// <summary>
        /// 初始化员工节点
        /// </summary>
        /// <param name="departid">部门id</param>
        /// <param name="parent">父节点</param>
        private void InitEmp(int departid, TreeNode parent)
        {
            DataTable dt = EmployeeMgr.GetEmpByDepart(departid);
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TreeNode emp = new TreeNode();
                    emp.Text = dt.Rows[i][1].ToString();//5~1-a-s-p-x
                    emp.Tag = dt.Rows[i][0].ToString();
                    emp.ImageIndex = 2;
                    emp.SelectedImageIndex = 2;
                    parent.Nodes.Add(emp);

                }
            }
        }
        /// <summary>
        /// 跟据点击树的节点不同来过滤资产领用表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvwEmp_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if (this.dat.Rows.Count != 0)
            {
                if (e.Node.Parent == null)//选择根节点
                {
                    this.InitDbgBoroow();
                }
                if (e.Node.Parent != null)//点击的是部门节点
                {
                    if (e.Node.Parent.Parent == null && e.Node != null)
                    {
                        string str = string.Format("使用部门='{0}'", e.Node.Text);
                        dv.RowFilter = str;
                        if (dbgBorrow.Rows.Count == 0)
                        {
                            untCommon.InfoMsg("没有您所要查找的记录。");
                        }
                    }

                    else if (e.Node.Parent.Parent.Parent == null && e.Node != null)//点击的是员工节点
                    {
                        string str = string.Format("领用人工号={0}", e.Node.Tag);
                        dv.RowFilter = str;
                        if (dbgBorrow.Rows.Count == 0)
                        {
                            untCommon.InfoMsg("没有您所要查找的记录。");
                        }

                    }
                }
            }
        }
        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string str = string.Format("{0}='{1}'", toolcbxSeachType.Text, tooltxtCondition.Text);

                dv.RowFilter = str;
                
                
            }
            catch(Exception)
            {
                untCommon.InfoMsg("没有您所要查找的记录。");
                return;
 
            }
                if (dbgBorrow.Rows.Count == 0)
                {
                    untCommon.InfoMsg("没有您所要查找的记录。");
                }
            
        }

        private void toolbtnSearchAll_Click(object sender, EventArgs e)
        {
            this.InitDbgBoroow();
        }
        /// <summary>
        /// 归还所借的资产
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnReturn_Click(object sender, EventArgs e)
        {
            frmReturn fr = new frmReturn();
            fr.txtbooker.Text = this._user;
            fr.txtborrower.Text = this.dbgBorrow.SelectedRows[0].Cells[5].Value.ToString();
            fr.txtEqNo.Text = this.dbgBorrow.SelectedRows[0].Cells[1].Value.ToString();
            fr.ShowDialog();
        
          
        }

        private void toolbtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 将所查询出的结果导出到Exel中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnExel_Click(object sender, EventArgs e)
        {
            untCommon.ToExel(this.dbgBorrow);
        }
        /// <summary>
        /// 归还资产
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolMenuItem_Return_Click(object sender, EventArgs e)
        {
            frmReturn fr = new frmReturn();
            fr.txtbooker.Text = this._user;
            fr.txtborrower.Text = this.dbgBorrow.SelectedRows[0].Cells[5].Value.ToString();
            fr.txtEqNo.Text = this.dbgBorrow.SelectedRows[0].Cells[1].Value.ToString();//5^1^a^s^p^x
            fr.ShowDialog();

        }
        /// <summary>
        /// 将所查询出的结果导出到Exel中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolMenuItem_Exel_Click(object sender, EventArgs e)
        {
            untCommon.ToExel(this.dbgBorrow);
        }
        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolMenuItem_Refresh_Click(object sender, EventArgs e)
        {
            this.InitDbgBoroow();

        }

        private void ToolMenuItem_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tooltxtCondition_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (toolcbxSeachType.Text == "领用人工号")
                {
                    string fileter = string.Format("{0} like {1}%", toolcbxSeachType.Text, int.Parse(tooltxtCondition.Text));
                    dv.RowFilter = fileter;
                    return;

                }
            }
            catch
            { return; }
            string str = string.Format("{0} like '{1}%'", toolcbxSeachType.Text, tooltxtCondition.Text);
            dv.RowFilter = str;
        }
 
    }
}