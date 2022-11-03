namespace Telemedicine.Meds
{
    partial class MedAdminItemForm
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
            this.textQuantity = new Telemedicine.Forms.CgLabelTextBox();
            this.textUnit = new Telemedicine.Forms.CgLabelTextBox();
            this.dateRange = new Telemedicine.CgLabelDateTimeRange();
            this.medControl1 = new Telemedicine.Meds.MedControl();
            this.buttonOk = new Telemedicine.Forms.CgIconButton();
            this.buttonCancel = new Telemedicine.Forms.CgIconButton();
            this.groupBox1.SuspendLayout();
            this.cgFlowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cgFlowLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 159);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(328, 168);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "用藥";
            // 
            // cgFlowLayoutPanel1
            // 
            this.cgFlowLayoutPanel1.AutoMargin = true;
            this.cgFlowLayoutPanel1.AutoMarginSize = new System.Windows.Forms.Padding(0);
            this.cgFlowLayoutPanel1.AutoResizeChild = true;
            this.cgFlowLayoutPanel1.Controls.Add(this.textQuantity);
            this.cgFlowLayoutPanel1.Controls.Add(this.textUnit);
            this.cgFlowLayoutPanel1.Controls.Add(this.dateRange);
            this.cgFlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cgFlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.cgFlowLayoutPanel1.Location = new System.Drawing.Point(3, 18);
            this.cgFlowLayoutPanel1.Name = "cgFlowLayoutPanel1";
            this.cgFlowLayoutPanel1.Size = new System.Drawing.Size(322, 147);
            this.cgFlowLayoutPanel1.TabIndex = 0;
            this.cgFlowLayoutPanel1.WrapContents = false;
            // 
            // textQuantity
            // 
            this.textQuantity.Header = "數量";
            this.textQuantity.Location = new System.Drawing.Point(3, 3);
            this.textQuantity.Name = "textQuantity";
            this.textQuantity.Size = new System.Drawing.Size(282, 30);
            this.textQuantity.TabIndex = 17;
            // 
            // textUnit
            // 
            this.textUnit.Header = "單位";
            this.textUnit.Location = new System.Drawing.Point(3, 39);
            this.textUnit.Name = "textUnit";
            this.textUnit.ReadOnly = true;
            this.textUnit.Size = new System.Drawing.Size(282, 30);
            this.textUnit.TabIndex = 20;
            // 
            // dateRange
            // 
            this.dateRange.ComponentHeight = 50;
            this.dateRange.EnableTime = false;
            this.dateRange.From = new System.DateTime(2022, 11, 3, 19, 32, 26, 509);
            this.dateRange.Header = "用藥時間";
            this.dateRange.Location = new System.Drawing.Point(3, 75);
            this.dateRange.Name = "dateRange";
            this.dateRange.Size = new System.Drawing.Size(282, 58);
            this.dateRange.TabIndex = 19;
            this.dateRange.Text = "cgLabelDateTimeRange1";
            this.dateRange.To = new System.DateTime(2022, 11, 3, 19, 32, 26, 518);
            // 
            // medControl1
            // 
            this.medControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.medControl1.Location = new System.Drawing.Point(12, 12);
            this.medControl1.Name = "medControl1";
            this.medControl1.PickerVisible = false;
            this.medControl1.Size = new System.Drawing.Size(328, 140);
            this.medControl1.TabIndex = 8;
            this.medControl1.Title = "Medication";
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonOk.Location = new System.Drawing.Point(184, 333);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 11;
            this.buttonOk.Text = "確定";
            this.buttonOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonCancel.Location = new System.Drawing.Point(265, 333);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // MedAdminItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 368);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.medControl1);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Name = "MedAdminItemForm";
            this.Text = "用藥紀錄";
            this.groupBox1.ResumeLayout(false);
            this.cgFlowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Forms.CgFlowLayoutPanel cgFlowLayoutPanel1;
        private Forms.CgLabelTextBox textQuantity;
        private MedControl medControl1;
        private Forms.CgIconButton buttonOk;
        private Forms.CgIconButton buttonCancel;
        private Forms.CgLabelTextBox textUnit;
        private CgLabelDateTimeRange dateRange;
    }
}