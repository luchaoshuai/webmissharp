namespace WebMisSharp
{
    partial class ProjectAttributes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectAttributes));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtProDBConStr = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CboProjectDB = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnProPathPre = new System.Windows.Forms.Button();
            this.TxtProjectPath = new System.Windows.Forms.TextBox();
            this.TxtProjectName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioOther = new System.Windows.Forms.RadioButton();
            this.radioAspnetMVC = new System.Windows.Forms.RadioButton();
            this.radioSimpleThreeLayer = new System.Windows.Forms.RadioButton();
            this.BtnTryDBConnect = new System.Windows.Forms.Button();
            this.BtnSaveProject = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtProDBConStr);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.CboProjectDB);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.BtnProPathPre);
            this.groupBox1.Controls.Add(this.TxtProjectPath);
            this.groupBox1.Controls.Add(this.TxtProjectName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 171);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "项目基本信息";
            // 
            // TxtProDBConStr
            // 
            this.TxtProDBConStr.Font = new System.Drawing.Font("宋体", 8F);
            this.TxtProDBConStr.Location = new System.Drawing.Point(55, 114);
            this.TxtProDBConStr.Multiline = true;
            this.TxtProDBConStr.Name = "TxtProDBConStr";
            this.TxtProDBConStr.Size = new System.Drawing.Size(241, 48);
            this.TxtProDBConStr.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "连接串：";
            // 
            // CboProjectDB
            // 
            this.CboProjectDB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboProjectDB.FormattingEnabled = true;
            this.CboProjectDB.Location = new System.Drawing.Point(55, 87);
            this.CboProjectDB.Name = "CboProjectDB";
            this.CboProjectDB.Size = new System.Drawing.Size(241, 20);
            this.CboProjectDB.TabIndex = 6;
            this.CboProjectDB.SelectedIndexChanged += new System.EventHandler(this.CboProjectDB_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "数据库：";
            // 
            // BtnProPathPre
            // 
            this.BtnProPathPre.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BtnProPathPre.Location = new System.Drawing.Point(273, 54);
            this.BtnProPathPre.Name = "BtnProPathPre";
            this.BtnProPathPre.Size = new System.Drawing.Size(24, 23);
            this.BtnProPathPre.TabIndex = 4;
            this.BtnProPathPre.Text = "...";
            this.BtnProPathPre.UseVisualStyleBackColor = true;
            this.BtnProPathPre.Click += new System.EventHandler(this.BtnProPathPre_Click);
            // 
            // TxtProjectPath
            // 
            this.TxtProjectPath.Location = new System.Drawing.Point(55, 55);
            this.TxtProjectPath.Name = "TxtProjectPath";
            this.TxtProjectPath.ReadOnly = true;
            this.TxtProjectPath.Size = new System.Drawing.Size(215, 21);
            this.TxtProjectPath.TabIndex = 3;
            // 
            // TxtProjectName
            // 
            this.TxtProjectName.Location = new System.Drawing.Point(55, 28);
            this.TxtProjectName.Name = "TxtProjectName";
            this.TxtProjectName.Size = new System.Drawing.Size(241, 21);
            this.TxtProjectName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "路径：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "名称：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioOther);
            this.groupBox2.Controls.Add(this.radioAspnetMVC);
            this.groupBox2.Controls.Add(this.radioSimpleThreeLayer);
            this.groupBox2.Location = new System.Drawing.Point(331, 95);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(155, 136);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "项目框架";
            // 
            // radioOther
            // 
            this.radioOther.AutoSize = true;
            this.radioOther.Location = new System.Drawing.Point(13, 97);
            this.radioOther.Name = "radioOther";
            this.radioOther.Size = new System.Drawing.Size(65, 16);
            this.radioOther.TabIndex = 3;
            this.radioOther.Text = "其他...";
            this.radioOther.UseVisualStyleBackColor = true;
            // 
            // radioAspnetMVC
            // 
            this.radioAspnetMVC.AutoSize = true;
            this.radioAspnetMVC.Location = new System.Drawing.Point(13, 61);
            this.radioAspnetMVC.Name = "radioAspnetMVC";
            this.radioAspnetMVC.Size = new System.Drawing.Size(119, 16);
            this.radioAspnetMVC.TabIndex = 2;
            this.radioAspnetMVC.Text = "MVC_Rest[JQuery]";
            this.radioAspnetMVC.UseVisualStyleBackColor = true;
            // 
            // radioSimpleThreeLayer
            // 
            this.radioSimpleThreeLayer.AutoSize = true;
            this.radioSimpleThreeLayer.Checked = true;
            this.radioSimpleThreeLayer.Location = new System.Drawing.Point(13, 25);
            this.radioSimpleThreeLayer.Name = "radioSimpleThreeLayer";
            this.radioSimpleThreeLayer.Size = new System.Drawing.Size(125, 16);
            this.radioSimpleThreeLayer.TabIndex = 0;
            this.radioSimpleThreeLayer.TabStop = true;
            this.radioSimpleThreeLayer.Text = "简单三层[Ext.net]";
            this.radioSimpleThreeLayer.UseVisualStyleBackColor = true;
            // 
            // BtnTryDBConnect
            // 
            this.BtnTryDBConnect.Location = new System.Drawing.Point(331, 234);
            this.BtnTryDBConnect.Name = "BtnTryDBConnect";
            this.BtnTryDBConnect.Size = new System.Drawing.Size(75, 30);
            this.BtnTryDBConnect.TabIndex = 2;
            this.BtnTryDBConnect.Text = "测试连接";
            this.BtnTryDBConnect.UseVisualStyleBackColor = true;
            this.BtnTryDBConnect.Click += new System.EventHandler(this.BtnTryDBConnect_Click);
            // 
            // BtnSaveProject
            // 
            this.BtnSaveProject.Location = new System.Drawing.Point(412, 234);
            this.BtnSaveProject.Name = "BtnSaveProject";
            this.BtnSaveProject.Size = new System.Drawing.Size(74, 30);
            this.BtnSaveProject.TabIndex = 3;
            this.BtnSaveProject.Text = "保存项目";
            this.BtnSaveProject.UseVisualStyleBackColor = true;
            this.BtnSaveProject.Click += new System.EventHandler(this.BtnSaveProject_Click);
            // 
            // ProjectAttributes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(498, 276);
            this.Controls.Add(this.BtnSaveProject);
            this.Controls.Add(this.BtnTryDBConnect);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProjectAttributes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新建项目";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TxtProDBConStr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CboProjectDB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnProPathPre;
        private System.Windows.Forms.TextBox TxtProjectPath;
        private System.Windows.Forms.TextBox TxtProjectName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioOther;
        private System.Windows.Forms.RadioButton radioAspnetMVC;
        private System.Windows.Forms.RadioButton radioSimpleThreeLayer;
        private System.Windows.Forms.Button BtnTryDBConnect;
        private System.Windows.Forms.Button BtnSaveProject;
    }
}