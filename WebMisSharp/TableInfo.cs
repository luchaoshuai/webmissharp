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

namespace WebMisSharp
{
    public partial class TableInfo : DockContent
    {
        WebMisSharp GlobalForm = null;
        Console log = null;
        public TableInfo()
        {
            InitializeComponent();
            GlobalForm = (WebMisSharp)Application.OpenForms["WebMisSharp"];
        }
        //绑定表结构
        public void BindTableStruct()
        {
            this.Text = GlobalForm.LbGlobalTable.Text + "-表结构";
            DataTable dt = SQLDBHelper.GetTableStructs(GlobalForm.LbGlobalProject.Text, GlobalForm.LbGlobalTable.Text);
            DGridTableStruct.DataSource = dt;
            DataRow[] dr = dt.Select("标识='√'");
            if (dr.Count() > 0)
                TxtDBAutoID.Text = dr[0]["字段名"].ToString();
        }

        private void BtnSaveFieldRemark_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in DGridTableStruct.Rows)
            {
                if (r.Cells["FieldDesc"].Value.ToString().Trim().Length <= 0) continue;
                SQLDBHelper.SetTableFieldRemark(GlobalForm.LbGlobalProject.Text,
                                                r.Cells["Tid"].Value.ToString().Trim(),
                                                r.Cells["Cid"].Value.ToString().Trim(),
                                                GlobalForm.LbGlobalTable.Text,
                                                r.Cells["FieldName"].Value.ToString().Trim(),
                                                r.Cells["FieldDesc"].Value.ToString().Trim());
            }
            MessageBox.Show("自动描述写入完毕！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TableInfo_Load(object sender, EventArgs e)
        {
            BindTableStruct();
            this.TxtModelName.Text = GlobalForm.LbGlobalTable.Text;
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
        string Path,ModelName,TableName,AutoID,UIPath;
        int Cols = 2;
        bool MC = false, WC = false;
        private void BtnCreateCode2Proj_Click(object sender, EventArgs e)
        {
            log = ((Console)Application.OpenForms["Console"]);
            log.Show();
            ColumnsDT = DGridTableStruct.DataSource as DataTable;
            //配置线程参数
            Path = ExtNetCore.GetPath(GlobalForm.LbGlobalProject.Text);
            ModelName = TxtModelName.Text.Trim();
            TableName = GlobalForm.LbGlobalTable.Text;
            AutoID = TxtDBAutoID.Text.Trim();
            UIPath = TxtAspxName.Text.Trim();
            Cols = (int)NUDColumns.Value;
            MC = CBModel.Checked;
            WC = CBWeb.Checked;
            //End
            Thread threadcore = new Thread(new ThreadStart(Create2Proj));//定义一个线程
            threadcore.Start();//启动一个线程
        }
        #region 生成配置线程
        private void Create2Proj() 
        {
            PrintLine("开始生成...0%");
            PrintLine("获取项目路径...5%");
            PrintLine(Path);
            if (MC)
            {
                string ModelColumns = ExtNetCore.CreateModelContent(ColumnsDT);
                PrintLine("成功生成Model的get;set;...25%");
                PrintLine("生成Model文件...");
                PrintLine(ExtNetCore.WriteModelFile(ModelColumns, TableName, ModelName, AutoID, Path));
                PrintLine("成功创建Model文件...40%");
                PrintLine("配置BLL逻辑工厂...");
                PrintLine(ExtNetCore.UpdateBLLMWSFactory(Path, ModelName));
                PrintLine("成功配置BLL逻辑工厂...50%");
            }
            else
                PrintLine("跳过Model生成...");
            if (WC)
            {
                PrintLine("开始生成WebUI...");
                ArrayList stringList = ExtNetCore.CreateUIElement(ColumnsDT, COMStoreList, AutoID, Cols);
                if (stringList == null)
                {
                    PrintLine("WebUI元素获取失败，生成无法继续！");
                    return;
                }
                PrintLine("成功获取WebUI元素...90%");
                PrintLine(ExtNetCore.CreateAspx(stringList, Path, UIPath, ModelName, AutoID, Cols));
            }
            else
                PrintLine("跳过WebUI生成...");
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
                    log.LogPreView.SelectionColor = Color.Red;
                else
                    log.LogPreView.SelectionColor = Color.Lime;
                log.RTLog(msg);
                Application.DoEvents();
            }
        }
        #endregion
    }
}
