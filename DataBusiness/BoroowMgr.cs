using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
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
            string id = br.ID;//��ˮ��
            string eqNo = br.EqNo;//�ʲ�����
            string eqName = br.EqName;//�ʲ�����
            string depart = br.Department;//��������
            string keepPlace = br.KeepPlace;//���ܵص�
            string keeper = br.Keeper;//������
            string borrower = br.Borrower;//������
            string bAgent = br.BAgent;//��辭����
            DateTime bDate = br.BDate;//��������
            DateTime rDate = br.RDate;//�黹����
            string remark = br.bRemark;//��ע
            string sql = string.Format("INSERT BorrowLog(serialNo, EqNo, EqName, departId, KeepPlace, EqKeeper, borrower, bAgent, bDate, rDate, bRemark, state) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')",
                id, eqNo, eqName, depart, keepPlace, keeper, borrower, bAgent, bDate, rDate, remark, "��������");
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }
        /// <summary>
        /// �ʲ�����
        /// </summary>
        /// <param name="br"></param>
        /// <returns></returns>
        public static bool AddWithoutVerify(Borrow br)
        {
            string id = br.ID;//��ˮ��
            string eqNo = br.EqNo;//�ʲ�����
            string eqName = br.EqName;//�ʲ�����
            string depart = br.Department;//��������
            string keepPlace = br.KeepPlace;//���ܵص�
            string keeper = br.Keeper;//������
            string borrower = br.Borrower;//������
            string bAgent = br.BAgent;//��辭����
            DateTime bDate = br.BDate;//��������
            DateTime rDate = br.RDate;//�黹����
            string remark = br.bRemark;//��ע
            string sql = string.Format("INSERT BorrowLog(serialNo, EqNo, EqName, departId, KeepPlace, EqKeeper, borrower, bAgent, bDate, rDate, bRemark, state) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')",
                id, eqNo, eqName, depart, keepPlace, keeper, borrower, bAgent, bDate, rDate, remark, "�ѽ��");
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }
        /// <summary>
        /// �����ʲ�����
        /// </summary>
        /// <param name="br"></param>
        /// <returns></returns>
        public static bool BUpdate(string ID, Borrow br)
        {
            string borrower = br.Borrower;//������
            DateTime bDate = br.BDate;//��������
            DateTime rDate = br.RDate;//�黹����
            string remark = br.bRemark;//��ע
            string sql = string.Format("update BorrowLog set  borrower='{1}', bDate='{2}', rDate='{3}', bRemark='{4}', state='{5}' where serialNo='{0}'",
                ID, borrower, bDate, rDate, remark, "��������");
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }
        /// <summary>
        /// �����ʲ��黹
        /// </summary>
        /// <param name="br"></param>
        /// <returns></returns>
        public static bool RUpdate(string ID, Borrow br)
        {
            string sql = string.Format("update BorrowLog set  rAgent='{1}', rDate='{2}', rRemark='{3}', state='{4}'where serialNo='{0}'",
                ID, br.RAgent, br.RDate, br.rRemark, "�黹�����");
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }
        /// <summary>
        /// �����ʲ��黹
        /// </summary>
        /// <param name="br"></param>
        /// <returns></returns>
        public static bool RUpdateWithoutVerify(string ID, Borrow br)
        {
            string sql = string.Format("update BorrowLog set  rAgent='{1}', rDate='{2}', rRemark='{3}', state='{4}'where serialNo='{0}'",
                ID, br.RAgent, br.RDate, br.rRemark, "�ѹ黹");
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }
        /// <summary>
        /// �õ�ĳԱ�����õ�ĳһ���ʲ��������Ϣ
        /// </summary>
        /// <param name="eqno">�ʲ�����</param>
        /// <param name="boorow">������id</param>
        /// <returns></returns>

        public static DataTable GetOneBorrow(string ID)
        {
            string sql = string.Format("SELECT borrower,bDate,rDate,bRemark, EqNo FROM BorrowLog WHERE serialNo='{0}'", ID);
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null; 
        }
        /// <summary>
        /// �õ�ĳԱ�����õ�ĳһ���ʲ���������Ϣ
        /// </summary>
        /// <param name="eqno">�ʲ�����</param>
        /// <param name="boorow">������id</param>
        /// <returns></returns>

        public static DataTable GetOneAllBorrow(string ID)
        {
            string sql = string.Format("SELECT * FROM View_BorrowLog WHERE ��ˮ��='{0}'", ID);
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
        public static DataTable getAuditList(string agent)
        {
            sqlHandler sh = new sqlHandler();

            string sql = string.Format("select * from View_BorrowLog where ״̬ like '%���' or (��辭���� = '{0}' and ״̬ = '�ѽ��')", agent);
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
        /// �õ��������Ϣ
        /// </summary>
        /// <param name="agent">�û�</param>
        /// <returns></returns>
        public static DataTable getUnAuditList(string agent)
        {
            sqlHandler sh = new sqlHandler();
            string sql = string.Format("SELECT * FROM View_BorrowLog WHERE ״̬ IN ('��������','������δͨ��','�ѽ��','�黹�����') AND ��辭���� = '{0}'", agent);
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
        /// �������ͨ��
        /// </summary>
        /// <param name="ID">��ˮ��</param>
        /// <param name="bReviewer">�û�</param>
        /// <returns></returns>
        public static bool agreeBAudit(string ID, string user)
        {
            string sql = string.Format("update BorrowLog set bReviewer='{1}', state='�ѽ��' where serialNo='{0}'", ID, user);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;

        }
        /// <summary>
        /// �黹���ͨ��
        /// </summary>
        /// <param name="ID">��ˮ��</param>
        /// <param name="bReviewer">�û�</param>
        /// <returns></returns>
        public static bool agreeRAudit(string ID, string user)
        {
            string sql = string.Format("update BorrowLog set rReviewer='{1}', state='�ѹ黹' where serialNo='{0}'", ID, user);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;

        }
        /// <summary>
        /// �������δͨ��
        /// </summary>
        /// <param name="ID">��ˮ��</param>
        /// <param name="bReviewer">�û�</param>
        /// <returns></returns>
        public static bool disagreeAudit(string ID, string user)
        {
            string sql = string.Format("update BorrowLog set bReviewer='{1}', state='������δͨ��' where serialNo='{0}'", ID, user);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;

        }
        /// <summary>
        /// ɾ��������Ϣ
        /// </summary>
        /// <param name="ID">��ˮ��</param>
        /// <param name="bReviewer">�û�</param>
        /// <returns></returns>
        public static bool deleteAudit(string ID)
        {
            string sql = string.Format("DELETE BorrowLog WHERE serialNo='{0}'", ID);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
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
                sql = "select * from View_BorrowLog order by ��ˮ��";
            else if (power == "2")
                sql = string.Format("select * from View_BorrowLog where ���ű�� like '{0}%'order by ��ˮ��", departId.Substring(0, 2));
            else
                sql = string.Format("select * from View_BorrowLog where ���ű��='{0}'order by ��ˮ��", departId);

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
            string sql = "select count(*) from BorrowLog";
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
                        sql = string.Format("select {0} from View_BorrowLog order by ��ˮ��", selectItem);
                    else if (power == "2")
                        sql = string.Format("select {1} from View_BorrowLog where ���ű�� like '{0}%'order by ��ˮ��", departId.Substring(0, 2), selectItem);
                    else
                        sql = string.Format("select {1} from View_BorrowLog where ���ű��='{0}'order by ��ˮ��", departId, selectItem);
                }
                else
                {
                    if (power == "0" || power == "1")
                        sql = string.Format("select {0} from View_BorrowLog order by {1}", selectItem, OrderString);
                    else if (power == "2")
                        sql = string.Format("select {1} from View_BorrowLog where ���ű�� like '{0}%'order by {2}", departId.Substring(0, 2), selectItem, OrderString);
                    else
                        sql = string.Format("select {1} from View_BorrowLog where ���ű��='{0}'order by {2}", departId, selectItem, OrderString);
                }

            }
            else
            {
                if (string.IsNullOrEmpty(OrderString))
                {
                    if (power == "0" || power == "1")
                        sql = string.Format("select {0} from View_BorrowLog where {1} order by ��ˮ��", selectItem, sortSet);
                    else if (power == "2")
                        sql = string.Format("select {1} from View_BorrowLog where ���ű�� like '{0}%' and {2} order by ��ˮ��", departId.Substring(0, 2), selectItem, sortSet);
                    else
                        sql = string.Format("select {1} from View_BorrowLog where ���ű��='{0}'and {2} order by ��ˮ��", departId, selectItem, sortSet);
                }
                else
                {
                    if (power == "0" || power == "1")
                        sql = string.Format("select {0} from View_BorrowLog where {1} order by {2}", selectItem, sortSet, OrderString);
                    else if (power == "2")
                        sql = string.Format("select {1} from View_BorrowLog where ���ű�� like '{0}%' and {2} order by {3}", departId.Substring(0, 2), selectItem, sortSet, OrderString);
                    else
                        sql = string.Format("select {1} from View_BorrowLog where ���ű��='{0}' and {2} order by {3}", departId, selectItem, sortSet, OrderString);
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
                    sql = string.Format("select distinct {0} from View_BorrowLog order by {0}", Column);
                else if (power == "2")
                    sql = string.Format("select distinct {1} from View_BorrowLog where ���ű�� like '{0}%'order by {1}", departId.Substring(0, 2), Column);
                else
                    sql = string.Format("select distinct {1} from View_BorrowLog where ���ű��='{0}'order by {1}", departId, Column);

            }
            else
            {
                if (power == "0" || power == "1")
                    sql = string.Format("select distinct {0} from View_BorrowLog where {1} order by {0}", Column, sortSet);
                else if (power == "2")
                    sql = string.Format("select distinct {1} from View_BorrowLog where ���ű�� like '{0}%' and {2} order by {1}", departId.Substring(0, 2), Column, sortSet);
                else
                    sql = string.Format("select distinct {1} from View_BorrowLog where ���ű��='{0}'and {2} order by {1}", departId, Column, sortSet);
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

        /// <summary>
        /// ͨ���ʲ���������ˮ����
        /// </summary>
        /// <param name="departId"></param>
        /// <returns></returns>
        public static string GetIDFromEqNo(string eqno)
        {
            string sql = string.Format("select top 1 serialNo from BorrowLog where EqNo='{0}'order by serialNo desc", eqno);
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            string departName = "";
            if (dt.Rows.Count > 0)
            {

                departName = dt.Rows[0][0].ToString();

            }
            return departName;

        }

        /// <summary>
        /// ͨ����ˮ���Ż���ʲ�״̬
        /// </summary>
        /// <param name="departId"></param>
        /// <returns></returns>
        public static string GetStateFromSerialNo(string serialNo)
        {
            string sql = string.Format("select State from BorrowLog where serialNo='{0}'", serialNo);
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            string departName = "";
            if (dt.Rows.Count > 0)
            {

                departName = dt.Rows[0][0].ToString();

            }
            return departName;

        }
        
    }
}
