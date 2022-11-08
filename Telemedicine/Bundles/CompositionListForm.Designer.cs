namespace Telemedicine.Bundles
{
    partial class CompositionListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompositionListForm));
            this.cgFlowLayoutPanel1 = new Telemedicine.Forms.CgFlowLayoutPanel();
            this.textPatIdentifier = new Telemedicine.Forms.CgLabelTextBox();
            this.cgLabelDateTimeRange1 = new Telemedicine.CgLabelDateTimeRange();
            this.textOrg = new Telemedicine.Forms.CgLabelTextBox();
            this.textPat = new Telemedicine.Forms.CgLabelTextBox();
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
            this.dgvData.Size = new System.Drawing.Size(528, 450);
            this.dgvData.TopPanelVisible = true;
            // 
            // textId
            // 
            this.textId.Size = new System.Drawing.Size(258, 39);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Image = ((System.Drawing.Image)(resources.GetObject("buttonSearch.Image")));
            this.buttonSearch.Location = new System.Drawing.Point(0, 381);
            this.buttonSearch.Size = new System.Drawing.Size(266, 69);
            // 
            // panelExtra
            // 
            this.panelExtra.Controls.Add(this.cgFlowLayoutPanel1);
            this.panelExtra.Size = new System.Drawing.Size(258, 219);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Panel2Collapsed = true;
            this.splitContainer2.Size = new System.Drawing.Size(528, 450);
            this.splitContainer2.SplitterDistance = 182;
            // 
            // cgFlowLayoutPanel1
            // 
            this.cgFlowLayoutPanel1.AutoMargin = true;
            this.cgFlowLayoutPanel1.AutoMarginSize = new System.Windows.Forms.Padding(0);
            this.cgFlowLayoutPanel1.AutoResizeChild = true;
            this.cgFlowLayoutPanel1.Controls.Add(this.textPat);
            this.cgFlowLayoutPanel1.Controls.Add(this.textPatIdentifier);
            this.cgFlowLayoutPanel1.Controls.Add(this.textOrg);
            this.cgFlowLayoutPanel1.Controls.Add(this.cgLabelDateTimeRange1);
            this.cgFlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cgFlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.cgFlowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.cgFlowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.cgFlowLayoutPanel1.Name = "cgFlowLayoutPanel1";
            this.cgFlowLayoutPanel1.Size = new System.Drawing.Size(258, 219);
            this.cgFlowLayoutPanel1.TabIndex = 3;
            this.cgFlowLayoutPanel1.WrapContents = false;
            // 
            // textPatIdentifier
            // 
            this.textPatIdentifier.Header = "病患識別碼";
            this.textPatIdentifier.HeaderAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textPatIdentifier.Location = new System.Drawing.Point(4, 51);
            this.textPatIdentifier.Margin = new System.Windows.Forms.Padding(4);
            this.textPatIdentifier.Name = "textPatIdentifier";
            this.textPatIdentifier.Padding = new System.Windows.Forms.Padding(2);
            this.textPatIdentifier.Size = new System.Drawing.Size(198, 39);
            this.textPatIdentifier.TabIndex = 11;
            // 
            // cgLabelDateTimeRange1
            // 
            this.cgLabelDateTimeRange1.ComponentHeight = 50;
            this.cgLabelDateTimeRange1.EndTimeAvaliable = false;
            this.cgLabelDateTimeRange1.IsGrouping = false;
            this.cgLabelDateTimeRange1.Location = new System.Drawing.Point(4, 145);
            this.cgLabelDateTimeRange1.Margin = new System.Windows.Forms.Padding(4);
            this.cgLabelDateTimeRange1.Name = "cgLabelDateTimeRange1";
            this.cgLabelDateTimeRange1.Padding = new System.Windows.Forms.Padding(2);
            this.cgLabelDateTimeRange1.Size = new System.Drawing.Size(198, 60);
            this.cgLabelDateTimeRange1.TabIndex = 15;
            this.cgLabelDateTimeRange1.Text = "cgLabelDateTimeRange1";
            // 
            // textOrg
            // 
            this.textOrg.Header = "組織代碼";
            this.textOrg.HeaderAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textOrg.Location = new System.Drawing.Point(4, 98);
            this.textOrg.Margin = new System.Windows.Forms.Padding(4);
            this.textOrg.Name = "textOrg";
            this.textOrg.Padding = new System.Windows.Forms.Padding(2);
            this.textOrg.Size = new System.Drawing.Size(198, 39);
            this.textOrg.TabIndex = 16;
            // 
            // textPat
            // 
            this.textPat.Header = "病患ID";
            this.textPat.HeaderAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textPat.Location = new System.Drawing.Point(4, 4);
            this.textPat.Margin = new System.Windows.Forms.Padding(4);
            this.textPat.Name = "textPat";
            this.textPat.Padding = new System.Windows.Forms.Padding(2);
            this.textPat.Size = new System.Drawing.Size(198, 39);
            this.textPat.TabIndex = 17;
            // 
            // CompositionListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "CompositionListForm";
            this.Text = "CompositionListForm";
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
        private CgLabelDateTimeRange cgLabelDateTimeRange1;
        private Forms.CgLabelTextBox textPat;
        private Forms.CgLabelTextBox textOrg;
    }
}