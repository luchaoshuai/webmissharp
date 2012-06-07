using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections;
using CJ_DBOperater;
using System.Configuration;
using Tools;

namespace Web.Admin.Core
{
    public partial class LogAndSql : WMS_UI
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindLogs();
        }
        class LogInfo
        {
            public string filename { get; set; }
            public string filedate { get; set; }
            public string filesize { get; set; }
        }
        private void BindLogs()
        {
            ArrayList list = new ArrayList();
            DirectoryInfo dir = new DirectoryInfo(MapPath("/Logs"));
            foreach (FileInfo file in dir.GetFiles())
            {
                LogInfo loginfo = new LogInfo();
                loginfo.filename = file.Name;
                loginfo.filedate = file.LastWriteTime.ToString();
                loginfo.filesize = Math.Round((file.Length / 1024.0 / 1024.0),4).ToString() + "M";
                list.Add(loginfo);
            }
            RPLogs.DataSource = list;
            RPLogs.DataBind();
        }

        protected void BtnRunRead_Click(object sender, EventArgs e)
        {
            if (TxtSQL.Text.Trim().Length < 0)
            {
                LbSqlInfo.ForeColor = System.Drawing.Color.Red;
                LbSqlInfo.Text = "请输入要执行的SQL";
                return;
            }
            try
            {
                CJ.sqlconn_str = ConfigurationManager.AppSettings["ConnectionString"];
                GridData.DataSource = CJ.SQL_ReturnDataTable(TxtSQL.Text.Trim());
                GridData.DataBind();
                log.Info(Tools.CookieHelper.GetCookie("username")+" 执行BtnRunRead成功:" + TxtSQL.Text.Trim());
                LbSqlInfo.ForeColor = System.Drawing.Color.Green;
                LbSqlInfo.Text = "SQL执行成功";
            }
            catch (Exception error)
            {
                LbSqlInfo.ForeColor = System.Drawing.Color.Red;
                LbSqlInfo.Text = "ERROR："+error.Message;
                log.Info(Tools.CookieHelper.GetCookie("username") + " 执行BtnRunRead失败:" + TxtSQL.Text.Trim()+"  ERROR:"+error.Message);
            }
        }

        protected void BtnRunNoRead_Click(object sender, EventArgs e)
        {
            try
            {
                CJ.sqlconn_str = ConfigurationManager.AppSettings["ConnectionString"];
                int line = CJ.SQL_ExecuteNonQuery(TxtSQL.Text.Trim());
                log.Info(Tools.CookieHelper.GetCookie("username") + " 执行BtnRunNoRead成功:" + TxtSQL.Text.Trim());
                LbSqlInfo.ForeColor = System.Drawing.Color.Green;
                LbSqlInfo.Text = "SQL执行成功，受影响行数：" + line.ToString();
            }
            catch (Exception error)
            {
                LbSqlInfo.ForeColor = System.Drawing.Color.Red;
                LbSqlInfo.Text = "ERROR：" + error.Message;
                log.Info(Tools.CookieHelper.GetCookie("username") + " 执行BtnRunNoRead失败:" + TxtSQL.Text.Trim() + "  ERROR:" + error.Message);
            }
        }

        protected void imgbtnDel_Click(object sender, CommandEventArgs e)
        {
            string filename = e.CommandName.ToString();
            try
            {
                if (File.Exists(Server.MapPath("/Logs/" + filename)))
                {
                    File.Delete(Server.MapPath("/Logs/" + filename));
                    AjAxMessageBox("ZENG.msgbox.show('" + filename + "-日志文件成功删除！', 1, 1500);");
                    log.Info(Tools.CookieHelper.GetCookie("username") + " 执行日志" + filename + "删除成功！");
                }
                else
                    AjAxMessageBox("ZENG.msgbox.show('" + filename + "-日志文件不存在！', 5, 1500);");
            }
            catch (Exception error)
            {
                AjAxMessageBox("ZENG.msgbox.show('ERROR:"+error.Message+"！', 5, 1500);");
                log.Info(Tools.CookieHelper.GetCookie("username") + " 执行日志"+filename+"删除失败:" + TxtSQL.Text.Trim() + "  ERROR:" + error.Message);
            }
        }

        private void AjAxMessageBox(string msg)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this.BtnRunNoRead, this.BtnRunNoRead.GetType(), "ajs", msg, true);
        }
    }
}