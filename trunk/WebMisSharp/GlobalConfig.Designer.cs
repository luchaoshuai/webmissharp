namespace WebMisSharp
{
    partial class GlobalConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("字段映射");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("基本配置", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GlobalConfig));
            this.TreeSettings = new System.Windows.Forms.TreeView();
            this.UserControlContainer = new System.Windows.Forms.Panel();
            this.BtnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TreeSettings
            // 
            this.TreeSettings.Location = new System.Drawing.Point(7, 7);
            this.TreeSettings.Name = "TreeSettings";
            treeNode1.Name = "ZDYS";
            treeNode1.Text = "字段映射";
            treeNode2.Name = "JBPZ";
            treeNode2.Text = "基本配置";
            this.TreeSettings.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.TreeSettings.Size = new System.Drawing.Size(135, 292);
            this.TreeSettings.TabIndex = 0;
            this.TreeSettings.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeSettings_AfterSelect);
            // 
            // UserControlContainer
            // 
            this.UserControlContainer.Location = new System.Drawing.Point(148, 7);
            this.UserControlContainer.Name = "UserControlContainer";
            this.UserControlContainer.Size = new System.Drawing.Size(336, 264);
            this.UserControlContainer.TabIndex = 1;
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(409, 277);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(75, 23);
            this.BtnClose.TabIndex = 2;
            this.BtnClose.Text = "关  闭";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // GlobalConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 306);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.UserControlContainer);
            this.Controls.Add(this.TreeSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GlobalConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选项";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView TreeSettings;
        private System.Windows.Forms.Panel UserControlContainer;
        private System.Windows.Forms.Button BtnClose;
    }
}