namespace Telemedicine.Patients
{
    partial class PatientControl
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {            
            this.cgFlowLayoutPanel1 = new Telemedicine.Forms.CgFlowLayoutPanel();
            this.textIdentifier = new Telemedicine.Forms.CgLabelTextBox();
            this.textChtno = new Telemedicine.Forms.CgLabelTextBox();
            this.textName = new Telemedicine.Forms.CgLabelTextBox();
            this.panelExtra.SuspendLayout();
            this.cgFlowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelExtra
            // 
            this.panelExtra.Controls.Add(this.cgFlowLayoutPanel1);
            // 
            // cgFlowLayoutPanel1
            // 
            this.cgFlowLayoutPanel1.AutoMargin = true;
            this.cgFlowLayoutPanel1.AutoMarginSize = new System.Windows.Forms.Padding(0);
            this.cgFlowLayoutPanel1.AutoResizeChild = true;
            this.cgFlowLayoutPanel1.Controls.Add(this.textIdentifier);
            this.cgFlowLayoutPanel1.Controls.Add(this.textChtno);
            this.cgFlowLayoutPanel1.Controls.Add(this.textName);
            this.cgFlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cgFlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.cgFlowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.cgFlowLayoutPanel1.Name = "cgFlowLayoutPanel1";
            this.cgFlowLayoutPanel1.Size = new System.Drawing.Size(144, 57);
            this.cgFlowLayoutPanel1.TabIndex = 0;
            this.cgFlowLayoutPanel1.WrapContents = false;
            // 
            // textIdentifier
            // 
            this.textIdentifier.Header = "身分證號";
            this.textIdentifier.Location = new System.Drawing.Point(3, 3);
            this.textIdentifier.Name = "textIdentifier";
            this.textIdentifier.ReadOnly = true;
            this.textIdentifier.Size = new System.Drawing.Size(104, 30);
            this.textIdentifier.TabIndex = 1;
            // 
            // textChtno
            // 
            this.textChtno.Header = "病歷號";
            this.textChtno.Location = new System.Drawing.Point(3, 39);
            this.textChtno.Name = "textChtno";
            this.textChtno.ReadOnly = true;
            this.textChtno.Size = new System.Drawing.Size(104, 30);
            this.textChtno.TabIndex = 3;
            // 
            // textName
            // 
            this.textName.Header = "姓名";
            this.textName.Location = new System.Drawing.Point(3, 75);
            this.textName.Name = "textName";
            this.textName.ReadOnly = true;
            this.textName.Size = new System.Drawing.Size(104, 30);
            this.textName.TabIndex = 2;
            // 
            // PatientControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "PatientControl";
            this.panelExtra.ResumeLayout(false);
            this.cgFlowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Forms.CgFlowLayoutPanel cgFlowLayoutPanel1;
        private Forms.CgLabelTextBox textIdentifier;
        private Forms.CgLabelTextBox textName;
        private System.Windows.Forms.Panel panel1;
        private Forms.CgLabelTextBox textChtno;
    }
}
