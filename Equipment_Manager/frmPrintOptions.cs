using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DGVPrinterHelper;

namespace Equipment_Manager
{
    public partial class frmPrintOptions : Form
    {
        public frmPrintOptions()
        {
            InitializeComponent();
        }
        private static DataGridView dgv;    // Holds DataGridView Object to print its contents
        private static DataGridView print_dgv;    // Holds DataGridView Object to print its contents
        private static List<string> AvailableColumns = new List<string>();  // All Columns avaiable in DataGrid
        private static List<string> SelectedColumns = new List<string>();   // The Columns Selected by user to print. 

        public frmPrintOptions(DataGridView dgv1)
        {
            InitializeComponent();
            // Getting DataGridView object to print
            dgv = CopyDataGridView(dgv1);
            // Getting all Coulmns Names in the DataGridView
            AvailableColumns.Clear();
            foreach (DataGridViewColumn c in dgv.Columns)
            {
                if (!c.Visible) continue;
                AvailableColumns.Add(c.HeaderText);
            }
            foreach (string field in AvailableColumns)
                chklst.Items.Add(field, true);   

        }

        private void frmPrintOptions_Load(object sender, EventArgs e)
        {  
                 
        }

        private void Select_All_button_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < chklst.Items.Count; j++)
                chklst.SetItemChecked(j, true); 
        }

        private void Select_None_button_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < chklst.Items.Count; j++)
                chklst.SetItemChecked(j, false); 
        }

        private void Invert_Selection_button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chklst.Items.Count; i++)
            {
                if (chklst.GetItemChecked(i))
                {
                    chklst.SetItemChecked(i, false);
                }
                else
                {
                    chklst.SetItemChecked(i, true);
                }
            }
        }

        private void Cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PrintePreview_button_Click(object sender, EventArgs e)
        {
            print_dgv = CopyDataGridView(dgv);
            for (int i = 0; i < chklst.Items.Count; i++)
            {
                if (!chklst.GetItemChecked(i))
                {
                    print_dgv.Columns.Remove(chklst.Items[i].ToString());
                }
            }
            DGVPrinter printer = new DGVPrinter();
            printer.Title = " ";
            printer.SubTitle = " ";
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.ShowTotalPageNumber = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "页 脚";
            printer.FooterSpacing = 15;
            printer.PageSeparator = " / ";
            printer.PageText = "页";
            printer.PrintPreviewDataGridView(print_dgv);
        }
        private DataGridView CopyDataGridView(DataGridView dgv_org)
        {
            DataGridView dgv_copy = new DataGridView();
            try
            {
                if (dgv_copy.Columns.Count == 0)
                {
                    foreach (DataGridViewColumn dgvc in dgv_org.Columns)
                    {
                        dgv_copy.Columns.Add(dgvc.Clone() as DataGridViewColumn);
                    }
                }

                DataGridViewRow row = new DataGridViewRow();

                for (int i = 0; i < dgv_org.Rows.Count; i++)
                {
                    row = (DataGridViewRow)dgv_org.Rows[i].Clone();
                    int intColIndex = 0;
                    foreach (DataGridViewCell cell in dgv_org.Rows[i].Cells)
                    {
                        row.Cells[intColIndex].Value = cell.Value;
                        intColIndex++;
                    }
                    dgv_copy.Rows.Add(row);
                }
                dgv_copy.AllowUserToAddRows = false;
                dgv_copy.Refresh();

            }
            catch (Exception ex)
            {
                untCommon.InfoMsg("Copy DataGridViw");
            }
            return dgv_copy;
        }

    }
}
