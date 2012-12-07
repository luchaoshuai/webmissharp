using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DockPanelUI.Docking;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;
using System.Data.SqlClient;
using BaseLibs;
using BaseLibs;

namespace MisSharp
{
    public partial class RunSQL : DockContent
    {
        MisSharp GlobalForm = null;
        string TableName = "";
        public RunSQL(string SQL="")
        {
            InitializeComponent();
            GlobalForm = (MisSharp)Application.OpenForms["WebMisSharp"];
            txtSQL.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("TSQL");
            txtSQL.ShowInvalidLines = false;
            txtSQL.Text = SQL;
        }

        //执行查询
        private void ExecSQL()
        {
            string SQLstring;
            if (txtSQL.ActiveTextAreaControl.SelectionManager.SelectedText.Length > 1)
            {
                SQLstring = txtSQL.ActiveTextAreaControl.SelectionManager.SelectedText.Trim();
            }
            else
            {
                SQLstring = txtSQL.Text.Trim();
            }
            string _sqlconn_str = XMLHelper.Read(XMLPaths.ProjectXml, "/Root/Project[@Name='" + GlobalForm.LbGlobalProject.Text + "']/DBConStr", "");
            if (SQLstring.ToLower().StartsWith("select"))
            {
                SqlConnection connection = new SqlConnection(_sqlconn_str);
                DataTable dt = new DataTable();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLstring, connection);
                    DataSet ds = new DataSet();
                    command.Fill(ds, "Table");
                    dt = ds.Tables["Table"];
                    dataGridResult.DataSource = dt;
                    this.txtMsgs.Text = dt.Rows.Count.ToString() + " 条数据";
                    tabControl.SelectedIndex = 0;
                    //获取TableName
                    TableName = SQLstring.ToLower().Substring(SQLstring.ToLower().IndexOf("from ") + 5).Trim();
                    TableName = TableName.Contains(" ") ? TableName.Substring(0,TableName.IndexOf(" ")).Trim() : TableName;
                    ReLoadColunmsName();
                }
                catch(Exception error)
                {
                    dataGridResult.DataSource = null;
                    this.txtMsgs.Text = error.Message;
                    tabControl.SelectedIndex = 1;
                }
                finally
                {
                    connection.Close();
                }
            }
            else
            {
                SqlConnection connection = new SqlConnection(_sqlconn_str);
                SqlCommand cmd = new SqlCommand(SQLstring, connection);
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    dataGridResult.DataSource = null;
                    this.txtMsgs.Text = rows.ToString() + "行受影响";
                }
                catch(Exception error)
                {
                    dataGridResult.DataSource = null;
                    this.txtMsgs.Text = error.Message;
                }
                finally
                {
                    connection.Close();
                }
                tabControl.SelectedIndex = 1;
            }
        }

        private void ReLoadColunmsName()
        {
            if (TableName != "")
            {
                DataTable dt = DBHelper.SQLDBHelper.GetColumnsDesc(GlobalForm.LbGlobalProject.Text, TableName);
                for (int i = 0; i < dataGridResult.Columns.Count; i++)
                {
                    DataRow[] dr = dt.Select("FieldName='" + dataGridResult.Columns[i].HeaderCell.Value.ToString().ToLower() + "'");
                    if (dr.Count() > 0)
                    {
                         dataGridResult.Columns[i].HeaderCell.Value += "\r\n" + dr[0][1].ToString();
                    }
                }
            }
        }

        #region 调用编辑器API
        private void button1_Click(object sender, EventArgs e)
        {
            DoEditAction(txtSQL,new ICSharpCode.TextEditor.Actions.Undo());
            //ExecSQL();
        }

        private void DoEditAction(TextEditorControl editor, ICSharpCode.TextEditor.Actions.IEditAction action)
        {
            if (editor != null && action != null)
            {
                TextArea area = editor.ActiveTextAreaControl.TextArea;
                editor.BeginUpdate();
                try
                {
                    lock (editor.Document)
                    {
                        action.Execute(area);
                        if (area.SelectionManager.HasSomethingSelected && area.AutoClearSelection /*&& caretchanged*/)
                        {
                            if (area.Document.TextEditorProperties.DocumentSelectionMode == DocumentSelectionMode.Normal)
                            {
                                area.SelectionManager.ClearSelection();
                            }
                        }
                    }
                }
                finally
                {
                    editor.EndUpdate();
                    area.Caret.UpdateCaretPosition();
                }
            }
        }
        #endregion

        private void 执行SQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExecSQL();
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            if (sf.ShowDialog() == DialogResult.OK)
            {
                FileHelper.WriteFile(sf.FileName, txtSQL.Text);
            }
        }
    }
}
