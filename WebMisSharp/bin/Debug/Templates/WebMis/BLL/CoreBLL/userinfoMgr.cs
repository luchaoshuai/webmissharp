using System.Collections.Generic;
using Model;
using DAL;
using IDAL;


/**
 * 作者：陈杰
 * QQ ： 710782046
 * Email：ovenjackchain@gmail.com
 * Web：http://yj.ChinaCloudTech.com
 */
namespace BLL
{
    public class userinfoMgr
    {
        WMS_USERINFO_DAL userinfoDao = new WMS_USERINFO_DAL();
        public WMS_USERINFO FindById_userinfo(string id)
        {
            return userinfoDao.FindById_userinfo(id);
        }
        public void Update_userinfo(WMS_USERINFO userinfo)
        {
            IDAL<WMS_USERINFO> mgr = new SQLServer_DAL<WMS_USERINFO>();
            mgr.Update(userinfo);
        }
    }
}
