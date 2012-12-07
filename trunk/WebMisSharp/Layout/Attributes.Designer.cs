namespace MisSharp
{
    partial class Attributes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Attributes));
            this.PropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.CboCurrentObject = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // PropertyGrid
            // 
            this.PropertyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PropertyGrid.Location = new System.Drawing.Point(1, 20);
            this.PropertyGrid.Name = "PropertyGrid";
            this.PropertyGrid.Size = new System.Drawing.Size(232, 387);
            this.PropertyGrid.TabIndex = 0;
            this.PropertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.PropertyGrid_PropertyValueChanged);
            // 
            // CboCurrentObject
            // 
            this.CboCurrentObject.Dock = System.Windows.Forms.DockStyle.Top;
            this.CboCurrentObject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboCurrentObject.FormattingEnabled = true;
            this.CboCurrentObject.Location = new System.Drawing.Point(0, 0);
            this.CboCurrentObject.Name = "CboCurrentObject";
            this.CboCurrentObject.Size = new System.Drawing.Size(234, 20);
            this.CboCurrentObject.TabIndex = 1;
            // 
            // Attributes
            // 
            this.AutoHidePortion = 0.16D;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 407);
            this.Controls.Add(this.CboCurrentObject);
            this.Controls.Add(this.PropertyGrid);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Attributes";
            this.ShowHint = DockPanelUI.Docking.DockState.DockRight;
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "属性";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PropertyGrid PropertyGrid;
        public System.Windows.Forms.ComboBox CboCurrentObject;

    }
}