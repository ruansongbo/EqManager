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
        /// �黹�ʲ�
        /// </summary>
        /// <param name="re"></param>
        /// <returns>true���ɹ���false��ʧ��</returns>
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
        /// �õ����е��ʲ��黹��Ϣ
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
        /// ��ѯĳһ���ʲ��Ĺ黹���
        /// </summary>
        /// <param name="eqno">�ʲ����</param>
        /// <returns></returns>
        public static DataTable GetInfoByEqno(string eqno)
        {
            string sql = string.Format("select * from view_return where �ʲ����='{0}'", eqno);
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;
        }
        /// <summary>
        /// ��ѯĳһ���ʲ��Ĺ黹���(ģ����ѯ)
        /// </summary>
        /// <param name="eqno">�ʲ����</param>
        /// <returns></returns>
        public static DataTable GetInfoByEqno2(string eqno)
        {
            string sql = string.Format("select * from view_return where �ʲ���� like '{0}%'", eqno);
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;
        }
        /// <summary>
        /// ��ѯĳ�����õ��ʲ��黹��¼(��ȷ��ѯ)
        /// </summary>
        /// <param name="Borrower">�����˹���</param>
        /// <returns></returns>
        public static DataTable GetInfoByBorrower(int Borrower)
        {
            string sql = string.Format("select * from view_return where �����˹���='{0}'", Borrower);
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;
 
        }
        /// <summary>
        /// ��ѯĳ�����õ��ʲ��黹��¼��ģ����Ѱ��
        /// </summary>
        /// <param name="Borrower">�����˹���</param>
        /// <returns></returns>
        public static DataTable GetInfoByBorrower2(int Borrower)
        {
            string sql = string.Format("select * from view_return where �����˹��� like '{0}%'", Borrower);
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;

        }
        /// <summary>
        /// ��ѯ��������ڵ��ʲ��黹��¼
        /// </summary>
        /// <returns></returns>
        public static DataTable getInfoLast6Month()
        {
            string sql = "select * from view_return where datediff(mm,�黹����,getdate())<=6";
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;
        }
        /// <summary>
        /// ��ѯ���1���ڵ��ʲ��黹��¼
        /// </summary>
        /// <returns></returns>
        public static DataTable getInfoLastYear()
        {
            string sql = "select * from view_return where datediff(yy,�黹����,getdate())<=1";
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;
        }
        /// <summary>
        /// ��ѯָ�����ڵ��ʲ��黹��¼
        /// </summary>
        /// <returns></returns>
        public static DataTable getInfoYearMonth(int year,int month)
        {
            string sql = string.Format("select * from view_return where year(�黹����)={0} and month(�黹����)={1}",year,month);
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;
        }
    }
}
