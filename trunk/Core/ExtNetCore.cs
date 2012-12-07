using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseLibs;
using System.Data;
using System.IO;
using System.Collections;

namespace Core
{
    public class ExtNetCore
    {
        //生成Combox的store的模版
        static string CboStoreTemplate = "\t<ext:Store runat=\"server\" ID=\"{0}_Store\" >"+"\r\n"
                              + "\t\t<Reader>" + "\r\n"
                              + "\t\t\t<ext:JsonReader>" + "\r\n"
                              + "\t\t\t\t<Fields>" + "\r\n"
                              + "\t\t\t\t\t<ext:RecordField Name=\"{1}\" />" + "\r\n"
                              + "\t\t\t\t\t<ext:RecordField Name=\"{2}\" />" + "\r\n"
                              + "\t\t\t\t</Fields>" + "\r\n"
                              + "\t\t\t</ext:JsonReader>" + "\r\n"
                              + "\t\t</Reader>" + "\r\n"
                              + "\t</ext:Store>";
        static string AspxCboStoreBindTemplate = "\t\tprivate void BindCboData_{0}()" + "\r\n"
                               + "\t\t{" + "\r\n"
                               + "\t\t\t{0}_Store.DataSource = BLL.{BllTABLENAME}.{1};" + "\r\n"
                               + "\t\t\t{0}_Store.DataBind();" + "\r\n"
                               + "\t\t}";

        static string WebCSPROJ = "\t<Compile Include=\"Admin\\{0}\">"
                               + "\t\t<DependentUpon>{1}</DependentUpon>"
                               + "\t\t<SubType>ASPXCodeBehind</SubType>"
                               + "\t</Compile>"
                               + "\t<Compile Include=\"Admin\\{2}\">"
                               + "\t\t<DependentUpon>{1}</DependentUpon>"
                               + "\t</Compile>"
                               + "<!--CompilePOINT-->";
        //创建BLL
        public static string CreateBLL(string Path, string BllName,string ModelName)
        {
            try
            {
                string ModelCSProj = FileHelper.ReadFile(Path + "\\BLL\\BLL.csproj");
                if (!ModelCSProj.Contains("Business\\" + BllName + ".cs"))
                {
                    string BllContent = FileHelper.ReadFile(".\\Templates\\BLL.cs");
                    string Content = BllContent.Replace("{TABLENAME}", BllName).Replace("{MODELNAME}", ModelName);
                    FileHelper.WriteFile(Path + "\\BLL\\Business\\" + BllName + ".cs", Content);
                    FileHelper.WriteFile(Path + "\\BLL\\BLL.csproj", FileHelper.ReadFile(Path + "\\BLL\\BLL.csproj").Replace("<!--DHELPERBLL-->", "<Compile Include=\"Business\\" + BllName + ".cs\" />\r\n\t<!--DHELPERBLL-->"));
                }
                return "BLL单独逻辑文件创建成功";
            }
            catch (Exception error)
            {
                return "ERROR：Model生成错误-" + error.Message;
            }
        }
        
        
        //更新BLL的工厂
        public static string UpdateBLLMWSFactory(string Path, string ModelName,string ArgName,bool isRef=true)
        {
            try
            {
                string WMSFactory = FileHelper.ReadFile(Path + "\\BLL\\WMSFactory.cs");
                if (WMSFactory.Contains("WMS_Mgr<" + ModelName + ">") || WMSFactory.Contains(ArgName))
                    return "BLL逻辑工厂已配置，本次忽略";
                string Mgr = "public static WMS_Mgr<{0}> {1} { get { return new WMS_Mgr<{0}>(); } }";                
                if (isRef == false)//如果不是泛型
                {
                    Mgr = "public static {0} {1} {get { return new {0}(); } }";
                    Mgr = Mgr.Replace("{0}", ArgName).Replace("{1}", ModelName) + "\r\n\t\t/*WMSPOINT*/";
                }
                else
                    Mgr = Mgr.Replace("{0}", ModelName).Replace("{1}", ArgName) + "\r\n\t\t/*WMSPOINT*/";

                FileHelper.WriteFile(Path + "\\BLL\\WMSFactory.cs", WMSFactory.Replace("/*WMSPOINT*/", Mgr));
                return "BLL逻辑工厂配置成功";
            }
            catch (Exception error)
            {
                return "ERROR：逻辑工厂配置错误-" + error.Message;
            }
        }

