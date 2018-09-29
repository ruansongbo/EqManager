using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


using DataAccess;

namespace DataBusiness
{
    public class AddTypeMgr
    {
        /// <summary>
        /// 添加资产类型
        /// </summary>
        /// <param name="type">类型名称</param>
        /// <returns>true：成功；false：失败</returns>
        public static bool Add(string type)
        {
            string sql = string.Format("insert into AddType values('{0}')", type);
            sqlHandler sh=new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0; 
        }
        /// <summary>
        /// 得到所有的资产增长类型
        /// </summary>
        /// <returns>dt：所有增长类型</returns>
        public static DataTable GetAllType()
        {
            string sql = "select * from AddType";
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
        public static bool Del(int id)
        {
            string sql = string.Format("delete from AddType where id={0}", id);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0; 
 
        }
    }
}
