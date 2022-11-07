﻿namespace Telemedicine.Patients
{
    partial class CreatePatientForm2
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cgFlowLayoutPanel1 = new Telemedicine.Forms.CgFlowLayoutPanel();
            this.textName = new Telemedicine.CgLabelHumanName();
            this.textBirthDat = new Telemedicine.Forms.CgLabelTextBox();
            this.textIdNo = new Telemedicine.Forms.CgLabelTextBox();
            this.comboSex = new Telemedicine.Forms.CgLabelComboBox();
            this.textEmail = new Telemedicine.Forms.CgLabelTextBox();
            this.textPersonalUrl = new Telemedicine.Forms.CgLabelTextBox();
            this.textTelecom = new Telemedicine.Forms.CgLabelTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cgTableLayoutPanel1 = new Telemedicine.Forms.CgTableLayoutPanel();
            this.comboDist = new Telemedicine.Forms.CgLabelComboBox();
            this.comboCity = new Telemedicine.Forms.CgLabelComboBox();
            this.textAddress = new Telemedicine.Forms.CgTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cgFlowLayoutPanel2 = new Telemedicine.Forms.CgFlowLayoutPanel();
            this.textContactName = new Telemedicine.CgLabelHumanName();
            this.comboContactRelation = new Telemedicine.Forms.CgLabelComboBox();
            this.textContactTelecom = new Telemedicine.Forms.CgLabelTextBox();
            this.buttonSave = new Telemedicine.Forms.CgIconButton();
            this.ucOrg = new Telemedicine.Orgs.OrgControl();
            this.textChtNo = new Telemedicine.Forms.CgLabelTextBox();
            this.buttonCancel = new Telemedicine.Forms.CgIconButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cgFlowLayoutPanel3 = new Telemedicine.Forms.CgFlowLayoutPanel();
            this.checkDead = new System.Windows.Forms.CheckBox();
            this.comboMeta = new Telemedicine.Forms.CgLabelComboBox();
            this.groupBox1.SuspendLayout();
            this.cgFlowLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.cgTableLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.cgFlowLayoutPanel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.cgFlowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cgFlowLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(18, 18);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(484, 639);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本資料";
            // 
            // cgFlowLayoutPanel1
            // 
            this.cgFlowLayoutPanel1.AutoMargin = true;
            this.cgFlowLayoutPanel1.AutoMarginSize = new System.Windows.Forms.Padding(1);
            this.cgFlowLayoutPanel1.AutoResizeChild = true;
            this.cgFlowLayoutPanel1.Controls.Add(this.textName);
            this.cgFlowLayoutPanel1.Controls.Add(this.textBirthDat);
            this.cgFlowLayoutPanel1.Controls.Add(this.textIdNo);
            this.cgFlowLayoutPanel1.Controls.Add(this.comboSex);
            this.cgFlowLayoutPanel1.Controls.Add(this.textEmail);
            this.cgFlowLayoutPanel1.Controls.Add(this.textPersonalUrl);
            this.cgFlowLayoutPanel1.Controls.Add(this.textTelecom);
            this.cgFlowLayoutPanel1.Controls.Add(this.groupBox2);
            this.cgFlowLayoutPanel1.Controls.Add(this.groupBox3);
            this.cgFlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cgFlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.cgFlowLayoutPanel1.Location = new System.Drawing.Point(4, 26);
            this.cgFlowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cgFlowLayoutPanel1.Name = "cgFlowLayoutPanel1";
            this.cgFlowLayoutPanel1.Size = new System.Drawing.Size(476, 609);
            this.cgFlowLayoutPanel1.TabIndex = 0;
            this.cgFlowLayoutPanel1.WrapContents = false;
            // 
            // textName
            // 
            this.textName.FamilyName = "王";
            this.textName.GivenName = "長庚";
            this.textName.Header = "姓名";
            this.textName.Location = new System.Drawing.Point(4, 4);
            this.textName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textName.Name = "textName";
            this.textName.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textName.Size = new System.Drawing.Size(416, 34);
            this.textName.TabIndex = 14;
            this.textName.Text = "cgLabelHumanName1";
            // 
            // textBirthDat
            // 
            this.textBirthDat.Header = "生日";
            this.textBirthDat.Location = new System.Drawing.Point(2, 42);
            this.textBirthDat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBirthDat.Name = "textBirthDat";
            this.textBirthDat.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBirthDat.Size = new System.Drawing.Size(420, 41);
            this.textBirthDat.TabIndex = 1;
            this.textBirthDat.Text = "1990-01-01";
            // 
            // textIdNo
            // 
            this.textIdNo.Header = "身分證號";
            this.textIdNo.Location = new System.Drawing.Point(2, 85);
            this.textIdNo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textIdNo.Name = "textIdNo";
            this.textIdNo.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textIdNo.Size = new System.Drawing.Size(420, 41);
            this.textIdNo.TabIndex = 3;
            this.textIdNo.Text = "X123456789";
            // 
            // comboSex
            // 
            this.comboSex.Header = "性別";
            this.comboSex.Location = new System.Drawing.Point(2, 128);
            this.comboSex.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboSex.Name = "comboSex";
            this.comboSex.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboSex.Size = new System.Drawing.Size(420, 42);
            this.comboSex.TabIndex = 10;
            // 
            // textEmail
            // 
            this.textEmail.Header = "電子郵件";
            this.textEmail.Location = new System.Drawing.Point(2, 172);
            this.textEmail.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textEmail.Name = "textEmail";
            this.textEmail.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textEmail.Size = new System.Drawing.Size(420, 41);
            this.textEmail.TabIndex = 4;
            this.textEmail.Text = "kamsung@company.com";
            // 
            // textPersonalUrl
            // 
            this.textPersonalUrl.Header = "個人網址";
            this.textPersonalUrl.Location = new System.Drawing.Point(2, 215);
            this.textPersonalUrl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textPersonalUrl.Name = "textPersonalUrl";
            this.textPersonalUrl.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textPersonalUrl.Size = new System.Drawing.Size(420, 41);
            this.textPersonalUrl.TabIndex = 5;
            this.textPersonalUrl.Text = "https://line.me/ti/p/OiIWZNnCeu";
            // 
            // textTelecom
            // 
            this.textTelecom.Header = "連絡電話";
            this.textTelecom.Location = new System.Drawing.Point(2, 258);
            this.textTelecom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textTelecom.Name = "textTelecom";
            this.textTelecom.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textTelecom.Size = new System.Drawing.Size(420, 41);
            this.textTelecom.TabIndex = 6;
            this.textTelecom.Text = "0989678473";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cgTableLayoutPanel1);
            this.groupBox2.Location = new System.Drawing.Point(4, 303);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(416, 237);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "地址";
            // 
            // cgTableLayoutPanel1
            // 
            this.cgTableLayoutPanel1.ColumnCount = 2;
            this.cgTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.cgTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.cgTableLayoutPanel1.Controls.Add(this.comboDist, 1, 0);
            this.cgTableLayoutPanel1.Controls.Add(this.comboCity, 0, 0);
            this.cgTableLayoutPanel1.Controls.Add(this.textAddress, 0, 1);
            this.cgTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cgTableLayoutPanel1.Location = new System.Drawing.Point(4, 26);
            this.cgTableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cgTableLayoutPanel1.Name = "cgTableLayoutPanel1";
            this.cgTableLayoutPanel1.RowCount = 2;
            this.cgTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.cgTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.cgTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.cgTableLayoutPanel1.Size = new System.Drawing.Size(408, 207);
            this.cgTableLayoutPanel1.TabIndex = 11;
            // 
            // comboDist
            // 
            this.comboDist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDist.Header = "地區";
            this.comboDist.Location = new System.Drawing.Point(208, 4);
            this.comboDist.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboDist.Name = "comboDist";
            this.comboDist.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboDist.Size = new System.Drawing.Size(182, 42);
            this.comboDist.TabIndex = 1;
            // 
            // comboCity
            // 
            this.comboCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCity.Header = "縣市";
            this.comboCity.Location = new System.Drawing.Point(4, 4);
            this.comboCity.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboCity.Name = "comboCity";
            this.comboCity.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboCity.Size = new System.Drawing.Size(180, 42);
            this.comboCity.TabIndex = 0;
            // 
            // textAddress
            // 
            this.cgTableLayoutPanel1.SetColumnSpan(this.textAddress, 2);
            this.textAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textAddress.Location = new System.Drawing.Point(4, 52);
            this.textAddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textAddress.Multiline = true;
            this.textAddress.Name = "textAddress";
            this.textAddress.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textAddress.Size = new System.Drawing.Size(400, 151);
            this.textAddress.TabIndex = 2;
            this.textAddress.Text = "復興一路5號";
            this.textAddress.WatermarkText = "詳細地址";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cgFlowLayoutPanel2);
            this.groupBox3.Location = new System.Drawing.Point(4, 548);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(416, 168);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "緊急連絡人";
            // 
            // cgFlowLayoutPanel2
            // 
            this.cgFlowLayoutPanel2.AutoMargin = true;
            this.cgFlowLayoutPanel2.AutoMarginSize = new System.Windows.Forms.Padding(0);
            this.cgFlowLayoutPanel2.AutoResizeChild = true;
            this.cgFlowLayoutPanel2.Controls.Add(this.textContactName);
            this.cgFlowLayoutPanel2.Controls.Add(this.comboContactRelation);
            this.cgFlowLayoutPanel2.Controls.Add(this.textContactTelecom);
            this.cgFlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cgFlowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.cgFlowLayoutPanel2.Location = new System.Drawing.Point(4, 26);
            this.cgFlowLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cgFlowLayoutPanel2.Name = "cgFlowLayoutPanel2";
            this.cgFlowLayoutPanel2.Size = new System.Drawing.Size(408, 138);
            this.cgFlowLayoutPanel2.TabIndex = 0;
            this.cgFlowLayoutPanel2.WrapContents = false;
            // 
            // textContactName
            // 
            this.textContactName.FamilyName = "許";
            this.textContactName.GivenName = "庭瑋";
            this.textContactName.Header = "姓名";
            this.textContactName.HeaderAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textContactName.Location = new System.Drawing.Point(4, 4);
            this.textContactName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textContactName.Name = "textContactName";
            this.textContactName.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textContactName.Size = new System.Drawing.Size(348, 34);
            this.textContactName.TabIndex = 15;
            // 
            // comboContactRelation
            // 
            this.comboContactRelation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboContactRelation.Header = "關係";
            this.comboContactRelation.HeaderAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.comboContactRelation.Location = new System.Drawing.Point(4, 44);
            this.comboContactRelation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboContactRelation.Name = "comboContactRelation";
            this.comboContactRelation.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboContactRelation.Size = new System.Drawing.Size(348, 42);
            this.comboContactRelation.TabIndex = 16;
            // 
            // textContactTelecom
            // 
            this.textContactTelecom.Header = "連絡電話";
            this.textContactTelecom.HeaderAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textContactTelecom.Location = new System.Drawing.Point(0, 88);
            this.textContactTelecom.Margin = new System.Windows.Forms.Padding(0);
            this.textContactTelecom.Name = "textContactTelecom";
            this.textContactTelecom.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textContactTelecom.Size = new System.Drawing.Size(356, 41);
            this.textContactTelecom.TabIndex = 9;
            this.textContactTelecom.Text = "0987654321";
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonSave.Location = new System.Drawing.Point(512, 567);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(202, 90);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "存檔";
            this.buttonSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // ucOrg
            // 
            this.ucOrg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucOrg.Location = new System.Drawing.Point(512, 18);
            this.ucOrg.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.ucOrg.Name = "ucOrg";
            this.ucOrg.Size = new System.Drawing.Size(357, 165);
            this.ucOrg.TabIndex = 5;
            this.ucOrg.Title = "Organization";
            // 
            // textChtNo
            // 
            this.textChtNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textChtNo.Header = "病歷號";
            this.textChtNo.Location = new System.Drawing.Point(0, 0);
            this.textChtNo.Margin = new System.Windows.Forms.Padding(0);
            this.textChtNo.Name = "textChtNo";
            this.textChtNo.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textChtNo.Size = new System.Drawing.Size(297, 41);
            this.textChtNo.TabIndex = 6;
            this.textChtNo.Text = "500";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonCancel.Location = new System.Drawing.Point(723, 567);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(146, 90);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Visible = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.cgFlowLayoutPanel3);
            this.groupBox4.Location = new System.Drawing.Point(512, 192);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Size = new System.Drawing.Size(357, 366);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "其他";
            // 
            // cgFlowLayoutPanel3
            // 
            this.cgFlowLayoutPanel3.AutoMargin = true;
            this.cgFlowLayoutPanel3.AutoMarginSize = new System.Windows.Forms.Padding(0);
            this.cgFlowLayoutPanel3.AutoResizeChild = true;
            this.cgFlowLayoutPanel3.Controls.Add(this.textChtNo);
            this.cgFlowLayoutPanel3.Controls.Add(this.checkDead);
            this.cgFlowLayoutPanel3.Controls.Add(this.comboMeta);
            this.cgFlowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cgFlowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.cgFlowLayoutPanel3.Location = new System.Drawing.Point(4, 26);
            this.cgFlowLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cgFlowLayoutPanel3.Name = "cgFlowLayoutPanel3";
            this.cgFlowLayoutPanel3.Size = new System.Drawing.Size(349, 336);
            this.cgFlowLayoutPanel3.TabIndex = 7;
            this.cgFlowLayoutPanel3.WrapContents = false;
            // 
            // checkDead
            // 
            this.checkDead.AutoSize = true;
            this.checkDead.Location = new System.Drawing.Point(4, 43);
            this.checkDead.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkDead.Name = "checkDead";
            this.checkDead.Size = new System.Drawing.Size(88, 22);
            this.checkDead.TabIndex = 7;
            this.checkDead.Text = "已死亡";
            this.checkDead.UseVisualStyleBackColor = true;
            // 
            // comboMeta
            // 
            this.comboMeta.Header = "META";
            this.comboMeta.Location = new System.Drawing.Point(2, 71);
            this.comboMeta.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboMeta.Name = "comboMeta";
            this.comboMeta.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboMeta.Size = new System.Drawing.Size(293, 42);
            this.comboMeta.TabIndex = 11;
            // 
            // CreatePatientForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 675);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.ucOrg);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CreatePatientForm2";
            this.Text = "病患初診資料";
            this.groupBox1.ResumeLayout(false);
            this.cgFlowLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.cgTableLayoutPanel1.ResumeLayout(false);
            this.cgTableLayoutPanel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.cgFlowLayoutPanel2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.cgFlowLayoutPanel3.ResumeLayout(false);
            this.cgFlowLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Forms.CgFlowLayoutPanel cgFlowLayoutPanel1;
        private Forms.CgLabelTextBox textBirthDat;
        private Forms.CgLabelTextBox textIdNo;
        private Forms.CgLabelTextBox textEmail;
        private Forms.CgLabelTextBox textPersonalUrl;
        private Forms.CgLabelTextBox textTelecom;
        private Forms.CgIconButton buttonSave;
        private Forms.CgLabelComboBox comboSex;
        private Orgs.OrgControl ucOrg;
        private Forms.CgTableLayoutPanel cgTableLayoutPanel1;
        private Forms.CgLabelComboBox comboCity;
        private Forms.CgLabelComboBox comboDist;
        private Forms.CgTextBox textAddress;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private Forms.CgLabelTextBox textChtNo;
        private Forms.CgFlowLayoutPanel cgFlowLayoutPanel2;
        private Forms.CgLabelTextBox textContactTelecom;
        private CgLabelHumanName textName;
        private CgLabelHumanName textContactName;
        private Forms.CgIconButton buttonCancel;
        private System.Windows.Forms.GroupBox groupBox4;
        private Forms.CgFlowLayoutPanel cgFlowLayoutPanel3;
        private System.Windows.Forms.CheckBox checkDead;
        private Forms.CgLabelComboBox comboContactRelation;
        private Forms.CgLabelComboBox comboMeta;
    }
}