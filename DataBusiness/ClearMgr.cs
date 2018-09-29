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
        /// 资产注销
        /// </summary>
        /// <param name="fix"></param>
        /// <returns></returns>
        public static bool Add(Clear clear)
        {
            string id = clear.ID;//流水号
            string eqNo = clear.EqNo;//资产编码
            string eqName = clear.EqName;//资产名称
            string depart = clear.Department;//所属部门
            string keepPlace = clear.KeepPlace;//保管地点
            string keeper = clear.Keeper;//保管人
            string cType = clear.CType;//注销方式
            string cAgent = clear.CAgent;//注销经办人
            DateTime cDate = clear.CDate;//注销日期
            string remark = clear.Remark;//备注
            string sql = string.Format("INSERT ClearLog(serialNo, EqNo, EqName, departId, KeepPlace, EqKeeper, cType, cAgent, cDate, remark, state) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')",
                id, eqNo, eqName, depart, keepPlace, keeper, cType, cAgent, cDate, remark, "注销待审核");
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }

        /// <summary>
        /// 资产注销
        /// </summary>
        /// <param name="fix"></param>
        /// <returns></returns>
        public static bool AddWithoutVerify(Clear clear)
        {
            string id = clear.ID;//流水号
            string eqNo = clear.EqNo;//资产编码
            string eqName = clear.EqName;//资产名称
            string depart = clear.Department;//所属部门
            string keepPlace = clear.KeepPlace;//保管地点
            string keeper = clear.Keeper;//保管人
            string cType = clear.CType;//注销方式
            string cAgent = clear.CAgent;//注销经办人
            DateTime cDate = clear.CDate;//注销日期
            string remark = clear.Remark;//备注
            string sql = string.Format("INSERT ClearLog(serialNo, EqNo, EqName, departId, KeepPlace, EqKeeper, cType, cAgent, cDate, remark, state) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')",
                id, eqNo, eqName, depart, keepPlace, keeper, cType, cAgent, cDate, remark, "已注销");
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }

        /// <summary>
        /// 更新资产领用
        /// </summary>
        /// <param name="br"></param>
        /// <returns></returns>
        public static bool CUpdate(string ID, Clear clear)
        {
            string cType = clear.CType;//注销方式
            DateTime cDate = clear.CDate;//借用日期
            string remark = clear.Remark;//备注
            string sql = string.Format("update ClearLog set  cType='{1}', cDate='{2}', remark='{3}', state='{4}' where serialNo='{0}'",
                ID, cType, cDate, remark, "注销待审核");
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }
        /// <summary>
        /// 得到某员工注销的某一笔资产的相关信息
        /// </summary>
        /// <param name="serialNo">单号号</param>
        /// <returns></returns>

        public static DataTable GetOneClear(string serialNo)
        {
            string sql = string.Format("SELECT cType, cDate, remark, EqNo FROM ClearLog WHERE serialNo='{0}'", serialNo);
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null;
        }

        /// <summary>
        /// 得到审核信息
        /// </summary>
        /// <param name="departId">部门</param>
        /// <param name="power">权限</param>
        /// <returns></returns>
        public static DataTable getAuditList(string departId, string power)
        {
            sqlHandler sh = new sqlHandler();
            string sql = "";
            if (power == "0" || power == "1")
            {
                sql = "select * from View_ClearLog where 状态 like '%审核'";
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
                MessageBox.Show("无权限");
                return null;
            }
        }
        /// <summary>
        /// 得到审核信息单数
        /// </summary>
        /// <returns></returns>
        public static int getAuditListCount()
        {
            sqlHandler sh = new sqlHandler();
            string sql = string.Format("select count(*) from (select * from View_ClearLog where 状态 like '%审核') AS M");
            DataTable dt = sh.GetData(sql);
            int result = 0;
            if (dt != null)
            {
                result = int.Parse(dt.Rows[0][0].ToString());
            }

            return result;
        }
        /// <summary>
        /// 得到待审核信息
        /// </summary>
        /// <param name="agent">用户</param>
        /// <returns></returns>
        public static DataTable getUnAuditList(string agent)
        {
            sqlHandler sh = new sqlHandler();
            string sql = string.Format("SELECT * FROM View_ClearLog WHERE 状态 IN ('注销待审核','注销审核未通过') AND 注销经办人 = '{0}'", agent);
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
        /// 得到待审核信息单数
        /// </summary>
        /// <returns></returns>
        public static int getUnAuditListCount(string agent)
        {
            sqlHandler sh = new sqlHandler();
            string sql = string.Format("select count(*) from (SELECT * FROM View_ClearLog WHERE 状态 IN ('注销待审核','注销审核未通过') AND 注销经办人 = '{0}') AS M", agent);
            DataTable dt = sh.GetData(sql);
            int result = 0;
            if (dt != null)
            {
                result = int.Parse(dt.Rows[0][0].ToString());
            }

            return result;
        }
        /// <summary>
        /// 注销审核通过
        /// </summary>
        /// <param name="ID">流水号</param>
        /// <param name="bReviewer">用户</param>
        /// <returns></returns>
        public static bool agreeAudit(string ID, string user)
        {
            string sql = string.Format("update ClearLog set cReviewer='{1}', state='已注销' where serialNo='{0}'", ID, user);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }
        /// <summary>
        /// 注销审核未通过
        /// </summary>
        /// <param name="ID">流水号</param>
        /// <param name="bReviewer">用户</param>
        /// <returns></returns>
        public static bool disagreeAudit(string ID, string user, string audit)
        {
            string sql = string.Format("update ClearLog set cReviewer='{1}', state='注销审核未通过' , audit='{2}'where serialNo='{0}'", ID, user, audit);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }
        /// <summary>
        /// 删除注销信息
        /// </summary>
        /// <param name="ID">流水号</param>
        /// <param name="bReviewer">用户</param>
        /// <returns></returns>
        public static bool deleteAudit(string ID)
        {
            string sql = string.Format("DELETE ClearLog WHERE serialNo='{0}'", ID);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }
        /// <summary>
        /// 得到所有注销方式
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
        /// 得到资产信息(分页)
        /// </summary>
        /// <param name="start">起始页</param>
        /// <param name="max">最大条数</param>
        /// <returns></returns>
        public static DataTable getLogList(int start, int max, string departId, string power)
        {
            sqlHandler sh = new sqlHandler();
            string sql = "";
            if (power == "0" || power == "1")
                sql = "select * from View_ClearLog order by 流水号";
            else if (power == "2")
                sql = string.Format("select * from View_ClearLog where 部门编号 like '{0}%'order by 流水号", departId.Substring(0, 2));
            else
                sql = string.Format("select * from View_ClearLog where 部门编号='{0}'order by 流水号", departId);

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
        /// 得到资产信息的总条数
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
        /// 得到筛选资产信息(分页)
        /// </summary>
        /// <param name="start">起始页</param>
        /// <param name="max">最大条数</param>
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
                        sql = string.Format("select {0} from View_ClearLog order by 流水号", selectItem);
                    else if (power == "2")
                        sql = string.Format("select {1} from View_ClearLog where 部门编号 like '{0}%'order by 流水号", departId.Substring(0, 2), selectItem);
                    else
                        sql = string.Format("select {1} from View_ClearLog where 部门编号='{0}'order by 流水号", departId, selectItem);
                }
                else
                {
                    if (power == "0" || power == "1")
                        sql = string.Format("select {0} from View_ClearLog order by {1}", selectItem, OrderString);
                    else if (power == "2")
                        sql = string.Format("select {1} from View_ClearLog where 部门编号 like '{0}%'order by {2}", departId.Substring(0, 2), selectItem, OrderString);
                    else
                        sql = string.Format("select {1} from View_ClearLog where 部门编号='{0}'order by {2}", departId, selectItem, OrderString);
                }

            }
            else
            {
                if (string.IsNullOrEmpty(OrderString))
                {
                    if (power == "0" || power == "1")
                        sql = string.Format("select {0} from View_ClearLog where {1} order by 流水号", selectItem, sortSet);
                    else if (power == "2")
                        sql = string.Format("select {1} from View_ClearLog where 部门编号 like '{0}%' and {2} order by 流水号", departId.Substring(0, 2), selectItem, sortSet);
                    else
                        sql = string.Format("select {1} from View_ClearLog where 部门编号='{0}'and {2} order by 流水号", departId, selectItem, sortSet);
                }
                else
                {
                    if (power == "0" || power == "1")
                        sql = string.Format("select {0} from View_ClearLog where {1} order by {2}", selectItem, sortSet, OrderString);
                    else if (power == "2")
                        sql = string.Format("select {1} from View_ClearLog where 部门编号 like '{0}%' and {2} order by {3}", departId.Substring(0, 2), selectItem, sortSet, OrderString);
                    else
                        sql = string.Format("select {1} from View_ClearLog where 部门编号='{0}' and {2} order by {3}", departId, selectItem, sortSet, OrderString);
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
        /// 得到筛选后某列的所有值
        /// </summary>
        /// <param name="start">起始页</param>
        /// <param name="max">最大条数</param>
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
                    sql = string.Format("select distinct {1} from View_ClearLog where 部门编号 like '{0}%'order by {1}", departId.Substring(0, 2), Column);
                else
                    sql = string.Format("select distinct {1} from View_ClearLog where 部门编号='{0}'order by {1}", departId, Column);

            }
            else
            {
                if (power == "0" || power == "1")
                    sql = string.Format("select distinct {0} from View_ClearLog where {1} order by {0}", Column, sortSet);
                else if (power == "2")
                    sql = string.Format("select distinct {1} from View_ClearLog where 部门编号 like '{0}%' and {2} order by {1}", departId.Substring(0, 2), Column, sortSet);
                else
                    sql = string.Format("select distinct {1} from View_ClearLog where 部门编号='{0}'and {2} order by {1}", departId, Column, sortSet);
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