        /***********创建Web层的UI页面****************/
        public static ArrayList CreateUIElement(DataTable dt, List<ComBoxStore> list, string AutoID, int cols,string BllName)
        {
            try
            {
                StringBuilder JsonReader = new StringBuilder();
                StringBuilder Columns = new StringBuilder();
                StringBuilder Filters = new StringBuilder();
                StringBuilder Cells = new StringBuilder();
                StringBuilder Designer = new StringBuilder();
                StringBuilder ModelSet = new StringBuilder();
                //为Cbox使用
                StringBuilder CboStores = new StringBuilder();
                StringBuilder CboStoresBinds = new StringBuilder();
                StringBuilder PageLoadBinds = new StringBuilder();

                //读取配置表
                DataSet ds = new DataSet();
                ds.ReadXml(XMLPaths.DBTypeXml);
                DataTable TypeDt = ds.Tables[2];
                int i = 0;
                foreach (ComBoxStore cbo in list)
                {
                    ModelSet.AppendLine("DataTable dt" + cbo.TableName + i.ToString() + " = BLL.BLL_" + cbo.TableName + "combox.{0}.Tables[0];");
                    if (cbo.Conditions == null || cbo.Conditions.Trim().Length <= 0)
                        ModelSet.Replace("{0}", "GetAllList()");
                    else
                        ModelSet.Replace("{0}", "GetList(\"" + cbo.Conditions.Trim() + "\")");
                    ModelSet.AppendLine("\t\t\tforeach (DataRow dataRow in dt" + cbo.TableName + i.ToString() + ".Rows)");
                    ModelSet.AppendLine("\t\t\t{");
                    ModelSet.AppendLine("\t\t\t\tif (dataRow[\"" + cbo.Display + "\"].ToString() == Cbo" + cbo.FieldName + ".Text)");
                    ModelSet.AppendLine("\t\t\t\t{");
                    ModelSet.AppendLine("\t\t\t\t\tCbo" + cbo.FieldName + ".Text = dataRow[\"" + cbo.Value + "\"].ToString();");
                    ModelSet.AppendLine("\t\t\t\t\tbreak;");
                    ModelSet.AppendLine("\t\t\t\t}");
                    ModelSet.AppendLine("\t\t\t}");
                }

                foreach (DataRow dr in dt.Rows)
                {
                    JsonReader.AppendLine("\t\t\t\t\t<ext:RecordField Name=\"" + dr["字段名"].ToString() + "\" />");
                    if (dr["字段名"].ToString() == AutoID)
                        Columns.AppendLine("\t\t\t\t\t\t\t\t<ext:Column Header=\"自增\" Hidden=\"true\" DataIndex=\"" + AutoID + "\" />");
                    else if(dr["id"].ToString() == "True")
                        Columns.AppendLine("\t\t\t\t\t\t\t\t<ext:Column Header=\"" + dr["说明"].ToString() + "\" Sortable=\"true\" DataIndex=\"" + dr["字段名"].ToString() + "\" />");
                    else //add by zk 如果没有被勾选，则将该列隐藏
                        Columns.AppendLine("\t\t\t\t\t\t\t\t<ext:Column Header=\"" + dr["说明"].ToString() + "\"  Hidden=\"true\"  Sortable=\"true\" DataIndex=\"" + dr["字段名"].ToString() + "\" />");
                    string CSharpType = TypeDt.Select("key='" + dr["字段类型"].ToString() + "'")[0][2].ToString();
                    //if (CSharpType == "string")
                        Filters.AppendLine("\t\t\t\t\t\t\t\t\t<ext:StringFilter DataIndex=\"" + dr["字段名"].ToString() + "\" />");

                        if (dr["id"].ToString() == "True" && dr["字段名"].ToString() != AutoID)
                        {
                            //后台Model赋值
                            if (dr["Form"].ToString() == "TextArea")
                                Cells.AppendLine("\t\t\t\t\t\t\t<ext:Cell ColSpan=\"" + cols.ToString() + "\" >");
                            else
                                Cells.AppendLine("\t\t\t\t\t\t\t<ext:Cell>");
                            Cells.AppendLine("\t\t\t\t\t\t\t\t<ext:Container Layout=\"Form\">");
                            Cells.AppendLine("\t\t\t\t\t\t\t\t\t<Items>");
                            switch (dr["Form"].ToString())
                            {
                                case "TextField":
                                    Cells.AppendLine("\t\t\t\t\t\t\t\t\t<ext:TextField ID=\"Txt" + dr["字段名"].ToString() +
                                                     "\" Width=\"160\" FieldLabel=\"" + dr["说明"].ToString() +
                                                     "\" runat=\"server\" DataIndex=\"" + dr["字段名"].ToString() + "\" />");
                                    Designer.AppendLine("\t\tprotected global::Ext.Net.TextField Txt" +
                                                        dr["字段名"].ToString() + ";");
                                    if (CSharpType == "int" || CSharpType == "decimal" || CSharpType == "long")
                                        ModelSet.AppendLine("\t\t\t_{TABLENAME}." + dr["字段名"].ToString() + " = " +
                                                            CSharpType + ".Parse(Txt" + dr["字段名"].ToString() +
                                                            ".Text); //" + dr["说明"].ToString());
                                    else
                                        ModelSet.AppendLine("\t\t\t_{TABLENAME}." + dr["字段名"].ToString() + " = Txt" +
                                                            dr["字段名"].ToString() + ".Text; //" + dr["说明"].ToString());
                                    break;
                                case "DateField":
                                    Cells.AppendLine("\t\t\t\t\t\t\t\t\t<ext:DateField ID=\"DF" + dr["字段名"].ToString() +
                                                     "\" Width=\"160\" Format=\"yyyy-MM-dd\" FieldLabel=\"" +
                                                     dr["说明"].ToString() + "\" runat=\"server\" DataIndex=\"" +
                                                     dr["字段名"].ToString() + "\" />");
                                    Designer.AppendLine("\t\tprotected global::Ext.Net.DateField DF" +
                                                        dr["字段名"].ToString() + ";");
                                    if (CSharpType == "int" || CSharpType == "decimal" || CSharpType == "long")
                                        ModelSet.AppendLine("\t\t\t_{TABLENAME}." + dr["字段名"].ToString() + " = " +
                                                            CSharpType + ".Parse(DF" + dr["字段名"].ToString() +
                                                            ".Text); //" + dr["说明"].ToString());
                                    else
                                        ModelSet.AppendLine("\t\t\t_{TABLENAME}." + dr["字段名"].ToString() +
                                                            " = DateTime.Parse(DF" + dr["字段名"].ToString() +
                                                            ".Text).ToString(\"yyyy-MM-dd\"); //" + dr["说明"].ToString());
                                    break;
                                case "NumberField":
                                    Cells.AppendLine("\t\t\t\t\t\t\t\t\t<ext:NumberField ID=\"NF" + dr["字段名"].ToString() +
                                                     "\" Width=\"160\" FieldLabel=\"" + dr["说明"].ToString() +
                                                     "\" runat=\"server\" DataIndex=\"" + dr["字段名"].ToString() + "\" />");
                                    Designer.AppendLine("\t\tprotected global::Ext.Net.NumberField NF" +
                                                        dr["字段名"].ToString() + ";");
                                    if (CSharpType == "int" || CSharpType == "decimal" || CSharpType == "long")
                                        ModelSet.AppendLine("\t\t\t_{TABLENAME}." + dr["字段名"].ToString() + " = " +
                                                            CSharpType + ".Parse(NF" + dr["字段名"].ToString() +
                                                            ".Text); //" + dr["说明"].ToString());
                                    else
                                        ModelSet.AppendLine("\t\t\t_{TABLENAME}." + dr["字段名"].ToString() +
                                                            " = int.Parse(NF" + dr["字段名"].ToString() + ".Text); //" +
                                                            dr["说明"].ToString());
                                    break;
                                case "TextArea":
                                    Cells.AppendLine("\t\t\t\t\t\t\t\t\t<ext:TextArea ID=\"TA" + dr["字段名"].ToString() +
                                                     "\" Width=\"" + (165*cols).ToString() + "\" FieldLabel=\"" +
                                                     dr["说明"].ToString() + "\" runat=\"server\" DataIndex=\"" +
                                                     dr["字段名"].ToString() + "\" />");
                                    Designer.AppendLine("\t\tprotected global::Ext.Net.TextArea TA" +
                                                        dr["字段名"].ToString() + ";");
                                    ModelSet.AppendLine("\t\t\t_{TABLENAME}." + dr["字段名"].ToString() + " = TA" +
                                                        dr["字段名"].ToString() + ".Text; //" + dr["说明"].ToString());
                                    break;
                                case "ComboBox":
                                    ComBoxStore cbo = null;
                                    if (list.Count > 0)
                                        cbo =
                                            list.First<ComBoxStore>(
                                                delegate(ComBoxStore l) { return l.FieldName == dr["字段名"].ToString(); });
                                    if (cbo == null || cbo.TableName == null || cbo.TableName.Trim().Length <= 0
                                        || cbo.Display == null || cbo.Display.Trim().Length <= 0
                                        || cbo.Value == null || cbo.Display.Trim().Length <= 0)
                                        Cells.AppendLine("\t\t\t\t\t\t\t\t\t<ext:ComboBox ID=\"Cbo" +
                                                         dr["字段名"].ToString() + "\" StoreID=\"" + dr["字段名"].ToString() +
                                                         "_Store\" Editable=\"false\"  Width=\"160\" FieldLabel=\"" +
                                                         dr["说明"].ToString() + "\" runat=\"server\" DataIndex=\"" +
                                                         dr["字段名"].ToString() + "\" />");
                                    else
                                    {
                                        Cells.AppendLine("\t\t\t\t\t\t\t\t\t<ext:ComboBox ID=\"Cbo" +
                                                         dr["字段名"].ToString() + "\" StoreID=\"" + dr["字段名"].ToString() +
                                                         "_Store\" Editable=\"false\"  Width=\"160\" FieldLabel=\"" +
                                                         dr["说明"].ToString() + "\" runat=\"server\" DisplayField=\"" +
                                                         cbo.Display.Trim() + "\" ValueField=\"" + cbo.Value.Trim() +
                                                         "\" DataIndex=\"" + dr["字段名"].ToString() + "\"  />");
                                        CboStores.AppendLine(string.Format(CboStoreTemplate, dr["字段名"].ToString(),
                                                                           cbo.Display.Trim(), cbo.Value.Trim()));
                                        CboStoresBinds.AppendLine(
                                            AspxCboStoreBindTemplate.Replace("{BllTABLENAME}", "BLL_" + cbo.TableName).
                                                Replace("{0}", dr["字段名"].ToString()).Replace("{1}",
                                                                                             ((cbo.Conditions == null ||
                                                                                               cbo.Conditions.Trim().
                                                                                                   Length <= 0)
                                                                                                  ? "GetAllList()"
                                                                                                  : "GetList(\"" +
                                                                                                    cbo.Conditions.Trim() +
                                                                                                    "\")")));
                                        PageLoadBinds.AppendLine("\t\t\t\tBindCboData_" + dr["字段名"].ToString() + "();");
                                    }
                                    Designer.AppendLine("\t\tprotected global::Ext.Net.ComboBox Cbo" +
                                                        dr["字段名"].ToString() + ";");
                                    Designer.AppendLine("\t\tprotected global::Ext.Net.Store " + dr["字段名"].ToString() +
                                                        "_Store;");


                                    if (CSharpType == "string")
                                        ModelSet.AppendLine("\t\t\t_{TABLENAME}." + dr["字段名"].ToString() + " = Cbo" +
                                                            dr["字段名"].ToString() + ".Text; //" + dr["说明"].ToString());
                                    else
                                    {
                                        ModelSet.AppendLine("\t\t\t_{TABLENAME}." + dr["字段名"].ToString() + " = " +
                                                            CSharpType + ".Parse(Cbo" + dr["字段名"].ToString() +
                                                            ".Text); //" + dr["说明"].ToString());
                                    }
                                    break;
                                case "MultiCombo":
                                    ComBoxStore mcbo = null;
                                    if (list.Count > 0)
                                        mcbo =
                                            list.First<ComBoxStore>(
                                                delegate(ComBoxStore l) { return l.FieldName == dr["字段名"].ToString(); });
                                    if (mcbo == null || mcbo.TableName == null || mcbo.TableName.Trim().Length <= 0
                                        || mcbo.Display == null || mcbo.Display.Trim().Length <= 0
                                        || mcbo.Value == null || mcbo.Display.Trim().Length <= 0)
                                        Cells.AppendLine("\t\t\t\t\t\t\t\t\t<ext:MultiCombo ID=\"MCbo" +
                                                         dr["字段名"].ToString() + "\" Editable=\"false\" StoreID=\"" +
                                                         dr["字段名"].ToString() + "_Store\" Width=\"160\" FieldLabel=\"" +
                                                         dr["说明"].ToString() + "\" runat=\"server\" DataIndex=\"" +
                                                         dr["字段名"].ToString() + "\" />");
                                    else
                                    {
                                        Cells.AppendLine("\t\t\t\t\t\t\t\t\t<ext:MultiCombo ID=\"MCbo" +
                                                         dr["字段名"].ToString() + "\" Editable=\"false\" StoreID=\"" +
                                                         dr["字段名"].ToString() + "_Store\" Width=\"160\" FieldLabel=\"" +
                                                         dr["说明"].ToString() + "\" runat=\"server\" DisplayField=\"" +
                                                         mcbo.Display.Trim() + "\" ValueField=\"" + mcbo.Value.Trim() +
                                                         "\" DataIndex=\"" + dr["字段名"].ToString() + "\"  />");
                                        CboStores.AppendLine(string.Format(CboStoreTemplate, dr["字段名"].ToString(),
                                                                           mcbo.Display.Trim(), mcbo.Value.Trim()));
                                        CboStoresBinds.AppendLine(
                                            AspxCboStoreBindTemplate.Replace("{0}", dr["字段名"].ToString()).Replace(
                                                "{1}",
                                                ((mcbo.Conditions == null || mcbo.Conditions.Trim().Length <= 0)
                                                     ? "FindAll()"
                                                     : "FindByCondition(\"" + mcbo.Conditions.Trim() + "\")")));
                                        PageLoadBinds.AppendLine("\t\t\t\tBindCboData_" + dr["字段名"].ToString() + ";");
                                    }
                                    Designer.AppendLine("\t\tprotected global::Ext.Net.MultiCombo MCbo" +
                                                        dr["字段名"].ToString() + ";");
                                    ModelSet.AppendLine("\t\t\t//_{TABLENAME}." + dr["字段名"].ToString() + " = MCbo" +
                                                        dr["字段名"].ToString() + ".Text; //" + dr["说明"].ToString());
                                    break;
                            }
                            Cells.AppendLine("\t\t\t\t\t\t\t\t\t</Items>");
                            Cells.AppendLine("\t\t\t\t\t\t\t\t</ext:Container>");
                            Cells.AppendLine("\t\t\t\t\t\t\t</ext:Cell>");
                        }
                        else
                            ModelSet.AppendLine("\t\t\t//_{TABLENAME}." + dr["字段名"].ToString() + " = ; //" + dr["说明"].ToString());
                }

                Cells.AppendLine("\t\t\t\t\t\t\t<ext:Cell>");
                Cells.AppendLine("\t\t\t\t\t\t\t\t<ext:Container Layout=\"Form\">");
                Cells.AppendLine("\t\t\t\t\t\t\t\t\t<Items>");
                Cells.AppendLine("\t\t\t\t\t\t\t\t\t<ext:Hidden ID=\"Hid\" runat=\"server\" DataIndex=\"" + AutoID + "\" />");
                Designer.AppendLine("\t\tprotected global::Ext.Net.Hidden Hid;");
                Cells.AppendLine("\t\t\t\t\t\t\t\t\t</Items>");
                Cells.AppendLine("\t\t\t\t\t\t\t\t</ext:Container>");
                Cells.AppendLine("\t\t\t\t\t\t\t</ext:Cell>");
                ArrayList stringList = new ArrayList();
                stringList.Add(JsonReader.ToString());
                stringList.Add(Columns.ToString());
                stringList.Add(Filters.ToString());
                stringList.Add(Cells.ToString());
                stringList.Add(CboStores.ToString());
                stringList.Add(Designer.ToString());
                stringList.Add(ModelSet.ToString());
                stringList.Add(CboStoresBinds.ToString());
                stringList.Add(PageLoadBinds.ToString());

                return stringList;
            }
            catch
            {
                return null;
            }
        }

