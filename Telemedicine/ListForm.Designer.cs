namespace Telemedicine
{
    partial class ListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListForm));
            this.buttonSearch = new Telemedicine.Forms.CgIconButton();
            this.dgvData = new Telemedicine.Forms.CgDataGridPanel();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.groupSearch = new System.Windows.Forms.GroupBox();
            this.panelExtra = new System.Windows.Forms.Panel();
            this.textId = new Telemedicine.Forms.CgLabelTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panelExtraCriteria = new Telemedicine.Forms.CgFlowLayoutPanel();
            this.contextMenuStrip.SuspendLayout();
            this.groupSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonSearch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonSearch.Icon = "FontAwesome.Search";
            this.buttonSearch.IconMargin = 3;
            this.buttonSearch.Image = ((System.Drawing.Image)(resources.GetObject("buttonSearch.Image")));
            this.buttonSearch.Location = new System.Drawing.Point(0, 404);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(267, 46);
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
            this.dgvData.Location = new System.Drawing.Point(0, 0);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(529, 183);
            this.dgvData.TabIndex = 4;
            this.dgvData.DataSelected += new Telemedicine.Forms.CgDataGridPanel.DataSelectedEventHandler(this.dgvData_DataSelected);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDelete});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(99, 26);
            // 
            // menuDelete
            // 
            this.menuDelete.Name = "menuDelete";
            this.menuDelete.Size = new System.Drawing.Size(98, 22);
            this.menuDelete.Text = "刪除";
            this.menuDelete.Click += new System.EventHandler(this.menuDelete_Click);
            // 
            // groupSearch
            // 
            this.groupSearch.Controls.Add(this.panelExtra);
            this.groupSearch.Controls.Add(this.panelExtraCriteria);
            this.groupSearch.Controls.Add(this.textId);
            this.groupSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupSearch.Location = new System.Drawing.Point(0, 0);
            this.groupSearch.Name = "groupSearch";
            this.groupSearch.Size = new System.Drawing.Size(267, 404);
            this.groupSearch.TabIndex = 6;
            this.groupSearch.TabStop = false;
            this.groupSearch.Text = "查詢條件";
            // 
            // panelExtra
            // 
            this.panelExtra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelExtra.Location = new System.Drawing.Point(3, 110);
            this.panelExtra.Name = "panelExtra";
            this.panelExtra.Size = new System.Drawing.Size(261, 291);
            this.panelExtra.TabIndex = 1;
            // 
            // textId
            // 
            this.textId.Dock = System.Windows.Forms.DockStyle.Top;
            this.textId.Header = "#";
            this.textId.HeaderAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textId.Location = new System.Drawing.Point(3, 18);
            this.textId.Margin = new System.Windows.Forms.Padding(0);
            this.textId.Name = "textId";
            this.textId.Size = new System.Drawing.Size(261, 30);
            this.textId.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupSearch);
            this.splitContainer1.Panel1.Controls.Add(this.buttonSearch);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 267;
            this.splitContainer1.TabIndex = 10;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgvData);
            this.splitContainer2.Size = new System.Drawing.Size(529, 450);
            this.splitContainer2.SplitterDistance = 183;
            this.splitContainer2.TabIndex = 5;
            // 
            // panelExtraCriteria
            // 
            this.panelExtraCriteria.AutoMarginSize = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.panelExtraCriteria.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelExtraCriteria.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelExtraCriteria.Location = new System.Drawing.Point(3, 48);
            this.panelExtraCriteria.Name = "panelExtraCriteria";
            this.panelExtraCriteria.Size = new System.Drawing.Size(261, 62);
            this.panelExtraCriteria.TabIndex = 2;
            this.panelExtraCriteria.WrapContents = false;
            // 
            // ListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ListForm";
            this.contextMenuStrip.ResumeLayout(false);
            this.groupSearch.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        protected Forms.CgDataGridPanel dgvData;
        protected Forms.CgLabelTextBox textId;
        protected Forms.CgIconButton buttonSearch;
        protected System.Windows.Forms.Panel panelExtra;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuDelete;
        private System.Windows.Forms.GroupBox groupSearch;
        private System.Windows.Forms.SplitContainer splitContainer1;
        protected System.Windows.Forms.SplitContainer splitContainer2;
        private Forms.CgFlowLayoutPanel panelExtraCriteria;
    }
}