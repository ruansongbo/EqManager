using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RedrawControl
{
    public class DoubleBufferDataGridView:DataGridView
    {
        public DoubleBufferDataGridView()
        {
            SetStyle(ControlStyles.UserPaint, true);//控件自行重绘
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
        }
    }
}
