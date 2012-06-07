using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using Ext.Net;
using Tools;
using System.Data;

namespace Web.Admin
{
    public partial class Welcome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CookieHelper.GetCookie("username") == null || CookieHelper.GetCookie("role") == null)
                Response.Redirect("Error.htm");
            if (!X.IsAjaxRequest)
            { NoticeBind(); GetFunction(); }
            //这里涉及到权限
        }

        private void NoticeBind()
        {
            Notice_Store.DataSource = WMSFactory.WMS_NOTICE.FindAllByPage(0, 8, 11, "", "nreceiver='ALL' or nreceiver like '%" + CookieHelper.GetCookie("username") + ",%'");
            Notice_Store.DataBind();
        }

        private void GetFunction()
        {
            rolefunMgr mgr = new rolefunMgr();
            DataTable dt = mgr.FindFavoriteFun(CookieHelper.GetCookie("username"));
            List<object> data = new List<object>();
            List<object> temp = new List<object>();
            foreach (DataRow dr in dt.Rows)
            {
                temp.Add(new
                {
                    Funid = dr[0].ToString(),
                    Funno = dr[1].ToString(),
                    Funname = dr[2].ToString()
                });
            }
            data.Add(new { FunGroup = "功能收藏夹", FunItems = temp });
            Favorite_Store.DataSource = data;
            Favorite_Store.DataBind();
        }

        protected void DelFavorite(object sender, DirectEventArgs e)
        {
            WMSFactory.WMS_FAVORITES.DelByConditions("Funid=" + e.ExtraParams["FUNID"].ToString() + " and UserId='" + CookieHelper.GetCookie("username") + "'");
            GetFunction();
        }
    }
}