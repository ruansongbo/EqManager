using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

using DataAccess;
using DataEntity;

namespace DataBusiness
{
    public class ClearMgr
    {
        /// <summary>
        /// �ʲ�ע��
        /// </summary>
        /// <param name="fix"></param>
        /// <returns></returns>
        public static bool Add(Clear clear)
        {
            string id = clear.ID;//��ˮ��
            string eqNo = clear.EqNo;//�ʲ�����
            string eqName = clear.EqName;//�ʲ�����
            string depart = clear.Department;//��������
            string keepPlace = clear.KeepPlace;//���ܵص�
            string keeper = clear.Keeper;//������
            string cType = clear.CType;//ע����ʽ
            string cAgent = clear.CAgent;//ע��������
            DateTime cDate = clear.CDate;//ע������
            string remark = clear.Remark;//��ע
            string sql = string.Format("INSERT ClearLog(serialNo, EqNo, EqName, departId, KeepPlace, EqKeeper, cType, cAgent, cDate, remark, state) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')",
                id, eqNo, eqName, depart, keepPlace, keeper, cType, cAgent, cDate, remark, "ע�������");
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }

        /// <summary>
        /// �ʲ�ע��
        /// </summary>
        /// <param name="fix"></param>
        /// <returns></returns>
        public static bool AddWithoutVerify(Clear clear)
        {
            string id = clear.ID;//��ˮ��
            string eqNo = clear.EqNo;//�ʲ�����
            string eqName = clear.EqName;//�ʲ�����
            string depart = clear.Department;//��������
            string keepPlace = clear.KeepPlace;//���ܵص�
            string keeper = clear.Keeper;//������
            string cType = clear.CType;//ע����ʽ
            string cAgent = clear.CAgent;//ע��������
            DateTime cDate = clear.CDate;//ע������
            string remark = clear.Remark;//��ע
            string sql = string.Format("INSERT ClearLog(serialNo, EqNo, EqName, departId, KeepPlace, EqKeeper, cType, cAgent, cDate, remark, state) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')",
                id, eqNo, eqName, depart, keepPlace, keeper, cType, cAgent, cDate, remark, "��ע��");
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }

        /// <summary>
        /// �����ʲ�����
        /// </summary>
        /// <param name="br"></param>
        /// <returns></returns>
        public static bool CUpdate(string ID, Clear clear)
        {
            string cType = clear.CType;//ע����ʽ
            DateTime cDate = clear.CDate;//��������
            string remark = clear.Remark;//��ע
            string sql = string.Format("update ClearLog set  cType='{1}', cDate='{2}', remark='{3}', state='{4}' where serialNo='{0}'",
                ID, cType, cDate, remark, "ע�������");
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }
        /// <summary>
        /// �õ�ĳԱ��ע����ĳһ���ʲ��������Ϣ
        /// </summary>
        /// <param name="serialNo">���ź�</param>
        /// <returns></returns>

        public static DataTable GetOneClear(string serialNo)
        {
            string sql = string.Format("SELECT cType, cDate, remark, EqNo FROM ClearLog WHERE serialNo='{0}'", serialNo);
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;
        }

