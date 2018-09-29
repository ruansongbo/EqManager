using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using DataAccess;
using DataEntity;


namespace DataBusiness
{
    public class ReturnMgr
    {
        /// <summary>
        /// 归还资产
        /// </summary>
        /// <param name="re"></param>
        /// <returns>true：成功；false：失败</returns>
        public static bool Returns(Returns re)
        {
            string eqno = re.EqNo;
            int count = re.Count;
            string booker = re.Booker;
            int Borower = re.Borrower;
            string date = re.Date;
            sqlHandler sh = new sqlHandler();
            string sql = string.Format("insert into [return] values({0},'{1}',{2},'{3}','{4}')",Borower, eqno, count, date, booker);
            return sh.ExecuteNonQuery(sql) > 0;
 
        }
        /// <summary>
        /// 得到所有的资产归还信息
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAll()
        {
            string sql = "select * from view_return";
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;


        }
        /// <summary>
        /// 查询某一笔资产的归还情况
        /// </summary>
        /// <param name="eqno">资产编号</param>
        /// <returns></returns>
        public static DataTable GetInfoByEqno(string eqno)
        {
            string sql = string.Format("select * from view_return where 资产编号='{0}'", eqno);
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;
        }
        /// <summary>
        /// 查询某一笔资产的归还情况(模糊查询)
        /// </summary>
        /// <param name="eqno">资产编号</param>
        /// <returns></returns>
        public static DataTable GetInfoByEqno2(string eqno)
        {
            string sql = string.Format("select * from view_return where 资产编号 like '{0}%'", eqno);
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;
        }
        /// <summary>
        /// 查询某人领用的资产归还记录(精确查询)
        /// </summary>
        /// <param name="Borrower">领用人工号</param>
        /// <returns></returns>
        public static DataTable GetInfoByBorrower(int Borrower)
        {
            string sql = string.Format("select * from view_return where 领用人工号='{0}'", Borrower);
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;
 
        }
        /// <summary>
        /// 查询某人领用的资产归还记录（模糊查寻）
        /// </summary>
        /// <param name="Borrower">领用人工号</param>
        /// <returns></returns>
        public static DataTable GetInfoByBorrower2(int Borrower)
        {
            string sql = string.Format("select * from view_return where 领用人工号 like '{0}%'", Borrower);
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;

        }
        /// <summary>
        /// 查询最近半年内的资产归还记录
        /// </summary>
        /// <returns></returns>
        public static DataTable getInfoLast6Month()
        {
            string sql = "select * from view_return where datediff(mm,归还日期,getdate())<=6";
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;
        }
        /// <summary>
        /// 查询最近1年内的资产归还记录
        /// </summary>
        /// <returns></returns>
        public static DataTable getInfoLastYear()
        {
            string sql = "select * from view_return where datediff(yy,归还日期,getdate())<=1";
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;
        }
        /// <summary>
        /// 查询指定日期的资产归还记录
        /// </summary>
        /// <returns></returns>
        public static DataTable getInfoYearMonth(int year,int month)
        {
            string sql = string.Format("select * from view_return where year(归还日期)={0} and month(归还日期)={1}",year,month);
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;
        }
    }
}
