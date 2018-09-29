using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using DataAccess;

namespace DataBusiness
{
   public class KeeperMgr
    {
       /// <summary>
       /// ��ѯ���еı�����Ա
       /// </summary>
       /// <returns></returns>
       public static DataTable GetAll()
       {
           string sql = "select * from keeper";
           sqlHandler sh = new sqlHandler();
           DataTable dt = sh.GetData(sql);
           return dt!=null?dt:null;
       }
       /// <summary>
       /// ��ӱ�����Ա
       /// </summary>
       /// <param name="empid">����</param>
       /// <param name="name">����</param>
       /// <returns></returns>
       public static bool Add(int empid,string name)
       {
           string sql = string.Format("Insert into keeper values({0},'{1}')",empid,name);
           sqlHandler sh = new sqlHandler();
           return sh.ExecuteNonQuery(sql) > 0;

       }
       /// <summary>
       /// ɾ��ָ���ı�����
       /// </summary>
       /// <param name="id">����</param>
       /// <returns></returns>
       public static int Del(int id)
       {
           sqlHandler sh = new sqlHandler();
           string sqlcheck = string.Format("exec proc_DelKeeper {0}", id);
           string sqldel = string.Format("delete from keeper where id={0}", id); 
           if ( sh.ExecuteNonQuery(sqlcheck) ==-1)//�ж��Ƿ񻹱����ʲ�
           {
               return -1;
               
           }
           else
           {
               return sh.ExecuteNonQuery(sqldel);

           } 
       }
    }
}
