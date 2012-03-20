namespace WebMisSharp
{
    partial class TableInfo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableInfo));
            this.DGridTableStruct = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FieldDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Form = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnCreateTabDict = new System.Windows.Forms.Button();
            this.BtnSaveFieldRemark = new System.Windows.Forms.Button();
            this.TxtDBAutoID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnCreateCodeNeWin = new System.Windows.Forms.Button();
            this.BtnCreateCode2Proj = new System.Windows.Forms.Button();
            this.CBWeb = new System.Windows.Forms.CheckBox();
            this.CBModel = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TxtModelName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnConfigCbo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtAspxName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.NUDColumns = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGridTableStruct)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDColumns)).BeginInit();
            this.SuspendLayout();
            // 
            // DGridTableStruct
            // 
            this.DGridTableStruct.AllowUserToAddRows = false;
            this.DGridTableStruct.AllowUserToDeleteRows = false;
            this.DGridTableStruct.AllowUserToResizeColumns = false;
            this.DGridTableStruct.AllowUserToResizeRows = false;
            this.DGridTableStruct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DGridTableStruct.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGridTableStruct.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DGridTableStruct.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DGridTableStruct.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGridTableStruct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGridTableStruct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Column1,
            this.FieldDesc,
            this.FieldName,
            this.Form,
            this.Column9,
            this.Column8,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column10,
            this.Column11,
            this.Tid,
            this.Cid});
            this.DGridTableStruct.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DGridTableStruct.Location = new System.Drawing.Point(12, 12);
            this.DGridTableStruct.Name = "DGridTableStruct";
            this.DGridTableStruct.RowHeadersVisible = false;
            this.DGridTableStruct.RowTemplate.Height = 23;
            this.DGridTableStruct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGridTableStruct.Size = new System.Drawing.Size(715, 196);
            this.DGridTableStruct.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.Frozen = true;
            this.ID.HeaderText = "选择";
            this.ID.IndeterminateValue = "true";
            this.ID.Name = "ID";
            this.ID.ToolTipText = "是否参与Web页面编辑";
            this.ID.Width = 35;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "序号";
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "序号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 35;
            // 
            // FieldDesc
            // 
            this.FieldDesc.DataPropertyName = "说明";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.FieldDesc.DefaultCellStyle = dataGridViewCellStyle1;
            this.FieldDesc.Frozen = true;
            this.FieldDesc.HeaderText = "说明";
            this.FieldDesc.Name = "FieldDesc";
            this.FieldDesc.Width = 54;
            // 
            // FieldName
            // 
            this.FieldName.DataPropertyName = "字段名";
            this.FieldName.Frozen = true;
            this.FieldName.HeaderText = "字段名";
            this.FieldName.Name = "FieldName";
            this.FieldName.ReadOnly = true;
            this.FieldName.Width = 66;
            // 
            // Form
            // 
            this.Form.DataPropertyName = "Form";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Form.DefaultCellStyle = dataGridViewCellStyle2;
            this.Form.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.Form.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Form.Frozen = true;
            this.Form.HeaderText = "Form类型";
            this.Form.Items.AddRange(new object[] {
            "TextField",
            "DateField",
            "NumberField",
            "ComboBox",
            "MultiCombo",
            "TextArea"});
            this.Form.Name = "Form";
            this.Form.ToolTipText = "选择表单类型";
            this.Form.Width = 59;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "主键";
            this.Column9.HeaderText = "主键";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 54;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "标识";
            this.Column8.HeaderText = "标识";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 54;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "字段类型";
            this.Column4.HeaderText = "字段类型";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 78;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "长度";
            this.Column5.HeaderText = "长度";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 54;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "占用字节数";
            this.Column6.HeaderText = "占用字节数";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 90;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "小数位数";
            this.Column7.HeaderText = "小数位数";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 78;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "允许为空";
            this.Column10.HeaderText = "允许为空";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 78;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "默认值";
            this.Column11.HeaderText = "默认值";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Width = 66;
            // 
            // Tid
            // 
            this.Tid.DataPropertyName = "Tid";
            this.Tid.HeaderText = "Tid";
            this.Tid.Name = "Tid";
            this.Tid.ReadOnly = true;
            this.Tid.Visible = false;
            this.Tid.Width = 48;
            // 
            // Cid
            // 
            this.Cid.DataPropertyName = "Cid";
            this.Cid.HeaderText = "Cid";
            this.Cid.Name = "Cid";
            this.Cid.ReadOnly = true;
            this.Cid.Visible = false;
            this.Cid.Width = 48;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.BtnCreateTabDict);
            this.groupBox1.Controls.Add(this.BtnSaveFieldRemark);
            this.groupBox1.Controls.Add(this.TxtDBAutoID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 215);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(714, 64);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "必备条件";
            // 
            // BtnCreateTabDict
            // 
            this.BtnCreateTabDict.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnCreateTabDict.Location = new System.Drawing.Point(371, 18);
            this.BtnCreateTabDict.Name = "BtnCreateTabDict";
            this.BtnCreateTabDict.Size = new System.Drawing.Size(147, 37);
            this.BtnCreateTabDict.TabIndex = 3;
            this.BtnCreateTabDict.Text = "生成本表数据字典";
            this.BtnCreateTabDict.UseVisualStyleBackColor = true;
            // 
            // BtnSaveFieldRemark
            // 
            this.BtnSaveFieldRemark.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnSaveFieldRemark.Location = new System.Drawing.Point(204, 18);
            this.BtnSaveFieldRemark.Name = "BtnSaveFieldRemark";
            this.BtnSaveFieldRemark.Size = new System.Drawing.Size(147, 37);
            this.BtnSaveFieldRemark.TabIndex = 2;
            this.BtnSaveFieldRemark.Text = "保存表字段说明信息";
            this.BtnSaveFieldRemark.UseVisualStyleBackColor = true;
            this.BtnSaveFieldRemark.Click += new System.EventHandler(this.BtnSaveFieldRemark_Click);
            // 
            // TxtDBAutoID
            // 
            this.TxtDBAutoID.Location = new System.Drawing.Point(84, 27);
            this.TxtDBAutoID.Name = "TxtDBAutoID";
            this.TxtDBAutoID.Size = new System.Drawing.Size(100, 21);
            this.TxtDBAutoID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "自增ID字段：";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.BtnCreateCodeNeWin);
            this.groupBox2.Controls.Add(this.BtnCreateCode2Proj);
            this.groupBox2.Controls.Add(this.CBWeb);
            this.groupBox2.Controls.Add(this.CBModel);
            this.groupBox2.Location = new System.Drawing.Point(13, 285);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(714, 69);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "生成选项";
            // 
            // BtnCreateCodeNeWin
            // 
            this.BtnCreateCodeNeWin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnCreateCodeNeWin.Location = new System.Drawing.Point(204, 19);
            this.BtnCreateCodeNeWin.Name = "BtnCreateCodeNeWin";
            this.BtnCreateCodeNeWin.Size = new System.Drawing.Size(147, 37);
            this.BtnCreateCodeNeWin.TabIndex = 5;
            this.BtnCreateCodeNeWin.Text = "生成到新窗口";
            this.BtnCreateCodeNeWin.UseVisualStyleBackColor = true;
            // 
            // BtnCreateCode2Proj
            // 
            this.BtnCreateCode2Proj.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnCreateCode2Proj.Location = new System.Drawing.Point(371, 19);
            this.BtnCreateCode2Proj.Name = "BtnCreateCode2Proj";
            this.BtnCreateCode2Proj.Size = new System.Drawing.Size(147, 37);
            this.BtnCreateCode2Proj.TabIndex = 4;
            this.BtnCreateCode2Proj.Text = "生成到项目";
            this.BtnCreateCode2Proj.UseVisualStyleBackColor = true;
            this.BtnCreateCode2Proj.Click += new System.EventHandler(this.BtnCreateCode2Proj_Click);
            // 
            // CBWeb
            // 
            this.CBWeb.AutoSize = true;
            this.CBWeb.Checked = true;
            this.CBWeb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CBWeb.Location = new System.Drawing.Point(119, 30);
            this.CBWeb.Name = "CBWeb";
            this.CBWeb.Size = new System.Drawing.Size(42, 16);
            this.CBWeb.TabIndex = 1;
            this.CBWeb.Text = "Web";
            this.CBWeb.UseVisualStyleBackColor = true;
            // 
            // CBModel
            // 
            this.CBModel.AutoSize = true;
            this.CBModel.Checked = true;
            this.CBModel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CBModel.Location = new System.Drawing.Point(33, 30);
            this.CBModel.Name = "CBModel";
            this.CBModel.Size = new System.Drawing.Size(54, 16);
            this.CBModel.TabIndex = 0;
            this.CBModel.Text = "Model";
            this.CBModel.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.TxtModelName);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.BtnConfigCbo);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.TxtAspxName);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.NUDColumns);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(13, 360);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(714, 93);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Web页面配置";
            // 
            // TxtModelName
            // 
            this.TxtModelName.Location = new System.Drawing.Point(88, 27);
            this.TxtModelName.Name = "TxtModelName";
            this.TxtModelName.Size = new System.Drawing.Size(96, 21);
            this.TxtModelName.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "Model实体名：";
            // 
            // BtnConfigCbo
            // 
            this.BtnConfigCbo.Location = new System.Drawing.Point(558, 30);
            this.BtnConfigCbo.Name = "BtnConfigCbo";
            this.BtnConfigCbo.Size = new System.Drawing.Size(99, 36);
            this.BtnConfigCbo.TabIndex = 9;
            this.BtnConfigCbo.Text = "配置下拉列表";
            this.BtnConfigCbo.UseVisualStyleBackColor = true;
            this.BtnConfigCbo.Click += new System.EventHandler(this.BtnConfigCbo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(483, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = ".aspx";
            // 
            // TxtAspxName
            // 
            this.TxtAspxName.Location = new System.Drawing.Point(320, 26);
            this.TxtAspxName.Name = "TxtAspxName";
            this.TxtAspxName.Size = new System.Drawing.Size(166, 21);
            this.TxtAspxName.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(202, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "文件名：/Web/Admin/";
            // 
            // NUDColumns
            // 
            this.NUDColumns.Location = new System.Drawing.Point(88, 59);
            this.NUDColumns.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NUDColumns.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDColumns.Name = "NUDColumns";
            this.NUDColumns.Size = new System.Drawing.Size(43, 21);
            this.NUDColumns.TabIndex = 1;
            this.NUDColumns.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "WinForm列数：";
            // 
            // TableInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 465);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DGridTableStruct);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TableInfo";
            this.Text = "表结构明细";
            this.Load += new System.EventHandler(this.TableInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGridTableStruct)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDColumns)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGridTableStruct;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnCreateTabDict;
        private System.Windows.Forms.Button BtnSaveFieldRemark;
        private System.Windows.Forms.TextBox TxtDBAutoID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnCreateCodeNeWin;
        private System.Windows.Forms.Button BtnCreateCode2Proj;
        private System.Windows.Forms.CheckBox CBWeb;
        private System.Windows.Forms.CheckBox CBModel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox TxtAspxName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown NUDColumns;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnConfigCbo;
        private System.Windows.Forms.TextBox TxtModelName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FieldDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn FieldName;
        private System.Windows.Forms.DataGridViewComboBoxColumn Form;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cid;
    }
}