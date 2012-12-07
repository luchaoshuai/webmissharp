using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MisSharp
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += new System.UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MisSharp app = new MisSharp();
            if (app.isRunning != null)//只允许一个实例
                Application.Run(new MisSharpContext());
            else
                MessageBox.Show(app, "您已经开启了一个实例，系统不允许多实例运行！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //全局错误
        static void CurrentDomain_UnhandledException(object sender, System.UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject != null)
            {
                Exception ex = e.ExceptionObject as Exception;
                string errorMessage = "错误信息：\n\n" +
                                      ex.Message + "\n\n" + ex.GetType() +
                                      "\n\nStack Trace:\n" + ex.StackTrace;
                Common.ErrorReport er = new Common.ErrorReport(errorMessage);
                if (er.ShowDialog() == DialogResult.OK)
                    Application.Exit();
            }
        }
    }
    class MisSharpContext : SplashScreenApplicationContext
    {
        protected override void OnCreateSplashScreenForm()
        {
            this.SplashScreenForm = new SplashScreen();//启动窗体 
        }
        protected override void OnCreateMainForm()
        {
            this.PrimaryForm = new MisSharp();//主窗体 
        }
        protected override void SetSeconds()
        {
            this.SecondsShow = 5;//启动窗体显示的时间(秒) 
        }
    }
}
