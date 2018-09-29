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
        /// ����ʲ�����
        /// </summary>
        /// <param name="type">��������</param>
        /// <returns>true���ɹ���false��ʧ��</returns>
        public static bool Add(string type)
        {
            string sql = string.Format("insert into AddType values('{0}')", type);
            sqlHandler sh=new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0; 
        }
        /// <summary>
        /// �õ����е��ʲ���������
        /// </summary>
        /// <returns>dt��������������</returns>
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
