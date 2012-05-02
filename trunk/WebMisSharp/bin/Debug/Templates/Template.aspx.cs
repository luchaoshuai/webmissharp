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
/**
 * 作者：陈杰
 * QQ  : 710782046
 * Email:ovenjackchain@gmail.com
 * Web :http://yj.ChinaCloudTech.com
 */
namespace Web.Admin
{
    public partial class Template : WMS_UI
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
			if (!X.IsAjaxRequest)
            {
//{CBOBIND}
			}
        }
//{CBOBINDFun}
        //绑定Grid
        protected void {TABLENAME}_DataBind(object sender, StoreRefreshDataEventArgs e)
        {
            e.Total = int.Parse(WMSFactory.{TABLENAME}.GetTotalCount(e.Parameters[{TABLENAME}_Filter.ParamPrefix], ""));
            IList<{TABLENAME}> list = WMSFactory.{TABLENAME}.FindAllByPage(e.Start, e.Limit, 11, e.Parameters[{TABLENAME}_Filter.ParamPrefix], "");
            {TABLENAME}_MainStore.DataSource = list;
            {TABLENAME}_MainStore.DataBind();
        }
        //删除数据
        protected void BtnDel_Click(object sender, DirectEventArgs e)
        {
            int Success = 0, Failed = 0;
            RowSelectionModel sm = {TABLENAME}_Grid.SelectionModel.Primary as RowSelectionModel;
            foreach (SelectedRow row in sm.SelectedRows)
            {
                {TABLENAME} _{TABLENAME} = new {TABLENAME}();
                _{TABLENAME}.{AutoID} = int.Parse(row.RecordID);
                if (WMSFactory.{TABLENAME}.Del(_{TABLENAME})) Success++;
                else Failed++;
            }
            {TABLENAME}_Grid.Reload();
            if (Failed > 0)
                MsgBox.MessageShow("删除操作完成，成功" + Success.ToString() + "条，失败" + Failed.ToString() + "条！", "OK");
            else
                MsgBox.NotifiShow("删除操作完成，成功" + Success.ToString() + "条，失败" + Failed.ToString() + "条！", "OK");
        }
        protected void BtnSave_Click(object sender, DirectEventArgs e)
        {
            {TABLENAME} _{TABLENAME} = new {TABLENAME}();
            if (Hid.Text.Length > 0)
                _{TABLENAME} = WMSFactory.{TABLENAME}.FindById(Hid.Text);
                
            {ModelSetValue}

            bool isok = false;
            if (Hid.Text.Length > 0)
                isok = WMSFactory.{TABLENAME}.Update(_{TABLENAME});
            else
                isok = WMSFactory.{TABLENAME}.Add(_{TABLENAME});
            if (isok)
            {
                {TABLENAME}_Win.Hide();
                {TABLENAME}_Grid.Reload();
                MsgBox.NotifiShow("恭喜您，操作成功！", "OK");
            }
            else
                MsgBox.MessageShow("操作失败，请您重试！", "ERROR");
        }
    }
}