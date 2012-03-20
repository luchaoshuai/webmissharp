namespace WebMisSharp.Common
{
    partial class ErrorReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorReport));
            this.RTxtErrors = new System.Windows.Forms.RichTextBox();
            this.BtnSubmitErrors = new System.Windows.Forms.Button();
            this.BtnExitApp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RTxtErrors
            // 
            this.RTxtErrors.Cursor = System.Windows.Forms.Cursors.Default;
            this.RTxtErrors.Location = new System.Drawing.Point(3, 2);
            this.RTxtErrors.Name = "RTxtErrors";
            this.RTxtErrors.ReadOnly = true;
            this.RTxtErrors.Size = new System.Drawing.Size(441, 206);
            this.RTxtErrors.TabIndex = 0;
            this.RTxtErrors.Text = "";
            // 
            // BtnSubmitErrors
            // 
            this.BtnSubmitErrors.Location = new System.Drawing.Point(369, 212);
            this.BtnSubmitErrors.Name = "BtnSubmitErrors";
            this.BtnSubmitErrors.Size = new System.Drawing.Size(75, 23);
            this.BtnSubmitErrors.TabIndex = 1;
            this.BtnSubmitErrors.Text = "提交错误";
            this.BtnSubmitErrors.UseVisualStyleBackColor = true;
            this.BtnSubmitErrors.Click += new System.EventHandler(this.BtnSubmitErrors_Click);
            // 
            // BtnExitApp
            // 
            this.BtnExitApp.Location = new System.Drawing.Point(288, 212);
            this.BtnExitApp.Name = "BtnExitApp";
            this.BtnExitApp.Size = new System.Drawing.Size(75, 23);
            this.BtnExitApp.TabIndex = 2;
            this.BtnExitApp.Text = "终止程序";
            this.BtnExitApp.UseVisualStyleBackColor = true;
            this.BtnExitApp.Click += new System.EventHandler(this.BtnExitApp_Click);
            // 
            // ErrorReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 239);
            this.Controls.Add(this.BtnExitApp);
            this.Controls.Add(this.BtnSubmitErrors);
            this.Controls.Add(this.RTxtErrors);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ErrorReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "应用程序错误";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox RTxtErrors;
        private System.Windows.Forms.Button BtnSubmitErrors;
        private System.Windows.Forms.Button BtnExitApp;
    }
}