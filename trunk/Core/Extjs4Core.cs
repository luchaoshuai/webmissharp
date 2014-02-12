using BaseLibs;
using StaticConfigure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

/* *
 * Copyright © 2013 CCT All Rights Reserved 
 * 作者：JackChain 
 * 时间：2014-01-03 17:58:06
 * 功能：
 * 版本：V1.0
 *
 * 修改人：
 * 修改点：
 * */

namespace Core
{
    public class Extjs4Core
    {

        //获取项目的Path
        public static string GetPath(string ProjectName)
        {
            return XMLHelper.Read(XMLPaths.ProjectXml, "/Root/Project[@Name='" + ProjectName + "']/Path", "");
        }
        //生成Model
        public static string CreateModelContent(DataTable dt)
        {
            //读取配置表
            DataSet ds = new DataSet();
            ds.ReadXml(XMLPaths.DBTypeXml);
            DataTable TypeDt = ds.Tables[2];

            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr in dt.Rows)
            {
                if ("id|createuser|createtime|modifyuser|modifytime|rowversion".Contains(dr["字段名"].ToString().ToLower())) continue;

                sb.AppendLine("\t\t/// <summary>");
                sb.AppendLine("\t\t/// " + dr["说明"].ToString());
                sb.AppendLine("\t\t/// </summary>");
                string CSharpType = TypeDt.Select("key='" + dr["字段类型"].ToString() + "'")[0][1].ToString();
                sb.AppendLine("\t\tpublic " + CSharpType + " " + dr["字段名"].ToString() + " { get; set; }");
                sb.AppendLine("\t\t");
            }
            return sb.ToString();
        }

