using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DataBusiness;

namespace Equipment_Manager
{
    public partial class ZCGridSortForm : Form
    {
        public ZCGridColumnSortButton btn;
        private bool mouseInBottomRight;
        private bool checkListInitOk;
        private ZCGridSortHelper helper = null;
        private DataGridView dbgEq = null;
        private string fin;

        private Dictionary<String, String> SortsString = new Dictionary<String, String>();
        private Dictionary<string, ZCGridColumnSortButton> SortButtons = new Dictionary<string, ZCGridColumnSortButton>();


        private string[] OrderByString = new string[1];

        public delegate void UpdateEventHandler();
        public event UpdateEventHandler UpdateEvent;
        public delegate List<string> GetRowListEventHandler(string Column);
        public event GetRowListEventHandler GetRowListEvent;

        public ZCGridSortForm(DataGridView dbgEq, Dictionary<String, String> SortsString, Dictionary<string, ZCGridColumnSortButton> SortButtons, string[] OrderByString)
        {
            InitializeComponent();
            this.SortButtons = SortButtons;
            this.OrderByString = OrderByString;
            this.dbgEq = dbgEq;
            this.SortsString = SortsString;
            this.MinimumSize = new Size(273, 384);
            this.pnlBottom.BackColor = CT.HeaderTop;
            this.fin = "";            
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rect = this.ClientRectangle;

            rect.Y = this.Height - this.Padding.Bottom;
            rect.Height = this.Padding.Bottom;

            LinearGradientBrush linGrBrush = new LinearGradientBrush(rect, CT.HeaderTop, CT.HeaderBottom, LinearGradientMode.Vertical);
            e.Graphics.FillRectangle(linGrBrush, rect);
            e.Graphics.FillRectangles(new SolidBrush(CT.HeaderBorder),
                new Rectangle[] { new Rectangle(rect.Right - 7, rect.Bottom - 7, 4, 4) ,
               new Rectangle(rect.Right - 7, rect.Bottom - 13, 4, 4),
                new Rectangle(rect.Right - 13, rect.Bottom - 7, 4, 4)});

            rect = this.ClientRectangle;
            rect.Height -= 1;
            rect.Width -= 1;
            e.Graphics.DrawRectangle(new Pen(CT.HeaderBorder, 1), rect);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.cbbFirstLogic.SelectedIndex >= 0 && !string.IsNullOrEmpty(this.txtFirstKey.Text))
            {
                ZCGridViewKeyFilterType ftype = (ZCGridViewKeyFilterType)this.cbbFirstLogic.SelectedIndex;
                helper.FirstKeyFilterType = ftype;
                helper.FirstKey = this.txtFirstKey.Text;

                if (this.rdoAnd.Checked)
                    helper.KeyLinkType = ZCGridViewKeyLinkType.And;
                else if (this.rdoOr.Checked)
                    helper.KeyLinkType = ZCGridViewKeyLinkType.Or;
                else
                    helper.KeyLinkType = ZCGridViewKeyLinkType.None;

                if (helper.KeyLinkType != ZCGridViewKeyLinkType.None
                    && this.cbbSecondLogic.SelectedIndex >= 0
                    && !string.IsNullOrEmpty(this.txtSecondKey.Text))
                {
                    ZCGridViewKeyFilterType stype = (ZCGridViewKeyFilterType)this.cbbSecondLogic.SelectedIndex;
                    helper.SecondKeyFilterType = stype;
                    helper.SecondKey = this.txtSecondKey.Text;
                }
                helper.UseListFilter = false;
            }
            else
            {
                helper.UseListFilter = true;
                helper.ListFilterSelectAll = false;
                helper.ListFilterSelectNull = false;
                if (this.cklList.GetItemChecked(0) == true)
                {
                    helper.ListFilterSelectAll = true;
                    helper.ListFilterKeys.Clear();
                }
                else
                {
                    helper.ListFilterKeys.Clear();

                    if (helper.HasNullListKey && this.cklList.GetItemChecked(this.cklList.Items.Count - 1) == true)
                        helper.ListFilterSelectNull = true;
                    foreach (int index in this.cklList.CheckedIndices)
                    {
                        if (helper.HasNullListKey && index == this.cklList.Items.Count - 1)
                            continue;
                        else
                            helper.ListFilterKeys.Add(this.cklList.Items[index].ToString());
                    }
                }
                if (helper.ListFilterSelectAll)
                    helper.UseListFilter = false;
            }
            SortThisColumn();
            this.RefreshColumnInfo();
            this.Visible = false;
        }

