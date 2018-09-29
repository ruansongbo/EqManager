using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using DataAccess;
using DataEntity;

namespace DataBusiness
{
    public class ClearMgr
    {
        /// <summary>
        /// �õ�������������
        /// </summary>
        /// <param name="eqno"></param>
        /// <returns>-1��û�п�������ʲ�</returns>
        public static int GetMaxClear(string eqno)
        {
            string sql = string.Format("exec proc_GetMaxCountCanUse '{0}'", eqno);
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            if (dt != null)
            {
                return int.Parse(dt.Rows[0][0].ToString());

            }
            else
            {
                return -1;
            }
        }
        /// <summary>
        /// �����ʲ�
        /// </summary>
        /// <param name="cl"></param>
        /// <returns></returns>
        public static bool Clear(Clear cl)
        {
            string eqno = cl.EqNo;
            int count = cl.Count;
            string cleartype = cl.ClearType;
            string clearer = cl.Clearer;
            string remark = cl.Mark;
            string date = cl.ClearDate;
            string sql = string.Format("insert into clear values('{0}','{1}','{2}','{3}','{4}','{5}')",eqno,count,cleartype,clearer,date,remark);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;

        }
        /// <summary>
        /// �õ����е��ʲ������¼��
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAll()
        {
            string sql = "select id as ��ˮ��,eqno as �ʲ����,count as ��������,cleartype as ����ʽ,clearer as ������,clearDate as ��������,mark as ��ע from clear";
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;
        }
        /// <summary>
        /// ��������ʱ����ģ����ѯ�����¼
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DataTable GetBydate(string date)
        {
            string sql = string.Format("select id as ��ˮ��,eqno as �ʲ����,count as ��������,cleartype as ����ʽ,clearer as ������,clearDate as ��������,mark as ��ע from clear where date like '{0}%' ", date);
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;
 
        }
    }
}
