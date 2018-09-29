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
        /// �õ����е��ʲ�����
        /// </summary>
        /// <returns>dt�����е����ƣ�null</returns>
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
        /// ����ʲ�����
        /// </summary>
        /// <param name="name"></param>
        /// <returns>true����ӳɹ���false�����ʧ��</returns>
        public static bool AddName(string name)
        {
            string sql = string.Format("insert into eqname values('{0}')", name);
            sqlHandler sh=new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }
        /// <summary>
        /// ɾ���ʲ�����
        /// </summary>
        /// <param name="name"></param>
        /// <returns>true��ɾ���ɹ���false��ɾ��ʧ��</returns>
        public static bool Del(int id)
        {
            string sql = string.Format("delete from eqname where id={0}", id);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }

    }
}
