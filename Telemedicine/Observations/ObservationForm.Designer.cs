
namespace Telemedicine.Observations
{
    partial class ObservationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ObservationForm));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonSearch = new Telemedicine.Forms.CgIconButton();
            this.dgvData = new Telemedicine.Forms.CgDataGridPanel();
            this.textId = new Telemedicine.Forms.CgLabelControl();
            this.textSex = new Telemedicine.Forms.CgLabelTextBox();
            this.textBrithDate = new Telemedicine.Forms.CgLabelTextBox();
            this.textName = new Telemedicine.Forms.CgLabelTextBox();
            this.comboVs = new Telemedicine.Forms.CgLabelComboBox();
            this.textSearch = new Telemedicine.Forms.CgLabelTextBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textId);
            this.groupBox2.Controls.Add(this.textSex);
            this.groupBox2.Controls.Add(this.textBrithDate);
            this.groupBox2.Controls.Add(this.textName);
            this.groupBox2.Location = new System.Drawing.Point(411, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(353, 80);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "使用者";
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonSearch.Icon = "FontAwesome.Search";
            this.buttonSearch.IconSize = 0;
            this.buttonSearch.Image = ((System.Drawing.Image)(resources.GetObject("buttonSearch.Image")));
            this.buttonSearch.Location = new System.Drawing.Point(330, 12);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 80);
            this.buttonSearch.TabIndex = 5;
            this.buttonSearch.Text = "查詢";
            this.buttonSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // dgvData
            // 
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.Location = new System.Drawing.Point(12, 98);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(752, 414);
            this.dgvData.TabIndex = 4;
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
            this.textSex.Location = new System.Drawing.Point(177, 44);
            this.textSex.Name = "textSex";
            this.textSex.Padding = new System.Windows.Forms.Padding(1);
            this.textSex.ReadOnly = true;
            this.textSex.Size = new System.Drawing.Size(165, 24);
            this.textSex.TabIndex = 5;
            // 
            // textBrithDate
            // 
            this.textBrithDate.Header = "生日";
            this.textBrithDate.Location = new System.Drawing.Point(177, 14);
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
            // comboVs
            // 
            this.comboVs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboVs.Header = "查詢類型";
            this.comboVs.Location = new System.Drawing.Point(13, 43);
            this.comboVs.Name = "comboVs";
            this.comboVs.Padding = new System.Windows.Forms.Padding(1);
            this.comboVs.Size = new System.Drawing.Size(261, 22);
            this.comboVs.TabIndex = 1;
            // 
            // textSearch
            // 
            this.textSearch.Header = "識別碼";
            this.textSearch.Location = new System.Drawing.Point(13, 13);
            this.textSearch.Name = "textSearch";
            this.textSearch.Padding = new System.Windows.Forms.Padding(1);
            this.textSearch.Size = new System.Drawing.Size(261, 24);
            this.textSearch.TabIndex = 0;
            // 
            // ObservationForm
            // 
            this.ClientSize = new System.Drawing.Size(776, 524);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.comboVs);
            this.Controls.Add(this.textSearch);
            this.Name = "ObservationForm";
            this.Text = "生理數值查詢";
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Forms.CgLabelTextBox textSearch;
        private Forms.CgLabelComboBox comboVs;
        private System.Windows.Forms.GroupBox groupBox2;
        private Forms.CgLabelControl textId;
        private Forms.CgLabelTextBox textSex;
        private Forms.CgLabelTextBox textBrithDate;
        private Forms.CgLabelTextBox textName;
        private Forms.CgDataGridPanel dgvData;
        private Forms.CgIconButton buttonSearch;
    }
}