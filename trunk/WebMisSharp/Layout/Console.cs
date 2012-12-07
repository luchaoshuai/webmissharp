using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BaseLibs;

namespace MisSharp
{
    public partial class Console : DockPanelUI.Docking.DockContent
    {
        public Console()
        {
            InitializeComponent();
        }

        private void RMBtnClearLog_Click(object sender, EventArgs e)
        {
            LogPreView.Clear();
        }

        private void RMBtnSaveLog_Click(object sender, EventArgs e)
        {
            if (LogPreView.Text.Trim().Length <= 0)
            {
                MessageBox.Show("日志为空，无法存储！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "(*.txt)|*.txt";
            sfd.FileName = DateTime.Now.ToString("yyyyMMdd").ToString() + ".txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                FileHelper.WriteFile(sfd.FileName, LogPreView.Text.Trim());
                MessageBox.Show("日志存储成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void RMBtnUploadLog_Click(object sender, EventArgs e)
        {
            MessageBox.Show("本功能暂未实现！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //日志追加
        public void RTLog(string logTxt)
        {
            LogPreView.AppendText(" CJ> " + logTxt + "\r\n");
            LogPreView.Focus();
        }
    }
}
