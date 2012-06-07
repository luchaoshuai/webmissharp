using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using Model;
using Tools;

namespace Web
{
    public class WMS_UI : System.Web.UI.Page
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected override void OnPreInit(EventArgs e)
        {
            if (!IsPostBack)
            {
                if (CookieHelper.GetCookie("username") == null || CookieHelper.GetCookie("role") == null)
                    Response.Redirect("~/Admin/Error.htm");
                rolefunMgr mgr = new rolefunMgr();
                List<WMS_AUTHORITY> power = new List<WMS_AUTHORITY>();
                if (CacheHelper.CacheValue(CookieHelper.GetCookie("username")) != null)
                    power = (List<WMS_AUTHORITY>)CacheHelper.CacheValue(CookieHelper.GetCookie("username"));
                else
                {
                    power = mgr.FindAuthFun(CookieHelper.GetCookie("role"));
                    CacheHelper.CacheInsertAddMinutes(CookieHelper.GetCookie("username"), power, 20);
                }
                //判断角色是否能访问该文件
                string currenturl = Request.RawUrl;
                log.Debug("来自IP" + Request.UserHostAddress + "的用户" + CookieHelper.GetCookie("username") + "正在访问:" + currenturl + "页面");
                WMS_AUTHORITY auth = power.Find(delegate(WMS_AUTHORITY fun) { return currenturl.Contains(fun.funno); });
                if (auth == null)
                {
                    log.Debug("访问权限被拒绝！！！");
                    Response.Redirect("~/Admin/Error.htm");
                }
                base.OnPreInit(e);
            }
        }

    }
}