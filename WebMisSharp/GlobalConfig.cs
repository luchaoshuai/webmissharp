using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WebMisSharp
{
    public partial class GlobalConfig : Form
    {
        private UserCtrls.FieldSettings fieldsettings = new UserCtrls.FieldSettings();
        public GlobalConfig()
        {
            InitializeComponent();
            UserControlContainer.Controls.Add(fieldsettings);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TreeSettings_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = this.TreeSettings.SelectedNode;
            if (selectedNode != null)
            {
                switch (selectedNode.Text)
                {
                    case "字段映射":
                        ActivateOptionControl(fieldsettings);
                        break;
                }
            }
        }

        private void ActivateOptionControl(System.Windows.Forms.UserControl optionControl)
        {
            foreach (UserControl uc in this.UserControlContainer.Controls)
                uc.Hide();
            optionControl.Show();
        }
    }
}
