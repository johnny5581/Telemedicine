namespace Telemedicine.Bundles
{
    partial class BundleListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BundleListForm));
            this.groupSearch = new System.Windows.Forms.GroupBox();
            this.checkDateRange = new System.Windows.Forms.CheckBox();
            this.labelDateRange = new Telemedicine.Forms.CgLabelCustomControl();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.textId = new Telemedicine.Forms.CgLabelTextBox();
            this.textPatIdentifier = new Telemedicine.Forms.CgLabelTextBox();
            this.comboPatOrg = new Telemedicine.Forms.CgLabelComboBox();
            this.buttonSearch = new Telemedicine.Forms.CgIconButton();
            this.dgvData = new Telemedicine.Forms.CgDataGridPanel();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupSearch.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupSearch
            // 
            this.groupSearch.Controls.Add(this.checkDateRange);
            this.groupSearch.Controls.Add(this.labelDateRange);
            this.groupSearch.Controls.Add(this.flowLayoutPanel1);
            this.groupSearch.Controls.Add(this.buttonSearch);
            this.groupSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupSearch.Location = new System.Drawing.Point(0, 0);
            this.groupSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupSearch.Name = "groupSearch";
            this.groupSearch.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupSearch.Size = new System.Drawing.Size(1200, 199);
            this.groupSearch.TabIndex = 6;
            this.groupSearch.TabStop = false;
            this.groupSearch.Text = "查詢條件";
            // 
            // checkDateRange
            // 
            this.checkDateRange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkDateRange.AutoSize = true;
            this.checkDateRange.Location = new System.Drawing.Point(708, 144);
            this.checkDateRange.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkDateRange.Name = "checkDateRange";
            this.checkDateRange.Size = new System.Drawing.Size(89, 22);
            this.checkDateRange.TabIndex = 11;
            this.checkDateRange.Text = "Enabled";
            this.checkDateRange.UseVisualStyleBackColor = true;
            // 
            // labelDateRange
            // 
            this.labelDateRange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelDateRange.ComponentHeight = 26;
            this.labelDateRange.Header = "日期區間";
            this.labelDateRange.HeaderAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.labelDateRange.Location = new System.Drawing.Point(10, 128);
            this.labelDateRange.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelDateRange.Name = "labelDateRange";
            this.labelDateRange.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.labelDateRange.Size = new System.Drawing.Size(688, 38);
            this.labelDateRange.TabIndex = 10;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.textId);
            this.flowLayoutPanel1.Controls.Add(this.textPatIdentifier);
            this.flowLayoutPanel1.Controls.Add(this.comboPatOrg);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(10, 32);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1050, 87);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // textId
            // 
            this.textId.Header = "#";
            this.textId.HeaderAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textId.Location = new System.Drawing.Point(4, 4);
            this.textId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textId.Name = "textId";
            this.textId.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textId.Size = new System.Drawing.Size(336, 41);
            this.textId.TabIndex = 0;
            // 
            // textPatIdentifier
            // 
            this.textPatIdentifier.Header = "病患識別碼";
            this.textPatIdentifier.HeaderAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textPatIdentifier.Location = new System.Drawing.Point(348, 4);
            this.textPatIdentifier.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textPatIdentifier.Name = "textPatIdentifier";
            this.textPatIdentifier.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textPatIdentifier.Size = new System.Drawing.Size(336, 41);
            this.textPatIdentifier.TabIndex = 4;
            // 
            // comboPatOrg
            // 
            this.comboPatOrg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPatOrg.Header = "組織";
            this.comboPatOrg.HeaderAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.comboPatOrg.Location = new System.Drawing.Point(692, 4);
            this.comboPatOrg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboPatOrg.Name = "comboPatOrg";
            this.comboPatOrg.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboPatOrg.Size = new System.Drawing.Size(336, 42);
            this.comboPatOrg.TabIndex = 6;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonSearch.Icon = "FontAwesome.Search";
            this.buttonSearch.IconMargin = 3;
            this.buttonSearch.Image = ((System.Drawing.Image)(resources.GetObject("buttonSearch.Image")));
            this.buttonSearch.Location = new System.Drawing.Point(1070, 32);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(112, 88);
            this.buttonSearch.TabIndex = 5;
            this.buttonSearch.Text = "查詢";
            this.buttonSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // dgvData
            // 
            this.dgvData.AutoFitColumnWidth = true;
            this.dgvData.ContextMenuStrip = this.contextMenuStrip;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.InfoBoxTextFormat = "{0} rows";
            this.dgvData.InfoBoxWidth = 224;
            this.dgvData.Location = new System.Drawing.Point(0, 0);
            this.dgvData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvData.Name = "dgvData";
            this.dgvData.SearchBoxWidth = 224;
            this.dgvData.Size = new System.Drawing.Size(1200, 470);
            this.dgvData.TabIndex = 4;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDelete});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(117, 34);
            // 
            // menuDelete
            // 
            this.menuDelete.Name = "menuDelete";
            this.menuDelete.Size = new System.Drawing.Size(116, 30);
            this.menuDelete.Text = "刪除";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupSearch);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvData);
            this.splitContainer1.Size = new System.Drawing.Size(1200, 675);
            this.splitContainer1.SplitterDistance = 199;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 9;
            // 
            // BundleListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 675);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "BundleListForm";
            this.Text = "查詢電子病歷文件";
            this.groupSearch.ResumeLayout(false);
            this.groupSearch.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupSearch;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Forms.CgLabelTextBox textId;
        private Forms.CgLabelTextBox textPatIdentifier;
        private Forms.CgLabelComboBox comboPatOrg;
        private Forms.CgIconButton buttonSearch;
        private Forms.CgDataGridPanel dgvData;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuDelete;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox checkDateRange;
        private Forms.CgLabelCustomControl labelDateRange;
    }
}