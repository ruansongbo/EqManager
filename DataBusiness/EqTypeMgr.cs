using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using System.Xml;

using DataEntity;
using DataBusiness;
using DataAccess;

namespace DataBusiness
{
    public class EqTypeMgr
    {
        /// <summary>
        /// 得到所有的资产类型
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllType()
        {
            string sql = "select distinct gbType from Gb";
            sqlHandler sh=new sqlHandler();
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
        /// 添加资产类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool AddType(string type)
        {
            string sql = string.Format("insert into type values('{0}')", type);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }
        /// <summary>
        /// 删除资产类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool Del(int id)
        {
            string sql = string.Format("delete from type where id={0}", id);
            sqlHandler sh = new sqlHandler();
            return sh.ExecuteNonQuery(sql) > 0;
        }

        /// <summary>
        /// 获取当前DataGridView上资产类别的种类
        /// </summary>
        /// <param name="view">需要检测的DataGridView</param>
        /// <returns>含有当前所有类别的列表</returns>
        public static List<string>  GetEqTypes(DataGridView view)
        {
            List<string> types=new List<string>{""};
            string eqtype="";
            //将第一行的资产类别赋予类别数组首位
            types[0] = view["资产类别", 0].Value.ToString();
            for (int row = 1; row < view.RowCount; row++)
            {
                eqtype=view["资产类别",row].Value.ToString();
                if (types.Contains(eqtype))
                    continue;
                else
                    types.Add(eqtype);
                if (types.Count == 8)//当前种类总数为4
                    return types;
            }
            return types;
        }

        public static List<string> GetEqTypes(DataTable dt)
        {
            List<string> types = new List<string> { "" };
            string eqtype = "";
            //将第一行的资产类别赋予类别数组首位
            types[0] = dt.Rows[0]["资产类别"].ToString();
            for (int row = 1; row < dt.Rows.Count; row++)
            {
                eqtype = dt.Rows[row]["资产类别"].ToString();
                if (types.Contains(eqtype))
                    continue;
                else
                    types.Add(eqtype);
                if (types.Count == 8)//当前种类总数为4
                    return types;
            }
            return types;
        }

        public static List<string> GetScEqTypes(DataGridView view)
        {
            List<string> types = new List<string> { "" };
            string eqtype = "";
            //将第一行的资产类别赋予类别数组首位
            types[0] = view.SelectedRows[0].Cells["资产类别"].Value.ToString();
            for (int row = 1; row < view.SelectedRows.Count; row++)
            {
                eqtype = view.SelectedRows[row].Cells["资产类别"].Value.ToString();
                if (types.Contains(eqtype))
                    continue;
                else
                    types.Add(eqtype);
                if (types.Count == 8)//当前种类总数为8
                    return types;
            }
            return types;
        }


        /// <summary>
        /// 根据资产类别从xml中获取Excel表头
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static List<string> GetHeader(string type)
        {
            List<string> list = new List<string>();
            XmlDocument xml = new XmlDocument();
            //这个xml文件在Equipment_Manager下，可以去那里修改
            xml.Load("xEqType.xml");
            XmlNode rootNode = xml.SelectSingleNode("EqTypeList");
            XmlNodeList firstLevelNodeList = rootNode.ChildNodes;
            foreach (XmlNode node in firstLevelNodeList)
            {
                if (node.Attributes["id"].Value == type)
                {
                    foreach (XmlNode snode in node)
                    {
                        list.Add(snode.InnerText);
                    }
                    break;
                }
                
            }
            return list;
        }



        


        

        /// <summary>
        /// 自动生成资产编码
        /// </summary>
        private  static string SetEqNo()
        {
            string No = EqMgr.GetLastEqNo();
            string yy = DateTime.Now.Year.ToString();
            string eqno="";
            if (No != "")
            {
                //如果从数据库中查到有值，就在原有编号后自加1
                eqno = (int.Parse(No) + 1).ToString();

            }
            else
            {
                eqno = yy + "000001";
            }
            return eqno;

        }
    }
}
