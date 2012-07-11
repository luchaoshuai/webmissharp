using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tools;
using Ext.Net;
using BLL;
using Model;

namespace Web.Admin
{
    public partial class Default : System.Web.UI.Page
    {
        WMS_Mgr<WMS_USERINFO> mgr = new WMS_Mgr<WMS_USERINFO>();
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            if (CookieHelper.GetCookie("username") == null || CookieHelper.GetCookie("role") == null)
                Response.Redirect("Login.aspx");
            if (!IsPostBack)
                ThemeChange();
        }
        //登录
        protected void BtnSave_Click(object sender, DirectEventArgs e)
        {
            if (TxtNewPwd.Text.Trim().Length <= 0 || TxtOldPwd.Text.Trim().Length <= 0)
            {
                MsgBox.MessageShow("信息不完整！", "ERROR");
                return;
            }
            if (TxtSurePwd.Text != TxtNewPwd.Text)
            { MsgBox.MessageShow("两次新密码输入不一致！", "ERROR"); return; }
            userinfoMgr userinfoMgr = new userinfoMgr();
            WMS_USERINFO user = userinfoMgr.FindById_userinfo(CookieHelper.GetCookie("username"));
            //Md5+盐值加密算法，相对安全
            if (user != null && user.password.Trim() == CJ_DBOperater.CJ.PwdSecurity(Server.UrlEncode(this.TxtOldPwd.Text.Trim().Replace("'", ""))))
            {
                user.password = CJ_DBOperater.CJ.PwdSecurity(Server.UrlEncode(this.TxtSurePwd.Text.Trim().Replace("'", "")));
                if (mgr.Update(user))
                {
                    MsgBox.MessageShow("密码修改成功，请重新登录系统！", "INFO");
                    Response.Redirect("Login.aspx");
                    return;
                }
                MsgBox.MessageShow("密码修改失败，请重试！", "ERROR");
            }
            else
                MsgBox.MessageShow("旧密码错误，请重新输入！", "ERROR");
        }
        //退出系统
        protected void BtnExit_Click(object sender, DirectEventArgs e)
        {
	    CookieHelper.ClearCookie(CookieHelper.GetCookie("username"));
            CookieHelper.ClearCookie("username");
            CookieHelper.ClearCookie("role");
            Response.Redirect("Login.aspx");
        }
        /// <summary>
        /// 获取用户角色功能菜单树
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GetExamplesNodes(object sender, NodeLoadEventArgs e)
        {
            if (e.NodeID == "root")
            {
                rolefunMgr rolefunMgr = new rolefunMgr();
                if (CookieHelper.GetCookie("role") != null && CookieHelper.GetCookie("role").Trim().Length > 0)
                    e.Nodes = rolefunMgr.GetMenu(CookieHelper.GetCookie("role"));
            }
        }

        protected void AddNode2Favorite_Click(object sender, DirectEventArgs e)
        {
            string NodeId = e.ExtraParams["NODEID"].ToString();
            WMS_FAVORITES Fav = new WMS_FAVORITES();
            Fav.Funid = int.Parse(NodeId);
            Fav.UserId = CookieHelper.GetCookie("username");
            Fav.CreateDate = DateTime.Now.ToString();
            if (WMSFactory.WMS_FAVORITES.Add(Fav))
            {
                X.AddScript("Home.loadIFrame({ url: 'Welcome.aspx' });");
                MsgBox.NotifiShow("恭喜您，添加成功！", "OK");
            }
            else
                MsgBox.MessageShow("收藏夹添加失败，请检查是否已存在！", "ERROR");
        }

        //保存皮肤到cookie
        protected void cbTheme_changed(object sender, DirectEventArgs e)
        {
            Response.Cookies["theme"].Value = cbTheme.SelectedItem.Value.ToString();
            Response.Cookies["theme"].Expires = DateTime.Now.AddDays(100d);
            Response.Redirect(Request.Url.ToString());
        }
        /// <summary>
        /// 皮肤切换后保存到cookie中，下次登录加载皮肤
        /// </summary>
        private void ThemeChange()
        {
            if (Request.Cookies["theme"] != null)
            {
                switch (Request.Cookies["theme"].Value)
                {
                    case "gray":
                        HttpContext.Current.Session["Ext.net.Theme"] = Ext.Net.Theme.Gray;
                        cbTheme.SetValue("gray");
                        break;
                    case "access":
                        HttpContext.Current.Session["Ext.net.Theme"] = Ext.Net.Theme.Access;
                        cbTheme.SetValue("access");
                        break;
                    case "slate":
                        HttpContext.Current.Session["Ext.net.Theme"] = Ext.Net.Theme.Slate;
                        cbTheme.SetValue("slate");
                        break;
                    default:
                        HttpContext.Current.Session["Ext.net.Theme"] = Ext.Net.Theme.Default;
                        cbTheme.SetValue("default");
                        break;
                }
            }
            if (CookieHelper.GetCookie("username") != null)
            {
                this.Lbname.Html = "当前用户：" + CookieHelper.GetCookie("username") + "--" + CookieHelper.GetCookie("cn_name");
            }
        }
    }
}