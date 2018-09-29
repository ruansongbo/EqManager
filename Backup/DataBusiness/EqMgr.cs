using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Drawing;
using System.Data.SqlClient;

using DataEntity;
using DataAccess;

namespace Equipment_Manager
{
     public class EpMgr
    {
         /// <summary>
         /// �ʲ�����
         /// </summary>
         /// <param name="eq"></param>
         /// <returns>true:�ɹ���false��ʧ��</returns>
        public static bool Add(Equipment eq)
        {
            SqlParameter param1 = new SqlParameter("@eqNo", SqlDbType.VarChar,50);
            param1.Value = eq.EqNo;

            SqlParameter param2 = new SqlParameter("@type", SqlDbType.VarChar, 50);
            param2.Value = eq.Type;

            SqlParameter param3 = new SqlParameter("@name", SqlDbType.VarChar, 50);
            param3.Value = eq.Name;

            SqlParameter param4 = new SqlParameter("@lable", SqlDbType.VarChar, 50);
            param4.Value = eq.Lable;

            SqlParameter param5 = new SqlParameter("@model", SqlDbType.VarChar, 50);
            param5.Value = eq.Model;

            SqlParameter param6 = new SqlParameter("@plus", SqlDbType.VarChar, 50);
            param6.Value = eq.Plus;

            SqlParameter param7 = new SqlParameter("@count", SqlDbType.Int);
            param7.Value = eq.Count;

            SqlParameter param8 = new SqlParameter("@unitt", SqlDbType.VarChar, 50);
            param8.Value = eq.Unit;

            SqlParameter param9 = new SqlParameter("@price", SqlDbType.Money);
            param9.Value = eq.Price;

            SqlParameter param10 = new SqlParameter("@maker", SqlDbType.VarChar, 50);
            param10.Value = eq.Maker;

            SqlParameter param11 = new SqlParameter("@birth", SqlDbType.VarChar, 50);
            param11.Value = eq.Birthday;

            SqlParameter param12 = new SqlParameter("@addtype", SqlDbType.VarChar, 50);
            param12.Value = eq.AddType;

            SqlParameter param13 = new SqlParameter("@keepplace", SqlDbType.VarChar, 50);
            param13.Value = eq.KeepPlace;

            SqlParameter param14 = new SqlParameter("@keeper", SqlDbType.Int);
            param14.Value = eq.Keeper;

            SqlParameter param15 = new SqlParameter("@usetime", SqlDbType.VarChar,50);
            param15.Value = eq.UseTime;

            SqlParameter param16 = new SqlParameter("@booker", SqlDbType.VarChar, 50);
            param16.Value = eq.Booker;

            SqlParameter param17 = new SqlParameter("@bookdatae", SqlDbType.VarChar, 50);
            param17.Value = eq.BookDate;


           byte[] Photo = File.ReadAllBytes(eq.Photo);
            SqlParameter param18 = new SqlParameter("@image", SqlDbType.Image, Photo.Length);
            param18.Value = Photo;
                                                     
            string sql = "insert into equipment values(@eqNo,@type,@name,@lable,@model,@plus,@count,@unitt,@price,@maker,@birth,@addtype,@keepplace,@keeper,@usetime,@booker,@bookdatae,@image)";
            sqlHandler sh=new sqlHandler();
            try
            {
                int result = sh.ExecuteSQL(sql, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14, param15, param16, param17, param18);
                return result > 0;
            }
            catch
            {
                return false;
            }                                                                                                                                                

        }
         public static bool Update(Equipment eq)
         {

             string sql = "";
             if (eq.Photo == "")
             {
                 sql = "update equipment set type=@type,name=@name,label=@lable,model=@model,plus=@plus,count=@count,unit=@unitt,price=@price,maker=@maker,birthday=@birth,addtype=@addtype,keepplace=@keepplace,keeper=@keeper,usetime=@usetime,booker=@booker,boodDate=@bookdatae where eqno=@eqNo";
             }
             else
             {
                 sql = "update equipment set type=@type,name=@name,label=@lable,model=@model,plus=@plus,count=@count,unit=@unitt,price=@price,maker=@maker,birthday=@birth,addtype=@addtype,keepplace=@keepplace,keeper=@keeper,usetime=@usetime,booker=@booker,boodDate=@bookdatae,photo=@photo where eqno=@eqNo";
             }

             SqlParameter param1 = new SqlParameter("@eqNo", SqlDbType.VarChar, 50);
             param1.Value = eq.EqNo;

             SqlParameter param2 = new SqlParameter("@type", SqlDbType.VarChar, 50);
             param2.Value = eq.Type;

             SqlParameter param3 = new SqlParameter("@name", SqlDbType.VarChar, 50);
             param3.Value = eq.Name;

             SqlParameter param4 = new SqlParameter("@lable", SqlDbType.VarChar, 50);
             param4.Value = eq.Lable;

             SqlParameter param5 = new SqlParameter("@model", SqlDbType.VarChar, 50);
             param5.Value = eq.Model;

             SqlParameter param6 = new SqlParameter("@plus", SqlDbType.VarChar, 50);
             param6.Value = eq.Plus;

             SqlParameter param7 = new SqlParameter("@count", SqlDbType.Int);
             param7.Value = eq.Count;

             SqlParameter param8 = new SqlParameter("@unitt", SqlDbType.VarChar, 50);
             param8.Value = eq.Unit;

             SqlParameter param9 = new SqlParameter("@price", SqlDbType.Money);
             param9.Value = eq.Price;

             SqlParameter param10 = new SqlParameter("@maker", SqlDbType.VarChar, 50);
             param10.Value = eq.Maker;

             SqlParameter param11 = new SqlParameter("@birth", SqlDbType.VarChar, 50);
             param11.Value = eq.Birthday;

             SqlParameter param12 = new SqlParameter("@addtype", SqlDbType.VarChar, 50);
             param12.Value = eq.AddType;

             SqlParameter param13 = new SqlParameter("@keepplace", SqlDbType.VarChar, 50);
             param13.Value = eq.KeepPlace;

             SqlParameter param14 = new SqlParameter("@keeper", SqlDbType.Int);
             param14.Value = eq.Keeper;

             SqlParameter param15 = new SqlParameter("@usetime", SqlDbType.VarChar, 50);
             param15.Value = eq.UseTime;

             SqlParameter param16 = new SqlParameter("@booker", SqlDbType.VarChar, 50);
             param16.Value = eq.Booker;

             SqlParameter param17 = new SqlParameter("@bookdatae", SqlDbType.VarChar, 50);
             param17.Value = eq.BookDate;



             SqlParameter param18 = null;
             if (eq.Photo != null)
             {
                 try
                 {
                     byte[] Photo = File.ReadAllBytes(eq.Photo);

                     param18 = new SqlParameter("@photo", SqlDbType.Image, Photo.Length);
                     param18.Value = Photo;
                 }
                 catch
                 {
                     param18 = null;
                 }
 
             }
             sqlHandler sh = new sqlHandler();
             try
             {
                 // ִ�������������������ݼ�¼��
                 //insertCMD.ExecuteNonQuery();
                 if (param18 != null)
                 {
                     int result = sh.ExecuteSQL(sql, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14, param15, param16, param17, param18);
                     return result > 0;
                 }
                 else
                 {
                    int result= sh.ExecuteSQL(sql, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14, param15, param16, param17);
                     return result > 0;
                 }

             }
             catch
             {
                 return false;
             }

         }
        
