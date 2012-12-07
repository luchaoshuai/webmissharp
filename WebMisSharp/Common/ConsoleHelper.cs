using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace MisSharp
{
    public class ConsoleHelper
    {
        public static Console console = null;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ConsoleHelper()
        {

        }
        //输出日志
        public static void ShowConsole(string Msg)
        {
            log.Info(Msg);
            console = ((Console)Application.OpenForms["Console"]);
            if (console == null) return;
            console.Show();
            console.RTLog(Msg);
        }
        //设置当前行颜色
        public static void SetLineColor(Color color)
        {
            console = ((Console)Application.OpenForms["Console"]);
            if (console == null) return;
            console.LogPreView.SelectionColor = color;
        }
    }
}
