using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Admin.Plugin.KindEditor4
{
    public partial class KindEditor : System.Web.UI.UserControl
    {
        public string Text
        {
            set { EditorContent.Value = value; }
            get { return EditorContent.Value; }
        }
    }
}