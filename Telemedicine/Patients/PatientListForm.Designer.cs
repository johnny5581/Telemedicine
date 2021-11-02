
namespace Telemedicine.Patients
{
    partial class PatientListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatientListForm));
            this.buttonSearch = new Telemedicine.Forms.CgIconButton();
            this.dgvData = new Telemedicine.Forms.CgDataGridPanel();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.groupSearch = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.textId = new Telemedicine.Forms.CgLabelTextBox();
            this.textIdentifier = new Telemedicine.Forms.CgLabelTextBox();
            this.textName = new Telemedicine.Forms.CgLabelTextBox();
            this.comboOrg = new Telemedicine.Forms.CgLabelComboBox();
            this.buttonClear = new Telemedicine.Forms.CgIconButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.contextMenuStrip.SuspendLayout();
            this.groupSearch.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSearch
            // 
            this.buttonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonSearch.Icon = "FontAwesome.Search";
            this.buttonSearch.IconMargin = 3;
            this.buttonSearch.IconSize = 0;
            this.buttonSearch.Image = ((System.Drawing.Image)(resources.GetObject("buttonSearch.Image")));
            this.buttonSearch.Location = new System.Drawing.Point(743, 21);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 64);
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
            this.dgvData.Size = new System.Drawing.Size(830, 380);
            this.dgvData.TabIndex = 4;
            this.dgvData.DataSelected += new Telemedicine.Forms.CgDataGridPanel.DataSelectedEventHandler(this.dgvData_DataSelected);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuEdit,
            this.menuDelete});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(99, 48);
            // 
            // menuEdit
            // 
            this.menuEdit.Name = "menuEdit";
            this.menuEdit.Size = new System.Drawing.Size(98, 22);
            this.menuEdit.Text = "修改";
            this.menuEdit.Click += new System.EventHandler(this.menuEdit_Click);
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
            this.groupSearch.Controls.Add(this.flowLayoutPanel1);
            this.groupSearch.Controls.Add(this.buttonClear);
            this.groupSearch.Controls.Add(this.buttonSearch);
            this.groupSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupSearch.Location = new System.Drawing.Point(0, 0);
            this.groupSearch.Name = "groupSearch";
            this.groupSearch.Size = new System.Drawing.Size(830, 140);
            this.groupSearch.TabIndex = 6;
            this.groupSearch.TabStop = false;
            this.groupSearch.Text = "查詢條件";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.textId);
            this.flowLayoutPanel1.Controls.Add(this.textIdentifier);
            this.flowLayoutPanel1.Controls.Add(this.textName);
            this.flowLayoutPanel1.Controls.Add(this.comboOrg);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(7, 21);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(730, 116);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // textId
            // 
            this.textId.Header = "#";
            this.textId.HeaderAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textId.Location = new System.Drawing.Point(3, 3);
            this.textId.Name = "textId";
            this.textId.Padding = new System.Windows.Forms.Padding(1);
            this.textId.Size = new System.Drawing.Size(224, 30);
            this.textId.TabIndex = 0;
            // 
            // textIdentifier
            // 
            this.textIdentifier.Header = "病患身分證";
            this.textIdentifier.HeaderAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textIdentifier.Location = new System.Drawing.Point(3, 39);
            this.textIdentifier.Name = "textIdentifier";
            this.textIdentifier.Padding = new System.Windows.Forms.Padding(1);
            this.textIdentifier.Size = new System.Drawing.Size(224, 30);
            this.textIdentifier.TabIndex = 4;
            this.textIdentifier.Text = "X123456789";
            // 
            // textName
            // 
            this.textName.Header = "病患姓名";
            this.textName.HeaderAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textName.Location = new System.Drawing.Point(3, 75);
            this.textName.Name = "textName";
            this.textName.Padding = new System.Windows.Forms.Padding(1);
            this.textName.Size = new System.Drawing.Size(224, 30);
            this.textName.TabIndex = 5;
            // 
            // comboOrg
            // 
            this.comboOrg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboOrg.Header = "病患組織";
            this.comboOrg.HeaderAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.comboOrg.Location = new System.Drawing.Point(233, 3);
            this.comboOrg.Name = "comboOrg";
            this.comboOrg.Padding = new System.Windows.Forms.Padding(1);
            this.comboOrg.Size = new System.Drawing.Size(224, 31);
            this.comboOrg.TabIndex = 6;
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonClear.Icon = "FontAwesome.File";
            this.buttonClear.IconMargin = 3;
            this.buttonClear.IconSize = 0;
            this.buttonClear.Image = ((System.Drawing.Image)(resources.GetObject("buttonClear.Image")));
            this.buttonClear.Location = new System.Drawing.Point(743, 91);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 46);
            this.buttonClear.TabIndex = 7;
            this.buttonClear.Text = "清除";
            this.buttonClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonClear.UseVisualStyleBackColor = true;
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
            this.splitContainer1.Panel1.Controls.Add(this.groupSearch);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvData);
            this.splitContainer1.Size = new System.Drawing.Size(830, 524);
            this.splitContainer1.SplitterDistance = 140;
            this.splitContainer1.TabIndex = 7;
            // 
            // PatientListForm
            // 
            this.ClientSize = new System.Drawing.Size(830, 524);
            this.Controls.Add(this.splitContainer1);
            this.Name = "PatientListForm";
            this.Text = "病患資料";
            this.contextMenuStrip.ResumeLayout(false);
            this.groupSearch.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Forms.CgDataGridPanel dgvData;
        private Forms.CgIconButton buttonSearch;
        private System.Windows.Forms.GroupBox groupSearch;
        private Forms.CgIconButton buttonClear;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Forms.CgLabelTextBox textId;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuEdit;
        private System.Windows.Forms.ToolStripMenuItem menuDelete;
        private Forms.CgLabelTextBox textIdentifier;
        private Forms.CgLabelTextBox textName;
        private Forms.CgLabelComboBox comboOrg;
    }
}