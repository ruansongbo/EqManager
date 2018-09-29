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
        /// ��ʼ���ʲ����ñ�
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
            this.InitDbgBoroow();//�����ʲ����ñ�
            this.InitTree();//����Ա����
        }
        /// <summary>
        /// ��ʾ��Ա����
        /// </summary>
        private void InitTree()
        {
            DataTable dt = ConpanyInfoMgr.GetInfo();
            if (dt != null)//���ظ��ڵ�
            {

                tvwEmp.Nodes.Clear();
                Root = new TreeNode();
                Root.Text = dt.Rows[0][1].ToString();
                Root.ImageIndex = 0;
                Root.SelectedImageIndex = 0;
                this.tvwEmp.Nodes.Add(Root);
                this.InitTreeDepart(Root);//�������Ĳ��Žڵ�
                Root.Expand();
                
            }


        }
        /// <summary>
        /// ��ʾ�����Žڵ�
        /// </summary>
        /// <param name="parent">���ڵ�</param>
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

                    this.InitEmp(int.Parse(deprt.Tag.ToString()), deprt);//������Ա���ڵ�
                }
            }

        }
        /// <summary>
        /// ��ʼ��Ա���ڵ�
        /// </summary>
        /// <param name="departid">����id</param>
        /// <param name="parent">���ڵ�</param>
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
        /// ���ݵ�����Ľڵ㲻ͬ�������ʲ����ñ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvwEmp_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if (this.dat.Rows.Count != 0)
            {
                if (e.Node.Parent == null)//ѡ����ڵ�
                {
                    this.InitDbgBoroow();
                }
                if (e.Node.Parent != null)//������ǲ��Žڵ�
                {
                    if (e.Node.Parent.Parent == null && e.Node != null)
                    {
                        string str = string.Format("ʹ�ò���='{0}'", e.Node.Text);
                        dv.RowFilter = str;
                        if (dbgBorrow.Rows.Count == 0)
                        {
                            untCommon.InfoMsg("û������Ҫ���ҵļ�¼��");
                        }
                    }

                    else if (e.Node.Parent.Parent.Parent == null && e.Node != null)//�������Ա���ڵ�
                    {
                        string str = string.Format("�����˹���={0}", e.Node.Tag);
                        dv.RowFilter = str;
                        if (dbgBorrow.Rows.Count == 0)
                        {
                            untCommon.InfoMsg("û������Ҫ���ҵļ�¼��");
                        }

                    }
                }
            }
        }
        /// <summary>
        /// ������ѯ
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
                untCommon.InfoMsg("û������Ҫ���ҵļ�¼��");
                return;
 
            }
                if (dbgBorrow.Rows.Count == 0)
                {
                    untCommon.InfoMsg("û������Ҫ���ҵļ�¼��");
                }
            
        }

        private void toolbtnSearchAll_Click(object sender, EventArgs e)
        {
            this.InitDbgBoroow();
        }
        /// <summary>
        /// �黹������ʲ�
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
        /// ������ѯ���Ľ��������Exel��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnExel_Click(object sender, EventArgs e)
        {
            untCommon.ToExel(this.dbgBorrow);
        }
        /// <summary>
        /// �黹�ʲ�
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
        /// ������ѯ���Ľ��������Exel��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolMenuItem_Exel_Click(object sender, EventArgs e)
        {
            untCommon.ToExel(this.dbgBorrow);
        }
        /// <summary>
        /// ˢ��
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
                if (toolcbxSeachType.Text == "�����˹���")
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