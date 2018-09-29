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
        /// 登录
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public static string[] Login(string uid, string pass)
        {
            string sql = string.Format("exec proc_login '{0}','{1}' ",uid,pass);
            string[] sydata = { "", "", "" }; 
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            if (dt!=null)
            {
                for (int i = 0; i < 3; i++)
                {
                    sydata[i]=dt.Rows[0][i].ToString();
                }
                return sydata;
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
            string sql = "select LoginName from syusers";
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
            string sql = "select id,loginname from syUsers";
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;
        }

        /// <summary>
        /// 根据登录id获取密码
        /// </summary>
        /// <param name="loginid"></param>
        /// <returns></returns>
        public static string GetPass(string loginid)
        {
            string sql = string.Format("select LoginPWD from syUsers where ID='{0}'",loginid);
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            if (dt.Rows.Count != 0)
            {
                return dt.Rows[0][0].ToString();
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 根据登录ID获取其他信息
        /// </summary>
        /// <param name="loginid"></param>
        /// <returns></returns>
        public static DataTable GetOneUser(string loginid)
        {
            string sql = string.Format("select * from syUsers where id='{0}'",loginid);
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;
        }
       /// <summary>
        /// 添加新的系统用户
       /// </summary>
       /// <param name="loginid"></param>
       /// <param name="pass"></param>
       /// <param name="name"></param>
       /// <param name="isDefaultPower">是否给新加用户赋默认权限</param>
        /// <returns>-2:添加用户失败；-3:添加用户和赋权都成功；
        ///power:复权所影响的行数；-5;//添加用成功，不赋权</returns>
        public static int Add(string loginid, string pass, string name,string departId,string tel,string email,string power)
        {
            sqlHandler sh = new sqlHandler();
            string sql = string.Format("insert into syUsers values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", loginid, pass, name,departId,tel,email,power);
            int Adduser=sh.ExecuteNonQuery(sql);//添加用户
            if (Adduser>0)//如果添加成功就赋默认权限
            {
                string sqlPower = string.Format("exec Proc_AddPower '{0}','{1}'", loginid,power);
                int result = sh.ExecuteNonQuery(sqlPower);
                /*if (power != -2) //赋默认权限
                {
                    return result;//添加用户和赋权都成功
                }
                else
                {
                    return -2;//添加用户成功但赋权失败
                }*/
               
            }
            else
            {
                return -1;//添加用户失败
            }
            return 0;
 
        }
        /// <summary>
        /// 删除系统用户
        /// </summary>
        /// <param name="loginid"></param>
        /// <returns></returns>
        public static bool Del(string loginid)
        {
            string sql = string.Format("delete from SyUsers where id='{0}'",loginid );
            string powersql = string.Format("delete from [Power] where loginid='{0}'", loginid);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0 && sh.ExecuteNonQuery(powersql)>0;
 
        }
        /// <summary>
        /// 修改资料（不修改密码）
        /// </summary>
        /// <param name="loginid">登录名</param>
        /// <param name="name">真实姓名</param>
        /// <returns></returns>
        public static bool UpdateNoPass(string loginid, string name, string tel, string email, string departid)
        {
            string sql = string.Format("update SyUsers set loginname='{0}' ,tel='{1}',email='{2}',DepartId='{3}' where id='{4}'",  name,tel,email,departid,loginid);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
 
        }
        /// <summary>
        /// 修改资料
        /// </summary>
        /// <param name="loginid">登录名</param>
        /// <param name="oldpass">原密码</param>
        /// <param name="newpass">新密码</param>
        /// <param name="name">真实姓名</param>
        /// <returns></returns>
        public static int UpdatePass(string loginid,string oldpass,string newpass,string name,string tel,string email,string departid )
        {
            string sql = string.Format("exec proc_UpdateSysUserInfo '{0}','{1}','{2}','{3}','{4}','{5}','{6}'",loginid,oldpass,newpass,name,tel,email,departid);
            sqlHandler sh = new sqlHandler();
             
            return sh.ExecuteNonQuery(sql) ;
 
        }
        /// <summary>
        /// 得到某用户的权限（用户所能执行的操作）
        /// </summary>
        /// <param name="Loginname"></param>
        /// <returns></returns>
        public static ArrayList GetPower(string LoginID)
        {
            string sql = string.Format("select a.menu_name from Func a inner join [Power] b on(a.menu_id=b.menu_id) where b.LoginID='{0}'", LoginID);
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
        public static string GetIdByLoginName(string loginname)
        {
            string sql =string.Format( "select ID from syUsers where loginname='{0}'",loginname);
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
        /// <param name="loginid"></param>
        /// <returns></returns>
        public static ArrayList GetOneListByUser(string loginid)
        {
            string sql = string.Format("select menu_id from [power]where menu_id in(select menu_id from Func where parentmenuid!=0 ) and LoginID='{0}'", loginid);
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
        /// <param name="loginid"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static bool Add(string loginid,int func)
        {
            string sql = string.Format("insert into [power] values('{0}',{1})", loginid,func);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
 
 
        }
        /// <summary>
        /// 删除某一个用户的权限
        /// </summary>
        /// <param name="loginid"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static bool Del(string loginid, int func)
        {
            string sql = string.Format("delete from [power] where LoginId='{0}'and menu_id={1}", loginid, func);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;


        }
        /// <summary>
        /// 得到的用户部门ID
        /// </summary>
        /// <returns></returns>
        public static string GetDepartmentIDByUser(string user)
        {
            string sql = string.Format("select DepartId from SyUsers where LoginName='{0}'", user);
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt.Rows[0][0].ToString() : "";

        }


       
    }
}
