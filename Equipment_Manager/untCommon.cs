using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

//using Excel = Microsoft.Office.Interop.Excel;

namespace Equipment_Manager
{
    class untCommon
    {
        /// <summary>
        /// ��Ϣ�Ի���
        /// </summary>
        /// <param name="txt">�ı�</param>
        /// <param name="title">����</param>
        public static void InfoMsg(string txt)
        {
            
            MessageBox.Show(txt, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// ����Ի���
        /// </summary>
        /// <param name="txt">�ı�</param>
        /// <param name="title">����</param>
        public static void ErrorMsg(string txt)
        {

            MessageBox.Show(txt," ����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }
        /// <summary>
        /// ����Ի���
        /// </summary>
        /// <param name="txt">�ı�</param>
        /// <param name="title">����</param>
        public static bool QuestionMsg(string txt)
        {

            if (MessageBox.Show(txt, "ȷ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// ��datagridview�е����ݵ�����excel�� 
        /// </summary>
        /// <param name="view">datagridview</param>
        /*public static void ToExel(DataGridView view)
        {
            if (view.Rows.Count == 0)
            {
                untCommon.InfoMsg("�����û�����ݣ����ܵ����ձ�");
                return;
            }

            //����Excel����
            Excel.Application excel = new Excel.Application();
            excel.Application.Workbooks.Add(true);
            excel.Visible = true;
            //�����ֶ�����
            for (int i = 0; i < view.ColumnCount; i++)
            {

                excel.Cells[1, i + 1] = view.Columns[i].HeaderText;
            }
            //�������
            for (int row = 0; row <= view.RowCount - 1; row++)
            {
                for (int column = 0; column < view.ColumnCount; column++)
                {

                    if (view[column, row].ValueType == typeof(string))
                    {
                        excel.Cells[row + 2, column + 1] = "'" + view[column, row].Value.ToString();
                    }
                    else
                    {
                        excel.Cells[row + 2, column + 1] = view[column, row].Value.ToString();
                    }
                }
            }
        }*/
    }
}
