using BaseLibs;
using StaticConfigure;
using System;
using System.Collections.Generic;
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

        //更新webconfig的数据库连接串
        public static void UpdateDbConnectStr(string ProName)
        {
            string Path = XMLHelper.Read(XMLPaths.ProjectXml, "/Root/Project[@Name='" + ProName + "']/Path", "") + "\\ElegantWM.WebUI\\Web.config";
            string DBConStr = XMLHelper.Read(XMLPaths.ProjectXml, "/Root/Project[@Name='" + ProName + "']/DBConStr", "");
            FileHelper.WriteFile(Path, FileHelper.ReadFile(Path).Replace("{DBCONNECTSTRING}", DBConStr));
        }
    }
}
