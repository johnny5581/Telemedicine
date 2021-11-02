
namespace Telemedicine.Observations
{
    partial class ObservationListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ObservationListForm));
            this.buttonSearch = new Telemedicine.Forms.CgIconButton();
            this.dgvData = new Telemedicine.Forms.CgDataGridPanel();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.groupSearch = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.textId = new Telemedicine.Forms.CgLabelTextBox();
            this.comboVitalSign = new Telemedicine.Forms.CgLabelComboBox();
            this.textSubject = new Telemedicine.Forms.CgLabelTextBox();
            this.textPatIdentifier = new Telemedicine.Forms.CgLabelTextBox();
            this.textPatName = new Telemedicine.Forms.CgLabelTextBox();
            this.comboPatOrg = new Telemedicine.Forms.CgLabelComboBox();
            this.buttonClear = new Telemedicine.Forms.CgIconButton();
            this.labelDateRange = new Telemedicine.Forms.CgLabelCustomControl();
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
            this.buttonSearch.Location = new System.Drawing.Point(689, 21);
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
            this.dgvData.Size = new System.Drawing.Size(776, 372);
            this.dgvData.TabIndex = 4;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuEdit,
            this.menuDelete});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(181, 70);
            // 
            // menuEdit
            // 
            this.menuEdit.Name = "menuEdit";
            this.menuEdit.Size = new System.Drawing.Size(180, 22);
            this.menuEdit.Text = "修改";
            this.menuEdit.Click += new System.EventHandler(this.menuEdit_Click);
            // 
            // menuDelete
            // 
            this.menuDelete.Name = "menuDelete";
            this.menuDelete.Size = new System.Drawing.Size(180, 22);
            this.menuDelete.Text = "刪除";
            this.menuDelete.Click += new System.EventHandler(this.menuDelete_Click);
            // 
            // groupSearch
            // 
            this.groupSearch.Controls.Add(this.flowLayoutPanel1);
            this.groupSearch.Controls.Add(this.buttonClear);
            this.groupSearch.Controls.Add(this.buttonSearch);
            this.groupSearch.Controls.Add(this.labelDateRange);
            this.groupSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupSearch.Location = new System.Drawing.Point(0, 0);
            this.groupSearch.Name = "groupSearch";
            this.groupSearch.Size = new System.Drawing.Size(776, 148);
            this.groupSearch.TabIndex = 6;
            this.groupSearch.TabStop = false;
            this.groupSearch.Text = "查詢條件";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.textId);
            this.flowLayoutPanel1.Controls.Add(this.comboVitalSign);
            this.flowLayoutPanel1.Controls.Add(this.textSubject);
            this.flowLayoutPanel1.Controls.Add(this.textPatIdentifier);
            this.flowLayoutPanel1.Controls.Add(this.textPatName);
            this.flowLayoutPanel1.Controls.Add(this.comboPatOrg);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(7, 21);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(676, 87);
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
            // comboVitalSign
            // 
            this.comboVitalSign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboVitalSign.Header = "類別";
            this.comboVitalSign.HeaderAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.comboVitalSign.Location = new System.Drawing.Point(3, 39);
            this.comboVitalSign.Name = "comboVitalSign";
            this.comboVitalSign.Padding = new System.Windows.Forms.Padding(1);
            this.comboVitalSign.Size = new System.Drawing.Size(224, 31);
            this.comboVitalSign.TabIndex = 2;
            // 
            // textSubject
            // 
            this.textSubject.Header = "病患ID";
            this.textSubject.HeaderAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textSubject.Location = new System.Drawing.Point(233, 3);
            this.textSubject.Name = "textSubject";
            this.textSubject.Padding = new System.Windows.Forms.Padding(1);
            this.textSubject.Size = new System.Drawing.Size(224, 30);
            this.textSubject.TabIndex = 3;
            // 
            // textPatIdentifier
            // 
            this.textPatIdentifier.Header = "病患身分證";
            this.textPatIdentifier.HeaderAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textPatIdentifier.Location = new System.Drawing.Point(233, 39);
            this.textPatIdentifier.Name = "textPatIdentifier";
            this.textPatIdentifier.Padding = new System.Windows.Forms.Padding(1);
            this.textPatIdentifier.Size = new System.Drawing.Size(224, 30);
            this.textPatIdentifier.TabIndex = 4;
            // 
            // textPatName
            // 
            this.textPatName.Header = "病患姓名";
            this.textPatName.HeaderAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textPatName.Location = new System.Drawing.Point(463, 3);
            this.textPatName.Name = "textPatName";
            this.textPatName.Padding = new System.Windows.Forms.Padding(1);
            this.textPatName.Size = new System.Drawing.Size(194, 30);
            this.textPatName.TabIndex = 5;
            // 
            // comboPatOrg
            // 
            this.comboPatOrg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPatOrg.Header = "病患組織";
            this.comboPatOrg.HeaderAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.comboPatOrg.Location = new System.Drawing.Point(463, 39);
            this.comboPatOrg.Name = "comboPatOrg";
            this.comboPatOrg.Padding = new System.Windows.Forms.Padding(1);
            this.comboPatOrg.Size = new System.Drawing.Size(194, 31);
            this.comboPatOrg.TabIndex = 6;
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonClear.Icon = "FontAwesome.File";
            this.buttonClear.IconMargin = 3;
            this.buttonClear.IconSize = 0;
            this.buttonClear.Image = ((System.Drawing.Image)(resources.GetObject("buttonClear.Image")));
            this.buttonClear.Location = new System.Drawing.Point(689, 91);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 46);
            this.buttonClear.TabIndex = 7;
            this.buttonClear.Text = "清除";
            this.buttonClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonClear.UseVisualStyleBackColor = true;
            // 
            // labelDateRange
            // 
            this.labelDateRange.ComponentHeight = 26;
            this.labelDateRange.Header = "日期區間";
            this.labelDateRange.HeaderAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.labelDateRange.Location = new System.Drawing.Point(6, 111);
            this.labelDateRange.Name = "labelDateRange";
            this.labelDateRange.Padding = new System.Windows.Forms.Padding(1);
            this.labelDateRange.Size = new System.Drawing.Size(458, 34);
            this.labelDateRange.TabIndex = 5;
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
            this.splitContainer1.Size = new System.Drawing.Size(776, 524);
            this.splitContainer1.SplitterDistance = 148;
            this.splitContainer1.TabIndex = 7;
            // 
            // ObservationListForm
            // 
            this.ClientSize = new System.Drawing.Size(776, 524);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ObservationListForm";
            this.Text = "生理數值";
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
        private Forms.CgLabelComboBox comboVitalSign;
        private Forms.CgLabelTextBox textSubject;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuEdit;
        private System.Windows.Forms.ToolStripMenuItem menuDelete;
        private Forms.CgLabelTextBox textPatIdentifier;
        private Forms.CgLabelCustomControl labelDateRange;
        private Forms.CgLabelTextBox textPatName;
        private Forms.CgLabelComboBox comboPatOrg;
    }
}