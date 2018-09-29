using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using DataAccess;

namespace DataBusiness
{
    public class EqTypeMgr
    {
        /// <summary>
        /// �õ����е��ʲ�����
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllType()
        {
            string sql = "select * from type";
            sqlHandler sh=new sqlHandler();
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
        /// ����ʲ�����
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool AddType(string type)
        {
            string sql = string.Format("insert into type values('{0}')", type);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }
        /// <summary>
        /// ɾ���ʲ�����
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool Del(int id)
        {
            string sql = string.Format("delete from type where id={0}", id);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }

    }
}
