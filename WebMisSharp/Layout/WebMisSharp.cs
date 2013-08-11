using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DockPanelUI.Docking;
using System.IO;
using System.Threading;

namespace WebMisSharp
{
    public partial class WebMisSharp : Form
    {
        private DeserializeDockContent m_deserializeDockContent;
        private Project proj = new Project();
        private Attributes att = new Attributes();
        private Console console = new Console();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Mutex isRunning;//单实例标记
        public WebMisSharp()
        {
            InitializeComponent();
            isRunning = new Mutex(false, "SINGLE_WebMisSharp_MUTEX");
            if (!isRunning.WaitOne(0, false))
            {
                isRunning.Close();
                isRunning = null;
            }
            m_deserializeDockContent = new DeserializeDockContent(GetContentFromPersistString);

            string configFile = ".\\CFG\\Layout.config";
            if (File.Exists(configFile))
                MainDockPanel.LoadFromXml(configFile, m_deserializeDockContent);

            Welcome wc = new Welcome();
            wc.Show(this.MainDockPanel);
        }

        private IDockContent GetContentFromPersistString(string persistString)
        {
            if (persistString == typeof(Project).ToString())
                return proj;
            else if (persistString == typeof(Attributes).ToString())
                return att;
            else if (persistString == typeof(Console).ToString())
                return console;
            else return null;
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }


        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        //首次加载的时候
        private void WebMisSharp_Load(object sender, EventArgs e)
        {
            log.Debug("程序启动了");
        }
        //关闭窗体时候保存配置
        private void WebMisSharp_FormClosing(object sender, FormClosingEventArgs e)
        {
            string configFile = ".\\CFG\\Layout.config";
            MainDockPanel.SaveAsXml(configFile);
        }

        //显示解决方案
        private void ToolMenuSolution_Click(object sender, EventArgs e)
        {
            proj.Show(MainDockPanel);
        }
        //显示属性
        private void ToolAttibutes_Click(object sender, EventArgs e)
        {
            att.Show(MainDockPanel);
        }

        private void ToolConsole_Click(object sender, EventArgs e)
        {
            console.Show(MainDockPanel);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalConfig cfg = new GlobalConfig();
            cfg.ShowDialog();
        }

        private void toolStripStatusLabel_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"http://www.chinacloudtech.com"); 
        }

    }
}
