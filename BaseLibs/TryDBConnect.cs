using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.OracleClient;
using System.Data;

namespace BaseLibs
{
    public class TryDBConnect
    {
        //SQLServer测试连接状态
        public static bool TryMSSQLConnect(string ConStr)
        {
            SqlConnection con = new SqlConnection("Connect Timeout=30;"+ConStr);
            try
            {
                con.Open();
                return true;
            }
            catch { return false; }
            finally { con.Close(); 
            }
        }
        //ORACLE测试连接状态
        public static bool TryOracleConnect(string ConStr)
        {
            OracleConnection con = new OracleConnection(ConStr);
            try
            {
                con.Open();
                return true;
            }
            catch { return false; }
            finally { con.Close(); }
        }
    }
}
