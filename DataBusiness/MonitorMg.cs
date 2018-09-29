using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using DataAccess;
using DataEntity;


namespace DataBusiness
{
    public class MonitorMgr
    {
        
        /// <summary>
        /// 添加监控设备
        /// </summary>
        /// <param name="br"></param>
        /// <returns></returns>
        public static bool Add(Monitor mt)
        {
            int mtNo = mt.MtNo;
            string place = mt.Place;
            int doNo = mt.DoNo;
            string ip = mt.IP;
            string status = mt.Status;
            string sql = string.Format("insert into Monitor values({0},'{1}',{2},'{3}','{4}')", mtNo, place, doNo, ip, status);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }
        
        /// <summary>
        /// 得到所有的监控设备信息
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAll()
        {
            string sql = "select * from view_Monitor";
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;

        }
        
    }
}