        internal void ResetShow(ZCGridColumnSortButton btn)
        {
            if (this.btn != null && this.btn.IsDisposed == false && this.btn.Equals(btn) == false)
                this.btn.Checked = false;

            this.btn = btn;
            this.btn.Checked = true;

            this.cklList.Items.Clear();
            this.cklList.Items.Add("正在读取...");
            this.cklList.Enabled = false;
            this.checkListInitOk = false;
            this.helper = this.btn.sortHelper;

            this.cbbFirstLogic.SelectedIndex = (int)helper.FirstKeyFilterType;
            this.txtFirstKey.Text = helper.FirstKey;

            if (helper.KeyLinkType == ZCGridViewKeyLinkType.And)
                this.rdoAnd.Checked = true;
            else if (helper.KeyLinkType == ZCGridViewKeyLinkType.Or)
                this.rdoOr.Checked = true;
            else
                this.rdoSingle.Checked = true;

            this.cbbSecondLogic.SelectedIndex = (int)helper.SecondKeyFilterType;
            this.txtSecondKey.Text = helper.SecondKey;

            this.bwReadList.RunWorkerAsync(this.btn.Column.Name);
            Application.DoEvents();

            this.Size = this.MinimumSize;
            Point p = this.dbgEq.PointToScreen(btn.Location);
            p.Y += btn.Height;

            this.Location = p;

            if (this.Right > Screen.PrimaryScreen.WorkingArea.Right)
                this.Left = Screen.PrimaryScreen.WorkingArea.Right - this.Width;
            if (this.Left < Screen.PrimaryScreen.WorkingArea.Left)
                this.Left = Screen.PrimaryScreen.WorkingArea.Left;
            if (this.Bottom > Screen.PrimaryScreen.WorkingArea.Bottom)
                this.Top = Screen.PrimaryScreen.WorkingArea.Bottom - this.Height;

            this.Show();
            this.cklList.Select();
        }
        private void lAZ_MouseEnter(object sender, EventArgs e)
        {
            Control c = sender as Control;
            c.BackColor = CT.HeaderBottom;
        }
        private void lSort_MouseLeave(object sender, EventArgs e)
        {
            Control c = sender as Control;
            c.BackColor = Color.White;
        }
        private void lAZ_MouseLeave(object sender, EventArgs e)
        {
            Control c = sender as Control;
            c.BackColor = Color.WhiteSmoke;
        }
        private void RefreshColumnInfo()
        {
            this.btn.sortHelper = this.helper;
        }

