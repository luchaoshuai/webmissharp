using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using BLL;
using Model;
using Tools;

namespace Web.Admin.Core
{
    public partial class UserMgr : WMS_UI
    {
        //信息绑定
        protected void InfoBind(object sender, StoreRefreshDataEventArgs e)
        {
            string conditions = "";
            if (TxtKeys.Text.Trim().Length > 0)
                conditions = string.Format("username like '%{0}%' or cn_name like '%{0}%'", Server.HtmlEncode(TxtKeys.Text.Trim().Replace("'", "")));
            e.Total = int.Parse(WMSFactory.WMS_USERINFO.GetTotalCount("", conditions));
            IList<WMS_USERINFO> list = WMSFactory.WMS_USERINFO.FindAllByPage(e.Start, e.Limit, 11, "", conditions);
            USER_Store.DataSource = list;
            USER_Store.DataBind();
        }
        //获取所有角色，与用户角色ID做映射
        protected void GetAllRoles(object sender, StoreRefreshDataEventArgs e)
        {
            S_Roles.DataSource = WMSFactory.WMS_ROLES.FindAll();
            S_Roles.DataBind();
        }

        //重置选中用户密码
        protected void BtnResetPwd_Click(object sender, DirectEventArgs e)
        {
            if (Hid.Text.Length <= 0)
            {
                MsgBox.MessageShow("请选择要重置密码的用户", "WARNING"); return;
            }
            WMS_USERINFO user = WMSFactory.WMS_USERINFO.FindById(Hid.Text);
            user.password = CJ_DBOperater.CJ.PwdSecurity("123456");
            if (WMSFactory.WMS_USERINFO.Update(user))
            {
                WinUser.Hide();
                MsgBox.NotifiShow("用户密码重置成功，重置密码为123456", "OK");
                USERINFO_Grid.Reload();
            }
            else
                MsgBox.MessageShow("用户密码重置失败，请重试", "ERROR");
        }
        //删除用户
        protected void BtnDel_Click(object sender, DirectEventArgs e)
        {
            int Success = 0, Failed = 0;
            RowSelectionModel sm = this.USERINFO_Grid.SelectionModel.Primary as RowSelectionModel;
            foreach (SelectedRow row in sm.SelectedRows)
            {
                WMS_USERINFO user = WMSFactory.WMS_USERINFO.FindById(row.RecordID);
                if (user.username == CookieHelper.GetCookie("username"))
                {
                    MsgBox.MessageShow("系统不允许删除当前登录用户！", "ERROR");
                    continue;
                }
                if (WMSFactory.WMS_USERINFO.Del(user))
                    Success++;
                else
                    Failed++;
            }
            MsgBox.NotifiShow("成功执行了删除，成功删除" + Success.ToString() + "条记录，失败" + Failed.ToString() + "条！", "OK");
            USERINFO_Grid.Reload();
        }
        //保存用户
        protected void BtnSave_Click(object sender, DirectEventArgs e)
        {
            WMS_USERINFO user = new WMS_USERINFO();
            if (Hid.Text.Length > 0)
                user = WMSFactory.WMS_USERINFO.FindById(Hid.Text);
            user.username = TxtUserName.Text;
            user.usersex = cboSex.SelectedItem.Text;
            user.roleid = int.Parse(cboRole.SelectedItem.Value);
            user.telephone = TxtTel.Text.Trim();
            user.email = TxtEmail.Text.Trim();
            user.address = TxtAddress.Text.Trim();
            user.cn_name = Txtusernamec.Text.Trim();
            user.userdept = Txtuserdept.Text.Trim();
            user.password = CJ_DBOperater.CJ.PwdSecurity("123456");
            user.logintime = DateTime.Now.ToString();
            user.createtime = DateTime.Now.ToString();
            if (Hid.Text.Length > 0)
            {
                if (WMSFactory.WMS_USERINFO.Update(user))
                    MsgBox.NotifiShow("恭喜您，用户信息更新成功！", "OK");
                else
                    MsgBox.MessageShow("用户信息更新失败，请重试！", "ERROR");
            }
            else
            {
                if (WMSFactory.WMS_USERINFO.FindByCondition("username='" + TxtUserName.Text.Trim() + "'").Count > 0)
                {
                    MsgBox.MessageShow("该用户已存在，请使用其他用户名！", "WARNING");
                    return;
                }
                if (WMSFactory.WMS_USERINFO.Add(user))
                    MsgBox.NotifiShow("用户添加成功，默认密码123456！", "OK");
                else
                    MsgBox.MessageShow("用户添加失败，请重试！", "ERROR");

            }
            WinUser.Hide();
            USERINFO_Grid.Reload();
        }
    }
}