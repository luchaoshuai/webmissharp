using Model;

/*
 * 陈杰 JackChain
 * QQ:710782046
 * Email:ovenjackchain@gmail.com
 * Web:http://yj.ChinaCloudTech.com
 */
namespace BLL
{
    public class WMSFactory
    {
        #region 系统
        public static WMS_Mgr<WMS_NOTICE> WMS_NOTICE { get { return new WMS_Mgr<WMS_NOTICE>(); } }
        public static WMS_Mgr<WMS_FAVORITES> WMS_FAVORITES { get { return new WMS_Mgr<WMS_FAVORITES>(); } }
        public static WMS_Mgr<WMS_USERINFO> WMS_USERINFO { get { return new WMS_Mgr<WMS_USERINFO>(); } }
        public static WMS_Mgr<WMS_ROLES> WMS_ROLES { get { return new WMS_Mgr<WMS_ROLES>(); } }
        public static WMS_Mgr<WMS_ROLEFUN> WMS_ROLEFUN { get { return new WMS_Mgr<WMS_ROLEFUN>(); } }
        public static WMS_Mgr<WMS_USERFUN> WMS_USERFUN { get { return new WMS_Mgr<WMS_USERFUN>(); } }
        #endregion

        /*WMSPOINT*/
    }
}
