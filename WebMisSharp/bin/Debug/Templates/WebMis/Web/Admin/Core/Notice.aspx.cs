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

namespace Web.Admin.Core
{
    public partial class Notice : WMS_UI
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                User_Store.DataSource = WMSFactory.WMS_USERINFO.FindAll();
                User_Store.DataBind();
            }
        }
        //绑定Grid
        protected void WMS_NOTICE_DataBind(object sender, StoreRefreshDataEventArgs e)
        {
            string conditions="nreceiver='ALL' or nreceiver like '%" + CookieHelper.GetCookie("username") + ",%'";
            if(CookieHelper.GetCookie("role")=="1") conditions="";
            e.Total = int.Parse(WMSFactory.WMS_NOTICE.GetTotalCount(e.Parameters[WMS_NOTICE_Filter.ParamPrefix], conditions));
            IList<WMS_NOTICE> list = WMSFactory.WMS_NOTICE.FindAllByPage(e.Start, e.Limit, 11, e.Parameters[WMS_NOTICE_Filter.ParamPrefix], conditions);
            WMS_NOTICE_MainStore.DataSource = list;
            WMS_NOTICE_MainStore.DataBind();
        }
        //删除数据
        protected void BtnDel_Click(object sender, DirectEventArgs e)
        {
            int Success = 0, Failed = 0;
            RowSelectionModel sm = WMS_NOTICE_Grid.SelectionModel.Primary as RowSelectionModel;
            foreach (SelectedRow row in sm.SelectedRows)
            {
                WMS_NOTICE _WMS_NOTICE = new WMS_NOTICE();
                _WMS_NOTICE.nid = int.Parse(row.RecordID);
                if (WMSFactory.WMS_NOTICE.Del(_WMS_NOTICE)) Success++;
                else Failed++;
            }
            WMS_NOTICE_Grid.Reload();
            if (Failed > 0)
                MsgBox.MessageShow("删除操作完成，成功" + Success.ToString() + "条，失败" + Failed.ToString() + "条！", "OK");
            else
                MsgBox.NotifiShow("删除操作完成，成功" + Success.ToString() + "条，失败" + Failed.ToString() + "条！", "OK");
        }
        protected void BtnSave_Click(object sender, DirectEventArgs e)
        {
            WMS_NOTICE _WMS_NOTICE = new WMS_NOTICE();
            if (Hid.Text.Length > 0)
            {
                _WMS_NOTICE = WMSFactory.WMS_NOTICE.FindById(Hid.Text);
                if (_WMS_NOTICE.nowner != CookieHelper.GetCookie("username"))
                {
                    MsgBox.MessageShow("您无权修改他人的通知公告！", "ERROR");
                    return;
                }
            }
            _WMS_NOTICE.ntitle = Txtntitle.Text.Trim();
            _WMS_NOTICE.ncontent = this.HtmlContent.Text.Trim();
            _WMS_NOTICE.ndate = DateTime.Now.ToString();
            _WMS_NOTICE.nowner = CookieHelper.GetCookie("username");
            _WMS_NOTICE.norigin = Txtnorigin.Text.Trim();
            _WMS_NOTICE.nreceiver = "";
            foreach (SelectedListItem i in Cbonreceiver.SelectedItems)
            {
                _WMS_NOTICE.nreceiver += i.Value + ",";
            }
            if (_WMS_NOTICE.nreceiver == "") _WMS_NOTICE.nreceiver = "ALL";
            bool isok = false;
            if (Hid.Text.Length > 0)
                isok = WMSFactory.WMS_NOTICE.Update(_WMS_NOTICE);
            else
                isok = WMSFactory.WMS_NOTICE.Add(_WMS_NOTICE);
            if (isok)
            {
                WMS_NOTICE_Win.Hide();
                WMS_NOTICE_Grid.Reload();
                MsgBox.NotifiShow("恭喜您，操作成功！", "OK");
            }
            else
                MsgBox.MessageShow("操作失败，请您重试！", "ERROR");
        }
    }
}