namespace WebMisSharp
{
    partial class RunSQL
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RunSQL));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpResult = new System.Windows.Forms.TabPage();
            this.dataGridResult = new System.Windows.Forms.DataGridView();
            this.tpMsgs = new System.Windows.Forms.TabPage();
            this.txtSQL = new ICSharpCode.TextEditor.TextEditorControl();
            this.txtMsgs = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.执行SQLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tpResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResult)).BeginInit();
            this.tpMsgs.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtSQL);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl);
            this.splitContainer1.Size = new System.Drawing.Size(780, 494);
            this.splitContainer1.SplitterDistance = 255;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpResult);
            this.tabControl.Controls.Add(this.tpMsgs);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(780, 235);
            this.tabControl.TabIndex = 0;
            // 
            // tpResult
            // 
            this.tpResult.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tpResult.Controls.Add(this.dataGridResult);
            this.tpResult.Location = new System.Drawing.Point(4, 22);
            this.tpResult.Name = "tpResult";
            this.tpResult.Padding = new System.Windows.Forms.Padding(3);
            this.tpResult.Size = new System.Drawing.Size(772, 209);
            this.tpResult.TabIndex = 0;
            this.tpResult.Text = "结果";
            this.tpResult.UseVisualStyleBackColor = true;
            // 
            // dataGridResult
            // 
            this.dataGridResult.AllowUserToAddRows = false;
            this.dataGridResult.AllowUserToDeleteRows = false;
            this.dataGridResult.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.dataGridResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridResult.Location = new System.Drawing.Point(3, 3);
            this.dataGridResult.Name = "dataGridResult";
            this.dataGridResult.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Consolas", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridResult.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridResult.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridResult.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Consolas", 9F);
            this.dataGridResult.RowTemplate.Height = 23;
            this.dataGridResult.Size = new System.Drawing.Size(766, 203);
            this.dataGridResult.TabIndex = 0;
            // 
            // tpMsgs
            // 
            this.tpMsgs.Controls.Add(this.txtMsgs);
            this.tpMsgs.Location = new System.Drawing.Point(4, 22);
            this.tpMsgs.Name = "tpMsgs";
            this.tpMsgs.Padding = new System.Windows.Forms.Padding(3);
            this.tpMsgs.Size = new System.Drawing.Size(772, 209);
            this.tpMsgs.TabIndex = 1;
            this.tpMsgs.Text = "消息";
            this.tpMsgs.UseVisualStyleBackColor = true;
            // 
            // txtSQL
            // 
            this.txtSQL.ContextMenuStrip = this.contextMenuStrip1;
            this.txtSQL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSQL.Encoding = ((System.Text.Encoding)(resources.GetObject("txtSQL.Encoding")));
            this.txtSQL.IsReadOnly = false;
            this.txtSQL.Location = new System.Drawing.Point(0, 0);
            this.txtSQL.Name = "txtSQL";
            this.txtSQL.Size = new System.Drawing.Size(780, 255);
            this.txtSQL.TabIndex = 0;
            // 
            // txtMsgs
            // 
            this.txtMsgs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMsgs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMsgs.Location = new System.Drawing.Point(3, 3);
            this.txtMsgs.Multiline = true;
            this.txtMsgs.Name = "txtMsgs";
            this.txtMsgs.Size = new System.Drawing.Size(766, 203);
            this.txtMsgs.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.执行SQLToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(122, 26);
            // 
            // 执行SQLToolStripMenuItem
            // 
            this.执行SQLToolStripMenuItem.Name = "执行SQLToolStripMenuItem";
            this.执行SQLToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.执行SQLToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.执行SQLToolStripMenuItem.Text = "执行";
            this.执行SQLToolStripMenuItem.Click += new System.EventHandler(this.执行SQLToolStripMenuItem_Click);
            // 
            // RunSQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 494);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RunSQL";
            this.Text = "SQL查询分析器";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tpResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResult)).EndInit();
            this.tpMsgs.ResumeLayout(false);
            this.tpMsgs.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpResult;
        private System.Windows.Forms.TabPage tpMsgs;
        private System.Windows.Forms.DataGridView dataGridResult;
        private ICSharpCode.TextEditor.TextEditorControl txtSQL;
        private System.Windows.Forms.TextBox txtMsgs;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 执行SQLToolStripMenuItem;
    }
}