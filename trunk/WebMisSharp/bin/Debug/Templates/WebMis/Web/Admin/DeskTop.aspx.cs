using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Model;
using BLL;
using Tools;
using System.IO;

namespace Web.Admin
{
    public partial class DeskTop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CookieHelper.GetCookie("username") == null || CookieHelper.GetCookie("role") == null)
                Response.Redirect("Login.aspx");
            if (!X.IsAjaxRequest)
                DeskTopICON();
        }
        private void DeskTopICON()
        {
            rolefunMgr mgr=new rolefunMgr();
            IList<WMS_USERFUN> list = mgr.FindWMS_ROLEFUN(Tools.CookieHelper.GetCookie("role"));
            foreach (WMS_USERFUN fun in list)
            {
                if (fun.fatherid == 0) continue;
                DesktopShortcut cut = new DesktopShortcut();
                cut.Text = fun.funname;
                cut.ShortcutID = fun.funno+"|"+fun.funname;
                if(File.Exists(Server.MapPath("images/menu/"+fun.funid.ToString()+".png")))
                    cut.IconCls = "shortcut-icon icon-"+fun.funid.ToString();
                else
                    cut.IconCls = "shortcut-icon icon-none";
                MyDesktop.Shortcuts.Add(cut);
            }
        }
        //退出系统
        protected void BtnExit_Click(object sender, DirectEventArgs e)
        {
            CookieHelper.ClearCookie("username");
            CookieHelper.ClearCookie("role");
            Response.Redirect("Login.aspx");
        }
    }
}