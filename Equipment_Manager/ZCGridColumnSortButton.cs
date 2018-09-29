using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Equipment_Manager
{
    public class ZCGridColumnSortButton : System.Windows.Forms.Button
    {
        protected DataGridViewCell cell;
        private DataGridViewColumn column;
        public ZCGridSortHelper sortHelper = null;
        private ZCGridButtonState state = ZCGridButtonState.Normal;
        private bool check = false;
        private ZCGridColumnSortButtonStyle buttonStyle= ZCGridColumnSortButtonStyle.Arrow;

        public ZCGridColumnSortButton()
        {
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FlatAppearance.BorderColor = CT.HeaderBorder;
            this.BackColor = CT.HeaderTop;
            this.FlatAppearance.MouseOverBackColor = CT.HeaderBottom;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.EnableNotifyMessage, true);
            this.MinimumSize = new Size(17, 17);
            this.MaximumSize = this.MinimumSize;
        }
        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            this.state = ZCGridButtonState.MouseHover;
            base.OnMouseUp(mevent);
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            this.state = ZCGridButtonState.MouseHover;
            base.OnMouseEnter(e);
        }
        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            this.state = ZCGridButtonState.MouseDown;
            base.OnMouseDown(mevent);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            this.state = ZCGridButtonState.Normal;
            base.OnMouseLeave(e);
        }
        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            if (!this.Enabled)
                this.state = ZCGridButtonState.Disabled;
            this.Refresh();
        }
        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);
            this.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            #region 由状态得到颜色
            Color backTopColor = CT.HeaderTop;
            Color backBottomColor = CT.HeaderBottom;
            Color borderColor = CT.HeaderBorder;
            Color fontColor = this.ForeColor;
            switch (this.state)
            {
                case ZCGridButtonState.Disabled:
                    backTopColor = CT.DisableButtonTop;
                    backBottomColor = CT.DisableButtonBottom;
                    borderColor = CT.DisableButtonBorder;
                    break;

                case ZCGridButtonState.MouseDown:
                    backTopColor = CT.ButtonDownTop;
                    backBottomColor = CT.ButtonDownBottom;
                    borderColor = CT.ButtonDownBorder;
                    break;

                case ZCGridButtonState.MouseHover:
                    backTopColor = CT.ButtonHoverTop;
                    backBottomColor = CT.ButtonHoverBottom;
                    borderColor = CT.ButtonHoverBorder;
                    break;

                case ZCGridButtonState.Normal:
                    backTopColor = CT.ButtonTop;
                    backBottomColor = CT.ButtonBottom;
                    borderColor = CT.ButtonBorder;
                    break;
            }
            if (this.check)
            {
                backTopColor = CT.ButtonDownTop;
                backBottomColor = CT.ButtonDownBottom;
                borderColor = CT.ButtonDownBorder;
            }
            #endregion 由状态得到颜色

            System.Drawing.Drawing2D.LinearGradientBrush br = new System.Drawing.Drawing2D.LinearGradientBrush(
                this.ClientRectangle, backTopColor, backBottomColor, 90);
            e.Graphics.FillRectangle(br, this.ClientRectangle);

            Rectangle rectBorder = this.ClientRectangle;
            rectBorder.Width -= 1;
            rectBorder.Height -= 1;
            e.Graphics.DrawRectangle(new Pen(borderColor, 1), rectBorder);

            if (this.buttonStyle == ZCGridColumnSortButtonStyle.Arrow)
            {
                #region 画箭头按钮
                if (this.sortHelper != null)
                {
                    bool filtered = false;
                    if (sortHelper.UseListFilter || sortHelper.FirstKeyFilterType != ZCGridViewKeyFilterType.FilterNone)
                        filtered = true;

                    if (sortHelper.SortType == ZCGridViewSortType.SortAZ && !filtered)
                    {
                        e.Graphics.FillPolygon(new SolidBrush(CT.ButtonBorder), new Point[] { new Point(3, 10), new Point(8, 10), new Point(5, 13) });
                        e.Graphics.FillPolygon(new SolidBrush(CT.ButtonBorder), new Point[] { new Point(9, 3), new Point(9, 14), new Point(14, 14) });

                    }
                    else if (sortHelper.SortType == ZCGridViewSortType.SortZA && !filtered)
                    {
                        e.Graphics.FillPolygon(new SolidBrush(CT.ButtonBorder), new Point[] { new Point(3, 10), new Point(8, 10), new Point(5, 13) });
                        e.Graphics.FillPolygon(new SolidBrush(CT.ButtonBorder), new Point[] { new Point(9, 4), new Point(9, 14), new Point(14, 4) });
                    }
                    else if (sortHelper.SortType == ZCGridViewSortType.SortAZ && filtered)
                    {
                        e.Graphics.FillPolygon(new SolidBrush(CT.ButtonBorder), new Point[] 
                    { new Point(2, 5),
                        new Point(5, 8),
                        new Point(5, 13),
                        new Point(7, 13), 
                        new Point(7, 8),
                        new Point(10, 5)
                    });
                        e.Graphics.FillPolygon(new SolidBrush(CT.ButtonBorder), new Point[] { new Point(10, 3), new Point(10, 14), new Point(15, 14) });
                    }
                    else if (sortHelper.SortType == ZCGridViewSortType.SortZA && filtered)
                    {
                        e.Graphics.FillPolygon(new SolidBrush(CT.ButtonBorder), new Point[] 
                    { new Point(2, 5),
                        new Point(5, 8),
                        new Point(5, 13),
                        new Point(7, 13), 
                        new Point(7, 8),
                        new Point(10, 5)
                    });
                        e.Graphics.FillPolygon(new SolidBrush(CT.ButtonBorder), new Point[] { new Point(10, 4), new Point(10, 14), new Point(15, 4) });
                    }
                    else if (sortHelper.SortType == ZCGridViewSortType.SortNone && filtered)
                    {
                        e.Graphics.FillPolygon(new SolidBrush(CT.ButtonBorder), new Point[] { new Point(3, 10), new Point(8, 10), new Point(5, 13) });

                        e.Graphics.FillPolygon(new SolidBrush(CT.ButtonBorder), new Point[] 
                    { new Point(6, 5),
                        new Point(9, 8),
                        new Point(9, 13),
                        new Point(11, 13), 
                        new Point(11, 8),
                        new Point(14, 5)
                    });
                    }
                    else
                    {
                        e.Graphics.FillPolygon(new SolidBrush(CT.ButtonBorder), new Point[]
                    {
                        new Point(rectBorder.Left+5,rectBorder.Top+7)
                        ,new Point(rectBorder.Right-4,rectBorder.Top+7)
                        ,new Point(rectBorder.Left+rectBorder.Width/2,rectBorder.Bottom-5)
                
                    });
                    }
                }
                else
                {
                    Point[] ps = new Point[] { new Point(5, 7), new Point(12, 7), new Point(8, 11) };
                    e.Graphics.FillPolygon(new SolidBrush(CT.ButtonBorder), ps);
                }
                #endregion 画箭头按钮
            }
            else if(this.buttonStyle == ZCGridColumnSortButtonStyle.UpdownGrip)
            {
                #region 画拖动按钮
                SolidBrush sbr = new SolidBrush(CT.ButtonBorder);
                if (this.state == ZCGridButtonState.MouseDown)
                {
                    e.Graphics.FillRectangle(sbr, new Rectangle(3, 5, 10, 2));
                    e.Graphics.FillRectangle(sbr, new Rectangle(3, 8, 10, 2));
                    e.Graphics.FillRectangle(sbr, new Rectangle(3, 11, 10, 2));
                }
                else
                {
                    e.Graphics.FillRectangle(sbr, new Rectangle(3, 4, 10, 2));
                    e.Graphics.FillRectangle(sbr, new Rectangle(3, 7, 10, 2));
                    e.Graphics.FillRectangle(sbr, new Rectangle(3, 10, 10, 2));
                }
                #endregion 画拖动按钮
            }
            else if (this.buttonStyle == ZCGridColumnSortButtonStyle.Form)
            {
                #region 画窗口按钮
                SolidBrush sbr = new SolidBrush(CT.ButtonBorder);
                    Pen p = new Pen(CT.ButtonBorder, 1);
                if (this.state == ZCGridButtonState.MouseDown)
                {
                    e.Graphics.DrawRectangle(p, new Rectangle(4, 4, 10, 10));
                    e.Graphics.FillRectangle(sbr, new Rectangle(4, 4, 10, 3));
                    e.Graphics.FillRectangle(sbr, new Rectangle(9, 11, 4, 2));
                }
                else
                {
                    e.Graphics.DrawRectangle(p, new Rectangle(3, 3, 10, 10));
                    e.Graphics.FillRectangle(sbr, new Rectangle(3, 3, 10, 3));
                    e.Graphics.FillRectangle(sbr, new Rectangle(8, 10, 4, 2));
                }
                #endregion 画窗口按钮
            }
            else if (this.buttonStyle == ZCGridColumnSortButtonStyle.ToTop)
            {
                #region 画到最上按钮
                e.Graphics.FillPolygon(new SolidBrush(CT.ButtonBorder), new Point[]
                { new Point(3, 12), new Point(14, 12), new Point(8, 6) });
                e.Graphics.FillRectangle(new SolidBrush(CT.ButtonBorder), 
                    new Rectangle(4, 5, 9, 2));
                 
                #endregion 画到最上按钮

            }
            else if (this.buttonStyle == ZCGridColumnSortButtonStyle.ToBottom)
            {
                #region 画到最下按钮
                e.Graphics.FillPolygon(new SolidBrush(CT.ButtonBorder), new Point[]
                    {new Point(4,5),new Point(13,5),new Point(8,10) });
                e.Graphics.FillRectangle(new SolidBrush(CT.ButtonBorder), new Rectangle(4, 10, 9, 2));
                    
                #endregion 画到最下按钮

            }
        }

        /// <summary>
        /// 按钮所在的DataGridViewColumn
        /// </summary>
        public System.Windows.Forms.DataGridViewColumn Column
        {
            get { return this.column; }
            set
            {
                this.column = value;
                //if (this.sortHelper == null)
                //{
                //    ZCGrid g = (value.DataGridView as ZCGrid);
                //    if (g.frmSort != null)
                //    {
                //        Dictionary<String, ZCGridSortHelper> Sorts = g.frmSort.Sorts;
                //        if (Sorts.ContainsKey(value.Name))
                //            this.sortHelper = Sorts[value.Name];
                //    }
                //}
            }
        }

        public bool Checked
        {
            get { return this.check; }
            set
            {
                this.check = value;
                this.Refresh();
            }
        }


        public ZCGridColumnSortButtonStyle ButtonStyle
        {
            get { return this.buttonStyle; }
            set
            {
                this.buttonStyle = value;
                this.Invalidate();
            }

        }

        public enum ZCGridColumnSortButtonStyle
        {
            Arrow,
            UpdownGrip,
            Form,
            ToBottom,
            ToTop
        }
    }
}
