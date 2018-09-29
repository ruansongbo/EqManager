using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using DataAccess;

namespace DataBusiness
{
    public class UnitMgr
    {
        /// <summary>
        /// 得到所有的计量单位
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAll()
        {
            string sql = "select * from unit";
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            if (dt != null)
            {
                return dt;
            }
            else
            {
                return null;
            }

        }
        /// <summary>
        /// 添加计量单位
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool Add(string unit)
        {
            string sql = string.Format("insert into unit values('{0}')",unit);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql)>0;
        }
        /// <summary>
        /// 删除计量单位
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool Del(int id)
        {
            string sql = string.Format("delete from unit where id={0}", id);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }
    }
}
