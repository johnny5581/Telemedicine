
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
            this.groupPat = new System.Windows.Forms.GroupBox();
            this.buttonPat = new Telemedicine.Forms.CgIconButton();
            this.textPatId = new Telemedicine.Forms.CgLabelControl();
            this.textPatSex = new Telemedicine.Forms.CgLabelTextBox();
            this.textPatBrithDate = new Telemedicine.Forms.CgLabelTextBox();
            this.textPatName = new Telemedicine.Forms.CgLabelTextBox();
            this.buttonCreate = new Telemedicine.Forms.CgIconButton();
            this.groupOrg = new System.Windows.Forms.GroupBox();
            this.buttonMedReq = new Telemedicine.Forms.CgIconButton();
            this.textMedRedId = new Telemedicine.Forms.CgLabelControl();
            this.textOrgName = new Telemedicine.Forms.CgLabelTextBox();
            this.cgLabelTextBox1 = new Telemedicine.Forms.CgLabelTextBox();
            this.groupBox3.SuspendLayout();
            this.groupPat.SuspendLayout();
            this.groupOrg.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.cgLabelTextBox1);
            this.groupBox3.Location = new System.Drawing.Point(195, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(409, 280);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "注射資料";
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
            this.buttonCreate.Location = new System.Drawing.Point(460, 298);
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
            this.groupOrg.Controls.Add(this.buttonMedReq);
            this.groupOrg.Controls.Add(this.textMedRedId);
            this.groupOrg.Location = new System.Drawing.Point(12, 186);
            this.groupOrg.Name = "groupOrg";
            this.groupOrg.Size = new System.Drawing.Size(177, 104);
            this.groupOrg.TabIndex = 8;
            this.groupOrg.TabStop = false;
            this.groupOrg.Text = "組織";
            // 
            // buttonMedReq
            // 
            this.buttonMedReq.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonMedReq.IconSize = 0;
            this.buttonMedReq.Location = new System.Drawing.Point(96, 20);
            this.buttonMedReq.Name = "buttonMedReq";
            this.buttonMedReq.Size = new System.Drawing.Size(75, 23);
            this.buttonMedReq.TabIndex = 7;
            this.buttonMedReq.Text = "選擇組織";
            this.buttonMedReq.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonMedReq.UseVisualStyleBackColor = true;
            this.buttonMedReq.Click += new System.EventHandler(this.buttonMedReq_Click);
            // 
            // textMedRedId
            // 
            this.textMedRedId.Header = "#";
            this.textMedRedId.HeaderAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textMedRedId.Location = new System.Drawing.Point(6, 49);
            this.textMedRedId.Name = "textMedRedId";
            this.textMedRedId.Padding = new System.Windows.Forms.Padding(1);
            this.textMedRedId.Size = new System.Drawing.Size(165, 14);
            this.textMedRedId.TabIndex = 6;
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
            // 
            // cgLabelTextBox1
            // 
            this.cgLabelTextBox1.Header = "目標疾病";
            this.cgLabelTextBox1.Location = new System.Drawing.Point(6, 20);
            this.cgLabelTextBox1.Name = "cgLabelTextBox1";
            this.cgLabelTextBox1.Padding = new System.Windows.Forms.Padding(1);
            this.cgLabelTextBox1.Size = new System.Drawing.Size(231, 30);
            this.cgLabelTextBox1.TabIndex = 4;
            // 
            // ImmunizationCreateForm
            // 
            this.ClientSize = new System.Drawing.Size(616, 363);
            this.Controls.Add(this.groupOrg);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupPat);
            this.Name = "ImmunizationCreateForm";
            this.Text = "用藥紀錄建立";
            this.groupBox3.ResumeLayout(false);
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
        private Forms.CgIconButton buttonMedReq;
        private Forms.CgLabelControl textMedRedId;
        private Forms.CgLabelTextBox textOrgName;
        private Forms.CgLabelTextBox cgLabelTextBox1;
    }
}