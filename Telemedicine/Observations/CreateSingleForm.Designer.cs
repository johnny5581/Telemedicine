
namespace Telemedicine.Observations
{
    partial class CreateSingleForm
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonOk = new Telemedicine.Forms.CgIconButton();
            this.textUnit = new Telemedicine.Forms.CgLabelTextBox();
            this.comboItem = new Telemedicine.Forms.CgLabelComboBox();
            this.textValue = new Telemedicine.Forms.CgLabelTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textId = new Telemedicine.Forms.CgLabelControl();
            this.textSex = new Telemedicine.Forms.CgLabelTextBox();
            this.textBrithDate = new Telemedicine.Forms.CgLabelTextBox();
            this.textName = new Telemedicine.Forms.CgLabelTextBox();
            this.textSearch = new Telemedicine.Forms.CgLabelTextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dateTimePicker2);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.buttonOk);
            this.groupBox2.Controls.Add(this.textUnit);
            this.groupBox2.Controls.Add(this.comboItem);
            this.groupBox2.Controls.Add(this.textValue);
            this.groupBox2.Location = new System.Drawing.Point(195, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(280, 204);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "生理數值";
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonOk.IconSize = 0;
            this.buttonOk.Location = new System.Drawing.Point(199, 175);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 4;
            this.buttonOk.Text = "上傳";
            this.buttonOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // textUnit
            // 
            this.textUnit.Header = "單位";
            this.textUnit.Location = new System.Drawing.Point(6, 84);
            this.textUnit.Name = "textUnit";
            this.textUnit.Padding = new System.Windows.Forms.Padding(1);
            this.textUnit.ReadOnly = true;
            this.textUnit.Size = new System.Drawing.Size(251, 24);
            this.textUnit.TabIndex = 2;
            // 
            // comboItem
            // 
            this.comboItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboItem.Header = "類別";
            this.comboItem.Location = new System.Drawing.Point(6, 21);
            this.comboItem.Name = "comboItem";
            this.comboItem.Padding = new System.Windows.Forms.Padding(1);
            this.comboItem.Size = new System.Drawing.Size(251, 22);
            this.comboItem.TabIndex = 1;
            this.comboItem.SelectedIndexChanged += new System.EventHandler(this.comboItem_SelectedIndexChanged);
            // 
            // textValue
            // 
            this.textValue.Header = "數值";
            this.textValue.Location = new System.Drawing.Point(5, 54);
            this.textValue.Name = "textValue";
            this.textValue.Padding = new System.Windows.Forms.Padding(1);
            this.textValue.Size = new System.Drawing.Size(251, 24);
            this.textValue.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textId);
            this.groupBox1.Controls.Add(this.textSex);
            this.groupBox1.Controls.Add(this.textBrithDate);
            this.groupBox1.Controls.Add(this.textName);
            this.groupBox1.Location = new System.Drawing.Point(12, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(177, 174);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "病患資料";
            // 
            // textId
            // 
            this.textId.Header = "#";
            this.textId.HeaderAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textId.Location = new System.Drawing.Point(6, 24);
            this.textId.Name = "textId";
            this.textId.Padding = new System.Windows.Forms.Padding(1);
            this.textId.Size = new System.Drawing.Size(165, 14);
            this.textId.TabIndex = 6;
            // 
            // textSex
            // 
            this.textSex.Header = "性別";
            this.textSex.Location = new System.Drawing.Point(6, 104);
            this.textSex.Name = "textSex";
            this.textSex.Padding = new System.Windows.Forms.Padding(1);
            this.textSex.ReadOnly = true;
            this.textSex.Size = new System.Drawing.Size(165, 24);
            this.textSex.TabIndex = 5;
            // 
            // textBrithDate
            // 
            this.textBrithDate.Header = "生日";
            this.textBrithDate.Location = new System.Drawing.Point(6, 74);
            this.textBrithDate.Name = "textBrithDate";
            this.textBrithDate.Padding = new System.Windows.Forms.Padding(1);
            this.textBrithDate.ReadOnly = true;
            this.textBrithDate.Size = new System.Drawing.Size(165, 24);
            this.textBrithDate.TabIndex = 4;
            // 
            // textName
            // 
            this.textName.Header = "姓名";
            this.textName.Location = new System.Drawing.Point(6, 44);
            this.textName.Name = "textName";
            this.textName.Padding = new System.Windows.Forms.Padding(1);
            this.textName.ReadOnly = true;
            this.textName.Size = new System.Drawing.Size(165, 24);
            this.textName.TabIndex = 3;
            // 
            // textSearch
            // 
            this.textSearch.Header = "查詢";
            this.textSearch.Location = new System.Drawing.Point(12, 12);
            this.textSearch.Name = "textSearch";
            this.textSearch.Padding = new System.Windows.Forms.Padding(1);
            this.textSearch.Size = new System.Drawing.Size(177, 24);
            this.textSearch.TabIndex = 1;
            this.textSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textSearch_KeyDown);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(42, 114);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(110, 22);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker2.Location = new System.Drawing.Point(158, 114);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(98, 22);
            this.dateTimePicker2.TabIndex = 6;
            // 
            // CreateSingleForm
            // 
            this.ClientSize = new System.Drawing.Size(487, 228);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.textSearch);
            this.Controls.Add(this.groupBox1);
            this.Name = "CreateSingleForm";
            this.Text = "建立單筆";
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Forms.CgLabelTextBox textSearch;
        private System.Windows.Forms.GroupBox groupBox2;
        private Forms.CgLabelTextBox textValue;
        private Forms.CgLabelComboBox comboItem;
        private Forms.CgLabelTextBox textUnit;
        private Forms.CgLabelTextBox textName;
        private Forms.CgLabelTextBox textBrithDate;
        private Forms.CgLabelTextBox textSex;
        private Forms.CgLabelControl textId;
        private Forms.CgIconButton buttonOk;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
    }
}