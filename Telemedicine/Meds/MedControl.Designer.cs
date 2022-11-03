namespace Telemedicine.Meds
{
    partial class MedControl
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
            this.textCode = new Telemedicine.Forms.CgLabelTextBox();
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
            this.cgFlowLayoutPanel1.Controls.Add(this.textCode);
            this.cgFlowLayoutPanel1.Controls.Add(this.textName);
            this.cgFlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cgFlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.cgFlowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.cgFlowLayoutPanel1.Name = "cgFlowLayoutPanel1";
            this.cgFlowLayoutPanel1.Size = new System.Drawing.Size(144, 84);
            this.cgFlowLayoutPanel1.TabIndex = 1;
            this.cgFlowLayoutPanel1.WrapContents = false;
            // 
            // textCode
            // 
            this.textCode.Header = "代號";
            this.textCode.Location = new System.Drawing.Point(0, 0);
            this.textCode.Margin = new System.Windows.Forms.Padding(0);
            this.textCode.Name = "textCode";
            this.textCode.ReadOnly = true;
            this.textCode.Size = new System.Drawing.Size(110, 30);
            this.textCode.TabIndex = 3;
            // 
            // textName
            // 
            this.textName.Header = "名稱";
            this.textName.Location = new System.Drawing.Point(0, 30);
            this.textName.Margin = new System.Windows.Forms.Padding(0);
            this.textName.Name = "textName";
            this.textName.ReadOnly = true;
            this.textName.Size = new System.Drawing.Size(110, 30);
            this.textName.TabIndex = 2;
            // 
            // MedControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "MedControl";
            this.panelExtra.ResumeLayout(false);
            this.cgFlowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Forms.CgFlowLayoutPanel cgFlowLayoutPanel1;
        private Forms.CgLabelTextBox textName;
        private Forms.CgLabelTextBox textCode;
    }
}
