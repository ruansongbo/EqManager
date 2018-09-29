using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using DataAccess;
using DataEntity;


namespace DataBusiness
{
    public class RecordMgr
    {
        
        
        /// <summary>
        /// 得到所有的监控记录
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAll()
        {
            string sql = "select * from view_Record";
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;

        }

        /// <summary>
        /// 得到该用户未处理的信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static DataTable GetToDo(string user)
        {
            string sql = string.Format("exec proc_GetToDo '{0}'", user);
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            
            return dt != null ? dt : null;
        }

        /// <summary>
        /// 得到未处理信息条数
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int GetToDoCount(string user)
        {
            string sql = string.Format("exec proc_GetToDo '{0}'", user);
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);

            return dt.Rows.Count;
        }

        public static void Sign(string serialNo)
        {
            string sql = string.Format("exec proc_Sign '{0}'", serialNo);
            sqlHandler sh = new sqlHandler();
            sh.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 添加监控记录
        /// </summary>
        /// <param name="rd"></param>
        /// <returns></returns>
        public static bool AddRecord(Record rd)
        {
            string serialNo=rd.SerialNo;
            string epc=rd.EPC;
            string keepPlace=rd.KeepPlace;
            string mtNo=rd.MtNo;
            string time=rd.Time;
            string activity=rd.Activity;
            int processor=rd.Processor;
            string done = rd.Done;

            string sql =string.Format( "exec proc_RecordAdd '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}'",
                serialNo,epc,keepPlace,mtNo,time,activity,processor,done);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }


        /// <summary>
        /// 得到监控记录表最后一行的流水号
        /// </summary>
        /// <returns></returns>
        public static string GetLastNo()
        {
            string sql = "select top 1  serialNo  from Record order by serialNo desc";
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            return dt != null ? (dt.Rows[0][0].ToString()) :"";
        }
    }
}
