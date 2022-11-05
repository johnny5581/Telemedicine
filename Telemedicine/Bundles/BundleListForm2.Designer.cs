namespace Telemedicine.Bundles
{
    partial class BundleListForm2
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
            this.textPatIdentifier = new Telemedicine.Forms.CgLabelTextBox();
            this.comboPatOrg = new Telemedicine.Forms.CgLabelComboBox();
            this.cgLabelDateTimeRange1 = new Telemedicine.CgLabelDateTimeRange();
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
            this.dgvData.Size = new System.Drawing.Size(529, 450);
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
            this.cgFlowLayoutPanel1.Controls.Add(this.textPatIdentifier);
            this.cgFlowLayoutPanel1.Controls.Add(this.comboPatOrg);
            this.cgFlowLayoutPanel1.Controls.Add(this.cgLabelDateTimeRange1);
            this.cgFlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cgFlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.cgFlowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.cgFlowLayoutPanel1.Name = "cgFlowLayoutPanel1";
            this.cgFlowLayoutPanel1.Size = new System.Drawing.Size(261, 291);
            this.cgFlowLayoutPanel1.TabIndex = 2;
            this.cgFlowLayoutPanel1.WrapContents = false;
            // 
            // textPatIdentifier
            // 
            this.textPatIdentifier.Header = "病患識別碼";
            this.textPatIdentifier.HeaderAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textPatIdentifier.Location = new System.Drawing.Point(3, 3);
            this.textPatIdentifier.Name = "textPatIdentifier";
            this.textPatIdentifier.Size = new System.Drawing.Size(221, 30);
            this.textPatIdentifier.TabIndex = 11;
            // 
            // comboPatOrg
            // 
            this.comboPatOrg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPatOrg.Header = "病患組織";
            this.comboPatOrg.HeaderAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.comboPatOrg.Location = new System.Drawing.Point(3, 39);
            this.comboPatOrg.Name = "comboPatOrg";
            this.comboPatOrg.Size = new System.Drawing.Size(221, 31);
            this.comboPatOrg.TabIndex = 13;
            // 
            // cgLabelDateTimeRange1
            // 
            this.cgLabelDateTimeRange1.ComponentHeight = 50;
            this.cgLabelDateTimeRange1.IsGrouping = false;
            this.cgLabelDateTimeRange1.Location = new System.Drawing.Point(3, 73);
            this.cgLabelDateTimeRange1.Name = "cgLabelDateTimeRange1";
            this.cgLabelDateTimeRange1.Size = new System.Drawing.Size(221, 58);
            this.cgLabelDateTimeRange1.TabIndex = 15;
            this.cgLabelDateTimeRange1.Text = "cgLabelDateTimeRange1";
            // 
            // BundleListForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "BundleListForm2";
            this.Text = "BundleListForm2";
            this.panelExtra.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.cgFlowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Forms.CgFlowLayoutPanel cgFlowLayoutPanel1;
        private Forms.CgLabelTextBox textPatIdentifier;
        private Forms.CgLabelComboBox comboPatOrg;
        private CgLabelDateTimeRange cgLabelDateTimeRange1;
    }
}