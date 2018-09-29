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
        /// 得到所有的部门
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
        /// 添加新部门
        /// </summary>
        /// <param name="depart"></param>
        /// <returns>true：成功；fals：失败</returns>
        public static bool Add(string depart)
        {
            string sql = string.Format("insert into department values('{0}')", depart);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
 
        }
        /// <summary>
        /// 修改部门名称
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
        /// 删除指定的部门
        /// </summary>
        /// <param name="id">部门id</param>
        /// <returns></returns>
        public static bool Del(int id)
        {
            string sql = string.Format("delete from department where id={0}", id);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
            
            
        }
        /// <summary>
        /// 得到所有有员工的部门
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
