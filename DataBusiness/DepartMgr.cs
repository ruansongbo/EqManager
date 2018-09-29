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
        /// �õ����еĲ��ż�ID
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
        /// �õ����ж�������
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
        /// �õ������������µ���������
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
        /// ����²���
        /// </summary>
        /// <param name="departId"></param>
        /// <returns>true���ɹ���fals��ʧ��</returns>
        public static bool Add(string departId,string departName,string pid)
        {
            string sql = string.Format("insert into department values('{0}','{1}','{2}')", departId,departName,pid);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
 
        }
        /// <summary>
        /// �޸Ĳ�������
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
        /// ɾ��ָ���Ĳ���
        /// </summary>
        /// <param name="id">����id</param>
        /// <returns></returns>
        public static bool Del(string id)
        {
            string sql = string.Format("delete from department where id='{0}' or pid='{0}'", id);
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

        /// <summary>
        /// �õ�������������
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
        /// �õ�������������
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
        /// ͨ���������ƻ�ȡ���ű��
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
        /// ͨ������Id��ò�������
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
