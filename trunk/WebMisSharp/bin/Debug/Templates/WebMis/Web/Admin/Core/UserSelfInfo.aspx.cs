using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tools;
using Ext.Net;
using Model;
using BLL;

namespace Web.Admin.Core
{
    public partial class UserSelfInfo : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            if (CookieHelper.GetCookie("username") == null || CookieHelper.GetCookie("role") == null)
                Response.Redirect("/Admin/Login.aspx");
            if (!IsPostBack)
                InfoBind();
        }
        protected void InfoBind()
        {
            WMS_USERINFO user =(new userinfoMgr()).FindById_userinfo(CookieHelper.GetCookie("username"));
            if (user != null)
            {
                TxtUserName.Text = user.username;
                TxtTel.Text = user.telephone;
                TxtEmail.Text = user.email;
                Txtuserdept.Text = user.userdept;
                Txtusernamec.Text = user.cn_name;
                cboSex.Value = user.usersex;
                TxtAddress.Text = user.address;
            }
        }
        //保存用户
        protected void BtnSave_Click(object sender, DirectEventArgs e)
        {
            WMS_USERINFO user = (new userinfoMgr()).FindById_userinfo(CookieHelper.GetCookie("username"));
            user.usersex = cboSex.SelectedItem.Text;
            user.telephone = TxtTel.Text.Trim();
            user.email = TxtEmail.Text.Trim();
            user.address = TxtAddress.Text.Trim();
            user.cn_name = Txtusernamec.Text.Trim();
            user.userdept = Txtuserdept.Text.Trim();
            if (WMSFactory.WMS_USERINFO.Update(user))
                MsgBox.NotifiShow("用户修改成功！", "OK");
            else
                MsgBox.MessageShow("用户修改失败，请重试！", "ERROR");
        }

    }
}