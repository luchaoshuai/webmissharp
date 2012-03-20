using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using StaticConfigure;
using BaseLibs;
using DBHelper;
using System.Threading;
using System.Collections;

namespace WebMisSharp
{
    public partial class Project : DockPanelUI.Docking.DockContent
    {
        Attributes Atts;
        ProjectProperty ProPro = new ProjectProperty();
        WebMisSharp GlobalForm;
        //线程参数
        string CurrentProj = "";
        TreeNode CurrentNode = null;
        TreeNode GlobalDBNodes = null;
        //END
        public Project()
        {
            InitializeComponent();
            LoadProjectFromXml();//加载已有项目
        }

        //窗体呈现的同时从xml中加载已有项目
        private void LoadProjectFromXml(string ProName = null)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(XMLPaths.ProjectXml);
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("Root").ChildNodes;
            foreach (XmlNode xn in nodeList)//遍历所有子节点
            {
                XmlElement xe = (XmlElement)xn;
                if (xe.Name != "Project") continue;
                TreeNode Node = new TreeNode();
                Node.Name = xe.Attributes["Name"].InnerText;
                Node.Text = xe.Attributes["Name"].InnerText;
                Node.ImageIndex = 6;
                Node.SelectedImageIndex = 7;
                XmlNodeList node = xe.ChildNodes;
                Node.Tag = ObjectProperty.ObjectList.Project.ToString();
                TreeNode DBnode = new TreeNode();
                DBnode.Text = "数据库";
                DBnode.ImageIndex = 0;
                DBnode.SelectedImageIndex = 0;
                DBnode.Tag = ObjectProperty.ObjectList.DataBase.ToString();
                TreeNode MenuNode = new TreeNode();
                MenuNode.Text = "功能菜单";
                MenuNode.ImageIndex = 21;
                MenuNode.SelectedImageIndex = 22;
                MenuNode.Tag = ObjectProperty.ObjectList.Menu.ToString();
                Node.Nodes.Add(DBnode);
                Node.Nodes.Add(MenuNode);
                Tree_Project.Nodes.Add(Node);
            }
        }
        //当选择项目路径的时候
        private void Tree_Project_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Console console = ((Console)Application.OpenForms["Console"]);
            try
            {
                 GetProjectDetail();
            }
            catch (Exception error) { console.RTLog("加载属性异常:" + error.Message); }
        }

        #region 工具栏按钮功能
        //新建项目，查看项目属性等
        private void ProToolBarProjectAttribute_Click(object sender, EventArgs e)
        {
            ProjectAttributes patt = new ProjectAttributes();
            if (patt.ShowDialog() == DialogResult.OK)
            {
                TreeNode Node = new TreeNode();
                Node.Name = patt.ProductName;
                Node.Text = patt.ProductName;
                Node.ImageIndex = 6;
                Node.SelectedImageIndex = 7;
                Node.Tag = ObjectProperty.ObjectList.Project.ToString();
                TreeNode DBnode = new TreeNode();
                DBnode.Text = "数据库";
                DBnode.ImageIndex = 0;
                DBnode.SelectedImageIndex = 0;
                DBnode.Tag = ObjectProperty.ObjectList.DataBase.ToString();
                Node.Nodes.Add(DBnode);
                Tree_Project.Nodes.Add(Node);
            }
        }

        //加载对象属性
        private void GetProjectDetail()
        {
            TreeNode Node = this.Tree_Project.SelectedNode;
            string NodeType = Node.Tag.ToString();
            while (Node.Tag.ToString() != ObjectProperty.ObjectList.Project.ToString())
                Node = Node.Parent;//循环找到根节点
            Atts = (Attributes)Application.OpenForms["Attributes"];
            PropertyTable ProjectBag = new PropertyTable();
            Attribute[] ReadOnly=new Attribute[] { ReadOnlyAttribute.Yes };
            PropertySpec PName = new PropertySpec("ProName", typeof(String), "项目", "项目名称", Node.Text);
            PName.Attributes = ReadOnly;
            PropertySpec PDBType = new PropertySpec("DBType", typeof(String), "项目", "项目采用的数据库类型", XMLHelper.Read(XMLPaths.ProjectXml, "/Root/Project[@Name='" + Node.Text + "']/DBType", ""));
            PDBType.Attributes = ReadOnly;
            PropertySpec PDBConStr = new PropertySpec("DBConStr", typeof(String), "项目", "项目数据库的连接串", "");
            PropertySpec PStructure = new PropertySpec("Structure", typeof(String), "项目", "项目采用架构", XMLHelper.Read(XMLPaths.ProjectXml, "/Root/Project[@Name='" + Node.Text + "']/Structure", ""));
            PDBType.Attributes = ReadOnly;
            PropertySpec PPath = new PropertySpec("Path", typeof(String), "项目", "项目本地磁盘路径", "");
            PStructure.Attributes = ReadOnly;
            ProjectBag.Properties.Add(PName);
            ProjectBag.Properties.Add(PDBType);
            ProjectBag.Properties.Add(PDBConStr);
            ProjectBag.Properties.Add(PStructure);
            ProjectBag.Properties.Add(PPath);
            ProjectBag["ProName"] = Node.Text;
            ProjectBag["DBType"] = XMLHelper.Read(XMLPaths.ProjectXml, "/Root/Project[@Name='" + Node.Text + "']/DBType", "");
            ProjectBag["DBConStr"] = XMLHelper.Read(XMLPaths.ProjectXml, "/Root/Project[@Name='" + Node.Text + "']/DBConStr", "");
            ProjectBag["Structure"] = XMLHelper.Read(XMLPaths.ProjectXml, "/Root/Project[@Name='" + Node.Text + "']/Structure", "");
            ProjectBag["Path"] = XMLHelper.Read(XMLPaths.ProjectXml, "/Root/Project[@Name='" + Node.Text + "']/Path", "");
            if (NodeType == ObjectProperty.ObjectList.DataBase.ToString() && Tree_Project.SelectedNode.GetNodeCount(true) <= 0)
            {
            }
            else if (NodeType == ObjectProperty.ObjectList.DataBase.ToString())
            {
                DataTable dtemp = DBHelper.SQLDBHelper.GetDBBasicInfo(Node.Text);
                DataTable dfile = DBHelper.SQLDBHelper.GetDBFilesInfo(Node.Text);
                DataTable dpvu = DBHelper.SQLDBHelper.GetUVPcount(Node.Text);
                PropertySpec DBOwner = new PropertySpec("0.所有者", typeof(String), "数据库", "数据库创建人", dtemp.Rows[0]["owner"].ToString());
                DBOwner.Attributes = ReadOnly;
                PropertySpec DBCreate = new PropertySpec("1.创建日期", typeof(String), "数据库", "数据库的创建日期", dtemp.Rows[0]["crdate"].ToString());
                DBCreate.Attributes = ReadOnly;
                PropertySpec DBcmpt = new PropertySpec("2.兼容性", typeof(String), "数据库", "数据库兼容性", dtemp.Rows[0]["cmptlevel"].ToString());
                DBcmpt.Attributes = ReadOnly;
                PropertySpec DBMainFile = new PropertySpec("3.主文件", typeof(String), "数据库", "数据库文件路径", dtemp.Rows[0]["filename"].ToString());
                DBMainFile.Attributes = ReadOnly;
                PropertySpec DBlogFile = new PropertySpec("4.日志文件", typeof(String), "数据库", "数据库日志文件路径", dfile.Rows[1]["physical_name"].ToString());
                DBlogFile.Attributes = ReadOnly;
                PropertySpec DBMainSize = new PropertySpec("5.主文件大小", typeof(String), "数据库", "数据库主文件大小", ((int)dfile.Rows[0]["size"] * 8 / 1024).ToString() + "MB");
                DBMainSize.Attributes = ReadOnly;
                PropertySpec DBlogSize = new PropertySpec("6.日志大小", typeof(String), "数据库", "数据库日志文件大小", ((int)dfile.Rows[1]["size"] * 8 / 1024).ToString() + "MB");
                DBlogSize.Attributes = ReadOnly;
                /********************/
                for (int i = 0; i < dpvu.Rows.Count; i++)
                {
                    PropertySpec P =null;
                    string temp = (i + 7).ToString();
                    if (dpvu.Rows[i][0].ToString().Trim() == "P")
                    {
                        temp += ".存储过程数量";
                        P = new PropertySpec(temp, typeof(String), "数据库", "数据库中存储过程数量", dpvu.Rows[i][1].ToString());
                    }
                    else if (dpvu.Rows[i][0].ToString().Trim() == "U")
                    {
                        temp += ".表数量";
                        P = new PropertySpec(temp, typeof(String), "数据库", "数据库中用户表数量", dpvu.Rows[i][1].ToString());
                    }
                    else
                    {
                        temp += ".视图数量";
                        P = new PropertySpec(temp, typeof(String), "数据库", "数据库中用户视图数量", dpvu.Rows[i][1].ToString());
                    }
                    P.Attributes = ReadOnly;
                    ProjectBag.Properties.Add(P);
                    ProjectBag[temp] = dpvu.Rows[i][1].ToString();
                }
                
                /********************/
                ProjectBag.Properties.Add(DBOwner);
                ProjectBag.Properties.Add(DBCreate);
                ProjectBag.Properties.Add(DBcmpt);
                ProjectBag.Properties.Add(DBMainFile);
                ProjectBag.Properties.Add(DBlogFile);
                ProjectBag.Properties.Add(DBMainSize);
                ProjectBag.Properties.Add(DBlogSize);
                ProjectBag["0.所有者"] = dtemp.Rows[0]["owner"].ToString();
                ProjectBag["1.创建日期"] = dtemp.Rows[0]["crdate"].ToString();
                ProjectBag["2.兼容性"] = dtemp.Rows[0]["cmptlevel"].ToString();
                ProjectBag["3.主文件"] = dtemp.Rows[0]["filename"].ToString();
                ProjectBag["4.日志文件"] = dfile.Rows[1]["physical_name"].ToString();
                ProjectBag["5.主文件大小"] = ((int)dfile.Rows[0]["size"] * 8 / 1024).ToString() + "MB";
                ProjectBag["6.日志大小"] = ((int)dfile.Rows[1]["size"] * 8 / 1024).ToString() + "MB";
                
            }
            else if (NodeType == ObjectProperty.ObjectList.Table.ToString())
            {
                string CurrentTable = Tree_Project.SelectedNode.Text;
                MainGlobalProjectInfo(Node.Text, Tree_Project.SelectedNode.Parent.Parent.Text.Replace("数据库[", "").Replace("]", ""), CurrentTable);
                DataTable dtemp = DBHelper.SQLDBHelper.GetTableBasic(Node.Text,CurrentTable);
                DataTable dfile = DBHelper.SQLDBHelper.GetTableSize(Node.Text, CurrentTable);
                PropertySpec TName = new PropertySpec("0.表名", typeof(String), "表", "表名称", dtemp.Rows[0]["name"].ToString());
                TName.Attributes = ReadOnly;
                PropertySpec TOwner = new PropertySpec("1.所有者", typeof(String), "表", "表创建人", dtemp.Rows[0]["owner"].ToString());
                TOwner.Attributes = ReadOnly;
                PropertySpec TCreate = new PropertySpec("2.创建日期", typeof(String), "表", "表创建日期", dtemp.Rows[0]["create_date"].ToString());
                TCreate.Attributes = ReadOnly;
                PropertySpec TRows = new PropertySpec("3.行数", typeof(String), "表", "表中数据记录行数", dfile.Rows[0]["rows"].ToString());
                TRows.Attributes = ReadOnly;
                PropertySpec TCanSize = new PropertySpec("4.被分配空间", typeof(String), "表", "为表保留的空间总量",dfile.Rows[0]["reserved"].ToString());
                TCanSize.Attributes = ReadOnly;
                PropertySpec TSize = new PropertySpec("5.已用空间", typeof(String), "表", "表的数据所使用的空间总量", dfile.Rows[0]["data"].ToString());
                TSize.Attributes = ReadOnly;
                PropertySpec Tunused = new PropertySpec("6.剩余空间", typeof(String), "表", "保留但尚未使用的空间总量", dfile.Rows[0]["unused"].ToString());
                Tunused.Attributes = ReadOnly;
                ProjectBag.Properties.Add(TName);
                ProjectBag.Properties.Add(TOwner);
                ProjectBag.Properties.Add(TCreate);
                ProjectBag.Properties.Add(TRows);
                ProjectBag.Properties.Add(TCanSize);
                ProjectBag.Properties.Add(TSize);
                ProjectBag.Properties.Add(Tunused);
                ProjectBag["0.表名"] = dtemp.Rows[0]["name"].ToString();
                ProjectBag["1.所有者"] = dtemp.Rows[0]["owner"].ToString();
                ProjectBag["2.创建日期"] = dtemp.Rows[0]["create_date"].ToString();
                ProjectBag["3.行数"] = dfile.Rows[0]["rows"].ToString();
                ProjectBag["4.被分配空间"] = dfile.Rows[0]["reserved"].ToString();
                ProjectBag["5.已用空间"] = dfile.Rows[0]["data"].ToString();
                ProjectBag["6.剩余空间"] = dfile.Rows[0]["unused"].ToString();
            }
            Atts.PropertyGrid.SelectedObject = ProjectBag;
            Atts.CboCurrentObject.Items.Clear();
            Atts.CboCurrentObject.Items.Add(NodeType);
            Atts.CboCurrentObject.SelectedIndex = 0;
        }
        //主窗体设置项目名称，数据库，表名称
        private void MainGlobalProjectInfo(string ProjName,string DBName,String TableName)
        {
            GlobalForm.LbGlobalProject.Text = ProjName;
            GlobalForm.LbGlobalDB.Text = DBName;
            GlobalForm.LbGlobalTable.Text = TableName;
            //if (((TableInfo)Application.OpenForms["TableInfo"]) != null)
            //    ((TableInfo)Application.OpenForms["TableInfo"]).BindTableStruct();
        }
        //移除项目
        private void ProToolBarRemove_Click(object sender, EventArgs e)
        {
            RemoveSelectedProject();
        }
        //移除项目
        private void RemoveSelectedProject()
        {
            Console console = ((Console)Application.OpenForms["Console"]);
            try
            {
                TreeNode Node = this.Tree_Project.SelectedNode;
                while (Node.Tag.ToString() != ObjectProperty.ObjectList.Project.ToString())
                    Node = Node.Parent;//循环找到根节点
                if (MessageBox.Show("您确定要删除项目“" + Node.Text + "”吗？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    XMLHelper.Delete(XMLPaths.ProjectXml, "/Root/Project[@Name='" + Node.Text + "']", "");
                    Tree_Project.Nodes.Remove(Node);
                    console.RTLog("您删除了项目：" + Node.Text);
                }
            }
            catch (Exception error)
            {
                console.RTLog("删除项目异常:" + error.Message);
                MessageBox.Show("请先选择要移除的项目！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region 配置右键菜单
        //单击右键的时候根据节点选择需要加载的菜单
        private void Tree_Project_MouseUp(object sender, MouseEventArgs e)
        {
            RightMenuProTree.Hide();
            Console console = ((Console)Application.OpenForms["Console"]);
            try
            {
                Point mpt = new Point(e.X, e.Y);
                TreeNode CurrentNode = this.Tree_Project.GetNodeAt(mpt);
                this.Tree_Project.SelectedNode = CurrentNode;
                if (CurrentNode != null)
                {
                    CreatTreeRightMenu(CurrentNode.Tag.ToString());
                    if (e.Button == MouseButtons.Right && RightMenuProTree.Items.Count > 0)
                        this.RightMenuProTree.Show(this.Tree_Project, mpt);
                }
                else
                {
                    RightMenuProTree.Items.Clear();
                }
            }
            catch (Exception error)
            {
                console.RTLog("加载右键异常:" + error.Message);
            }
        }

        private void CreatTreeRightMenu(string NodeType)
        {
            this.RightMenuProTree.Items.Clear();
            RightMenuProTree.ImageList = ImgList;
            if (NodeType == ObjectProperty.ObjectList.Project.ToString())//当在项目上右键的时候
            {
                ToolStripMenuItem RM_ProAtt = new ToolStripMenuItem();
                RM_ProAtt.Name = "RM_ProAtt";
                RM_ProAtt.Text = "项目属性";
                RM_ProAtt.ImageIndex = 8;
                RM_ProAtt.Click += new EventHandler(RM_ProAtt_Click);

                ToolStripMenuItem RM_DelPro = new ToolStripMenuItem();
                RM_DelPro.Name = "RM_DelPro";
                RM_DelPro.Text = "删除项目";
                RM_DelPro.ImageIndex = 9;
                RM_DelPro.Click += new EventHandler(RM_DelPro_Click);

                RightMenuProTree.Items.AddRange(
                            new System.Windows.Forms.ToolStripItem[] { 
                                RM_ProAtt,RM_DelPro                            
                            });
            }
            else if (NodeType == ObjectProperty.ObjectList.Menu.ToString())
            {
                ToolStripMenuItem RM_MenuView = new ToolStripMenuItem();
                RM_MenuView.Name = "RM_MenuView";
                RM_MenuView.Text = "打开";
                RM_MenuView.ImageIndex = 21;
                RM_MenuView.Click += new EventHandler(RM_MenuView_Click);
                RightMenuProTree.Items.AddRange(
                             new System.Windows.Forms.ToolStripItem[] { 
                                RM_MenuView                           
                            });
            }
            else if (NodeType == ObjectProperty.ObjectList.DataBase.ToString())
            {//当右键数据库的时候
                ToolStripMenuItem RM_DBLoad = new ToolStripMenuItem();
                RM_DBLoad.Name = "RM_DBLoad";
                RM_DBLoad.Text = "加载/刷新";
                RM_DBLoad.ImageIndex = 10;
                RM_DBLoad.Click += new EventHandler(RM_DBLoad_Click);

                ToolStripMenuItem RM_DBQuery = new ToolStripMenuItem();
                RM_DBQuery.Name = "RM_DBQuery";
                RM_DBQuery.Text = "新建查询";
                RM_DBQuery.ImageIndex = 17;
                RM_DBQuery.Click += new EventHandler(RM_DBQuery_Click);

                ToolStripSeparator S1 = new ToolStripSeparator();
                S1.Name = "S1";

                ToolStripMenuItem RM_DBCode = new ToolStripMenuItem();
                RM_DBCode.Name = "RM_DBCode";
                RM_DBCode.Text = "批量代码生成";
                RM_DBCode.ImageIndex = 14;
                RM_DBCode.Click += new EventHandler(RM_DBCode_Click);

                ToolStripSeparator S2 = new ToolStripSeparator();
                S2.Name = "S2";

                ToolStripMenuItem RM_DBCreateSQL = new ToolStripMenuItem();
                RM_DBCreateSQL.Name = "RM_DBCreateSQL";
                RM_DBCreateSQL.Text = "生成数据库脚本";
                RM_DBCreateSQL.ImageIndex = 20;
                RM_DBCreateSQL.Click += new EventHandler(RM_DBCreateSQL_Click);

                ToolStripMenuItem RM_DBDOC = new ToolStripMenuItem();
                RM_DBDOC.Name = "RM_DBDOC";
                RM_DBDOC.Text = "生成数据库文档";
                RM_DBDOC.ImageIndex = 15;
                RM_DBDOC.Click += new EventHandler(RM_DBDOC_Click);

                ToolStripSeparator S3 = new ToolStripSeparator();
                S2.Name = "S3";

                ToolStripMenuItem RM_DBAtt = new ToolStripMenuItem();
                RM_DBAtt.Name = "RM_DBAtt";
                RM_DBAtt.Text = "属性";
                RM_DBAtt.ImageIndex = 8;
                RM_DBAtt.Click += new EventHandler(RM_DBAtt_Click);
                //表、存储过程、视图数量；数据库创建时间，日志大小，数据库大小，作者等。

                RightMenuProTree.Items.AddRange(
                            new System.Windows.Forms.ToolStripItem[] { 
                                RM_DBLoad,RM_DBQuery,S1,RM_DBCode,S2,
                                RM_DBCreateSQL,RM_DBDOC,S3,RM_DBAtt
                            });
            }
            else if (NodeType == ObjectProperty.ObjectList.TableRoot.ToString())
            {
                ToolStripMenuItem RM_DBFCCode = new ToolStripMenuItem();
                RM_DBFCCode.Name = "RM_DBFCCode";
                RM_DBFCCode.Text = "父子表代码生成";
                RM_DBFCCode.ImageIndex = 18;
                RM_DBFCCode.Click += new EventHandler(RM_DBFCCode_Click);

                ToolStripMenuItem RM_DBData = new ToolStripMenuItem();
                RM_DBData.Name = "RM_DBData";
                RM_DBData.Text = "批量导出数据";
                RM_DBData.ImageIndex = 19;
                RM_DBData.Click += new EventHandler(RM_DBData_Click);

                RightMenuProTree.Items.AddRange(
                            new System.Windows.Forms.ToolStripItem[] { 
                                RM_DBFCCode,RM_DBData
                            });
            }
            else if (NodeType == ObjectProperty.ObjectList.Table.ToString())
            {

                ToolStripMenuItem RM_TabStruct = new ToolStripMenuItem();
                RM_TabStruct.Name = "RM_TabStruct";
                RM_TabStruct.Text = "查看表结构";
                RM_TabStruct.ImageIndex = 19;
                RM_TabStruct.Click += new EventHandler(RM_TabDEV_Click);

                ToolStripMenuItem RM_TabDataView = new ToolStripMenuItem();
                RM_TabDataView.Name = "RM_TabDataView";
                RM_TabDataView.Text = "查看表数据";
                RM_TabDataView.ImageIndex = 21;
                RM_TabDataView.Click += new EventHandler(RM_TabDataView_Click);

                ToolStripMenuItem RM_TabSQL = new ToolStripMenuItem();
                RM_TabSQL.Name = "RM_TabSQL";
                RM_TabSQL.Text = "生成脚本";
                RM_TabSQL.ImageIndex = 11;

                #region 生成SQL语句到
                ToolStripMenuItem RM_Select = new ToolStripMenuItem();
                RM_Select.Name = "SELECT";
                RM_Select.Text = "SELECT";
                RM_Select.Click += new System.EventHandler(RM_Select_Click);
                ToolStripMenuItem RM_Update = new ToolStripMenuItem();
                RM_Update.Name = "UPDATE";
                RM_Update.Text = "UPDATE";
                RM_Update.Click += new System.EventHandler(RM_Update_Click);
                ToolStripMenuItem RM_Delete = new ToolStripMenuItem();
                RM_Delete.Name = "DELETE";
                RM_Delete.Text = "DELETE";
                RM_Delete.Click += new System.EventHandler(RM_Delete_Click);
                ToolStripMenuItem RM_Insert = new ToolStripMenuItem();
                RM_Insert.Name = "INSERT";
                RM_Insert.Text = "INSERT";
                RM_Insert.Click += new System.EventHandler(RM_Insert_Click);
                ToolStripMenuItem RM_Create = new ToolStripMenuItem();
                RM_Create.Name = "Create";
                RM_Create.Text = "Create";
                RM_Create.Click += new System.EventHandler(RM_Create_Click);
                RM_TabSQL.DropDownItems.AddRange(
                    new System.Windows.Forms.ToolStripItem[] { 
                                RM_Select,RM_Update,RM_Delete,RM_Create
                            }
                    );
                #endregion

                ToolStripMenuItem RM_TabCode = new ToolStripMenuItem();
                RM_TabCode.Name = "RM_DBFCCode";
                RM_TabCode.Text = "单表代码生成";
                RM_TabCode.ImageIndex = 3;
                RM_TabCode.Click += new EventHandler(RM_TabDEV_Click);

                ToolStripMenuItem RM_DBCode = new ToolStripMenuItem();
                RM_DBCode.Name = "RM_DBCode";
                RM_DBCode.Text = "批量代码生成";
                RM_DBCode.ImageIndex = 14;
                RM_DBCode.Click += new EventHandler(RM_DBCode_Click);

                ToolStripMenuItem RM_DBFCCode = new ToolStripMenuItem();
                RM_DBFCCode.Name = "RM_DBFCCode";
                RM_DBFCCode.Text = "父子表代码生成";
                RM_DBFCCode.ImageIndex = 18;
                RM_DBFCCode.Click += new EventHandler(RM_DBFCCode_Click);

                RightMenuProTree.Items.AddRange(
                           new System.Windows.Forms.ToolStripItem[] { 
                                RM_TabStruct,RM_TabDataView,RM_TabSQL,RM_TabCode,
                                RM_DBCode,RM_DBFCCode
                            });
            }
        }
        #endregion

        #region 项目右键功能
        //项目属性
        private void RM_ProAtt_Click(object sender, EventArgs e)
        {
            GetProjectDetail();
            ((Attributes)Application.OpenForms["Attributes"]).Show();
        }
        //删除项目
        private void RM_DelPro_Click(object sender, EventArgs e)
        {
            RemoveSelectedProject();
        }
        //显示项目属性
        private void ProToolBarAtt_Click(object sender, EventArgs e)
        {
            GetProjectDetail();
            ((Attributes)Application.OpenForms["Attributes"]).Show();
        }
        //打开功能菜单
        private void RM_MenuView_Click(object sender, EventArgs e)
        {
        }
        #endregion

        #region 数据库右键功能
        //刷新

        private void RM_DBLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentNode != null)
                {
                    MessageBox.Show("其他线程正在加载数据库信息，请稍后再操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                GlobalDBNodes = new TreeNode();
                GlobalForm = (WebMisSharp)Application.OpenForms["WebMisSharp"];
                GlobalForm.GlobalPBar.Visible = true;
                TreeNode Node = CurrentNode = this.Tree_Project.SelectedNode;
                while (Node.Tag.ToString() != ObjectProperty.ObjectList.Project.ToString())
                    Node = Node.Parent;//循环找到根节点
                CurrentProj = Node.Text;//获取选中的项目
                this.Tree_Project.SelectedNode.Text = "数据库[" + SQLDBHelper.GetDBName(CurrentProj) + "]";
                backgroundWorkDBLoad.RunWorkerAsync();
            }
            catch
            {
                CurrentProj = "";
                CurrentNode = null;
                GlobalDBNodes = null;
                MessageBox.Show("数据库加载失败，请验证数据库服务是否开启，连接串是否正确！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        //新建查询
        private void RM_DBQuery_Click(object sender, EventArgs e)
        {
        }
        //批量代码
        private void RM_DBCode_Click(object sender, EventArgs e)
        {
        }
        //父子表代码
        private void RM_DBFCCode_Click(object sender, EventArgs e)
        {
        }
        //生成数据脚本
        private void RM_DBCreateSQL_Click(object sender, EventArgs e)
        {
        }
        //生成数据库文档
        private void RM_DBDOC_Click(object sender, EventArgs e)
        {
        }
        //数据库属性
        private void RM_DBAtt_Click(object sender, EventArgs e)
        {
        }
        #endregion

        #region 表右键功能
        //导出表数据
        private void RM_DBData_Click(object sender, EventArgs e)
        {
        }
        //表代码生成
        private void RM_TabDEV_Click(object sender, EventArgs e)
        {
            //if (((TableInfo)Application.OpenForms["TableInfo"]) == null)
            //{
                TableInfo ti = new TableInfo();
                ti.Show(GlobalForm.MainDockPanel);
            //}
            //else
            //{
            //    ((TableInfo)Application.OpenForms["TableInfo"]).BindTableStruct();
            //}
        }
        //表数据查看
        private void RM_TabDataView_Click(object sender, EventArgs e)
        {

        }
        //生成SQL
        private void RM_Select_Click(object sender, EventArgs e)
        {

        }
        private void RM_Update_Click(object sender, EventArgs e)
        {

        }
        private void RM_Insert_Click(object sender, EventArgs e)
        {

        }
        private void RM_Delete_Click(object sender, EventArgs e)
        {

        }
        private void RM_Create_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 线程
        public void ReflashDB(object sender, DoWorkEventArgs e)
        {
            DataTable UTab = SQLDBHelper.GetTableViewProc(CurrentProj);
            GlobalForm.GlobalLbinfo.Text = "准备加载...";
            TreeNode NTab = new TreeNode();//表
            NTab.Text = "表";
            NTab.Tag = ObjectProperty.ObjectList.TableRoot.ToString();
            NTab.ImageIndex = 1; NTab.SelectedImageIndex = 2;
            TreeNode NView = new TreeNode();//视图
            NView.Text = "视图";
            NView.Tag = ObjectProperty.ObjectList.ViewRoot.ToString();
            NView.ImageIndex = 1; NView.SelectedImageIndex = 2;
            TreeNode NProc = new TreeNode();//存储过程
            NProc.Text = "存储过程";
            NProc.Tag = ObjectProperty.ObjectList.ProcRoot.ToString();
            NProc.ImageIndex = 1; NProc.SelectedImageIndex = 2;
            GlobalForm.GlobalLbinfo.Text = "根节点加载成功...";
            int i = 1;
            foreach (DataRow dr in UTab.Rows)
            {
                TreeNode TempNode = new TreeNode();
                TempNode.Text = dr[0].ToString();
                TempNode.Name = dr[0].ToString();
                GlobalForm.GlobalLbinfo.Text = "加载" + TempNode.Name + "...";
                backgroundWorkDBLoad.ReportProgress((100 * i) / UTab.Rows.Count);
                switch (dr[1].ToString().Trim())
                {
                    case "U":
                        TempNode.Tag = ObjectProperty.ObjectList.Table.ToString();
                        TempNode.ImageIndex = 3; TempNode.SelectedImageIndex = 3;
                        NTab.Nodes.Add(TempNode);
                        break;
                    case "V":
                        TempNode.Tag = ObjectProperty.ObjectList.View.ToString();
                        TempNode.ImageIndex = 4; TempNode.SelectedImageIndex = 4;
                        NView.Nodes.Add(TempNode);
                        break;
                    case "P":
                        TempNode.Tag = ObjectProperty.ObjectList.Proc.ToString();
                        TempNode.ImageIndex = 5; TempNode.SelectedImageIndex = 5;
                        NProc.Nodes.Add(TempNode);
                        break;
                }
                i++;
            }
            GlobalDBNodes.Nodes.Add(NTab);
            GlobalDBNodes.Nodes.Add(NView);
            GlobalDBNodes.Nodes.Add(NProc);
        }
        //进度条
        private void backgroundWorkDBLoad_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            GlobalForm.GlobalPBar.Value = e.ProgressPercentage;
            //((Console)Application.OpenForms["Console"]).RTLog("进度"+e.ProgressPercentage.ToString()+"%");
        }
        private void backgroundWorkDBLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CurrentNode.Nodes.Clear();//清除
            CurrentNode.Nodes.Add(GlobalDBNodes.Nodes[0]);
            CurrentNode.Nodes.Add(GlobalDBNodes.Nodes[1]);
            CurrentNode.Nodes.Add(GlobalDBNodes.Nodes[2]);
            CurrentNode.Expand();
            GlobalForm = (WebMisSharp)Application.OpenForms["WebMisSharp"];
            GlobalForm.GlobalLbinfo.Text = "就绪";
            GlobalForm.GlobalPBar.Visible = false;
            GlobalForm.GlobalPBar.Value = 0;
            ((Console)Application.OpenForms["Console"]).Show();
            ((Console)Application.OpenForms["Console"]).RTLog(CurrentProj + "数据库加载成功，找到表：" + CurrentNode.Nodes[0].GetNodeCount(true).ToString() +
                                                              "     视图：" + CurrentNode.Nodes[1].GetNodeCount(true) +
                                                              "     存储过程：" + CurrentNode.Nodes[2].GetNodeCount(true));
            CurrentNode = null;
        }
        #endregion


    }
}
