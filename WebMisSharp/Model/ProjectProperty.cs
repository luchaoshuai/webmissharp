using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace WebMisSharp
{
    public class ProjectProperty
    {
        [CategoryAttribute("基本属性"), ReadOnly(true), DescriptionAttribute("项目名称")]
        public string ProName
        {
            get;
            set;
        }
        [CategoryAttribute("基本属性"), ReadOnly(true), DescriptionAttribute("数据库类型")]
        public string DBType
        {
            get;
            set;
        }

        [CategoryAttribute("基本属性"), DescriptionAttribute("数据库连接串")]
        public string DBConStr
        {
            get;
            set;
        }
        [CategoryAttribute("基本属性"), DescriptionAttribute("项目的生成路径")]
        public string Path
        {
            get;
            set;
        }

        [CategoryAttribute("基本属性"), ReadOnly(true), DescriptionAttribute("项目所采用的架构")]
        public string Structure
        {
            get;
            set;
        }

    }
}
