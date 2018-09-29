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
        /// ������������
        /// </summary>
        private void BuidTree()
        {
            TreeNode Root = new TreeNode();
            Root.Text = "������";
            Root.ImageIndex=0;
            Root.ImageIndex=0;
            tvwClearer.Nodes.Add(Root);
            tvwClearer.ExpandAll();
            DataTable dt = SysUserMgr.GetAllName();
            if (dt != null)//�����ӽڵ㣨������������
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
        /// �����û������ͬ�Ľڵ��������ʲ������
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
                    dv.RowFilter = string.Format("������='{0}'", e.Node.Text);
                }
            }
        }
        /// <summary>
        /// �������������˱��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnSearch_Click(object sender, EventArgs e)
        {
            if(this.toolcbxSearchType.Text.Trim()=="")
            {
                untCommon.InfoMsg("��ѡ����ҷ�ʽ��");
                return;
            }
            if (this.tooltxtCodition.Text.Trim() == "")
            {
                untCommon.InfoMsg("�������������");
                return;
            }
            try
            {
                dv.RowFilter = string.Format("{0}='{1}'", this.toolcbxSearchType.Text, this.tooltxtCodition.Text);
                if (dbgClear.Rows.Count == 0)
                {
                    untCommon.InfoMsg("û������Ҫ���ҵļ�¼��");
                    return;
 
                }
            }
            catch (Exception)
            {
                untCommon.InfoMsg("û������Ҫ���ҵļ�¼��");
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
        /// ������ѯ�Ľ��������Exel��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnExel_Click(object sender, EventArgs e)
        {
            untCommon.ToExel(this.dbgClear);
        }
        /// <summary>
        /// ������ѯ�Ľ��������Exel��
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