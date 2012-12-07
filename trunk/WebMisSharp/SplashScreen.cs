using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MisSharp
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent(); 
        }
        //验证是否有新版本
        private void CheckVersion()
        {
            this.LbStart.Text +="\r\nProduct:"+ Application.ProductName +" Ver:"+ Application.ProductVersion;
        }
        //启动升级程序
        private void StartUpdate()
        {
        }
        //发送用户信息
        private void SendCurrentClient()
        {
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            CheckVersion();
        }
    }
}
