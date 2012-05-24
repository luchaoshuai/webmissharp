using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CJ;
using System.Data;
using BaseLibs;
using StaticConfigure;
using System.Data.SqlClient;

namespace DBHelper
{
    public class SQLDBHelper
    {
        //创建基础数据表，数据
        public static int CreateBasicTableAndData(string ProName)
        {
            CJ_DevelopHelper.SqlConn_Str = XMLHelper.Read(XMLPaths.ProjectXml, "/Root/Project[@Name='" + ProName + "']/DBConStr", "");
            CJ_DevelopHelper.SqlStr = FileHelper.ReadFile(".\\CFG\\BasicData.sql");
            int i = CJ_DevelopHelper.SQL_ExecuteNonQuery;
            CJ_DevelopHelper.SqlStr = SQLCmds.S_CreatePageProc;
            i += CJ_DevelopHelper.SQL_ExecuteNonQuery;
            CJ_DevelopHelper.SqlStr = SQLCmds.S_CreatePageProc2;
            return i + CJ_DevelopHelper.SQL_ExecuteNonQuery;
        }
        /// <summary>
        /// 获取所有的Table
        /// </summary>
        /// <param name="ProName">项目名称</param>
        /// <returns></returns>
        public static DataTable GetAllTables(string ProName)
        {
            CJ_DevelopHelper.SqlConn_Str = XMLHelper.Read(XMLPaths.ProjectXml, "/Root/Project[@Name='" + ProName + "']/DBConStr", "");
            CJ_DevelopHelper.SqlStr = SQLCmds.S_GETAllTables;
            return CJ_DevelopHelper.SQL_ReturnDateTable;
        }
        /// <summary>
        /// 获取所有的表、视图、存储过程
        /// </summary>
        /// <param name="ProName"></param>
        /// <returns></returns>
        public static DataTable GetTableViewProc(string ProName)
        {
            //ORACLE,和SQLSERVER区别
            //TO DO
            CJ_DevelopHelper.SqlConn_Str = XMLHelper.Read(XMLPaths.ProjectXml, "/Root/Project[@Name='" + ProName + "']/DBConStr", "");
            CJ_DevelopHelper.SqlStr = SQLCmds.S_GETTables;
            return CJ_DevelopHelper.SQL_ReturnDateTable;
        }
        /// <summary>
        /// 获取所有的表、视图,供Combox下拉store使用
        /// </summary>
        /// <param name="ProName"></param>
        /// <returns></returns>
        public static DataTable GetTableView(string ProName)
        {
            //ORACLE,和SQLSERVER区别
            //TO DO
            CJ_DevelopHelper.SqlConn_Str = XMLHelper.Read(XMLPaths.ProjectXml, "/Root/Project[@Name='" + ProName + "']/DBConStr", "");
            CJ_DevelopHelper.SqlStr = SQLCmds.S_GETTableAndViews;
            return CJ_DevelopHelper.SQL_ReturnDateTable;
        }
        /// <summary>
        /// 获取表结构
        /// </summary>
        /// <param name="ProName"></param>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public static DataTable GetTableViewStruct(string ProName, string TableName)
        {
            CJ_DevelopHelper.SqlConn_Str = XMLHelper.Read(XMLPaths.ProjectXml, "/Root/Project[@Name='" + ProName + "']/DBConStr", "");
            CJ_DevelopHelper.SqlStr = String.Format(SQLCmds.S_GETTableViewStruct, TableName);
            return CJ_DevelopHelper.SQL_ReturnDateTable;
        }
        /// <summary>
        /// 获取数据库名称
        /// </summary>
        /// <param name="ProName"></param>
        /// <returns></returns>
        public static string GetDBName(string ProName)
        {
            //ORACLE,和SQLSERVER区别
            //TO DO
            CJ_DevelopHelper.SqlConn_Str = XMLHelper.Read(XMLPaths.ProjectXml, "/Root/Project[@Name='" + ProName + "']/DBConStr", "");
            CJ_DevelopHelper.SqlStr = SQLCmds.S_GETDBName;
            return CJ_DevelopHelper.SQL_ReturnDateTable.Rows[0][0].ToString();
        }
        /// <summary>
        /// 获取数据库的基本属性
        /// </summary>
        /// <param name="ProName"></param>
        /// <returns></returns>
        public static DataTable GetDBBasicInfo(string ProName)
        {
            CJ_DevelopHelper.SqlConn_Str = XMLHelper.Read(XMLPaths.ProjectXml, "/Root/Project[@Name='" + ProName + "']/DBConStr", "");
            CJ_DevelopHelper.SqlStr = SQLCmds.S_GETDBBasic;
            return CJ_DevelopHelper.SQL_ReturnDateTable;
        }
        /// <summary>
        /// 获取数据库文件信息
        /// </summary>
        /// <param name="ProName"></param>
        /// <returns></returns>
        public static DataTable GetDBFilesInfo(string ProName)
        {
            CJ_DevelopHelper.SqlConn_Str = XMLHelper.Read(XMLPaths.ProjectXml, "/Root/Project[@Name='" + ProName + "']/DBConStr", "");
            CJ_DevelopHelper.SqlStr = SQLCmds.S_GETDBFiles;
            return CJ_DevelopHelper.SQL_ReturnDateTable;
        }
        /// <summary>
        /// 获取P V U的数量
        /// </summary>
        /// <param name="ProName"></param>
        /// <returns></returns>
        public static DataTable GetUVPcount(string ProName)
        {
            CJ_DevelopHelper.SqlConn_Str = XMLHelper.Read(XMLPaths.ProjectXml, "/Root/Project[@Name='" + ProName + "']/DBConStr", "");
            CJ_DevelopHelper.SqlStr = SQLCmds.S_GETPVUcount;
            return CJ_DevelopHelper.SQL_ReturnDateTable;
        }
        /// <summary>
        /// 获取表的基本信息
        /// </summary>
        /// <param name="ProName"></param>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public static DataTable GetTableBasic(string ProName, string TableName)
        {
            CJ_DevelopHelper.SqlConn_Str = XMLHelper.Read(XMLPaths.ProjectXml, "/Root/Project[@Name='" + ProName + "']/DBConStr", "");
            CJ_DevelopHelper.SqlStr = String.Format(SQLCmds.S_GETTableBasic, TableName);
            return CJ_DevelopHelper.SQL_ReturnDateTable;
        }
        /// <summary>
        /// 获取表的大小信息
        /// </summary>
        /// <param name="ProName"></param>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public static DataTable GetTableSize(string ProName, string TableName)
        {
            SqlParameter[] parameters = { new SqlParameter("@objname", SqlDbType.NVarChar, 776) };
            parameters[0].Value = TableName;
            return RunProc(
                 XMLHelper.Read(XMLPaths.ProjectXml, "/Root/Project[@Name='" + ProName + "']/DBConStr", ""),
                 "sys.sp_spaceused",
                 parameters);
        }
        /// <summary>
        /// 获取表的结构
        /// </summary>
        /// <param name="ProName"></param>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public static DataTable GetTableStructs(string ProName, string TableName)
        {
            CJ_DevelopHelper.SqlConn_Str = XMLHelper.Read(XMLPaths.ProjectXml, "/Root/Project[@Name='" + ProName + "']/DBConStr", "");
            CJ_DevelopHelper.SqlStr = String.Format(SQLCmds.S_GETTableStruct, TableName);
            return CJ_DevelopHelper.SQL_ReturnDateTable;
        }
        /// <summary>
        /// 获取视图的结构
        /// </summary>
        /// <param name="ProName"></param>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public static DataTable GetViewStructs(string ProName, string TableName)
        {
            CJ_DevelopHelper.SqlConn_Str = XMLHelper.Read(XMLPaths.ProjectXml, "/Root/Project[@Name='" + ProName + "']/DBConStr", "");
            CJ_DevelopHelper.SqlStr = String.Format(SQLCmds.S_GETViewStruct, TableName);
            return CJ_DevelopHelper.SQL_ReturnDateTable;
        }
        /// <summary>
        /// 更新表字段备注信息
        /// </summary>
        /// <param name="ProName"></param>
        /// <param name="Tid"></param>
        /// <param name="Cid"></param>
        /// <param name="TableName"></param>
        /// <param name="FieldName"></param>
        /// <param name="Remark"></param>
        public static void SetTableFieldRemark(string ProName, string Tid, string Cid, string TableName, string FieldName, string Remark)
        {
            CJ_DevelopHelper.SqlConn_Str = XMLHelper.Read(XMLPaths.ProjectXml, "/Root/Project[@Name='" + ProName + "']/DBConStr", "");
            CJ_DevelopHelper.SqlStr = String.Format(SQLCmds.S_SETFieldRemark, Tid, Cid, TableName, FieldName, Remark);
            int result = CJ_DevelopHelper.SQL_ExecuteNonQuery;
        }

