using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;
using MyTCPServerNameSpace;
using DataBusiness;
using DataEntity;

namespace Equipment_Manager
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
           
        }
        
        private static int curPage = 1;  //当前页
        private static int TotalPage = 0; //总页数
        private static int pageCount = 30; //第页条数

        
       
        private string _user;
        private string _loginname;

        ArrayList MenuList = null;
      

        public string LoginName
        {
            set
            {
                this._loginname = value;
            }
            
        }
        
        public string User
        {
            set
            {
                this._user = value;
 
            }
            
           
        }

        
        
        /// <summary>
        /// 资产编号点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">dbg</param>
        frmEqInfo frmInfo = null;
        private void colEqNo_CellContentClick(Object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = (DataGridView)(sender);
            // 确认是否确实是在“资产编号”数据列当中的超级链接上按一下。
            if (e.RowIndex >= 0 && e.ColumnIndex == grid.Columns["资产编号"].Index)
            {

                //string EqNo = ((DataRowView)(grid.Rows[e.RowIndex].DataBoundItem)).Row["资产编号"].ToString();
                string EqNo = this.dbgEq.SelectedRows[0].Cells[0].Value.ToString();
                if (frmInfo == null || frmInfo.IsDisposed)
                {
                    frmInfo = new frmEqInfo();
                    frmInfo.Eqno = EqNo;
                    frmInfo.Show();

                }
                else
                {
                    frmInfo.Eqno = EqNo;
                    frmInfo.GetInfo();
                    frmInfo.Focus();
                }
                
                frmInfo.TopMost = true;
                //调整资产信息卡出现的位置
                frmInfo.Location = new Point(this.PointToClient(MousePosition).X+10, this.PointToClient(MousePosition).Y+50);

            }
        }

        cardReader cardR;
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.MenuList = SysUserMgr.GetPower(_loginname);//得到登录用户的权限（可执行的操作）
            this.initMenu();//加载菜单
            this.initToolBar();//加载资产管理的工具栏
            this.InitDbgEq();//加载资产表

            this.BuilTree();//加载树
            this.tvwEqSeach.Nodes[0].Expand();//展开树的第一层节点

            this.InitStatusInfo();//加载状态栏
            TotalPage = this.getTotalPage();//得到数据的总页数
            this.lblTotalpage.Text = "共"+TotalPage.ToString()+"页";


            cardR = new cardReader(); 

           

        }
        /// <summary>
        /// 添加节点
        /// </summary>
        /// <param name="txt">节点的文本</param>
        /// <param name="parent">节点的父节点</param>
        private void AddNode(TreeNode node, string txt,int imageindex, TreeNode parent)
        {
            //TreeNode node = new TreeNode();
            node.Text = txt;
            node.ImageIndex = imageindex;
            node.SelectedImageIndex = imageindex;//5-1-a-s-p-x
            parent.Nodes.Add(node);
            
        }
        /// <summary>
        /// 构造树
        /// </summary>
        private void BuilTree()
        {
            TreeNode nodeAll = new TreeNode();
            nodeAll.Text = "全部资产";
            nodeAll.ImageIndex = 0;
            nodeAll.SelectedImageIndex = 0;
            tvwEqSeach.Nodes.Add(nodeAll);
            


            this.BuildType(nodeAll);//加载资产类别l列表
            this.BuildName(nodeAll);//加载资产名称列表
            this.BuildKeepPlace(nodeAll);//加载保存地点列表
            this.BuildAddType(nodeAll);//加载增长方式列表
            
        }
        /// <summary>
        /// 构造资产保存地点节点
        /// </summary>
        /// <param name="parent">父节点</param>
        private void BuildKeepPlace(TreeNode parent)
        {
            TreeNode KeepPlace = new TreeNode();
            this.AddNode(KeepPlace,"保存地点",1, parent);
            DataTable dt = KeepPlaceMgr.GetAllPlace();
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TreeNode keep = new TreeNode();
                    this.AddNode(keep, dt.Rows[i][1].ToString(),2, KeepPlace);
                }
            }


        }
        /// <summary>
        /// 构造资产名称节点
        /// </summary>
        /// <param name="parent">父节点</param>
        private void BuildName(TreeNode parent)
        {
            TreeNode Name = new TreeNode();
            this.AddNode(Name, "资产名称",5, parent);
            DataTable dt = EqNameMgr.GetAllEqname();
            
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TreeNode name = new TreeNode();
                        this.AddNode(name,dt.Rows[i][1].ToString() ,2, Name);

                    }
                }
            

        }
        /// <summary>
        /// 构造资产类比节点
        /// </summary>
        /// <param name="parent">父节点</param>
        private void BuildType(TreeNode parent)
        {
            TreeNode Type = new TreeNode();
            this.AddNode(Type, "资产类别",7, parent);

            DataTable dt = EqTypeMgr.GetAllType();
            
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TreeNode type = new TreeNode();
                        this.AddNode(type, dt.Rows[i][1].ToString(),2, Type);

                    }
                }
            
 
        }
        /// <summary>
        /// 构造增长方式节点
        /// </summary>
        /// <param name="parent"></param>
        private void BuildAddType(TreeNode parent)
        {
            TreeNode nodeAddType = new TreeNode();
            this.AddNode(nodeAddType,"增长方式",9,parent);

            DataTable dt = AddTypeMgr.GetAllType();
            
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TreeNode addtype = new TreeNode();
                        this.AddNode(addtype, dt.Rows[i][1].ToString(),2, nodeAddType);
 
                    }
                }
            
        }


        /// <summary>
        /// 跟均用户点击树上的不同节点来过滤资产记录表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvwEqSeach_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent == null)//点击根节点
            {
                return;
            }

            if (e.Node.Parent.Parent == null && e.Node != null)//点击第枝节点
            {
                return;
            }
            if (e.Node.Parent.Parent.Parent == null && e.Node != null)//点击叶节点
            {
                if (e.Node.Parent.Text == "资产编号")
                {
                    this.SearchByEqno(e.Node.Text);
                    this.toolStrip3.Enabled = false;
                    this.toolbtnSearchAll.Enabled = true;
                    return;
 
                }
                if (e.Node.Parent.Text == "资产类别")
                {
                    this.SearchByType(e.Node.Text);
                    this.toolStrip3.Enabled = false;
                    this.toolbtnSearchAll.Enabled = true;
                    return;

                }
                if (e.Node.Parent.Text == "资产名称")
                {
                    this.SearchByName(e.Node.Text);
                    this.toolStrip3.Enabled = false;
                    this.toolbtnSearchAll.Enabled = true;
                    return;

                }
                if (e.Node.Parent.Text == "增长方式")
                {
                    this.searchByAddtype(e.Node.Text);
                    this.toolStrip3.Enabled = false;
                    this.toolbtnSearchAll.Enabled = true;
                    return;

                }
                if (e.Node.Parent.Text == "保存地点")
                {
                    this.SearchByKeepPlace(e.Node.Text);
                    this.toolStrip3.Enabled = false;
                    this.toolbtnSearchAll.Enabled = true;
                    return;

                }
                if (e.Node.Parent.Text == "登记人")
                {
                    this.SearchByBooker(e.Node.Text);
                    this.toolStrip3.Enabled = false;
                    this.toolbtnSearchAll.Enabled = true;
                    return;

                }
            }
           
        }
        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolSearch_Click(object sender, EventArgs e)
        {
            if (this.CheckInput())
            {
                if (this.toolcbxSearchType. Text == "资产编号")
                {
                    this.SearchByEqno(this.tooltxtCondition.Text);
                    this.toolStrip3.Enabled = false;
                    this.toolbtnSearchAll.Enabled = true;
                    return;
                }
                if (this.toolcbxSearchType.Text == "资产类别")
                {
                    this.SearchByType(this.tooltxtCondition.Text);
                    this.toolStrip3.Enabled = false;
                    this.toolbtnSearchAll.Enabled = true;
                    return;
                }
                if (this.toolcbxSearchType.Text == "资产名称")
                {
                    this.SearchByName(this.tooltxtCondition.Text);
                    this.toolStrip3.Enabled = false;
                    this.toolbtnSearchAll.Enabled = true;
                    return;
 
                }
                if (this.toolcbxSearchType.Text == "增长方式")
                {
                    this.searchByAddtype(this.tooltxtCondition.Text);
                    this.toolStrip3.Enabled = false;
                    this.toolbtnSearchAll.Enabled = true;
                    return;

                }
                if (this.toolcbxSearchType.Text == "保存地点")
                {
                    this.SearchByKeepPlace(this.tooltxtCondition.Text);//5^1^a^s^p^x
                    this.toolStrip3.Enabled = false;
                    this.toolbtnSearchAll.Enabled = true;
                    return;

                }
                if (this.toolcbxSearchType.Text == "登记人")
                {
                    this.SearchByBooker(this.tooltxtCondition.Text);
                    this.toolStrip3.Enabled = false;
                    this.toolbtnSearchAll.Enabled = true;
                    return;

                }

            }    

        }
        /// <summary>
        /// 检查超找输入是否合法
        /// </summary>
        /// <returns></returns>
        private bool CheckInput()
        {
            if (toolcbxSearchType.Text.Trim() == "")
            {
                untCommon.InfoMsg("请选择查找条件类别。");
                return false;
            }
            if (tooltxtCondition.Text.Trim() == "")
            {
                untCommon.InfoMsg("请输入查找条件。");
                return false;

            }
            return true;
 
        }
        /// <summary>
        /// 按登记人查找
        /// </summary>
        public void SearchByBooker(string booker)
        {
            DataTable dt = EpMgr.GetInfobyBooker(booker);
            if (dt != null)
            {
                if (dt.Rows.Count != 0)
                {
                    this.dbgEq.DataSource = dt;
                }
                else
                {
                    untCommon.InfoMsg("没有您所要查找的记录。");
                }


            }
        }
        /// <summary>
        /// 按保存地点查找
        /// </summary>
        private void SearchByKeepPlace(string place)
        {
            DataTable dt = EpMgr.GetInfobyKeepplace(place);
            if (dt != null)
            {
                if (dt.Rows.Count != 0)
                {
                    this.dbgEq.DataSource = dt;
                }
                else
                {
                    untCommon.InfoMsg("没有您所要查找的记录。");
                }


            }
        }
        /// <summary>
        /// 按名称查找
        /// </summary>
        private void SearchByName(string name)
        {
            DataTable dt = EpMgr.GetInfobyName(name);
            if (dt != null)
            {
                if (dt.Rows.Count != 0)
                {
                    this.dbgEq.DataSource = dt;
                }
                else
                {
                    untCommon.InfoMsg("没有您所要查找的记录。");
                }


            }
        }
        /// <summary>
        /// 按增长方式查找
        /// </summary>
        private void searchByAddtype(string addtype)
        {
            DataTable dt = EpMgr.GetInfobyAddtype(addtype);
            if (dt != null)
            {
                if (dt.Rows.Count != 0)
                {
                    this.dbgEq.DataSource = dt;
                }
                else
                {
                    untCommon.InfoMsg("没有您所要查找的记录。");
                }


            }
        }
        /// <summary>
        /// 按资产类别查找
        /// </summary>
        private void SearchByType(string type)
        {
            DataTable dt = EpMgr.GetInfobyType(type);
            if (dt != null)
            {
                if (dt.Rows.Count != 0)
                {
                    this.dbgEq.DataSource = dt;
                }
                else
                {
                    untCommon.InfoMsg("没有您所要查找的记录。");
                }


            }
        }
        /// <summary>
        /// 按资产编号查找
        /// </summary>
        private void SearchByEqno(string eqno)
        {
            DataTable dt = EpMgr.GetInfobyEqno(eqno);
            if (dt != null)
            {
                if (dt.Rows.Count != 0)
                {
                    this.dbgEq.DataSource = dt;
                }
                else
                {
                    untCommon.InfoMsg("没有您所要查找的记录。");
                }


            }
 
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.statusInfo.Items[1].Text = DateTime.Now.ToString();
        }
        /// <summary>
        /// 初始化状态栏
        /// </summary>
        private void InitStatusInfo()
        {
            DataTable dt = ConpanyInfoMgr.GetInfo();
            if (dt != null)
            {
                this.statusInfo.Items[2].Text = dt.Rows[0][1].ToString();
                this.statusInfo.Items[3].Text = dt.Rows[0][3].ToString();
            }
            this.statusInfo.Items[0].Text = "当前系统操作员：" + this._user;
            this.timer.Start();

        }


        /// <summary>
        /// 进入资产更新界面
        /// </summary>
        private void UpdateEnter()
        {
            frmEqUpdate frupdate = new frmEqUpdate();
            if (this.dbgEq.Rows.Count == 0)
            {
                frupdate.ShowDialog();

            }
            else
            {
                frupdate.Eqno = this.dbgEq.SelectedRows[0].Cells[0].Value.ToString();
                frupdate.Keeper = this.dbgEq.SelectedRows[0].Cells[7].Value.ToString();

                if (frupdate.ShowDialog() == DialogResult.OK)
                {
                    this.DataRefresh();
                }
                
              
                
            }

        }
        /// <summary>
        /// 进入资产领用界面
        /// </summary>
        private void BoroowEnter()
        {
            if (this.dbgEq.Rows.Count == 0)
            {
                untCommon.InfoMsg("没有可供领用的资产。");
                return;
            }
            if (dbgEq.SelectedRows.Count == 0)
            {
                untCommon.InfoMsg("请在资产列表中选择所要领用的资产。");
                return;
            }
            
            string eqNo = this.dbgEq.SelectedRows[0].Cells[0].Value.ToString();
            frmBorrow boroow = new frmBorrow();

            //检查选中的资产是否可以借用
            int max = BoroowMgr.GetMaxBoroow(eqNo);
            if (max != -1)
            {
                boroow.Max = max;
                boroow.User = this._user;
                boroow.Eqno = eqNo;
                boroow.ShowDialog();
          

            }
            else
            {
                untCommon.InfoMsg("这笔资产已经被领用完了");
            }

        }
        /// <summary>
        /// 进入清理资产界面
        /// </summary>
        private void ClearEnter()
        {
            
            
            frmClear clear = new frmClear();
            //查选中的资产是否能够清理
            if (this.dbgEq.Rows.Count != 0)//资产列表中有数据
            {
                string eqno = this.dbgEq.SelectedRows[0].Cells[0].Value.ToString();
                int max = ClearMgr.GetMaxClear(eqno);
                //可以清理
                if (max != -1)
                {
                    clear.User = this._user;
                    clear.Max = max;
                    clear.Eqno=eqno;
                    clear.ShowDialog();
                    

                }
                else
                {
                    untCommon.InfoMsg("该笔资产目前全部都正在使用,不能清理。");
                }
            }
            else
            {
                untCommon.InfoMsg("没有资产可供清理。");
            }

        }
        /// <summary>
        /// 系统初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_Sys_Init_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("警告：数据初始化会造成数据丢失，您确定要初始化吗？？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (untCommon.QuestionMsg("在初始化之前请做好充分准备，是否要备份数据？"))
                {
                    frmBackup backup = new frmBackup();
                    backup.ShowDialog();
                    if (SysMgr.SysInit())
                    {

                        untCommon.InfoMsg("系统初始化成功。");
                    }
                    else
                    {

                        untCommon.InfoMsg("系统初始化失败。");
                    }


                }
                else
                {
                    if (SysMgr.SysInit())
                    {

                        untCommon.InfoMsg("系统初始化成功。");
                    }
                    else
                    {

                        untCommon.InfoMsg("系统初始化失败。");
                    }

                }
            }
        }
        /// <summary>
        /// 得到信息的总页数
        /// </summary>
        /// <returns></returns>
        private int getTotalPage()
        {
            int result = EpMgr.EqCount();
            int Total;
            if (result != 0)
            {
                int count = EpMgr.EqCount() % pageCount;
                if (count == 0)
                    Total = EpMgr.EqCount() / pageCount;
                else
                    Total = EpMgr.EqCount() / pageCount + 1;
            }
            else
                Total = 0;
            return Total;

        }
        /// <summary>
        /// 初始化资产表
        /// </summary>
        private void InitDbgEq()
        {
            curPage = 1;
            DataTable dat = EpMgr.getEqList(0, pageCount);
            if (dat != null)
            {
                this.dbgEqSet();

                //绑定数据

                dbgEq.DataSource = dat;
                dbgEq.ScrollBars = ScrollBars.Both;
            }
        }
        /// <summary>
        /// 设置资产编号这一列为链接形式
        /// </summary>
        private void dbgEqSet()
        {
            //
            DataGridViewLinkColumn colEqNo = new DataGridViewLinkColumn();
            colEqNo.MinimumWidth = 100;
            colEqNo.DataPropertyName = "资产编号";
            colEqNo.HeaderText = "资产编号";
            colEqNo.LinkBehavior = LinkBehavior.AlwaysUnderline;
            colEqNo.LinkBehavior = LinkBehavior.SystemDefault;
            colEqNo.Name = "资产编号";
            colEqNo.SortMode = DataGridViewColumnSortMode.Automatic;
            dbgEq.Columns.Add(colEqNo);
            colEqNo.Frozen = true;
            // 处理超级链接的 Click 事件。
            // 由于超级链接并没有事件，因此必须使用 DataGridView.CellContentClick 来处理之。
            // 事实上 DataGridViewLinkColumn 的运作模式非常类似于 DataGridViewButtonColumn，
            // 两者只是外观不同。
            dbgEq.CellContentClick += new DataGridViewCellEventHandler(colEqNo_CellContentClick);

        }
        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFirst_Click(object sender, EventArgs e)
        {

            curPage = 1;
            DataTable dat = EpMgr.getEqList(0, pageCount);
            if (dat != null)
            {


                //绑定数据

                dbgEq.DataSource = dat;
            }
            this.lblCurPage.Text = "第" + curPage.ToString() + "页";

        }
        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {


            if (curPage < TotalPage)
            {
                curPage++;
            }
            DataTable dat = EpMgr.getEqList((curPage - 1) * pageCount, pageCount);

            if (dat != null)
            {

                //绑定数据
                dbgEq.DataSource = dat;
            }
            this.lblCurPage.Text = "第" + curPage.ToString() + "页";


        }
        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (curPage > 1)
                curPage--;
            else
                curPage = 1;

            DataTable dat = EpMgr.getEqList((curPage - 1) * pageCount, pageCount);

            if (dat != null)
            {
                //绑定数据
                dbgEq.DataSource = dat;
            }
            this.lblCurPage.Text = "第" + curPage.ToString() + "页";


        }

        /// <summary>
        /// 尾页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLast_Click(object sender, EventArgs e)
        {
            curPage = TotalPage;

            DataTable dat = EpMgr.getEqList((curPage - 1) * pageCount, pageCount);

            if (dat != null)
            {


                //绑定数据

                dbgEq.DataSource = dat;
            }
            this.lblCurPage.Text = "第" + curPage.ToString() + "页";


        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnRefresh_Click(object sender, EventArgs e)
        {
            this.DataRefresh();


        }
        /// <summary>
        /// 查询所有信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnSearchAll_Click(object sender, EventArgs e)
        {
            curPage = 1;
            DataTable dat = EpMgr.getEqList(0, pageCount);
            if (dat != null)
            {
                //绑定数据
                dbgEq.DataSource = dat;
                this.toolStrip3.Enabled = true;
            }
        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        private void DataRefresh()
        {
            DataTable dat = EpMgr.getEqList((curPage - 1) * pageCount, pageCount);

            if (dat != null)
            {
                TotalPage = this.getTotalPage();//得到数据的总页数

                //绑定数据
                dbgEq.DataSource = dat;
            }
            this.lblTotalpage.Text = "共" + TotalPage.ToString() + "页";
            this.lblCurPage.Text = "第" + curPage.ToString() + "页";
        }
        /// <summary>
        /// 查询指定页数的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (txtPage.Text.Trim() == "")
            {
                untCommon.InfoMsg("请输入所要查询的页数。");
                return;
            }
            try
            {
                curPage = int.Parse(this.txtPage.Text);
            }
            catch (FormatException)
            {
                untCommon.InfoMsg("所要查询的页数请输入数字。");
                return;
            }
            if (curPage > TotalPage || curPage < 1)
            {
                untCommon.InfoMsg("没有您所要查询的页数。");
                return;
            }

            DataTable dat = EpMgr.getEqList((curPage - 1) * pageCount, pageCount);

            if (dat != null)
            {


                //绑定数据

                dbgEq.DataSource = dat;
            }
            this.lblCurPage.Text = "第" + curPage.ToString() + "页";

        }
        /// <summary>
        /// 设置菜单的所有子项是否可见
        /// </summary>
        /// <param name="visibled">true：可见;false：不可见</param>
        private void isVisibleAllMenu(bool visibled)
        {
            for (int i = 0; i < this.menuEqMgr.Items.Count; i++)
            {
                for (int j = 0; j < ((ToolStripMenuItem)menuEqMgr.Items[i]).DropDownItems.Count; j++)
                {
                    if (((ToolStripMenuItem)menuEqMgr.Items[i]).DropDownItems[j].Tag != null)
                    {
                        //分隔符可见
                        if (((ToolStripMenuItem)menuEqMgr.Items[i]).DropDownItems[j].Tag.ToString() == "s")
                        {
                            continue;

                        }

                    }
                    else
                    {
                        if (((ToolStripMenuItem)menuEqMgr.Items[i]).DropDownItems[j].Text == "系统退出" || ((ToolStripMenuItem)menuEqMgr.Items[i]).DropDownItems[j].Text == "系统注销")
                        {
                            continue;
                        }
                        else
                        {
                            ToolStripMenuItem subitem = (ToolStripMenuItem)menuEqMgr.Items[i];
                            subitem.DropDownItems[j].Visible = visibled;
                        }
                    }
                }

            }
        }


        /// <summary>
        /// 根据用户来初使化系统菜单
        /// </summary>
        private void initMenu()
        {

            if (MenuList != null)
            {
                this.isVisibleAllMenu(false); //将所有子菜单全部初使化为不可见

                for (int i = 0; i < menuEqMgr.Items.Count; i++)
                {
                    for (int j = 0; j < ((ToolStripMenuItem)menuEqMgr.Items[i]).DropDownItems.Count; j++)
                    {
                        ToolStripMenuItem subitem = (ToolStripMenuItem)menuEqMgr.Items[i];
                        for (int index = 0; index < MenuList.Count; index++)
                        {
                            if (subitem.DropDownItems[j].Name == MenuList[index].ToString())
                            {
                                subitem.DropDownItems[j].Visible = true;
                                break;
                            }


                        }


                    }

                }


            }

        }


        /// <summary>
        /// 设置工具栏的像是否可见
        /// </summary>
        /// <param name="visibled">true：可见;false：不可见</param>
        private void isVisibleAllToolBar(bool visibled)
        {
            for (int i = 0; i < toolMgr.Items.Count; i++)
            {
                if (toolMgr.Items[i].Tag != null)
                {
                    //分隔符可见
                    if (toolMgr.Items[i].Text == "系统退出" || toolMgr.Items[i].Text == "系统注销" || toolMgr.Items[i].Tag.ToString() == "s")
                        continue;
                    else
                        toolMgr.Items[i].Visible = visibled;
                }


            }
        }
        /// <summary>
        /// 初始化资产管理的工具栏
        /// </summary>
        private void initToolBar()
        {
            isVisibleAllToolBar(false);

            // ArrayList MenuList = SysUserMgr.GetPower(this._loginname);
            for (int i = 0; i < toolMgr.Items.Count; i++)
            {

                for (int index = 0; index < MenuList.Count; index++)
                {
                    if (toolMgr.Items[i].Tag != null)
                    {
                        if (toolMgr.Items[i].Tag.ToString() == MenuList[index].ToString())
                        {
                            toolMgr.Items[i].Visible = true;

                        }
                    }
                }

            }
        }


        private void menu_EqMgr_BaseInfo_Click(object sender, EventArgs e)
        {
            frmBaseInfo fb = new frmBaseInfo();
            fb.ShowDialog();
        }

        private void menu_Emp_depart_Click(object sender, EventArgs e)
        {
            frmDepart fd = new frmDepart();
            fd.ShowDialog();
        }

        private void meun_emp_emp_Click(object sender, EventArgs e)
        {
            frmEmployee fe = new frmEmployee();
            fe.ShowDialog();
        }

        private void Menu_Eq_Add_Click(object sender, EventArgs e)
        {
            frmEqAdd frmadd = new frmEqAdd();
            frmadd.Booker = this._user;
            if (frmadd.ShowDialog() == DialogResult.Cancel)
            {
                this.DataRefresh();
            }
        }

        private void Menu_BaseInfo_Keeper_Click(object sender, EventArgs e)
        {
            frmKeeper fk = new frmKeeper();
            fk.ShowDialog();
        }

        private void Menu_Eq_Update_Click(object sender, EventArgs e)
        {
            this.UpdateEnter();
           

        }
       
        private void Menu_Eq_Boroow_Click(object sender, EventArgs e)
        {
            this.BoroowEnter();
 
        }
        
        private void Menu_Eq_Clear_Click(object sender, EventArgs e)
        {
            this.ClearEnter();
            
            
        }
        

        private void Menu_Eq_Return_Click(object sender, EventArgs e)
        {
            frmReturn frmreturn = new frmReturn();
            frmreturn.txtbooker.Text = this._user;
            frmreturn.ShowDialog();
        }

        private void Menu_Eq_BorrowLook_Click(object sender, EventArgs e)
        {
            frmBorrowLook fbl = new frmBorrowLook();
            fbl.User = this._user;
            fbl.ShowDialog();
            
        }

        private void Menu_MyInfo_Click(object sender, EventArgs e)
        {
            frmConpanyInfo fc = new frmConpanyInfo();
            fc.ShowDialog();
        }

        private void Menu_Eq_ClearLook_Click(object sender, EventArgs e)
        {
            frmClearLook fcl = new frmClearLook();
            fcl.ShowDialog();
        }

        private void Menu_Data_backup_Click(object sender, EventArgs e)
        {
            frmBackup backup = new frmBackup();
            backup.ShowDialog();
        }
        
       

       

        private void toolbtnBaiseInfo_Click(object sender, EventArgs e)
        {
            frmBaseInfo fb = new frmBaseInfo();
            fb.ShowDialog();

        }

        private void toolEqAdd_Click(object sender, EventArgs e)
        {
            frmEqAdd frmadd = new frmEqAdd();
            frmadd.Booker = this._user;
            if (frmadd.ShowDialog() == DialogResult.Cancel)
            {
                this.DataRefresh();
            }

        }

        private void toolEqClear_Click(object sender, EventArgs e)
        {
            this.ClearEnter();

        }

        private void toolEqBorrow_Click(object sender, EventArgs e)
        {
            this.BoroowEnter();
        }

        private void toolbtnReturn_Click(object sender, EventArgs e)
        {
            frmReturn fr = new frmReturn();
            fr.txtbooker.Text = this._user;
            fr.ShowDialog();
        }

        private void Menu_Eq_Sata_Click(object sender, EventArgs e)
        {
            frmStat fs = new frmStat();
            fs.ShowDialog();
        }

        private void Menu_Sys_UserAdd_Click(object sender, EventArgs e)
        {
            frmsysUser user = new frmsysUser();
            user.LoginName = this._loginname;
            user.ShowDialog();
        }

        private void Menu_Sys_Update_Click(object sender, EventArgs e)
        {
            frmUpdateSysUserInfo update = new frmUpdateSysUserInfo();
            update.LoginName = this._loginname;
            update.Names = this._user;
           
            update.ShowDialog();
        }
        /// <summary>
        /// 启动记事本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_Tool_Notepad_Click(object sender, EventArgs e)
        {
            Process.Start("notepad.exe");
            
        }
        /// <summary>
        /// 启动计算器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_Tool_Calc_Click(object sender, EventArgs e)
        {
            Process.Start("calc.exe");
        }
        /// <summary>
        /// 退出系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_Sys_Exit_Click(object sender, EventArgs e)
        {
            if (untCommon.QuestionMsg("您确定要退出系统？"))
            {
                Application.Exit();
            }
        }
        /// <summary>
        /// 系统注销
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_Sys_AppRestart_Click(object sender, EventArgs e)
        {
            if (untCommon.QuestionMsg("您确定要注销系统？"))
            {
                Application.Restart();
            }
        }

        private void toolbtnAppRestat_Click(object sender, EventArgs e)
        {
            if (untCommon.QuestionMsg("您确定要注销系统？"))
            {
                Application.Restart();
            }
        }

        private void toolbtnExit_Click(object sender, EventArgs e)
        {
            if (untCommon.QuestionMsg("您确定要退出系统？"))
            {
                Application.Exit();
            }
        }

        private void toolbtnSata_Click(object sender, EventArgs e)
        {

            frmStat fs = new frmStat();
            fs.ShowDialog();

        }

        private void Menu_Eq_ReturnLook_Click(object sender, EventArgs e)
        {
            frmReturnLook frl = new frmReturnLook();
            frl.ShowDialog();
        }
        /// <summary>
        /// 将查询出的结果导出为Exel表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnExel_Click(object sender, EventArgs e)
        {
            untCommon.ToExel(this.dbgEq);
        }


        private void Menu_Sy_PowerSet_Click(object sender, EventArgs e)
        {
            frmPowerSet power = new frmPowerSet();
            power.LoginName = this._loginname;
            power.ShowDialog();
        }

        private void Menu_Mot_View_Click(object sender, EventArgs e)
        {
            frmMonitor fr = new frmMonitor();
            fr.ShowDialog();
        }

        private void Menu_Mot_Add_Click(object sender, EventArgs e)
        {
            frmMonitorAdd fr = new frmMonitorAdd();
            fr.ShowDialog();
        }

       

        private void Menu_Red_View_Click(object sender, EventArgs e)
        {
            frmRecord fr = new frmRecord();
            fr.ShowDialog();
        }

        private void Menu_Red_ToDo_Click(object sender, EventArgs e)
        {
            frmRecordToDo fr = new frmRecordToDo();
            fr.User = _user;
            fr.ShowDialog();
        }

        
        
    }
}