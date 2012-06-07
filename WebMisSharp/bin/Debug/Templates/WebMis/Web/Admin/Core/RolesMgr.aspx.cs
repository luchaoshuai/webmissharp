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
    public partial class RolesMgr : WMS_UI
    {
        protected void InfoBind(object sender, StoreRefreshDataEventArgs e)
        {
            IList<WMS_ROLES> list = WMSFactory.WMS_ROLES.FindAll();
            role_Store.DataSource = list;
            role_Store.DataBind();
        }
        protected void HandleChanges(object sender, BeforeStoreChangedEventArgs e)
        {
            int Success=0,Failed=0;
            ChangeRecords<WMS_ROLES> persons = e.DataHandler.ObjectData<WMS_ROLES>();
            foreach (WMS_ROLES updated in persons.Updated)
            {
                if (updated.rolename.Trim().Length <= 0) continue;
                if (WMSFactory.WMS_ROLES.Update(updated)) Success++;                        
                else Failed++;                        
            }
            foreach (WMS_ROLES inserted in persons.Created)
            {
                if (inserted.rolename.Trim().Length <= 0) continue;
                if (WMSFactory.WMS_ROLES.Add(inserted)) Success++;
                else Failed++;
            }
            MsgBox.NotifiShow("保存操作完成，成功"+Success.ToString()+"条，失败"+Failed.ToString()+"条！", "OK");
            e.Cancel = true;
        }
        //删除权限
        protected void BtnDel_Click(object sender, DirectEventArgs e)
        {
            int Success = 0, Failed = 0;
            RowSelectionModel sm = this.role_Grid.SelectionModel.Primary as RowSelectionModel;
            foreach (SelectedRow row in sm.SelectedRows)
            {
                WMS_ROLES role = new WMS_ROLES();
                role.roleid = int.Parse(row.RecordID);
                if (row.RecordID == "1")
                {
                    MsgBox.MessageShow("系统不允许删除超级管理员的角色权限！", "ERROR");
                    continue;
                }
                if (WMSFactory.WMS_ROLES.Del(role))
                {
                    WMSFactory.WMS_ROLEFUN.DelByConditions("roleid=" + row.RecordID);
                    Success++;
                }
                else Failed++;
            }
            if(Failed>0)
                MsgBox.MessageShow("删除角色操作完成，成功" + Success.ToString() + "条，失败" + Failed.ToString() + "条！", "OK");
            else
                MsgBox.NotifiShow("删除角色操作完成，成功" + Success.ToString() + "条，失败" + Failed.ToString() + "条！", "OK");
            role_Grid.Reload();
        }
        /// <summary>
        /// 获取功能菜单树
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GetExamplesNodes(object sender, NodeLoadEventArgs e)
        {
            if (e.NodeID == "root")
            {
                rolefunMgr rolefunMgr = new rolefunMgr();
                e.Nodes = rolefunMgr.GetMenu("-1");
            }
        }

        //双击Grid的列，弹出修改框
        protected void roleForFunGridDBClick(object sender, StoreRefreshDataEventArgs e)
        {
            rolefun_Store.DataSource = WMSFactory.WMS_ROLEFUN.FindByCondition("roleid=" + e.Parameters["roleid"].ToString());
            rolefun_Store.DataBind();
        }

        protected void AllFunBind(object sender, StoreRefreshDataEventArgs e)
        {
            AllFun_Store.DataSource = WMSFactory.WMS_USERFUN.FindAll();
            AllFun_Store.DataBind();
        }

        protected void BtnGiveFuns_Click(object sender, DirectEventArgs e)
        {
            rolefunMgr mgr = new rolefunMgr();
            if (mgr.WMS_ROLEFUNGive(e.ExtraParams["id"].ToString()))
            {
                funOfrole_Grid.Reload();
                MsgBox.NotifiShow("恭喜您，授权成功！", "OK");
            }
            else
                MsgBox.MessageShow("授权失败，请您重试！", "ERROR");
        }

        protected void BtnDelFuns_Click(object sender, DirectEventArgs e)
        {
            RowSelectionModel sm = this.funOfrole_Grid.SelectionModel.Primary as RowSelectionModel;
            foreach (SelectedRow row in sm.SelectedRows)
            {
                WMS_ROLEFUN rolefun = new WMS_ROLEFUN();
                rolefun.pid = int.Parse(row.RecordID);
                WMSFactory.WMS_ROLEFUN.Del(rolefun);
            }
            funOfrole_Grid.Reload();
            MsgBox.NotifiShow("恭喜您，功能菜单删除成功！", "OK");
        }

        protected void BtnCacheReflash_Click(object sender, DirectEventArgs e)
        {
            CacheHelper.CacheNull(CookieHelper.GetCookie("username"));
            MsgBox.NotifiShow("缓存清理完毕！", "OK");
        }
    }
}