        private void SortThisColumn()
        {
            if (this.helper.SortType == ZCGridViewSortType.SortAZ)
            {
                foreach (var value in SortButtons)
                {
                    if (value.Key.Equals(this.btn.Column.Name))
                        continue;
                    if (value.Value.sortHelper.SortType != ZCGridViewSortType.SortNone)
                        value.Value.sortHelper.SortType = ZCGridViewSortType.SortNone;
                }
                OrderByString[0] = string.Format("{0} ASC", this.btn.Column.Name);
            }
            else if (this.helper.SortType == ZCGridViewSortType.SortZA)
            {
                foreach (var value in SortButtons)
                {
                    if (value.Key.Equals(this.btn.Column.Name))
                        continue;
                    if (value.Value.sortHelper.SortType != ZCGridViewSortType.SortNone)
                        value.Value.sortHelper.SortType = ZCGridViewSortType.SortNone;
                }
                OrderByString[0] = string.Format("{0} DESC", this.btn.Column.Name); 
            }
            else
                OrderByString[0] =  "";
            string f = "";
            if (this.helper.UseListFilter)
            {
                if (this.helper.ListFilterSelectAll)
                {
                    f = "";
                }
                else
                {
                    if (this.helper.ListFilterSelectNull)
                    {
                        f = this.btn.Column.Name + "=''";
                    }
                    else
                    {
                        string temp = "";
                        for (int i = 0; i < this.helper.ListFilterKeys.Count; i++)
                        {
                            string key = this.helper.ListFilterKeys[i];
                            temp += "'" + key + "',";
                        }
                        temp = temp.Substring(0, temp.Length - 1);
                        f = this.btn.Column.Name + " IN(" + temp + ")";
                    }
                }
            }
            else//使用条件筛选
            {
                string a = "", s = "";
                switch (helper.FirstKeyFilterType)
                {
                    case ZCGridViewKeyFilterType.BeginWith:
                        f = "{0} like '{1}%'";
                        break;
                    case ZCGridViewKeyFilterType.EndWidt:
                        f = "{0} like '%{1}'";
                        break;
                    case ZCGridViewKeyFilterType.Equal:
                        f = "{0} = '{1}'";
                        break;
                    case ZCGridViewKeyFilterType.GreateThan:
                        f = "{0} > '{1}'";
                        break;
                    case ZCGridViewKeyFilterType.SmallThan:
                        f = "{0} < '{1}'";
                        break;
                    case ZCGridViewKeyFilterType.Include:
                        f = "{0} like '%{1}%'";
                        break;
                    case ZCGridViewKeyFilterType.NotEqual:
                        f = "{0} <> '{1}'";
                        break;
                    case ZCGridViewKeyFilterType.NotInclude:
                        f = "{0} not like '%{1}%'";
                        break;
                }
                f = string.Format(f, this.btn.Column.Name, helper.FirstKey);
                if (helper.KeyLinkType != ZCGridViewKeyLinkType.None)
                {
                    a = helper.KeyLinkType.ToString().ToLower();
                    switch (helper.SecondKeyFilterType)
                    {
                        case ZCGridViewKeyFilterType.BeginWith:
                            s = "{0} like '{1}%'";
                            break;
                        case ZCGridViewKeyFilterType.EndWidt:
                            s = "{0} like '%{1}'";
                            break;
                        case ZCGridViewKeyFilterType.Equal:
                            s = "{0} = '{1}'";
                            break;
                        case ZCGridViewKeyFilterType.GreateThan:
                            s = "{0} > '{1}'";
                            break;
                        case ZCGridViewKeyFilterType.SmallThan:
                            s = "{0} < '{1}'";
                            break;
                        case ZCGridViewKeyFilterType.Include:
                            s = "{0} like '%{1}%'";
                            break;
                        case ZCGridViewKeyFilterType.NotEqual:
                            s = "{0} <> '{1}'";
                            break;
                        case ZCGridViewKeyFilterType.NotInclude:
                            s = "{0} not like '%{1}%'";
                            break;
                    }
                    s = string.Format(s, this.btn.Column.Name, helper.SecondKey);
                    f = "(" + f + " " + a + " " + s + ")";
                }
            }
            this.btn.sortHelper = this.helper;
            if (!string.IsNullOrEmpty(f))
            {
                if (this.SortsString.ContainsKey(this.btn.Column.Name))
                {
                    this.SortsString[this.btn.Column.Name] = f;
                }
                else
                {
                    this.SortsString.Add(this.btn.Column.Name, f);
                }
            }
            if (UpdateEvent != null)
            {
                UpdateEvent();
            }
        }


