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
        /// ��¼
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
        /// �õ�����ϵͳ����Ա����ʵ������Ҳ�������е��ʲ�������
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
        /// �õ������û����������������Ϣ
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
        /// ���ݵ�¼id��ȡ����
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
        /// ���ݵ�¼ID��ȡ������Ϣ
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
        /// ����µ�ϵͳ�û�
       /// </summary>
       /// <param name="loginid"></param>
       /// <param name="pass"></param>
       /// <param name="name"></param>
       /// <param name="isDefaultPower">�Ƿ���¼��û���Ĭ��Ȩ��</param>
        /// <returns>-2:����û�ʧ�ܣ�-3:����û��͸�Ȩ���ɹ���
        ///power:��Ȩ��Ӱ���������-5;//����óɹ�������Ȩ</returns>
        public static int Add(string loginid, string pass, string name,string departId,string tel,string email,string power)
        {
            sqlHandler sh = new sqlHandler();
            string sql = string.Format("insert into syUsers values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", loginid, pass, name,departId,tel,email,power);
            int Adduser=sh.ExecuteNonQuery(sql);//����û�
            if (Adduser>0)//�����ӳɹ��͸�Ĭ��Ȩ��
            {
                string sqlPower = string.Format("exec Proc_AddPower '{0}','{1}'", loginid,power);
                int result = sh.ExecuteNonQuery(sqlPower);
                /*if (power != -2) //��Ĭ��Ȩ��
                {
                    return result;//����û��͸�Ȩ���ɹ�
                }
                else
                {
                    return -2;//����û��ɹ�����Ȩʧ��
                }*/
               
            }
            else
            {
                return -1;//����û�ʧ��
            }
            return 0;
 
        }
        /// <summary>
        /// ɾ��ϵͳ�û�
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
        /// �޸����ϣ����޸����룩
        /// </summary>
        /// <param name="loginid">��¼��</param>
        /// <param name="name">��ʵ����</param>
        /// <returns></returns>
        public static bool UpdateNoPass(string loginid, string name, string tel, string email, string departid)
        {
            string sql = string.Format("update SyUsers set loginname='{0}' ,tel='{1}',email='{2}',DepartId='{3}' where id='{4}'",  name,tel,email,departid,loginid);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
 
        }
        /// <summary>
        /// �޸�����
        /// </summary>
        /// <param name="loginid">��¼��</param>
        /// <param name="oldpass">ԭ����</param>
        /// <param name="newpass">������</param>
        /// <param name="name">��ʵ����</param>
        /// <returns></returns>
        public static int UpdatePass(string loginid,string oldpass,string newpass,string name,string tel,string email,string departid )
        {
            string sql = string.Format("exec proc_UpdateSysUserInfo '{0}','{1}','{2}','{3}','{4}','{5}','{6}'",loginid,oldpass,newpass,name,tel,email,departid);
            sqlHandler sh = new sqlHandler();
             
            return sh.ExecuteNonQuery(sql) ;
 
        }
        /// <summary>
        /// �õ�ĳ�û���Ȩ�ޣ��û�����ִ�еĲ�����
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
        /// �õ����еõ����û���¼��
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
        /// �����û���¼���õ��û�����ʵ����
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
        /// �õ����й��ܵ��б�
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
        /// �õ�ĳ�û���Ȩ�ޣ��û�����ִ�еĲ��������
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
        /// ���ĳһ���û���Ȩ��
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
        /// ɾ��ĳһ���û���Ȩ��
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
        /// �õ����û�����ID
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
