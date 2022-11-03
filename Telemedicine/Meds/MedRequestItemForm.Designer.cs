namespace Telemedicine.Meds
{
    partial class MedRequestItemForm
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
            this.medControl1 = new Telemedicine.Meds.MedControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cgFlowLayoutPanel1 = new Telemedicine.Forms.CgFlowLayoutPanel();
            this.comboUnit = new Telemedicine.Forms.CgLabelComboBox();
            this.textInstruction = new Telemedicine.Forms.CgLabelTextBox();
            this.comboMedRoute = new Telemedicine.Forms.CgLabelComboBox();
            this.comboMedTiming = new Telemedicine.Forms.CgLabelComboBox();
            this.cgLabelDateTimeRange1 = new Telemedicine.CgLabelDateTimeRange();
            this.buttonOk = new Telemedicine.Forms.CgIconButton();
            this.buttonCancel = new Telemedicine.Forms.CgIconButton();
            this.groupBox1.SuspendLayout();
            this.cgFlowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // medControl1
            // 
            this.medControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.medControl1.Location = new System.Drawing.Point(12, 12);
            this.medControl1.Name = "medControl1";
            this.medControl1.PickerVisible = false;
            this.medControl1.Size = new System.Drawing.Size(328, 140);
            this.medControl1.TabIndex = 0;
            this.medControl1.Title = "Medication";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cgFlowLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 159);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(328, 247);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "處方內容";
            // 
            // cgFlowLayoutPanel1
            // 
            this.cgFlowLayoutPanel1.AutoMargin = true;
            this.cgFlowLayoutPanel1.AutoMarginSize = new System.Windows.Forms.Padding(0);
            this.cgFlowLayoutPanel1.AutoResizeChild = true;
            this.cgFlowLayoutPanel1.Controls.Add(this.comboUnit);
            this.cgFlowLayoutPanel1.Controls.Add(this.textInstruction);
            this.cgFlowLayoutPanel1.Controls.Add(this.comboMedRoute);
            this.cgFlowLayoutPanel1.Controls.Add(this.comboMedTiming);
            this.cgFlowLayoutPanel1.Controls.Add(this.cgLabelDateTimeRange1);
            this.cgFlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cgFlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.cgFlowLayoutPanel1.Location = new System.Drawing.Point(3, 18);
            this.cgFlowLayoutPanel1.Name = "cgFlowLayoutPanel1";
            this.cgFlowLayoutPanel1.Size = new System.Drawing.Size(322, 226);
            this.cgFlowLayoutPanel1.TabIndex = 0;
            this.cgFlowLayoutPanel1.WrapContents = false;
            // 
            // comboUnit
            // 
            this.comboUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboUnit.Header = "單位";
            this.comboUnit.Location = new System.Drawing.Point(3, 3);
            this.comboUnit.Name = "comboUnit";
            this.comboUnit.Size = new System.Drawing.Size(282, 31);
            this.comboUnit.TabIndex = 18;
            // 
            // textInstruction
            // 
            this.textInstruction.Header = "說明";
            this.textInstruction.Location = new System.Drawing.Point(3, 40);
            this.textInstruction.Name = "textInstruction";
            this.textInstruction.Size = new System.Drawing.Size(282, 30);
            this.textInstruction.TabIndex = 17;
            // 
            // comboMedRoute
            // 
            this.comboMedRoute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMedRoute.Header = "給藥路徑";
            this.comboMedRoute.Location = new System.Drawing.Point(3, 76);
            this.comboMedRoute.Name = "comboMedRoute";
            this.comboMedRoute.Size = new System.Drawing.Size(282, 31);
            this.comboMedRoute.TabIndex = 16;
            // 
            // comboMedTiming
            // 
            this.comboMedTiming.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMedTiming.Header = "給藥頻率";
            this.comboMedTiming.Location = new System.Drawing.Point(3, 113);
            this.comboMedTiming.Name = "comboMedTiming";
            this.comboMedTiming.Size = new System.Drawing.Size(282, 31);
            this.comboMedTiming.TabIndex = 15;
            // 
            // cgLabelDateTimeRange1
            // 
            this.cgLabelDateTimeRange1.ComponentHeight = 50;
            this.cgLabelDateTimeRange1.EnableTime = false;
            this.cgLabelDateTimeRange1.From = new System.DateTime(2022, 11, 3, 19, 32, 26, 509);
            this.cgLabelDateTimeRange1.Header = "日期";
            this.cgLabelDateTimeRange1.Location = new System.Drawing.Point(3, 150);
            this.cgLabelDateTimeRange1.Name = "cgLabelDateTimeRange1";
            this.cgLabelDateTimeRange1.Size = new System.Drawing.Size(282, 58);
            this.cgLabelDateTimeRange1.TabIndex = 19;
            this.cgLabelDateTimeRange1.Text = "cgLabelDateTimeRange1";
            this.cgLabelDateTimeRange1.To = new System.DateTime(2022, 11, 3, 19, 32, 26, 518);
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonOk.Location = new System.Drawing.Point(184, 412);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 7;
            this.buttonOk.Text = "確定";
            this.buttonOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonCancel.Location = new System.Drawing.Point(265, 412);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // MedRequestItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 447);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.medControl1);
            this.Name = "MedRequestItemForm";
            this.Text = "處方籤明細";
            this.groupBox1.ResumeLayout(false);
            this.cgFlowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MedControl medControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Forms.CgFlowLayoutPanel cgFlowLayoutPanel1;
        private Forms.CgLabelComboBox comboUnit;
        private Forms.CgLabelTextBox textInstruction;
        private Forms.CgLabelComboBox comboMedRoute;
        private Forms.CgLabelComboBox comboMedTiming;
        private Forms.CgIconButton buttonOk;
        private Forms.CgIconButton buttonCancel;
        private CgLabelDateTimeRange cgLabelDateTimeRange1;
    }
}