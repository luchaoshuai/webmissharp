namespace WebMisSharp
{
    partial class ConfigComBoxStore
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DGVComboxStore = new System.Windows.Forms.DataGridView();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.FieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FieldDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TableName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Display = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Conditions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGVComboxStore)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVComboxStore
            // 
            this.DGVComboxStore.AllowUserToAddRows = false;
            this.DGVComboxStore.AllowUserToDeleteRows = false;
            this.DGVComboxStore.AllowUserToResizeRows = false;
            this.DGVComboxStore.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.DGVComboxStore.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVComboxStore.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DGVComboxStore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVComboxStore.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FieldName,
            this.FieldDesc,
            this.TableName,
            this.Display,
            this.Value,
            this.Conditions});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVComboxStore.DefaultCellStyle = dataGridViewCellStyle5;
            this.DGVComboxStore.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DGVComboxStore.GridColor = System.Drawing.Color.White;
            this.DGVComboxStore.Location = new System.Drawing.Point(12, 12);
            this.DGVComboxStore.MultiSelect = false;
            this.DGVComboxStore.Name = "DGVComboxStore";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVComboxStore.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.DGVComboxStore.RowHeadersVisible = false;
            this.DGVComboxStore.RowTemplate.Height = 23;
            this.DGVComboxStore.Size = new System.Drawing.Size(540, 215);
            this.DGVComboxStore.TabIndex = 0;
            this.DGVComboxStore.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVComboxStore_CellValueChanged);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(477, 233);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 1;
            this.BtnCancel.Text = "取 消";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(396, 233);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 2;
            this.BtnSave.Text = "确 定";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // FieldName
            // 
            this.FieldName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FieldName.DataPropertyName = "FieldName";
            this.FieldName.Frozen = true;
            this.FieldName.HeaderText = "字段名";
            this.FieldName.Name = "FieldName";
            this.FieldName.ReadOnly = true;
            this.FieldName.Width = 66;
            // 
            // FieldDesc
            // 
            this.FieldDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FieldDesc.DataPropertyName = "FieldDesc";
            this.FieldDesc.Frozen = true;
            this.FieldDesc.HeaderText = "字段描述";
            this.FieldDesc.Name = "FieldDesc";
            this.FieldDesc.ReadOnly = true;
            this.FieldDesc.Width = 78;
            // 
            // TableName
            // 
            this.TableName.DataPropertyName = "TableName";
            this.TableName.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.TableName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.TableName.HeaderText = "Store来源";
            this.TableName.Name = "TableName";
            // 
            // Display
            // 
            this.Display.DataPropertyName = "Display";
            this.Display.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.Display.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Display.HeaderText = "Display";
            this.Display.Name = "Display";
            // 
            // Value
            // 
            this.Value.DataPropertyName = "Value";
            this.Value.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.Value.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            // 
            // Conditions
            // 
            this.Conditions.DataPropertyName = "Conditions";
            this.Conditions.HeaderText = "查询条件";
            this.Conditions.Name = "Conditions";
            this.Conditions.Width = 93;
            // 
            // ConfigComBoxStore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 262);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.DGVComboxStore);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigComBoxStore";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "下拉列表Store配置";
            this.Load += new System.EventHandler(this.ConfigComBoxStore_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVComboxStore)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVComboxStore;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn FieldName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FieldDesc;
        private System.Windows.Forms.DataGridViewComboBoxColumn TableName;
        private System.Windows.Forms.DataGridViewComboBoxColumn Display;
        private System.Windows.Forms.DataGridViewComboBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn Conditions;
    }
}