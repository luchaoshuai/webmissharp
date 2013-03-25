using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DockPanelUI.Docking;

namespace WebMisSharp
{
    public partial class Welcome : DockContent
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void Welcome_Load(object sender, EventArgs e)
        {
            //CCTWS.ChinaCloudTechWSSoapClient ws = new CCTWS.ChinaCloudTechWSSoapClient();
            //webBrowser.DocumentText = ws.GetWSInfo("WebMisSharp")[0].incontent;
        }
    }
}
