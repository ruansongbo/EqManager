using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using DataEntity;
using DataAccess;

namespace DataBusiness
{
    public class EmployeeMgr
    {
        /// <summary>
        /// 添加新员工
        /// </summary>
        /// <param name="emp">员工</param>
        /// <returns>true:添加成功；false：添加失败</returns>
        public static bool Add(Employee emp)
        {
            string id = emp.EmpId;
            string depart = emp.departId;
            string name = emp.Name;
            string sex = emp.Sex;
            string tel = emp.Tel;
            string email = emp.Email;
            string sql = string.Format("insert into employee values('{0}','{1}','{2}','{3}','{4}','{5}')",id,name,depart,sex,tel,email);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }
        /// <summary>
        /// 超找某部门的所有员工
        /// </summary>
        /// <param name="deprt">部门id</param>
        /// <returns></returns>

        public static DataTable GetEmpByDepart(int deprt)
        {
            sqlHandler sh=new sqlHandler();
            string sql = string.Format("select empid,name from employee where departid={0}", deprt);
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
        /// 得到所有员工的姓名
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllName()
        {
            sqlHandler sh = new sqlHandler();
            string sql = "select name, empid from employee";
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
        /// 得到所有员工的信息
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllInfo()
        {
            sqlHandler sh = new sqlHandler();
            string sql = "select a.empid as 工号,a.name as 姓名,a.sex as 性别,b.departname as 所在部门,a.tel as 联系电话,a.email as 电子邮箱 from employee a left join department b on (a.departId=b.id)";
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
        /// 修改员工信息
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        public static bool Update(Employee emp)
        {
            string empNo = emp.EmpId;
            //string id = emp.ID;
            string depart = emp.departId;
            string name = emp.Name;
            string sex = emp.Sex;
            string tel = emp.Tel;
            string email = emp.Email;
            string sql = string.Format("update employee set name='{0}',sex='{1}',departid='{2}',tel='{4}',email='{5}' where empid={3}", name, sex, depart, empNo,tel,email);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
 
        }
        /// <summary>
        /// 删除指定的员工
        /// </summary>
        /// <param name="empNo"></param>
        /// <returns></returns>
        public static int Del(string empNo)
        {
            sqlHandler sh = new sqlHandler();
            /*string sqlcheckKeeper = string.Format("select Count(*) from keeper where id ={0}", empNo);
            if (int.Parse(sh.GetData(sqlcheckKeeper).Rows[0][0].ToString()) == 0)
            {
                string sqlcheck = string.Format("select count(*)from Borrow where Borrwer={0}", empNo);
                if (int.Parse(sh.GetData(sqlcheck).Rows[0][0].ToString()) == 0)
                {
                    string sqlDel = string.Format("delete from employee where empid={0}", empNo);
                    return sh.ExecuteNonQuery(sqlDel);
                }
                else
                {
                    return -2;
 
                }
                
            }
            else
            {
                return -1;
 
            }*/

            string sqlcheckSyUsers = string.Format("select Count(*) from SyUsers where id ='{0}'", empNo);
            if (int.Parse(sh.GetData(sqlcheckSyUsers).Rows[0][0].ToString()) == 0)
            {
                string sqlDel = string.Format("delete from employee where empid='{0}'", empNo);
                return sh.ExecuteNonQuery(sqlDel);
            }
            return -1;
            
     
            
        }
        /// <summary>
        /// 得到某一个员工的信息
        /// </summary>
        /// <param name="empid"></param>
        /// <returns></returns>
        public static DataTable GetOneEmp(int empid)
        {
            string sql = string.Format("select * from employee where empid={0}", empid);
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;
        }


    }
}