        public static string CreateAspx(ArrayList list, string path, string UIPath, string ModelName,string BllName, string AutoID, int cols)
        {
            try
            {
                string PageName = UIPath.Substring(UIPath.LastIndexOf('/') + 1);
                UIPath = UIPath.Replace("/", "\\").Replace(PageName, "");
                if (!Directory.Exists(path + "\\Web\\Admin\\" + UIPath))
                    Directory.CreateDirectory(path + "\\Web\\Admin\\" + UIPath);

                //创建Aspx
                string Aspx = FileHelper.ReadFile(".\\Templates\\Template.aspx").Replace("Template", PageName);
                Aspx = Aspx.Replace("{TABLENAME}", ModelName)
                         .Replace("{RecordField}", list[0].ToString())
                         .Replace("{AutoID}", AutoID)
                         .Replace("{Columns}", list[1].ToString())
                         .Replace("{StringFilter}", list[2].ToString())
                         .Replace("{Cells}", list[3].ToString())
                         .Replace("{TableColumns}", cols.ToString())
                         .Replace("{WIDTH}", (cols * 260).ToString())
                         .Replace("<!--CBOSTORE-->", list[4].ToString());

                //创建Aspx.cs
                string AspxCS = FileHelper.ReadFile(".\\Templates\\Template.aspx.cs").Replace("Template", PageName);
                AspxCS = AspxCS.Replace("{ModelSetValue}", list[6].ToString())
                    .Replace("//{CBOBIND}", list[8].ToString())
                    .Replace("//{CBOBINDFun}", list[7].ToString().Replace("{TABLENAME}", ModelName))
                    .Replace("{AutoID}", AutoID)
                    .Replace("{TABLENAME}", ModelName)
                    .Replace("{BllTABLENAME}", BllName);
                //创建Aspx.designer
                string AspxDesigner = FileHelper.ReadFile(".\\Templates\\Template.aspx.designer.cs").Replace("Template", PageName);
                AspxDesigner = AspxDesigner.Replace("{DesignPOINT}", list[5].ToString())
                    .Replace("{TABLENAME}", ModelName);

                //存储UI文件到指定目录
                FileHelper.WriteFile(path + "\\Web\\Admin\\" + UIPath + PageName + ".aspx", Aspx);
                FileHelper.WriteFile(path + "\\Web\\Admin\\" + UIPath + PageName + ".aspx.cs", AspxCS);
                FileHelper.WriteFile(path + "\\Web\\Admin\\" + UIPath + PageName + ".aspx.designer.cs", AspxDesigner);

                //开始配置csproj
                string WebCSPROJTEMP = string.Format(WebCSPROJ, UIPath + PageName + ".aspx.cs", PageName + ".aspx", UIPath + PageName + ".aspx.designer.cs");
                string tempCSPROJ = FileHelper.ReadFile(path + "\\Web\\Web.csproj");
                if (!tempCSPROJ.Contains("Admin\\" + UIPath + PageName + ".aspx"))
                    FileHelper.WriteFile(path + "\\Web\\Web.csproj",
                                        tempCSPROJ.Replace("<!--CompilePOINT-->", WebCSPROJTEMP).Replace("<!--ContentPOINT-->", "<Content Include=\"Admin\\" + UIPath + PageName + ".aspx\" />\r\n<!--ContentPOINT-->"));
                return "WebUI生成成功...100%";
            }
            catch (Exception error)
            {
                return "ERROR：WebUI生成异常-" + error.Message;
            }
        }
        //更新webconfig的数据库连接串
        public static void UpdateDbConnectStr(string ProName)
        {
            string Path = XMLHelper.Read(XMLPaths.ProjectXml, "/Root/Project[@Name='" + ProName + "']/Path", "") + "\\Web\\Web.config";
            string DBConStr = XMLHelper.Read(XMLPaths.ProjectXml, "/Root/Project[@Name='" + ProName + "']/DBConStr", "");
            FileHelper.WriteFile(Path, FileHelper.ReadFile(Path).Replace("{DBCONNECTSTRING}", DBConStr));
        }
    }
}
