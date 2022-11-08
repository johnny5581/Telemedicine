namespace Telemedicine.Laboratories
{
    partial class LabCreateForm
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
            this.pracControl1 = new Telemedicine.Practitioners.PracControl();
            this.orgControl1 = new Telemedicine.Orgs.OrgControl();
            this.patientControl1 = new Telemedicine.Patients.PatientControl();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cgFlowLayoutPanel1 = new Telemedicine.Forms.CgFlowLayoutPanel();
            this.textLabItid = new Telemedicine.Forms.CgLabelTextBox();
            this.textLabItnm = new Telemedicine.Forms.CgLabelTextBox();
            this.textLabId = new Telemedicine.Forms.CgLabelTextBox();
            this.textLabSrc = new Telemedicine.Forms.CgLabelTextBox();
            this.textLabSrcDesc = new Telemedicine.Forms.CgLabelTextBox();
            this.textLabCategory = new Telemedicine.Forms.CgLabelTextBox();
            this.textLabCategoryDesc = new Telemedicine.Forms.CgLabelTextBox();
            this.textLabDat = new Telemedicine.Forms.CgLabelTextBox();
            this.textRcvDat = new Telemedicine.Forms.CgLabelTextBox();
            this.textRptDat = new Telemedicine.Forms.CgLabelTextBox();
            this.textLabRslt = new Telemedicine.Forms.CgLabelTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cgFlowLayoutPanel2 = new Telemedicine.Forms.CgFlowLayoutPanel();
            this.textRptTitle = new Telemedicine.Forms.CgLabelTextBox();
            this.buttonCreate = new Telemedicine.Forms.CgIconButton();
            this.cgIconButton1 = new Telemedicine.Forms.CgIconButton();
            this.groupBox3.SuspendLayout();
            this.cgFlowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.cgFlowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pracControl1
            // 
            this.pracControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pracControl1.Location = new System.Drawing.Point(20, 489);
            this.pracControl1.Margin = new System.Windows.Forms.Padding(6);
            this.pracControl1.Name = "pracControl1";
            this.pracControl1.Size = new System.Drawing.Size(399, 168);
            this.pracControl1.TabIndex = 14;
            this.pracControl1.Title = "Practitioner";
            // 
            // orgControl1
            // 
            this.orgControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.orgControl1.Location = new System.Drawing.Point(18, 352);
            this.orgControl1.Margin = new System.Windows.Forms.Padding(6);
            this.orgControl1.Name = "orgControl1";
            this.orgControl1.Size = new System.Drawing.Size(400, 128);
            this.orgControl1.TabIndex = 13;
            this.orgControl1.Title = "Organization";
            // 
            // patientControl1
            // 
            this.patientControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.patientControl1.Location = new System.Drawing.Point(18, 18);
            this.patientControl1.Margin = new System.Windows.Forms.Padding(6);
            this.patientControl1.Name = "patientControl1";
            this.patientControl1.Size = new System.Drawing.Size(400, 326);
            this.patientControl1.TabIndex = 12;
            this.patientControl1.Title = "Patient";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.cgFlowLayoutPanel1);
            this.groupBox3.Location = new System.Drawing.Point(428, 18);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(402, 639);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "檢驗";
            // 
            // cgFlowLayoutPanel1
            // 
            this.cgFlowLayoutPanel1.AutoMargin = true;
            this.cgFlowLayoutPanel1.AutoMarginSize = new System.Windows.Forms.Padding(0);
            this.cgFlowLayoutPanel1.AutoResizeChild = true;
            this.cgFlowLayoutPanel1.Controls.Add(this.textLabItid);
            this.cgFlowLayoutPanel1.Controls.Add(this.textLabItnm);
            this.cgFlowLayoutPanel1.Controls.Add(this.textLabId);
            this.cgFlowLayoutPanel1.Controls.Add(this.textLabSrc);
            this.cgFlowLayoutPanel1.Controls.Add(this.textLabSrcDesc);
            this.cgFlowLayoutPanel1.Controls.Add(this.textLabCategory);
            this.cgFlowLayoutPanel1.Controls.Add(this.textLabCategoryDesc);
            this.cgFlowLayoutPanel1.Controls.Add(this.textLabDat);
            this.cgFlowLayoutPanel1.Controls.Add(this.textRcvDat);
            this.cgFlowLayoutPanel1.Controls.Add(this.textRptDat);
            this.cgFlowLayoutPanel1.Controls.Add(this.textLabRslt);
            this.cgFlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cgFlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.cgFlowLayoutPanel1.Location = new System.Drawing.Point(4, 26);
            this.cgFlowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.cgFlowLayoutPanel1.Name = "cgFlowLayoutPanel1";
            this.cgFlowLayoutPanel1.Size = new System.Drawing.Size(394, 609);
            this.cgFlowLayoutPanel1.TabIndex = 0;
            this.cgFlowLayoutPanel1.WrapContents = false;
            // 
            // textLabItid
            // 
            this.textLabItid.Header = "檢驗項目";
            this.textLabItid.Location = new System.Drawing.Point(4, 4);
            this.textLabItid.Margin = new System.Windows.Forms.Padding(4);
            this.textLabItid.Name = "textLabItid";
            this.textLabItid.Padding = new System.Windows.Forms.Padding(2);
            this.textLabItid.Size = new System.Drawing.Size(334, 39);
            this.textLabItid.TabIndex = 11;
            this.textLabItid.Text = "11502-2";
            // 
            // textLabItnm
            // 
            this.textLabItnm.Header = "檢驗項目名稱";
            this.textLabItnm.Location = new System.Drawing.Point(4, 51);
            this.textLabItnm.Margin = new System.Windows.Forms.Padding(4);
            this.textLabItnm.Name = "textLabItnm";
            this.textLabItnm.Padding = new System.Windows.Forms.Padding(2);
            this.textLabItnm.Size = new System.Drawing.Size(334, 39);
            this.textLabItnm.TabIndex = 12;
            this.textLabItnm.Text = "Laboratory report.total";
            // 
            // textLabId
            // 
            this.textLabId.Header = "檢驗單號";
            this.textLabId.Location = new System.Drawing.Point(4, 98);
            this.textLabId.Margin = new System.Windows.Forms.Padding(4);
            this.textLabId.Name = "textLabId";
            this.textLabId.Padding = new System.Windows.Forms.Padding(2);
            this.textLabId.Size = new System.Drawing.Size(334, 39);
            this.textLabId.TabIndex = 2;
            // 
            // textLabSrc
            // 
            this.textLabSrc.Header = "檢體來源";
            this.textLabSrc.Location = new System.Drawing.Point(4, 145);
            this.textLabSrc.Margin = new System.Windows.Forms.Padding(4);
            this.textLabSrc.Name = "textLabSrc";
            this.textLabSrc.Padding = new System.Windows.Forms.Padding(2);
            this.textLabSrc.Size = new System.Drawing.Size(334, 39);
            this.textLabSrc.TabIndex = 0;
            this.textLabSrc.Text = "49852007";
            // 
            // textLabSrcDesc
            // 
            this.textLabSrcDesc.Header = "檢體來源說明";
            this.textLabSrcDesc.Location = new System.Drawing.Point(4, 192);
            this.textLabSrcDesc.Margin = new System.Windows.Forms.Padding(4);
            this.textLabSrcDesc.Name = "textLabSrcDesc";
            this.textLabSrcDesc.Padding = new System.Windows.Forms.Padding(2);
            this.textLabSrcDesc.Size = new System.Drawing.Size(334, 39);
            this.textLabSrcDesc.TabIndex = 13;
            this.textLabSrcDesc.Text = "Structure of median cubital vein (body structure)";
            // 
            // textLabCategory
            // 
            this.textLabCategory.Header = "檢體類別";
            this.textLabCategory.Location = new System.Drawing.Point(4, 239);
            this.textLabCategory.Margin = new System.Windows.Forms.Padding(4);
            this.textLabCategory.Name = "textLabCategory";
            this.textLabCategory.Padding = new System.Windows.Forms.Padding(2);
            this.textLabCategory.Size = new System.Drawing.Size(334, 39);
            this.textLabCategory.TabIndex = 4;
            this.textLabCategory.Text = "BLD";
            // 
            // textLabCategoryDesc
            // 
            this.textLabCategoryDesc.Header = "檢體類別說明";
            this.textLabCategoryDesc.Location = new System.Drawing.Point(4, 286);
            this.textLabCategoryDesc.Margin = new System.Windows.Forms.Padding(4);
            this.textLabCategoryDesc.Name = "textLabCategoryDesc";
            this.textLabCategoryDesc.Padding = new System.Windows.Forms.Padding(2);
            this.textLabCategoryDesc.Size = new System.Drawing.Size(334, 39);
            this.textLabCategoryDesc.TabIndex = 5;
            this.textLabCategoryDesc.Text = "Whole blood";
            // 
            // textLabDat
            // 
            this.textLabDat.Header = "採檢日";
            this.textLabDat.Location = new System.Drawing.Point(4, 333);
            this.textLabDat.Margin = new System.Windows.Forms.Padding(4);
            this.textLabDat.Name = "textLabDat";
            this.textLabDat.Padding = new System.Windows.Forms.Padding(2);
            this.textLabDat.Size = new System.Drawing.Size(334, 39);
            this.textLabDat.TabIndex = 6;
            this.textLabDat.Text = "2022-11-06";
            // 
            // textRcvDat
            // 
            this.textRcvDat.Header = "簽收日";
            this.textRcvDat.Location = new System.Drawing.Point(4, 380);
            this.textRcvDat.Margin = new System.Windows.Forms.Padding(4);
            this.textRcvDat.Name = "textRcvDat";
            this.textRcvDat.Padding = new System.Windows.Forms.Padding(2);
            this.textRcvDat.Size = new System.Drawing.Size(334, 39);
            this.textRcvDat.TabIndex = 7;
            this.textRcvDat.Text = "2022-11-07";
            // 
            // textRptDat
            // 
            this.textRptDat.Header = "報告日";
            this.textRptDat.Location = new System.Drawing.Point(4, 427);
            this.textRptDat.Margin = new System.Windows.Forms.Padding(4);
            this.textRptDat.Name = "textRptDat";
            this.textRptDat.Padding = new System.Windows.Forms.Padding(2);
            this.textRptDat.Size = new System.Drawing.Size(334, 39);
            this.textRptDat.TabIndex = 8;
            this.textRptDat.Text = "2022-11-08";
            // 
            // textLabRslt
            // 
            this.textLabRslt.Header = "檢驗結果/值";
            this.textLabRslt.Location = new System.Drawing.Point(4, 474);
            this.textLabRslt.Margin = new System.Windows.Forms.Padding(4);
            this.textLabRslt.Name = "textLabRslt";
            this.textLabRslt.Padding = new System.Windows.Forms.Padding(2);
            this.textLabRslt.Size = new System.Drawing.Size(334, 39);
            this.textLabRslt.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cgFlowLayoutPanel2);
            this.groupBox1.Location = new System.Drawing.Point(838, 18);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(344, 150);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "報告";
            // 
            // cgFlowLayoutPanel2
            // 
            this.cgFlowLayoutPanel2.AutoMargin = true;
            this.cgFlowLayoutPanel2.AutoMarginSize = new System.Windows.Forms.Padding(0);
            this.cgFlowLayoutPanel2.AutoResizeChild = true;
            this.cgFlowLayoutPanel2.Controls.Add(this.textRptTitle);
            this.cgFlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cgFlowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.cgFlowLayoutPanel2.Location = new System.Drawing.Point(4, 26);
            this.cgFlowLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.cgFlowLayoutPanel2.Name = "cgFlowLayoutPanel2";
            this.cgFlowLayoutPanel2.Size = new System.Drawing.Size(336, 120);
            this.cgFlowLayoutPanel2.TabIndex = 0;
            this.cgFlowLayoutPanel2.WrapContents = false;
            // 
            // textRptTitle
            // 
            this.textRptTitle.Header = "標題";
            this.textRptTitle.Location = new System.Drawing.Point(4, 4);
            this.textRptTitle.Margin = new System.Windows.Forms.Padding(4);
            this.textRptTitle.Name = "textRptTitle";
            this.textRptTitle.Padding = new System.Windows.Forms.Padding(2);
            this.textRptTitle.Size = new System.Drawing.Size(276, 39);
            this.textRptTitle.TabIndex = 13;
            this.textRptTitle.Text = "檢驗報告";
            // 
            // buttonCreate
            // 
            this.buttonCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCreate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonCreate.Location = new System.Drawing.Point(838, 568);
            this.buttonCreate.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(339, 80);
            this.buttonCreate.TabIndex = 17;
            this.buttonCreate.Text = "建立";
            this.buttonCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // cgIconButton1
            // 
            this.cgIconButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cgIconButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cgIconButton1.Location = new System.Drawing.Point(838, 477);
            this.cgIconButton1.Margin = new System.Windows.Forms.Padding(4);
            this.cgIconButton1.Name = "cgIconButton1";
            this.cgIconButton1.Size = new System.Drawing.Size(339, 80);
            this.cgIconButton1.TabIndex = 18;
            this.cgIconButton1.Text = "產生單號";
            this.cgIconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cgIconButton1.UseVisualStyleBackColor = true;
            this.cgIconButton1.Click += new System.EventHandler(this.cgIconButton1_Click);
            // 
            // LabCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 675);
            this.Controls.Add(this.cgIconButton1);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.pracControl1);
            this.Controls.Add(this.orgControl1);
            this.Controls.Add(this.patientControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LabCreateForm";
            this.Text = "打包抽血";
            this.groupBox3.ResumeLayout(false);
            this.cgFlowLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.cgFlowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Practitioners.PracControl pracControl1;
        private Orgs.OrgControl orgControl1;
        private Patients.PatientControl patientControl1;
        private System.Windows.Forms.GroupBox groupBox3;
        private Forms.CgFlowLayoutPanel cgFlowLayoutPanel1;
        private Forms.CgLabelTextBox textLabSrc;
        private System.Windows.Forms.GroupBox groupBox1;
        private Forms.CgFlowLayoutPanel cgFlowLayoutPanel2;
        private Forms.CgIconButton buttonCreate;
        private Forms.CgLabelTextBox textLabId;
        private Forms.CgLabelTextBox textLabCategory;
        private Forms.CgLabelTextBox textLabCategoryDesc;
        private Forms.CgLabelTextBox textLabDat;
        private Forms.CgLabelTextBox textRcvDat;
        private Forms.CgLabelTextBox textRptDat;
        private Forms.CgLabelTextBox textLabRslt;
        private Forms.CgLabelTextBox textLabItid;
        private Forms.CgLabelTextBox textLabItnm;
        private Forms.CgLabelTextBox textLabSrcDesc;
        private Forms.CgLabelTextBox textRptTitle;
        private Forms.CgIconButton cgIconButton1;
    }
}