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
    [TABLE(Name = "WMS_USERINFO", AutoID = "userid")]
    public class WMS_USERINFO
    {
        #region 构造函数
        public WMS_USERINFO()
        { }
        #endregion

        #region 属性
        public int userid
        {
            get;
            set;
        }

        public string username
        {
            get;
            set;
        }

        public string cn_name
        {
            get;
            set;
        }


        public string userdept
        {
            get;
            set;
        }

        public string password
        {
            get;
            set;
        }

        public int roleid
        {
            get;
            set;
        }

        public string telephone
        {
            get;
            set;
        }

        public string usersex
        {
            get;
            set;
        }

        public string address
        {
            get;
            set;
        }

        public string email
        {
            get;
            set;
        }

        public string logintime
        {
            get;
            set;
        }

        public string createtime
        {
            get;
            set;
        }

        #endregion

    }
}
