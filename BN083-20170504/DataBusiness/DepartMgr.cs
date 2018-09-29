using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using DataAccess;

namespace DataBusiness
{
    public class DepartMgr
    {
        /// <summary>
        /// �õ����еĲ���
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAll()
        {
            string sql = "select * from department";
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
        /// ����²���
        /// </summary>
        /// <param name="depart"></param>
        /// <returns>true���ɹ���fals��ʧ��</returns>
        public static bool Add(string depart)
        {
            string sql = string.Format("insert into department values('{0}')", depart);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
 
        }
        /// <summary>
        /// �޸Ĳ�������
        /// </summary>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Update(string name,int id)
        {
            string sql = string.Format("update department set departname='{0}' where id={1} ", name,id);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
 
        }
        /// <summary>
        /// ɾ��ָ���Ĳ���
        /// </summary>
        /// <param name="id">����id</param>
        /// <returns></returns>
        public static bool Del(int id)
        {
            string sql = string.Format("delete from department where id={0}", id);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
            
            
        }
        /// <summary>
        /// �õ�������Ա���Ĳ���
        /// </summary>
        /// <returns></returns>
        public static DataTable Getdepart()
        {
            string sql = "select id,departname from department where id in (select departid from employee) ";
            sqlHandler sh = new sqlHandler();
            DataTable dt=sh.GetData(sql);
            return dt != null ? dt : null;
        }
    }
}
