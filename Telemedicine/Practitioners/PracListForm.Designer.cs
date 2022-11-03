namespace Telemedicine.Practitioners
{
    partial class PracListForm
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
            this.textUserName = new Telemedicine.Forms.CgLabelTextBox();
            this.textUserNo = new Telemedicine.Forms.CgLabelTextBox();
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
            this.cgFlowLayoutPanel1.Controls.Add(this.textUserName);
            this.cgFlowLayoutPanel1.Controls.Add(this.textUserNo);
            this.cgFlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cgFlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.cgFlowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.cgFlowLayoutPanel1.Name = "cgFlowLayoutPanel1";
            this.cgFlowLayoutPanel1.Size = new System.Drawing.Size(239, 353);
            this.cgFlowLayoutPanel1.TabIndex = 0;
            this.cgFlowLayoutPanel1.WrapContents = false;
            // 
            // textUserName
            // 
            this.textUserName.Header = "員工名稱";
            this.textUserName.HeaderAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textUserName.Location = new System.Drawing.Point(0, 0);
            this.textUserName.Margin = new System.Windows.Forms.Padding(0);
            this.textUserName.Name = "textUserName";
            this.textUserName.Size = new System.Drawing.Size(205, 30);
            this.textUserName.TabIndex = 10;
            // 
            // textUserNo
            // 
            this.textUserNo.Header = "員工證號";
            this.textUserNo.HeaderAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textUserNo.Location = new System.Drawing.Point(0, 30);
            this.textUserNo.Margin = new System.Windows.Forms.Padding(0);
            this.textUserNo.Name = "textUserNo";
            this.textUserNo.Size = new System.Drawing.Size(205, 30);
            this.textUserNo.TabIndex = 9;
            this.textUserNo.Text = "XYZ";
            // 
            // PracListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "PracListForm";
            this.Text = "醫事人員查詢";
            this.panelExtra.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.cgFlowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Forms.CgFlowLayoutPanel cgFlowLayoutPanel1;
        private Forms.CgLabelTextBox textUserName;
        private Forms.CgLabelTextBox textUserNo;
    }
}