using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using OfficeOpenXml;
using DataEntity;



namespace DataBusiness
{
    //这个类中用的是EPPlus第三方插件，需要另外引用
    public class ExcelMgr
    {
        /// <summary>
        /// 导出Excel电子表格
        /// </summary>
        /// <param name="dt">数据源</param>
        /// <param name="filepath">导出的Excel的文件名的一部分</param>
        /// <returns>true:成功;false:失败</returns>
        public static bool ExportExcel(DataTable dt,string filePath)
        {
            string savePath = filePath;
            Stream stream = new FileStream(savePath, FileMode.Create);
            try
            {
                
                using (ExcelPackage package = new ExcelPackage())
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("固定资产信息");
                    worksheet.Row(1).Height = 20;//设置表头行高
                    //EPPlus的索引是从1开始的
                    //获取列名和设置列宽
                    for (int columnHeader = 1; columnHeader <= dt.Columns.Count; columnHeader++)
                    {
                        worksheet.Cells[1, columnHeader].Value = dt.Columns[columnHeader - 1].ColumnName;
                        worksheet.Column(columnHeader).Width = 15;
                    }
                    for (int row = 2; row <= dt.Rows.Count + 1; row++)
                    {
                        for (int column = 1; column <= dt.Columns.Count; column++)
                        {
                            worksheet.Cells[row, column].Value = dt.Rows[row - 2][column - 1];
                        }
                    }                    
                    using (stream)
                    {
                        package.SaveAs(stream);
                    }
                    
                }
                stream.Close();//关闭流，否则下次再使用会出现文件被占用的情况
                return true;
            }
            catch(Exception e)
            {
                stream.Close();
                return false;
            }
        }

        /// <summary>
        /// 导入Excel表格
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool ImportExcel(string filePath,string type)
        {
            Equipment eq;
            FileStream fileStream = new FileStream(@filePath, FileMode.Open);
            try
            {
                
                using (ExcelPackage package = new ExcelPackage(fileStream))
                {
                    for (int index = 1; index <= package.Workbook.Worksheets.Count; index++)
                    {
                        ExcelWorksheet sheet = package.Workbook.Worksheets[index];
                        
                        for (int srow = sheet.Dimension.Start.Row+1, erow = sheet.Dimension.End.Row; srow <= erow; srow++)
                        {
                            List<string> list = new List<string> { };
                            for (int scolumn = sheet.Dimension.Start.Column, ecolumn = sheet.Dimension.End.Column; scolumn <= ecolumn; scolumn++)
                            {
                                if (sheet.GetValue<string>(srow, scolumn) != null)
                                    list.Add(sheet.GetValue<string>(srow, scolumn));

                                else
                                    list.Add("");
                            }
                            eq=EqMgr.SetEq(list);
                            EqMgr.Add(eq);
                        }
                    }
                }
                
                fileStream.Close();
                return true;
            }
            catch(Exception e)
            {
                fileStream.Close();
                return false;
            }
        }
    }
}
