namespace Telemedicine.Meds
{
    partial class MedRequestControl
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
            this.textPatName = new Telemedicine.Forms.CgLabelTextBox();
            this.textMed = new Telemedicine.Forms.CgLabelTextBox();
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
            this.cgFlowLayoutPanel1.Controls.Add(this.textPatName);
            this.cgFlowLayoutPanel1.Controls.Add(this.textMed);
            this.cgFlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cgFlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.cgFlowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.cgFlowLayoutPanel1.Name = "cgFlowLayoutPanel1";
            this.cgFlowLayoutPanel1.Size = new System.Drawing.Size(144, 84);
            this.cgFlowLayoutPanel1.TabIndex = 2;
            this.cgFlowLayoutPanel1.WrapContents = false;
            // 
            // textPatName
            // 
            this.textPatName.Header = "病患";
            this.textPatName.Location = new System.Drawing.Point(0, 0);
            this.textPatName.Margin = new System.Windows.Forms.Padding(0);
            this.textPatName.Name = "textPatName";
            this.textPatName.ReadOnly = true;
            this.textPatName.Size = new System.Drawing.Size(110, 30);
            this.textPatName.TabIndex = 2;
            // 
            // textMed
            // 
            this.textMed.Header = "藥品";
            this.textMed.Location = new System.Drawing.Point(0, 30);
            this.textMed.Margin = new System.Windows.Forms.Padding(0);
            this.textMed.Name = "textMed";
            this.textMed.ReadOnly = true;
            this.textMed.Size = new System.Drawing.Size(110, 30);
            this.textMed.TabIndex = 3;
            // 
            // MedRequestControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "MedRequestControl";
            this.panelExtra.ResumeLayout(false);
            this.cgFlowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Forms.CgFlowLayoutPanel cgFlowLayoutPanel1;
        private Forms.CgLabelTextBox textPatName;
        private Forms.CgLabelTextBox textMed;
    }
}
