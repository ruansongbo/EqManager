using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


using DataAccess;

namespace DataBusiness
{
    public class CompanyInfoMgr
    {
        /// <summary>
        /// 得到本单位的信息
        /// </summary>
        /// <returns></returns>
        public static DataTable GetInfo()
        {
            string sql = "select * from dbo.CompanyInfo";
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
        /// 修改本单位的信息
        /// </summary>
        /// <param name="name">单位名</param>
        /// <param name="LinkMan">联系人</param>
        /// <param name="address">地址</param>
        /// <returns></returns>
        public static bool update(string name,string LinkMan,string address)
        {
            string sql = string.Format("update CompanyInfo set name='{0}',linkMan='{1}',Address='{2}'",name,LinkMan,address);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }

    }
}
