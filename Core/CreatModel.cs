using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BaseLibs;

namespace Core
{
    public class CreatModel
    {
        //生成Model
        public static string CreateModelContent(DataTable dt)
        {
            //读取配置表
            DataSet ds = new DataSet();
            ds.ReadXml(XMLPaths.DBTypeXml);
            DataTable TypeDt = ds.Tables["SQLSERVER2008"];

            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr in dt.Rows)
            {
                sb.AppendLine("\t\t/// <summary>");
                sb.AppendLine("\t\t/// " + dr["说明"].ToString());
                sb.AppendLine("\t\t/// </summary>");
                string CSharpType = TypeDt.Select("key='" + dr["字段类型"].ToString() + "'")[0][1].ToString();
                sb.AppendLine("\t\tpublic " + CSharpType + " " + dr["字段名"].ToString() + " { get; set; }");
                sb.AppendLine("\t\t");
            }
            return sb.ToString();
        }

        public static string WriteModelFile(string ModelContent, string TableName, string ModelName, string AutoID, string Path)
        {
            try
            {
                string ModelCSProj = FileHelper.ReadFile(Path + "\\Model\\Model.csproj");
                //if (!ModelCSProj.Contains("Entities\\" + ModelName + ".cs"))
                //{
                    string ModelTemplate = FileHelper.ReadFile(".\\Templates\\Model.cs");
                    ModelTemplate = ModelTemplate.Replace("{0}", ModelName).Replace("{1}", AutoID).Replace("{2}", ModelContent);
                    FileHelper.WriteFile(Path + "\\Model\\" + ModelName + ".cs", ModelTemplate);
                    //FileHelper.WriteFile(Path + "\\Model\\Model.csproj", ModelCSProj.Replace("<!--MODELPOINT-->", "<Compile Include=\"Entities\\" + ModelName + ".cs\" />\r\n\t<!--MODELPOINT-->"));
                //}
                return "Model创建成功";
            }
            catch (Exception error)
            {
                return "ERROR：Model生成错误-" + error.Message;
            }
        }
    }
}
