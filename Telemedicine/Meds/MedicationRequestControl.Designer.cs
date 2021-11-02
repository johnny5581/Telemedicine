
namespace Telemedicine.Meds
{
    partial class MedicationRequestControl
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
            this.textInstruction = new Telemedicine.Forms.CgLabelTextBox();
            this.dateEnd = new System.Windows.Forms.DateTimePicker();
            this.dateBegin = new System.Windows.Forms.DateTimePicker();
            this.comboMedRoute = new Telemedicine.Forms.CgLabelComboBox();
            this.comboMedTiming = new Telemedicine.Forms.CgLabelComboBox();
            this.comboUnit = new Telemedicine.Forms.CgLabelComboBox();
            this.groupEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupEdit
            // 
            this.groupEdit.BackColor = System.Drawing.SystemColors.Control;
            this.groupEdit.Controls.Add(this.comboUnit);
            this.groupEdit.Controls.Add(this.textInstruction);
            this.groupEdit.Controls.Add(this.dateEnd);
            this.groupEdit.Controls.Add(this.dateBegin);
            this.groupEdit.Controls.Add(this.comboMedRoute);
            this.groupEdit.Controls.Add(this.comboMedTiming);
            this.groupEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupEdit.Location = new System.Drawing.Point(0, 0);
            this.groupEdit.Name = "groupEdit";
            this.groupEdit.Size = new System.Drawing.Size(286, 202);
            this.groupEdit.TabIndex = 8;
            this.groupEdit.TabStop = false;
            this.groupEdit.Text = "編輯";
            // 
            // textInstruction
            // 
            this.textInstruction.Header = "說明";
            this.textInstruction.Location = new System.Drawing.Point(6, 95);
            this.textInstruction.Name = "textInstruction";
            this.textInstruction.Padding = new System.Windows.Forms.Padding(1);
            this.textInstruction.Size = new System.Drawing.Size(263, 30);
            this.textInstruction.TabIndex = 13;
            // 
            // dateEnd
            // 
            this.dateEnd.CustomFormat = "yyyy-MM-dd";
            this.dateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateEnd.Location = new System.Drawing.Point(142, 168);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Size = new System.Drawing.Size(127, 22);
            this.dateEnd.TabIndex = 12;
            // 
            // dateBegin
            // 
            this.dateBegin.CustomFormat = "yyyy-MM-dd";
            this.dateBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateBegin.Location = new System.Drawing.Point(6, 168);
            this.dateBegin.Name = "dateBegin";
            this.dateBegin.Size = new System.Drawing.Size(127, 22);
            this.dateBegin.TabIndex = 11;
            // 
            // comboMedRoute
            // 
            this.comboMedRoute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMedRoute.Header = "給藥路徑";
            this.comboMedRoute.Location = new System.Drawing.Point(6, 58);
            this.comboMedRoute.Name = "comboMedRoute";
            this.comboMedRoute.Padding = new System.Windows.Forms.Padding(1);
            this.comboMedRoute.Size = new System.Drawing.Size(264, 31);
            this.comboMedRoute.TabIndex = 10;
            // 
            // comboMedTiming
            // 
            this.comboMedTiming.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMedTiming.Header = "給藥頻率";
            this.comboMedTiming.Location = new System.Drawing.Point(6, 21);
            this.comboMedTiming.Name = "comboMedTiming";
            this.comboMedTiming.Padding = new System.Windows.Forms.Padding(1);
            this.comboMedTiming.Size = new System.Drawing.Size(264, 31);
            this.comboMedTiming.TabIndex = 9;
            // 
            // comboUnit
            // 
            this.comboUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboUnit.Header = "單位";
            this.comboUnit.Location = new System.Drawing.Point(6, 131);
            this.comboUnit.Name = "comboUnit";
            this.comboUnit.Padding = new System.Windows.Forms.Padding(1);
            this.comboUnit.Size = new System.Drawing.Size(264, 31);
            this.comboUnit.TabIndex = 14;
            // 
            // MedicationRequestControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupEdit);
            this.Name = "MedicationRequestControl";
            this.Size = new System.Drawing.Size(286, 202);
            this.groupEdit.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupEdit;
        private System.Windows.Forms.DateTimePicker dateEnd;
        private System.Windows.Forms.DateTimePicker dateBegin;
        private Forms.CgLabelComboBox comboMedRoute;
        private Forms.CgLabelComboBox comboMedTiming;
        private Forms.CgLabelTextBox textInstruction;
        private Forms.CgLabelComboBox comboUnit;
    }
}
