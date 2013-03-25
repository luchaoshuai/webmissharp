using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DBHelper;
using Core;

namespace WebMisSharp
{
    public partial class ConfigComBoxStore : Form
    {
        string ProjectName = "";
        List<ComBoxStore> storeList = null;
        public ConfigComBoxStore(List<ComBoxStore> store,string proj)
        {
            InitializeComponent();
            this.DGVComboxStore.DataError += delegate(object sender, DataGridViewDataErrorEventArgs e) { };
            ProjectName = proj;
            storeList = store;
        }

        private void ConfigComBoxStore_Load(object sender, EventArgs e)
        {
            DGVComboxStore.DataSource = storeList;
            DataGridViewComboBoxColumn lDgvCbC = (DataGridViewComboBoxColumn)this.DGVComboxStore.Columns["TableName"];
            lDgvCbC.DataSource = SQLDBHelper.GetTableView(ProjectName);
            lDgvCbC.DisplayMember = "TableName";

            foreach (DataGridViewRow dr in this.DGVComboxStore.Rows)
            {
                if (dr.Cells["TableName"].Value == null) continue;
                DataGridViewComboBoxCell lDgvD = (DataGridViewComboBoxCell)dr.Cells["Display"];
                DataGridViewComboBoxCell lDgvV = (DataGridViewComboBoxCell)dr.Cells["Value"];
                lDgvD.DataSource = lDgvV.DataSource = SQLDBHelper.GetTableViewStruct(ProjectName, dr.Cells["TableName"].Value.ToString());
                lDgvD.DisplayMember = "name";
                lDgvV.DisplayMember = "name";
            }
        }

        //当选择完表的时候
        private void DGVComboxStore_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex > -1)
            {
                DataGridViewComboBoxCell lDgvD = (DataGridViewComboBoxCell)this.DGVComboxStore.Rows[e.RowIndex].Cells["Display"];
                DataGridViewComboBoxCell lDgvV = (DataGridViewComboBoxCell)this.DGVComboxStore.Rows[e.RowIndex].Cells["Value"];
                lDgvD.DataSource = lDgvV.DataSource = SQLDBHelper.GetTableViewStruct(ProjectName, DGVComboxStore.Rows[e.RowIndex].Cells["TableName"].Value.ToString());
                lDgvD.DisplayMember = "name";
                lDgvV.DisplayMember = "name";
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in DGVComboxStore.Rows)
            {
                ComBoxStore store = storeList.First<ComBoxStore>(delegate(ComBoxStore l) { return l.FieldName == dr.Cells["FieldName"].Value.ToString(); });
                store.TableName = dr.Cells["TableName"].Value == null ? "" : dr.Cells["TableName"].Value.ToString();
                store.Display = dr.Cells["Display"].Value == null ? "" : dr.Cells["Display"].Value.ToString();
                store.Value = dr.Cells["Value"].Value == null ? "" : dr.Cells["Value"].Value.ToString();
                store.Conditions = dr.Cells["Conditions"].Value == null ? "" : dr.Cells["Conditions"].Value.ToString();
            }
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
