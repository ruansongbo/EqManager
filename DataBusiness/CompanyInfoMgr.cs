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
        /// �õ�����λ����Ϣ
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
        /// �޸ı���λ����Ϣ
        /// </summary>
        /// <param name="name">��λ��</param>
        /// <param name="LinkMan">��ϵ��</param>
        /// <param name="address">��ַ</param>
        /// <returns></returns>
        public static bool update(string name,string LinkMan,string address)
        {
            string sql = string.Format("update CompanyInfo set name='{0}',linkMan='{1}',Address='{2}'",name,LinkMan,address);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }

    }
}
