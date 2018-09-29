using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataAccess;

namespace DataBusiness
{
    public class EqNameMgr
    {
        /// <summary>
        /// 得到所有的资产名称
        /// </summary>
        /// <returns>dt：所有的名称；null</returns>
        public static DataTable GetAllEqname()
        {
            string sql = "select * from eqname";
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
        /// 添加资产名称
        /// </summary>
        /// <param name="name"></param>
        /// <returns>true：添加成功；false：添加失败</returns>
        public static bool AddName(string name)
        {
            string sql = string.Format("insert into eqname values('{0}')", name);
            sqlHandler sh=new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }
        /// <summary>
        /// 删除资产名称
        /// </summary>
        /// <param name="name"></param>
        /// <returns>true：删除成功；false：删除失败</returns>
        public static bool Del(int id)
        {
            string sql = string.Format("delete from eqname where id={0}", id);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }

    }
}
