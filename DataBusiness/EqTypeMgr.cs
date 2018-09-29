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
        /// �õ����е��ʲ�����
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
        /// ����ʲ�����
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
        /// ɾ���ʲ�����
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
        /// ��ȡ��ǰDataGridView���ʲ���������
        /// </summary>
        /// <param name="view">��Ҫ����DataGridView</param>
        /// <returns>���е�ǰ���������б�</returns>
        public static List<string>  GetEqTypes(DataGridView view)
        {
            List<string> types=new List<string>{""};
            string eqtype="";
            //����һ�е��ʲ���������������λ
            types[0] = view["�ʲ����", 0].Value.ToString();
            for (int row = 1; row < view.RowCount; row++)
            {
                eqtype=view["�ʲ����",row].Value.ToString();
                if (types.Contains(eqtype))
                    continue;
                else
                    types.Add(eqtype);
                if (types.Count == 8)//��ǰ��������Ϊ4
                    return types;
            }
            return types;
        }

        public static List<string> GetEqTypes(DataTable dt)
        {
            List<string> types = new List<string> { "" };
            string eqtype = "";
            //����һ�е��ʲ���������������λ
            types[0] = dt.Rows[0]["�ʲ����"].ToString();
            for (int row = 1; row < dt.Rows.Count; row++)
            {
                eqtype = dt.Rows[row]["�ʲ����"].ToString();
                if (types.Contains(eqtype))
                    continue;
                else
                    types.Add(eqtype);
                if (types.Count == 8)//��ǰ��������Ϊ4
                    return types;
            }
            return types;
        }

        public static List<string> GetScEqTypes(DataGridView view)
        {
            List<string> types = new List<string> { "" };
            string eqtype = "";
            //����һ�е��ʲ���������������λ
            types[0] = view.SelectedRows[0].Cells["�ʲ����"].Value.ToString();
            for (int row = 1; row < view.SelectedRows.Count; row++)
            {
                eqtype = view.SelectedRows[row].Cells["�ʲ����"].Value.ToString();
                if (types.Contains(eqtype))
                    continue;
                else
                    types.Add(eqtype);
                if (types.Count == 8)//��ǰ��������Ϊ8
                    return types;
            }
            return types;
        }


        /// <summary>
        /// �����ʲ�����xml�л�ȡExcel��ͷ
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static List<string> GetHeader(string type)
        {
            List<string> list = new List<string>();
            XmlDocument xml = new XmlDocument();
            //���xml�ļ���Equipment_Manager�£�����ȥ�����޸�
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
        /// �Զ������ʲ�����
        /// </summary>
        private  static string SetEqNo()
        {
            string No = EqMgr.GetLastEqNo();
            string yy = DateTime.Now.Year.ToString();
            string eqno="";
            if (No != "")
            {
                //��������ݿ��в鵽��ֵ������ԭ�б�ź��Լ�1
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
