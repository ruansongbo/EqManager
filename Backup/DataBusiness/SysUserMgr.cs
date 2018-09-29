using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

using DataAccess;

namespace DataBusiness
{
    public class SysUserMgr
    {
        /// <summary>
        /// 登路
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public static string Login(string uid, string pass)
        {
            string sql = string.Format("exec proc_login '{0}','{1}' ",uid,pass);
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            if (dt != null)
            {
                return dt.Rows[0][0].ToString();

            }
            else
            {
                return null;
            }
            
        }
        /// <summary>
        /// 得到所有系统操作员的真实姓名，也就是所有的资产清理人
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllName()
        {
            string sql = "select name from syusers";
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;
        }
        /// <summary>
        /// 得到所有用户除了密码以外的信息
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllUser()
        {
            string sql = "select loginname,name from syUsers";
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;
        }
       /// <summary>
        /// 添加新的系统用户
       /// </summary>
       /// <param name="loginname"></param>
       /// <param name="pass"></param>
       /// <param name="name"></param>
       /// <param name="isDefaultPower">是否给新加用户赋默认权限</param>
        /// <returns>-2:添加用户失败；-3:添加用户和赋权都成功；
        ///power:复权所影响的行数；-5;//添加用成功，不赋权</returns>
        public static int Add(string loginname, string pass, string name,bool isDefaultPower)
        {
            sqlHandler sh = new sqlHandler();
            string sql = string.Format("insert into syUsers values('{0}','{1}','{2}')", loginname, pass, name);
            int Adduser=sh.ExecuteNonQuery(sql);//添加用户
            if (Adduser>0)//如果添加成功就检查是否要赋默认权限
            {
                if (isDefaultPower)//如果需要添加默认权限
                {

                    string sqlPower = string.Format("exec Proc_AddPower '{0}'", loginname);
                    int power = sh.ExecuteNonQuery(sqlPower);
                    if (power != -3) //赋默认权限
                    {
                        return power;//添加用户和赋权都成功
                    }
                    else
                    {
                        return -3;//添加用户成功但赋权失败
                    }


                }
                else
                {
                    return -5;//添加用成功，不赋权
 
                }
                
                
            }
            else
            {
                return -2;//添加用户失败
            }
 
        }
        /// <summary>
        /// 删除系统用户
        /// </summary>
        /// <param name="loginname"></param>
        /// <returns></returns>
        public static bool Del(string loginname)
        {
            string sql = string.Format("delete from SyUsers where loginname='{0}'",loginname );
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
 
        }
        /// <summary>
        /// 修改资料（不修改密码）
        /// </summary>
        /// <param name="loginname">登录名</param>
        /// <param name="name">真实姓名</param>
        /// <returns></returns>
        public static bool UpdateNoPass(string loginname, string name)
        {
            string sql = string.Format("update SyUsers set name='{0}' where loginname='{1}'",  name,loginname);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
 
        }
        /// <summary>
        /// 修改资料
        /// </summary>
        /// <param name="loginname">登录名</param>
        /// <param name="oldpass">原密码</param>
        /// <param name="newpass">新密码</param>
        /// <param name="name">真实姓名</param>
        /// <returns></returns>
        public static int UpdatePass(string loginname,string oldpass,string newpass,string name)
        {
            string sql = string.Format("exec proc_UpdateSysUserInfo '{0}','{1}','{2}','{3}'",loginname,oldpass,newpass,name);
            sqlHandler sh = new sqlHandler();
             
            return sh.ExecuteNonQuery(sql) ;
 
        }
        /// <summary>
        /// 得到某用户的权限（用户所能执行的操作）
        /// </summary>
        /// <param name="Loginname"></param>
        /// <returns></returns>
        public static ArrayList GetPower(string Loginname)
        {
            string sql = string.Format("select a.menu_name from Func a inner join [Power] b on(a.menu_id=b.menu_id) where b.UserLoginName='{0}'", Loginname);
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            ArrayList List = new ArrayList();
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    List.Add(dt.Rows[i][0].ToString());
                }
                return List;

            }
            else
            {
                return null;

            }

        }
        /// <summary>
        /// 得到所有得到的用户登录名
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllLoginName()
        {
            string sql = "select loginname from SyUsers ";
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;
 
        }
        /// <summary>
        /// 根据用户登录名得到用户的真实姓名
        /// </summary>
        /// <param name="loginname"></param>
        /// <returns></returns>
        public static string GetANameByLoginName(string loginname)
        {
            string sql =string.Format( "select name from syUsers where loginname='{0}'",loginname);
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt.Rows[0][0].ToString() : "";
 
        }
        /// <summary>
        /// 得到所有功能的列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetFuncList(int parentid)
        {
            string sql = string.Format("select menu_id,menu_desc from Func where parentmenuid={0}", parentid);
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
        /// 得到某用户的权限（用户所能执行的操作）编号
        /// </summary>
        /// <param name="loginname"></param>
        /// <returns></returns>
        public static ArrayList GetOneListByUser(string loginname)
        {
            string sql = string.Format("select menu_id from [power]where menu_id in(select menu_id from Func where parentmenuid!=0 ) and userloginname='{0}'", loginname);
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            ArrayList List = new ArrayList();
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    List.Add(dt.Rows[i][0].ToString());
                }
                return List;

            }
            else
            {
                return null;

            }

        }
        /// <summary>
        /// 添加某一个用户的权限
        /// </summary>
        /// <param name="loginname"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static bool Add(string loginname,int func)
        {
            string sql = string.Format("insert into [power] values('{0}',{1})", loginname,func);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
 
 
        }
        /// <summary>
        /// 删除某一个用户的权限
        /// </summary>
        /// <param name="loginname"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static bool Del(string loginname, int func)
        {
            string sql = string.Format("delete from [power] where userloginname='{0}'and menu_id={1}", loginname, func);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;


        }



    }
}