        //生成到Model.csproj
        public static string WriteModelFile(string ModelContent, string TableName, string Path)
        {
            try
            {
                string ModelTemplate = FileHelper.ReadFile(".\\Templates\\EnterpriseExtJs\\Model.cs");
                ModelTemplate = ModelTemplate.Replace("{0}", TableName).Replace("{datetime}", DateTime.Now.ToString()).Replace("{1}", ModelContent);
                FileHelper.WriteFile(Path + "\\ElegantWM.EntityModel\\" + TableName + ".cs", ModelTemplate);
                string ModelCSProj = FileHelper.ReadFile(Path + "\\ElegantWM.EntityModel\\ElegantWM.EntityModel.csproj");
                if (!ModelCSProj.Contains(TableName + ".cs"))
                    FileHelper.WriteFile(Path + "\\ElegantWM.EntityModel\\ElegantWM.EntityModel.csproj", ModelCSProj.Replace("<!--MODELPOINT-->", "<Compile Include=\"" + TableName + ".cs\" />\r\n\t<!--MODELPOINT-->"));
                return "Model创建成功";
            }
            catch (Exception error)
            {
                return "ERROR：Model生成错误-" + error.Message;
            }
        }
        private static bool CheckExisit(string path, string value)
        {
            string CSProj = FileHelper.ReadFile(path);
            return CSProj.Contains(value);
        }
        //创建BLL
        public static string CreateBLL(string Path, string BllName, string TableName, string pageName)
        {
            try
            {
                //IDAL
                string IDalContent = FileHelper.ReadFile(".\\Templates\\EnterpriseExtJs\\IDAL.cs");
                IDalContent = IDalContent.Replace("{datetime}", DateTime.Now.ToString())
                                       .Replace("{0}", BllName)
                                       .Replace("{1}", TableName);
                if (!CheckExisit(Path + "\\ElegantWM.IDAL\\ElegantWM.IDAL.csproj", "I" + BllName + "DAL.cs"))
                {
                    FileHelper.WriteFile(Path + "\\ElegantWM.IDAL\\I" + BllName + "DAL.cs", IDalContent);
                    FileHelper.WriteFile(Path + "\\ElegantWM.IDAL\\ElegantWM.IDAL.csproj", FileHelper.ReadFile(Path + "\\ElegantWM.IDAL\\ElegantWM.IDAL.csproj").Replace("<!--DHELPERBLL-->", "<Compile Include=\"I" + BllName + "DAL.cs\" />\r\n\t<!--DHELPERBLL-->"));
                }
                //DAL
                string DalContent = FileHelper.ReadFile(".\\Templates\\EnterpriseExtJs\\DAL.cs");
                DalContent = DalContent.Replace("{datetime}", DateTime.Now.ToString())
                                       .Replace("{0}", BllName)
                                       .Replace("{1}", TableName);
                if (!CheckExisit(Path + "\\ElegantWM.DAL\\ElegantWM.DAL.csproj", BllName + "DAL.cs"))
                {
                    FileHelper.WriteFile(Path + "\\ElegantWM.DAL\\" + BllName + "DAL.cs", DalContent);
                    FileHelper.WriteFile(Path + "\\ElegantWM.DAL\\ElegantWM.DAL.csproj", FileHelper.ReadFile(Path + "\\ElegantWM.DAL\\ElegantWM.DAL.csproj").Replace("<!--DHELPERBLL-->", "<Compile Include=\"" + BllName + "DAL.cs\" />\r\n\t<!--DHELPERBLL-->"));
                }
                //IBLL
                string IBllContent = FileHelper.ReadFile(".\\Templates\\EnterpriseExtJs\\IService.cs");
                IBllContent = IBllContent.Replace("{datetime}", DateTime.Now.ToString())
                                       .Replace("{0}", BllName)
                                       .Replace("{1}", TableName);
                if (!CheckExisit(Path + "\\ElegantWM.IBLL\\ElegantWM.IBLL.csproj", "I" + BllName + "Service.cs"))
                {
                    FileHelper.WriteFile(Path + "\\ElegantWM.IBLL\\I" + BllName + "Service.cs", IBllContent);
                    FileHelper.WriteFile(Path + "\\ElegantWM.IBLL\\ElegantWM.IBLL.csproj", FileHelper.ReadFile(Path + "\\ElegantWM.IBLL\\ElegantWM.IBLL.csproj").Replace("<!--DHELPERBLL-->", "<Compile Include=\"I" + BllName + "Service.cs\" />\r\n\t<!--DHELPERBLL-->"));
                }
                //BLL
                string BLLContent = FileHelper.ReadFile(".\\Templates\\EnterpriseExtJs\\Service.cs");
                BLLContent = BLLContent.Replace("{datetime}", DateTime.Now.ToString())
                                       .Replace("{0}", BllName)
                                       .Replace("{1}", TableName);
                if (!CheckExisit(Path + "\\ElegantWM.BLL\\ElegantWM.BLL.csproj", BllName + "Service.cs"))
                {
                    FileHelper.WriteFile(Path + "\\ElegantWM.BLL\\" + BllName + "Service.cs", BLLContent);
                    FileHelper.WriteFile(Path + "\\ElegantWM.BLL\\ElegantWM.BLL.csproj", FileHelper.ReadFile(Path + "\\ElegantWM.BLL\\ElegantWM.BLL.csproj").Replace("<!--DHELPERBLL-->", "<Compile Include=\"" + BllName + "Service.cs\" />\r\n\t<!--DHELPERBLL-->"));
                }
                //Controller
                string ControllerContent = FileHelper.ReadFile(".\\Templates\\EnterpriseExtJs\\Controller.cs");
                ControllerContent = ControllerContent.Replace("{datetime}", DateTime.Now.ToString())
                                       .Replace("{pagename}", pageName)
                                       .Replace("{0}", BllName)
                                       .Replace("{1}", TableName);
                if (!CheckExisit(Path + "\\ElegantWM.WebUI\\ElegantWM.WebUI.csproj", "Areas\\Admin\\Controllers\\" + BllName + "Controller.cs"))
                {
                    FileHelper.WriteFile(Path + "\\ElegantWM.WebUI\\Areas\\Admin\\Controllers\\" + BllName + "Controller.cs", ControllerContent);
                    FileHelper.WriteFile(Path + "\\ElegantWM.WebUI\\ElegantWM.WebUI.csproj", FileHelper.ReadFile(Path + "\\ElegantWM.WebUI\\ElegantWM.WebUI.csproj").Replace("<!--ControllerInsertPoint-->", "<Compile Include=\"Areas\\Admin\\Controllers\\" + BllName + "Controller.cs\" />\r\n\t<!--ControllerInsertPoint-->"));
                }
                return "业务层创建成功";
            }
            catch (Exception error)
            {
                return "ERROR：Model生成错误-" + error.Message;
            }
        }

