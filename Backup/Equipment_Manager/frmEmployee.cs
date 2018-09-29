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
        DataTable dat = new DataTable("emp");//用来接受查询结果

        private void tctrEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            //根据选择的选项卡不同来设置相关按钮的状态
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
            //如果选择的是修改资料，就得到该员工的各属性的值，并放到个文本框内
            if (this.tctrEmp.SelectedIndex == 2)
            {
                this.txtEmpNo.Text = this.dbgEmp.SelectedRows[0].Cells[0].Value.ToString();
                this.txtName.Text = this.dbgEmp.SelectedRows[0].Cells[1].Value.ToString();
                string Sex = this.dbgEmp.SelectedRows[0].Cells[2].Value.ToString();
                if (Sex == "男")
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
        /// 检查添加员工时填写的资料是否合法
        /// </summary>
        /// <returns></returns>
        private bool CheckAddInput()
        {
            if (this.txtNewName.Text.Trim() == "")
            {
                untCommon.InfoMsg("请填写姓名。");
                return false;
            }
            string sex = "";
            if (this.rabFemale.Checked)
            {
                sex = "女";
            }
            if (this.rabMale.Checked)
            {
                sex = "男";
            }
            if (sex.Trim() == "")
            {
                untCommon.InfoMsg("请选择性别");
                return false;
            }
            return true;

        }
        /// <summary>
        /// 保存设置
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
        /// 添加员工
        /// </summary>
        private void AddEmp()
        {
            if (this.CheckAddInput())
            {
                Employee emp = new Employee();
                emp.Name = this.txtNewName.Text;
                emp.Sex = rabFemale.Checked ? "女" : "男";

                emp.departId = int.Parse(this.cbxNewDepart.SelectedValue.ToString());

                //如果添加成功
                if (EmployeeMgr.Add(emp))
                {


                    //刷新树
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
                    untCommon.InfoMsg("注册失败");
                }
            }
        }
        /// <summary>
        /// 初始化部门列表
        /// </summary>
        private void InitDepaert()
        {
            DataTable dt = DepartMgr.GetAll();
            if (dt != null)
            {

                //初始化新员工注册界面的部门列表
                this.cbxNewDepart.Items.Clear();
                this.cbxNewDepart.DataSource = dt;
                this.cbxNewDepart.DisplayMember = dt.Columns[1].ToString();
                this.cbxNewDepart.ValueMember = dt.Columns[0].ToString();
                //初始化修改信息界面的部门列表
                this.cbxDepart.Items.Clear();
                this.cbxDepart.DataSource = dt;
                this.cbxDepart.DisplayMember = dt.Columns[1].ToString();
                this.cbxDepart.ValueMember = dt.Columns[0].ToString();
            }
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            this.btnSave.Enabled = false;
            this.InitDepaert(); //初始化部门列表

            this.InitTree(); //初始化员工树

            this.InitDbgEmp();//初始化员工表

        }
        /// <summary>
        /// 构造员工树
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
        /// 初始化员工表
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
        /// 检查修改资料时输入的资料是否合法
        /// </summary>
        /// <returns>true：合法；false：不合法</returns>
        private bool CheckUpdatInput()
        {
           
            if (this.txtName.Text.Trim() == "")
            {
                untCommon.InfoMsg("请填写姓名。");
                return false;
            }
            string sex = "";
            if (this.rabGirl.Checked)
            {
                sex = "女";
            }
            if (this.rabBoy.Checked)
            {
                sex = "男";
            }
            if (sex.Trim()== "")
            {
                untCommon.InfoMsg("请选择性别");
                return false;
            }
            return true;

        }
        
        /// <summary>
        /// 修改资料
        /// </summary>
        private void UpdateInfo()
        {
            if (this.CheckUpdatInput())
            {
                Employee emp = new Employee();
                // emp.ID = this.txtId.Text;
                emp.EmpNo = int.Parse(this.txtEmpNo.Text);
                emp.Name = txtName.Text;
                emp.Sex = rabBoy.Checked ? "男" : "女";
                emp.departId = int.Parse(this.cbxDepart.SelectedValue.ToString());
                if (EmployeeMgr.Update(emp))
                {
                   
                    this.InitDbgEmp();
                    this.InitTree();
                    //修改成功以后改变相关空间的状态
                    this.txtName.Text = "";
                    this.txtEmpNo.Text = "";
                    this.btnSave.Enabled = false;
                    this.tctrEmp.SelectedIndex = 0;
                }
                else
                {
                    untCommon.InfoMsg("修改失败");
                }
            }
        }
        /// <summary>
        /// 根据点击树上的不同节点对员工表进行过滤
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
                //如果点击的是部门节点则按部门过滤
                if (e.Node.Parent .Parent== null && e.Node != null)
                {
                    dv.RowFilter = "所在部门='" + tvwEmp.SelectedNode.Text + "'";
                    this.dbgEmp.DataSource = dv;
                    return;

                }
                //如果点击的是员工节点则按工号过滤
                if (e.Node.Parent.Parent.Parent==null && e.Node != null)
                {
                    string filterstr = string.Format("工号={0}", tvwEmp.SelectedNode.Tag);
                    dv.RowFilter = filterstr;
                    
                    this.dbgEmp.DataSource = dv;
                    return;
                }
            }

                 
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();//关闭窗口

        }
        /// <summary>
        /// 删除员工
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnDel_Click(object sender, EventArgs e)
        {
            this.Del();

        }
        /// <summary>
        /// 删除员工
        /// </summary>
        private void Del()
        {
            if (this.dbgEmp.SelectedRows.Count == 0)
            {
                untCommon.InfoMsg("请在员工表中选择所要删除的员工。");
                return;
            }
            int empno = int.Parse(this.dbgEmp.SelectedRows[0].Cells[0].Value.ToString());
            if (untCommon.QuestionMsg("您确定要删除该员工吗？"))
            {
                int result = EmployeeMgr.Del(empno);
                if (result >0)
                {
                    untCommon.InfoMsg("删除成功。");
                    this.InitTree();
                }
                else
                {
                    if (result == -1)
                    {
                        untCommon.ErrorMsg("删除失败，该员工是本单位固定资产的保管员，\r\n请取消该员工的保管员身份后再删除。");
                        return;
                    }
                    if(result==-2)
                    {
                        untCommon.ErrorMsg("删除失败，该员工还有领用的资产没有归还，\r\n请归还所借的资产后再删除。");
                        return;
                    }
                    
                    untCommon.InfoMsg("删除失败");
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
            DataView dv = new DataView(dat);
            string condition = toolcbxSearchtype.SelectedItem.ToString();//条件查找方式
            string Input = tooltxtContaint.Text;//查找条件
            string str = string.Format("{0}='{1}'", condition, Input);
            dv.RowFilter = str;   //根据条件过滤
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
        /// 刷新员工表
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
        /// 查看所有员工
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnAll_Click(object sender, EventArgs e)
        {
            this.InitDbgEmp();

        }

       






       
    }
}