using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BaseLibs;
using BaseLibs;

namespace MisSharp.UserCtrls
{
    public partial class FieldSettings : UserControl
    {
        public FieldSettings()
        {
            InitializeComponent();
            BindXML();
        }
        private void BindXML()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(XMLPaths.DBTypeXml);
            BindingSource bs = new BindingSource();
            bs.DataSource = ds.Tables[2];
            this.DGVMSSQL.DataSource = bs;
        }
        //单击单元格时候
        private void DGVMSSQL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                TxtKey.Text = DGVMSSQL.Rows[e.RowIndex].Cells[0].Value.ToString();
                TxtValue.Text = DGVMSSQL.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }
        //保存按钮
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (TxtKey.Text.Trim().Length <= 0 || TxtValue.Text.Trim().Length <= 0)
            {
                MessageBox.Show("请输入数据库数据类型和对应的C#类型！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (XMLHelper.Read(XMLPaths.DBTypeXml, "/Map/SQLSERVER/SQLSERVER2008[@key='" + TxtKey.Text.Trim() + "']", "value") != "")
                XMLHelper.Update(XMLPaths.DBTypeXml, "/Map/SQLSERVER/SQLSERVER2008[@key='" + TxtKey.Text.Trim() + "']", "value", TxtValue.Text.Trim());
            else
            {
                XMLHelper.Insert(XMLPaths.DBTypeXml, "/Map/SQLSERVER", "SQLSERVER2008", "key", TxtKey.Text.Trim());
                XMLHelper.Insert(XMLPaths.DBTypeXml, "/Map/SQLSERVER/SQLSERVER2008[@key='" + TxtKey.Text.Trim() + "']", "", "value", TxtValue.Text.Trim());
            }
            BindXML();
            MessageBox.Show("保存成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //删除按钮
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (TxtKey.Text.Trim().Length <= 0 || TxtValue.Text.Trim().Length <= 0)
            {
                MessageBox.Show("请先选择要删除的行！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            XMLHelper.Delete(XMLPaths.DBTypeXml, "/Map/SQLSERVER/SQLSERVER2008[@key='" + TxtKey.Text.Trim() + "']", "");
            BindXML(); 
            MessageBox.Show("删除成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