        //更新EF模型和工厂
        public static string UpdateBLLMWSFactory(string Path, string BllName, string TableName)
        {
            try
            {
                //DBSET
                string dbcontext = FileHelper.ReadFile(Path + "\\ElegantWM.DAL\\DBContext.cs");
                if (!dbcontext.Contains("DbSet<" + TableName + ">"))
                {
                    string dbset = "public DbSet<{1}> {0} { get; set; }";
                    dbset = dbset.Replace("{0}", BllName).Replace("{1}", TableName) + "\r\n\t\t/*DBSET*/";
                    FileHelper.WriteFile(Path + "\\ElegantWM.DAL\\DBContext.cs", dbcontext.Replace("/*DBSET*/", dbset));
                }
                //WMFactory
                string WMSFactory = FileHelper.ReadFile(Path + "\\ElegantWM.Factory\\WMFactory.cs");
                if (WMSFactory.Contains(BllName + "Service") || WMSFactory.Contains("I" + BllName + "Service"))
                    return "工厂已配置，本次忽略";
                string Mgr = "public static I{0}Service {0} { get { return new {0}Service(); } }";
                Mgr = Mgr.Replace("{0}", BllName).Replace("{datetime}", DateTime.Now.ToString()) + "\r\n\t\t/*WMPOINT*/";
                FileHelper.WriteFile(Path + "\\ElegantWM.Factory\\WMFactory.cs", WMSFactory.Replace("/*WMPOINT*/", Mgr));
                return "工厂配置成功";
            }
            catch (Exception error)
            {
                return "ERROR：逻辑工厂配置错误-" + error.Message;
            }
        }

