using System;
using System.Collections;

/**
 * 作者：陈杰
 * QQ  : 710782046
 * Email:ovenjackchain@gmail.com
 * Web :http://yj.ChinaCloudTech.com
 */

namespace Model
{
    [TABLE(Name = "WMS_ROLEFUN", AutoID = "pid")]
    public class WMS_ROLEFUN
    {
        #region 构造函数
        public WMS_ROLEFUN()
        { }
        #endregion

        #region 属性
        public int pid
        {
            get;
            set;
        }

        public int roleid
        {
            get;
            set;
        }

        public int funid
        {
            get;
            set;
        }

        #endregion

    }
}