        private void lAZ_Click(object sender, EventArgs e)
        {
            helper.SortType = ZCGridViewSortType.SortAZ;
            SortThisColumn();
            this.RefreshColumnInfo();
            this.Visible = false;
        }
        private void pnlAZ_Paint(object sender, PaintEventArgs e)
        {
            Control l = sender as Control;
            Rectangle r = l.ClientRectangle;

            if (l.Equals(this.pnlAZ))
                e.Graphics.DrawImage(global::Equipment_Manager.Properties.Resources.IconAZ, 8, 8);
            else
                e.Graphics.DrawImage(global::Equipment_Manager.Properties.Resources.IconZA, 8, 8);
        }
        private void lZA_Click(object sender, EventArgs e)
        {
            helper.SortType = ZCGridViewSortType.SortZA;
            SortThisColumn();
            this.RefreshColumnInfo();
            this.Visible = false;
        }
        private void ZCGridViewSortForm_MouseDown(object sender, MouseEventArgs e)
        {
            Rectangle rect = this.ClientRectangle;
            rect.Y = rect.Height - this.Padding.Bottom;
            rect.Height = this.Padding.Bottom;
            rect.X = rect.X + rect.Width - 20;
            if (rect.Contains(e.Location))
            {
                this.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
                mouseInBottomRight = true;
            }
        }
        private void ZCGridViewSortForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && mouseInBottomRight == true)
            {
                Point p = PointToScreen(e.Location);
                this.Width = p.X - this.Left;
                this.Height = p.Y - this.Top;
                this.Refresh();
            }

        }
        private void ZCGridViewSortForm_MouseUp(object sender, MouseEventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.Default;
            mouseInBottomRight = false;
        }
        private void ZCGridViewSortForm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == false)
                this.btn.Checked = false;

        }
        private void rdoSingle_CheckedChanged(object sender, EventArgs e)
        {
            this.cbbSecondLogic.Enabled = this.txtSecondKey.Enabled = !this.rdoSingle.Checked;
        }
        private void lClear_Click(object sender, EventArgs e)
        {
            if (this.SortsString.ContainsKey(this.btn.Column.Name))
            {
                this.SortsString.Remove(this.btn.Column.Name);
            }
            this.helper = new ZCGridSortHelper();
            this.SortThisColumn();
            this.Visible = false;
        }
        private void bwReadList_DoWork(object sender, DoWorkEventArgs e)
        {
            string columnName = e.Argument as string;
            if (GetRowListEvent != null)
            {
                e.Result = GetRowListEvent(columnName);
            }
            else
            {
                e.Result = null;
            }

        }
        private void bwReadList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this == null || this.IsDisposed) return;
            List<string> l = e.Result as List<string>;
            this.cklList.Items.Clear();

            helper.HasNullListKey = false;
            this.cklList.Items.Add("[全选]");
            if (helper.ListFilterSelectAll)
                this.cklList.SetItemChecked(0, true);

            int index = 0;
            foreach (string value in l)
            {
                if (index % 500 == 0)
                    Application.DoEvents();
                if (string.IsNullOrEmpty(value))
                {
                    helper.HasNullListKey = true;
                }
                else
                {
                    index++;
                    this.cklList.Items.Add(value);
                    if (helper.ListFilterSelectAll ||
                        ((!helper.ListFilterSelectAll && helper.ListFilterKeys.Count > 0 && helper.ListFilterKeys.Contains(value))))
                    {
                        this.cklList.SetItemChecked(index, true);
                    }

                }
            }
            if (helper.HasNullListKey)
            {
                index++;
                this.cklList.Items.Add("[空值]");
                if (helper.ListFilterSelectAll || helper.ListFilterSelectNull)
                {
                    this.cklList.SetItemChecked(index, true);
                }
            }
            this.checkListInitOk = true;

            if (this.cbbFirstLogic.SelectedIndex == -1 || this.cbbFirstLogic.SelectedIndex == this.cbbFirstLogic.Items.Count - 1)
                this.cklList.Enabled = true;

            this.cklList.Select();
        }
        private void cbbFirstLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbFirstLogic.SelectedIndex >= 0)
                this.cklList.Enabled = cbbFirstLogic.SelectedIndex == cbbFirstLogic.Items.Count - 1;
            else
                this.cklList.Enabled = true;

        }
        private void cklList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!this.checkListInitOk) return;
            if (e.Index == 0)
            {
                bool check = e.NewValue == CheckState.Checked;
                for (int i = 1; i < this.cklList.Items.Count; i++)
                {
                    this.cklList.SetItemChecked(i, check);
                }
            }
            else
            {
                if (e.NewValue == CheckState.Unchecked)
                {
                    this.checkListInitOk = false;
                    this.cklList.SetItemChecked(0, false);
                    this.checkListInitOk = true;
                }
                else if (e.NewValue == CheckState.Checked)
                {
                    bool allchecked = true;
                    for (int i = 1; i < this.cklList.Items.Count; i++)
                    {
                        if (i != e.Index && cklList.GetItemChecked(i) == false)
                        {
                            allchecked = false;
                            break;
                        }
                    }
                    if (allchecked)
                    {
                        this.checkListInitOk = false;
                        this.cklList.SetItemChecked(0, true);
                        this.checkListInitOk = true;
                    }
                }
            }
        }
    }
}
