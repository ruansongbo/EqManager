using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Equipment_Manager
{
    public partial class frmSelectItem : Form
    {
        private static List<string> AvailableColumns = new List<string>();  // All Columns avaiable in DataGrid
        private static List<string> SelectedColumns = new List<string>();   // The Columns Selected by user to print. 

        public delegate void UpdateEventHandler();
        public event UpdateEventHandler UpdateEvent;

        public frmSelectItem()
        {
            InitializeComponent();
        }

        public frmSelectItem(List<string> availableColumns, List<string> selectedColumns)
        {
            InitializeComponent();
            AvailableColumns = availableColumns;
            SelectedColumns = selectedColumns;
        }
        private void frmSelectItem_Load(object sender, EventArgs e)
        {
            foreach (string field in AvailableColumns)
            {
                if (SelectedColumns.Contains(field))
                {
                    chklst.Items.Add(field, true);
                }
                else
                {
                    chklst.Items.Add(field, false);
                }
            }
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

        private void Select_button_Click(object sender, EventArgs e)
        {
            SelectedColumns.Clear();
            for (int i = 0; i < chklst.Items.Count; i++)
            {
                if (chklst.GetItemChecked(i))
                {
                    SelectedColumns.Add(chklst.Items[i].ToString());
                }
            }
            if (UpdateEvent != null)
            {
                UpdateEvent();
            }
            this.Close();
         }

        private void Cancel_button_Click(object sender, EventArgs e)
        {
             this.Close();
        }
    }
}
