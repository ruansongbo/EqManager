using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataEntity;
using DataBusiness;

namespace Equipment_Manager
{
    public partial class frmImport : Form
    {
        public frmImport()
        {
            InitializeComponent();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            //获取Excel表头
            List<string> headers;

            headers = EqTypeMgr.GetHeader("总表");
            DataTable dt = ListToTable(headers);
            string filePath = string.Empty;
            FolderBrowserDialog BrowDialog = new FolderBrowserDialog();
            BrowDialog.ShowNewFolderButton = true;
            BrowDialog.Description = "请选择模板保存位置";

            if (BrowDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = BrowDialog.SelectedPath;//这个就是点击选择文件夹的路径
                filePath = filePath + "\\" + "资产表格模板" + ".xlsx";
                if (ExcelMgr.ExportExcel(dt, filePath))
                {
                    untCommon.InfoMsg("导出成功");
                }
                else
                {
                    untCommon.InfoMsg("导出失败");
                }
            }
            
            else
            {
                untCommon.InfoMsg("请选择资产类别");
            }
        }


        private DataTable ListToTable(List<string> list)
        {
            DataTable dt = new DataTable();
            DataColumn dc;
            //第一个是资产编码，自动生成，不需要导出
            for (int count = 1; count < list.Count; count++)
            {
                dc = new DataColumn(list[count]);
                dt.Columns.Add(dc);
            }
            return dt;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            string type = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;//这个就是点击选择文件的路径
                
               if (ExcelMgr.ImportExcel(filePath,type))
                {
                    untCommon.InfoMsg("导入成功");
                }
                else
                {
                    untCommon.InfoMsg("导入失败");
                }
            }
        }
    }
}
