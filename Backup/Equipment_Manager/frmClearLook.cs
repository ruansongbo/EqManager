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
    public partial class frmClearLook : Form
    {
        public frmClearLook()
        {
            InitializeComponent();
        }
        DataTable dat = new DataTable("clear");
        DataView dv = null;
        public void InitDbg()
        {
            dat = ClearMgr.GetAll();
            dv = new DataView(dat);
            if (dat != null)
            {
                this.dbgClear.DataSource = dv;
            }
 
        }

        private void frmClearLook_Load(object sender, EventArgs e)
        {
            this.InitDbg();
            this.BuidTree();
            tvwClearer.ExpandAll();
        }
        /// <summary>
        /// 构造清理人树
        /// </summary>
        private void BuidTree()
        {
            TreeNode Root = new TreeNode();
            Root.Text = "清理人";
            Root.ImageIndex=0;
            Root.ImageIndex=0;
            tvwClearer.Nodes.Add(Root);
            tvwClearer.ExpandAll();
            DataTable dt = SysUserMgr.GetAllName();
            if (dt != null)//构造子节点（清理人名单）
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TreeNode clearer = new TreeNode();
                    clearer.Text = dt.Rows[i][0].ToString();
                    clearer.ImageIndex = 1;
                    clearer.SelectedImageIndex = 1;
                    Root.Nodes.Add(clearer);
                }
 
            }
        }
        /// <summary>
        /// 根据用户点击不同的节点来过滤资产清理表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void tvwClearer_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent == null&&e.Node!=null)
            {
                this.InitDbg();
            }
            else
            {
                if (e.Node.Parent.Parent == null&&e.Node!=null) 
                {
                    dv.RowFilter = string.Format("清理人='{0}'", e.Node.Text);
                }
            }
        }
        /// <summary>
        /// 根据条件来过滤表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnSearch_Click(object sender, EventArgs e)
        {
            if(this.toolcbxSearchType.Text.Trim()=="")
            {
                untCommon.InfoMsg("请选择查找方式。");
                return;
            }
            if (this.tooltxtCodition.Text.Trim() == "")
            {
                untCommon.InfoMsg("请输入查找条件");
                return;
            }
            try
            {
                dv.RowFilter = string.Format("{0}='{1}'", this.toolcbxSearchType.Text, this.tooltxtCodition.Text);
                if (dbgClear.Rows.Count == 0)
                {
                    untCommon.InfoMsg("没有您所要查找的记录。");
                    return;
 
                }
            }
            catch (Exception)
            {
                untCommon.InfoMsg("没有您所要查找的记录。");
            }
            
           
 
            
        }

        private void toolbtnSearchAll_Click(object sender, EventArgs e)
        {
            this.InitDbg();
        }

        private void toolbtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 将所查询的结果导出到Exel中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnExel_Click(object sender, EventArgs e)
        {
            untCommon.ToExel(this.dbgClear);
        }
        /// <summary>
        /// 将所查询的结果导出到Exel中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolMenuItem_Exel_Click(object sender, EventArgs e)
        {
            untCommon.ToExel(this.dbgClear);
        }

        private void ToolMenuItem_Refresh_Click(object sender, EventArgs e)
        {
            this.InitDbg();

        }

        private void ToolMenuItem_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tooltxtCodition_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dv.RowFilter = string.Format("{0} like '{1}%'", this.toolcbxSearchType.Text, this.tooltxtCodition.Text);
            }
            catch
            {
                return;
            }
           
        }
    }
}