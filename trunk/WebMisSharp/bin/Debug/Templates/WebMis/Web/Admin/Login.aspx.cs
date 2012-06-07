using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using Tools;
using Ext.Net;

namespace Web.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        MsgBox mb = new MsgBox();
        protected void ImgBtnLogin_Click(object sender, ImageClickEventArgs e)
        {
            if (TxtUserName.Text.Trim().Length <= 0 || TxtPwd.Text.Trim().Length <= 0)
                MessageBoxHelper.ResponseScript(this,"ZENG.msgbox.show('用户名和密码不能为空！', 1, 1500);");
            else
            {
                userinfoMgr userinfoMgr = new userinfoMgr();
                WMS_USERINFO user = userinfoMgr.FindById_userinfo(Server.HtmlEncode(TxtUserName.Text.Trim().Replace("'", "")));
                //Md5+盐值加密算法，相对安全
                if (user != null && user.password.Trim() == CJ_DBOperater.CJ.PwdSecurity(TxtPwd.Text.Trim()))
                {
                    CookieHelper.SaveCookie("username", user.username, 0);
                    CookieHelper.SaveCookie("cn_name", user.cn_name, 0);
                    CookieHelper.SaveCookie("role", user.roleid.ToString(), 0);
                    user.logintime = DateTime.Now.ToString();
                    userinfoMgr.Update_userinfo(user);//记录用户当前登录时间
                    Response.Redirect("/Admin");
                }
                else
                    MessageBoxHelper.ResponseScript(this, "ZENG.msgbox.show('用户名或密码错误！', 5, 1500);");
            }
        }
    }
}