        /***********创建Web层的ExtjsUI页面****************/
        public static ArrayList CreateUIElement(DataTable dt, bool isWinEdit, int cols = 2)
        {
            try
            {
                StringBuilder model = new StringBuilder();
                StringBuilder grid = new StringBuilder();
                StringBuilder edit = new StringBuilder();
                int curRow = 1;
                string columnWidth = string.Format("{0:#.##}", (1.00 / cols));
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["字段名"].ToString().ToLower() == "rowversion")
                    {

                    }
                    else if (dr["字段类型"].ToString().ToLower() == "datetime")
                        model.Append("\r\n\t\t{ name: '" + dr["字段名"].ToString() + "', convert: function (value) { return Ext.Tools.FormatDate(value, 'Y-m-d').toString(); } },");
                    else
                        model.Append("\r\n\t\t'" + dr["字段名"].ToString() + "',");

                    if (!"id,rowversion,".Contains(dr["字段名"].ToString().ToLower() + ","))
                    {
                        grid.Append("\r\n\t\t{" + "\r\n"
                                       + "\t\t\ttext: '" + dr["说明"].ToString() + "'," + "\r\n"
                                       + "\t\t\tmenuDisabled: true," + "\r\n"
                                       + "\t\t\tsortable: true," + "\r\n"
                                       + "\t\t\tdataIndex: '" + dr["字段名"].ToString() + "'" + "\r\n"
                                       + "\t\t},");
                    }
                    if (isWinEdit == false)
                        continue;
                    //生成编辑表格                    
                    if (dr[0].ToString() == "True" && !"id,createuser,createtime,modifytime,modifyuser,rowversion,".Contains(dr["字段名"].ToString().ToLower() + ","))
                    {
                        //增加每一行的开始
                        if (curRow % cols == 1)
                        {
                            edit.Append("\r\n\t\t\t{" + "\r\n"
                               + "\t\t\t\tlayout: 'column'," + "\r\n"
                               + "\t\t\t\tborder: false," + "\r\n"
                               + "\t\t\t\tdefaults: {" + "\r\n"
                               + "\t\t\t\t\tborder: false," + "\r\n"
                               + "\t\t\t\t\tlayout: 'form'" + "\r\n"
                               + "\t\t\t\t}," + "\r\n"
                               + "\t\t\t\titems: [");
                        }
                        string tempCol = "";
                        switch (dr["Form"].ToString())
                        {
                            case "TextField":
                                tempCol = "\r\n\t\t\t\t\t{" + "\r\n"
                                        + "\t\t\t\t\t\tcolumnWidth: " + columnWidth + "," + "\r\n"
                                        + "\t\t\t\t\t\titems: [" + "\r\n"
                                        + "\t\t\t\t\t\t\t{" + "\r\n"
                                        + "\t\t\t\t\t\t\t\txtype: 'textfield'," + "\r\n"
                                        + "\t\t\t\t\t\t\t\t" + (dr["允许为空"].ToString()=="√"?"//":"")+"allowBlank: false," + "\r\n"
                                        + "\t\t\t\t\t\t\t\t//vtype: 'number|alpha|alphanum|url|email|'," + "\r\n"
                                        + "\t\t\t\t\t\t\t\tname: '" + dr["字段名"].ToString() + "'," + "\r\n"
                                        + "\t\t\t\t\t\t\t\tfieldLabel: '" + dr["说明"].ToString() + "'" + "\r\n"
                                        + "\t\t\t\t\t\t\t}]" + "\r\n"
                                        + "\t\t\t\t\t},";
                                break;
                            case "DateField":
                                tempCol = "\r\n\t\t\t\t\t{" + "\r\n"
                                        + "\t\t\t\t\t\tcolumnWidth: " + columnWidth + "," + "\r\n"
                                        + "\t\t\t\t\t\titems: [" + "\r\n"
                                        + "\t\t\t\t\t\t\t{" + "\r\n"
                                        + "\t\t\t\t\t\t\t\txtype: 'datefield'," + "\r\n"
                                        + "\t\t\t\t\t\t\t\t" + (dr["允许为空"].ToString() == "√" ? "//" : "") + "allowBlank: false," + "\r\n"
                                        + "\t\t\t\t\t\t\t\tname: '" + dr["字段名"].ToString() + "'," + "\r\n"
                                        + "\t\t\t\t\t\t\t\tfieldLabel: '" + dr["说明"].ToString() + "'," + "\r\n"
                                        + "\t\t\t\t\t\t\t\tformat: 'Y-m-d'" + "\r\n"
                                        + "\t\t\t\t\t\t\t\t//符合alt格式的时间，会被强制转换为format格式" + "\r\n"
                                        + "\t\t\t\t\t\t\t\t//altFormats: 'Y-m-d|m,d,Y|m.d.Y'," + "\r\n"
                                        + "\t\t\t\t\t\t\t\t//submitFormat: 'Y-m-d'," + "\r\n"                                        
                                        + "\t\t\t\t\t\t\t}]" + "\r\n"
                                        + "\t\t\t\t\t},";
                                break;
                            case "NumberField":
                                tempCol = "\r\n\t\t\t\t\t{" + "\r\n"
                                        + "\t\t\t\t\t\tcolumnWidth: " + columnWidth + "," + "\r\n"
                                        + "\t\t\t\t\t\titems: [" + "\r\n"
                                        + "\t\t\t\t\t\t\t{" + "\r\n"
                                        + "\t\t\t\t\t\t\t\txtype: 'numberfield'," + "\r\n"
                                        + "\t\t\t\t\t\t\t\t" + (dr["允许为空"].ToString() == "√" ? "//" : "") + "allowBlank: false," + "\r\n"
                                        + "\t\t\t\t\t\t\t\tname: '" + dr["字段名"].ToString() + "'," + "\r\n"
                                        + "\t\t\t\t\t\t\t\tvtype: 'number'," + "\r\n"
                                        + "\t\t\t\t\t\t\t\tfieldLabel: '" + dr["说明"].ToString() + "'" + "\r\n"
                                        + "\t\t\t\t\t\t\t}]" + "\r\n"
                                        + "\t\t\t\t\t},";
                                break;
                            case "TextArea":
                                tempCol = "\r\n\t\t\t\t\t{" + "\r\n"
                                        + "\t\t\t\t\t\tcolumnWidth: " + columnWidth + "," + "\r\n"
                                        + "\t\t\t\t\t\titems: [" + "\r\n"
                                        + "\t\t\t\t\t\t\t{" + "\r\n"
                                        + "\t\t\t\t\t\t\t\txtype: 'textareafield'," + "\r\n"
                                        + "\t\t\t\t\t\t\t\t" + (dr["允许为空"].ToString() == "√" ? "//" : "") + "allowBlank: false," + "\r\n"
                                        + "\t\t\t\t\t\t\t\tname: '" + dr["字段名"].ToString() + "'," + "\r\n"
                                        + "\t\t\t\t\t\t\t\tbodyPadding: 10," + "\r\n"
                                        + "\t\t\t\t\t\t\t\tgrow: true," + "\r\n"
                                        + "\t\t\t\t\t\t\t\tfieldLabel: '" + dr["说明"].ToString() + "'" + "\r\n"
                                        + "\t\t\t\t\t\t\t}]" + "\r\n"
                                        + "\t\t\t\t\t},";
                                break;
                            case "ComboBox":
                                tempCol = "\r\n\t\t\t\t\t{" + "\r\n"
                                        + "\t\t\t\t\t\tcolumnWidth: " + columnWidth + "," + "\r\n"
                                        + "\t\t\t\t\t\titems: [" + "\r\n"
                                        + "\t\t\t\t\t\t\t{" + "\r\n"
                                        + "\t\t\t\t\t\t\t\txtype: 'combo'," + "\r\n"
                                        + "\t\t\t\t\t\t\t\t" + (dr["允许为空"].ToString() == "√" ? "//" : "") + "allowBlank: false," + "\r\n"
                                        + "\t\t\t\t\t\t\t\tname: '" + dr["字段名"].ToString() + "'," + "\r\n"
                                        + "\t\t\t\t\t\t\t\tfieldLabel: '" + dr["说明"].ToString() + "'," + "\r\n"
                                        + "\t\t\t\t\t\t\t\tforceSelection: true," + "\r\n"
                                        + "\t\t\t\t\t\t\t\teditable:false," + "\r\n"
                                        + "\t\t\t\t\t\t\t\tvalueField: '" + dr["字段名"].ToString() + "'," + "\r\n"
                                        + "\t\t\t\t\t\t\t\tdisplayField: '" + dr["字段名"].ToString() + "'," + "\r\n"
                                        + "\t\t\t\t\t\t\t\ttypeAhead: true," + "\r\n"
                                        + "\t\t\t\t\t\t\t\tqueryMode: 'local'," + "\r\n"
                                        + "\t\t\t\t\t\t\t\tstore: Ext.create('Ext.data.ArrayStore', {" + "\r\n"
                                        + "\t\t\t\t\t\t\t\t\tfields: ['" + dr["字段名"].ToString() + "']," + "\r\n"
                                        + "\t\t\t\t\t\t\t\t\tdata: []//[['男'], ['女']]" + "\r\n"
                                        + "\t\t\t\t\t\t\t\t})" + "\r\n"
                                        + "\t\t\t\t\t\t\t}]" + "\r\n"
                                        + "\t\t\t\t\t},";
                                break;
                        }
                        //如果一行结束，加入结束标记
                        if (curRow % cols == 0)
                        {
                            edit.Append(tempCol.TrimEnd(','));
                            edit.Append("\r\n\t\t\t\t]" + "\r\n"
                                           + "\t\t\t},");
                        }
                        else//将列加入改行
                            edit.Append(tempCol);
                        curRow++;
                    }
                }
                string tempString = edit.ToString().TrimEnd(',');
                if (isWinEdit && (curRow - 1) % cols != 0)
                {
                    tempString += "\r\n\t\t\t\t]" + "\r\n"
                                           + "\t\t\t},";
                }
                ArrayList stringList = new ArrayList();
                stringList.Add(model.ToString().TrimEnd(','));
                stringList.Add(grid.ToString().TrimEnd(','));
                stringList.Add(tempString.TrimEnd(','));
                return stringList;
            }
            catch
            {
                return null;
            }
        }

        public static string CreateExtjsApp(ArrayList stringList, string Path, string BLLName, string PageName, bool isWinEdit)
        {
            try
            {
                string templatePath = (isWinEdit ? ".\\Templates\\EnterpriseExtJs\\ExtjsUI-winEdit\\" : ".\\Templates\\EnterpriseExtJs\\ExtjsUI-rowEdit\\");
                string appPath = Path + "\\ElegantWM.WebUI\\Application\\" + BLLName;

                /*
                 * 1.创建BLLName文件夹
                 * 2.创建Controller、model、store、view文件夹
                 * 3.创建app.js
                 * 4.创建MainGrid.js,Viewport.js,...
                 * 5.创建Index.cshtml
                 * 6.更新工程文件csproj
                 * 
                 */

                //创建目录
                Directory.CreateDirectory(appPath + "\\controller");
                Directory.CreateDirectory(appPath + "\\model");
                Directory.CreateDirectory(appPath + "\\store");
                Directory.CreateDirectory(appPath + "\\view");
                Directory.CreateDirectory(Path + "\\ElegantWM.WebUI\\Areas\\Admin\\Views\\" + BLLName);
                //拷贝不需要修改的文件Viewport.js
                File.Copy(templatePath + "\\view\\Viewport.js", appPath + "\\view\\Viewport.js", true);
                //app.js
                string appjs = FileHelper.ReadFile(templatePath + "app.js");
                FileHelper.WriteFile(appPath + "\\app.js", string.Format(appjs, BLLName));
                string modeljs = FileHelper.ReadFile(templatePath + "\\model\\model.js");
                FileHelper.WriteFile(appPath + "\\model\\" + BLLName + ".js", string.Format(modeljs, BLLName, stringList[0].ToString()));
                string storejs = FileHelper.ReadFile(templatePath + "\\store\\store.js");
                FileHelper.WriteFile(appPath + "\\store\\" + BLLName + ".js", string.Format(storejs, BLLName));
                string gridjs = FileHelper.ReadFile(templatePath + "\\view\\MainGrid.js");
                FileHelper.WriteFile(appPath + "\\view\\MainGrid.js", string.Format(gridjs, BLLName, stringList[1].ToString()));
                string ctrljs = FileHelper.ReadFile(templatePath + "\\controller\\Main.js");
                FileHelper.WriteFile(appPath + "\\controller\\Main.js", string.Format(ctrljs, BLLName));
                if (isWinEdit)
                {
                    string editWinjs = FileHelper.ReadFile(templatePath + "\\view\\EditWin.js");
                    FileHelper.WriteFile(appPath + "\\view\\EditWin.js", string.Format(editWinjs, stringList[2].ToString()));
                }
                //index.cshtml
                string index = FileHelper.ReadFile(".\\Templates\\EnterpriseExtJs\\Index.cshtml");
                FileHelper.WriteFile(Path + "\\ElegantWM.WebUI\\Areas\\Admin\\Views\\" + BLLName + "\\Index.cshtml", index.Replace("{pagename}", PageName).Replace("{0}", BLLName));

                //index
                string CSProj = FileHelper.ReadFile(Path + "\\ElegantWM.WebUI\\ElegantWM.WebUI.csproj");
                if (!CSProj.Contains("Areas\\Admin\\Views\\" + BLLName + "\\Index.cshtml"))
                {
                    CSProj.Replace("<!--ViewsInsertPoint-->", "<Content Include=\"Areas\\Admin\\Views\\" + BLLName + "\\Index.cshtml\" />\r\n\t<!--ViewsInsertPoint-->");
                }
                if (!CSProj.Contains("Application\\" + BLLName + "\\view\\MainGrid.js"))
                {
                    CSProj.Replace("<!--AppjsInsertPoint-->",
                                   "<Content Include=\"Application\\" + BLLName + "\\view\\MainGrid.js\" />\r\n\t<!--AppjsInsertPoint-->"
                                   );
                }
                if (!CSProj.Contains("Application\\" + BLLName + "\\view\\Viewport.js"))
                {
                    CSProj.Replace("<!--AppjsInsertPoint-->",
                                   "<Content Include=\"Application\\" + BLLName + "\\view\\Viewport.js\" />\r\n\t<!--AppjsInsertPoint-->"
                                   );
                }
                if (!CSProj.Contains("Application\\" + BLLName + "\\model\\" + BLLName + ".js"))
                {
                    CSProj.Replace("<!--AppjsInsertPoint-->",
                                   "<Content Include=\"Application\\" + BLLName + "\\model\\" + BLLName + ".js\" />\r\n\t<!--AppjsInsertPoint-->"
                                   );
                }
                if (!CSProj.Contains("Application\\" + BLLName + "\\store\\" + BLLName + ".js"))
                {
                    CSProj.Replace("<!--AppjsInsertPoint-->",
                                   "<Content Include=\"Application\\" + BLLName + "\\store\\" + BLLName + ".js\" />\r\n\t<!--AppjsInsertPoint-->"
                                   );
                }
                if (!CSProj.Contains("Application\\" + BLLName + "\\controller\\Main.js"))
                {
                    CSProj.Replace("<!--AppjsInsertPoint-->",
                                   "<Content Include=\"Application\\" + BLLName + "\\controller\\Main.js\" />\r\n\t<!--AppjsInsertPoint-->"
                                   );
                }
                if (!CSProj.Contains("Application\\" + BLLName + "\\app.js"))
                {
                    CSProj.Replace("<!--AppjsInsertPoint-->",
                                   "<Content Include=\"Application\\" + BLLName + "\\app.js\" />\r\n\t<!--AppjsInsertPoint-->"
                                   );
                }
                if (isWinEdit && !CSProj.Contains("Application\\" + BLLName + "\\view\\EditWin.js"))
                {
                    CSProj.Replace("<!--AppjsInsertPoint-->",
                                   "<Content Include=\"Application\\" + BLLName + "\\view\\EditWin.js\" />\r\n\t<!--AppjsInsertPoint-->"
                                   );
                }
                FileHelper.WriteFile(Path + "\\ElegantWM.WebUI\\ElegantWM.WebUI.csproj", CSProj);

                return "Extjs模块界面生成成功！";
            }
            catch (Exception err)
            {
                return "ERROR：Extjs模块界面生成异常-" + err.Message;
            }
        }
        /*
         
                //Views
                string ViewContent = FileHelper.ReadFile(".\\Templates\\EnterpriseExtJs\\Index.cshtml");
                ViewContent = ViewContent.Replace("{pagename}", ModuleName)
                                       .Replace("{0}", BllName);
                if (!CheckExisit(Path + "\\ElegantWM.WebUI\\ElegantWM.WebUI.csproj", "Areas\\Admin\\Views\\" + BllName + "\\Index.cshtml"))
                {
                    Directory.CreateDirectory(Path + "\\ElegantWM.WebUI\\Areas\\Admin\\"+BllName);
                    FileHelper.WriteFile(Path + "\\ElegantWM.WebUI\\Areas\\Admin\\Views\\" + BllName + "\\Index.cshtml", ViewContent);
                    FileHelper.WriteFile(Path + "\\ElegantWM.WebUI\\ElegantWM.WebUI.csproj", FileHelper.ReadFile(Path + "\\ElegantWM.WebUI\\ElegantWM.WebUI.csproj").Replace("<!--ViewsInsertPoint-->", "<Compile Include=\"Areas\\Admin\\Views\\" + BllName + "\\Index.cshtml\" />\r\n\t<!--ViewsInsertPoint-->"));
                }
        */

        //更新webconfig的数据库连接串
        public static void UpdateDbConnectStr(string ProName)
        {
            string Path = XMLHelper.Read(XMLPaths.ProjectXml, "/Root/Project[@Name='" + ProName + "']/Path", "") + "\\ElegantWM.WebUI\\Web.config";
            string DBConStr = XMLHelper.Read(XMLPaths.ProjectXml, "/Root/Project[@Name='" + ProName + "']/DBConStr", "");
            FileHelper.WriteFile(Path, FileHelper.ReadFile(Path).Replace("{DBCONNECTSTRING}", DBConStr));
        }
    }
}
