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
            this.textLabSource = new Telemedicine.Forms.CgLabelTextBox();
            this.cgLabelTextBox1 = new Telemedicine.Forms.CgLabelTextBox();
            this.cgLabelTextBox2 = new Telemedicine.Forms.CgLabelTextBox();
            this.cgLabelComboBox1 = new Telemedicine.Forms.CgLabelComboBox();
            this.cgLabelTextBox3 = new Telemedicine.Forms.CgLabelTextBox();
            this.cgLabelTextBox4 = new Telemedicine.Forms.CgLabelTextBox();
            this.cgLabelTextBox5 = new Telemedicine.Forms.CgLabelTextBox();
            this.cgLabelTextBox6 = new Telemedicine.Forms.CgLabelTextBox();
            this.cgLabelTextBox7 = new Telemedicine.Forms.CgLabelTextBox();
            this.cgLabelTextBox8 = new Telemedicine.Forms.CgLabelTextBox();
            this.cgLabelTextBox9 = new Telemedicine.Forms.CgLabelTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cgFlowLayoutPanel2 = new Telemedicine.Forms.CgFlowLayoutPanel();
            this.buttonCreate = new Telemedicine.Forms.CgIconButton();
            this.groupBox3.SuspendLayout();
            this.cgFlowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pracControl1
            // 
            this.pracControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pracControl1.Location = new System.Drawing.Point(20, 489);
            this.pracControl1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pracControl1.Name = "pracControl1";
            this.pracControl1.Size = new System.Drawing.Size(399, 168);
            this.pracControl1.TabIndex = 14;
            this.pracControl1.Title = "Practitioner";
            // 
            // orgControl1
            // 
            this.orgControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.orgControl1.Location = new System.Drawing.Point(18, 352);
            this.orgControl1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
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
            this.patientControl1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
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
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(402, 639);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "抽血";
            // 
            // cgFlowLayoutPanel1
            // 
            this.cgFlowLayoutPanel1.AutoMargin = true;
            this.cgFlowLayoutPanel1.AutoMarginSize = new System.Windows.Forms.Padding(0);
            this.cgFlowLayoutPanel1.AutoResizeChild = true;
            this.cgFlowLayoutPanel1.Controls.Add(this.textLabSource);
            this.cgFlowLayoutPanel1.Controls.Add(this.cgLabelTextBox1);
            this.cgFlowLayoutPanel1.Controls.Add(this.cgLabelTextBox2);
            this.cgFlowLayoutPanel1.Controls.Add(this.cgLabelComboBox1);
            this.cgFlowLayoutPanel1.Controls.Add(this.cgLabelTextBox3);
            this.cgFlowLayoutPanel1.Controls.Add(this.cgLabelTextBox4);
            this.cgFlowLayoutPanel1.Controls.Add(this.cgLabelTextBox5);
            this.cgFlowLayoutPanel1.Controls.Add(this.cgLabelTextBox6);
            this.cgFlowLayoutPanel1.Controls.Add(this.cgLabelTextBox7);
            this.cgFlowLayoutPanel1.Controls.Add(this.cgLabelTextBox8);
            this.cgFlowLayoutPanel1.Controls.Add(this.cgLabelTextBox9);
            this.cgFlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cgFlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.cgFlowLayoutPanel1.Location = new System.Drawing.Point(4, 26);
            this.cgFlowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cgFlowLayoutPanel1.Name = "cgFlowLayoutPanel1";
            this.cgFlowLayoutPanel1.Size = new System.Drawing.Size(394, 609);
            this.cgFlowLayoutPanel1.TabIndex = 0;
            this.cgFlowLayoutPanel1.WrapContents = false;
            // 
            // textLabSource
            // 
            this.textLabSource.Header = "檢體來源";
            this.textLabSource.Location = new System.Drawing.Point(4, 4);
            this.textLabSource.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textLabSource.Name = "textLabSource";
            this.textLabSource.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textLabSource.Size = new System.Drawing.Size(334, 41);
            this.textLabSource.TabIndex = 0;
            // 
            // cgLabelTextBox1
            // 
            this.cgLabelTextBox1.Header = "院方網址";
            this.cgLabelTextBox1.Location = new System.Drawing.Point(4, 51);
            this.cgLabelTextBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cgLabelTextBox1.Name = "cgLabelTextBox1";
            this.cgLabelTextBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cgLabelTextBox1.Size = new System.Drawing.Size(334, 41);
            this.cgLabelTextBox1.TabIndex = 1;
            // 
            // cgLabelTextBox2
            // 
            this.cgLabelTextBox2.Header = "檢驗單號";
            this.cgLabelTextBox2.Location = new System.Drawing.Point(4, 98);
            this.cgLabelTextBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cgLabelTextBox2.Name = "cgLabelTextBox2";
            this.cgLabelTextBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cgLabelTextBox2.Size = new System.Drawing.Size(334, 41);
            this.cgLabelTextBox2.TabIndex = 2;
            // 
            // cgLabelComboBox1
            // 
            this.cgLabelComboBox1.Header = "檢體來源";
            this.cgLabelComboBox1.Location = new System.Drawing.Point(4, 145);
            this.cgLabelComboBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cgLabelComboBox1.Name = "cgLabelComboBox1";
            this.cgLabelComboBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cgLabelComboBox1.Size = new System.Drawing.Size(334, 42);
            this.cgLabelComboBox1.TabIndex = 3;
            this.cgLabelComboBox1.Text = "cgLabelComboBox1";
            // 
            // cgLabelTextBox3
            // 
            this.cgLabelTextBox3.Header = "檢體類別";
            this.cgLabelTextBox3.Location = new System.Drawing.Point(4, 193);
            this.cgLabelTextBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cgLabelTextBox3.Name = "cgLabelTextBox3";
            this.cgLabelTextBox3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cgLabelTextBox3.Size = new System.Drawing.Size(334, 41);
            this.cgLabelTextBox3.TabIndex = 4;
            // 
            // cgLabelTextBox4
            // 
            this.cgLabelTextBox4.Header = "檢體類別說明";
            this.cgLabelTextBox4.Location = new System.Drawing.Point(4, 240);
            this.cgLabelTextBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cgLabelTextBox4.Name = "cgLabelTextBox4";
            this.cgLabelTextBox4.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cgLabelTextBox4.Size = new System.Drawing.Size(334, 41);
            this.cgLabelTextBox4.TabIndex = 5;
            // 
            // cgLabelTextBox5
            // 
            this.cgLabelTextBox5.Header = "採檢日";
            this.cgLabelTextBox5.Location = new System.Drawing.Point(4, 287);
            this.cgLabelTextBox5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cgLabelTextBox5.Name = "cgLabelTextBox5";
            this.cgLabelTextBox5.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cgLabelTextBox5.Size = new System.Drawing.Size(334, 41);
            this.cgLabelTextBox5.TabIndex = 6;
            // 
            // cgLabelTextBox6
            // 
            this.cgLabelTextBox6.Header = "簽收日";
            this.cgLabelTextBox6.Location = new System.Drawing.Point(4, 334);
            this.cgLabelTextBox6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cgLabelTextBox6.Name = "cgLabelTextBox6";
            this.cgLabelTextBox6.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cgLabelTextBox6.Size = new System.Drawing.Size(334, 41);
            this.cgLabelTextBox6.TabIndex = 7;
            // 
            // cgLabelTextBox7
            // 
            this.cgLabelTextBox7.Header = "報告日";
            this.cgLabelTextBox7.Location = new System.Drawing.Point(4, 381);
            this.cgLabelTextBox7.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cgLabelTextBox7.Name = "cgLabelTextBox7";
            this.cgLabelTextBox7.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cgLabelTextBox7.Size = new System.Drawing.Size(334, 41);
            this.cgLabelTextBox7.TabIndex = 8;
            // 
            // cgLabelTextBox8
            // 
            this.cgLabelTextBox8.Header = "檢驗結果/值";
            this.cgLabelTextBox8.Location = new System.Drawing.Point(4, 428);
            this.cgLabelTextBox8.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cgLabelTextBox8.Name = "cgLabelTextBox8";
            this.cgLabelTextBox8.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cgLabelTextBox8.Size = new System.Drawing.Size(334, 41);
            this.cgLabelTextBox8.TabIndex = 9;
            // 
            // cgLabelTextBox9
            // 
            this.cgLabelTextBox9.Header = "參考值";
            this.cgLabelTextBox9.Location = new System.Drawing.Point(4, 475);
            this.cgLabelTextBox9.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cgLabelTextBox9.Name = "cgLabelTextBox9";
            this.cgLabelTextBox9.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cgLabelTextBox9.Size = new System.Drawing.Size(334, 41);
            this.cgLabelTextBox9.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cgFlowLayoutPanel2);
            this.groupBox1.Location = new System.Drawing.Point(838, 18);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(344, 150);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "就診";
            // 
            // cgFlowLayoutPanel2
            // 
            this.cgFlowLayoutPanel2.AutoMargin = true;
            this.cgFlowLayoutPanel2.AutoMarginSize = new System.Windows.Forms.Padding(0);
            this.cgFlowLayoutPanel2.AutoResizeChild = true;
            this.cgFlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cgFlowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.cgFlowLayoutPanel2.Location = new System.Drawing.Point(4, 26);
            this.cgFlowLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cgFlowLayoutPanel2.Name = "cgFlowLayoutPanel2";
            this.cgFlowLayoutPanel2.Size = new System.Drawing.Size(336, 120);
            this.cgFlowLayoutPanel2.TabIndex = 0;
            this.cgFlowLayoutPanel2.WrapContents = false;
            // 
            // buttonCreate
            // 
            this.buttonCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCreate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonCreate.Location = new System.Drawing.Point(838, 568);
            this.buttonCreate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(339, 80);
            this.buttonCreate.TabIndex = 17;
            this.buttonCreate.Text = "建立";
            this.buttonCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonCreate.UseVisualStyleBackColor = true;
            // 
            // LabCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 675);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.pracControl1);
            this.Controls.Add(this.orgControl1);
            this.Controls.Add(this.patientControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "LabCreateForm";
            this.Text = "打包抽血";
            this.groupBox3.ResumeLayout(false);
            this.cgFlowLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Practitioners.PracControl pracControl1;
        private Orgs.OrgControl orgControl1;
        private Patients.PatientControl patientControl1;
        private System.Windows.Forms.GroupBox groupBox3;
        private Forms.CgFlowLayoutPanel cgFlowLayoutPanel1;
        private Forms.CgLabelTextBox textLabSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private Forms.CgFlowLayoutPanel cgFlowLayoutPanel2;
        private Forms.CgIconButton buttonCreate;
        private Forms.CgLabelTextBox cgLabelTextBox1;
        private Forms.CgLabelTextBox cgLabelTextBox2;
        private Forms.CgLabelComboBox cgLabelComboBox1;
        private Forms.CgLabelTextBox cgLabelTextBox3;
        private Forms.CgLabelTextBox cgLabelTextBox4;
        private Forms.CgLabelTextBox cgLabelTextBox5;
        private Forms.CgLabelTextBox cgLabelTextBox6;
        private Forms.CgLabelTextBox cgLabelTextBox7;
        private Forms.CgLabelTextBox cgLabelTextBox8;
        private Forms.CgLabelTextBox cgLabelTextBox9;
    }
}