        public static void SetViewFieldRemark(string ProName, string Tid, string Cid, string TableName, string FieldName, string Remark)
        {
            CJ_DevelopHelper.SqlConn_Str = XMLHelper.Read(XMLPaths.ProjectXml, "/Root/Project[@Name='" + ProName + "']/DBConStr", "");
            CJ_DevelopHelper.SqlStr = String.Format(SQLCmds.S_SETViewFieldRemark, Tid, Cid, TableName, FieldName, Remark);
            int result = CJ_DevelopHelper.SQL_ExecuteNonQuery;
        }

        private static DataTable RunProc(string connStr, string ProcName, IDataParameter[] para)
        {
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connection, ProcName, para);
                sqlDA.Fill(dataSet);
                connection.Close();
                return dataSet.Tables[0];
            }
        }
        private static SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                if (parameter != null)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    command.Parameters.Add(parameter);
                }
            }

            return command;
        }
        /// <summary>
        /// 获取列说明
        /// </summary>
        /// <param name="ProName"></param>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public static DataTable GetColumnsDesc(string ProName, string TableName)
        {
            CJ_DevelopHelper.SqlConn_Str = XMLHelper.Read(XMLPaths.ProjectXml, "/Root/Project[@Name='" + ProName + "']/DBConStr", "");
            CJ_DevelopHelper.SqlStr = string.Format(SQLCmds.S_GetTableColumnsDesc, TableName);
            return CJ_DevelopHelper.SQL_ReturnDateTable;
        }
        /// <summary>
        /// 执行查询
        /// </summary>
        /// <param name="ProName"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable RunSQLString(string ProName, string sql)
        {
            CJ_DevelopHelper.SqlConn_Str = XMLHelper.Read(XMLPaths.ProjectXml, "/Root/Project[@Name='" + ProName + "']/DBConStr", "");
            CJ_DevelopHelper.SqlStr = sql;
            return CJ_DevelopHelper.SQL_ReturnDateTable;
        }
        /// <summary>
        /// 执行非查询
        /// </summary>
        /// <param name="ProName"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int RunNoReturnSQLString(string ProName, string sql)
        {
            CJ_DevelopHelper.SqlConn_Str = XMLHelper.Read(XMLPaths.ProjectXml, "/Root/Project[@Name='" + ProName + "']/DBConStr", "");
            CJ_DevelopHelper.SqlStr = sql;
            return CJ_DevelopHelper.SQL_ExecuteNonQuery;
        }

        /*
        /// <summary>
        /// 生成数据库表创建脚本
        /// </summary>
        /// <returns></returns>
        public string CreateTabScript(string ProName,string dbname, string tablename)
        {
            CJ_DevelopHelper.SqlConn_Str = XMLHelper.Read(XMLPaths.ProjectXml, "/Root/Project[@Name='" + ProName + "']/DBConStr", "");

            List<ColumnInfo> collist = dbobj.GetColumnInfoList(dbname, tablename);
            DataTable dt = LTP.CodeHelper.CodeCommon.GetColumnInfoDt(collist);
            StringPlus strclass = new StringPlus();
            strclass.AppendLine("if exists (select * from sysobjects where id = OBJECT_ID('[" + tablename + "]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) ");
            strclass.AppendLine("DROP TABLE [" + tablename + "]");

            string PKfild = "";//主键字段
            bool IsIden = false;//是否是标识字段
            StringPlus ColdefaVal = new StringPlus();//字段的默认值列表			

            Hashtable FildtabList = new Hashtable();//字段列表
            StringPlus FildList = new StringPlus();//字段列表
            //开始创建表
            strclass.AppendLine("");
            strclass.AppendLine("CREATE TABLE [" + tablename + "] (");
            if (dt != null)
            {
                DataRow[] dtrows;
                if (Fieldlist.Count > 0)
                {
                    dtrows = dt.Select("ColumnName in (" + Fields + ")", "colorder asc");
                }
                else
                {
                    dtrows = dt.Select();
                }

                foreach (DataRow row in dtrows)
                {
                    string columnName = row["ColumnName"].ToString();
                    string columnType = row["TypeName"].ToString();
                    string IsIdentity = row["IsIdentity"].ToString();
                    string Length = row["Length"].ToString();
                    string Preci = row["Preci"].ToString();
                    string Scale = row["Scale"].ToString();
                    string ispk = row["isPK"].ToString();
                    string isnull = row["cisNull"].ToString();
                    string defaultVal = row["defaultVal"].ToString();
                    strclass.Append("[" + columnName + "] [" + columnType + "] ");
                    if (IsIdentity == "√")
                    {
                        IsIden = true;
                        strclass.Append(" IDENTITY (1, 1) ");
                    }
                    switch (columnType.Trim())
                    {
                        case "varchar":
                        case "char":
                        case "nchar":
                        case "binary":
                        case "nvarchar":
                        case "varbinary":
                            {
                                string len = CodeCommon.GetDataTypeLenVal(columnType.Trim(), Length);
                                strclass.Append(" (" + len + ")");
                            }
                            break;
                        case "decimal":
                        case "numeric":
                            strclass.Append(" (" + Preci + "," + Scale + ")");
                            break;
                    }
                    if (isnull == "√")
                    {
                        strclass.Append(" NULL");
                    }
                    else
                    {
                        strclass.Append(" NOT NULL");
                    }
                    if (defaultVal != "")
                    {
                        strclass.Append(" DEFAULT " + defaultVal);
                    }
                    strclass.AppendLine(",");

                    FildtabList.Add(columnName, columnType);
                    FildList.Append("[" + columnName + "],");
                    if ((ispk == "√") && (PKfild == ""))
                    {
                        PKfild = columnName;//得到主键
                    }
                }
            }
            strclass.DelLastComma();
            FildList.DelLastComma();
            strclass.AppendLine(")");
            strclass.AppendLine("");

            if (PKfild != "")
            {
                strclass.AppendLine("ALTER TABLE [" + tablename + "] WITH NOCHECK ADD  CONSTRAINT [PK_" + tablename + "] PRIMARY KEY  NONCLUSTERED ( [" + PKfild + "] )");
            }

            //是自动增长列
            if (IsIden)
            {
                strclass.AppendLine("SET IDENTITY_INSERT [" + tablename + "] ON");
                strclass.AppendLine("");
            }

            //获取数据
            DataTable dtdata = dbobj.GetTabData(dbname, tablename);
            if (dtdata != null)
            {
                foreach (DataRow row in dtdata.Rows)//循环表数据
                {
                    StringPlus strfild = new StringPlus();
                    StringPlus strdata = new StringPlus();
                    string[] split = FildList.Value.Split(new Char[] { ',' });

                    foreach (string fild in split)//循环一行数据的各个字段
                    {
                        string colname = fild.Substring(1, fild.Length - 2);
                        string coltype = "";
                        foreach (DictionaryEntry myDE in FildtabList)
                        {
                            if (myDE.Key.ToString() == colname)
                            {
                                coltype = myDE.Value.ToString();
                            }
                        }
                        string strval = "";
                        switch (coltype)
                        {
                            case "binary":
                                {
                                    byte[] bys = (byte[])row[colname];
                                    strval = LTP.CodeHelper.CodeCommon.ToHexString(bys);
                                }
                                break;
                            case "bit":
                                {
                                    strval = (row[colname].ToString().ToLower() == "true") ? "1" : "0";
                                }
                                break;
                            default:
                                strval = row[colname].ToString().Trim();
                                break;
                        }
                        if (strval != "")
                        {
                            if (LTP.CodeHelper.CodeCommon.IsAddMark(coltype))
                            {
                                strdata.Append("'" + strval + "',");
                            }
                            else
                            {
                                strdata.Append(strval + ",");
                            }
                            strfild.Append("[" + colname + "],");
                        }

                    }
                    strfild.DelLastComma();
                    strdata.DelLastComma();
                    //导出数据INSERT语句
                    strclass.Append("INSERT [" + tablename + "] (");
                    strclass.Append(strfild.Value);
                    strclass.Append(") VALUES ( ");
                    strclass.Append(strdata.Value);//数据值
                    strclass.AppendLine(")");
                }
            }
            if (IsIden)
            {
                strclass.AppendLine("");
                strclass.AppendLine("SET IDENTITY_INSERT [" + tablename + "] OFF");
            }

            return strclass.Value;

        }
        */
    }
}
