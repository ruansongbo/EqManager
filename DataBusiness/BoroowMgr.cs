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
        /// 得到某笔资产最大可领用数量
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
        /// 资产领用
        /// </summary>
        /// <param name="br"></param>
        /// <returns></returns>
        public static bool Add(Borrow br)
        {
            string id = br.ID;//流水号
            string eqNo = br.EqNo;//资产编码
            string eqName = br.EqName;//资产名称
            string depart = br.Department;//所属部门
            string keepPlace = br.KeepPlace;//保管地点
            string keeper = br.Keeper;//保管人
            string borrower = br.Borrower;//借用人
            string bAgent = br.BAgent;//外借经办人
            DateTime bDate = br.BDate;//借用日期
            DateTime rDate = br.RDate;//归还日期
            string remark = br.bRemark;//备注
            string sql = string.Format("INSERT BorrowLog(serialNo, EqNo, EqName, departId, KeepPlace, EqKeeper, borrower, bAgent, bDate, rDate, bRemark, state) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')",
                id, eqNo, eqName, depart, keepPlace, keeper, borrower, bAgent, bDate, rDate, remark, "借出待审核");
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }
        /// <summary>
        /// 资产领用
        /// </summary>
        /// <param name="br"></param>
        /// <returns></returns>
        public static bool AddWithoutVerify(Borrow br)
        {
            string id = br.ID;//流水号
            string eqNo = br.EqNo;//资产编码
            string eqName = br.EqName;//资产名称
            string depart = br.Department;//所属部门
            string keepPlace = br.KeepPlace;//保管地点
            string keeper = br.Keeper;//保管人
            string borrower = br.Borrower;//借用人
            string bAgent = br.BAgent;//外借经办人
            DateTime bDate = br.BDate;//借用日期
            DateTime rDate = br.RDate;//归还日期
            string remark = br.bRemark;//备注
            string sql = string.Format("INSERT BorrowLog(serialNo, EqNo, EqName, departId, KeepPlace, EqKeeper, borrower, bAgent, bDate, rDate, bRemark, state) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')",
                id, eqNo, eqName, depart, keepPlace, keeper, borrower, bAgent, bDate, rDate, remark, "已借出");
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }
        /// <summary>
        /// 更新资产领用
        /// </summary>
        /// <param name="br"></param>
        /// <returns></returns>
        public static bool BUpdate(string ID, Borrow br)
        {
            string borrower = br.Borrower;//借用人
            DateTime bDate = br.BDate;//借用日期
            DateTime rDate = br.RDate;//归还日期
            string remark = br.bRemark;//备注
            string sql = string.Format("update BorrowLog set  borrower='{1}', bDate='{2}', rDate='{3}', bRemark='{4}', state='{5}' where serialNo='{0}'",
                ID, borrower, bDate, rDate, remark, "借出待审核");
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }
        /// <summary>
        /// 更新资产归还
        /// </summary>
        /// <param name="br"></param>
        /// <returns></returns>
        public static bool RUpdate(string ID, Borrow br)
        {
            string sql = string.Format("update BorrowLog set  rAgent='{1}', rDate='{2}', rRemark='{3}', state='{4}'where serialNo='{0}'",
                ID, br.RAgent, br.RDate, br.rRemark, "归还待审核");
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }
        /// <summary>
        /// 更新资产归还
        /// </summary>
        /// <param name="br"></param>
        /// <returns></returns>
        public static bool RUpdateWithoutVerify(string ID, Borrow br)
        {
            string sql = string.Format("update BorrowLog set  rAgent='{1}', rDate='{2}', rRemark='{3}', state='{4}'where serialNo='{0}'",
                ID, br.RAgent, br.RDate, br.rRemark, "已归还");
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }
        /// <summary>
        /// 得到某员工领用的某一笔资产的相关信息
        /// </summary>
        /// <param name="eqno">资产编码</param>
        /// <param name="boorow">领用人id</param>
        /// <returns></returns>

        public static DataTable GetOneBorrow(string ID)
        {
            string sql = string.Format("SELECT borrower,bDate,rDate,bRemark, EqNo FROM BorrowLog WHERE serialNo='{0}'", ID);
            sqlHandler sh = new sqlHandler();
            DataTable dt = sh.GetData(sql);
            return dt != null ? dt : null; 
        }
        /// <summary>
        /// 得到某员工领用的某一笔资产的完整信息
        /// </summary>
        /// <param name="eqno">资产编码</param>
        /// <param name="boorow">领用人id</param>
        /// <returns></returns>

        public static DataTable GetOneAllBorrow(string ID)
        {
            string sql = string.Format("SELECT * FROM View_BorrowLog WHERE 流水号='{0}'", ID);
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
        public static DataTable getAuditList(string agent)
        {
            sqlHandler sh = new sqlHandler();

            string sql = string.Format("select * from View_BorrowLog where 状态 like '%审核' or (外借经办人 = '{0}' and 状态 = '已借出')", agent);
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
        /// 得到待审核信息
        /// </summary>
        /// <param name="agent">用户</param>
        /// <returns></returns>
        public static DataTable getUnAuditList(string agent)
        {
            sqlHandler sh = new sqlHandler();
            string sql = string.Format("SELECT * FROM View_BorrowLog WHERE 状态 IN ('借出待审核','借出审核未通过','已借出','归还待审核') AND 外借经办人 = '{0}'", agent);
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
        /// 借用审核通过
        /// </summary>
        /// <param name="ID">流水号</param>
        /// <param name="bReviewer">用户</param>
        /// <returns></returns>
        public static bool agreeBAudit(string ID, string user)
        {
            string sql = string.Format("update BorrowLog set bReviewer='{1}', state='已借出' where serialNo='{0}'", ID, user);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;

        }
        /// <summary>
        /// 归还审核通过
        /// </summary>
        /// <param name="ID">流水号</param>
        /// <param name="bReviewer">用户</param>
        /// <returns></returns>
        public static bool agreeRAudit(string ID, string user)
        {
            string sql = string.Format("update BorrowLog set rReviewer='{1}', state='已归还' where serialNo='{0}'", ID, user);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;

        }
        /// <summary>
        /// 借用审核未通过
        /// </summary>
        /// <param name="ID">流水号</param>
        /// <param name="bReviewer">用户</param>
        /// <returns></returns>
        public static bool disagreeAudit(string ID, string user)
        {
            string sql = string.Format("update BorrowLog set bReviewer='{1}', state='借出审核未通过' where serialNo='{0}'", ID, user);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;

        }
        /// <summary>
        /// 删除借用信息
        /// </summary>
        /// <param name="ID">流水号</param>
        /// <param name="bReviewer">用户</param>
        /// <returns></returns>
        public static bool deleteAudit(string ID)
        {
            string sql = string.Format("DELETE BorrowLog WHERE serialNo='{0}'", ID);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }
        /// <summary>
        /// 得到所有的资产领用信息
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
        /// 按部门统计资产的领用
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
        /// 统计各类资产领用的总量
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
                sql = "select * from View_BorrowLog order by 流水号";
            else if (power == "2")
                sql = string.Format("select * from View_BorrowLog where 部门编号 like '{0}%'order by 流水号", departId.Substring(0, 2));
            else
                sql = string.Format("select * from View_BorrowLog where 部门编号='{0}'order by 流水号", departId);

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
                        sql = string.Format("select {0} from View_BorrowLog order by 流水号", selectItem);
                    else if (power == "2")
                        sql = string.Format("select {1} from View_BorrowLog where 部门编号 like '{0}%'order by 流水号", departId.Substring(0, 2), selectItem);
                    else
                        sql = string.Format("select {1} from View_BorrowLog where 部门编号='{0}'order by 流水号", departId, selectItem);
                }
                else
                {
                    if (power == "0" || power == "1")
                        sql = string.Format("select {0} from View_BorrowLog order by {1}", selectItem, OrderString);
                    else if (power == "2")
                        sql = string.Format("select {1} from View_BorrowLog where 部门编号 like '{0}%'order by {2}", departId.Substring(0, 2), selectItem, OrderString);
                    else
                        sql = string.Format("select {1} from View_BorrowLog where 部门编号='{0}'order by {2}", departId, selectItem, OrderString);
                }

            }
            else
            {
                if (string.IsNullOrEmpty(OrderString))
                {
                    if (power == "0" || power == "1")
                        sql = string.Format("select {0} from View_BorrowLog where {1} order by 流水号", selectItem, sortSet);
                    else if (power == "2")
                        sql = string.Format("select {1} from View_BorrowLog where 部门编号 like '{0}%' and {2} order by 流水号", departId.Substring(0, 2), selectItem, sortSet);
                    else
                        sql = string.Format("select {1} from View_BorrowLog where 部门编号='{0}'and {2} order by 流水号", departId, selectItem, sortSet);
                }
                else
                {
                    if (power == "0" || power == "1")
                        sql = string.Format("select {0} from View_BorrowLog where {1} order by {2}", selectItem, sortSet, OrderString);
                    else if (power == "2")
                        sql = string.Format("select {1} from View_BorrowLog where 部门编号 like '{0}%' and {2} order by {3}", departId.Substring(0, 2), selectItem, sortSet, OrderString);
                    else
                        sql = string.Format("select {1} from View_BorrowLog where 部门编号='{0}' and {2} order by {3}", departId, selectItem, sortSet, OrderString);
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
                    sql = string.Format("select distinct {0} from View_BorrowLog order by {0}", Column);
                else if (power == "2")
                    sql = string.Format("select distinct {1} from View_BorrowLog where 部门编号 like '{0}%'order by {1}", departId.Substring(0, 2), Column);
                else
                    sql = string.Format("select distinct {1} from View_BorrowLog where 部门编号='{0}'order by {1}", departId, Column);

            }
            else
            {
                if (power == "0" || power == "1")
                    sql = string.Format("select distinct {0} from View_BorrowLog where {1} order by {0}", Column, sortSet);
                else if (power == "2")
                    sql = string.Format("select distinct {1} from View_BorrowLog where 部门编号 like '{0}%' and {2} order by {1}", departId.Substring(0, 2), Column, sortSet);
                else
                    sql = string.Format("select distinct {1} from View_BorrowLog where 部门编号='{0}'and {2} order by {1}", departId, Column, sortSet);
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
        /// 通过资产编码获得流水单号
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
        /// 通过流水单号获得资产状态
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
