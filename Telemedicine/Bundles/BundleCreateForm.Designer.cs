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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonPatPicker = new Telemedicine.Forms.CgIconButton();
            this.textPatId = new Telemedicine.Forms.CgLabelTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonOrgPicker = new Telemedicine.Forms.CgIconButton();
            this.textOrgId = new Telemedicine.Forms.CgLabelTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cgFlowLayoutPanel1 = new Telemedicine.Forms.CgFlowLayoutPanel();
            this.textIdSys = new Telemedicine.Forms.CgLabelTextBox();
            this.textIdVal = new Telemedicine.Forms.CgLabelTextBox();
            this.textPeriodFrom = new Telemedicine.Forms.CgLabelTextBox();
            this.textPeriodTo = new Telemedicine.Forms.CgLabelTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonUserPicker = new Telemedicine.Forms.CgIconButton();
            this.textUserId = new Telemedicine.Forms.CgLabelTextBox();
            this.buttonCreate = new Telemedicine.Forms.CgIconButton();
            this.cgIconButton1 = new Telemedicine.Forms.CgIconButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.cgFlowLayoutPanel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonPatPicker);
            this.groupBox1.Controls.Add(this.textPatId);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(267, 86);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "病患";
            // 
            // buttonPatPicker
            // 
            this.buttonPatPicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPatPicker.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonPatPicker.Location = new System.Drawing.Point(186, 21);
            this.buttonPatPicker.Name = "buttonPatPicker";
            this.buttonPatPicker.Size = new System.Drawing.Size(75, 23);
            this.buttonPatPicker.TabIndex = 1;
            this.buttonPatPicker.Text = "選取";
            this.buttonPatPicker.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonPatPicker.UseVisualStyleBackColor = true;
            this.buttonPatPicker.Click += new System.EventHandler(this.buttonPatPicker_Click);
            // 
            // textPatId
            // 
            this.textPatId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textPatId.Header = "#";
            this.textPatId.Location = new System.Drawing.Point(6, 50);
            this.textPatId.Name = "textPatId";
            this.textPatId.ReadOnly = true;
            this.textPatId.Size = new System.Drawing.Size(255, 30);
            this.textPatId.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonOrgPicker);
            this.groupBox2.Controls.Add(this.textOrgId);
            this.groupBox2.Location = new System.Drawing.Point(12, 104);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(267, 86);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "組織";
            // 
            // buttonOrgPicker
            // 
            this.buttonOrgPicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOrgPicker.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonOrgPicker.Location = new System.Drawing.Point(186, 21);
            this.buttonOrgPicker.Name = "buttonOrgPicker";
            this.buttonOrgPicker.Size = new System.Drawing.Size(75, 23);
            this.buttonOrgPicker.TabIndex = 1;
            this.buttonOrgPicker.Text = "選取";
            this.buttonOrgPicker.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonOrgPicker.UseVisualStyleBackColor = true;
            this.buttonOrgPicker.Click += new System.EventHandler(this.buttonOrgPicker_Click);
            // 
            // textOrgId
            // 
            this.textOrgId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textOrgId.Header = "#";
            this.textOrgId.Location = new System.Drawing.Point(6, 50);
            this.textOrgId.Name = "textOrgId";
            this.textOrgId.ReadOnly = true;
            this.textOrgId.Size = new System.Drawing.Size(255, 30);
            this.textOrgId.TabIndex = 0;
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
            this.textIdSys.Text = "http://www.cgmh.org.tw";
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
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonUserPicker);
            this.groupBox4.Controls.Add(this.textUserId);
            this.groupBox4.Location = new System.Drawing.Point(12, 196);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(267, 99);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "簽章人員";
            // 
            // buttonUserPicker
            // 
            this.buttonUserPicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUserPicker.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonUserPicker.Location = new System.Drawing.Point(186, 20);
            this.buttonUserPicker.Name = "buttonUserPicker";
            this.buttonUserPicker.Size = new System.Drawing.Size(75, 23);
            this.buttonUserPicker.TabIndex = 3;
            this.buttonUserPicker.Text = "選取";
            this.buttonUserPicker.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonUserPicker.UseVisualStyleBackColor = true;
            this.buttonUserPicker.Click += new System.EventHandler(this.buttonUserPicker_Click);
            // 
            // textUserId
            // 
            this.textUserId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textUserId.Header = "#";
            this.textUserId.Location = new System.Drawing.Point(6, 49);
            this.textUserId.Name = "textUserId";
            this.textUserId.ReadOnly = true;
            this.textUserId.Size = new System.Drawing.Size(255, 30);
            this.textUserId.TabIndex = 2;
            // 
            // buttonCreate
            // 
            this.buttonCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCreate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonCreate.Location = new System.Drawing.Point(18, 413);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(144, 53);
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
            this.cgIconButton1.Location = new System.Drawing.Point(18, 354);
            this.cgIconButton1.Name = "cgIconButton1";
            this.cgIconButton1.Size = new System.Drawing.Size(144, 53);
            this.cgIconButton1.TabIndex = 8;
            this.cgIconButton1.Text = "產生識別";
            this.cgIconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cgIconButton1.UseVisualStyleBackColor = true;
            this.cgIconButton1.Click += new System.EventHandler(this.cgIconButton1_Click);
            // 
            // BundleCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 481);
            this.Controls.Add(this.cgIconButton1);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "BundleCreateForm";
            this.Text = "建立電子病歷文件";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.cgFlowLayoutPanel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Forms.CgLabelTextBox textPatId;
        private Forms.CgIconButton buttonPatPicker;
        private System.Windows.Forms.GroupBox groupBox2;
        private Forms.CgIconButton buttonOrgPicker;
        private Forms.CgLabelTextBox textOrgId;
        private System.Windows.Forms.GroupBox groupBox3;
        private Forms.CgLabelTextBox textIdSys;
        private Forms.CgLabelTextBox textIdVal;
        private Forms.CgLabelTextBox textPeriodFrom;
        private Forms.CgLabelTextBox textPeriodTo;
        private Forms.CgFlowLayoutPanel cgFlowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox4;
        private Forms.CgIconButton buttonCreate;
        private Forms.CgIconButton buttonUserPicker;
        private Forms.CgLabelTextBox textUserId;
        private Forms.CgIconButton cgIconButton1;
    }
}