using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BaseLibs;

namespace Core
{
    public class CreatBll
    {
        public string ModelSpace { get; set; }
        public string ModelName { get; set; }
        private string _bllNameSpace;
        public string BLLNameSpace
        {
            get { return _bllNameSpace; }
            set { _bllNameSpace = value; }
        }
        public string BLLName { get; set; }
        public string DalNameSpace { get; set; }
        public string DALName { get; set; }
        public string DbType { get; set; }
        public DataTable DataTable { get; set; }
        private string PrimaryKey = "fid";
        private string PrimaryType = "int";
        public string CreatBllCode()
        {
            StringPlus strclass = new StringPlus();
            strclass.AppendLine("using System;");
            strclass.AppendLine("using System.Data;");
            strclass.AppendLine("using System.Collections.Generic;");
            strclass.AppendLine("using " + ModelSpace + ";");
            strclass.AppendLine("using " + DalNameSpace + ";");
            strclass.AppendLine("namespace " + BLLNameSpace);
            strclass.AppendLine("{");
            strclass.AppendSpaceLine(1, "/// <summary>");
            strclass.AppendSpaceLine(1, "/// " + BLLName);
            strclass.AppendSpaceLine(1, "/// </summary>");
            strclass.AppendSpaceLine(1, "public partial class " + BLLName);
            strclass.AppendSpaceLine(1, "{");
            //strclass.AppendSpaceLine(2, "private readonly " + DALName + " dal=" + "new " + DALName + "();");
            strclass.AppendSpaceLine(2, "public " + BLLName + "()");
            strclass.AppendSpaceLine(2, "{}");
            strclass.AppendSpaceLine(2, "#region  Method");

            #region  方法代码

            if (DataTable.Rows.Count > 0)
            {
                foreach (DataRow dr in DataTable.Rows)
                {
                    if (dr["主键"].ToString().Length > 0)
                    {
                        PrimaryKey = dr["字段名"].ToString();
                        PrimaryType = dr["字段类型"].ToString();
                        if (dr["字段类型"].ToString() == "int")
                        {
                            strclass.AppendLine(CreatBLLGetMaxID());
                            break;
                        }
                    }
                }
            }
            strclass.AppendLine(CreatBLLExists());
            strclass.AppendLine(CreatBLLADD());
            strclass.AppendLine(CreatBLLUpdate());
            strclass.AppendLine(CreatBLLDelete());
            strclass.AppendLine(CreatBLLGetModel());
            strclass.AppendLine(CreatBLLGetList());
            strclass.AppendLine(CreatBLLGetAllList());
            strclass.AppendLine(CreatBLLGetListByPage());

            #endregion

            strclass.AppendSpaceLine(2, "#endregion  Method");
            strclass.AppendSpaceLine(1, "}");
            strclass.AppendLine("}");
            strclass.AppendLine("");

            return strclass.ToString();
        }
        #region 具体方法代码
        private string CreatBLLGetMaxID()
        {
            StringPlus strclass = new StringPlus();
            strclass.AppendLine("");
            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 得到最大ID");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "public static int GetMaxId()");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "return "+DALName+".GetMaxId();");
            strclass.AppendSpaceLine(2, "}");
            return strclass.ToString();
        }
        private string CreatBLLExists()
        {
            StringPlus strclass = new StringPlus();
            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 是否存在该记录");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "public static bool Exists(" +PrimaryType+" "+ PrimaryKey + ")");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "return " + DALName + ".Exists(" + PrimaryKey + ");");
            strclass.AppendSpaceLine(2, "}");
            return strclass.ToString();
        }
        private string CreatBLLADD()
        {
            StringPlus strclass = new StringPlus();
            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 增加一条数据");
            strclass.AppendSpaceLine(2, "/// </summary>");
            string strretu = "bool";
            strclass.AppendSpaceLine(2, "public static " + strretu + " Add(" + ModelName + " model)");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "return "+DALName+".Add(model);");
            strclass.AppendSpaceLine(2, "}");
            return strclass.ToString();
        }
        private string CreatBLLUpdate()
        {
            StringPlus strclass = new StringPlus();
            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 更新一条数据");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "public static bool Update(" + ModelName + " model)");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "return "+DALName+".Update(model);");
            strclass.AppendSpaceLine(2, "}");
            return strclass.ToString();
        }
        private string CreatBLLDelete()
        {
            StringPlus strclass = new StringPlus();

            #region 标识字段优先的删除

            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 删除一条数据");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "public static bool Delete(" + PrimaryType + " " + PrimaryKey + ")");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "return "+DALName+".Delete(" + PrimaryKey + ");");
            strclass.AppendSpaceLine(2, "}");

            #endregion

            #region 批量删除

            //批量删除方法
            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 批量删除数据");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "public static bool DeleteList(string " + PrimaryKey + "list )");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "return "+DALName+".DeleteList(" + PrimaryKey + "list );");
            strclass.AppendSpaceLine(2, "}");

            #endregion

            return strclass.ToString();
        }
        private string CreatBLLGetModel()
        {
            StringPlus strclass = new StringPlus();
            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 得到一个对象实体");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "public static " + ModelName + " GetModel(" + PrimaryType + " " + PrimaryKey + ")");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "return "+DALName+".GetModel(" + PrimaryKey + ");");
            strclass.AppendSpaceLine(2, "}");

            return strclass.ToString();

        }
        private string CreatBLLGetList()
        {
            StringPlus strclass = new StringPlus();
            //返回DataSet
            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 获得数据列表");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "public static DataSet GetList(string strWhere)");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "return "+DALName+".GetList(strWhere);");
            strclass.AppendSpaceLine(2, "}");
            
            if ((DbType == "SQL2000") ||
                (DbType == "SQL2005") ||
                (DbType == "SQL2008"))
            {
                //返回DataSet
                strclass.AppendSpaceLine(2, "/// <summary>");
                strclass.AppendSpaceLine(2, "/// 获得前几行数据");
                strclass.AppendSpaceLine(2, "/// </summary>");
                strclass.AppendSpaceLine(2, "public static DataSet GetList(int Top,string strWhere,string filedOrder)");
                strclass.AppendSpaceLine(2, "{");
                strclass.AppendSpaceLine(3, "return "+DALName+".GetList(Top,strWhere,filedOrder);");
                strclass.AppendSpaceLine(2, "}");
            }

            //返回List<>
            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 获得数据列表");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "public static List<" + ModelName + "> GetModelList(string strWhere)");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "DataSet ds = "+DALName+".GetList(strWhere);");
            strclass.AppendSpaceLine(3, "return DataTableToList(ds.Tables[0]);");
            strclass.AppendSpaceLine(2, "}");

            //返回List<>
            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 获得数据列表");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "public static List<" + ModelName + "> DataTableToList(DataTable dt)");
            strclass.AppendSpaceLine(2, "{");
            //strclass.AppendSpaceLine(3, "DataSet ds = dal.GetList(strWhere);");
            strclass.AppendSpaceLine(3, "List<" + ModelName + "> modelList = new List<" + ModelName + ">();");
            strclass.AppendSpaceLine(3, "int rowsCount = dt.Rows.Count;");
            strclass.AppendSpaceLine(3, "if (rowsCount > 0)");
            strclass.AppendSpaceLine(3, "{");
            strclass.AppendSpaceLine(4, ModelName + " model;");
            strclass.AppendSpaceLine(4, "for (int n = 0; n < rowsCount; n++)");
            strclass.AppendSpaceLine(4, "{");
            strclass.AppendSpaceLine(5, "model = new " + ModelName + "();");

            #region 字段赋值
            DataSet ds = new DataSet();
            ds.ReadXml(XMLPaths.DBTypeXml);
            DataTable TypeDt = ds.Tables[2];
            foreach (DataRow  dr in DataTable.Rows)
            {
                string columnName = dr["字段名"].ToString();
                string columnType = PrimaryType = dr["字段类型"].ToString();

                strclass.AppendSpaceLine(5, "if(dt.Rows[n][\"" + columnName + "\"]!=null && dt.Rows[n][\"" + columnName + "\"].ToString()!=\"\")");
                strclass.AppendSpaceLine(5, "{");
                #region
                switch (TypeDt.Select("key='" + dr["字段类型"].ToString() + "'")[0][1].ToString())
                {
                    case "int":
                        {
                            //strclass.AppendSpaceLine(5, "if(dt.Rows[n][\"" + columnName + "\"].ToString()!=\"\")");
                            //strclass.AppendSpaceLine(5, "{");
                            strclass.AppendSpaceLine(6, "model." + columnName + "=int.Parse(dt.Rows[n][\"" + columnName + "\"].ToString());");
                            //strclass.AppendSpaceLine(5, "}");
                        }
                        break;
                    case "long":
                        {
                            //strclass.AppendSpaceLine(5, "if(dt.Rows[n][\"" + columnName + "\"].ToString()!=\"\")");
                            //strclass.AppendSpaceLine(5, "{");
                            strclass.AppendSpaceLine(6, "model." + columnName + "=long.Parse(dt.Rows[n][\"" + columnName + "\"].ToString());");
                            //strclass.AppendSpaceLine(5, "}");
                        }
                        break;
                    case "decimal":
                        {
                            //strclass.AppendSpaceLine(5, "if(dt.Rows[n][\"" + columnName + "\"].ToString()!=\"\")");
                            //strclass.AppendSpaceLine(5, "{");
                            strclass.AppendSpaceLine(6, "model." + columnName + "=decimal.Parse(dt.Rows[n][\"" + columnName + "\"].ToString());");
                            //strclass.AppendSpaceLine(5, "}");
                        }
                        break;
                    case "float":
                        {
                            //strclass.AppendSpaceLine(5, "if(dt.Rows[n][\"" + columnName + "\"].ToString()!=\"\")");
                            //strclass.AppendSpaceLine(5, "{");
                            strclass.AppendSpaceLine(6, "model." + columnName + "=float.Parse(dt.Rows[n][\"" + columnName + "\"].ToString());");
                            //strclass.AppendSpaceLine(5, "}");
                        }
                        break;
                    case "DateTime":
                        {
                            //strclass.AppendSpaceLine(5, "if(dt.Rows[n][\"" + columnName + "\"].ToString()!=\"\")");
                            //strclass.AppendSpaceLine(5, "{");
                            strclass.AppendSpaceLine(6, "model." + columnName + "=DateTime.Parse(dt.Rows[n][\"" + columnName + "\"].ToString());");
                            //strclass.AppendSpaceLine(5, "}");
                        }
                        break;
                    case "string":
                        {
                            strclass.AppendSpaceLine(5, "model." + columnName + "=dt.Rows[n][\"" + columnName + "\"].ToString();");
                        }
                        break;
                    case "bool":
                        {
                            //strclass.AppendSpaceLine(5, "if(dt.Rows[n][\"" + columnName + "\"].ToString()!=\"\")");
                            //strclass.AppendSpaceLine(5, "{");
                            strclass.AppendSpaceLine(6, "if((dt.Rows[n][\"" + columnName + "\"].ToString()==\"1\")||(dt.Rows[n][\"" + columnName + "\"].ToString().ToLower()==\"true\"))");
                            strclass.AppendSpaceLine(6, "{");
                            strclass.AppendSpaceLine(6, "model." + columnName + "=true;");
                            strclass.AppendSpaceLine(6, "}");
                            strclass.AppendSpaceLine(6, "else");
                            strclass.AppendSpaceLine(6, "{");
                            strclass.AppendSpaceLine(7, "model." + columnName + "=false;");
                            strclass.AppendSpaceLine(6, "}");
                            //strclass.AppendSpaceLine(5, "}");
                        }
                        break;
                    case "byte[]":
                        {
                            //strclass.AppendSpaceLine(5, "if(dt.Rows[n][\"" + columnName + "\"].ToString()!=\"\")");
                            //strclass.AppendSpaceLine(5, "{");
                            strclass.AppendSpaceLine(6, "model." + columnName + "=(byte[])dt.Rows[n][\"" + columnName + "\"];");
                            //strclass.AppendSpaceLine(5, "}");
                        }
                        break;
                    case "uniqueIdentifier":
                    case "Guid":
                        {
                            //strclass.AppendSpaceLine(5, "if(dt.Rows[n][\"" + columnName + "\"].ToString()!=\"\")");
                            //strclass.AppendSpaceLine(5, "{");
                            strclass.AppendSpaceLine(6, "model." + columnName + "=new Guid(dt.Rows[n][\"" + columnName + "\"].ToString());");
                            //strclass.AppendSpaceLine(5, "}");
                        }
                        break;
                    default:
                        strclass.AppendSpaceLine(5, "//model." + columnName + "=dt.Rows[n][\"" + columnName + "\"].ToString();");
                        break;
                }
                #endregion

                strclass.AppendSpaceLine(5, "}");


            }
            #endregion

            strclass.AppendSpaceLine(5, "modelList.Add(model);");
            strclass.AppendSpaceLine(4, "}");
            strclass.AppendSpaceLine(3, "}");
            strclass.AppendSpaceLine(3, "return modelList;");
            strclass.AppendSpaceLine(2, "}");



            return strclass.ToString();

        }
        private string CreatBLLGetAllList()
        {
            StringPlus strclass = new StringPlus();
            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 获得数据列表");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "public static DataSet GetAllList()");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "return GetList(\"\");");
            strclass.AppendSpaceLine(2, "}");
            return strclass.ToString();
        }
        private string CreatBLLGetListByPage()
        {
            StringPlus strclass = new StringPlus();

            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 获取记录总数");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "public static int GetRecordCount(string strWhere)");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "return "+DALName+".GetRecordCount(strWhere);");
            strclass.AppendSpaceLine(2, "}");

            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 分页获取数据列表");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "public static DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "return "+DALName+".GetListByPage( strWhere,  orderby,  startIndex,  endIndex);");
            strclass.AppendSpaceLine(2, "}");


            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 分页获取数据列表");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "//public static DataSet GetList(int PageSize,int PageIndex,string strWhere)");
            strclass.AppendSpaceLine(2, "//{");
            strclass.AppendSpaceLine(3, "//return "+DALName+".GetList(PageSize,PageIndex,strWhere);");
            strclass.AppendSpaceLine(2, "//}");
            return strclass.ToString();
        }
        #endregion

        public string WriteBllFile(string BllContent, string Path)
        {
            try
            {
                string BllCSProj = FileHelper.ReadFile(Path + "\\Bll\\Bll.csproj");
                if (!BllCSProj.Contains("Entities\\" + BLLName + ".cs"))
                {
                    FileHelper.WriteFile(Path + "\\Bll\\" + BLLName + ".cs", BllContent);
                    FileHelper.WriteFile(Path + "\\Bll\\Bll.csproj", BllCSProj.Replace("<!--MODELPOINT-->", "<Compile Include=\"Entities\\" + BLLName + ".cs\" />\r\n\t<!--MODELPOINT-->"));
                }
                return "Bll创建成功";
            }
            catch (Exception error)
            {
                return "ERROR：Bll生成错误-" + error.Message;
            }
        }
    }
}
