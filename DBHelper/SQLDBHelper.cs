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
        //获取所有的表、视图、存储过程
        public static DataTable GetTableViewProc(string ProName)
        {
            //ORACLE,和SQLSERVER区别
            //TO DO
            CJ_DevelopHelper.SqlConn_Str=XMLHelper.Read(XMLPaths.ProjectXml, "/Root/Project[@Name='" + ProName + "']/DBConStr", "");
            CJ_DevelopHelper.SqlStr = SQLCmds.S_GETTables;
            return CJ_DevelopHelper.SQL_ReturnDateTable;
        }
        //获取所有的表、视图,供Combox下拉store使用
        public static DataTable GetTableView(string ProName)
        {
            //ORACLE,和SQLSERVER区别
            //TO DO
            CJ_DevelopHelper.SqlConn_Str = XMLHelper.Read(XMLPaths.ProjectXml, "/Root/Project[@Name='" + ProName + "']/DBConStr", "");
            CJ_DevelopHelper.SqlStr = SQLCmds.S_GETTableAndViews;
            return CJ_DevelopHelper.SQL_ReturnDateTable;
        }
        public static DataTable GetTableViewStruct(string ProName, string TableName)
        {
            CJ_DevelopHelper.SqlConn_Str = XMLHelper.Read(XMLPaths.ProjectXml, "/Root/Project[@Name='" + ProName + "']/DBConStr", "");
            CJ_DevelopHelper.SqlStr = String.Format(SQLCmds.S_GETTableViewStruct, TableName);
            return CJ_DevelopHelper.SQL_ReturnDateTable;
        }
        //获取数据库名称
        public static string GetDBName(string ProName)
        {
            //ORACLE,和SQLSERVER区别
            //TO DO
            CJ_DevelopHelper.SqlConn_Str = XMLHelper.Read(XMLPaths.ProjectXml, "/Root/Project[@Name='" + ProName + "']/DBConStr", "");
            CJ_DevelopHelper.SqlStr = SQLCmds.S_GETDBName;
            return CJ_DevelopHelper.SQL_ReturnDateTable.Rows[0][0].ToString();
        }
        //获取数据库的基本属性
        public static DataTable GetDBBasicInfo(string ProName)
        {
            CJ_DevelopHelper.SqlConn_Str = XMLHelper.Read(XMLPaths.ProjectXml, "/Root/Project[@Name='" + ProName + "']/DBConStr", "");
            CJ_DevelopHelper.SqlStr = SQLCmds.S_GETDBBasic;
            return CJ_DevelopHelper.SQL_ReturnDateTable;
        }
        //获取数据库文件信息
        public static DataTable GetDBFilesInfo(string ProName)
        {
            CJ_DevelopHelper.SqlConn_Str = XMLHelper.Read(XMLPaths.ProjectXml, "/Root/Project[@Name='" + ProName + "']/DBConStr", "");
            CJ_DevelopHelper.SqlStr = SQLCmds.S_GETDBFiles;
            return CJ_DevelopHelper.SQL_ReturnDateTable;
        }
        //获取P V U的数量
        public static DataTable GetUVPcount(string ProName)
        {
            CJ_DevelopHelper.SqlConn_Str = XMLHelper.Read(XMLPaths.ProjectXml, "/Root/Project[@Name='" + ProName + "']/DBConStr", "");
            CJ_DevelopHelper.SqlStr = SQLCmds.S_GETPVUcount;
            return CJ_DevelopHelper.SQL_ReturnDateTable;
        }
        //获取表的基本信息
        public static DataTable GetTableBasic(string ProName, string TableName)
        {
            CJ_DevelopHelper.SqlConn_Str = XMLHelper.Read(XMLPaths.ProjectXml, "/Root/Project[@Name='" + ProName + "']/DBConStr", "");
            CJ_DevelopHelper.SqlStr = String.Format(SQLCmds.S_GETTableBasic, TableName);
            return CJ_DevelopHelper.SQL_ReturnDateTable;
        }
        //获取表的大小信息
        public static DataTable GetTableSize(string ProName, string TableName)
        {
            SqlParameter[] parameters = {new SqlParameter("@objname",SqlDbType.NVarChar,776)};
            parameters[0].Value = TableName;
            return RunProc(
                 XMLHelper.Read(XMLPaths.ProjectXml, "/Root/Project[@Name='" + ProName + "']/DBConStr", ""),
                 "sys.sp_spaceused",
                 parameters);
        }
        //获取表的结构
        public static DataTable GetTableStructs(string ProName, string TableName)
        {
            CJ_DevelopHelper.SqlConn_Str = XMLHelper.Read(XMLPaths.ProjectXml, "/Root/Project[@Name='" + ProName + "']/DBConStr", "");
            CJ_DevelopHelper.SqlStr = String.Format(SQLCmds.S_GETTableStruct, TableName);
            return CJ_DevelopHelper.SQL_ReturnDateTable;
        }

        //更新表字段备注信息
        public static void SetTableFieldRemark(string ProName,string Tid,string Cid, string TableName, string FieldName, string Remark)
        {
            CJ_DevelopHelper.SqlConn_Str = XMLHelper.Read(XMLPaths.ProjectXml, "/Root/Project[@Name='" + ProName + "']/DBConStr", "");
            CJ_DevelopHelper.SqlStr = String.Format(SQLCmds.S_SETFieldRemark, Tid, Cid, TableName, FieldName, Remark);
            int result=CJ_DevelopHelper.SQL_ExecuteNonQuery;
        }

        private static DataTable RunProc(string connStr,string ProcName, IDataParameter[] para)
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
    }
}