         /// <summary>
         /// �õ�ĳһ���ʲ��ı������ԣ�������Ϣ��
         /// </summary>
         /// <param name="eqno"></param>
         /// <returns></returns>
         public static DataTable GetOneBaseInfo(string eqno)
         {
             sqlHandler sh = new sqlHandler();
             string sql =string.Format( "select * from view_baseInfo where �ʲ����='{0}'",eqno);
             DataTable dt = sh.GetData(sql);
             return dt != null ? dt : null;
         }
         /// <summary>
         /// �õ���ӵ����һ���ʲ����ʲ����
         /// </summary>
         /// <returns>"":û���ҵ���dt.Rows[0][0].ToString()�����һ���ʲ��ı��</returns>
         public static string GetLastEqNo()
         {
             sqlHandler sh = new sqlHandler();
             string sql = "select top 1 eqNo from Equipment order by eqno desc";
             DataTable dt = sh.GetData(sql);
             if (dt != null)
             {
                 if (dt.Rows.Count != 0)
                 {
                     return dt.Rows[0][0].ToString();
                 }
                 else
                 {
                     return "";
                 }
             }
             else
             {
                 return "";
             }
         }
         /// <summary>
         /// �õ�ĳһ���ʲ�����Ϣ
         /// </summary>
         /// <returns></returns>
         public static DataTable GetOneInfo(string eqno)
         {
             sqlHandler sh = new sqlHandler();
             string sql = string.Format("select eqno,type,name,label,price,birthday,model,plus,keepplace,keeper,maker from Equipment where eqno='{0}'", eqno);
             DataTable dt = sh.GetData(sql);
             return dt != null ? dt : null;

         }
         /// <summary>
         /// ͳ�������ʲ����۾���Ϣ
         /// </summary>
         /// <returns></returns>
         public static DataTable BecomeOld()
         {
             sqlHandler sh = new sqlHandler();
             string sql = "select * from view_BecomeOld";
             DataTable dt = sh.GetData(sql);
             return dt != null ? dt : null;
         }
         /// <summary>
         /// �õ������ʲ���������
         /// </summary>
         /// <returns></returns>
         public static DataTable eqUing()
         {
             string sql = "select * from view_EqUseing";
             sqlHandler sh = new sqlHandler();
             DataTable dt = sh.GetData(sql);
             return dt != null ? dt : null;

         }
         /// <summary>
         /// �õ�ĳһ���ʲ�����ϸ��Ϣ
         /// </summary>
         /// <param name="eqno"></param>
         /// <returns></returns>
         public static DataTable GetOneMostInfo(string  eqno)
         {
             sqlHandler sh = new sqlHandler();
             string sql =string.Format( "select * from Equipment where eqno='{0}'",eqno);
             DataTable dt = sh.GetData(sql);
             return dt != null ? dt : null;

         }
         /// <summary>
         /// �õ��ʲ���Ϣ��������
         /// </summary>
         /// <returns></returns>
         public static int EqCount()
         {
             sqlHandler sh = new sqlHandler();
             string sql = "select count(*) from Equipment";
             DataTable dt = sh.GetData(sql);
             int result = 0;
             if (dt != null)
             {
                 result = int.Parse(dt.Rows[0][0].ToString());

             }

             return result;
         }
         /// <summary>
         /// �õ��ʲ���Ϣ(��ҳ)
         /// </summary>
         /// <param name="start">��ʼҳ</param>
         /// <param name="max">�������</param>
         /// <returns></returns>
         public static DataTable getEqList(int start, int max)
         {
             sqlHandler sh = new sqlHandler();
             string sql = "select * from view_eqInfo select * from view_eqInfo  order by  �ʲ���� desc ";
                 
             DataTable dt = sh.GetDataTable_Page(sql, start, max);
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
         /// ����Ų�ѯ�ʲ���Ϣ
         /// </summary>
         /// <returns></returns>
         public static DataTable GetInfobyEqno(string eqno)
         {
             sqlHandler sh = new sqlHandler();
             string sql = string.Format("select * from view_eqInfo where �ʲ����='{0}'", eqno);
             DataTable dt = sh.GetData(sql);
             return dt != null ? dt : null;

         }
         /// <summary>
         /// ���ʲ�����ѯ�ʲ���Ϣ
         /// </summary>
         /// <param name="type">�������</param>
         /// <returns></returns>
         public static DataTable GetInfobyType(string type)
         {
             sqlHandler sh = new sqlHandler();
             string sql = string.Format("select * from view_eqInfo where �ʲ����='{0}'", type);
             DataTable dt = sh.GetData(sql);
             return dt != null ? dt : null;
 
         }
         /// <summary>
         /// ���ʲ����Ʋ�ѯ�ʲ���Ϣ
         /// </summary>
         /// <param name="name">�ʲ�����</param>
         /// <returns></returns>
         public static DataTable GetInfobyName(string name)
         {
             sqlHandler sh = new sqlHandler();
             string sql = string.Format("select * from view_eqInfo where �ʲ�����='{0}'", name);
             DataTable dt = sh.GetData(sql);
             return dt != null ? dt : null;
 
 
         }
         /// <summary>
         /// ���ʲ�������ʽ��ѯ�ʲ���Ϣ
         /// </summary>
         /// <param name="name">�ʲ�����</param>
         /// <returns></returns>
         public static DataTable GetInfobyAddtype(string addtype)
         {
             sqlHandler sh = new sqlHandler();
             string sql = string.Format("select * from view_eqInfo where ������ʽ='{0}'", addtype);
             DataTable dt = sh.GetData(sql);
             return dt != null ? dt : null;


         }
         /// <summary>
         /// ���ʲ�����ص��ѯ�ʲ���Ϣ
         /// </summary>
         /// <param name="name">�ʲ�����</param>
         /// <returns></returns>
         public static DataTable GetInfobyKeepplace(string place)
         {
             sqlHandler sh = new sqlHandler();
             string sql = string.Format("select * from view_eqInfo where ����ص�='{0}'", place);
             DataTable dt = sh.GetData(sql);
             return dt != null ? dt : null;


         }
         /// <summary>
         /// ���ʲ��Ǽ��˲�ѯ�ʲ���Ϣ
         /// </summary>
         /// <param name="name">�ʲ�����</param>
         /// <returns></returns>
         public static DataTable GetInfobyBooker(string booker)
         {
             sqlHandler sh = new sqlHandler();
             string sql = string.Format("select * from view_eqInfo where ����ص�='{0}'", booker);
             DataTable dt = sh.GetData(sql);
             return dt != null ? dt : null;


         }
    }
}
