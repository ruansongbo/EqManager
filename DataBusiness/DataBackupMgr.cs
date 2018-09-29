using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


using DataAccess;

namespace DataBusiness
{
    public class DataBackupMgr
    {
        
        public static bool Backup(string filename, bool format)
        {
            string sql = "";
            if (format)
            {

                sql = string.Format("backup database Equipment_Manage to disk = '{0}' with format", filename);
            }
            else
            {
                sql = string.Format("backup database Equipment_Manage to disk = '{0}' with noformat", filename);

            }
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) ==-1;

        }
        /// <summary>
        /// �õ����ݿ�ı�����־
        /// </summary>
        /// <param name="filename">�����ļ��������ļ���</param>
        /// <returns></returns>
        public static DataTable GetBackupLog(string filename)
        {
            string sql = string.Format("restore headeronly from disk='{0}'", filename);
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;

        }
        /// <summary>
        /// ��ԭ���ݿ�
        /// </summary>
        /// <param name="filename">�����ļ��������ļ���</param>
        /// <param name="file">��Ҫ��ԭ�ı��ݼ�</param>
        /// <returns></returns>
        public static bool RestoeData(string filename, int file)
        {
            string sqlKill = "exec proc_Kill 'Equipment_Manage'";
            sqlHandler sh = new sqlHandler();
            if (sh.ExecuteRestore(sqlKill) == -1)
            {
                string sqlRestore = string.Format(" use master restore database Equipment_Manage from disk='{0}'  with replace , file={1}", filename, file);
                return sh.ExecuteRestore(sqlRestore) == -1;

            }
            else
            {
                return false;
            }
            
        }
    }
}
