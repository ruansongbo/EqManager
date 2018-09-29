using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using DataAccess;
using DataEntity;

namespace DataBusiness
{
    public class BoroowMgr
    {
        /// <summary>
        /// �õ�ĳ���ʲ�������������
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int GetMaxBoroow(string id)
        {
            sqlHandler sh = new sqlHandler();
            string sql = string.Format("exec proc_GetMaxCountCanUse '{0}'", id);
            DataTable dt=sh.GetData(sql);
            return dt!=null?int.Parse(dt.Rows[0][0].ToString()):-1;
        }
        /// <summary>
        /// �ʲ�����
        /// </summary>
        /// <param name="br"></param>
        /// <returns></returns>
        public static bool Add(Borrow br)
        {
            string eqno = br.EqNo;
            int count = br.Count;
            string depart = br.depart;
            DateTime date = br.Date;
            string booker = br.Booker;
            int boroower = br.Borrower;
            string sql = string.Format("insert into borrow values('{0}',{1},'{2}','{3}','{4}','{5}')", eqno,count, depart,boroower ,date, booker);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }
        /// <summary>
        /// �õ�ĳԱ�����õ�ĳһ���ʲ��������Ϣ
        /// </summary>
        /// <param name="eqno">�ʲ����</param>
        /// <param name="boorow">������id</param>
        /// <returns></returns>

        public static DataTable GetOneBorrow(string eqno,int boorow)
        {
            string sql = string.Format("select a.count,a.depart,b.name,a.date from borrow a left join employee b on(a.borrwer=b.empid) where eqno='{0}'and borrwer={1}", eqno, boorow);
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;
 
        }
        /// <summary>
        /// �õ����е��ʲ�������Ϣ
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAll()
        {
            string sql = "select * from view_Borrow";
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;
 
        }
        /// <summary>
        /// ������ͳ���ʲ�������
        /// </summary>
        /// <returns></returns>
        public static DataTable BorrowStat()
        {
            string sql = "select * from view_ReportBorrowByDepart";
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;
 
        }
        /// <summary>
        /// ͳ�Ƹ����ʲ����õ�����
        /// </summary>
        /// <returns></returns>
        public static DataTable TypeBorrowSatat()
        {
            string sql = "select * from view_BorrowBytype ";
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;
        }
        
    }
}
