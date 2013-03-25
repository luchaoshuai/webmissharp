using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WebMisSharp.Common
{
    public partial class ErrorReport : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public ErrorReport(string Errors)
        {
            InitializeComponent();
            this.RTxtErrors.Text = Errors;
            log.Error(Errors);
        }

        //终止
        private void BtnExitApp_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        //提交错误
        private void BtnSubmitErrors_Click(object sender, EventArgs e)
        {
            MessageBox.Show("感谢您的支持，我们将尽快分析问题，提升软件质量！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
