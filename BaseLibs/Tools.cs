using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BaseLibs;
using BaseLibs;

namespace BaseLibs
{
    public class Tools
    {
        //获取项目的Path
        public static string GetPath(string ProjectName)
        {
            return XMLHelper.Read(XMLPaths.ProjectXml, "/Root/Project[@Name='" + ProjectName + "']/Path", "");
        }

        private static string ReadConfig(string str,string tablename)
        {
            string result = "";
            //读取配置表
            DataSet ds = new DataSet();
            ds.ReadXml(XMLPaths.DBTypeXml);
            DataTable TypeDt = ds.Tables[tablename];
            StringBuilder sb = new StringBuilder();

            try
            {
                result = TypeDt.Select("key='" + str + "'")[0][1].ToString();

            }
            catch (Exception)
            {

            }
            return result;
        }

        public static  bool IsAddMark(string colType)
        {
            bool result = false;
            string IsTrue = "";
            try
            {
                IsTrue = ReadConfig(colType, "AddMark");
                if (IsTrue.Length > 0)
                    result =  true;
            }
            catch (Exception)
            {
                
            }
            return result;
        }

        public static string DbTypeToCS(string colType)
        {
            return ReadConfig(colType, "DbToCS");
        }
    }
}
