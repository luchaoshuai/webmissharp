namespace MisSharp
{
    partial class Console
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Console));
            this.LogPreView = new System.Windows.Forms.RichTextBox();
            this.LogRightMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RMBtnClearLog = new System.Windows.Forms.ToolStripMenuItem();
            this.RMBtnSaveLog = new System.Windows.Forms.ToolStripMenuItem();
            this.RMBtnUploadLog = new System.Windows.Forms.ToolStripMenuItem();
            this.LogRightMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // LogPreView
            // 
            this.LogPreView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LogPreView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LogPreView.ContextMenuStrip = this.LogRightMenu;
            this.LogPreView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogPreView.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogPreView.ForeColor = System.Drawing.Color.Lime;
            this.LogPreView.Location = new System.Drawing.Point(0, 0);
            this.LogPreView.Name = "LogPreView";
            this.LogPreView.Size = new System.Drawing.Size(750, 188);
            this.LogPreView.TabIndex = 0;
            this.LogPreView.Text = " CJ> 系统加载成功\n";
            // 
            // LogRightMenu
            // 
            this.LogRightMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RMBtnClearLog,
            this.RMBtnSaveLog,
            this.RMBtnUploadLog});
            this.LogRightMenu.Name = "LogRightMenu";
            this.LogRightMenu.Size = new System.Drawing.Size(125, 70);
            // 
            // RMBtnClearLog
            // 
            this.RMBtnClearLog.Image = ((System.Drawing.Image)(resources.GetObject("RMBtnClearLog.Image")));
            this.RMBtnClearLog.Name = "RMBtnClearLog";
            this.RMBtnClearLog.Size = new System.Drawing.Size(124, 22);
            this.RMBtnClearLog.Text = "清空日志";
            this.RMBtnClearLog.Click += new System.EventHandler(this.RMBtnClearLog_Click);
            // 
            // RMBtnSaveLog
            // 
            this.RMBtnSaveLog.Image = ((System.Drawing.Image)(resources.GetObject("RMBtnSaveLog.Image")));
            this.RMBtnSaveLog.Name = "RMBtnSaveLog";
            this.RMBtnSaveLog.Size = new System.Drawing.Size(152, 22);
            this.RMBtnSaveLog.Text = "保存日志";
            this.RMBtnSaveLog.Click += new System.EventHandler(this.RMBtnSaveLog_Click);
            // 
            // RMBtnUploadLog
            // 
            this.RMBtnUploadLog.Image = ((System.Drawing.Image)(resources.GetObject("RMBtnUploadLog.Image")));
            this.RMBtnUploadLog.Name = "RMBtnUploadLog";
            this.RMBtnUploadLog.Size = new System.Drawing.Size(152, 22);
            this.RMBtnUploadLog.Text = "上传日志";
            this.RMBtnUploadLog.Click += new System.EventHandler(this.RMBtnUploadLog_Click);
            // 
            // Console
            // 
            this.AutoHidePortion = 0.2D;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 188);
            this.Controls.Add(this.LogPreView);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Console";
            this.ShowHint = DockPanelUI.Docking.DockState.DockBottomAutoHide;
            this.Text = "运行日志";
            this.LogRightMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox LogPreView;
        private System.Windows.Forms.ContextMenuStrip LogRightMenu;
        private System.Windows.Forms.ToolStripMenuItem RMBtnClearLog;
        private System.Windows.Forms.ToolStripMenuItem RMBtnSaveLog;
        private System.Windows.Forms.ToolStripMenuItem RMBtnUploadLog;
    }
}