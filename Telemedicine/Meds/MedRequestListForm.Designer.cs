namespace Telemedicine.Meds
{
    partial class MedRequestListForm
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
            this.cgFlowLayoutPanel1 = new Telemedicine.Forms.CgFlowLayoutPanel();
            this.comboStatus = new Telemedicine.Forms.CgLabelComboBox();
            this.textSubject = new Telemedicine.Forms.CgLabelTextBox();
            this.textPatIdentifier = new Telemedicine.Forms.CgLabelTextBox();
            this.textMedId = new Telemedicine.Forms.CgLabelTextBox();
            this.comboPatOrg = new Telemedicine.Forms.CgLabelComboBox();
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
            // buttonSearch
            // 
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // panelExtra
            // 
            this.panelExtra.Controls.Add(this.cgFlowLayoutPanel1);
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
            this.cgFlowLayoutPanel1.Controls.Add(this.comboStatus);
            this.cgFlowLayoutPanel1.Controls.Add(this.textSubject);
            this.cgFlowLayoutPanel1.Controls.Add(this.textPatIdentifier);
            this.cgFlowLayoutPanel1.Controls.Add(this.textMedId);
            this.cgFlowLayoutPanel1.Controls.Add(this.comboPatOrg);
            this.cgFlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cgFlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.cgFlowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.cgFlowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.cgFlowLayoutPanel1.Name = "cgFlowLayoutPanel1";
            this.cgFlowLayoutPanel1.Size = new System.Drawing.Size(392, 444);
            this.cgFlowLayoutPanel1.TabIndex = 0;
            this.cgFlowLayoutPanel1.WrapContents = false;
            // 
            // comboStatus
            // 
            this.comboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboStatus.Header = "狀態";
            this.comboStatus.HeaderAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.comboStatus.Location = new System.Drawing.Point(0, 0);
            this.comboStatus.Margin = new System.Windows.Forms.Padding(0);
            this.comboStatus.Name = "comboStatus";
            this.comboStatus.Padding = new System.Windows.Forms.Padding(2);
            this.comboStatus.Size = new System.Drawing.Size(340, 40);
            this.comboStatus.TabIndex = 8;
            // 
            // textSubject
            // 
            this.textSubject.Header = "病患ID";
            this.textSubject.HeaderAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textSubject.Location = new System.Drawing.Point(0, 36);
            this.textSubject.Margin = new System.Windows.Forms.Padding(0);
            this.textSubject.Name = "textSubject";
            this.textSubject.Padding = new System.Windows.Forms.Padding(2);
            this.textSubject.Size = new System.Drawing.Size(340, 39);
            this.textSubject.TabIndex = 9;
            // 
            // textPatIdentifier
            // 
            this.textPatIdentifier.Header = "病患識別碼";
            this.textPatIdentifier.HeaderAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textPatIdentifier.Location = new System.Drawing.Point(0, 75);
            this.textPatIdentifier.Margin = new System.Windows.Forms.Padding(0);
            this.textPatIdentifier.Name = "textPatIdentifier";
            this.textPatIdentifier.Padding = new System.Windows.Forms.Padding(2);
            this.textPatIdentifier.Size = new System.Drawing.Size(340, 39);
            this.textPatIdentifier.TabIndex = 10;
            this.textPatIdentifier.Text = "500";
            // 
            // textMedId
            // 
            this.textMedId.Header = "藥品代碼";
            this.textMedId.HeaderAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textMedId.Location = new System.Drawing.Point(0, 114);
            this.textMedId.Margin = new System.Windows.Forms.Padding(0);
            this.textMedId.Name = "textMedId";
            this.textMedId.Padding = new System.Windows.Forms.Padding(2);
            this.textMedId.Size = new System.Drawing.Size(340, 39);
            this.textMedId.TabIndex = 11;
            // 
            // comboPatOrg
            // 
            this.comboPatOrg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPatOrg.Header = "病患組織";
            this.comboPatOrg.HeaderAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.comboPatOrg.Location = new System.Drawing.Point(0, 153);
            this.comboPatOrg.Margin = new System.Windows.Forms.Padding(0);
            this.comboPatOrg.Name = "comboPatOrg";
            this.comboPatOrg.Padding = new System.Windows.Forms.Padding(2);
            this.comboPatOrg.Size = new System.Drawing.Size(340, 40);
            this.comboPatOrg.TabIndex = 12;
            // 
            // MedRequestListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 675);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "MedRequestListForm";
            this.Text = "處方用藥查詢";
            this.panelExtra.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.cgFlowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Forms.CgFlowLayoutPanel cgFlowLayoutPanel1;
        private Forms.CgLabelComboBox comboStatus;
        private Forms.CgLabelTextBox textSubject;
        private Forms.CgLabelTextBox textPatIdentifier;
        private Forms.CgLabelTextBox textMedId;
        private Forms.CgLabelComboBox comboPatOrg;
    }
}