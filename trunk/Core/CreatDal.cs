using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BaseLibs;

namespace Core
{
    public class CreatDal
    {
        #region 私有变量

        /// <summary>
        /// 标识列，或主键字段	
        /// </summary>
        protected string PrimaryKey = "";

        /// <summary>
        /// 标识列，或主键字段类型 
        /// </summary>
        protected string PrimaryType = "int";

        #endregion

        #region 公有属性
        private string _tablename;
        private string _dalname; //dal类名 
        private string _dbhelperName; //数据库访问类名
        private string _dalnamespace;

        public string DbType { get; set; }
        public DataTable DataTable { get; set; }

        public string TableName
        {
            set { _tablename = value; }
            get { return _tablename; }
        }

        public string SelectTableName { get; set; }
        
        /// <summary>
        /// 实体类的整个命名空间 + 类名
        /// </summary>
        /// <summary>
        /// 实体类的整个命名空间 + 类名，即等于 Modelpath+ModelName
        /// </summary>
        public string ModelSpace { get; set; }
        
        /// <summary>
        /// 数据层的命名空间
        /// </summary>
        public string DALNameSpace
        {
            set { _dalnamespace = value; }
            get { return _dalnamespace; }
        }

        public string DALName
        {
            set { _dalname = value; }
            get { return _dalname; }
        }
        
        public string DbHelperName
        {
            set { _dbhelperName = value; }
            get { return _dbhelperName; }
        }

        public string ModelName { get; set; }
        
        #endregion

        #region 构造属性

        /// <summary>
        /// 字段的 select * 列表
        /// </summary>
        public string Fieldstrlist
        {
            get
            {
                StringPlus _fields = new StringPlus();
                if (DataTable.Rows.Count > 0)
                {
                    foreach (DataRow dr in DataTable.Rows)
                    {
                        _fields.Append(dr["字段名"].ToString() + ",");
                    }
                }
                _fields.DelLastComma();
                return _fields.Value;
            }
        }

        /// <summary>
        /// 不同数据库类的前缀
        /// </summary>
        public string DbParaHead
        {
            get
            {
                switch (DbType)
                {
                    case "SQL2000":
                    case "SQL2005":
                    case "SQL2008":
                        return "Sql";
                    case "Oracle":
                        return "Oracle";
                    case "MySQL":
                        return "MySql";
                    case "OleDb":
                        return "OleDb";
                    case "SQLite":
                        return "SQLite";
                    default:
                        return "Sql";
                }
            }

        }

        /// <summary>
        ///  不同数据库字段类型
        /// </summary>
        public string DbParaDbType
        {
            get
            {
                switch (DbType)
                {
                    case "SQL2000":
                    case "SQL2005":
                    case "SQL2008":
                        return "SqlDbType";
                    case "Oracle":
                        return "OracleType";
                    case "MySQL":
                        return "MySqlDbType";
                    case "OleDb":
                        return "OleDbType";
                    case "SQLite":
                        return "DbType";
                    default:
                        return "SqlDbType";
                }
            }
        }

        /// <summary>
        /// 存储过程参数 调用符号@
        /// </summary>
        public string preParameter
        {
            get
            {
                switch (DbType)
                {
                    case "SQL2000":
                    case "SQL2005":
                    case "SQL2008":
                        return "@";
                    case "Oracle":
                        return ":";
                        //case "OleDb":
                        // break;
                    default:
                        return "@";

                }
            }
        }

        /// <summary>
        /// 列中是否有标识列
        /// </summary>
        public bool IsHasIdentity
        {
            get
            {
                bool isid = false;
                foreach (DataRow dr in DataTable.Rows)
                {
                    if (dr["主键"].ToString().Length > 0)
                    {
                        isid = true;
                    }
                }
                return isid;
            }
        }
        
        #endregion
        
        #region 数据层(整个类)

