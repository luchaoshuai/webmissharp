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
using System.Data;

namespace Web.Admin.Core
{
    public partial class Favorite : WMS_UI
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //绑定Grid
        protected void WMS_FAVORITES_DataBind(object sender, StoreRefreshDataEventArgs e)
        {
            rolefunMgr mgr = new rolefunMgr();
            DataTable dt = mgr.FindFavoriteFun(CookieHelper.GetCookie("username"));
            WMS_FAVORITES_MainStore.DataSource = dt;
            WMS_FAVORITES_MainStore.DataBind();
        }
        //删除数据
        protected void BtnDel_Click(object sender, DirectEventArgs e)
        {
            int Success = 0, Failed = 0;
            RowSelectionModel sm = WMS_FAVORITES_Grid.SelectionModel.Primary as RowSelectionModel;
            foreach (SelectedRow row in sm.SelectedRows)
            {
                WMS_FAVORITES _WMS_FAVORITES = new WMS_FAVORITES();
                _WMS_FAVORITES.Fid = int.Parse(row.RecordID);
                if (WMSFactory.WMS_FAVORITES.Del(_WMS_FAVORITES)) Success++;
                else Failed++;
            }
            if (Failed > 0)
                MsgBox.MessageShow("删除操作完成，成功" + Success.ToString() + "条，失败" + Failed.ToString() + "条！", "OK");
            else
                MsgBox.NotifiShow("删除操作完成，成功" + Success.ToString() + "条，失败" + Failed.ToString() + "条！", "OK");
            WMS_FAVORITES_Grid.Reload();
        }
    }
}