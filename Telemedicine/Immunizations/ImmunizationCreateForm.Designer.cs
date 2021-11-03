
namespace Telemedicine.Immunizations
{
    partial class ImmunizationCreateForm
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
            this.textICD = new Telemedicine.Forms.CgLabelTextBox();
            this.textVacId = new Telemedicine.Forms.CgLabelTextBox();
            this.textVacName = new Telemedicine.Forms.CgLabelTextBox();
            this.textVacMa = new Telemedicine.Forms.CgLabelTextBox();
            this.textVacDose = new Telemedicine.Forms.CgLabelTextBox();
            this.textVacSeries = new Telemedicine.Forms.CgLabelTextBox();
            this.textVacIot = new Telemedicine.Forms.CgLabelTextBox();
            this.textImmuDate = new Telemedicine.Forms.CgLabelTextBox();
            this.textImmuPerformer = new Telemedicine.Forms.CgLabelTextBox();
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
            this.groupBox3.Size = new System.Drawing.Size(409, 395);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "注射資料";
            // 
            // cgFlowLayoutPanel1
            // 
            this.cgFlowLayoutPanel1.AutoMarginSize = new System.Windows.Forms.Padding(0);
            this.cgFlowLayoutPanel1.AutoSize = true;
            this.cgFlowLayoutPanel1.Controls.Add(this.textICD);
            this.cgFlowLayoutPanel1.Controls.Add(this.textVacId);
            this.cgFlowLayoutPanel1.Controls.Add(this.textVacName);
            this.cgFlowLayoutPanel1.Controls.Add(this.textVacMa);
            this.cgFlowLayoutPanel1.Controls.Add(this.textVacDose);
            this.cgFlowLayoutPanel1.Controls.Add(this.textVacSeries);
            this.cgFlowLayoutPanel1.Controls.Add(this.textVacIot);
            this.cgFlowLayoutPanel1.Controls.Add(this.textImmuDate);
            this.cgFlowLayoutPanel1.Controls.Add(this.textImmuPerformer);
            this.cgFlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cgFlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.cgFlowLayoutPanel1.Location = new System.Drawing.Point(3, 18);
            this.cgFlowLayoutPanel1.Name = "cgFlowLayoutPanel1";
            this.cgFlowLayoutPanel1.Size = new System.Drawing.Size(403, 374);
            this.cgFlowLayoutPanel1.TabIndex = 5;
            this.cgFlowLayoutPanel1.WrapContents = false;
            // 
            // textICD
            // 
            this.textICD.Header = "目標疾病";
            this.textICD.Location = new System.Drawing.Point(3, 3);
            this.textICD.Name = "textICD";
            this.textICD.Padding = new System.Windows.Forms.Padding(1);
            this.textICD.Size = new System.Drawing.Size(231, 30);
            this.textICD.TabIndex = 4;
            this.textICD.Text = "U07.1";
            // 
            // textVacId
            // 
            this.textVacId.Header = "疫苗代號";
            this.textVacId.Location = new System.Drawing.Point(3, 39);
            this.textVacId.Name = "textVacId";
            this.textVacId.Padding = new System.Windows.Forms.Padding(1);
            this.textVacId.Size = new System.Drawing.Size(231, 30);
            this.textVacId.TabIndex = 5;
            this.textVacId.Text = "CoV_AZ";
            // 
            // textVacName
            // 
            this.textVacName.Header = "疫苗名稱";
            this.textVacName.Location = new System.Drawing.Point(3, 75);
            this.textVacName.Name = "textVacName";
            this.textVacName.Padding = new System.Windows.Forms.Padding(1);
            this.textVacName.Size = new System.Drawing.Size(231, 30);
            this.textVacName.TabIndex = 6;
            this.textVacName.Text = "AZD1222";
            // 
            // textVacMa
            // 
            this.textVacMa.Header = "製造商";
            this.textVacMa.Location = new System.Drawing.Point(3, 111);
            this.textVacMa.Name = "textVacMa";
            this.textVacMa.Padding = new System.Windows.Forms.Padding(1);
            this.textVacMa.Size = new System.Drawing.Size(231, 30);
            this.textVacMa.TabIndex = 7;
            this.textVacMa.Text = "AstraZeneca";
            // 
            // textVacDose
            // 
            this.textVacDose.Header = "劑別";
            this.textVacDose.Location = new System.Drawing.Point(3, 147);
            this.textVacDose.Name = "textVacDose";
            this.textVacDose.Padding = new System.Windows.Forms.Padding(1);
            this.textVacDose.Size = new System.Drawing.Size(231, 30);
            this.textVacDose.TabIndex = 8;
            this.textVacDose.Text = "1";
            // 
            // textVacSeries
            // 
            this.textVacSeries.Header = "完整劑數";
            this.textVacSeries.Location = new System.Drawing.Point(3, 183);
            this.textVacSeries.Name = "textVacSeries";
            this.textVacSeries.Padding = new System.Windows.Forms.Padding(1);
            this.textVacSeries.Size = new System.Drawing.Size(231, 30);
            this.textVacSeries.TabIndex = 9;
            this.textVacSeries.Text = "2";
            // 
            // textVacIot
            // 
            this.textVacIot.Header = "批號";
            this.textVacIot.Location = new System.Drawing.Point(3, 219);
            this.textVacIot.Name = "textVacIot";
            this.textVacIot.Padding = new System.Windows.Forms.Padding(1);
            this.textVacIot.Size = new System.Drawing.Size(231, 30);
            this.textVacIot.TabIndex = 10;
            this.textVacIot.Text = "1";
            // 
            // textImmuDate
            // 
            this.textImmuDate.Header = "接種日期";
            this.textImmuDate.Location = new System.Drawing.Point(3, 255);
            this.textImmuDate.Name = "textImmuDate";
            this.textImmuDate.Padding = new System.Windows.Forms.Padding(1);
            this.textImmuDate.Size = new System.Drawing.Size(231, 30);
            this.textImmuDate.TabIndex = 11;
            this.textImmuDate.Text = "2021-11-03";
            // 
            // textImmuPerformer
            // 
            this.textImmuPerformer.Header = "醫療人員";
            this.textImmuPerformer.Location = new System.Drawing.Point(3, 291);
            this.textImmuPerformer.Name = "textImmuPerformer";
            this.textImmuPerformer.Padding = new System.Windows.Forms.Padding(1);
            this.textImmuPerformer.Size = new System.Drawing.Size(231, 30);
            this.textImmuPerformer.TabIndex = 12;
            this.textImmuPerformer.Text = "陳長庚";
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
            this.buttonCreate.Location = new System.Drawing.Point(460, 413);
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
            // ImmunizationCreateForm
            // 
            this.ClientSize = new System.Drawing.Size(616, 478);
            this.Controls.Add(this.groupOrg);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupPat);
            this.Name = "ImmunizationCreateForm";
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
        private Forms.CgLabelTextBox textICD;
        private Forms.CgFlowLayoutPanel cgFlowLayoutPanel1;
        private Forms.CgLabelTextBox textVacId;
        private Forms.CgLabelTextBox textVacName;
        private Forms.CgLabelTextBox textVacMa;
        private Forms.CgLabelTextBox textVacDose;
        private Forms.CgLabelTextBox textVacSeries;
        private Forms.CgLabelTextBox textVacIot;
        private Forms.CgLabelTextBox textImmuDate;
        private Forms.CgLabelTextBox textImmuPerformer;
    }
}