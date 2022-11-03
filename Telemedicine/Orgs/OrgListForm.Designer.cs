namespace Telemedicine.Orgs
{
    partial class OrgListForm
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
            this.textOrgId = new Telemedicine.Forms.CgLabelTextBox();
            this.textOrgName = new Telemedicine.Forms.CgLabelTextBox();
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
            this.cgFlowLayoutPanel1.Controls.Add(this.textOrgId);
            this.cgFlowLayoutPanel1.Controls.Add(this.textOrgName);
            this.cgFlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cgFlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.cgFlowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.cgFlowLayoutPanel1.Name = "cgFlowLayoutPanel1";
            this.cgFlowLayoutPanel1.Size = new System.Drawing.Size(239, 353);
            this.cgFlowLayoutPanel1.TabIndex = 0;
            this.cgFlowLayoutPanel1.WrapContents = false;
            // 
            // textOrgId
            // 
            this.textOrgId.Header = "組織識別碼";
            this.textOrgId.HeaderAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textOrgId.Location = new System.Drawing.Point(0, 0);
            this.textOrgId.Margin = new System.Windows.Forms.Padding(0);
            this.textOrgId.Name = "textOrgId";
            this.textOrgId.Size = new System.Drawing.Size(205, 30);
            this.textOrgId.TabIndex = 9;
            this.textOrgId.Text = "1132070011";
            // 
            // textOrgName
            // 
            this.textOrgName.Header = "組織名稱";
            this.textOrgName.HeaderAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textOrgName.Location = new System.Drawing.Point(0, 30);
            this.textOrgName.Margin = new System.Windows.Forms.Padding(0);
            this.textOrgName.Name = "textOrgName";
            this.textOrgName.Size = new System.Drawing.Size(205, 30);
            this.textOrgName.TabIndex = 10;
            // 
            // OrgListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "OrgListForm";
            this.Text = "組織查詢";
            this.panelExtra.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.cgFlowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Forms.CgFlowLayoutPanel cgFlowLayoutPanel1;
        private Forms.CgLabelTextBox textOrgId;
        private Forms.CgLabelTextBox textOrgName;
    }
}