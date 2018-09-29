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
         /// 资产增长
         /// </summary>
         /// <param name="eq"></param>
         /// <returns>true:成功；false：失败</returns>
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
                 // 执行数据命令来新增数据记录。
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
         /// 得到某一笔资产的本身属性（基本信息）
         /// </summary>
         /// <param name="eqno"></param>
         /// <returns></returns>
         public static DataTable GetOneBaseInfo(string eqno)
         {
             sqlHandler sh = new sqlHandler();
             string sql =string.Format( "select * from view_baseInfo where 资产编号='{0}'",eqno);
             DataTable dt = sh.GetData(sql);
             return dt != null ? dt : null;
         }
         /// <summary>
         /// 得到添加的最后一笔资产的资产编号
         /// </summary>
         /// <returns>"":没有找到；dt.Rows[0][0].ToString()：最后一笔资产的编号</returns>
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
         /// 得到某一笔资产的信息
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
         /// 统计所有资产的折旧信息
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
         /// 得到各比资产的利用率
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
         /// 得到某一笔资产的详细信息
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
         /// 得到资产信息的总条数
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
         /// 得到资产信息(分页)
         /// </summary>
         /// <param name="start">起始页</param>
         /// <param name="max">最大条数</param>
         /// <returns></returns>
         public static DataTable getEqList(int start, int max)
         {
             sqlHandler sh = new sqlHandler();
             string sql = "select * from view_eqInfo select * from view_eqInfo  order by  资产编号 desc ";
                 
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
         /// 按编号查询资产信息
         /// </summary>
         /// <returns></returns>
         public static DataTable GetInfobyEqno(string eqno)
         {
             sqlHandler sh = new sqlHandler();
             string sql = string.Format("select * from view_eqInfo where 资产编号='{0}'", eqno);
             DataTable dt = sh.GetData(sql);
             return dt != null ? dt : null;

         }
         /// <summary>
         /// 按资产类别查询资产信息
         /// </summary>
         /// <param name="type">类别名称</param>
         /// <returns></returns>
         public static DataTable GetInfobyType(string type)
         {
             sqlHandler sh = new sqlHandler();
             string sql = string.Format("select * from view_eqInfo where 资产类别='{0}'", type);
             DataTable dt = sh.GetData(sql);
             return dt != null ? dt : null;
 
         }
         /// <summary>
         /// 按资产名称查询资产信息
         /// </summary>
         /// <param name="name">资产名称</param>
         /// <returns></returns>
         public static DataTable GetInfobyName(string name)
         {
             sqlHandler sh = new sqlHandler();
             string sql = string.Format("select * from view_eqInfo where 资产名称='{0}'", name);
             DataTable dt = sh.GetData(sql);
             return dt != null ? dt : null;
 
 
         }
         /// <summary>
         /// 按资产增长方式查询资产信息
         /// </summary>
         /// <param name="name">资产名称</param>
         /// <returns></returns>
         public static DataTable GetInfobyAddtype(string addtype)
         {
             sqlHandler sh = new sqlHandler();
             string sql = string.Format("select * from view_eqInfo where 增长方式='{0}'", addtype);
             DataTable dt = sh.GetData(sql);
             return dt != null ? dt : null;


         }
         /// <summary>
         /// 按资产保存地点查询资产信息
         /// </summary>
         /// <param name="name">资产名称</param>
         /// <returns></returns>
         public static DataTable GetInfobyKeepplace(string place)
         {
             sqlHandler sh = new sqlHandler();
             string sql = string.Format("select * from view_eqInfo where 保存地点='{0}'", place);
             DataTable dt = sh.GetData(sql);
             return dt != null ? dt : null;


         }
         /// <summary>
         /// 按资产登记人查询资产信息
         /// </summary>
         /// <param name="name">资产名称</param>
         /// <returns></returns>
         public static DataTable GetInfobyBooker(string booker)
         {
             sqlHandler sh = new sqlHandler();
             string sql = string.Format("select * from view_eqInfo where 保存地点='{0}'", booker);
             DataTable dt = sh.GetData(sql);
             return dt != null ? dt : null;


         }
    }
}
