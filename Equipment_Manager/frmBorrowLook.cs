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
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // ��ֹ��������.
            SetStyle(ControlStyles.DoubleBuffer, true); // ˫����

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
        private static int curPage = 1;  //��ǰҳ
        private static int TotalPage = 0; //��ҳ��
        private static int pageCount = 30; //��ҳ����
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
            TotalPage = this.getTotalPage();//�õ����ݵ���ҳ��
            this.lblTotalpage.Text = "��" + TotalPage.ToString() + "ҳ";
        }
        /// <summary>
        /// ����ǰ����
        /// </summary>
        private void dbgFrozen()
        {
            this.dbgBorrow.Columns[1].Frozen = true;//�ڶ���ǰ���ж�������
        }

        #region ҳ�����
        /// <summary>
        /// ��ҳ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFirst_Click(object sender, EventArgs e)
        {

            curPage = 1;
            DataTable dat = BoroowMgr.getSortEqList(0, pageCount, _departId, _power, SelectedColumns, SortsString, OrderByString[0]);
            if (dat != null)
            {
                //������
                dbgBorrow.DataSource = dat.DefaultView;
            }
            this.lblCurPage.Text = "��" + curPage.ToString() + "ҳ";
        }
        /// <summary>
        /// ��һҳ
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

                //������
                dbgBorrow.DataSource = dat.DefaultView;
            }
            this.lblCurPage.Text = "��" + curPage.ToString() + "ҳ";


        }
        /// <summary>
        /// ��һҳ
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
                //������
                dbgBorrow.DataSource = dat.DefaultView;
            }
            this.lblCurPage.Text = "��" + curPage.ToString() + "ҳ";


        }

        /// <summary>
        /// βҳ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLast_Click(object sender, EventArgs e)
        {
            curPage = TotalPage;

            DataTable dat = BoroowMgr.getSortEqList((curPage - 1) * pageCount, pageCount, _departId, _power, SelectedColumns, SortsString, OrderByString[0]);

            if (dat != null)
            {
                //������
                dbgBorrow.DataSource = dat.DefaultView;
            }
            this.lblCurPage.Text = "��" + curPage.ToString() + "ҳ";


        }

        /// <summary>
        /// ��ѯָ��ҳ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (txtPage.Text.Trim() == "")
            {
                untCommon.InfoMsg("��������Ҫ��ѯ��ҳ����");
                return;
            }
            try
            {
                curPage = int.Parse(this.txtPage.Text);
            }
            catch (FormatException)
            {
                untCommon.InfoMsg("��Ҫ��ѯ��ҳ�����������֡�");
                return;
            }
            if (curPage > TotalPage || curPage < 1)
            {
                untCommon.InfoMsg("û������Ҫ��ѯ��ҳ����");
                return;
            }

            DataTable dat = BoroowMgr.getLogList((curPage - 1) * pageCount, pageCount, _departId, _power);

            if (dat != null)
            {


                //������

                dbgBorrow.DataSource = dat.DefaultView;
            }
            this.lblCurPage.Text = "��" + curPage.ToString() + "ҳ";

        }

        #endregion ҳ�����

        /// <summary>
        /// �õ���Ϣ����ҳ��
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
        /// ˢ������
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
        /// ��ѯ������Ϣ
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
            ExportToExcel(dt, "��ǰ�ʲ����");
        }

        /// <summary>
        /// �������ӱ��
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="ExcelName"></param>
        private void ExportToExcel(DataTable dt, string ExcelName)
        {
            string filePath = string.Empty;
            string nowTime = DateTime.Now.ToString("yyyyMMddHHmmss");//��ȡ��ǰʱ����Ϊ�ļ�����һ����
            FolderBrowserDialog BrowDialog = new FolderBrowserDialog();
            BrowDialog.ShowNewFolderButton = true;
            BrowDialog.Description = "��ѡ����ӱ�񱣴�λ��";

            if (BrowDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = BrowDialog.SelectedPath;//������ǵ��ѡ���ļ��е�·��
                filePath = filePath + "\\" + ExcelName + nowTime + ".xlsx";
                if (ExcelMgr.ExportExcel(dt, filePath))
                {
                    untCommon.InfoMsg("�����ɹ�");
                }
                else
                {
                    untCommon.InfoMsg("����ʧ��");
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
        /// ˢ������
        /// </summary>
        private void DataRefresh()
        {
            DataTable dat = BoroowMgr.getLogList((curPage - 1) * pageCount, pageCount, _departId, _power);

            if (dat != null)
            {
                TotalPage = this.getTotalPage();//�õ����ݵ���ҳ��

                //������
                dbgBorrow.DataSource = dat.DefaultView;
            }
            this.lblTotalpage.Text = "��" + TotalPage.ToString() + "ҳ";
            this.lblCurPage.Text = "��" + curPage.ToString() + "ҳ";
        }

        /// <summary>
        /// ˢ��ɸѡ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataRefreshBySQL()
        {
            DataTable dat = BoroowMgr.getSortEqList((curPage - 1) * pageCount, pageCount, _departId, _power, SelectedColumns, SortsString, OrderByString[0]);
            if (dat != null)
            {
                TotalPage = this.getTotalPage();//�õ����ݵ���ҳ��
                dbgBorrow.DataSource = dat.DefaultView;
            }
            this.lblTotalpage.Text = "��" + TotalPage.ToString() + "ҳ";
            this.lblCurPage.Text = "��" + curPage.ToString() + "ҳ";

        }

        /// <summary>
        /// ˢ��ɸѡ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataRefreshBySQLSort()
        {
            DataTable dat = BoroowMgr.getSortEqList((curPage - 1) * pageCount, pageCount, _departId, _power, SelectedColumns, SortsString, OrderByString[0]);
            if (dat != null)
            {
                TotalPage = this.getTotalPage();//�õ����ݵ���ҳ��
                dbgBorrow.DataSource = dat.DefaultView;
            }
            this.lblTotalpage.Text = "��" + TotalPage.ToString() + "ҳ";
            this.lblCurPage.Text = "��" + curPage.ToString() + "ҳ";
            SetupControlsPosition();
        }

        /// <summary>
        /// ������ѯ
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
        /// ��ȡ���б�
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