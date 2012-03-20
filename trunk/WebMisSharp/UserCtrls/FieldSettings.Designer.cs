namespace WebMisSharp.UserCtrls
{
    partial class FieldSettings
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FieldSettings));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DBFieldSettings = new System.Windows.Forms.TabControl();
            this.TPMSSQLServer = new System.Windows.Forms.TabPage();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtValue = new System.Windows.Forms.TextBox();
            this.TxtKey = new System.Windows.Forms.TextBox();
            this.DGVMSSQL = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.TPOracle = new System.Windows.Forms.TabPage();
            this.key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DBFieldSettings.SuspendLayout();
            this.TPMSSQLServer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVMSSQL)).BeginInit();
            this.SuspendLayout();
            // 
            // DBFieldSettings
            // 
            this.DBFieldSettings.Controls.Add(this.TPMSSQLServer);
            this.DBFieldSettings.Controls.Add(this.TPOracle);
            this.DBFieldSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DBFieldSettings.Location = new System.Drawing.Point(0, 0);
            this.DBFieldSettings.Name = "DBFieldSettings";
            this.DBFieldSettings.SelectedIndex = 0;
            this.DBFieldSettings.Size = new System.Drawing.Size(336, 264);
            this.DBFieldSettings.TabIndex = 0;
            // 
            // TPMSSQLServer
            // 
            this.TPMSSQLServer.Controls.Add(this.BtnDelete);
            this.TPMSSQLServer.Controls.Add(this.BtnSave);
            this.TPMSSQLServer.Controls.Add(this.label1);
            this.TPMSSQLServer.Controls.Add(this.TxtValue);
            this.TPMSSQLServer.Controls.Add(this.TxtKey);
            this.TPMSSQLServer.Controls.Add(this.DGVMSSQL);
            this.TPMSSQLServer.Controls.Add(this.label2);
            this.TPMSSQLServer.Location = new System.Drawing.Point(4, 22);
            this.TPMSSQLServer.Name = "TPMSSQLServer";
            this.TPMSSQLServer.Padding = new System.Windows.Forms.Padding(3);
            this.TPMSSQLServer.Size = new System.Drawing.Size(328, 238);
            this.TPMSSQLServer.TabIndex = 0;
            this.TPMSSQLServer.Text = "MSSQLServer";
            this.TPMSSQLServer.UseVisualStyleBackColor = true;
            // 
            // BtnDelete
            // 
            this.BtnDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnDelete.BackgroundImage")));
            this.BtnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnDelete.Location = new System.Drawing.Point(293, 9);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(24, 23);
            this.BtnDelete.TabIndex = 6;
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnSave.BackgroundImage")));
            this.BtnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnSave.Location = new System.Drawing.Point(263, 9);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(24, 23);
            this.BtnSave.TabIndex = 5;
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "数据库";
            // 
            // TxtValue
            // 
            this.TxtValue.Location = new System.Drawing.Point(180, 11);
            this.TxtValue.Name = "TxtValue";
            this.TxtValue.Size = new System.Drawing.Size(76, 21);
            this.TxtValue.TabIndex = 2;
            // 
            // TxtKey
            // 
            this.TxtKey.Location = new System.Drawing.Point(49, 11);
            this.TxtKey.Name = "TxtKey";
            this.TxtKey.Size = new System.Drawing.Size(76, 21);
            this.TxtKey.TabIndex = 1;
            // 
            // DGVMSSQL
            // 
            this.DGVMSSQL.AllowUserToAddRows = false;
            this.DGVMSSQL.AllowUserToDeleteRows = false;
            this.DGVMSSQL.AllowUserToResizeColumns = false;
            this.DGVMSSQL.AllowUserToResizeRows = false;
            this.DGVMSSQL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVMSSQL.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVMSSQL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVMSSQL.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.key,
            this.value});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVMSSQL.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGVMSSQL.Location = new System.Drawing.Point(6, 38);
            this.DGVMSSQL.MultiSelect = false;
            this.DGVMSSQL.Name = "DGVMSSQL";
            this.DGVMSSQL.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVMSSQL.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DGVMSSQL.RowHeadersVisible = false;
            this.DGVMSSQL.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DGVMSSQL.RowTemplate.Height = 23;
            this.DGVMSSQL.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVMSSQL.Size = new System.Drawing.Size(316, 194);
            this.DGVMSSQL.TabIndex = 0;
            this.DGVMSSQL.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVMSSQL_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "C#类型";
            // 
            // TPOracle
            // 
            this.TPOracle.Location = new System.Drawing.Point(4, 22);
            this.TPOracle.Name = "TPOracle";
            this.TPOracle.Padding = new System.Windows.Forms.Padding(3);
            this.TPOracle.Size = new System.Drawing.Size(328, 238);
            this.TPOracle.TabIndex = 1;
            this.TPOracle.Text = "Oracle";
            this.TPOracle.UseVisualStyleBackColor = true;
            // 
            // key
            // 
            this.key.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.key.DataPropertyName = "key";
            this.key.HeaderText = "数据库字段类型";
            this.key.Name = "key";
            this.key.ReadOnly = true;
            // 
            // value
            // 
            this.value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.value.DataPropertyName = "value";
            this.value.HeaderText = "C#类型";
            this.value.Name = "value";
            this.value.ReadOnly = true;
            // 
            // FieldSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DBFieldSettings);
            this.Name = "FieldSettings";
            this.Size = new System.Drawing.Size(336, 264);
            this.DBFieldSettings.ResumeLayout(false);
            this.TPMSSQLServer.ResumeLayout(false);
            this.TPMSSQLServer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVMSSQL)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl DBFieldSettings;
        private System.Windows.Forms.TabPage TPMSSQLServer;
        private System.Windows.Forms.TabPage TPOracle;
        private System.Windows.Forms.DataGridView DGVMSSQL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtValue;
        private System.Windows.Forms.TextBox TxtKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn key;
        private System.Windows.Forms.DataGridViewTextBoxColumn value;
    }
}