        public string CreatDalCode()
        {
            StringPlus strclass = new StringPlus();
            strclass.AppendLine("using System;");
            strclass.AppendLine("using System.Data;");
            strclass.AppendLine("using System.Text;");
            strclass.AppendLine("using " + ModelSpace+";");
            switch (DbType)
            {
                case "SQL2005":
                case "SQL2008":
                    strclass.AppendLine("using System.Data.SqlClient;");
                    break;
                case "SQL2000":
                    strclass.AppendLine("using System.Data.SqlClient;");
                    break;
                case "Oracle":
                    strclass.AppendLine("using System.Data.OracleClient;");
                    break;
                case "MySQL":
                    strclass.AppendLine("using MySql.Data.MySqlClient;");
                    break;
                case "OleDb":
                    strclass.AppendLine("using System.Data.OleDb;");
                    break;
                case "SQLite":
                    strclass.AppendLine("using System.Data.SQLite;");
                    break;
            }
            strclass.AppendLine("using DBHelper;//Please add references");
            strclass.AppendLine("namespace " + DALNameSpace);
            strclass.AppendLine("{");
            strclass.AppendSpaceLine(1, "/// <summary>");
            strclass.AppendSpaceLine(1, "/// 数据访问类:" + DALName);
            strclass.AppendSpaceLine(1, "/// </summary>");
            strclass.AppendSpace(1, "public partial class " + DALName);
            
            strclass.AppendLine("");
            strclass.AppendSpaceLine(1, "{");
            strclass.AppendSpaceLine(2, "public " + DALName + "()");
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
                            strclass.AppendLine(CreatGetMaxID());
                            break;
                        }
                    }
                }
            }
            strclass.AppendLine(CreatExists());
            strclass.AppendLine(CreatAdd());
            strclass.AppendLine(CreatUpdate());
            strclass.AppendLine(CreatDelete());
            strclass.AppendLine(CreatGetModel());
            strclass.AppendLine(CreatGetList());
            strclass.AppendLine(CreatGetListByPage());
            strclass.AppendLine(CreatGetListByPageProc());

            #endregion

            strclass.AppendSpaceLine(2, "#endregion  Method");
            strclass.AppendSpaceLine(1, "}");
            strclass.AppendLine("}");
            strclass.AppendLine("");

            return strclass.ToString();
        }

        #endregion

        #region 数据层(方法)

        /// <summary>
        /// 得到某字段最大值的方法代码(只有主键是int型的情况下生成)
        /// </summary>
        /// <param name="TabName"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        private string CreatGetMaxID()
        {
            StringPlus strclass = new StringPlus();
            if (PrimaryKey.Length > 0)
            {
                strclass.AppendLine("");
                strclass.AppendSpaceLine(2, "/// <summary>");
                strclass.AppendSpaceLine(2, "/// 得到最大ID");
                strclass.AppendSpaceLine(2, "/// </summary>");
                strclass.AppendSpaceLine(2, "public static int GetMaxId()");
                strclass.AppendSpaceLine(2, "{");
                strclass.AppendSpaceLine(2,
                                         "return " + DbHelperName + ".GetMaxID(\"" + PrimaryKey + "\", \"" +
                                         _tablename + "\"); ");
                strclass.AppendSpaceLine(2, "}");
            }
            return strclass.ToString();
        }

        /// <summary>
        /// 得到Exists方法的代码
        /// </summary>
        /// <param name="_tablename"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        private string CreatExists()
        {
            StringPlus strclass = new StringPlus();

            if (PrimaryKey.Length > 0)
            {
                strclass.AppendLine("");
                strclass.AppendSpaceLine(2, "/// <summary>");
                strclass.AppendSpaceLine(2, "/// 是否存在该记录");
                strclass.AppendSpaceLine(2, "/// </summary>");
                strclass.AppendSpaceLine(2, "public static bool Exists(" + PrimaryType + " " + PrimaryKey + ")");
                strclass.AppendSpaceLine(2, "{");
                strclass.AppendSpaceLine(3, "StringBuilder strSql=new StringBuilder();");
                strclass.AppendSpaceLine(3, "strSql.Append(\"select count(1) from " + _tablename + "\");");
                strclass.AppendSpaceLine(3,
                                         "strSql.Append(\" where " + PrimaryKey + " = \"+" + PrimaryKey + "+\"\" );");
                strclass.AppendSpaceLine(3, "return " + DbHelperName + ".Exists(strSql.ToString());");
                strclass.AppendSpace(2, "}");
            }
            return strclass.ToString();
        }

        /// <summary>
        /// 得到Add()的代码
        /// </summary>        
        private string CreatAdd()
        {
            StringPlus strclass = new StringPlus();
            strclass.AppendLine("");
            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 增加一条数据");
            strclass.AppendSpaceLine(2, "/// </summary>");
            string strretu = "bool";
            if ((DbType == "SQL2000" || DbType == "SQL2005" ||
                 DbType == "SQL2008" || DbType == "SQLite") && (IsHasIdentity))
            {
                strretu = "int";
                if (PrimaryKey != "int")
                {
                    strretu = PrimaryKey;
                }
            }
            //if (dbobj.DbType == "OleDb" && IsHasIdentity)
            //{
            //    strretu = "bool";
            //}

            //方法定义头
            strclass.AppendSpaceLine(1, "public static " + strretu + " Add(" + ModelName + " model)");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "StringBuilder strSql=new StringBuilder();");
            strclass.AppendSpaceLine(3, "StringBuilder strSql1=new StringBuilder();");
            strclass.AppendSpaceLine(3, "StringBuilder strSql2=new StringBuilder();");
            foreach (DataRow dr in DataTable.Rows)
            {
                string columnName = dr["字段名"].ToString();
                string columnType = dr["字段类型"].ToString();
                bool IsIdentity = false;
                if(dr["主键"].ToString().Length >0)
                    IsIdentity = true;
                if (IsIdentity)
                {
                    continue;
                }
                strclass.AppendSpaceLine(3, "if (model." + columnName + " != null)");
                strclass.AppendSpaceLine(3, "{");
                strclass.AppendSpaceLine(4, "strSql1.Append(\"" + columnName + ",\");");
                if ((DbType == "Oracle") && (columnType.ToLower() == "date" || columnType.ToLower() == "datetime"))
                {
                    strclass.AppendSpaceLine(4,
                                             "strSql2.Append(\"to_date('\" + model." + columnName +
                                             ".ToString() + \"','YYYY-MM-DD HH24:MI:SS'),\");");
                }
                else if (columnType.ToLower() == "bit")
                {
                    strclass.AppendSpaceLine(4, "strSql2.Append(\"\"+(model." + columnName + "? 1 : 0) +\",\");");
                }
                else if ("uniqueidentifier" == columnType.ToLower())
                {
                    strclass.AppendSpaceLine(4, "strSql2.Append(\"'\"+ Guid.NewGuid().ToString() +\"',\");");
                }
                else if (Tools.IsAddMark(columnType.Trim()))
                {
                    strclass.AppendSpaceLine(4, "strSql2.Append(\"'\"+model." + columnName + "+\"',\");");
                }
                else
                {
                    strclass.AppendSpaceLine(4, "strSql2.Append(\"\"+model." + columnName + "+\",\");");
                }

                strclass.AppendSpaceLine(3, "}");
            }
            strclass.AppendSpaceLine(3, "strSql.Append(\"insert into " + TableName + "(\");");
            strclass.AppendSpaceLine(3, "strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));");
            strclass.AppendSpaceLine(3, "strSql.Append(\")\");");
            strclass.AppendSpaceLine(3, "strSql.Append(\" values (\");");
            strclass.AppendSpaceLine(3, "strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));");
            strclass.AppendSpaceLine(3, "strSql.Append(\")\");");

            if (strretu == "void")
            {
                strclass.AppendSpaceLine(3, "" + DbHelperName + ".ExecuteSql(strSql.ToString());");
            }
            else if (strretu == "bool")
            {
                strclass.AppendSpaceLine(3, "int rows=" + DbHelperName + ".ExecuteSql(strSql.ToString());");
                strclass.AppendSpaceLine(3, "if (rows > 0)");
                strclass.AppendSpaceLine(3, "{");
                strclass.AppendSpaceLine(4, "return true;");
                strclass.AppendSpaceLine(3, "}");
                strclass.AppendSpaceLine(3, "else");
                strclass.AppendSpaceLine(3, "{");
                strclass.AppendSpaceLine(4, "return false;");
                strclass.AppendSpaceLine(3, "}");
            }
            else //返回自动增长列值
            {
                if ((DbType == "SQL2000" || DbType == "SQL2005" || DbType == "SQL2008") &&
                    (IsHasIdentity))
                {
                    strclass.AppendSpaceLine(3, "strSql.Append(\";select @@IDENTITY\");");
                }
                if ((DbType == "SQLite") && (IsHasIdentity))
                {
                    strclass.AppendSpaceLine(3, "strSql.Append(\";select LAST_INSERT_ROWID()\");");
                }
                strclass.AppendSpaceLine(3, "object obj = " + DbHelperName + ".GetSingle(strSql.ToString());");
                strclass.AppendSpaceLine(3, "if (obj == null)");
                strclass.AppendSpaceLine(3, "{");
                strclass.AppendSpaceLine(4, "return 0;");
                strclass.AppendSpaceLine(3, "}");
                strclass.AppendSpaceLine(3, "else");
                strclass.AppendSpaceLine(3, "{");
                switch (strretu)
                {
                    case "int":
                        strclass.AppendSpaceLine(4, "return Convert.ToInt32(obj);");
                        break;
                    case "long":
                        strclass.AppendSpaceLine(4, "return Convert.ToInt64(obj);");
                        break;
                    case "decimal":
                        strclass.AppendSpaceLine(4, "return Convert.ToDecimal(obj);");
                        break;
                }
                strclass.AppendSpaceLine(3, "}");
            }
            strclass.AppendSpace(2, "}");
            return strclass.ToString();
        }

        /// <summary>
        /// 得到Update（）的代码
        /// </summary>
        /// <param name="DbName"></param>
        /// <param name="_tablename"></param>
        /// <param name="_key"></param>
        /// <param name="ModelName"></param>
        /// <returns></returns>
        private string CreatUpdate()
        {
            if (ModelSpace == "")
            {
                //ModelSpace = "ModelClassName"; ;
            }
            StringPlus strclass = new StringPlus();
            strclass.AppendLine("");
            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 更新一条数据");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "public static bool Update(" + ModelName + " model)");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "StringBuilder strSql=new StringBuilder();");
            strclass.AppendSpaceLine(3, "strSql.Append(\"update " + _tablename + " set \");");
            foreach (DataRow dr in DataTable.Rows)
            {
                string columnName = dr["字段名"].ToString();
                string columnType = dr["字段类型"].ToString();
                bool nullable = false;
                bool IsIdentity = false;
                if (dr["主键"].ToString().Length > 0)
                    IsIdentity = true;
                if (dr["允许为空"].ToString().Length>0)
                    nullable = true;
                if (IsIdentity)
                {
                    continue;
                }
                
                if (columnType.ToLower() == "timestamp")
                {
                    continue;
                }
                strclass.AppendSpaceLine(3, "if (model." + columnName + " != null)");
                strclass.AppendSpaceLine(3, "{");

                if ((DbType == "Oracle") && (columnType.ToLower() == "date" || columnType.ToLower() == "datetime"))
                {
                    strclass.AppendSpaceLine(4,
                                             "strSql.Append(\"" + columnName + "=to_date('\" + model." + columnName +
                                             ".ToString() + \"','YYYY-MM-DD HH24:MI:SS'),\");");
                }
                else if (columnType.ToLower() == "bit")
                {
                    strclass.AppendSpaceLine(4,
                                             "strSql.Append(\"" + columnName + "=\"+ (model." + columnName +
                                             "? 1 : 0) +\",\");");
                }
                else if (Tools.IsAddMark(columnType.Trim()))
                {
                    strclass.AppendSpaceLine(4,
                                             "strSql.Append(\"" + columnName + "='\"+model." + columnName + "+\"',\");");
                }
                else
                {
                    strclass.AppendSpaceLine(4, "strSql.Append(\"" + columnName + "=\"+model." + columnName + "+\",\");");
                }
                strclass.AppendSpaceLine(3, "}");
                if (nullable)
                {
                    strclass.AppendSpaceLine(3, "else"); //是null的情况
                    strclass.AppendSpaceLine(3, "{");
                    strclass.AppendSpaceLine(4, "strSql.Append(\"" + columnName + "= null ,\");");
                    strclass.AppendSpaceLine(3, "}");
                }

            }

            //去掉最后的逗号		

            strclass.AppendSpaceLine(3, "int n = strSql.ToString().LastIndexOf(\",\");");
            strclass.AppendSpaceLine(3, "strSql.Remove(n, 1);");
            strclass.AppendSpaceLine(3,
                                     "strSql.Append(\" where " + PrimaryKey + " = \"+model." + PrimaryKey + ");");
            strclass.AppendSpaceLine(3, "int rowsAffected=" + DbHelperName + ".ExecuteSql(strSql.ToString());");

            strclass.AppendSpaceLine(3, "if (rowsAffected > 0)");
            strclass.AppendSpaceLine(3, "{");
            strclass.AppendSpaceLine(4, "return true;");
            strclass.AppendSpaceLine(3, "}");
            strclass.AppendSpaceLine(3, "else");
            strclass.AppendSpaceLine(3, "{");
            strclass.AppendSpaceLine(4, "return false;");
            strclass.AppendSpaceLine(3, "}");

            strclass.AppendSpace(2, "}");
            return strclass.ToString();
        }

        /// <summary>
        /// 得到Delete的代码
        /// </summary>
        /// <param name="_tablename"></param>
        /// <param name="_key"></param>
        /// <returns></returns>
        private string CreatDelete()
        {
            StringPlus strclass = new StringPlus();
            strclass.AppendLine("");
            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 删除一条数据");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2,
                                     "public static bool Delete(" + PrimaryType + " " + PrimaryKey +
                                     ")");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "StringBuilder strSql=new StringBuilder();");
            //if (dbobj.DbType != "OleDb")
            //{
            //    strclass.AppendSpaceLine(3, "strSql.Append(\"delete " + _tablename + " \");" );
            //}
            //else
            //{
            strclass.AppendSpaceLine(3, "strSql.Append(\"delete from " + _tablename + " \");");
            //}
            strclass.AppendSpaceLine(3,
                                     "strSql.Append(\" where " + PrimaryKey + " = \"+" + PrimaryKey + "+\"\" );");

            strclass.AppendSpaceLine(3, "int rowsAffected=" + DbHelperName + ".ExecuteSql(strSql.ToString());");

            strclass.AppendSpaceLine(3, "if (rowsAffected > 0)");
            strclass.AppendSpaceLine(3, "{");
            strclass.AppendSpaceLine(4, "return true;");
            strclass.AppendSpaceLine(3, "}");
            strclass.AppendSpaceLine(3, "else");
            strclass.AppendSpaceLine(3, "{");
            strclass.AppendSpaceLine(4, "return false;");
            strclass.AppendSpaceLine(3, "}");


            strclass.AppendSpace(2, "}");
            
            #region 批量删除方法
            
            if (PrimaryKey.Length > 0)
            {
                strclass.AppendSpaceLine(2, "/// <summary>");
                strclass.AppendSpaceLine(2, "/// 批量删除数据");
                strclass.AppendSpaceLine(2, "/// </summary>");
                strclass.AppendSpaceLine(2, "public static bool DeleteList(string " + PrimaryKey + "list )");
                strclass.AppendSpaceLine(2, "{");
                strclass.AppendSpaceLine(3, "StringBuilder strSql=new StringBuilder();");
                strclass.AppendSpaceLine(3, "strSql.Append(\"delete from " + _tablename + " \");");
                strclass.AppendSpaceLine(3,
                                         "strSql.Append(\" where " + PrimaryKey + " in (\"+" + PrimaryKey +
                                         "list + \")  \");");
                strclass.AppendSpaceLine(3, "int rows=" + DbHelperName + ".ExecuteSql(strSql.ToString());");
                strclass.AppendSpaceLine(3, "if (rows > 0)");
                strclass.AppendSpaceLine(3, "{");
                strclass.AppendSpaceLine(4, "return true;");
                strclass.AppendSpaceLine(3, "}");
                strclass.AppendSpaceLine(3, "else");
                strclass.AppendSpaceLine(3, "{");
                strclass.AppendSpaceLine(4, "return false;");
                strclass.AppendSpaceLine(3, "}");
                strclass.AppendSpaceLine(2, "}");
            }
            #endregion
            return strclass.ToString();
        }

        /// <summary>
        /// 得到GetModel()的代码
        /// </summary>
        /// <param name="DbName"></param>
        /// <param name="_tablename"></param>
        /// <param name="_key"></param>
        /// <param name="ModelName"></param>
        /// <returns></returns>
        private string CreatGetModel()
        {
            StringPlus strclass = new StringPlus();
            strclass.AppendLine();
            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 得到一个对象实体");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2,
                                     "public static " + ModelName + " GetModel(" + PrimaryType + " " + PrimaryKey + ")");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "StringBuilder strSql=new StringBuilder();");
            strclass.AppendSpace(3, "strSql.Append(\"select ");
            if (DbType == "SQL2005" || DbType == "SQL2000" || DbType == "SQL2008")
            {
                strclass.Append(" top 1 ");
            }
            strclass.AppendLine(" \");");
            strclass.AppendSpaceLine(3, "strSql.Append(\" " + Fieldstrlist + " \");");
            strclass.AppendSpaceLine(3, "strSql.Append(\" from " + SelectTableName + " \");");
            strclass.AppendSpaceLine(3,
                                     "strSql.Append(\" where " + PrimaryKey + " = \"+" + PrimaryKey + "+\"\" );");
            strclass.AppendSpaceLine(3, ModelName + " model=new " + ModelName + "();");
            strclass.AppendSpaceLine(3, "DataSet ds=" + DbHelperName + ".ExecuteDs(strSql.ToString());");
            strclass.AppendSpaceLine(3, "if(ds.Tables[0].Rows.Count>0)");
            strclass.AppendSpaceLine(3, "{");

            foreach (DataRow dr in DataTable.Rows)
            {
                string columnName = dr["字段名"].ToString();
                string columnType = dr["字段类型"].ToString();

                strclass.AppendSpaceLine(4,
                                         "if(ds.Tables[0].Rows[0][\"" + columnName +
                                         "\"]!=null && ds.Tables[0].Rows[0][\"" + columnName + "\"].ToString()!=\"\")");
                strclass.AppendSpaceLine(4, "{");

                #region

                switch (Tools.DbTypeToCS(columnType))
                {
                    case "int":
                        {
                            //strclass.AppendSpaceLine(4, "if(ds.Tables[0].Rows[0][\"" + columnName + "\"].ToString()!=\"\")");
                            //strclass.AppendSpaceLine(4, "{");
                            strclass.AppendSpaceLine(5,
                                                     "model." + columnName + "=int.Parse(ds.Tables[0].Rows[0][\"" +
                                                     columnName + "\"].ToString());");
                            //strclass.AppendSpaceLine(4, "}");
                        }
                        break;
                    case "long":
                        {
                            //strclass.AppendSpaceLine(4, "if(ds.Tables[0].Rows[0][\"" + columnName + "\"].ToString()!=\"\")");
                            //strclass.AppendSpaceLine(4, "{");
                            strclass.AppendSpaceLine(5,
                                                     "model." + columnName + "=long.Parse(ds.Tables[0].Rows[0][\"" +
                                                     columnName + "\"].ToString());");
                            //strclass.AppendSpaceLine(4, "}");
                        }
                        break;
                    case "decimal":
                        {
                            //strclass.AppendSpaceLine(4, "if(ds.Tables[0].Rows[0][\"" + columnName + "\"].ToString()!=\"\")");
                            //strclass.AppendSpaceLine(4, "{");
                            strclass.AppendSpaceLine(5,
                                                     "model." + columnName + "=decimal.Parse(ds.Tables[0].Rows[0][\"" +
                                                     columnName + "\"].ToString());");
                            //strclass.AppendSpaceLine(4, "}");
                        }
                        break;
                    case "float":
                        {
                            //strclass.AppendSpaceLine(4, "if(ds.Tables[0].Rows[0][\"" + columnName + "\"].ToString()!=\"\")");
                            //strclass.AppendSpaceLine(4, "{");
                            strclass.AppendSpaceLine(5,
                                                     "model." + columnName + "=float.Parse(ds.Tables[0].Rows[0][\"" +
                                                     columnName + "\"].ToString());");
                            //strclass.AppendSpaceLine(4, "}");
                        }
                        break;
                    case "DateTime":
                        {
                            //strclass.AppendSpaceLine(4, "if(ds.Tables[0].Rows[0][\"" + columnName + "\"].ToString()!=\"\")");
                            //strclass.AppendSpaceLine(4, "{");
                            strclass.AppendSpaceLine(5,
                                                     "model." + columnName + "=DateTime.Parse(ds.Tables[0].Rows[0][\"" +
                                                     columnName + "\"].ToString());");
                            //strclass.AppendSpaceLine(4, "}");
                        }
                        break;
                    case "string":
                        {
                            //strclass.AppendSpaceLine(4, "if(ds.Tables[0].Rows[0][\"" + columnName + "\"]!=null)");
                            //strclass.AppendSpaceLine(4, "{");
                            strclass.AppendSpaceLine(5,
                                                     "model." + columnName + "=ds.Tables[0].Rows[0][\"" + columnName +
                                                     "\"].ToString();");
                            //strclass.AppendSpaceLine(4, "}");
                        }
                        break;
                    case "bool":
                        {
                            //strclass.AppendSpaceLine(4, "if(ds.Tables[0].Rows[0][\"" + columnName + "\"].ToString()!=\"\")");
                            //strclass.AppendSpaceLine(4, "{");
                            strclass.AppendSpaceLine(5,
                                                     "if((ds.Tables[0].Rows[0][\"" + columnName +
                                                     "\"].ToString()==\"1\")||(ds.Tables[0].Rows[0][\"" + columnName +
                                                     "\"].ToString().ToLower()==\"true\"))");
                            strclass.AppendSpaceLine(5, "{");
                            strclass.AppendSpaceLine(6, "model." + columnName + "=true;");
                            strclass.AppendSpaceLine(5, "}");
                            strclass.AppendSpaceLine(5, "else");
                            strclass.AppendSpaceLine(5, "{");
                            strclass.AppendSpaceLine(6, "model." + columnName + "=false;");
                            strclass.AppendSpaceLine(5, "}");
                            //strclass.AppendSpaceLine(4, "}");
                        }
                        break;
                    case "byte[]":
                        {
                            //strclass.AppendSpaceLine(4, "if(ds.Tables[0].Rows[0][\"" + columnName + "\"].ToString()!=\"\")");
                            //strclass.AppendSpaceLine(4, "{");
                            strclass.AppendSpaceLine(5,
                                                     "model." + columnName + "=(byte[])ds.Tables[0].Rows[0][\"" +
                                                     columnName + "\"];");
                            //strclass.AppendSpaceLine(4, "}");
                        }
                        break;
                    case "uniqueidentifier":
                    case "Guid":
                        {
                            //strclass.AppendSpaceLine(4, "if(ds.Tables[0].Rows[0][\"" + columnName + "\"].ToString()!=\"\")");
                            //strclass.AppendSpaceLine(4, "{");
                            strclass.AppendSpaceLine(5,
                                                     "model." + columnName + "=new Guid(ds.Tables[0].Rows[0][\"" +
                                                     columnName + "\"].ToString());");
                            //strclass.AppendSpaceLine(4, "}");
                        }
                        break;
                    default:
                        strclass.AppendSpaceLine(5,
                                                 "//model." + columnName + "=ds.Tables[0].Rows[0][\"" + columnName +
                                                 "\"].ToString();");
                        break;
                }

                #endregion

                strclass.AppendSpaceLine(4, "}");

            }
            strclass.AppendSpaceLine(4, "return model;");
            strclass.AppendSpaceLine(3, "}");
            strclass.AppendSpaceLine(3, "else");
            strclass.AppendSpaceLine(3, "{");
            strclass.AppendSpaceLine(4, "return null;");
            strclass.AppendSpaceLine(3, "}");
            strclass.AppendSpace(2, "}");
            return strclass.ToString();
        }

        /// <summary>
        /// 得到GetList()的代码
        /// </summary>
        /// <param name="_tablename"></param>
        /// <param name="_key"></param>
        /// <returns></returns>
        private string CreatGetList()
        {
            StringPlus strclass = new StringPlus();
            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 获得数据列表");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "public static DataSet GetList(string strWhere)");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "StringBuilder strSql=new StringBuilder();");
            strclass.AppendSpace(3, "strSql.Append(\"select ");
            strclass.AppendLine(Fieldstrlist + " \");");
            strclass.AppendSpaceLine(3, "strSql.Append(\" FROM " + SelectTableName + " \");");
            strclass.AppendSpaceLine(3, "if(strWhere.Trim()!=\"\")");
            strclass.AppendSpaceLine(3, "{");
            strclass.AppendSpaceLine(4, "strSql.Append(\" where \"+strWhere);");
            strclass.AppendSpaceLine(3, "}");
            strclass.AppendSpaceLine(3, "return " + DbHelperName + ".ExecuteDs(strSql.ToString());");
            strclass.AppendSpaceLine(2, "}");

            if ((DbType == "SQL2000") ||
                (DbType == "SQL2005") ||
                (DbType == "SQL2008"))
            {
                strclass.AppendLine();
                strclass.AppendSpaceLine(2, "/// <summary>");
                strclass.AppendSpaceLine(2, "/// 获得前几行数据");
                strclass.AppendSpaceLine(2, "/// </summary>");
                strclass.AppendSpaceLine(2, "public static DataSet GetList(int Top,string strWhere,string filedOrder)");
                strclass.AppendSpaceLine(2, "{");
                strclass.AppendSpaceLine(3, "StringBuilder strSql=new StringBuilder();");
                strclass.AppendSpaceLine(3, "strSql.Append(\"select \");");
                strclass.AppendSpaceLine(3, "if(Top>0)");
                strclass.AppendSpaceLine(3, "{");
                strclass.AppendSpaceLine(4, "strSql.Append(\" top \"+Top.ToString());");
                strclass.AppendSpaceLine(3, "}");
                strclass.AppendSpaceLine(3, "strSql.Append(\" " + Fieldstrlist + " \");");
                strclass.AppendSpaceLine(3, "strSql.Append(\" FROM " + TableName + " \");");
                strclass.AppendSpaceLine(3, "if(strWhere.Trim()!=\"\")");
                strclass.AppendSpaceLine(3, "{");
                strclass.AppendSpaceLine(4, "strSql.Append(\" where \"+strWhere);");
                strclass.AppendSpaceLine(3, "}");
                strclass.AppendSpaceLine(3, "strSql.Append(\" order by \" + filedOrder);");
                strclass.AppendSpaceLine(3, "return " + DbHelperName + ".ExecuteDs(strSql.ToString());");
                strclass.AppendSpaceLine(2, "}");
            }

            return strclass.Value;
        }

        /// <summary>
        /// 得到分页方法的代码
        /// </summary>        
        private string CreatGetListByPage()
        {
            StringPlus strclass = new StringPlus();
            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 获取记录总数");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "public static int GetRecordCount(string strWhere)");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "StringBuilder strSql=new StringBuilder();");
            strclass.AppendSpaceLine(3, "strSql.Append(\"select count(1) FROM " + SelectTableName + " \");");
            strclass.AppendSpaceLine(3, "if(strWhere.Trim()!=\"\")");
            strclass.AppendSpaceLine(3, "{");
            strclass.AppendSpaceLine(4, "strSql.Append(\" where \"+strWhere);");
            strclass.AppendSpaceLine(3, "}");
            strclass.AppendSpaceLine(3, "object obj =" + DbHelperName + ".GetSingle(strSql.ToString());");
            strclass.AppendSpaceLine(3, "if (obj == null)");
            strclass.AppendSpaceLine(3, "{");
            strclass.AppendSpaceLine(4, "return 0;");
            strclass.AppendSpaceLine(3, "}");
            strclass.AppendSpaceLine(3, "else");
            strclass.AppendSpaceLine(3, "{");
            strclass.AppendSpaceLine(4, "return Convert.ToInt32(obj);");
            strclass.AppendSpaceLine(3, "}");
            strclass.AppendSpaceLine(2, "}");

            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 分页获取数据列表");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2,
                                     "public static DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "StringBuilder strSql=new StringBuilder();");
            strclass.AppendSpaceLine(3, "strSql.Append(\"SELECT * FROM ( \");");
            strclass.AppendSpaceLine(3, "strSql.Append(\" SELECT ROW_NUMBER() OVER (\");");
            strclass.AppendSpaceLine(3, "if (!string.IsNullOrEmpty(orderby.Trim()))");
            strclass.AppendSpaceLine(3, "{");
            strclass.AppendSpaceLine(4, "strSql.Append(\"order by T.\" + orderby );");
            strclass.AppendSpaceLine(3, "}");
            strclass.AppendSpaceLine(3, "else");
            strclass.AppendSpaceLine(3, "{");
            strclass.AppendSpaceLine(4, "strSql.Append(\"order by T." + PrimaryKey + " desc\");");
            strclass.AppendSpaceLine(3, "}");

            strclass.AppendSpaceLine(3, "strSql.Append(\")AS Row, T.*  from " + SelectTableName.Substring(0,SelectTableName.Length-1) + " T \");");
            strclass.AppendSpaceLine(3, "if (!string.IsNullOrEmpty(strWhere.Trim()))");
            strclass.AppendSpaceLine(3, "{");
            strclass.AppendSpaceLine(4, "strSql.Append(\" WHERE \" + strWhere);");
            strclass.AppendSpaceLine(3, "}");

            strclass.AppendSpaceLine(3, "strSql.Append(\" ) TT\");");
            strclass.AppendSpaceLine(3,
                                     "strSql.AppendFormat(\" WHERE TT.Row between {0} and {1}\", startIndex, endIndex);");

            strclass.AppendSpaceLine(3, "return " + DbHelperName + ".ExecuteDs(strSql.ToString());");
            strclass.AppendSpaceLine(2, "}");

            return strclass.Value;
        }

        /// <summary>
        /// 得到GetList()的代码
        /// </summary>
        /// <param name="_tablename"></param>
        /// <param name="_key"></param>
        /// <returns></returns>
        private string CreatGetListByPageProc()
        {
            StringPlus strclass = new StringPlus();
            strclass.AppendSpaceLine(2, "/*");
            //strclass.AppendSpaceLine(2, "/// <summary>");
            //strclass.AppendSpaceLine(2, "/// "+Languagelist["summaryGetList3"].ToString());
            //strclass.AppendSpaceLine(2, "/// </summary>");
            //strclass.AppendSpaceLine(2, "public DataSet GetList(int PageSize,int PageIndex,string strWhere)");
            //strclass.AppendSpaceLine(2, "{");
            //strclass.AppendSpaceLine(3, "" + DbParaHead + "Parameter[] parameters = {");
            //strclass.AppendSpaceLine(5, "new " + DbParaHead + "Parameter(\"" + preParameter + "tblName\", " + DbParaDbType + ".VarChar, 255),");
            //strclass.AppendSpaceLine(5, "new " + DbParaHead + "Parameter(\"" + preParameter + "fldName\", " + DbParaDbType + ".VarChar, 255),");
            //strclass.AppendSpaceLine(5, "new " + DbParaHead + "Parameter(\"" + preParameter + "PageSize\", " + DbParaDbType + "." + CodeCommon.CSToProcType(dbobj.DbType, "int") + "),");
            //strclass.AppendSpaceLine(5, "new " + DbParaHead + "Parameter(\"" + preParameter + "PageIndex\", " + DbParaDbType + "." + CodeCommon.CSToProcType(dbobj.DbType, "int") + "),");
            //strclass.AppendSpaceLine(5, "new " + DbParaHead + "Parameter(\"" + preParameter + "IsReCount\", " + DbParaDbType + "." + CodeCommon.CSToProcType(dbobj.DbType, "bit") + "),");
            //strclass.AppendSpaceLine(5, "new " + DbParaHead + "Parameter(\"" + preParameter + "OrderType\", " + DbParaDbType + "." + CodeCommon.CSToProcType(dbobj.DbType, "bit") + "),");
            //strclass.AppendSpaceLine(5, "new " + DbParaHead + "Parameter(\"" + preParameter + "strWhere\", " + DbParaDbType + ".VarChar,1000),");
            //strclass.AppendSpaceLine(5, "};");
            //strclass.AppendSpaceLine(3, "parameters[0].Value = \"" + TableName + "\";");
            //strclass.AppendSpaceLine(3, "parameters[1].Value = \"" + _key + "\";");
            //strclass.AppendSpaceLine(3, "parameters[2].Value = PageSize;");
            //strclass.AppendSpaceLine(3, "parameters[3].Value = PageIndex;");
            //strclass.AppendSpaceLine(3, "parameters[4].Value = 0;");
            //strclass.AppendSpaceLine(3, "parameters[5].Value = 0;");
            //strclass.AppendSpaceLine(3, "parameters[6].Value = strWhere;	");
            //strclass.AppendSpaceLine(3, "return " + DbHelperName + ".RunProcedure(\"UP_GetRecordByPage\",parameters,\"ds\");");
            //strclass.AppendSpaceLine(2, "}");
            strclass.AppendSpaceLine(2, "*/");
            return strclass.Value;
        }

        #endregion//数据层

        public string WriteDalFile(string DalContent, string Path)
        {
            try
            {
                string DalCSProj = FileHelper.ReadFile(Path + "\\Dal\\Dal.csproj");
                if (!DalCSProj.Contains("Entities\\" + DALName + ".cs"))
                {
                    FileHelper.WriteFile(Path + "\\Dal\\" + DALName + ".cs", DalContent);
                    FileHelper.WriteFile(Path + "\\Dal\\Dal.csproj", DalCSProj.Replace("<!--MODELPOINT-->", "<Compile Include=\"Entities\\" + DALName + ".cs\" />\r\n\t<!--MODELPOINT-->"));
                }
                return "Dal创建成功";
            }
            catch (Exception error)
            {
                return "ERROR：Dal生成错误-" + error.Message;
            }
        }

    }
}