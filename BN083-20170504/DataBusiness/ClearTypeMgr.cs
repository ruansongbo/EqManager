using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using DataAccess;

namespace DataBusiness
{
    public class ClearTypeMgr
    {
        /// <summary>
        /// ����ʲ�����ʽ
        /// </summary>
        /// <param name="type">��������</param>
        /// <returns>true���ɹ���false��ʧ��</returns>
        public static bool Add(string type)
        {
            string sql = string.Format("insert into clearType values('{0}')", type);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }
        /// <summary>
        /// �õ����е��ʲ�����ʽ
        /// </summary>
        /// <returns>dt��������������</returns>
        public static DataTable GetAll()
        {
            string sql = "select * from clearType";
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
        /// ɾ��ָ��������ʽ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Del(int id)
        {
            string sql = string.Format("delete from clearType where id={0}", id);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }
    }
}
