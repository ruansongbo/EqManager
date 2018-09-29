using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using DataAccess;

namespace DataBusiness
{
    public class KeepPlaceMgr
    {
        /// <summary>
        /// �õ����еı���ص�
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllPlace()
        {
            string sql = "select * from View_KeepPlace order by ���";
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
        /// ��ӱ���ص�
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool AddPlace(string place)
        {
            string sql = string.Format("insert into KeepPlace values('{0}')", place);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }

        /// <summary>
        /// �޸ı���ص�
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool UpdatePlace(int id,string place)
        {
            string sql = string.Format("update KeepPlace set Place='{1}' where id={0}",id, place);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }

        /// <summary>
        /// ɾ������ص�
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool Del(int id)
        {
            string sql = string.Format("delete from KeepPlace where id={0}", id);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }
    }
}
