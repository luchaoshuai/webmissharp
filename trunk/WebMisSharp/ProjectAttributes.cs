using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BaseLibs;
using StaticConfigure;
using System.IO;

namespace WebMisSharp
{
    public partial class ProjectAttributes : Form
    {
        string XMLPath = "";//Project.xml的路径
        //Console ConsoleLog;
        public ProjectAttributes()
        {
            XMLPath = XMLPaths.ProjectXml;
            //ConsoleLog = (Console)Application.OpenForms["Console"];
            InitializeComponent();
            BindDataBaseType();
            ConsoleHelper.ShowConsole("成功加载新建项目窗体！");
        }
        //根据枚举绑定数据库类型
        private void BindDataBaseType()
        {
            foreach ( string TypeName in Enum.GetNames(typeof(ProjectDBType.DataBaseType)))
                CboProjectDB.Items.Add(TypeName);
            CboProjectDB.SelectedIndex = 0;
        }
        //根据数据库类型加载默认的连接串模板
        private void CboProjectDB_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtProDBConStr.Text = XMLHelper.Read(XMLPath, "/Root/" + CboProjectDB.Text, "");
        }
        //设置项目生成路径
        private void BtnProPathPre_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            if (fb.ShowDialog() == DialogResult.OK)
                TxtProjectPath.Text = fb.SelectedPath;
        }
        //测试连接串
        private void BtnTryDBConnect_Click(object sender, EventArgs e)
        {
            if (TryConnect())
                MessageBox.Show("连接成功！数据库连接串正常！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("连接失败！请认真检查连接串！", "失败", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
        private bool TryConnect()
        {
            if (CboProjectDB.Text == ProjectDBType.DataBaseType.SQLSERVER2008.ToString())
                return TryDBConnect.TryMSSQLConnect(TxtProDBConStr.Text.Trim());
            else if (CboProjectDB.Text == ProjectDBType.DataBaseType.ORACLE.ToString())
                return TryDBConnect.TryOracleConnect(TxtProDBConStr.Text.Trim());
            return false;
        }
        //保存项目到XML中
        private void BtnSaveProject_Click(object sender, EventArgs e)
        {
            string Name=TxtProjectName.Text.Trim().ToUpper();
            if (Name.Length <= 0 || TxtProjectPath.Text.Trim().Length <= 0 || TxtProDBConStr.Text.Trim().Length <= 0)
            {
                ConsoleHelper.ShowConsole("信息不完整，无法保存！");
                MessageBox.Show("信息不完整，无法保存！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (!TryConnect())
            {
                ConsoleHelper.ShowConsole("连接失败！请认真检查连接串！");
                MessageBox.Show("连接失败！请认真检查连接串！", "失败", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (XMLHelper.Read(XMLPath, "/Root/Project[@Name='" + Name + "']", "Name") != "")
            {
                ConsoleHelper.ShowConsole("该项目名称已被使用，请更换名称！");
                MessageBox.Show("该项目名称已被使用，请更换名称！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            string Struct = "";
            if (radioSimpleThreeLayer.Checked) Struct = Structures.ProjStructs.SimpleThreeLayer.ToString();
            else if (radioEnterpriseExtjs.Checked) Struct = Structures.ProjStructs.EnterpriseExtJs.ToString();
            XMLHelper.Insert(XMLPath, "/Root", "Project", "Name", Name);
            XMLHelper.Insert(XMLPath, "/Root/Project[@Name='" + Name + "']", "DBType", "", CboProjectDB.Text);
            XMLHelper.Insert(XMLPath, "/Root/Project[@Name='" + Name + "']", "DBConStr", "", TxtProDBConStr.Text.Trim());
            XMLHelper.Insert(XMLPath, "/Root/Project[@Name='" + Name + "']", "Path", "", TxtProjectPath.Text);
            XMLHelper.Insert(XMLPath, "/Root/Project[@Name='" + Name + "']", "Structure", "", Struct);
            XMLHelper.Update(XMLPath, "/Root/" + CboProjectDB.Text, "", TxtProDBConStr.Text.Trim());
            ConsoleHelper.ShowConsole("项目保存成功 名称：" + Name + "  数据库：" + CboProjectDB.Text + "  " + TxtProDBConStr.Text.Trim() + " 路径：" + TxtProjectPath.Text);
            this.DialogResult = DialogResult.OK;
        }
        //返回
        public string ProductName
        {
            get
            {
                return TxtProjectName.Text.Trim().ToUpper();
            }
        }

        //当选择项目的时候,判断是否存在模板
        private void SelectFramework(object sender, EventArgs e)
        {
            if (radioSimpleThreeLayer.Checked)
            {
                this.lbFwInfo.Text = "入门级框架，分三个大层DAL，BLL，Web。适合快速开发网站，企业中小型软件。";
                if (!File.Exists(".\\Templates\\SimpleThreeLayer\\WebMis.zip"))
                {
                    MessageBox.Show("简单三层-项目模板不存在，请到官网下载【http://www.chinacloudtech.com】！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }

            if (this.radioEnterpriseExtjs.Checked)
            {
                this.lbFwInfo.Text = "大型企业项目，DDD模式，EF+MVC4.0，集成单点登录SSO，认证授权中心";
                if (!File.Exists(".\\Templates\\EnterpriseExtjs\\WMC2.0-Client.zip"))
                {
                    MessageBox.Show("企业应用框架-项目模板不存在，请到官网下载【http://www.chinacloudtech.com】！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
    }
}
