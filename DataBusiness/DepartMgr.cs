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
        /// 得到所有的部门及ID
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllDepartment()
        {
            sqlHandler sh = new sqlHandler();
            string sql = "select departName, id from department";
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
        /// 得到所有二级部门
        /// </summary>
        /// <returns></returns>
        public static DataTable GetSecondOrder()
        {
            string sql = "select * from department where pid='0'";
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
        /// 得到二级部门属下的三级部门
        /// </summary>
        /// <param name="parent"></param>
        /// <returns></returns>
        public static DataTable GetThirdOrder(string parent)
        {
            string sParent = parent.ToString();
            string sql = string.Format("select * from department where pid='{0}'",sParent);
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
        /// 添加新部门
        /// </summary>
        /// <param name="departId"></param>
        /// <returns>true：成功；fals：失败</returns>
        public static bool Add(string departId,string departName,string pid)
        {
            string sql = string.Format("insert into department values('{0}','{1}','{2}')", departId,departName,pid);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
 
        }
        /// <summary>
        /// 修改部门名称
        /// </summary>
        /// <param name="name"></param>
        /// <param name="departid"></param>
        /// <returns></returns>
        public static bool Update(string name,string departid)
        {
            string sql = string.Format("update department set departName='{0}' where id='{1}' ", name,departid);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
 
        }
        /// <summary>
        /// 删除指定的部门
        /// </summary>
        /// <param name="id">部门id</param>
        /// <returns></returns>
        public static bool Del(string id)
        {
            string sql = string.Format("delete from department where id='{0}' or pid='{0}'", id);
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

        /// <summary>
        /// 得到二级部门数量
        /// </summary>
        /// <returns></returns>
        public static int SecondCount()
        {
            sqlHandler sh = new sqlHandler();
            string sql = "select count(*) from Department where pid='0'";
            DataTable dt = sh.GetData(sql);
            int result = 0;
            if (dt != null)
            {
                result = int.Parse(dt.Rows[0][0].ToString());

            }

            return result;
        }

        /// <summary>
        /// 得到三级部门数量
        /// </summary>
        /// <returns></returns>
        public static int ThirdCount()
        {
            sqlHandler sh = new sqlHandler();
            string sql = "select count(*) from Department where pid!='0'";
            DataTable dt = sh.GetData(sql);
            int result = 0;
            if (dt != null)
            {
                result = int.Parse(dt.Rows[0][0].ToString());

            }

            return result;
        }

        

        /// <summary>
        /// 通过部门名称获取部门编号
        /// </summary>
        /// <param name="departName"></param>
        /// <returns></returns>
        public static string GetIdFromName(string departName)
        {
            sqlHandler sh = new sqlHandler();
            string sql = string.Format("select id from Department where departName='{0}'", departName);
            DataTable dt = sh.GetData(sql);
            string result = "";
            if (dt.Rows.Count>0)
            {
                result = dt.Rows[0][0].ToString();

            }

            return result;
        }


        /// <summary>
        /// 通过部门Id获得部门名称
        /// </summary>
        /// <param name="departId"></param>
        /// <returns></returns>
        public static string GetNameFromId(string departId)
        {
            string sql = string.Format("select departName from Department where id='{0}'", departId);
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            string departName = "";
            if (dt.Rows.Count > 0)
            {

                departName = dt.Rows[0][0].ToString();

            }
            return departName;

        }
    }
}
