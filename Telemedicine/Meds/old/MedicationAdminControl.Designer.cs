
namespace Telemedicine.Meds
{
    partial class MedicationAdminControl
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
            this.groupEdit = new System.Windows.Forms.GroupBox();
            this.textUnit = new Telemedicine.Forms.CgLabelTextBox();
            this.textQuantity = new Telemedicine.Forms.CgLabelTextBox();
            this.dateEnd = new System.Windows.Forms.DateTimePicker();
            this.dateBegin = new System.Windows.Forms.DateTimePicker();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupEdit
            // 
            this.groupEdit.BackColor = System.Drawing.SystemColors.Control;
            this.groupEdit.Controls.Add(this.checkBox1);
            this.groupEdit.Controls.Add(this.textUnit);
            this.groupEdit.Controls.Add(this.textQuantity);
            this.groupEdit.Controls.Add(this.dateEnd);
            this.groupEdit.Controls.Add(this.dateBegin);
            this.groupEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupEdit.Location = new System.Drawing.Point(0, 0);
            this.groupEdit.Name = "groupEdit";
            this.groupEdit.Size = new System.Drawing.Size(286, 170);
            this.groupEdit.TabIndex = 8;
            this.groupEdit.TabStop = false;
            this.groupEdit.Text = "編輯";
            // 
            // textUnit
            // 
            this.textUnit.Header = "單位";
            this.textUnit.Location = new System.Drawing.Point(6, 57);
            this.textUnit.Name = "textUnit";
            this.textUnit.Padding = new System.Windows.Forms.Padding(1);
            this.textUnit.ReadOnly = true;
            this.textUnit.Size = new System.Drawing.Size(263, 30);
            this.textUnit.TabIndex = 14;
            // 
            // textQuantity
            // 
            this.textQuantity.Header = "數量";
            this.textQuantity.Location = new System.Drawing.Point(6, 21);
            this.textQuantity.Name = "textQuantity";
            this.textQuantity.Padding = new System.Windows.Forms.Padding(1);
            this.textQuantity.Size = new System.Drawing.Size(263, 30);
            this.textQuantity.TabIndex = 13;
            // 
            // dateEnd
            // 
            this.dateEnd.CustomFormat = "yyyy-MM-dd";
            this.dateEnd.Enabled = false;
            this.dateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateEnd.Location = new System.Drawing.Point(6, 121);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Size = new System.Drawing.Size(127, 22);
            this.dateEnd.TabIndex = 12;
            // 
            // dateBegin
            // 
            this.dateBegin.CustomFormat = "yyyy-MM-dd";
            this.dateBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateBegin.Location = new System.Drawing.Point(6, 93);
            this.dateBegin.Name = "dateBegin";
            this.dateBegin.Size = new System.Drawing.Size(127, 22);
            this.dateBegin.TabIndex = 11;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(140, 126);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(68, 16);
            this.checkBox1.TabIndex = 15;
            this.checkBox1.Text = "Endabled";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // MedicationAdminControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupEdit);
            this.Name = "MedicationAdminControl";
            this.Size = new System.Drawing.Size(286, 170);
            this.groupEdit.ResumeLayout(false);
            this.groupEdit.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupEdit;
        private System.Windows.Forms.DateTimePicker dateEnd;
        private System.Windows.Forms.DateTimePicker dateBegin;
        private Forms.CgLabelTextBox textQuantity;
        private Forms.CgLabelTextBox textUnit;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}
