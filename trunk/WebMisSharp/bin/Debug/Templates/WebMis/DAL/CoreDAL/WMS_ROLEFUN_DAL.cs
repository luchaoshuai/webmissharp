//添加必要的动态连接库
using Model;
using System.Collections.Generic;
using DBHelper;
using System.Data;

/**
 * 作者：陈杰
 * Q Q： 710782046
 * Email：ovenjackchain@gmail.com
 * Web：http://yj.ChinaCloudTech.com
 */
namespace DAL
{
    public class WMS_ROLEFUN_DAL
    {
        public IList<WMS_USERFUN> FindMyMenu(string roleid)
        {
            string sql = "select F.funid,F.funno,F.funname,F.fatherid from WMS_USERFUN F,WMS_ROLEFUN where WMS_ROLEFUN.funid=F.funid and roleid=" + roleid;
            if (roleid == "-1") sql = "select * from WMS_USERFUN";
            sql += " order by F.funid";
            return Common<WMS_USERFUN>.Dt2List(DbHelperSQL.Query(sql).Tables[0]);
        }

        public IList<WMS_AUTHORITY> FindAuthority(string roleid)
        {
            string sql = "select F.funno from WMS_USERFUN F,WMS_ROLEFUN where WMS_ROLEFUN.funid=F.funid and roleid=" + roleid;
            return Common<WMS_AUTHORITY>.Dt2List(DbHelperSQL.Query(sql).Tables[0]);
        }

        public DataTable FindUserFavoriteFun(string UserID)
        {
            string sql = "select U.funid,U.funno,U.funname,F.Fid from WMS_FAVORITES F,WMS_USERFUN U where F.Funid=U.funid and F.UserId='{0}'";
            return DbHelperSQL.Query(string.Format(sql, UserID)).Tables[0];
        }

        public int FunAddorUpdate(WMS_USERFUN Fun, string hid)
        {
            string sql="";
            if (hid.Length > 0)
                sql = "update WMS_USERFUN set funid=" + Fun.funid.ToString() + ",funno='" + Fun.funno + "',funname='" + Fun.funname + "',fatherid=" + Fun.fatherid + " where funid=" + hid + ";"
                    + "update WMS_ROLEFUN set funid=" + Fun.funid.ToString() + " where funid=" + hid + ";";
            else
                sql = "insert into WMS_USERFUN (funid,funno,funname,fatherid) values(" + Fun.funid.ToString() + ",'" + Fun.funno + "','" + Fun.funname + "'," + Fun.fatherid + ");insert into WMS_ROLEFUN values(1," + Fun.funid.ToString() + ");";
            return DbHelperSQL.ExecuteSql(sql);
        }
    }
}
