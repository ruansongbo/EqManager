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
        /// ������Ա��
        /// </summary>
        /// <param name="emp">Ա��</param>
        /// <returns>true:���ӳɹ���false������ʧ��</returns>
        public static bool Add(Employee emp)
        {
            int id = emp.EmpNo;
            int depart = emp.departId;
            string name = emp.Name;
            string sex = emp.Sex;
            string sql = string.Format("insert into employee values('{0}','{1}',{2})",name,sex,depart);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }
        /// <summary>
        /// ����ĳ���ŵ�����Ա��
        /// </summary>
        /// <param name="deprt">����id</param>
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
        /// �õ�����Ա������Ϣ
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllInfo()
        {
            sqlHandler sh = new sqlHandler();
            string sql = "select a.empid as ����,a.name as ����,a.sex as �Ա�,b.departname as ���ڲ��� from employee a left join department b on (a.departId=b.id)";
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
        /// �޸�Ա����Ϣ
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        public static bool Update(Employee emp)
        {
            int empNo = emp.EmpNo;
            //string id = emp.ID;
            int depart = emp.departId;
            string name = emp.Name;
            string sex = emp.Sex;
            string sql = string.Format("update employee set name='{0}',sex='{1}',departid={2} where empid={3}", name, sex, depart, empNo);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
 
        }
        /// <summary>
        /// ɾ��ָ����Ա��
        /// </summary>
        /// <param name="empNo"></param>
        /// <returns></returns>
        public static int Del(int empNo)
        {
            sqlHandler sh = new sqlHandler();
            string sqlcheckKeeper = string.Format("select Count(*) from keeper where id ={0}", empNo);
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
 
            }
            
            
               

            
            
     
            
        }
        /// <summary>
        /// �õ�ĳһ��Ա������Ϣ
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