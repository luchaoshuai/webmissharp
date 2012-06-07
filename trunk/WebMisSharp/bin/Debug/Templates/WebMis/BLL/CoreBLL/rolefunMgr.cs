using System.Collections.Generic;
using Model;
using DAL;
using Ext.Net;
using System.IO;
using System.Web;
using System.Data;

/**
 * 作者：陈杰
 * QQ ： 710782046
 * Email：ovenjackchain@gmail.com
 * Web：http://yj.ChinaCloudTech.com
 */

namespace BLL
{
    public class rolefunMgr
    {
        WMS_ROLEFUN_DAL WMS_ROLEFUNDao = new WMS_ROLEFUN_DAL();
        SQLServer_DAL<WMS_USERFUN> cjdao = new SQLServer_DAL<WMS_USERFUN>();
        SQLServer_DAL<WMS_ROLEFUN> rfdao = new SQLServer_DAL<WMS_ROLEFUN>();
        public IList<WMS_USERFUN> FindWMS_ROLEFUN(string roleid)
        {
            return WMS_ROLEFUNDao.FindMyMenu(roleid);
        }
        public List<WMS_AUTHORITY> FindAuthFun(string roleid)
        {
            return (List<WMS_AUTHORITY>)WMS_ROLEFUNDao.FindAuthority(roleid);
        }
        public DataTable FindFavoriteFun(string UserID)
        {
            return WMS_ROLEFUNDao.FindUserFavoriteFun(UserID);
        }
        public bool WMS_ROLEFUNGive(string funids)
        {
            string[] funs = funids.Split(',');
            List<WMS_USERFUN> listfun = (List<WMS_USERFUN>)cjdao.FindAll();
            for (int i = 0; i < funs.Length - 1; i++)
            {
                int fatherid = -1;
                int funid = int.Parse(funs[i]);
                while (fatherid != 0)
                {
                    WMS_USERFUN ufun = listfun.Find(delegate(WMS_USERFUN fun) { return fun.funid == funid; });
                    WMS_ROLEFUN _WMS_ROLEFUN = new WMS_ROLEFUN();
                    _WMS_ROLEFUN.roleid = int.Parse(funs[funs.Length - 1]);
                    _WMS_ROLEFUN.funid = ufun.funid;
                    if(rfdao.FindByCondition("roleid=" + _WMS_ROLEFUN.roleid + " and funid=" + _WMS_ROLEFUN.funid).Count<=0)
                        rfdao.Add(_WMS_ROLEFUN);
                    funid = ufun.fatherid;
                    fatherid = ufun.fatherid;
                }
            }
            return true;
        }
        public TreeNodeCollection GetMenu(string roleid)
        {
            List<WMS_USERFUN> roleMenu = (List<WMS_USERFUN>)WMS_ROLEFUNDao.FindMyMenu(roleid); //得到用户所有功能菜单
            List<WMS_USERFUN> userFatherFun = roleMenu.FindAll(delegate(WMS_USERFUN fun) { return fun.fatherid == 0; }); //父节点
            List<WMS_USERFUN> userChildernFun = roleMenu.FindAll(delegate(WMS_USERFUN fun) { return fun.fatherid > 0; });//子节点
            if(roleid=="-1")
                return CreateFunTree(roleid, userFatherFun, userChildernFun);
            return CreateTree(roleid,userFatherFun, userChildernFun);
        }
        private TreeNodeCollection CreateTree(string roleid,List<WMS_USERFUN> userFatherFun, List<WMS_USERFUN> userChildernFun)
        {
            TreeNodeCollection nodes = new TreeNodeCollection(false);
            foreach (WMS_USERFUN menu in userFatherFun)
            {
                if (menu.funid == 2000 || menu.fatherid == 2000) continue;
                TreeNode node = new TreeNode();
                //核心
                List<WMS_USERFUN> stack = userChildernFun.FindAll(delegate(WMS_USERFUN fun) { return fun.fatherid == menu.funid; });
                if (stack.Count > 0)
                {
                    node.NodeID = menu.funid.ToString();
                    node.Text = menu.funname;
                    node.SingleClickExpand = true;
                    node.Nodes.AddRange(CreateTree(roleid,stack, userChildernFun));
                }
                else
                {
                    node.NodeID = menu.funid.ToString();
                    node.Text = menu.funname;
                    node.IconFile = "images/Icons/"+ menu.funid.ToString() + ".png";
                    if (!File.Exists(HttpContext.Current.Server.MapPath(node.IconFile)))
                        node.IconFile = "images/Icons/none.png";
                    node.Href = menu.funno;
                    node.Leaf = true;
                }
                nodes.Add(node);
            }
            return nodes;
        }
        //角色分配
        private TreeNodeCollection CreateFunTree(string roleid, List<WMS_USERFUN> userFatherFun, List<WMS_USERFUN> userChildernFun)
        {
            TreeNodeCollection nodes = new TreeNodeCollection(false);
            foreach (WMS_USERFUN menu in userFatherFun)
            {
                TreeNode node = new TreeNode();
                //核心
                List<WMS_USERFUN> stack = userChildernFun.FindAll(delegate(WMS_USERFUN fun) { return fun.fatherid == menu.funid; });
                if (stack.Count > 0)
                {
                    node.NodeID = menu.funid.ToString();
                    node.Text = menu.funname;
                    node.SingleClickExpand = true;
                    node.Checked = ThreeStateBool.False;
                    node.Nodes.AddRange(CreateFunTree(roleid, stack, userChildernFun));
                }
                else
                {
                    node.NodeID = menu.funid.ToString();
                    node.Text = menu.funname;
                    node.IconFile = "../images/Icons/" + menu.funid.ToString() + ".png";
                    if (!File.Exists(HttpContext.Current.Server.MapPath(node.IconFile)))
                        node.IconFile = "../images/Icons/none.png";
                    node.Checked = ThreeStateBool.False;
                    node.Leaf = true;
                }
                nodes.Add(node);
            }
            return nodes;
        }
        //功能节点创建，修改
        public bool FunAddorUpdate(WMS_USERFUN Fun, string hid)
        {
            if (WMS_ROLEFUNDao.FunAddorUpdate(Fun, hid.Trim()) >= 0)
                return true;
            else
                return false;
        }
    }
}
