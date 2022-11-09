namespace Telemedicine.Observations
{
    partial class ObservationListForm2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ObservationListForm2));
            this.cgFlowLayoutPanel1 = new Telemedicine.Forms.CgFlowLayoutPanel();
            this.comboVitalSign = new Telemedicine.Forms.CgLabelComboBox();
            this.textSubject = new Telemedicine.Forms.CgLabelTextBox();
            this.textPatIdentifier = new Telemedicine.Forms.CgLabelTextBox();
            this.textPatName = new Telemedicine.Forms.CgLabelTextBox();
            this.comboPatOrg = new Telemedicine.Forms.CgLabelComboBox();
            this.cgLabelDateTimeRange1 = new Telemedicine.CgLabelDateTimeRange();
            this.textServiceRequest = new Telemedicine.Forms.CgLabelTextBox();
            this.panelExtra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.cgFlowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvData
            // 
            this.dgvData.InfoBoxVisible = true;
            this.dgvData.Margin = new System.Windows.Forms.Padding(6);
            this.dgvData.Size = new System.Drawing.Size(794, 675);
            this.dgvData.TopPanelVisible = true;
            // 
            // textId
            // 
            this.textId.Padding = new System.Windows.Forms.Padding(3);
            this.textId.Size = new System.Drawing.Size(392, 41);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Image = ((System.Drawing.Image)(resources.GetObject("buttonSearch.Image")));
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(6);
            // 
            // panelExtra
            // 
            this.panelExtra.Controls.Add(this.cgFlowLayoutPanel1);
            this.panelExtra.Location = new System.Drawing.Point(4, 160);
            this.panelExtra.Margin = new System.Windows.Forms.Padding(6);
            this.panelExtra.Size = new System.Drawing.Size(392, 442);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Panel2Collapsed = true;
            // 
            // cgFlowLayoutPanel1
            // 
            this.cgFlowLayoutPanel1.AutoMargin = true;
            this.cgFlowLayoutPanel1.AutoMarginSize = new System.Windows.Forms.Padding(0);
            this.cgFlowLayoutPanel1.AutoResizeChild = true;
            this.cgFlowLayoutPanel1.Controls.Add(this.comboVitalSign);
            this.cgFlowLayoutPanel1.Controls.Add(this.textSubject);
            this.cgFlowLayoutPanel1.Controls.Add(this.textPatIdentifier);
            this.cgFlowLayoutPanel1.Controls.Add(this.textPatName);
            this.cgFlowLayoutPanel1.Controls.Add(this.comboPatOrg);
            this.cgFlowLayoutPanel1.Controls.Add(this.textServiceRequest);
            this.cgFlowLayoutPanel1.Controls.Add(this.cgLabelDateTimeRange1);
            this.cgFlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cgFlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.cgFlowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.cgFlowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.cgFlowLayoutPanel1.Name = "cgFlowLayoutPanel1";
            this.cgFlowLayoutPanel1.Size = new System.Drawing.Size(392, 442);
            this.cgFlowLayoutPanel1.TabIndex = 0;
            this.cgFlowLayoutPanel1.WrapContents = false;
            // 
            // comboVitalSign
            // 
            this.comboVitalSign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboVitalSign.Header = "類別";
            this.comboVitalSign.HeaderAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.comboVitalSign.Location = new System.Drawing.Point(4, 4);
            this.comboVitalSign.Margin = new System.Windows.Forms.Padding(4);
            this.comboVitalSign.Name = "comboVitalSign";
            this.comboVitalSign.Padding = new System.Windows.Forms.Padding(2);
            this.comboVitalSign.Size = new System.Drawing.Size(332, 40);
            this.comboVitalSign.TabIndex = 8;
            // 
            // textSubject
            // 
            this.textSubject.Header = "病患ID";
            this.textSubject.HeaderAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textSubject.Location = new System.Drawing.Point(4, 48);
            this.textSubject.Margin = new System.Windows.Forms.Padding(4);
            this.textSubject.Name = "textSubject";
            this.textSubject.Padding = new System.Windows.Forms.Padding(2);
            this.textSubject.Size = new System.Drawing.Size(332, 39);
            this.textSubject.TabIndex = 9;
            // 
            // textPatIdentifier
            // 
            this.textPatIdentifier.Header = "病患身分證";
            this.textPatIdentifier.HeaderAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textPatIdentifier.Location = new System.Drawing.Point(4, 95);
            this.textPatIdentifier.Margin = new System.Windows.Forms.Padding(4);
            this.textPatIdentifier.Name = "textPatIdentifier";
            this.textPatIdentifier.Padding = new System.Windows.Forms.Padding(2);
            this.textPatIdentifier.Size = new System.Drawing.Size(332, 39);
            this.textPatIdentifier.TabIndex = 10;
            // 
            // textPatName
            // 
            this.textPatName.Header = "病患姓名";
            this.textPatName.HeaderAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textPatName.Location = new System.Drawing.Point(4, 142);
            this.textPatName.Margin = new System.Windows.Forms.Padding(4);
            this.textPatName.Name = "textPatName";
            this.textPatName.Padding = new System.Windows.Forms.Padding(2);
            this.textPatName.Size = new System.Drawing.Size(332, 39);
            this.textPatName.TabIndex = 11;
            // 
            // comboPatOrg
            // 
            this.comboPatOrg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPatOrg.Header = "病患組織";
            this.comboPatOrg.HeaderAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.comboPatOrg.Location = new System.Drawing.Point(4, 189);
            this.comboPatOrg.Margin = new System.Windows.Forms.Padding(4);
            this.comboPatOrg.Name = "comboPatOrg";
            this.comboPatOrg.Padding = new System.Windows.Forms.Padding(2);
            this.comboPatOrg.Size = new System.Drawing.Size(332, 40);
            this.comboPatOrg.TabIndex = 12;
            // 
            // cgLabelDateTimeRange1
            // 
            this.cgLabelDateTimeRange1.ComponentHeight = 50;
            this.cgLabelDateTimeRange1.EndTimeAvaliable = false;
            this.cgLabelDateTimeRange1.IsGrouping = false;
            this.cgLabelDateTimeRange1.Location = new System.Drawing.Point(4, 280);
            this.cgLabelDateTimeRange1.Margin = new System.Windows.Forms.Padding(4);
            this.cgLabelDateTimeRange1.Name = "cgLabelDateTimeRange1";
            this.cgLabelDateTimeRange1.Padding = new System.Windows.Forms.Padding(2);
            this.cgLabelDateTimeRange1.Size = new System.Drawing.Size(332, 60);
            this.cgLabelDateTimeRange1.TabIndex = 14;
            this.cgLabelDateTimeRange1.Text = "cgLabelDateTimeRange1";
            // 
            // textServiceRequest
            // 
            this.textServiceRequest.Header = "服務";
            this.textServiceRequest.HeaderAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textServiceRequest.Location = new System.Drawing.Point(4, 233);
            this.textServiceRequest.Margin = new System.Windows.Forms.Padding(4);
            this.textServiceRequest.Name = "textServiceRequest";
            this.textServiceRequest.Padding = new System.Windows.Forms.Padding(2);
            this.textServiceRequest.Size = new System.Drawing.Size(332, 39);
            this.textServiceRequest.TabIndex = 15;
            // 
            // ObservationListForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 675);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "ObservationListForm2";
            this.Text = "生理數值查詢";
            this.panelExtra.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.cgFlowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Forms.CgFlowLayoutPanel cgFlowLayoutPanel1;
        private Forms.CgLabelComboBox comboVitalSign;
        private Forms.CgLabelTextBox textSubject;
        private Forms.CgLabelTextBox textPatIdentifier;
        private Forms.CgLabelTextBox textPatName;
        private Forms.CgLabelComboBox comboPatOrg;
        private CgLabelDateTimeRange cgLabelDateTimeRange1;
        private Forms.CgLabelTextBox textServiceRequest;
    }
}