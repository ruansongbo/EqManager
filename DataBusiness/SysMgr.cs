using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


using DataAccess;

namespace DataBusiness
{
    public class SysMgr
    {
         /// <summary>
         /// 数据备份
         /// </summary>
         /// <param name="filename">备份路径</param>
         /// <param name="format">是否格式化</param>
         /// <returns></returns>
        public static bool Backup(string filename, bool format)
        {
            string sql = "";
            if (format)//格式化
            {

                sql = string.Format("backup database EqKeeper to disk = '{0}' with format", filename);
            }
            else//一般还原
            {
                sql = string.Format("backup database EqKeeper to disk = '{0}' with noformat", filename);

            }
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) ==-1;

        }
        /// <summary>
        /// 得到数据库的备份日志
        /// </summary>
        /// <param name="filename">备份文件的完整文件名</param>
        /// <returns></returns>
        public static DataTable GetBackupLog(string filename)
        {
            string sql = string.Format("restore headeronly from disk='{0}'", filename);
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;

        }
        /// <summary>
        /// 还原数据库
        /// </summary>
        /// <param name="filename">备份文件的完整文件名</param>
        /// <param name="file">所要还原的备份集</param>
        /// <returns></returns>
        public static bool RestoeData(string filename,int file)
        {
            string sqlKill ="exec proc_Kill 'EqKeeper'";
            sqlHandler sh = new sqlHandler();
            if (sh.ExecuteRestore(sqlKill) == -1)//杀死所有对数据库访问的进程
            {
                string sqlRestore = string.Format(" use master restore database Eqkeeper from disk='{0}'  with replace,file={1} ", filename,file);
                return sh.ExecuteRestore(sqlRestore) == -1;

            }
            else
            {
                return false;
            }
            
        }
        /// <summary>
        /// 系统数据初始化
        /// </summary>
        /// <returns></returns>
        public static bool SysInit()
        {
            string sql = "exec proc_Init";
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) == -1;
        }
    }
}
