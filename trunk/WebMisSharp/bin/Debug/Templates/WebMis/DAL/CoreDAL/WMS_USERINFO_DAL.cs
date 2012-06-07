using Model;
using DBHelper;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
/**
 * 作者：陈杰
 * Q Q： 710782046
 * Email：ovenjackchain@gmail.com
 * Web：http://yj.ChinaCloudTech.com
 */
namespace DAL
{
    public class WMS_USERINFO_DAL
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WMS_USERINFO FindById_userinfo(string userid)
        {
            WMS_USERINFO model = new WMS_USERINFO();
            DataTable dt = DbHelperSQL.FindByConditions(model, "username='" + userid.Replace("'", "") + "'");
            if (dt.Rows.Count <= 0)
                return null;
            else
            {
                return Common<WMS_USERINFO>.Dt2Model(model, dt);
            }
        }
    }
}
