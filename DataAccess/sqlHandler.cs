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
        /// �õ�����
        /// </summary>
        /// <param name="sql">sql��ѯ���</param>
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
        /// �����ݽ��� �� ɾ �� �Ĳ���
        /// </summary>
        /// <param name="sql">sql���</param>
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
        /// �ӱ�����־�л�ԭ����
        /// </summary>
        /// <param name="sql">���ݿ⻹ԭ���</param>
        /// <returns></returns>
        public int ExecuteRestore(string sql)
        {
            //����master���ݿ�
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
        /// ִ�д��������ݵ����ɾ���޸Ĳ���
        /// </summary>
        /// <param name="Pname">����SQL���</param>
        /// <param name="commandParameters">SQL�еĲ���</param>
        /// <returns>result:sql�����ݱ�Ӱ�������</returns>
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
        /// ���ؽ������ҳ
        /// </summary>
        /// <param name="cmdText">SQL���</param>
        /// <param name="start">��ʼ����(��0��ʼ) start+1 -- start+max</param>
        /// <param name="max">��ҳ����</param>
        public DataTable GetDataTable_Page(string cmdText, int start, int max)
        {
            this._conn = new SqlConnection(ConfigurationSettings.AppSettings["con"]);
            //����һ���µ�����������
            SqlDataAdapter custDA = new SqlDataAdapter();
            //����һ���µ� SqlCommand ����
            SqlCommand cmd = new SqlCommand();
            
            //��������
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
