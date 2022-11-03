namespace Telemedicine.Patients
{
    partial class PatientListForm2
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
            this.textIdentifier = new Telemedicine.Forms.CgLabelTextBox();
            this.textName = new Telemedicine.Forms.CgLabelTextBox();
            this.comboOrg = new Telemedicine.Forms.CgLabelComboBox();
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
            this.dgvData.Size = new System.Drawing.Size(551, 450);
            this.dgvData.TopPanelVisible = true;
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
            this.cgFlowLayoutPanel1.Controls.Add(this.textIdentifier);
            this.cgFlowLayoutPanel1.Controls.Add(this.textName);
            this.cgFlowLayoutPanel1.Controls.Add(this.comboOrg);
            this.cgFlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cgFlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.cgFlowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.cgFlowLayoutPanel1.Name = "cgFlowLayoutPanel1";
            this.cgFlowLayoutPanel1.Size = new System.Drawing.Size(239, 353);
            this.cgFlowLayoutPanel1.TabIndex = 0;
            this.cgFlowLayoutPanel1.WrapContents = false;
            // 
            // textIdentifier
            // 
            this.textIdentifier.Header = "病患身分證";
            this.textIdentifier.HeaderAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textIdentifier.Location = new System.Drawing.Point(0, 0);
            this.textIdentifier.Margin = new System.Windows.Forms.Padding(0);
            this.textIdentifier.Name = "textIdentifier";
            this.textIdentifier.Size = new System.Drawing.Size(205, 30);
            this.textIdentifier.TabIndex = 7;
            this.textIdentifier.Text = "X123456789";
            // 
            // textName
            // 
            this.textName.Header = "病患姓名";
            this.textName.HeaderAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textName.Location = new System.Drawing.Point(0, 30);
            this.textName.Margin = new System.Windows.Forms.Padding(0);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(205, 30);
            this.textName.TabIndex = 8;
            // 
            // comboOrg
            // 
            this.comboOrg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboOrg.Header = "病患組織";
            this.comboOrg.HeaderAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.comboOrg.Location = new System.Drawing.Point(0, 60);
            this.comboOrg.Margin = new System.Windows.Forms.Padding(0);
            this.comboOrg.Name = "comboOrg";
            this.comboOrg.Size = new System.Drawing.Size(205, 31);
            this.comboOrg.TabIndex = 9;
            // 
            // PatientListForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "PatientListForm2";
            this.Text = "病患查詢";
            this.panelExtra.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.cgFlowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Forms.CgFlowLayoutPanel cgFlowLayoutPanel1;
        private Forms.CgLabelTextBox textIdentifier;
        private Forms.CgLabelTextBox textName;
        private Forms.CgLabelComboBox comboOrg;
    }
}