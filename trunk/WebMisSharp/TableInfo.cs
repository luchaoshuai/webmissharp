﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BaseLibs;
using DockPanelUI.Docking;
using DBHelper;
using Core;
using System.Threading;
using System.Collections;

namespace MisSharp
{
    public partial class TableInfo : DockContent
    {
        MisSharp GlobalForm = null;
        private CreatBll creatBll = new CreatBll();
        private CreatDal creatDal = new CreatDal();
        //Console log = null;
        public TableInfo(string ModelName)
        {
            InitializeComponent();
            this.TableName=ModelName;
            GlobalForm = (MisSharp)Application.OpenForms["MisSharp"];
            BindTableStruct();
            this.TxtNamespace.Text =  GlobalForm.LbGlobalDB.Text;
            this.TxtModelName.Text = "MODEL_"+ GlobalForm.LbGlobalTable.Text;
            this.TxtBLLName.Text = "BLL_" + GlobalForm.LbGlobalTable.Text;
            this.TxtDalName.Text = "DAL_" + GlobalForm.LbGlobalTable.Text;
            this.TxtAspxName.Text = GlobalForm.LbGlobalTable.Text;
        }
        DataTable dt = new DataTable();
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
            DataRow[] dr = dt.Select("标识='√'");
            if (dr.Count() > 0)
                TxtDBAutoID.Text = dr[0]["字段名"].ToString();
        }
        //保存字段描述信息
        private void BtnSaveFieldRemark_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in DGridTableStruct.Rows)
            {
                if (r.Cells["FieldDesc"].Value.ToString().Trim().Length <= 0) continue;
                if (ObjectProperty.ObjectList.Table.ToString() == GlobalForm.LbGlobalTable.Text)
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

            if (CBWeb.Checked)
            {
                this.NUDColumns.Enabled = true;
                this.TxtAspxName.Enabled = true;
            }
            else
            {
                this.NUDColumns.Enabled = false;
                this.TxtAspxName.Enabled = false;
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
        string Path, ModelName, TableName, AutoID,AutoIDType, UIPath, BLLName;
        int Cols = 2;
        bool MC = false, WC = false, BC = false;
        private void BtnCreateCode2Proj_Click(object sender, EventArgs e)
        {
            ColumnsDT = DGridTableStruct.DataSource as DataTable;
            
            //配置线程参数
            Path = Tools.GetPath(GlobalForm.LbGlobalProject.Text);
            ModelName = TxtModelName.Text.Trim();
            BLLName = TxtBLLName.Text.Trim();
            AutoID = TxtDBAutoID.Text.Trim();
            UIPath = TxtAspxName.Text.Trim();
            Cols = (int)NUDColumns.Value;
            MC = CBModel.Checked;
            WC = CBWeb.Checked;
            BC = CBBLL.Checked;
            if (AutoID.Length <= 0 || ModelName.Length <= 0)
            {
                MessageBox.Show("自增ID和Model名称不能为空！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (BC && BLLName.Length <= 0)
            {
                MessageBox.Show("BLL类名不能为空！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (WC && UIPath.Length <= 0)
            {
                MessageBox.Show("UI文件名不能为空！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
            PrintLine("获取项目路径...5%");
            PrintLine(Path);
            if (MC)
            {
                string ModelColumns = CreatModel.CreateModelContent(ColumnsDT);
                PrintLine("成功生成Model的get;set;...25%");
                PrintLine("生成Model文件...");
                PrintLine(CreatModel.WriteModelFile(ModelColumns, TableName, ModelName, AutoID, Path));
                PrintLine("成功创建Model文件...40%");
            }
            else
                PrintLine("跳过Model生成...");
            if (COMStoreList.Count > 0)
            {
                PrintLine("成功生成关联Model的get;set;...45%");
                PrintLine("生成关联Model文件...");
                
                foreach (Core.ComBoxStore comstore in COMStoreList)
                {
                    //生成combox中对应表的model
                    DataTable dt = SQLDBHelper.GetTableStructs(GlobalForm.LbGlobalProject.Text, comstore.TableName);
                    string ModelColumns = CreatModel.CreateModelContent(dt);
                    PrintLine(CreatModel.WriteModelFile(ModelColumns, "MODEL_" + comstore.TableName, "MODEL_" + comstore.TableName, AutoID,
                                                        Path));
                    //生成combox中对应表的BLL
                    creatBll.BLLName = "BLL_" + comstore.TableName + "combox";
                    creatBll.BLLNameSpace = "BLL";
                    creatBll.DataTable = dt;
                    creatBll.DALName = "DAL_" + comstore.TableName+"combox";
                    creatBll.DbType = "2005";
                    creatBll.ModelName = comstore.TableName;
                    creatBll.ModelSpace = "Model";
                    creatBll.DalNameSpace = "DAL";
                    string BllContent = creatBll.CreatBllCode();
                    creatBll.WriteBllFile(BllContent, Path);
                    //PrintLine("成功创建关联BLL文件...50%");
                    //生成combox中对应表的DAL
                    creatDal.DALName = "DAL_" + comstore.TableName + "combox";
                    creatDal.DALNameSpace = "DAL";
                    creatDal.DataTable = dt;
                    creatDal.DbHelperName = "SQLHelper";
                    creatDal.DbType = "2005";
                    creatDal.ModelSpace = "Model";
                    creatDal.TableName = comstore.TableName;
                    string fieldstrlist = creatDal.Fieldstrlist;
                    fieldstrlist = TableName + "." + fieldstrlist;
                    fieldstrlist = fieldstrlist.Replace(",", "," + TableName + ".");
                    string fromtable = "";
                    string wherestr = "";
                    int i = 0;
                    fromtable += this.TableName;
                    string selecttablename = this.TableName + " ";
                    if (wherestr.Length > 0)
                    {
                        wherestr = wherestr.Substring(5);
                        selecttablename = "(select " + fieldstrlist + " from " + fromtable + " where " + wherestr + ") a";
                    }
                    creatDal.SelectTableName = selecttablename;
                    creatDal.ModelName = ModelName;
                    string DalContent = creatDal.CreatDalCode();
                    creatDal.WriteDalFile(DalContent, Path);
                }
                PrintLine("成功创建关联Model文件...55%");
            }
            if (BC)
            {
                PrintLine("生成BLL文件...");
                creatBll.BLLName = BLLName;
                creatBll.BLLNameSpace = "BLL";
                creatBll.DataTable = ColumnsDT;
                creatBll.DALName = TxtDalName.Text;
                creatBll.DbType = "2005";
                creatBll.ModelName =ModelName;
                creatBll.ModelSpace = "Model";
                creatBll.DalNameSpace = "DAL";
                string BllContent = creatBll.CreatBllCode();
                creatBll.WriteBllFile(BllContent, Path);
                PrintLine("成功创建了BLL文件...60%");

                creatDal.DALName = TxtDalName.Text;
                creatDal.DALNameSpace = "DAL";
                creatDal.DataTable = ColumnsDT;
                creatDal.DbHelperName = "SQLHelper";
                creatDal.DbType = "2005";
                creatDal.ModelSpace = "Model";
                creatDal.TableName = this.TableName;

                string fieldstrlist = creatDal.Fieldstrlist;
                fieldstrlist = TableName + "." + fieldstrlist;
                fieldstrlist = fieldstrlist.Replace(",", "," + TableName+".");
                string fromtable = "";
                string wherestr = "";
                int i = 0;
                foreach (Core.ComBoxStore comstore in COMStoreList)
                {

                    //根据combox中配置的信息，将字段替换为显示字段，并且列名不变
                    fieldstrlist = fieldstrlist.Replace(TableName + "." + comstore.FieldName,
                                                        TableName + "." + comstore.FieldName+","+comstore.TableName + i.ToString() + "." + comstore.Display + " as " +
                                                        comstore.FieldName + "Display");
                    if (comstore.Conditions.Length > 0)
                        wherestr += " and " + comstore.TableName + i.ToString() + "." + comstore.Conditions;

                    fromtable += comstore.TableName + " as " + comstore.TableName + i.ToString() + ",";
                    wherestr += " and " + TableName + "." + comstore.FieldName + " = " + comstore.TableName + i.ToString() + "." +
                                    comstore.Value;
                    i++;
                }

                fromtable += this.TableName;

                string selecttablename = this.TableName + " ";
                if (wherestr.Length > 0)
                {
                    wherestr = wherestr.Substring(5);

                    selecttablename = "(select " + fieldstrlist + " from " + fromtable + " where " + wherestr + ") a";
                }
                creatDal.SelectTableName = selecttablename;
                creatDal.ModelName = ModelName;
                string DalContent = creatDal.CreatDalCode();
                creatDal.WriteDalFile(DalContent, Path);
            }
            else
            {
                PrintLine("跳过BLL生成...");
                PrintLine("配置BLL逻辑工厂...");
                PrintLine(ExtNetCore.UpdateBLLMWSFactory(Path, ModelName, ModelName));
                PrintLine("成功配置BLL逻辑工厂...50%");
            }
            if (WC)
            {
                PrintLine("开始生成WebUI...");
                ArrayList stringList = ExtNetCore.CreateUIElement(ColumnsDT, COMStoreList, AutoID, Cols, BLLName);
                if (stringList == null)
                {
                    PrintLine("WebUI元素获取失败，生成无法继续！");
                    return;
                }
                PrintLine("成功获取WebUI元素...90%");
                PrintLine(ExtNetCore.CreateAspx(stringList, Path, UIPath, ModelName,BLLName, AutoID, Cols));
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
            Codes ti = new Codes("abc public", "C#", "");
            ti.Show(GlobalForm.MainDockPanel);
        }

    }
}
