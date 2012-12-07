namespace MisSharp
{
    partial class DBToSQLScript
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBToSQLScript));
            this.GBTable = new System.Windows.Forms.GroupBox();
            this.btnSomeBack = new System.Windows.Forms.Button();
            this.btnSome = new System.Windows.Forms.Button();
            this.btnAllBack = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.lBDest = new System.Windows.Forms.ListBox();
            this.lBSource = new System.Windows.Forms.ListBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnStart = new System.Windows.Forms.Button();
            this.GBTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // GBTable
            // 
            this.GBTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GBTable.Controls.Add(this.btnSomeBack);
            this.GBTable.Controls.Add(this.btnSome);
            this.GBTable.Controls.Add(this.btnAllBack);
            this.GBTable.Controls.Add(this.btnAll);
            this.GBTable.Controls.Add(this.lBDest);
            this.GBTable.Controls.Add(this.lBSource);
            this.GBTable.Location = new System.Drawing.Point(12, 12);
            this.GBTable.Name = "GBTable";
            this.GBTable.Size = new System.Drawing.Size(477, 254);
            this.GBTable.TabIndex = 0;
            this.GBTable.TabStop = false;
            this.GBTable.Text = "GBTable";
            // 
            // btnSomeBack
            // 
            this.btnSomeBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSomeBack.Location = new System.Drawing.Point(219, 128);
            this.btnSomeBack.Name = "btnSomeBack";
            this.btnSomeBack.Size = new System.Drawing.Size(39, 30);
            this.btnSomeBack.TabIndex = 5;
            this.btnSomeBack.Text = "<";
            this.btnSomeBack.UseVisualStyleBackColor = true;
            this.btnSomeBack.Click += new System.EventHandler(this.btnSomeBack_Click);
            // 
            // btnSome
            // 
            this.btnSome.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSome.Location = new System.Drawing.Point(219, 92);
            this.btnSome.Name = "btnSome";
            this.btnSome.Size = new System.Drawing.Size(39, 30);
            this.btnSome.TabIndex = 4;
            this.btnSome.Text = ">";
            this.btnSome.UseVisualStyleBackColor = true;
            this.btnSome.Click += new System.EventHandler(this.btnSome_Click);
            // 
            // btnAllBack
            // 
            this.btnAllBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAllBack.Location = new System.Drawing.Point(219, 196);
            this.btnAllBack.Name = "btnAllBack";
            this.btnAllBack.Size = new System.Drawing.Size(39, 30);
            this.btnAllBack.TabIndex = 3;
            this.btnAllBack.Text = "<<";
            this.btnAllBack.UseVisualStyleBackColor = true;
            this.btnAllBack.Click += new System.EventHandler(this.btnAllBack_Click);
            // 
            // btnAll
            // 
            this.btnAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAll.Location = new System.Drawing.Point(219, 32);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(39, 30);
            this.btnAll.TabIndex = 2;
            this.btnAll.Text = ">>";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // lBDest
            // 
            this.lBDest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lBDest.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lBDest.FormattingEnabled = true;
            this.lBDest.ItemHeight = 14;
            this.lBDest.Location = new System.Drawing.Point(288, 20);
            this.lBDest.Name = "lBDest";
            this.lBDest.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lBDest.Size = new System.Drawing.Size(175, 214);
            this.lBDest.Sorted = true;
            this.lBDest.TabIndex = 1;
            this.lBDest.DoubleClick += new System.EventHandler(this.lBDest_DoubleClick);
            // 
            // lBSource
            // 
            this.lBSource.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lBSource.FormattingEnabled = true;
            this.lBSource.ItemHeight = 14;
            this.lBSource.Location = new System.Drawing.Point(13, 20);
            this.lBSource.Name = "lBSource";
            this.lBSource.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lBSource.Size = new System.Drawing.Size(175, 214);
            this.lBSource.Sorted = true;
            this.lBSource.TabIndex = 0;
            this.lBSource.DoubleClick += new System.EventHandler(this.lBSource_DoubleClick);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 272);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(477, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStart.Location = new System.Drawing.Point(373, 300);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(116, 28);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "开 始 生 成";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // DBToSQLScript
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 336);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.GBTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DBToSQLScript";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "生成数据脚本";
            this.GBTable.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GBTable;
        private System.Windows.Forms.Button btnSomeBack;
        private System.Windows.Forms.Button btnSome;
        private System.Windows.Forms.Button btnAllBack;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.ListBox lBDest;
        private System.Windows.Forms.ListBox lBSource;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnStart;
    }
}