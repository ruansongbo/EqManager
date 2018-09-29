using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DataBusiness;
using DataEntity;


namespace Equipment_Manager
{
    public partial class frmEmployee : Form
    {
        public frmEmployee()
        {
            InitializeComponent();
        }

        TreeNode Root = null;
        DataTable dat = new DataTable("emp");//�������ܲ�ѯ���

        private void tctrEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            //����ѡ���ѡ���ͬ��������ذ�ť��״̬
            if (this.tctrEmp.SelectedIndex == 0)
            {
                this.toolSearh.Enabled = true;
                btnSave.Enabled = false;

                this.InitDbgEmp();
            }
            else
            {
                this.toolSearh.Enabled = false;
                btnSave.Enabled = true;
            }
            //���ѡ������޸����ϣ��͵õ���Ա���ĸ����Ե�ֵ�����ŵ����ı�����
            if (this.tctrEmp.SelectedIndex == 2)
            {
                this.txtEmpNo.Text = this.dbgEmp.SelectedRows[0].Cells[0].Value.ToString();
                this.txtName.Text = this.dbgEmp.SelectedRows[0].Cells[1].Value.ToString();
                string Sex = this.dbgEmp.SelectedRows[0].Cells[2].Value.ToString();
                if (Sex == "��")
                {
                    rabBoy.Checked = true;
                }
                else
                {
                    rabGirl.Checked = true;
                }
                this.cbxDepart.Text = this.dbgEmp.SelectedRows[0].Cells[3].Value.ToString();
            }

        }
        /// <summary>
        /// ������Ա��ʱ��д�������Ƿ�Ϸ�
        /// </summary>
        /// <returns></returns>
        private bool CheckAddInput()
        {
            if (this.txtNewName.Text.Trim() == "")
            {
                untCommon.InfoMsg("����д������");
                return false;
            }
            string sex = "";
            if (this.rabFemale.Checked)
            {
                sex = "Ů";
            }
            if (this.rabMale.Checked)
            {
                sex = "��";
            }
            if (sex.Trim() == "")
            {
                untCommon.InfoMsg("��ѡ���Ա�");
                return false;
            }
            return true;

        }
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.tctrEmp.SelectedIndex == 1)
            {
                
                    AddEmp();
               
            }
            if (this.tctrEmp.SelectedIndex == 2)
            {
                UpdateInfo();
            }
        }
        /// <summary>
        /// ���Ա��
        /// </summary>
        private void AddEmp()
        {
            if (this.CheckAddInput())
            {
                Employee emp = new Employee();
                emp.Name = this.txtNewName.Text;
                emp.Sex = rabFemale.Checked ? "Ů" : "��";

                emp.departId = int.Parse(this.cbxNewDepart.SelectedValue.ToString());

                //�����ӳɹ�
                if (EmployeeMgr.Add(emp))
                {


                    //ˢ����
                    for (int i = 0; i < Root.Nodes.Count; i++)
                    {
                        if (Root.Nodes[i].Text == this.cbxNewDepart.Text)
                        {
                            TreeNode newemp = new TreeNode();
                            newemp.Text = this.txtNewName.Text;
                            Root.Nodes[i].Nodes.Add(newemp);
                        }
                    }
                    this.txtNewName.Text = "";
                }
                else
                {
                    untCommon.InfoMsg("ע��ʧ��");
                }
            }
        }
        /// <summary>
        /// ��ʼ�������б�
        /// </summary>
        private void InitDepaert()
        {
            DataTable dt = DepartMgr.GetAll();
            if (dt != null)
            {

                //��ʼ����Ա��ע�����Ĳ����б�
                this.cbxNewDepart.Items.Clear();
                this.cbxNewDepart.DataSource = dt;
                this.cbxNewDepart.DisplayMember = dt.Columns[1].ToString();
                this.cbxNewDepart.ValueMember = dt.Columns[0].ToString();
                //��ʼ���޸���Ϣ����Ĳ����б�
                this.cbxDepart.Items.Clear();
                this.cbxDepart.DataSource = dt;
                this.cbxDepart.DisplayMember = dt.Columns[1].ToString();
                this.cbxDepart.ValueMember = dt.Columns[0].ToString();
            }
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            this.btnSave.Enabled = false;
            this.InitDepaert(); //��ʼ�������б�

            this.InitTree(); //��ʼ��Ա����

            this.InitDbgEmp();//��ʼ��Ա����

        }
        /// <summary>
        /// ����Ա����
        /// </summary>
        private void InitTree()
        {
            DataTable dt = ConpanyInfoMgr.GetInfo();
            if (dt != null)
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
        private void InitEmp(int departid,TreeNode parent)
        {
            DataTable dt = EmployeeMgr.GetEmpByDepart(departid);
            if(dt!=null)
            {
                for(int i=0;i<dt.Rows.Count;i++)
                {
                    TreeNode emp = new TreeNode();
                    emp.Text = dt.Rows[i][1].ToString();
                    emp.Tag = dt.Rows[i][0].ToString();
                    emp.ImageIndex = 2;
                    emp.SelectedImageIndex = 2;
                    parent.Nodes.Add(emp);

                }
            }
        }
        /// <summary>
        /// ��ʼ��Ա����
        /// </summary>
        private void InitDbgEmp()
        {
            dat = EmployeeMgr.GetAllInfo();
            if (dat != null)
            {
                this.dbgEmp.DataSource = null;
                this.dbgEmp.DataSource = dat;
            }

        }
        /// <summary>
        /// ����޸�����ʱ����������Ƿ�Ϸ�
        /// </summary>
        /// <returns>true���Ϸ���false�����Ϸ�</returns>
        private bool CheckUpdatInput()
        {
           
            if (this.txtName.Text.Trim() == "")
            {
                untCommon.InfoMsg("����д������");
                return false;
            }
            string sex = "";
            if (this.rabGirl.Checked)
            {
                sex = "Ů";
            }
            if (this.rabBoy.Checked)
            {
                sex = "��";
            }
            if (sex.Trim()== "")
            {
                untCommon.InfoMsg("��ѡ���Ա�");
                return false;
            }
            return true;

        }
        
        /// <summary>
        /// �޸�����
        /// </summary>
        private void UpdateInfo()
        {
            if (this.CheckUpdatInput())
            {
                Employee emp = new Employee();
                // emp.ID = this.txtId.Text;
                emp.EmpNo = int.Parse(this.txtEmpNo.Text);
                emp.Name = txtName.Text;
                emp.Sex = rabBoy.Checked ? "��" : "Ů";
                emp.departId = int.Parse(this.cbxDepart.SelectedValue.ToString());
                if (EmployeeMgr.Update(emp))
                {
                   
                    this.InitDbgEmp();
                    this.InitTree();
                    //�޸ĳɹ��Ժ�ı���ؿռ��״̬
                    this.txtName.Text = "";
                    this.txtEmpNo.Text = "";
                    this.btnSave.Enabled = false;
                    this.tctrEmp.SelectedIndex = 0;
                }
                else
                {
                    untCommon.InfoMsg("�޸�ʧ��");
                }
            }
        }
        /// <summary>
        /// ���ݵ�����ϵĲ�ͬ�ڵ��Ա������й���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvwEmp_AfterSelect(object sender, TreeViewEventArgs e)
        {
            DataView dv = new DataView(dat);
            if (e.Node.Parent == null && e.Node != null)
            {
                this.InitDbgEmp();
            }
            if (e.Node.Parent != null)
            {
                //���������ǲ��Žڵ��򰴲��Ź���
                if (e.Node.Parent .Parent== null && e.Node != null)
                {
                    dv.RowFilter = "���ڲ���='" + tvwEmp.SelectedNode.Text + "'";
                    this.dbgEmp.DataSource = dv;
                    return;

                }
                //����������Ա���ڵ��򰴹��Ź���
                if (e.Node.Parent.Parent.Parent==null && e.Node != null)
                {
                    string filterstr = string.Format("����={0}", tvwEmp.SelectedNode.Tag);
                    dv.RowFilter = filterstr;
                    
                    this.dbgEmp.DataSource = dv;
                    return;
                }
            }

                 
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();//�رմ���

        }
        /// <summary>
        /// ɾ��Ա��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnDel_Click(object sender, EventArgs e)
        {
            this.Del();

        }
        /// <summary>
        /// ɾ��Ա��
        /// </summary>
        private void Del()
        {
            if (this.dbgEmp.SelectedRows.Count == 0)
            {
                untCommon.InfoMsg("����Ա������ѡ����Ҫɾ����Ա����");
                return;
            }
            int empno = int.Parse(this.dbgEmp.SelectedRows[0].Cells[0].Value.ToString());
            if (untCommon.QuestionMsg("��ȷ��Ҫɾ����Ա����"))
            {
                int result = EmployeeMgr.Del(empno);
                if (result >0)
                {
                    untCommon.InfoMsg("ɾ���ɹ���");
                    this.InitTree();
                }
                else
                {
                    if (result == -1)
                    {
                        untCommon.ErrorMsg("ɾ��ʧ�ܣ���Ա���Ǳ���λ�̶��ʲ��ı���Ա��\r\n��ȡ����Ա���ı���Ա��ݺ���ɾ����");
                        return;
                    }
                    if(result==-2)
                    {
                        untCommon.ErrorMsg("ɾ��ʧ�ܣ���Ա���������õ��ʲ�û�й黹��\r\n��黹������ʲ�����ɾ����");
                        return;
                    }
                    
                    untCommon.InfoMsg("ɾ��ʧ��");
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
            DataView dv = new DataView(dat);
            string condition = toolcbxSearchtype.SelectedItem.ToString();//�������ҷ�ʽ
            string Input = tooltxtContaint.Text;//��������
            string str = string.Format("{0}='{1}'", condition, Input);
            dv.RowFilter = str;   //������������
            this.dbgEmp.DataSource = dv;
           
        }

        private void ToolMenuItem_update_Click(object sender, EventArgs e)
        {
            this.tctrEmp.SelectedIndex = 2;
        }

        private void ToolMenuItem_del_Click(object sender, EventArgs e)
        {
            this.Del();
        }
        /// <summary>
        /// ˢ��Ա����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolMenuItem_Refresh_Click(object sender, EventArgs e)
        {
            this.InitDbgEmp();
        }

        private void ToolMenuItem_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// �鿴����Ա��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnAll_Click(object sender, EventArgs e)
        {
            this.InitDbgEmp();

        }

       






       
    }
}