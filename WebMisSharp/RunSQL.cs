using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DockPanelUI.Docking;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;

namespace WebMisSharp
{
    public partial class RunSQL : DockContent
    {
        public RunSQL()
        {
            InitializeComponent();
        }

        //执行查询
        private void ExecSQL()
        {
            string SQLstring;
            if (txtSQL.ActiveTextAreaControl.SelectionManager.SelectedText.Length > 1)
            {
                SQLstring = txtSQL.ActiveTextAreaControl.SelectionManager.SelectedText;
            }
            else
            {
                SQLstring = txtSQL.Text;
            }
            MessageBox.Show(SQLstring);
        }

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
    }
}
