using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DataAccess
{
    public class sqlHandler
    {
        private SqlConnection _conn = null;
        private SqlCommand _cmd = null;
        private SqlDataAdapter _da = null;
       
        public sqlHandler()
        {
            
            
        }
        /// <summary>
        /// 得到数据
        /// </summary>
        /// <param name="sql">sql查询语句</param>
        /// <returns></returns>
        public DataTable GetData(string sql)
        {
            
            try
            {
                this._conn = new SqlConnection(ConfigurationSettings.AppSettings["con"]);
                this._da = new SqlDataAdapter(sql, _conn);
                DataTable dt = new DataTable();
                _da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
               // return null;
            }


        }
        /// <summary>
        /// 对数据进行 增 删 改 的操作
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sql)
        {
            try
            {
                this._conn = new SqlConnection(ConfigurationSettings.AppSettings["con"]);
                _conn.Open();
                this._cmd = new SqlCommand(sql,_conn);
                int efect = _cmd.ExecuteNonQuery();
                return efect ;
            }
            catch
            {
                
                return 0;
            }
            finally
            {
                _conn.Close();
            }

 
        }
        /// <summary>
        /// 从备份日志中还原数据
        /// </summary>
        /// <param name="sql">数据库还原语句</param>
        /// <returns></returns>
        public int ExecuteRestore(string sql)
        {
            //连接master数据库
            string s = ConfigurationSettings.AppSettings["restore"];
            SqlConnection  _restore = new SqlConnection(ConfigurationSettings.AppSettings["restore"]);
            try
            { 
                
                _restore.Open();
                this._cmd = new SqlCommand(sql, _restore);
                int efect = _cmd.ExecuteNonQuery();
                return efect;
            }
            catch
            {

                return 0;
            }
            finally
            {
                _restore.Close();
            }


        }
        /// <summary>
        /// 执行大容量数据的添加删除修改操作
        /// </summary>
        /// <param name="Pname">代参SQL语句</param>
        /// <param name="commandParameters">SQL中的参数</param>
        /// <returns>result:sql对数据表影响的行数</returns>
        public int ExecuteSQL(string sql, params SqlParameter[] commandParameters)
        {
            this._conn = new SqlConnection(ConfigurationSettings.AppSettings["con"]);
            _cmd = new SqlCommand(sql, _conn);
            for (int i = 0; i < commandParameters.Length; i++)
            {
                _cmd.Parameters.Add(commandParameters[i]);
            }
            try
            {
                this._conn.Open();
               int result= this._cmd.ExecuteNonQuery();
                return result;
            }
            catch(SqlException e)
            {

                return 0;
            }

            finally
            {
                if (this._cmd != null) _cmd.Dispose();
                this._conn.Close();
            }
        }
        /// <summary>
        /// 返回结果集分页
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="start">起始条数(从0开始) start+1 -- start+max</param>
        /// <param name="max">分页条数</param>
        public DataTable GetDataTable_Page(string cmdText, int start, int max)
        {
            this._conn = new SqlConnection(ConfigurationSettings.AppSettings["con"]);
            //创建一个新的数据适配器
            SqlDataAdapter custDA = new SqlDataAdapter();
            //创建一个新的 SqlCommand 对象
            SqlCommand cmd = new SqlCommand();
            
            //创建连接
            using (this._conn = new SqlConnection(ConfigurationSettings.AppSettings["con"]))
            {
                cmd.CommandText = cmdText;
                cmd.Connection = _conn;
                custDA.SelectCommand = cmd;
                DataSet ds = new DataSet();
                try
                {
                    custDA.Fill(ds, start, max, "data");
                }
                catch (Exception e)
                {
                    return null;
                }
                return ds.Tables["data"];
            }
        }
        
        
    }
}
