namespace WebMisSharp
{
    partial class Project
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Project));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ProToolBarProjectAttribute = new System.Windows.Forms.ToolStripButton();
            this.ProToolBarRemove = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ProToolBarAtt = new System.Windows.Forms.ToolStripButton();
            this.Tree_Project = new System.Windows.Forms.TreeView();
            this.RightMenuProTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ImgList = new System.Windows.Forms.ImageList(this.components);
            this.backgroundWorkDBLoad = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerUnZip = new System.ComponentModel.BackgroundWorker();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProToolBarProjectAttribute,
            this.ProToolBarRemove,
            this.toolStripSeparator1,
            this.ProToolBarAtt});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(234, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ProToolBarProjectAttribute
            // 
            this.ProToolBarProjectAttribute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ProToolBarProjectAttribute.Image = ((System.Drawing.Image)(resources.GetObject("ProToolBarProjectAttribute.Image")));
            this.ProToolBarProjectAttribute.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ProToolBarProjectAttribute.Name = "ProToolBarProjectAttribute";
            this.ProToolBarProjectAttribute.Size = new System.Drawing.Size(23, 22);
            this.ProToolBarProjectAttribute.Text = "新建项目";
            this.ProToolBarProjectAttribute.Click += new System.EventHandler(this.ProToolBarProjectAttribute_Click);
            // 
            // ProToolBarRemove
            // 
            this.ProToolBarRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ProToolBarRemove.Image = ((System.Drawing.Image)(resources.GetObject("ProToolBarRemove.Image")));
            this.ProToolBarRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ProToolBarRemove.Name = "ProToolBarRemove";
            this.ProToolBarRemove.Size = new System.Drawing.Size(23, 22);
            this.ProToolBarRemove.Text = "删除项目";
            this.ProToolBarRemove.Click += new System.EventHandler(this.ProToolBarRemove_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // ProToolBarAtt
            // 
            this.ProToolBarAtt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ProToolBarAtt.Image = ((System.Drawing.Image)(resources.GetObject("ProToolBarAtt.Image")));
            this.ProToolBarAtt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ProToolBarAtt.Name = "ProToolBarAtt";
            this.ProToolBarAtt.Size = new System.Drawing.Size(23, 22);
            this.ProToolBarAtt.Text = "项目属性";
            this.ProToolBarAtt.Click += new System.EventHandler(this.ProToolBarAtt_Click);
            // 
            // Tree_Project
            // 
            this.Tree_Project.ContextMenuStrip = this.RightMenuProTree;
            this.Tree_Project.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tree_Project.ImageIndex = 0;
            this.Tree_Project.ImageList = this.ImgList;
            this.Tree_Project.Location = new System.Drawing.Point(0, 25);
            this.Tree_Project.Name = "Tree_Project";
            this.Tree_Project.SelectedImageIndex = 0;
            this.Tree_Project.Size = new System.Drawing.Size(234, 418);
            this.Tree_Project.TabIndex = 2;
            this.Tree_Project.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.Tree_Project_AfterSelect);
            this.Tree_Project.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Tree_Project_MouseUp);
            // 
            // RightMenuProTree
            // 
            this.RightMenuProTree.Name = "RightMenuProTree";
            this.RightMenuProTree.Size = new System.Drawing.Size(61, 4);
            // 
            // ImgList
            // 
            this.ImgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImgList.ImageStream")));
            this.ImgList.TransparentColor = System.Drawing.Color.Transparent;
            this.ImgList.Images.SetKeyName(0, "db.gif");
            this.ImgList.Images.SetKeyName(1, "Folderclose.gif");
            this.ImgList.Images.SetKeyName(2, "Folderopen.gif");
            this.ImgList.Images.SetKeyName(3, "table.gif");
            this.ImgList.Images.SetKeyName(4, "view.gif");
            this.ImgList.Images.SetKeyName(5, "sp.gif");
            this.ImgList.Images.SetKeyName(6, "sln.ico");
            this.ImgList.Images.SetKeyName(7, "VS2005.ico");
            this.ImgList.Images.SetKeyName(8, "att.gif");
            this.ImgList.Images.SetKeyName(9, "drive--minus.png");
            this.ImgList.Images.SetKeyName(10, "btnRefresh.png");
            this.ImgList.Images.SetKeyName(11, "sql.png");
            this.ImgList.Images.SetKeyName(12, "cs.png");
            this.ImgList.Images.SetKeyName(13, "create.ico");
            this.ImgList.Images.SetKeyName(14, "csproj.png");
            this.ImgList.Images.SetKeyName(15, "document-office-text.png");
            this.ImgList.Images.SetKeyName(16, "document-word-text.png");
            this.ImgList.Images.SetKeyName(17, "magnifier-left.png");
            this.ImgList.Images.SetKeyName(18, "node-select-all.png");
            this.ImgList.Images.SetKeyName(19, "DatabaseProject.ico");
            this.ImgList.Images.SetKeyName(20, "script-code.png");
            this.ImgList.Images.SetKeyName(21, "blog.png");
            this.ImgList.Images.SetKeyName(22, "plus-shield.png");
            this.ImgList.Images.SetKeyName(23, "tick-shield.png");
            this.ImgList.Images.SetKeyName(24, "database--plus.png");
            // 
            // backgroundWorkDBLoad
            // 
            this.backgroundWorkDBLoad.WorkerReportsProgress = true;
            this.backgroundWorkDBLoad.WorkerSupportsCancellation = true;
            this.backgroundWorkDBLoad.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ReflashDB);
            this.backgroundWorkDBLoad.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkDBLoad_ProgressChanged);
            this.backgroundWorkDBLoad.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkDBLoad_RunWorkerCompleted);
            // 
            // backgroundWorkerUnZip
            // 
            this.backgroundWorkerUnZip.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerUnZip_DoWork);
            this.backgroundWorkerUnZip.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerUnZip_RunWorkerCompleted);
            // 
            // Project
            // 
            this.AutoHidePortion = 0.16D;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 443);
            this.Controls.Add(this.Tree_Project);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Project";
            this.ShowHint = DockPanelUI.Docking.DockState.DockRight;
            this.Text = "解决方案管理器";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ProToolBarProjectAttribute;
        private System.Windows.Forms.TreeView Tree_Project;
        private System.Windows.Forms.ImageList ImgList;
        private System.Windows.Forms.ToolStripButton ProToolBarRemove;
        private System.Windows.Forms.ContextMenuStrip RightMenuProTree;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton ProToolBarAtt;
        public System.ComponentModel.BackgroundWorker backgroundWorkDBLoad;
        private System.ComponentModel.BackgroundWorker backgroundWorkerUnZip;
    }
}