using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DockPanelUI.Docking;

using System.IO;
using ICSharpCode.TextEditor.Document;

namespace WebMisSharp
{
    public partial class YJCode : DockContent
    {
        //string[] modes = new string[]{"ASP3/XHTML","BAT","Boo","Coco","C++.NET","C#","HTML",
        //"Java","JavaScript","PHP","TeX","VBNET","XML","TSQL"};

        public YJCode(string tempFile, string FileType)
        {
            InitializeComponent();
            txtContent.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy(FileType);
            txtContent.ShowInvalidLines = false;
            StreamReader srFile = new StreamReader(tempFile, Encoding.Default);
            string Contents = srFile.ReadToEnd();
            srFile.Close();
            this.txtContent.Text = Contents;
        }

        public YJCode(string strCode, string FileType,string title)
        {
            InitializeComponent();
            txtContent.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy(FileType);
            
            this.txtContent.Text = strCode;
            this.Text = title;
        }
    }
}
