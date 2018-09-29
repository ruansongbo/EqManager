using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RedrawControl
{
    public class tsButton : ToolStripButton
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.DrawRectangle(new Pen(borderColor), 0, 0, this.Width - 1, this.Height - 1);
        }
        private Color borderColor = Color.Gray;
        [DefaultValue(typeof(Color), "Gray")]
        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; base.Invalidate(); }
        }
    }
}
