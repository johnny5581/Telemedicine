
namespace Telemedicine.Observations
{
    partial class ObservationControl
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dateTime = new System.Windows.Forms.DateTimePicker();
            this.textValue2 = new Telemedicine.Forms.CgLabelTextBox();
            this.dateDate = new System.Windows.Forms.DateTimePicker();
            this.textUnit = new Telemedicine.Forms.CgLabelTextBox();
            this.comboItem = new Telemedicine.Forms.CgLabelComboBox();
            this.textValue = new Telemedicine.Forms.CgLabelTextBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dateTime);
            this.groupBox2.Controls.Add(this.textValue2);
            this.groupBox2.Controls.Add(this.dateDate);
            this.groupBox2.Controls.Add(this.textUnit);
            this.groupBox2.Controls.Add(this.comboItem);
            this.groupBox2.Controls.Add(this.textValue);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(266, 250);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "生理數值";
            // 
            // dateTime
            // 
            this.dateTime.CustomFormat = "HH:mm:ss";
            this.dateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTime.Location = new System.Drawing.Point(164, 222);
            this.dateTime.Name = "dateTime";
            this.dateTime.ShowUpDown = true;
            this.dateTime.Size = new System.Drawing.Size(93, 22);
            this.dateTime.TabIndex = 10;
            // 
            // textValue2
            // 
            this.textValue2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textValue2.Header = "數值2";
            this.textValue2.Location = new System.Drawing.Point(6, 91);
            this.textValue2.Name = "textValue2";
            this.textValue2.Padding = new System.Windows.Forms.Padding(1);
            this.textValue2.Size = new System.Drawing.Size(251, 30);
            this.textValue2.TabIndex = 3;
            this.textValue2.Visible = false;
            // 
            // dateDate
            // 
            this.dateDate.CustomFormat = "yyyy-MM-dd";
            this.dateDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDate.Location = new System.Drawing.Point(46, 222);
            this.dateDate.Name = "dateDate";
            this.dateDate.Size = new System.Drawing.Size(112, 22);
            this.dateDate.TabIndex = 9;
            // 
            // textUnit
            // 
            this.textUnit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textUnit.Header = "單位";
            this.textUnit.Location = new System.Drawing.Point(6, 127);
            this.textUnit.Name = "textUnit";
            this.textUnit.Padding = new System.Windows.Forms.Padding(1);
            this.textUnit.ReadOnly = true;
            this.textUnit.Size = new System.Drawing.Size(251, 30);
            this.textUnit.TabIndex = 2;
            // 
            // comboItem
            // 
            this.comboItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboItem.Header = "類別";
            this.comboItem.Location = new System.Drawing.Point(6, 21);
            this.comboItem.Name = "comboItem";
            this.comboItem.Padding = new System.Windows.Forms.Padding(1);
            this.comboItem.Size = new System.Drawing.Size(251, 31);
            this.comboItem.TabIndex = 1;
            this.comboItem.SelectedIndexChanged += new System.EventHandler(this.comboItem_SelectedIndexChanged);
            // 
            // textValue
            // 
            this.textValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textValue.Header = "數值";
            this.textValue.Location = new System.Drawing.Point(6, 55);
            this.textValue.Name = "textValue";
            this.textValue.Padding = new System.Windows.Forms.Padding(1);
            this.textValue.Size = new System.Drawing.Size(251, 30);
            this.textValue.TabIndex = 0;
            // 
            // ObservationControl
            // 
            this.Controls.Add(this.groupBox2);
            this.Name = "ObservationControl";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(272, 256);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private Forms.CgLabelTextBox textUnit;
        private Forms.CgLabelComboBox comboItem;
        private Forms.CgLabelTextBox textValue;
        private Forms.CgLabelTextBox textValue2;
        private System.Windows.Forms.DateTimePicker dateTime;
        private System.Windows.Forms.DateTimePicker dateDate;
    }
}
