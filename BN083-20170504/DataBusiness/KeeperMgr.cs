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
       /// 查询所有的保管人员
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
       /// 添加保管人员
       /// </summary>
       /// <param name="empid">工号</param>
       /// <param name="name">姓名</param>
       /// <returns></returns>
       public static bool Add(int empid,string name)
       {
           string sql = string.Format("Insert into keeper values({0},'{1}')",empid,name);
           sqlHandler sh = new sqlHandler();
           return sh.ExecuteNonQuery(sql) > 0;

       }
       /// <summary>
       /// 删除指定的保管人
       /// </summary>
       /// <param name="id">工号</param>
       /// <returns></returns>
       public static int Del(int id)
       {
           sqlHandler sh = new sqlHandler();
           string sqlcheck = string.Format("exec proc_DelKeeper {0}", id);
           string sqldel = string.Format("delete from keeper where id={0}", id); 
           if ( sh.ExecuteNonQuery(sqlcheck) ==-1)//判断是否还保管资产
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
