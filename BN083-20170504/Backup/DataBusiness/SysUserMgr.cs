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
        /// ��·
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
        /// �õ�����ϵͳ����Ա����ʵ������Ҳ�������е��ʲ�������
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
        /// �õ������û����������������Ϣ
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
        /// ����µ�ϵͳ�û�
       /// </summary>
       /// <param name="loginname"></param>
       /// <param name="pass"></param>
       /// <param name="name"></param>
       /// <param name="isDefaultPower">�Ƿ���¼��û���Ĭ��Ȩ��</param>
        /// <returns>-2:����û�ʧ�ܣ�-3:����û��͸�Ȩ���ɹ���
        ///power:��Ȩ��Ӱ���������-5;//����óɹ�������Ȩ</returns>
        public static int Add(string loginname, string pass, string name,bool isDefaultPower)
        {
            sqlHandler sh = new sqlHandler();
            string sql = string.Format("insert into syUsers values('{0}','{1}','{2}')", loginname, pass, name);
            int Adduser=sh.ExecuteNonQuery(sql);//����û�
            if (Adduser>0)//�����ӳɹ��ͼ���Ƿ�Ҫ��Ĭ��Ȩ��
            {
                if (isDefaultPower)//�����Ҫ���Ĭ��Ȩ��
                {

                    string sqlPower = string.Format("exec Proc_AddPower '{0}'", loginname);
                    int power = sh.ExecuteNonQuery(sqlPower);
                    if (power != -3) //��Ĭ��Ȩ��
                    {
                        return power;//����û��͸�Ȩ���ɹ�
                    }
                    else
                    {
                        return -3;//����û��ɹ�����Ȩʧ��
                    }


                }
                else
                {
                    return -5;//����óɹ�������Ȩ
 
                }
                
                
            }
            else
            {
                return -2;//����û�ʧ��
            }
 
        }
        /// <summary>
        /// ɾ��ϵͳ�û�
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
        /// �޸����ϣ����޸����룩
        /// </summary>
        /// <param name="loginname">��¼��</param>
        /// <param name="name">��ʵ����</param>
        /// <returns></returns>
        public static bool UpdateNoPass(string loginname, string name)
        {
            string sql = string.Format("update SyUsers set name='{0}' where loginname='{1}'",  name,loginname);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
 
        }
        /// <summary>
        /// �޸�����
        /// </summary>
        /// <param name="loginname">��¼��</param>
        /// <param name="oldpass">ԭ����</param>
        /// <param name="newpass">������</param>
        /// <param name="name">��ʵ����</param>
        /// <returns></returns>
        public static int UpdatePass(string loginname,string oldpass,string newpass,string name)
        {
            string sql = string.Format("exec proc_UpdateSysUserInfo '{0}','{1}','{2}','{3}'",loginname,oldpass,newpass,name);
            sqlHandler sh = new sqlHandler();
             
            return sh.ExecuteNonQuery(sql) ;
 
        }
        /// <summary>
        /// �õ�ĳ�û���Ȩ�ޣ��û�����ִ�еĲ�����
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
        public static string GetANameByLoginName(string loginname)
        {
            string sql =string.Format( "select name from syUsers where loginname='{0}'",loginname);
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
        /// ���ĳһ���û���Ȩ��
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
        /// ɾ��ĳһ���û���Ȩ��
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
