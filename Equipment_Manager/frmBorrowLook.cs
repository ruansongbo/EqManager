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

        private string _departId;
        private string _power;

        private void frmBorrowLook_Load(object sender, EventArgs e)
        {
            curPage = 1;
            DataTable dat = BoroowMgr.getLogList(0, pageCount, _departId, _power);
            if (dat != null)
            {
                dbgBorrow.DataSource = dat.DefaultView;
                AvailableColumns.Clear();
                foreach (DataGridViewColumn c in dbgBorrow.Columns)
                {
                    if (!c.Visible) continue;
                    AvailableColumns.Add(c.HeaderText);
                    SelectedColumns.Add(c.HeaderText);
                }
                dbgBorrow.ScrollBars = ScrollBars.Both;
                this.dbgFrozen();
            }
            TotalPage = this.getTotalPage();//得到数据的总页数
            this.lblTotalpage.Text = "共" + TotalPage.ToString() + "页";
        }
        /// <summary>
        /// 冻结前两列
        /// </summary>
        private void dbgFrozen()
        {
            this.dbgBorrow.Columns[1].Frozen = true;//第二列前的列都被冻结
        }

        #region 页面操作
        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFirst_Click(object sender, EventArgs e)
        {

            curPage = 1;
            DataTable dat = BoroowMgr.getSortEqList(0, pageCount, _departId, _power, SelectedColumns, SortsString, OrderByString[0]);
            if (dat != null)
            {
                //绑定数据
                dbgBorrow.DataSource = dat.DefaultView;
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
            DataTable dat = BoroowMgr.getSortEqList((curPage - 1) * pageCount, pageCount, _departId, _power, SelectedColumns, SortsString, OrderByString[0]);

            if (dat != null)
            {

                //绑定数据
                dbgBorrow.DataSource = dat.DefaultView;
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

            DataTable dat = BoroowMgr.getSortEqList((curPage - 1) * pageCount, pageCount, _departId, _power, SelectedColumns, SortsString, OrderByString[0]);

            if (dat != null)
            {
                //绑定数据
                dbgBorrow.DataSource = dat.DefaultView;
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

            DataTable dat = BoroowMgr.getSortEqList((curPage - 1) * pageCount, pageCount, _departId, _power, SelectedColumns, SortsString, OrderByString[0]);

            if (dat != null)
            {
                //绑定数据
                dbgBorrow.DataSource = dat.DefaultView;
            }
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

            DataTable dat = BoroowMgr.getLogList((curPage - 1) * pageCount, pageCount, _departId, _power);

            if (dat != null)
            {


                //绑定数据

                dbgBorrow.DataSource = dat.DefaultView;
            }
            this.lblCurPage.Text = "第" + curPage.ToString() + "页";

        }

        #endregion 页面操作

        /// <summary>
        /// 得到信息的总页数
        /// </summary>
        /// <returns></returns>
        private int getTotalPage()
        {
            int result = BoroowMgr.LogCount();
            int Total;
            if (result != 0)
            {
                int count = BoroowMgr.LogCount() % pageCount;
                if (count == 0)
                    Total = BoroowMgr.LogCount() / pageCount;
                else
                    Total = BoroowMgr.LogCount() / pageCount + 1;
            }
            else
                Total = 0;
            return Total;

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
            SelectedColumns.Clear();
            foreach (string field in AvailableColumns)
            {
                SelectedColumns.Add(field);
            }
            foreach (var value in SortsString)
            {
                SortsString.Remove(value.Key);
            }
        }
        private void toolbtnExel_Click(object sender, EventArgs e)
        {
            DataTable dt = DgvMgr.GetTable(this.dbgBorrow);
            ExportToExcel(dt, "当前资产表格");
        }

        /// <summary>
        /// 导出电子表格
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="ExcelName"></param>
        private void ExportToExcel(DataTable dt, string ExcelName)
        {
            string filePath = string.Empty;
            string nowTime = DateTime.Now.ToString("yyyyMMddHHmmss");//获取当前时间作为文件名的一部分
            FolderBrowserDialog BrowDialog = new FolderBrowserDialog();
            BrowDialog.ShowNewFolderButton = true;
            BrowDialog.Description = "请选择电子表格保存位置";

            if (BrowDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = BrowDialog.SelectedPath;//这个就是点击选择文件夹的路径
                filePath = filePath + "\\" + ExcelName + nowTime + ".xlsx";
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmPrintOptions dlg = new frmPrintOptions(dbgBorrow);
            dlg.ShowDialog();
        }

        private void toolbtnSelectItem_Click(object sender, EventArgs e)
        {
            frmSelectItem dlg = new frmSelectItem(AvailableColumns, SelectedColumns);
            dlg.UpdateEvent += new frmSelectItem.UpdateEventHandler(DataRefreshBySQL);
            dlg.ShowDialog();
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        private void DataRefresh()
        {
            DataTable dat = BoroowMgr.getLogList((curPage - 1) * pageCount, pageCount, _departId, _power);

            if (dat != null)
            {
                TotalPage = this.getTotalPage();//得到数据的总页数

                //绑定数据
                dbgBorrow.DataSource = dat.DefaultView;
            }
            this.lblTotalpage.Text = "共" + TotalPage.ToString() + "页";
            this.lblCurPage.Text = "第" + curPage.ToString() + "页";
        }

        /// <summary>
        /// 刷新筛选数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataRefreshBySQL()
        {
            DataTable dat = BoroowMgr.getSortEqList((curPage - 1) * pageCount, pageCount, _departId, _power, SelectedColumns, SortsString, OrderByString[0]);
            if (dat != null)
            {
                TotalPage = this.getTotalPage();//得到数据的总页数
                dbgBorrow.DataSource = dat.DefaultView;
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
            DataTable dat = BoroowMgr.getSortEqList((curPage - 1) * pageCount, pageCount, _departId, _power, SelectedColumns, SortsString, OrderByString[0]);
            if (dat != null)
            {
                TotalPage = this.getTotalPage();//得到数据的总页数
                dbgBorrow.DataSource = dat.DefaultView;
            }
            this.lblTotalpage.Text = "共" + TotalPage.ToString() + "页";
            this.lblCurPage.Text = "第" + curPage.ToString() + "页";
            SetupControlsPosition();
        }

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnSearch_Click(object sender, EventArgs e)
        {
            if (!query_flag)
            {
                query_flag = true;

                ZCGridColumnSortButton btnSort = null;
                foreach (DataGridViewColumn c in dbgBorrow.Columns)
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
                    this.dbgBorrow.Controls.Add(btnSort);
                    btnSort.Visible = true;
                    btnSort = this.sortButtons[c.HeaderText];
                    btnSort.Column = dbgBorrow.Columns[c.Index];

                }
                SetupControlsPosition();
                this.toolbtnSelectItem.Enabled = false;
                this.toolbtnSearchAll.Enabled = false;
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
                frmSort = new ZCGridSortForm(this.dbgBorrow, this.SortsString, this.sortButtons, this.OrderByString);
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
            DataTable dat = BoroowMgr.getEqRowList(_departId, _power, Column, SortsString);
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
                if (this.dbgBorrow.Columns.Contains(columnName) == false || this.sortButtons.ContainsKey(columnName) == false) continue;
                DataGridViewColumn col = this.dbgBorrow.Columns[columnName];
                ZCGridColumnSortButton btnSort = this.sortButtons[columnName];
                Rectangle r = this.dbgBorrow.GetCellDisplayRectangle(col.DisplayIndex, -1, false);
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
        private void dbgBorrow_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            SetupControlsPosition();
        }

        private void dbgBorrow_Scroll(object sender, ScrollEventArgs e)
        {
            SetupControlsPosition();
        }

        private void dbgBorrow_SizeChanged(object sender, EventArgs e)
        {
            SetupControlsPosition();
        }

    }
}