        /// <summary>
        /// �õ������Ϣ
        /// </summary>
        /// <param name="departId">����</param>
        /// <param name="power">Ȩ��</param>
        /// <returns></returns>
        public static DataTable getAuditList(string departId, string power)
        {
            sqlHandler sh = new sqlHandler();
            string sql = "";
            if (power == "0" || power == "1")
            {
                sql = "select * from View_ClearLog where ״̬ like '%���'";
                DataTable dt = sh.GetData(sql);
                if (dt != null)
                {
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                MessageBox.Show("��Ȩ��");
                return null;
            }
        }
        /// <summary>
        /// �õ������Ϣ����
        /// </summary>
        /// <returns></returns>
        public static int getAuditListCount()
        {
            sqlHandler sh = new sqlHandler();
            string sql = string.Format("select count(*) from (select * from View_ClearLog where ״̬ like '%���') AS M");
            DataTable dt = sh.GetData(sql);
            int result = 0;
            if (dt != null)
            {
                result = int.Parse(dt.Rows[0][0].ToString());
            }

            return result;
        }
        /// <summary>
        /// �õ��������Ϣ
        /// </summary>
        /// <param name="agent">�û�</param>
        /// <returns></returns>
        public static DataTable getUnAuditList(string agent)
        {
            sqlHandler sh = new sqlHandler();
            string sql = string.Format("SELECT * FROM View_ClearLog WHERE ״̬ IN ('ע�������','ע�����δͨ��') AND ע�������� = '{0}'", agent);
            DataTable dt = sh.GetData(sql);
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
        /// �õ��������Ϣ����
        /// </summary>
        /// <returns></returns>
        public static int getUnAuditListCount(string agent)
        {
            sqlHandler sh = new sqlHandler();
            string sql = string.Format("select count(*) from (SELECT * FROM View_ClearLog WHERE ״̬ IN ('ע�������','ע�����δͨ��') AND ע�������� = '{0}') AS M", agent);
            DataTable dt = sh.GetData(sql);
            int result = 0;
            if (dt != null)
            {
                result = int.Parse(dt.Rows[0][0].ToString());
            }

            return result;
        }
        /// <summary>
        /// ע�����ͨ��
        /// </summary>
        /// <param name="ID">��ˮ��</param>
        /// <param name="bReviewer">�û�</param>
        /// <returns></returns>
        public static bool agreeAudit(string ID, string user)
        {
            string sql = string.Format("update ClearLog set cReviewer='{1}', state='��ע��' where serialNo='{0}'", ID, user);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }
        /// <summary>
        /// ע�����δͨ��
        /// </summary>
        /// <param name="ID">��ˮ��</param>
        /// <param name="bReviewer">�û�</param>
        /// <returns></returns>
        public static bool disagreeAudit(string ID, string user, string audit)
        {
            string sql = string.Format("update ClearLog set cReviewer='{1}', state='ע�����δͨ��' , audit='{2}'where serialNo='{0}'", ID, user, audit);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }
        /// <summary>
        /// ɾ��ע����Ϣ
        /// </summary>
        /// <param name="ID">��ˮ��</param>
        /// <param name="bReviewer">�û�</param>
        /// <returns></returns>
        public static bool deleteAudit(string ID)
        {
            string sql = string.Format("DELETE ClearLog WHERE serialNo='{0}'", ID);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }
        /// <summary>
        /// �õ�����ע����ʽ
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllClearType()
        {
            sqlHandler sh = new sqlHandler();
            string sql = "select * from ClearType";
            DataTable dt = sh.GetData(sql);
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
        /// �õ��ʲ���Ϣ(��ҳ)
        /// </summary>
        /// <param name="start">��ʼҳ</param>
        /// <param name="max">�������</param>
        /// <returns></returns>
        public static DataTable getLogList(int start, int max, string departId, string power)
        {
            sqlHandler sh = new sqlHandler();
            string sql = "";
            if (power == "0" || power == "1")
                sql = "select * from View_ClearLog order by ��ˮ��";
            else if (power == "2")
                sql = string.Format("select * from View_ClearLog where ���ű�� like '{0}%'order by ��ˮ��", departId.Substring(0, 2));
            else
                sql = string.Format("select * from View_ClearLog where ���ű��='{0}'order by ��ˮ��", departId);

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
        /// �õ��ʲ���Ϣ��������
        /// </summary>
        /// <returns></returns>
        public static int LogCount()
        {
            sqlHandler sh = new sqlHandler();
            string sql = "select count(*) from ClearLog";
            DataTable dt = sh.GetData(sql);
            int result = 0;
            if (dt != null)
            {
                result = int.Parse(dt.Rows[0][0].ToString());

            }

            return result;
        }

        /// <summary>
        /// �õ�ɸѡ�ʲ���Ϣ(��ҳ)
        /// </summary>
        /// <param name="start">��ʼҳ</param>
        /// <param name="max">�������</param>
        /// <returns></returns>
        public static DataTable getSortEqList(int start, int max, string departId, string power, List<string> SelectedColumns, Dictionary<String, String> SortsString, string OrderString)
        {
            string selectItem = "";
            foreach (string field in SelectedColumns)
            {
                if (field.Contains("/") || field.Contains("("))
                {
                    selectItem += "[" + field + "]" + ", ";
                }
                else
                {
                    selectItem += field + ", ";
                }
            }
            selectItem = selectItem.Substring(0, selectItem.Length - 2);
            string sortSet = "";
            int index = 0;
            foreach (KeyValuePair<string, string> kvp in SortsString)
            {
                if (string.IsNullOrEmpty(kvp.Value))
                    continue;
                if (index == 0)
                    sortSet = kvp.Value;
                else
                    sortSet = sortSet + " and " + kvp.Value;
                index++;
            }
            sqlHandler sh = new sqlHandler();
            string sql = "";
            if (string.IsNullOrEmpty(sortSet))
            {
                if (string.IsNullOrEmpty(OrderString))
                {
                    if (power == "0" || power == "1")
                        sql = string.Format("select {0} from View_ClearLog order by ��ˮ��", selectItem);
                    else if (power == "2")
                        sql = string.Format("select {1} from View_ClearLog where ���ű�� like '{0}%'order by ��ˮ��", departId.Substring(0, 2), selectItem);
                    else
                        sql = string.Format("select {1} from View_ClearLog where ���ű��='{0}'order by ��ˮ��", departId, selectItem);
                }
                else
                {
                    if (power == "0" || power == "1")
                        sql = string.Format("select {0} from View_ClearLog order by {1}", selectItem, OrderString);
                    else if (power == "2")
                        sql = string.Format("select {1} from View_ClearLog where ���ű�� like '{0}%'order by {2}", departId.Substring(0, 2), selectItem, OrderString);
                    else
                        sql = string.Format("select {1} from View_ClearLog where ���ű��='{0}'order by {2}", departId, selectItem, OrderString);
                }

            }
            else
            {
                if (string.IsNullOrEmpty(OrderString))
                {
                    if (power == "0" || power == "1")
                        sql = string.Format("select {0} from View_ClearLog where {1} order by ��ˮ��", selectItem, sortSet);
                    else if (power == "2")
                        sql = string.Format("select {1} from View_ClearLog where ���ű�� like '{0}%' and {2} order by ��ˮ��", departId.Substring(0, 2), selectItem, sortSet);
                    else
                        sql = string.Format("select {1} from View_ClearLog where ���ű��='{0}'and {2} order by ��ˮ��", departId, selectItem, sortSet);
                }
                else
                {
                    if (power == "0" || power == "1")
                        sql = string.Format("select {0} from View_ClearLog where {1} order by {2}", selectItem, sortSet, OrderString);
                    else if (power == "2")
                        sql = string.Format("select {1} from View_ClearLog where ���ű�� like '{0}%' and {2} order by {3}", departId.Substring(0, 2), selectItem, sortSet, OrderString);
                    else
                        sql = string.Format("select {1} from View_ClearLog where ���ű��='{0}' and {2} order by {3}", departId, selectItem, sortSet, OrderString);
                }

            }

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
        /// �õ�ɸѡ��ĳ�е�����ֵ
        /// </summary>
        /// <param name="start">��ʼҳ</param>
        /// <param name="max">�������</param>
        /// <returns></returns>
        public static DataTable getEqRowList(string departId, string power, string Column, Dictionary<String, String> SortsString)
        {
            string sortSet = "";
            int index = 0;
            foreach (KeyValuePair<string, string> kvp in SortsString)
            {
                if (string.IsNullOrEmpty(kvp.Value))
                    continue;
                if (index == 0)
                    sortSet = kvp.Value;
                else
                    sortSet = sortSet + " and " + kvp.Value;
                index++;
            }
            sqlHandler sh = new sqlHandler();
            string sql = "";
            if (string.IsNullOrEmpty(sortSet))
            {
                if (power == "0" || power == "1")
                    sql = string.Format("select distinct {0} from View_ClearLog order by {0}", Column);
                else if (power == "2")
                    sql = string.Format("select distinct {1} from View_ClearLog where ���ű�� like '{0}%'order by {1}", departId.Substring(0, 2), Column);
                else
                    sql = string.Format("select distinct {1} from View_ClearLog where ���ű��='{0}'order by {1}", departId, Column);

            }
            else
            {
                if (power == "0" || power == "1")
                    sql = string.Format("select distinct {0} from View_ClearLog where {1} order by {0}", Column, sortSet);
                else if (power == "2")
                    sql = string.Format("select distinct {1} from View_ClearLog where ���ű�� like '{0}%' and {2} order by {1}", departId.Substring(0, 2), Column, sortSet);
                else
                    sql = string.Format("select distinct {1} from View_ClearLog where ���ű��='{0}'and {2} order by {1}", departId, Column, sortSet);
            }

            DataTable dt = sh.GetData(sql);
            if (dt != null)
            {
                return dt;
            }
            else
            {
                return null;
            }

        }

    }
}
