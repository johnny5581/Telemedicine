namespace Telemedicine.Bundles
{
    partial class BundleCreateForm
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cgFlowLayoutPanel1 = new Telemedicine.Forms.CgFlowLayoutPanel();
            this.textIdSys = new Telemedicine.Forms.CgLabelTextBox();
            this.textIdVal = new Telemedicine.Forms.CgLabelTextBox();
            this.textPeriodFrom = new Telemedicine.Forms.CgLabelTextBox();
            this.textPeriodTo = new Telemedicine.Forms.CgLabelTextBox();
            this.buttonCreate = new Telemedicine.Forms.CgIconButton();
            this.cgIconButton1 = new Telemedicine.Forms.CgIconButton();
            this.patientControl1 = new Telemedicine.Patients.PatientControl();
            this.orgControl1 = new Telemedicine.Orgs.OrgControl();
            this.pracControl1 = new Telemedicine.Practitioners.PracControl();
            this.groupBox3.SuspendLayout();
            this.cgFlowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.cgFlowLayoutPanel1);
            this.groupBox3.Location = new System.Drawing.Point(285, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(465, 457);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "電子病歷";
            // 
            // cgFlowLayoutPanel1
            // 
            this.cgFlowLayoutPanel1.AutoMargin = true;
            this.cgFlowLayoutPanel1.AutoMarginSize = new System.Windows.Forms.Padding(0);
            this.cgFlowLayoutPanel1.AutoResizeChild = true;
            this.cgFlowLayoutPanel1.Controls.Add(this.textIdSys);
            this.cgFlowLayoutPanel1.Controls.Add(this.textIdVal);
            this.cgFlowLayoutPanel1.Controls.Add(this.textPeriodFrom);
            this.cgFlowLayoutPanel1.Controls.Add(this.textPeriodTo);
            this.cgFlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cgFlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.cgFlowLayoutPanel1.Location = new System.Drawing.Point(3, 18);
            this.cgFlowLayoutPanel1.Name = "cgFlowLayoutPanel1";
            this.cgFlowLayoutPanel1.Size = new System.Drawing.Size(459, 436);
            this.cgFlowLayoutPanel1.TabIndex = 0;
            this.cgFlowLayoutPanel1.WrapContents = false;
            // 
            // textIdSys
            // 
            this.textIdSys.Header = "識別系統";
            this.textIdSys.Location = new System.Drawing.Point(3, 3);
            this.textIdSys.Name = "textIdSys";
            this.textIdSys.Size = new System.Drawing.Size(419, 30);
            this.textIdSys.TabIndex = 0;
            this.textIdSys.Text = "https://www.cgmh.org.tw";
            // 
            // textIdVal
            // 
            this.textIdVal.Header = "識別值";
            this.textIdVal.Location = new System.Drawing.Point(3, 39);
            this.textIdVal.Name = "textIdVal";
            this.textIdVal.Size = new System.Drawing.Size(419, 30);
            this.textIdVal.TabIndex = 1;
            // 
            // textPeriodFrom
            // 
            this.textPeriodFrom.Header = "有效起日";
            this.textPeriodFrom.Location = new System.Drawing.Point(3, 75);
            this.textPeriodFrom.Name = "textPeriodFrom";
            this.textPeriodFrom.Size = new System.Drawing.Size(419, 30);
            this.textPeriodFrom.TabIndex = 2;
            this.textPeriodFrom.Text = "2022-10-14";
            // 
            // textPeriodTo
            // 
            this.textPeriodTo.Header = "有效迄日";
            this.textPeriodTo.Location = new System.Drawing.Point(3, 111);
            this.textPeriodTo.Name = "textPeriodTo";
            this.textPeriodTo.Size = new System.Drawing.Size(419, 30);
            this.textPeriodTo.TabIndex = 3;
            this.textPeriodTo.Text = "2099-12-31";
            // 
            // buttonCreate
            // 
            this.buttonCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCreate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonCreate.Location = new System.Drawing.Point(18, 413);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(158, 53);
            this.buttonCreate.TabIndex = 7;
            this.buttonCreate.Text = "建立";
            this.buttonCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // cgIconButton1
            // 
            this.cgIconButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cgIconButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cgIconButton1.Location = new System.Drawing.Point(182, 413);
            this.cgIconButton1.Name = "cgIconButton1";
            this.cgIconButton1.Size = new System.Drawing.Size(97, 53);
            this.cgIconButton1.TabIndex = 8;
            this.cgIconButton1.Text = "產生識別";
            this.cgIconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cgIconButton1.UseVisualStyleBackColor = true;
            this.cgIconButton1.Click += new System.EventHandler(this.cgIconButton1_Click);
            // 
            // patientControl1
            // 
            this.patientControl1.Location = new System.Drawing.Point(12, 12);
            this.patientControl1.Name = "patientControl1";
            this.patientControl1.Size = new System.Drawing.Size(267, 181);
            this.patientControl1.TabIndex = 9;
            this.patientControl1.Title = "Patient";
            // 
            // orgControl1
            // 
            this.orgControl1.Location = new System.Drawing.Point(13, 199);
            this.orgControl1.Name = "orgControl1";
            this.orgControl1.Size = new System.Drawing.Size(267, 94);
            this.orgControl1.TabIndex = 10;
            this.orgControl1.Title = "Organization";
            this.orgControl1.ItemPicked += new System.EventHandler(this.orgControl1_ItemPicked);
            // 
            // pracControl1
            // 
            this.pracControl1.Location = new System.Drawing.Point(13, 299);
            this.pracControl1.Name = "pracControl1";
            this.pracControl1.Size = new System.Drawing.Size(266, 108);
            this.pracControl1.TabIndex = 11;
            this.pracControl1.Title = "Practitioner";
            // 
            // BundleCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 481);
            this.Controls.Add(this.pracControl1);
            this.Controls.Add(this.orgControl1);
            this.Controls.Add(this.patientControl1);
            this.Controls.Add(this.cgIconButton1);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.groupBox3);
            this.Name = "BundleCreateForm";
            this.Text = "建立電子病歷文件";
            this.groupBox3.ResumeLayout(false);
            this.cgFlowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox3;
        private Forms.CgLabelTextBox textIdSys;
        private Forms.CgLabelTextBox textIdVal;
        private Forms.CgLabelTextBox textPeriodFrom;
        private Forms.CgLabelTextBox textPeriodTo;
        private Forms.CgFlowLayoutPanel cgFlowLayoutPanel1;
        private Forms.CgIconButton buttonCreate;
        private Forms.CgIconButton cgIconButton1;
        private Patients.PatientControl patientControl1;
        private Orgs.OrgControl orgControl1;
        private Practitioners.PracControl pracControl1;
    }
}