using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;
using DataBusiness;
using DataEntity;
using System.IO;
using RedrawControl;

namespace Equipment_Manager
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
           
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        private static int curPage = 1;  //当前页
        private static int TotalPage = 0; //总页数
        private static int pageCount = 30; //第页条数
        private Dictionary<string, ZCGridColumnSortButton> sortButtons = new Dictionary<string, ZCGridColumnSortButton>();
        private static List<string> AvailableColumns = new List<string>();
        private static List<string> SelectedColumns = new List<string>();
        private bool query_flag = false;
        public Dictionary<String, String> SortsString = new Dictionary<string, string>();
        public ZCGridSortForm frmSort;
        public string[] OrderByString = new string[1];
       
        private string _user;
        private string _loginid;
        private string _departId;
        private string _power;

        ArrayList MenuList = null;
      

        public string LoginID
        {
            set
            {
                this._loginid = value;
            }
            
        }
        
        public string User
        {
            set
            {
                this._user = value;
 
            }
            
           
        }

        public string DepartId
        {
            set
            {
                this._departId = value;

            }


        }

        public string Power
        {
            set
            {
                this._power = value;

            }


        }

        
        
        /// <summary>
        /// 资产编码点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">dbg</param>
        private void colEqNo_CellContentClick(Object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = (DataGridView)(sender);
            // 确认是否确实是在“资产编码”数据列当中的超级链接上按一下。
            if (e.RowIndex >= 0 && e.ColumnIndex == grid.Columns["资产编码"].Index)
            {
                List<string> EqnoList = new List<string>();
                EqnoList.Add(this.dbgEq.SelectedRows[0].Cells[0].Value.ToString());
                this.UpdateEnter(EqnoList);

            }
        }

        
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.MenuList = SysUserMgr.GetPower(_loginid);//得到登录用户的权限（可执行的操作）
            this.initMenu();//加载菜单
            this.initToolBar();//加载资产管理的工具栏
            this.InitDbgEq();//加载资产表

            this.BuilTree();//加载树
            this.tvwEqSeach.Nodes[0].Expand();//展开树的第一层节点

            this.InitStatusInfo();//加载状态栏
            TotalPage = this.getTotalPage();//得到数据的总页数
            this.lblTotalpage.Text = "共"+TotalPage.ToString()+"页";

           

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


            this.BuildState(nodeAll);//加载状态列表
            this.BuildType(nodeAll);//加载资产类别列表
            this.BuildDepart(nodeAll);//加载资产名称列表
            this.BuildKeepPlace(nodeAll);//加载保存地点列表
            this.BuildAddType(nodeAll);//加载增长方式列表
            
        }

        /// <summary>
        /// 构造状态节点
        /// </summary>
        /// <param name="parent">父节点</param>
        private void BuildState(TreeNode parent)
        {
            TreeNode State = new TreeNode();
            this.AddNode(State, "资产状态", 11, parent);
            TreeNode StateIn = new TreeNode();
            TreeNode StateBorrow = new TreeNode();
            TreeNode StateFix = new TreeNode();
            TreeNode StateClear = new TreeNode();
            
            this.AddNode(StateIn, "入库", 2, State);
            this.AddNode(StateBorrow, "借出", 2, State);
            this.AddNode(StateFix, "维修", 2, State);
            this.AddNode(StateClear, "注销", 2, State);


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
        /// 构造使用部门节点
        /// </summary>
        /// <param name="parent">父节点</param>
        private void BuildDepart(TreeNode parent)
        {
            TreeNode Name = new TreeNode();
            this.AddNode(Name, "使用部门",5, parent);
            DataTable dt = DepartMgr.GetAll();
            
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
                        this.AddNode(type, dt.Rows[i][0].ToString(),2, Type);

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
                if (e.Node.Parent.Text == "资产编码")
                {
                    this.SearchByEqno(e.Node.Text);
                    this.toolStrip3.Enabled = false;
                    this.toolbtnSearchAll.Enabled = true;
                    return;
 
                }
                if (e.Node.Parent.Text == "资产状态")
                {
                    this.SearchByState(e.Node.Text);
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
                if (e.Node.Parent.Text == "使用部门")
                {
                    this.SearchByDepart(e.Node.Text);
                    this.toolStrip3.Enabled = false;
                    this.toolbtnSearchAll.Enabled = true;
                    return;

                }
                if (e.Node.Parent.Text == "增长方式")
                {
                    this.searchByGetWay(e.Node.Text);
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
                if (e.Node.Parent.Text == "经办人")
                {
                    this.SearchByAgent(e.Node.Text);
                    this.toolStrip3.Enabled = false;
                    this.toolbtnSearchAll.Enabled = true;
                    return;

                }
            }
           
        }


        /// <summary>
        /// 按经办人查找
        /// </summary>
        public void SearchByAgent(string agent)
        {
            DataTable dt = EqMgr.GetInfobyFactor("经办人",agent,this._departId,this._power);
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
        /// 按存放地点查找
        /// </summary>
        private void SearchByKeepPlace(string place)
        {
            DataTable dt = EqMgr.GetInfobyFactor("存放地点", place, this._departId, this._power);
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
        /// 按使用部门查找
        /// </summary>
        private void SearchByDepart(string depart)
        {
            DataTable dt = EqMgr.GetInfobyFactor("使用部门", depart, this._departId, this._power);
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
        private void searchByGetWay(string getway)
        {
            DataTable dt = EqMgr.GetInfobyFactor("取得方式", getway, this._departId, this._power);
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
        /// 按资产状态查询
        /// </summary>
        /// <param name="state"></param>
        private void SearchByState(string state)
        {
            DataTable dt = EqMgr.GetInfobyFactor("状态", state, this._departId, this._power);
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
            DataTable dt = EqMgr.GetInfobyFactor("资产类别", type, this._departId, this._power);
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
        /// 按资产编码查找
        /// </summary>
        private void SearchByEqno(string eqno)
        {
            DataTable dt = EqMgr.GetInfobyFactor("资产编码", eqno, this._departId, this._power);
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
            DataTable dt = CompanyInfoMgr.GetInfo();

            if (dt != null)
            {
                this.statusInfo.Items[2].Text = dt.Rows[0][1].ToString() + DepartMgr.GetNameFromId(this._departId);
                this.statusInfo.Items[3].Text = dt.Rows[0][3].ToString();
            }
            
            this.statusInfo.Items[0].Text = "操作员：" +this._loginid+"  " +this._user;
            this.timer.Start();

        }


        /// <summary>
        /// 进入资产更新界面
        /// </summary>
        private void UpdateEnter(List<string> EqnoList)
        {
            
            frmEqUpdate frupdate = new frmEqUpdate(this._user, EqnoList,this._power,1);
            frupdate.Loginid = this._loginid;
            if (frupdate.ShowDialog() == DialogResult.OK)
            {
                this.DataRefresh();
            }
        }

        /// <summary>
        /// 批量修改资产
        /// </summary>
        /// <param name="AssetNo"></param>
        private void UpdateAssetEnter(string AssetNo)
        {
            frmEqUpdate frupdate = new frmEqUpdate(this._user, AssetNo, this._power, 2);
            frupdate.Loginid = this._loginid;
            if (frupdate.ShowDialog() == DialogResult.OK)
            {
                this.DataRefresh();
            }
        }
        /// <summary>
        /// 进入资产领用界面
        /// </summary>
        private void BoroowEnter()
        {
            if (IsEqAvailable())
            {
                frmBorrow boroow = new frmBorrow();
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
                boroow.Eqno = eqNo;
                boroow.User = this._user;
                boroow.Power = this._power;
                if (boroow.ShowDialog() == DialogResult.OK)
                {
                    DataRefreshBySQL();
                }
            }
            else
            {
                untCommon.InfoMsg("该资产不允许该操作。");
            }

        }


        /// <summary>
        /// 进入资产归还或是维修完成界面，视状态而定
        /// </summary>
        private void ReturnEnter()
        {
            DataRow dr = (dbgEq.Rows[dbgEq.CurrentRow.Index].DataBoundItem as DataRowView).Row;
            string eqno = dr.ItemArray[0].ToString();
            string ID;
            string state = dr.ItemArray[59].ToString();
            switch (state)
            {
                case "借出":
                    ID = BoroowMgr.GetIDFromEqNo(eqno);
                    if (BoroowMgr.GetStateFromSerialNo(ID).Equals("已借出"))
                    {
                        frmBorrowReturn eqBReturn = new frmBorrowReturn();
                        eqBReturn.User = this._user;
                        eqBReturn.Power = this._power;
                        eqBReturn.ID = ID;
                        eqBReturn.ShowDialog();
                    }
                    else
                        untCommon.InfoMsg("无法进行该操作。");
                    break;
                case "维修":
                    ID = FixMgr.GetIDFromEqNo(eqno);
                    if (FixMgr.GetStateFromSerialNo(ID).Equals("维修中"))
                    {
                        frmFixReturn eqFReturn = new frmFixReturn();
                        eqFReturn.User = this._user;
                        eqFReturn.Power = this._power;
                        eqFReturn.ID = ID;
                        eqFReturn.ShowDialog();
                    }
                    else
                        untCommon.InfoMsg("无法进行该操作。");
                    break;
                default:
                    untCommon.InfoMsg("无法进行该操作。");
                    break;
            }
        }
        /// <summary>
        /// 进入清理资产界面
        /// </summary>
        private void ClearEnter()
        {
            if (IsEqAvailable())
            {
                frmClear clear = new frmClear();
                //查选中的资产是否能够清理
                if (this.dbgEq.Rows.Count != 0)//资产列表中有数据
                {
                    string eqno = this.dbgEq.SelectedRows[0].Cells[0].Value.ToString();
                    //可以清理
                    clear.User = this._user;
                    clear.Power = this._power;
                    clear.Eqno = eqno;
                    if (clear.ShowDialog() == DialogResult.OK)
                    {
                        DataRefreshBySQL();
                    }

                }
                else
                {
                    untCommon.InfoMsg("没有资产可供清理。");
                }
            }
            else
            {
                untCommon.InfoMsg("该资产不允许该操作。");
            }

        }
        /// <summary>
        /// 进入维修资产界面
        /// </summary>
        private void FixEnter()
        {
            if (IsEqAvailable())
            {

                frmFix fix = new frmFix();
                //查选中的资产是否能够清理
                if (this.dbgEq.Rows.Count != 0)//资产列表中有数据
                {
                    string eqno = this.dbgEq.SelectedRows[0].Cells[0].Value.ToString();
                    fix.User = this._user;
                    fix.Power = this._power;
                    fix.Eqno = eqno;
                    if (fix.ShowDialog() == DialogResult.OK)
                    {
                        DataRefreshBySQL();
                    }

                }
                else
                {
                    untCommon.InfoMsg("没有资产可供维修。");
                }
            }
            else
            {
                untCommon.InfoMsg("该资产不允许该操作。");
            }

        }
        /// <summary>
        /// 进入资产领用界面
        /// </summary>
        private bool IsEqAvailable()
        {
            string eqno = this.dbgEq.SelectedRows[0].Cells[0].Value.ToString();
            DataTable dt = EqMgr.GetOneEqViewInfo(eqno);
            if (dt != null)
            {
                string status = dt.Rows[0]["状态"].ToString();
                if (status.Equals("入库"))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        /// <summary>
        /// 进入提醒维护窗口
        /// </summary>
        private void RemindEnter()
        {
            frmAudit dlg = new frmAudit(_user, _loginid, _departId, _power);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                DataRefreshBySQL();
            }
        }

        /// <summary>
        /// 进入导出全部资产
        /// </summary>
        private void AllExcel()
        {
            DataTable dt = EqMgr.getAllEq(this._departId, this._power);
            ExportToExcel(dt, "全部资产信息");
        }

        /// <summary>
        /// 进入导出当前资产表格
        /// </summary>
        private void CurrentExcel()
        {
            DataTable dt = DgvMgr.GetTable(this.dbgEq);
            ExportToExcel(dt, "当前资产信息");
        }

        /// <summary>
        /// 进入导出选中资产表格
        /// </summary>
        private void SelectedExcel()
        {
            DataTable dt = DgvMgr.GetSelectedTable(this.dbgEq);
            ExportToExcel(dt, "选中资产表格");
            
        }

        private void AllExcelInType()
        {
            DataTable dtsource = EqMgr.getAllEq(_departId, _power);
            //总表里没有数量这一栏
            dtsource.Columns.Add("数量");

            List<string> list = EqTypeMgr.GetEqTypes(dtsource);
            List<DataTable> dts = new List<DataTable> { null };
            List<string> headers;

            //只能从循环外先给第一个位赋值。原因我忘记了，总之会出错
            headers = EqTypeMgr.GetHeader(list[0]);
            dts[0] = DgvMgr.GetTable(dtsource, headers, list[0].ToString());

            for (int i = 1; i < list.Count; i++)
            {
                headers = EqTypeMgr.GetHeader(list[i]);
                dts.Add(DgvMgr.GetTable(dtsource, headers, list[i].ToString()));
            }
            ExportToExcelInType(dts, list);
        }

        /// <summary>
        /// 进入按类型导出当前表格
        /// </summary>
        private void CurrentExcelInType()
        {
            List<string> list = EqTypeMgr.GetEqTypes(this.dbgEq);
            List<DataTable> dts = new List<DataTable> { null };
            List<string> headers;

            //只能从循环外先给第一个位赋值。原因我忘记了，总之会出错
            headers = EqTypeMgr.GetHeader(list[0]);
            dts[0] = DgvMgr.GetTable(this.dbgEq, headers, list[0].ToString());

            for (int i = 1; i < list.Count; i++)
            {
                headers = EqTypeMgr.GetHeader(list[i]);
                dts.Add(DgvMgr.GetTable(this.dbgEq, headers, list[i].ToString()));                
            }
            ExportToExcelInType(dts, list);
        }

        /// <summary>
        /// 进入按类型导出所选表格
        /// </summary>
        private void ScExcelInType()
        {
            List<string> list = EqTypeMgr.GetScEqTypes(this.dbgEq);
            List<DataTable> dts = new List<DataTable> { null };
            List<string> headers = new List<string> { null};

            //只能从循环外先给第一个位赋值
            headers = EqTypeMgr.GetHeader(list[0]);
            dts[0] = DgvMgr.GetSelectedTable(this.dbgEq, headers, list[0].ToString());

            for (int i = 1; i < list.Count; i++)
            {
                headers = EqTypeMgr.GetHeader(list[i]);
                dts.Add(DgvMgr.GetSelectedTable(this.dbgEq, headers, list[i].ToString()));
            }
            ExportToExcelInType(dts, list);
        }

        

        /// <summary>
        /// 系统初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_Sys_Init_Click(object sender, EventArgs e)
        {
            //只有超级用户可以执行
            if (this._power != "0")
                return;

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
            int result = EqMgr.EqCount();
            int Total;
            if (result != 0)
            {
                int count = EqMgr.EqCount() % pageCount;
                if (count == 0)
                    Total = EqMgr.EqCount() / pageCount;
                else
                    Total = EqMgr.EqCount() / pageCount + 1;
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
            DataTable dat = EqMgr.getEqList(0, pageCount, _departId, _power);
            if (dat != null)
            {
                this.dbgEqSet();
                

                //绑定数据

                dbgEq.DataSource = dat.DefaultView;
                AvailableColumns.Clear();
                foreach (DataGridViewColumn c in dbgEq.Columns)
                {
                    if (!c.Visible) continue;
                    AvailableColumns.Add(c.HeaderText);
                    SelectedColumns.Add(c.HeaderText);
                }
                dbgEq.ScrollBars = ScrollBars.Both;
                this.dbgFrozen();

            }
        }
        /// <summary>
        /// 设置资产编码这一列为链接形式
        /// </summary>
        private void dbgEqSet()
        {
            //
            DataGridViewLinkColumn colEqNo = new DataGridViewLinkColumn();
            colEqNo.MinimumWidth = 100;
            colEqNo.DataPropertyName = "资产编码";
            colEqNo.HeaderText = "资产编码";
            colEqNo.LinkBehavior = LinkBehavior.AlwaysUnderline;
            colEqNo.LinkBehavior = LinkBehavior.SystemDefault;
            colEqNo.Name = "资产编码";
            colEqNo.SortMode = DataGridViewColumnSortMode.Automatic;
            dbgEq.Columns.Add(colEqNo);
            
            // 处理超级链接的 Click 事件。
            // 由于超级链接并没有事件，因此必须使用 DataGridView.CellContentClick 来处理之。
            // 事实上 DataGridViewLinkColumn 的运作模式非常类似于 DataGridViewButtonColumn，
            // 两者只是外观不同。

            
            dbgEq.CellContentClick += new DataGridViewCellEventHandler(colEqNo_CellContentClick);
           
        }

        /// <summary>
        /// 冻结前两列
        /// </summary>
        private void dbgFrozen()
        {
            this.dbgEq.Columns[1].Frozen = true;//第二列前的列都被冻结
        }
        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFirst_Click(object sender, EventArgs e)
        {

            curPage = 1;
            DataTable dat = EqMgr.getEqList(0, pageCount, _departId, _power);
            if (dat != null)
            {


                //绑定数据

                dbgEq.DataSource = dat.DefaultView;
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
            DataTable dat = EqMgr.getEqList((curPage - 1) * pageCount, pageCount, _departId, _power);

            if (dat != null)
            {

                //绑定数据
                dbgEq.DataSource = dat.DefaultView;
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

            DataTable dat = EqMgr.getEqList((curPage - 1) * pageCount, pageCount, _departId, _power);

            if (dat != null)
            {
                //绑定数据
                dbgEq.DataSource = dat.DefaultView;
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

            DataTable dat = EqMgr.getEqList((curPage - 1) * pageCount, pageCount, _departId, _power);

            if (dat != null)
            {


                //绑定数据

                dbgEq.DataSource = dat.DefaultView;
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
            if (!query_flag)
                DataRefreshBySQL();
            else
                DataRefreshBySQLSort();              
        }
        /// <summary>
        /// 查询所有信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnSearchAll_Click(object sender, EventArgs e)
        {
            this.DataRefresh();
            this.toolStrip3.Enabled = true;
            AvailableColumns.Clear();
            foreach (DataGridViewColumn c in dbgEq.Columns)
            {
                if (!c.Visible) continue;
                AvailableColumns.Add(c.HeaderText);
                SelectedColumns.Add(c.HeaderText);
            }
        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        private void DataRefresh()
        {
            DataTable dat = EqMgr.getEqList((curPage - 1) * pageCount, pageCount, _departId, _power);

            if (dat != null)
            {
                TotalPage = this.getTotalPage();//得到数据的总页数

                //绑定数据
                dbgEq.DataSource = dat.DefaultView;
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

            DataTable dat = EqMgr.getEqList((curPage - 1) * pageCount, pageCount, _departId, _power);

            if (dat != null)
            {


                //绑定数据

                dbgEq.DataSource = dat.DefaultView;
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

       
        /// <summary>
        /// 导出电子表格
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="ExcelName"></param>
        private void ExportToExcel(DataTable dt,string ExcelName)
        {
            string filePath = string.Empty;
            string nowTime = DateTime.Now.ToString("yyyyMMddHHmmss");//获取当前时间作为文件名的一部分
            FolderBrowserDialog BrowDialog = new FolderBrowserDialog();
            BrowDialog.ShowNewFolderButton = true;
            BrowDialog.Description = "请选择电子表格保存位置";

            if (BrowDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = BrowDialog.SelectedPath;//这个就是点击选择文件夹的路径
                filePath = filePath + "\\"+ExcelName + nowTime + ".xlsx";
                if (ExcelMgr.ExportExcel(dt, filePath))
                {
                    untCommon.InfoMsg("导出成功");
                }
                else
                {
                    untCommon.InfoMsg("导出失败");
                }
            }
        }

        /// <summary>
        /// 按类别导出电子表格
        /// </summary>
        /// <param name="dts">DataTable列表</param>
        /// <param name="ExcelNames">电子表格名称数组</param>
        private void ExportToExcelInType(List<DataTable> dts, List<string> ExcelNames)
        {
            string filePath = string.Empty;
            string nowTime = DateTime.Now.ToString("yyyyMMddHHmmss");//获取当前时间作为文件名的一部分
            FolderBrowserDialog BrowDialog = new FolderBrowserDialog();
            BrowDialog.ShowNewFolderButton = true;
            BrowDialog.Description = "请选择电子表格保存位置";
            if (BrowDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = BrowDialog.SelectedPath; //这个就是点击选择文件夹的路径
                
                DirectoryInfo dir = new DirectoryInfo(filePath);
                dir.CreateSubdirectory("按资产类别导出"+nowTime);
                filePath = filePath + "\\" + "按资产类别导出" + nowTime;
                for (int i = 0; i < ExcelNames.Count; i++)
                {
                    if (ExcelMgr.ExportExcel(dts[i],(filePath+"\\"+ExcelNames[i]+".xlsx")))
                    {
                        untCommon.InfoMsg("导出"+  ExcelNames[i] +"成功");
                    }
                    else
                    {
                        untCommon.InfoMsg("导出" + ExcelNames[i] + "失败");
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
            frmadd.Sysuser = this._user;
            frmadd.Loginid = this._loginid;
            frmadd.Power = this._power;
            if (frmadd.ShowDialog() == DialogResult.Cancel)
            {
                this.DataRefresh();
            }
        }

        private void Menu_BaseInfo_Keeper_Click(object sender, EventArgs e)
        {
            frmKeepPlace fk = new frmKeepPlace();
            fk.ShowDialog();
        }

        private void Menu_Eq_Update_Click(object sender, EventArgs e)
        {
            List<string> EqnoList = new List<string>();
            List<string> assertList = new List<string>();
            string assert;
            for (int i = 0; i < dbgEq.SelectedRows.Count; i++)
            {
                DataRow dr = (dbgEq.SelectedRows[i].DataBoundItem as DataRowView).Row;
                EqnoList.Add(dr.ItemArray[0].ToString());
                assertList.Add(dr.ItemArray[3].ToString());
            }
            assert = assertList[0];
            bool flag = true;
            foreach (string str in assertList)
            {
                if (!assert.Equals(str))
                    flag = false;
            }
            if (flag)
                this.UpdateEnter(EqnoList);
            else
                untCommon.InfoMsg("选中数据不能同时修改");
           

        }

        private void Menu_Eq_Update_AssetNo_Click(object sender, EventArgs e)
        {
            string AssetNo = this.dbgEq.SelectedRows[0].Cells["单号"].Value.ToString();
            this.UpdateAssetEnter(AssetNo);
        }
       
        private void Menu_Eq_Boroow_Click(object sender, EventArgs e)
        {
            this.BoroowEnter();
 
        }
        
        private void Menu_Eq_Clear_Click(object sender, EventArgs e)
        {
            this.ClearEnter();
            
            
        }
        

        private void Menu_Eq_Fix_Click(object sender, EventArgs e)
        {
            this.FixEnter();
        }

        private void Menu_Eq_BorrowLook_Click(object sender, EventArgs e)
        {
            frmBorrowLook fbl = new frmBorrowLook();
            fbl.Power = this._power;
            fbl.DepartId = this._departId;
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
            fcl.Power = this._power;
            fcl.DepartId = this._departId;
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
            frmadd.Sysuser = this._user;
            frmadd.Loginid = this._loginid;
            frmadd.Power = this._power;
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

        private void toolbtnFix_Click(object sender, EventArgs e)
        {
            this.FixEnter();
        }

        private void Menu_Eq_Import_Click(object sender, EventArgs e)
        {
            frmImport fimport = new frmImport();
            fimport.ShowDialog();
            if (fimport.DialogResult == DialogResult.OK)
            {
                this.Refresh();
            }
        }

        private void Menu_Sys_UserAdd_Click(object sender, EventArgs e)
        {
            frmsysUser user = new frmsysUser();
            user.LoginId = this._loginid;
            user.ShowDialog();
        }

        private void Menu_Sys_Update_Click(object sender, EventArgs e)
        {
            frmUpdateSysUserInfo update = new frmUpdateSysUserInfo(this._loginid, false);
           
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

        private void toolbtnImport_Click(object sender, EventArgs e)
        {

            frmImport frimport = new frmImport();
            frimport.ShowDialog();

        }

        private void Menu_Eq_FixLook_Click(object sender, EventArgs e)
        {
            frmFixLook frl = new frmFixLook();
            frl.Power = this._power;
            frl.DepartId = this._departId;
            frl.ShowDialog();
        }
        /// <summary>
        /// 将查询出的结果导出为Exel表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnExel_Click(object sender, EventArgs e)
        {
            CurrentExcel();       
        }


        private void Menu_Sy_PowerSet_Click(object sender, EventArgs e)
        {
            frmPowerSet powerset = new frmPowerSet();
            powerset.LoginId = this._loginid;
            powerset.ShowDialog();
        }

        private void Menu_Excel_All_Click(object sender, EventArgs e)
        {
            AllExcel();
        }   


        private void Menu_Excel_Current_Click(object sender, EventArgs e)
        {
            CurrentExcel();
        }

        private void Menu_Excel_Selected_Click(object sender, EventArgs e)
        {
            SelectedExcel();
        }

        private void Menu_Excel_AType_Click(object sender, EventArgs e)
        {
            AllExcelInType();
        }

        private void Menu_Excel_CType_Click(object sender, EventArgs e)
        {
            CurrentExcelInType();
        }

        private void Menu_Excel_SType_Click(object sender, EventArgs e)
        {
            ScExcelInType();
        }

        

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolSearch_Click(object sender, EventArgs e)
        {
            if (!query_flag)
            {
                query_flag = true;

                ZCGridColumnSortButton btnSort = null;
                foreach (DataGridViewColumn c in dbgEq.Columns)
                {
                    if (!c.Visible) continue;
                    if (sortButtons.ContainsKey(c.HeaderText)) continue;
                    btnSort = new ZCGridColumnSortButton();
                    btnSort.Text = ".";
                    btnSort.Click += btnSort_Click;
                    btnSort.Size = new Size(16, 16);
                    btnSort.MinimumSize = btnSort.Size;
                    btnSort.sortHelper = new ZCGridSortHelper();
                    this.sortButtons.Add(c.HeaderText, btnSort);
                    this.dbgEq.Controls.Add(btnSort);
                    btnSort.Visible = true;
                    btnSort = this.sortButtons[c.HeaderText];
                    btnSort.Column = dbgEq.Columns[c.Index];

                }
                SetupControlsPosition();
                this.toolbtnSelectItem.Enabled = false;
                this.toolbtnSearchAll.Enabled = false;
                this.tvwEqSeach.Enabled = false;
                DataRefreshBySQL();
            }
            else
            {
                query_flag = false;
                if (this.frmSort != null)
                    frmSort.Close();
                foreach (string key in sortButtons.Keys)
                {
                    sortButtons[key].Dispose();
                }
                sortButtons.Clear();
                SortsString.Clear();
                OrderByString[0] = "";
                this.toolbtnSelectItem.Enabled = true;
                this.toolbtnSearchAll.Enabled = true;
                this.tvwEqSeach.Enabled = true;
                DataRefreshBySQL();
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            //DataRefreshBySQL();
            ZCGridColumnSortButton btn = sender as ZCGridColumnSortButton;
            btn.Checked = !btn.Checked;
            if (frmSort == null || frmSort.IsDisposed)
            {
                frmSort = new ZCGridSortForm(this.dbgEq, this.SortsString, this.sortButtons, this.OrderByString);
                frmSort.UpdateEvent += new ZCGridSortForm.UpdateEventHandler(DataRefreshBySQLSort);
                frmSort.GetRowListEvent += new ZCGridSortForm.GetRowListEventHandler(GetRowListBySQL);
            }
            if (btn.Checked)
            {
                frmSort.ResetShow(btn);
            }
            else
            {
                frmSort.Visible = false;
            }
        }



        /// <summary>
        /// 获取行列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private List<string> GetRowListBySQL(string Column)
        {
            DataTable dat = EqMgr.getEqRowList(_departId, _power, Column, SortsString);
            List<string> result = new List<string>(); ;
            for (int i = 0; i < dat.Rows.Count; i++)
            {
                result.Add(dat.Rows[i][0].ToString());
            }
            return result;
        }

        private void SetupControlsPosition()
        {
            SetupSortButtonsPosition();
            RefreshControls();
        }
        private void SetupSortButtonsPosition()
        {
            foreach (string columnName in SelectedColumns)
            {
                if (this.dbgEq.Columns.Contains(columnName) == false || this.sortButtons.ContainsKey(columnName) == false) continue;
                DataGridViewColumn col = this.dbgEq.Columns[columnName];
                ZCGridColumnSortButton btnSort = this.sortButtons[columnName];
                Rectangle r = this.dbgEq.GetCellDisplayRectangle(col.DisplayIndex, -1, false);
                btnSort.Left = r.Right - btnSort.Width - 2;
                btnSort.Top = r.Bottom - btnSort.Height - 2;
            }
        }
        private void RefreshControls()
        {
            foreach (Control c in this.Controls)
                c.Refresh();
        }
        private void HideSortForm()
        {
            if (this.frmSort != null && this.frmSort.IsDisposed == false && this.frmSort.Visible)
                this.frmSort.Visible = false;
        }
        private void dbgEq_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            SetupControlsPosition();
        }

        private void dbgEq_Scroll(object sender, ScrollEventArgs e)
        {
            SetupControlsPosition();
        }

        private void dbgEq_SizeChanged(object sender, EventArgs e)
        {
            SetupControlsPosition();
        }



        /// <summary>
        /// 刷新筛选数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataRefreshBySQL()
        {
            DataTable dat = EqMgr.getSortEqList((curPage - 1) * pageCount, pageCount, _departId, _power, SelectedColumns, SortsString, OrderByString[0]);
            if (dat != null)
            {
                TotalPage = this.getTotalPage();//得到数据的总页数
                dbgEq.DataSource = dat.DefaultView;
            }
            this.lblTotalpage.Text = "共" + TotalPage.ToString() + "页";
            this.lblCurPage.Text = "第" + curPage.ToString() + "页";

        }

        /// <summary>
        /// 刷新筛选数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataRefreshBySQLSort()
        {
            DataTable dat = EqMgr.getSortEqList((curPage - 1) * pageCount, pageCount, _departId, _power, SelectedColumns, SortsString, OrderByString[0]);
            if (dat != null)
            {
                TotalPage = this.getTotalPage();//得到数据的总页数
                dbgEq.DataSource = dat.DefaultView;
            }
            this.lblTotalpage.Text = "共" + TotalPage.ToString() + "页";
            this.lblCurPage.Text = "第" + curPage.ToString() + "页";
            SetupControlsPosition();
        }

       
         

        private void Print_button_Click(object sender, EventArgs e)
        {
            frmPrintOptions dlg = new frmPrintOptions(dbgEq);
            dlg.ShowDialog();
        }

        private void toolbtnAudit_Click(object sender, EventArgs e)
        {
            frmAudit dlg = new frmAudit(_user, _loginid, _departId, _power);
            dlg.ShowDialog();
        }

        private void toolbtnPrint_Click(object sender, EventArgs e)
        {
            frmPrintOptions dlg = new frmPrintOptions(dbgEq);
            dlg.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmSelectItem dlg = new frmSelectItem(AvailableColumns, SelectedColumns);
            dlg.UpdateEvent += new frmSelectItem.UpdateEventHandler(DataRefreshBySQL);
            dlg.ShowDialog();
        }



        private void Tool_Label_Selected_Click(object sender, EventArgs e)
        {
            frmLabel flabel = new frmLabel();
            flabel.ShowDialog();
            if ( flabel.DialogResult== DialogResult.OK)
            {
                DataTable dt = DgvMgr.GetSelectedTable(this.dbgEq);
                int count = flabel.Count;
                PrintMgr.PrintLabel(dt,count);
            }
        }

        private void Tool_Label_All_Click(object sender, EventArgs e)
        {
            frmLabel flabel = new frmLabel();
            flabel.ShowDialog();
            if (flabel.DialogResult == DialogResult.OK)
            {
                string assetno = this.dbgEq.SelectedRows[0].Cells["单号"].Value.ToString();
                DataTable dt = EqMgr.GetAssetInfo(assetno);
                int count = flabel.Count;
                PrintMgr.PrintLabel(dt, count);
            }
        }

        private void Menu_BaseInfo_Maintainer_Click(object sender, EventArgs e)
        {
            frmMaintainer fm = new frmMaintainer();
            fm.ShowDialog();
        }

        private void toolbtnRemind_Click(object sender, EventArgs e)
        {
            this.RemindEnter();
        }

        private void Menu_Sy_Remind_Click(object sender, EventArgs e)
        {
            this.RemindEnter();
        }

        

        private void Menu_Eq_BorrowReturn_Click(object sender, EventArgs e)
        {
            ReturnEnter();
        }
        private void toolbtnBorrowReturn_Click(object sender, EventArgs e)
        {
            ReturnEnter();
        }

        private void Menu_Eq_FixReturn_Click(object sender, EventArgs e)
        {
            ReturnEnter();
        }

        private void toolbtnFixReturn_Click(object sender, EventArgs e)
        {
            ReturnEnter();
        }

        private void Tool_Print_Click(object sender, EventArgs e)
        {
            frmPrintOptions dlg = new frmPrintOptions(dbgEq);
            dlg.ShowDialog();
        }

        private void Tool_Excel_Selected_Click(object sender, EventArgs e)
        {
            SelectedExcel();
        }

        private void Tool_Excel_SType_Click(object sender, EventArgs e)
        {
            ScExcelInType();
        }


        /// <summary>
        /// 资产更新(右键)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Tool_Update_Click(object sender, EventArgs e)
        {
            List<string> EqnoList = new List<string>();
            List<string> assertList = new List<string>();
            string assert;
            for (int i = 0; i < dbgEq.SelectedRows.Count; i++)
            {
                DataRow dr = (dbgEq.SelectedRows[i].DataBoundItem as DataRowView).Row;
                EqnoList.Add(dr.ItemArray[0].ToString());
                assertList.Add(dr.ItemArray[3].ToString());
            }
            assert = assertList[0];
            bool flag = true;
            foreach (string str in assertList)
            {
                if (!assert.Equals(str))
                    flag = false;
            }
            if (flag)
                this.UpdateEnter(EqnoList);
            else
                untCommon.InfoMsg("选中数据不能同时修改");
        }

        /// <summary>
        /// 资产更新（右键）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tool_Borrow_Click(object sender, EventArgs e)
        {
            this.BoroowEnter();
        }

        /// <summary>
        /// 资产归还（右键）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tool_Borrow_Return_Click(object sender, EventArgs e)
        {
            ReturnEnter();
        }

        /// <summary>
        /// 资产维修(右键)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tool_Fix_Click(object sender, EventArgs e)
        {
            FixEnter();
        }

        /// <summary>
        /// 维修完成（右键）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tool_FixReturn_Click(object sender, EventArgs e)
        {
            ReturnEnter();
        }

        /// <summary>
        /// 资产注销（右键）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tool_Clear_Click(object sender, EventArgs e)
        {
            this.ClearEnter();
        }

        private void Tool_Refresh_Click(object sender, EventArgs e)
        {
            if (!query_flag)
                DataRefreshBySQL();
            else
                DataRefreshBySQLSort();      
        }

    }

    
}