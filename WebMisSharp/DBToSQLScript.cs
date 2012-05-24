using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WebMisSharp
{
    public partial class DBToSQLScript : Form
    {
        WebMisSharp GlobalForm;
        public DBToSQLScript()
        {
            InitializeComponent();
            //加载所选项目基本信息
            GlobalForm = (WebMisSharp)Application.OpenForms["WebMisSharp"];
            GBTable.Text = "项目：" + GlobalForm.LbGlobalProject.Text + "   数据库:" + GlobalForm.LbGlobalDB.Text;
            LoadTables();
        }

        public void LoadTables()
        {
            DataTable dt = DBHelper.SQLDBHelper.GetAllTables(GlobalForm.LbGlobalProject.Text);
            foreach (DataRow dr in dt.Rows)
                lBSource.Items.Add(dr[0].ToString());
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            int c = this.lBSource.Items.Count;
            for (int i = 0; i < c; i++)
            {
                this.lBDest.Items.Add(this.lBSource.Items[i]);
            }
            this.lBSource.Items.Clear();
        }

        private void btnSome_Click(object sender, EventArgs e)
        {
            int c = this.lBSource.SelectedItems.Count;
            ListBox.SelectedObjectCollection objs = this.lBSource.SelectedItems;
            for (int i = 0; i < c; i++)
            {
                this.lBDest.Items.Add(lBSource.SelectedItems[i]);

            }
            for (int i = 0; i < c; i++)
            {
                if (this.lBSource.SelectedItems.Count > 0)
                {
                    this.lBSource.Items.Remove(lBSource.SelectedItems[0]);
                }
            }
        }

        private void btnSomeBack_Click(object sender, EventArgs e)
        {
            int c = this.lBDest.SelectedItems.Count;
            ListBox.SelectedObjectCollection objs = this.lBDest.SelectedItems;
            for (int i = 0; i < c; i++)
            {
                this.lBSource.Items.Add(lBDest.SelectedItems[i]);

            }
            for (int i = 0; i < c; i++)
            {
                if (this.lBDest.SelectedItems.Count > 0)
                {
                    this.lBDest.Items.Remove(lBDest.SelectedItems[0]);
                }
            }
        }

        private void btnAllBack_Click(object sender, EventArgs e)
        {
            int c = this.lBDest.Items.Count;
            for (int i = 0; i < c; i++)
            {
                this.lBSource.Items.Add(this.lBDest.Items[i]);
            }
            this.lBDest.Items.Clear();
        }

        private void lBSource_DoubleClick(object sender, EventArgs e)
        {
            if (this.lBSource.SelectedItem != null)
            {
                this.lBDest.Items.Add(lBSource.SelectedItem);
                this.lBSource.Items.Remove(this.lBSource.SelectedItem);
            }
        }

        private void lBDest_DoubleClick(object sender, EventArgs e)
        {
            if (this.lBDest.SelectedItem != null)
            {
                this.lBSource.Items.Add(lBDest.SelectedItem);
                this.lBDest.Items.Remove(this.lBDest.SelectedItem);
            }
        }
    }
}
