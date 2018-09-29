using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using DataAccess;
using DataEntity;

namespace DataBusiness
{
    public class ClearMgr
    {
        /// <summary>
        /// 得到最大可清理数量
        /// </summary>
        /// <param name="eqno"></param>
        /// <returns>-1：没有可清理的资产</returns>
        public static int GetMaxClear(string eqno)
        {
            string sql = string.Format("exec proc_GetMaxCountCanUse '{0}'", eqno);
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            if (dt != null)
            {
                return int.Parse(dt.Rows[0][0].ToString());

            }
            else
            {
                return -1;
            }
        }
        /// <summary>
        /// 清理资产
        /// </summary>
        /// <param name="cl"></param>
        /// <returns></returns>
        public static bool Clear(Clear cl)
        {
            string eqno = cl.EqNo;
            int count = cl.Count;
            string cleartype = cl.ClearType;
            string clearer = cl.Clearer;
            string remark = cl.Mark;
            string date = cl.ClearDate;
            string sql = string.Format("insert into clear values('{0}','{1}','{2}','{3}','{4}','{5}')",eqno,count,cleartype,clearer,date,remark);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;

        }
        /// <summary>
        /// 得到所有的资产清理记录；
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAll()
        {
            string sql = "select id as 流水号,eqno as 资产编号,count as 清理数量,cleartype as 清理方式,clearer as 清理人,clearDate as 清理日期,mark as 备注 from clear";
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;
        }
        /// <summary>
        /// 根据清理时间来模糊查询清理记录
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DataTable GetBydate(string date)
        {
            string sql = string.Format("select id as 流水号,eqno as 资产编号,count as 清理数量,cleartype as 清理方式,clearer as 清理人,clearDate as 清理日期,mark as 备注 from clear where date like '{0}%' ", date);
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;
 
        }
    }
}
