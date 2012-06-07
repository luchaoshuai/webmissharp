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

namespace Web.Admin
{
    public partial class FunsMgr : WMS_UI
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
			if (!X.IsAjaxRequest)
            {

			}
        }

        //绑定Grid
        protected void WMS_USERFUN_DataBind(object sender, StoreRefreshDataEventArgs e)
        {
            e.Total = int.Parse(WMSFactory.WMS_USERFUN.GetTotalCount(e.Parameters[WMS_USERFUN_Filter.ParamPrefix], ""));
            IList<WMS_USERFUN> list = WMSFactory.WMS_USERFUN.FindAllByPage(e.Start, e.Limit, 11, e.Parameters[WMS_USERFUN_Filter.ParamPrefix], "");
            WMS_USERFUN_MainStore.DataSource = list;
            WMS_USERFUN_MainStore.DataBind();
        }
        //删除数据
        protected void BtnDel_Click(object sender, DirectEventArgs e)
        {
            int Success = 0, Failed = 0;
            RowSelectionModel sm = WMS_USERFUN_Grid.SelectionModel.Primary as RowSelectionModel;
            foreach (SelectedRow row in sm.SelectedRows)
            {
                WMS_USERFUN _WMS_USERFUN = new WMS_USERFUN();
                _WMS_USERFUN.funid = int.Parse(row.RecordID);
                if (WMSFactory.WMS_USERFUN.Del(_WMS_USERFUN))
                {
                    WMSFactory.WMS_ROLEFUN.DelByConditions("funid=" + row.RecordID);
                    Success++;
                }
                else Failed++;
            }
            WMS_USERFUN_Grid.Reload();
            if (Failed > 0)
                MsgBox.MessageShow("删除操作完成，成功" + Success.ToString() + "条，失败" + Failed.ToString() + "条！", "OK");
            else
                MsgBox.NotifiShow("删除操作完成，成功" + Success.ToString() + "条，失败" + Failed.ToString() + "条！", "OK");
        }
        protected void BtnSave_Click(object sender, DirectEventArgs e)
        {
            WMS_USERFUN _WMS_USERFUN = new WMS_USERFUN();
            _WMS_USERFUN.funid = int.Parse(NFfunid.Text);
            _WMS_USERFUN.funno = Txtfunno.Text; //功能链接
            _WMS_USERFUN.funname = Txtfunname.Text; //功能名称
            _WMS_USERFUN.fatherid = int.Parse(NFfatherid.Text); //父节点
            rolefunMgr mgr=new rolefunMgr();
            if (mgr.FunAddorUpdate(_WMS_USERFUN, Hid.Text))
            {
                WMS_USERFUN_Grid.Reload();
                MsgBox.NotifiShow("功能权限保存成功！", "OK");
            }
            else
                MsgBox.MessageShow("功能权限保存失败，请检查节点ID是否重复！", "ERROR");
        }
    }
}