using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace DataBusiness
{
    public class DgvMgr
    {
        /// <summary>
        /// 将dataGridView内容转成dataTable
        /// </summary>
        /// <param name="dgv"></param>
        /// <returns></returns>
        public static DataTable GetTable(DataGridView dgv)
        {
            DataTable dt = new DataTable();
            for (int count = 0; count < dgv.Columns.Count; count++)
            {
                DataColumn dc = new DataColumn(dgv.Columns[count].Name.ToString());
                dt.Columns.Add(dc);
            }
            for (int row = 0; row < dgv.Rows.Count; row++)
            {
                DataRow dr = dt.NewRow();
                for (int column = 0; column < dgv.Columns.Count; column++)
                {
                    dr[column] = Convert.ToString(dgv.Rows[row].Cells[column].Value);
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        /// <summary>
        /// 按照类型将DataGridView的内容筛选为DataTable
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="ppy">所要筛选的属性数组</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public static DataTable GetTable(DataGridView dgv, List<string> headers,string type)
        {
            DataTable dt = new DataTable();
            DataColumn dc;
            DataRow dr;

            //过滤用的字符串，比headers多的一列是“单号”，单号是过滤的依据
            string[] filter = new string[headers.Count + 1];

            //如果表头长度只为1，则直接返回一个空的dataTable
            if (headers.Count==1)
                return dt;
            //根据属性生成表头
            for (int count = 0; count < headers.Count; count++)
            {
                filter[count] = headers[count];
                dc = new DataColumn(headers[count]);
                dt.Columns.Add(dc);
            }
            //filter最后一列
            filter[headers.Count] = "单号";
            dc = new DataColumn("单号");
            dt.Columns.Add(dc);

            for (int row = 0; row < dgv.Rows.Count; row++)
            {
                if (dgv["资产类别",row].Value.ToString() != type)
                    continue;
                dr = dt.NewRow();
                for(int index=0;index<filter.Length;index++)
                    for (int column = 0; column < dgv.Columns.Count; column++)
                    {
                        if(dgv.Columns[column].HeaderText==filter[index])
                            dr[index] = Convert.ToString(dgv.Rows[row].Cells[column].Value);
                    }
                //总表里是没有数量这一列的，需要自行添加
                dr["数量"] = EqMgr.AssetCount(dr["单号"].ToString()).ToString();
                dt.Rows.Add(dr);
            }

            //根据单号去重
            dt = GetDistinctSelf(dt, "单号");
            dt.Columns.Remove("单号");
            return dt;
        }

        public static DataTable GetTable(DataTable dtsource, List<string> headers, string type)
        {
            DataTable dtInNeed=new DataTable();
            DataTable dtThisType = new DataTable();
            DataRow dr;


            //过滤用的字符串，比headers多的一列是“单号”，单号是过滤的依据
            string[] filter = new string[headers.Count + 1];

            //如果表头长度只为1，则直接返回一个空的dataTable
            if (headers.Count == 1)
                return dtInNeed;

            for (int count = 0; count < headers.Count; count++)
            {
                filter[count] = headers[count];
            }
            //filter最后一列
            filter[headers.Count] = "单号";


            //这一步是为了将dtsource的列名直接赋给dtThisType，缺少这一步的话dtThisType是没有列名的，也不能筛选
            dtThisType = dtsource.Clone();
            dtThisType.Clear();

            for (int index = 0; index < dtsource.Rows.Count; index++)
            {
                if (dtsource.Rows[index]["资产类别"].ToString() != type)
                    continue;
                dr = dtsource.Rows[index];
                dr["数量"] = EqMgr.AssetCount(dtsource.Rows[index]["单号"].ToString());
                dtThisType.ImportRow(dr);
            }

            dtInNeed = GetFilterTable(dtThisType, filter);

            dtInNeed = GetDistinctSelf(dtInNeed, "单号");
            dtInNeed.Columns.Remove("单号");

            return dtInNeed;
        }

        /// <summary>
        /// 将选中的行的内容转换成DataTable
        /// </summary>
        /// <param name="dgv"></param>
        /// <returns></returns>
        public static DataTable GetSelectedTable(DataGridView dgv)
        {
            DataTable dt = new DataTable();
            int rindex = 0;
            for (int count = 0; count < dgv.Columns.Count; count++)
            {
                DataColumn dc = new DataColumn(dgv.Columns[count].Name.ToString());
                dt.Columns.Add(dc);
            }
            for (int row = 0; row < dgv.SelectedRows.Count; row++)
            {
                rindex = dgv.SelectedRows[row].Index;
                DataRow dr = dt.NewRow();
                for (int column = 0; column < dgv.Columns.Count; column++)
                {
                    dr[column] = Convert.ToString(dgv.Rows[rindex].Cells[column].Value);
                }
                dt.Rows.Add(dr);
            }


            return dt;
        }

        /// <summary>
        /// 将选中的DataGridView按照资产类别转换为DataTable
        /// </summary>
        /// <param name="dgv">所要转换的DataGridView</param>
        /// <param name="headers">DataTable表头</param>
        /// <param name="type">资产类别</param>
        /// <returns></returns>
        public static DataTable GetSelectedTable(DataGridView dgv, List<string> headers, string type)
        {
            DataTable dt = new DataTable();
            DataColumn dc;
            DataRow dr;

            //过滤用的字符串，比headers多的一列是“单号”，单号是过滤的依据
            string[] filter = new string[headers.Count + 1];

            //如果属性数组长度只为1，则直接返回一个空的dataTable
            if (headers.Count == 1)
                return dt;
            //根据属性生成表头
            for (int count = 0; count < headers.Count; count++)
            {
                filter[count] = headers[count];
                dc = new DataColumn(headers[count]);
                dt.Columns.Add(dc);
            }
            //filter最后一列
            filter[headers.Count] = "单号";
            dc = new DataColumn("单号");
            dt.Columns.Add(dc);

            for (int row = 0; row < dgv.SelectedRows.Count; row++)
            {
                if (dgv.SelectedRows[row].Cells["资产类别"].Value.ToString() != type)
                    continue;
                dr = dt.NewRow();
                for (int index = 0; index < filter.Length; index++)
                    for (int column = 0; column < dgv.Columns.Count; column++)
                    {
                        if (dgv.Columns[column].HeaderText == filter[index])
                            dr[index] = Convert.ToString(dgv.SelectedRows[row].Cells[column].Value);
                    }
                //总表里是没有数量这一列的，需要自行添加
                dr["数量"] = EqMgr.AssetCount(dr["单号"].ToString()).ToString();
                dt.Rows.Add(dr);
            }

            //根据单号去重
            dt = GetDistinctSelf(dt, "单号");
            dt.Columns.Remove("单号");
            return dt;
        }


        /// <summary>
        /// DataTable 去重
        /// </summary>
        /// <param name="SourceDt"></param>
        /// <param name="filedName"></param>
        /// <returns></returns>
        public static DataTable GetDistinctSelf(DataTable SourceDt, string filedName)
        {
            for (int i = SourceDt.Rows.Count - 2; i > 0; i--)
            {
                DataRow[] rows = SourceDt.Select(string.Format("{0}='{1}'", filedName, SourceDt.Rows[i][filedName]));
                if (rows.Length > 1)
                {
                    SourceDt.Rows.RemoveAt(i);
                }
            }
            return SourceDt;


        }

        /// <summary>
        /// datatable筛选
        /// </summary>
        /// <param name="dtSource"></param>
        /// <param name="columnNames"></param>
        /// <returns></returns>
        public static DataTable GetFilterTable(DataTable dtSource, string[] columnNames)
        {
            DataTable distinctTable = dtSource.Clone();
            try
            {
                if (dtSource != null && dtSource.Rows.Count > 0)
                {
                    DataView dv = new DataView(dtSource);
                    distinctTable = dv.ToTable(false, columnNames);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            return distinctTable;
        }


    }
}
