namespace Telemedicine.Orgs
{
    partial class OrgControl
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
            this.comboPredefined = new Telemedicine.Forms.CgComboBox();
            this.panelExtra2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelExtra2
            // 
            this.panelExtra2.Controls.Add(this.comboPredefined);
            // 
            // comboPredefined
            // 
            this.comboPredefined.DisplayMember = "Text";
            this.comboPredefined.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboPredefined.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboPredefined.FormattingEnabled = true;
            this.comboPredefined.Location = new System.Drawing.Point(0, 0);
            this.comboPredefined.Name = "comboPredefined";
            this.comboPredefined.Size = new System.Drawing.Size(38, 23);
            this.comboPredefined.TabIndex = 0;
            this.comboPredefined.ValueMember = "Value";
            // 
            // OrgControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "OrgControl";
            this.panelExtra2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Forms.CgComboBox comboPredefined;
    }
}
