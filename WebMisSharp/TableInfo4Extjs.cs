using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DockPanelUI.Docking;
using DBHelper;
using Core;
using System.Threading;
using System.Collections;
using StaticConfigure;

namespace WebMisSharp
{
    public partial class TableInfo4Extjs : DockContent
    {
        WebMisSharp GlobalForm = null;
        //Console log = null;
        public TableInfo4Extjs(string ModelName)
        {
            InitializeComponent();
            this.TableName = ModelName;
            GlobalForm = (WebMisSharp)Application.OpenForms["WebMisSharp"];
            BindTableStruct();
            this.TxtModelName.Text = GlobalForm.LbGlobalTable.Text;
            this.TxtBLLName.Text = GlobalForm.LbGlobalTable.Text;
            this.txtPageName.Text = GlobalForm.LbGlobalTable.Text;
        }
        //绑定表结构
        public void BindTableStruct()
        {
            this.Text = GlobalForm.LbGlobalTable.Text + "-结构";
            DataTable dt = new DataTable();
            if (ObjectProperty.ObjectList.Table.ToString() == GlobalForm.LbGlobalViewTableProc.Text)
                dt = SQLDBHelper.GetTableStructs(GlobalForm.LbGlobalProject.Text, GlobalForm.LbGlobalTable.Text);
            else
                dt = SQLDBHelper.GetViewStructs(GlobalForm.LbGlobalProject.Text, GlobalForm.LbGlobalTable.Text);

            DGridTableStruct.DataSource = dt;

        }
        //保存字段描述信息
        private void BtnSaveFieldRemark_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in DGridTableStruct.Rows)
            {
                if (r.Cells["FieldDesc"].Value.ToString().Trim().Length <= 0) continue;
                if (ObjectProperty.ObjectList.Table.ToString() == GlobalForm.LbGlobalViewTableProc.Text)
                    SQLDBHelper.SetTableFieldRemark(GlobalForm.LbGlobalProject.Text,
                                                    r.Cells["Tid"].Value.ToString().Trim(),
                                                    r.Cells["Cid"].Value.ToString().Trim(),
                                                    GlobalForm.LbGlobalTable.Text,
                                                    r.Cells["FieldName"].Value.ToString().Trim(),
                                                    r.Cells["FieldDesc"].Value.ToString().Trim());
                else
                    SQLDBHelper.SetViewFieldRemark(GlobalForm.LbGlobalProject.Text,
                                               r.Cells["Tid"].Value.ToString().Trim(),
                                               r.Cells["Cid"].Value.ToString().Trim(),
                                               GlobalForm.LbGlobalTable.Text,
                                               r.Cells["FieldName"].Value.ToString().Trim(),
                                               r.Cells["FieldDesc"].Value.ToString().Trim());
            }
            MessageBox.Show("自动描述写入完毕！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //当WEBUI checkbox 选择的时候，change事件
        private void AttShowControl(object sender, EventArgs e)
        {
            if (CBBLL.Checked)
                this.TxtBLLName.Enabled = true;
            else
                this.TxtBLLName.Enabled = false;

            if (CBModel.Checked)
                this.TxtModelName.Enabled = true;
            else
                this.TxtModelName.Enabled = false;
        }

        //当选中WebUI的时候
        private void CBWeb_CheckedChanged(object sender, EventArgs e)
        {
            if (CBWeb.Checked)
            {
                this.cbEditTypeCell.Enabled = true;
                this.cbEditTypeCell.Checked = true;
                this.cbEditTypeWin.Checked = false;
                this.cbEditTypeWin.Enabled = false;
                this.NUDColumns.Enabled = false;
                //this.txtPageName.Enabled = true;
            }
            else
            {
                this.cbEditTypeCell.Enabled = false;
                this.cbEditTypeWin.Enabled = false;
                this.NUDColumns.Enabled = false;
                //this.txtPageName.Enabled = false;
            }
        }


        private void cbEditTypeCell_CheckedChanged(object sender, EventArgs e)
        {
            //grid行编辑模式
            if (!cbEditTypeCell.Checked && CBWeb.Checked)
            {
                this.cbEditTypeWin.Checked = true;
                this.cbEditTypeWin.Enabled = true;
                this.NUDColumns.Enabled = true;
                this.cbEditTypeCell.Enabled = false;
            }
        }

        private void cbEditTypeWin_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbEditTypeWin.Checked && CBWeb.Checked)
            {
                this.cbEditTypeWin.Enabled = false;
                this.NUDColumns.Enabled = false;
                this.cbEditTypeCell.Enabled = true;
                this.cbEditTypeCell.Checked = true;
            }
        }

        //配置下拉列表的Store
        List<Core.ComBoxStore> COMStoreList = new List<Core.ComBoxStore>();
        private void BtnConfigCbo_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in DGridTableStruct.Rows)
            {
                Core.ComBoxStore store = new Core.ComBoxStore();
                if (dr.Cells["Form"].Value.ToString() == "ComboBox" || dr.Cells["Form"].Value.ToString() == "MultiCombo")
                {
                    if (COMStoreList.Where(l => l.FieldName == dr.Cells["FieldName"].Value.ToString()).Count() <= 0)
                    {
                        store.FieldName = dr.Cells["FieldName"].Value.ToString();
                        store.FieldDesc = dr.Cells["FieldDesc"].Value.ToString();
                        COMStoreList.Add(store);
                    }
                }
                else if (COMStoreList.Where(l => l.FieldName == dr.Cells["FieldName"].Value.ToString()).Count() > 0)
                    COMStoreList.Remove(COMStoreList.First<ComBoxStore>(delegate(ComBoxStore l) { return l.FieldName == dr.Cells["FieldName"].Value.ToString(); }));
            }
            ConfigComBoxStore ccbs = new ConfigComBoxStore(COMStoreList, GlobalForm.LbGlobalProject.Text);
            ccbs.ShowDialog();
        }
        //生成代码到项目中
        /****声明******/
        DataTable ColumnsDT = null;
        string Path, ModelName, TableName, BLLName, PageName;
        int Cols = 2;
        bool MC = false, WC = false, BC = false, isWinEdit = false;

        private void BtnCreateCode2Proj_Click(object sender, EventArgs e)
        {
            ColumnsDT = DGridTableStruct.DataSource as DataTable;
            //配置线程参数
            Path = Extjs4Core.GetPath(GlobalForm.LbGlobalProject.Text);
            ModelName = TxtModelName.Text.Trim();
            BLLName = TxtBLLName.Text.Trim();
            PageName = txtPageName.Text.Trim();

            MC = CBModel.Checked;
            WC = CBWeb.Checked;
            BC = CBBLL.Checked;
            isWinEdit = this.cbEditTypeWin.Checked;
            //如果是window编辑模式
            if (isWinEdit)
            {
                Cols = (int)NUDColumns.Value;
            }

            if (MC && ModelName.Length <= 0)
            {
                MessageBox.Show("实体名称不能为空！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (BC && BLLName.Length <= 0 && PageName.Length <= 0)
            {
                MessageBox.Show("BLL类名不能为空！Extjs模块名称[中文]不能为空！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (WC && PageName.Length <= 0)
            {
                MessageBox.Show("Extjs模块名称[中文]不能为空！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            //End
            Thread threadcore = new Thread(new ThreadStart(Create2Proj));//定义一个线程
            threadcore.Start();//启动一个线程
        }
        #region 生成配置线程
        private void Create2Proj()
        {
            PrintLine("开始生成...0%");
            PrintLine("获取目标路径...5%");
            PrintLine(Path);
            if (MC)
            {
                string ModelColumns = Extjs4Core.CreateModelContent(ColumnsDT);
                PrintLine("成功生成Model的get;set;...25%");
                PrintLine("生成Model文件...");
                PrintLine(Extjs4Core.WriteModelFile(ModelColumns, TableName, Path));
                PrintLine("成功创建Model文件...40%");
            }
            else
                PrintLine("跳过Model生成...");
            if (BC)
            {
                PrintLine("生成业务类文件...");
                PrintLine(Extjs4Core.CreateBLL(Path, BLLName, TableName, PageName));
                PrintLine("成功创建了业务类文件...60%");
                PrintLine("配置EF DBSet和工厂...");
                PrintLine(Extjs4Core.UpdateBLLMWSFactory(Path, BLLName, TableName));
                PrintLine("成功配置EF DBSet和工厂...62%");
            }
            else
            {
                PrintLine("跳过业务逻辑生成...");
            }
            if (WC)
            {
                PrintLine("开始生成Extjs界面...");
                ArrayList stringList = Extjs4Core.CreateUIElement(ColumnsDT, isWinEdit, Cols);
                if (stringList == null)
                {
                    PrintLine("Extjs界面元素获取失败，生成无法继续！");
                    return;
                }
                PrintLine("成功生成ExtjsUI元素...90%");
                PrintLine(Extjs4Core.CreateExtjsApp(stringList, Path, BLLName,PageName, isWinEdit));
            }
            else
                PrintLine("跳过Extjs界面生成...");
            PrintLine("恭喜您，生成成功！");
        }

        private delegate void SetPrint(string msg);//设置一个线程代理
        private void PrintLine(string msg)
        {
            if (this.InvokeRequired)//这里最关键
            {
                SetPrint setprint = new SetPrint(PrintLine);
                this.Invoke(setprint, new object[] { msg });
            }
            else
            {
                if (msg.Contains("ERROR："))
                    ConsoleHelper.SetLineColor(Color.Red);
                else
                    ConsoleHelper.SetLineColor(Color.Lime);
                ConsoleHelper.ShowConsole(msg);
                Application.DoEvents();
            }
        }
        #endregion

        private void BtnCreateCodeNeWin_Click(object sender, EventArgs e)
        {
            Cols = (int)NUDColumns.Value;
            ColumnsDT = DGridTableStruct.DataSource as DataTable;
            ArrayList stringList = Extjs4Core.CreateUIElement(ColumnsDT, true, Cols);
            YJCode uiWin = new YJCode("/**********************Model************************/"
                                    + stringList[0].ToString().TrimEnd(',')
                                    +"\r\n\r\n/*********************Grid Columns*************************/"
                                    + stringList[1].ToString().TrimEnd(',')
                                    + "\r\n\r\n/*********************Edit Window Form*************************/"
                                    + stringList[2].ToString().TrimEnd(','), "C#", "Extjs-UI-界面代码");
            uiWin.Show(GlobalForm.MainDockPanel);

            string ModelColumns = Extjs4Core.CreateModelContent(ColumnsDT);
            YJCode modelWin = new YJCode(ModelColumns, "C#", "EntityModel");
            modelWin.Show(GlobalForm.MainDockPanel);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


    }
}
