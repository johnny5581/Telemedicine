
namespace Telemedicine.Vaccs
{
    partial class VaccCreateForm
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
            this.textVacSystem = new Telemedicine.Forms.CgLabelTextBox();
            this.textVacId = new Telemedicine.Forms.CgLabelTextBox();
            this.textVacName = new Telemedicine.Forms.CgLabelTextBox();
            this.textRcvdat = new Telemedicine.Forms.CgLabelTextBox();
            this.textRptdat = new Telemedicine.Forms.CgLabelTextBox();
            this.groupPat = new System.Windows.Forms.GroupBox();
            this.buttonPat = new Telemedicine.Forms.CgIconButton();
            this.textPatId = new Telemedicine.Forms.CgLabelControl();
            this.textPatSex = new Telemedicine.Forms.CgLabelTextBox();
            this.textPatBrithDate = new Telemedicine.Forms.CgLabelTextBox();
            this.textPatName = new Telemedicine.Forms.CgLabelTextBox();
            this.buttonCreate = new Telemedicine.Forms.CgIconButton();
            this.groupOrg = new System.Windows.Forms.GroupBox();
            this.textOrgName = new Telemedicine.Forms.CgLabelTextBox();
            this.buttonOrg = new Telemedicine.Forms.CgIconButton();
            this.textOrgId = new Telemedicine.Forms.CgLabelControl();
            this.groupBox3.SuspendLayout();
            this.cgFlowLayoutPanel1.SuspendLayout();
            this.groupPat.SuspendLayout();
            this.groupOrg.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.cgFlowLayoutPanel1);
            this.groupBox3.Location = new System.Drawing.Point(195, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(409, 278);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "注射資料";
            // 
            // cgFlowLayoutPanel1
            // 
            this.cgFlowLayoutPanel1.AutoMarginSize = new System.Windows.Forms.Padding(0);
            this.cgFlowLayoutPanel1.AutoSize = true;
            this.cgFlowLayoutPanel1.Controls.Add(this.textVacSystem);
            this.cgFlowLayoutPanel1.Controls.Add(this.textVacId);
            this.cgFlowLayoutPanel1.Controls.Add(this.textVacName);
            this.cgFlowLayoutPanel1.Controls.Add(this.textRcvdat);
            this.cgFlowLayoutPanel1.Controls.Add(this.textRptdat);
            this.cgFlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cgFlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.cgFlowLayoutPanel1.Location = new System.Drawing.Point(3, 18);
            this.cgFlowLayoutPanel1.Name = "cgFlowLayoutPanel1";
            this.cgFlowLayoutPanel1.Size = new System.Drawing.Size(403, 257);
            this.cgFlowLayoutPanel1.TabIndex = 5;
            this.cgFlowLayoutPanel1.WrapContents = false;
            // 
            // textVacSystem
            // 
            this.textVacSystem.Header = "檢驗系統";
            this.textVacSystem.Location = new System.Drawing.Point(3, 3);
            this.textVacSystem.Name = "textVacSystem";
            this.textVacSystem.Padding = new System.Windows.Forms.Padding(1);
            this.textVacSystem.Size = new System.Drawing.Size(231, 30);
            this.textVacSystem.TabIndex = 7;
            this.textVacSystem.Text = "http://loinc.org";
            // 
            // textVacId
            // 
            this.textVacId.Header = "檢驗代號";
            this.textVacId.Location = new System.Drawing.Point(3, 39);
            this.textVacId.Name = "textVacId";
            this.textVacId.Padding = new System.Windows.Forms.Padding(1);
            this.textVacId.Size = new System.Drawing.Size(231, 30);
            this.textVacId.TabIndex = 5;
            this.textVacId.Text = "LP217198-3";
            // 
            // textVacName
            // 
            this.textVacName.Header = "檢驗名稱";
            this.textVacName.Location = new System.Drawing.Point(3, 75);
            this.textVacName.Name = "textVacName";
            this.textVacName.Padding = new System.Windows.Forms.Padding(1);
            this.textVacName.Size = new System.Drawing.Size(231, 30);
            this.textVacName.TabIndex = 6;
            this.textVacName.Text = "Rapid Immunoassay";
            // 
            // textRcvdat
            // 
            this.textRcvdat.Header = "檢驗日期";
            this.textRcvdat.Location = new System.Drawing.Point(3, 111);
            this.textRcvdat.Name = "textRcvdat";
            this.textRcvdat.Padding = new System.Windows.Forms.Padding(1);
            this.textRcvdat.Size = new System.Drawing.Size(231, 30);
            this.textRcvdat.TabIndex = 11;
            this.textRcvdat.Text = "2021-11-03";
            // 
            // textRptdat
            // 
            this.textRptdat.Header = "報告日期";
            this.textRptdat.Location = new System.Drawing.Point(3, 147);
            this.textRptdat.Name = "textRptdat";
            this.textRptdat.Padding = new System.Windows.Forms.Padding(1);
            this.textRptdat.Size = new System.Drawing.Size(231, 30);
            this.textRptdat.TabIndex = 12;
            this.textRptdat.Text = "2021-11-04";
            // 
            // groupPat
            // 
            this.groupPat.Controls.Add(this.buttonPat);
            this.groupPat.Controls.Add(this.textPatId);
            this.groupPat.Controls.Add(this.textPatSex);
            this.groupPat.Controls.Add(this.textPatBrithDate);
            this.groupPat.Controls.Add(this.textPatName);
            this.groupPat.Location = new System.Drawing.Point(12, 12);
            this.groupPat.Name = "groupPat";
            this.groupPat.Size = new System.Drawing.Size(177, 168);
            this.groupPat.TabIndex = 2;
            this.groupPat.TabStop = false;
            this.groupPat.Text = "病患資料";
            // 
            // buttonPat
            // 
            this.buttonPat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonPat.IconSize = 0;
            this.buttonPat.Location = new System.Drawing.Point(96, 20);
            this.buttonPat.Name = "buttonPat";
            this.buttonPat.Size = new System.Drawing.Size(75, 23);
            this.buttonPat.TabIndex = 7;
            this.buttonPat.Text = "選擇病人";
            this.buttonPat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonPat.UseVisualStyleBackColor = true;
            this.buttonPat.Click += new System.EventHandler(this.buttonPat_Click);
            // 
            // textPatId
            // 
            this.textPatId.Header = "#";
            this.textPatId.HeaderAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textPatId.Location = new System.Drawing.Point(6, 49);
            this.textPatId.Name = "textPatId";
            this.textPatId.Padding = new System.Windows.Forms.Padding(1);
            this.textPatId.Size = new System.Drawing.Size(165, 14);
            this.textPatId.TabIndex = 6;
            // 
            // textPatSex
            // 
            this.textPatSex.Header = "性別";
            this.textPatSex.Location = new System.Drawing.Point(6, 129);
            this.textPatSex.Name = "textPatSex";
            this.textPatSex.Padding = new System.Windows.Forms.Padding(1);
            this.textPatSex.ReadOnly = true;
            this.textPatSex.Size = new System.Drawing.Size(165, 30);
            this.textPatSex.TabIndex = 5;
            // 
            // textPatBrithDate
            // 
            this.textPatBrithDate.Header = "生日";
            this.textPatBrithDate.Location = new System.Drawing.Point(6, 99);
            this.textPatBrithDate.Name = "textPatBrithDate";
            this.textPatBrithDate.Padding = new System.Windows.Forms.Padding(1);
            this.textPatBrithDate.ReadOnly = true;
            this.textPatBrithDate.Size = new System.Drawing.Size(165, 30);
            this.textPatBrithDate.TabIndex = 4;
            // 
            // textPatName
            // 
            this.textPatName.Header = "姓名";
            this.textPatName.Location = new System.Drawing.Point(6, 69);
            this.textPatName.Name = "textPatName";
            this.textPatName.Padding = new System.Windows.Forms.Padding(1);
            this.textPatName.ReadOnly = true;
            this.textPatName.Size = new System.Drawing.Size(165, 30);
            this.textPatName.TabIndex = 3;
            // 
            // buttonCreate
            // 
            this.buttonCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCreate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonCreate.IconSize = 0;
            this.buttonCreate.Location = new System.Drawing.Point(460, 296);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(144, 53);
            this.buttonCreate.TabIndex = 6;
            this.buttonCreate.Text = "建立";
            this.buttonCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // groupOrg
            // 
            this.groupOrg.Controls.Add(this.textOrgName);
            this.groupOrg.Controls.Add(this.buttonOrg);
            this.groupOrg.Controls.Add(this.textOrgId);
            this.groupOrg.Location = new System.Drawing.Point(12, 186);
            this.groupOrg.Name = "groupOrg";
            this.groupOrg.Size = new System.Drawing.Size(177, 104);
            this.groupOrg.TabIndex = 8;
            this.groupOrg.TabStop = false;
            this.groupOrg.Text = "組織";
            // 
            // textOrgName
            // 
            this.textOrgName.Header = "名稱";
            this.textOrgName.Location = new System.Drawing.Point(6, 68);
            this.textOrgName.Name = "textOrgName";
            this.textOrgName.Padding = new System.Windows.Forms.Padding(1);
            this.textOrgName.ReadOnly = true;
            this.textOrgName.Size = new System.Drawing.Size(165, 30);
            this.textOrgName.TabIndex = 8;
            this.textOrgName.Text = "長庚醫療財團法人林口長庚紀念醫院";
            // 
            // buttonOrg
            // 
            this.buttonOrg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonOrg.IconSize = 0;
            this.buttonOrg.Location = new System.Drawing.Point(96, 20);
            this.buttonOrg.Name = "buttonOrg";
            this.buttonOrg.Size = new System.Drawing.Size(75, 23);
            this.buttonOrg.TabIndex = 7;
            this.buttonOrg.Text = "選擇組織";
            this.buttonOrg.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonOrg.UseVisualStyleBackColor = true;
            this.buttonOrg.Click += new System.EventHandler(this.buttonOrg_Click);
            // 
            // textOrgId
            // 
            this.textOrgId.Header = "#";
            this.textOrgId.HeaderAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textOrgId.Location = new System.Drawing.Point(6, 49);
            this.textOrgId.Name = "textOrgId";
            this.textOrgId.Padding = new System.Windows.Forms.Padding(1);
            this.textOrgId.Size = new System.Drawing.Size(165, 14);
            this.textOrgId.TabIndex = 6;
            this.textOrgId.Text = "11909";
            // 
            // VaccCreateForm
            // 
            this.ClientSize = new System.Drawing.Size(616, 361);
            this.Controls.Add(this.groupOrg);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupPat);
            this.Name = "VaccCreateForm";
            this.Text = "用藥紀錄建立";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.cgFlowLayoutPanel1.ResumeLayout(false);
            this.groupPat.ResumeLayout(false);
            this.groupOrg.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupPat;
        private Forms.CgIconButton buttonPat;
        private Forms.CgLabelControl textPatId;
        private Forms.CgLabelTextBox textPatSex;
        private Forms.CgLabelTextBox textPatBrithDate;
        private Forms.CgLabelTextBox textPatName;
        private System.Windows.Forms.GroupBox groupBox3;
        private Forms.CgIconButton buttonCreate;
        private System.Windows.Forms.GroupBox groupOrg;
        private Forms.CgIconButton buttonOrg;
        private Forms.CgLabelControl textOrgId;
        private Forms.CgLabelTextBox textOrgName;
        private Forms.CgFlowLayoutPanel cgFlowLayoutPanel1;
        private Forms.CgLabelTextBox textVacId;
        private Forms.CgLabelTextBox textVacName;
        private Forms.CgLabelTextBox textVacSystem;
        private Forms.CgLabelTextBox textRcvdat;
        private Forms.CgLabelTextBox textRptdat;
    }
}