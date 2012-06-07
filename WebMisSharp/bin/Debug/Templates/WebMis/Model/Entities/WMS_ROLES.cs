using System;
using System.Collections;
using System.ComponentModel;
using Model;


/**
 * 作者：陈杰
 * QQ  : 710782046
 * Email:ovenjackchain@gmail.com
 * Web :http://yj.ChinaCloudTech.com
 */
namespace Model
{
    [TABLE(Name = "WMS_ROLES", AutoID = "roleid")]
    public class WMS_ROLES
    {
        #region 构造函数
        public WMS_ROLES()
        { }
        #endregion

        #region 属性
        public int roleid
        {
            get;
            set;
        }
        
        public string rolename
        {
            get;
            set;
        }

        public string remark
        {
            get;
            set;
        }

        #endregion
    }
}
