
namespace Telemedicine.Observations
{
    partial class ObservationCreateForm
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
            this.buttonUpload = new Telemedicine.Forms.CgIconButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvData = new Telemedicine.Forms.CgDataGridPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonItemEdit = new Telemedicine.Forms.CgIconButton();
            this.buttonItemDelete = new Telemedicine.Forms.CgIconButton();
            this.buttonItemAdd = new Telemedicine.Forms.CgIconButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textMedId = new Telemedicine.Forms.CgTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonPat = new Telemedicine.Forms.CgIconButton();
            this.textPatId = new Telemedicine.Forms.CgLabelControl();
            this.textPatSex = new Telemedicine.Forms.CgLabelTextBox();
            this.textPatBrithDate = new Telemedicine.Forms.CgLabelTextBox();
            this.textPatName = new Telemedicine.Forms.CgLabelTextBox();
            this.cgIconButton1 = new Telemedicine.Forms.CgIconButton();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonUpload
            // 
            this.buttonUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUpload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonUpload.IconSize = 0;
            this.buttonUpload.Location = new System.Drawing.Point(472, 277);
            this.buttonUpload.Name = "buttonUpload";
            this.buttonUpload.Size = new System.Drawing.Size(162, 51);
            this.buttonUpload.TabIndex = 5;
            this.buttonUpload.Text = "上傳";
            this.buttonUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonUpload.UseVisualStyleBackColor = true;
            this.buttonUpload.Click += new System.EventHandler(this.buttonUpload_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dgvData);
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Location = new System.Drawing.Point(196, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(438, 258);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "紀錄";
            // 
            // dgvData
            // 
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.InfoBoxVisible = false;
            this.dgvData.Location = new System.Drawing.Point(3, 56);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(432, 199);
            this.dgvData.TabIndex = 3;
            this.dgvData.TopPanelVisible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cgIconButton1);
            this.panel1.Controls.Add(this.buttonItemEdit);
            this.panel1.Controls.Add(this.buttonItemDelete);
            this.panel1.Controls.Add(this.buttonItemAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(432, 38);
            this.panel1.TabIndex = 0;
            // 
            // buttonItemEdit
            // 
            this.buttonItemEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonItemEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonItemEdit.IconSize = 0;
            this.buttonItemEdit.Location = new System.Drawing.Point(273, 9);
            this.buttonItemEdit.Name = "buttonItemEdit";
            this.buttonItemEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonItemEdit.TabIndex = 2;
            this.buttonItemEdit.Text = "修改";
            this.buttonItemEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonItemEdit.UseVisualStyleBackColor = true;
            this.buttonItemEdit.Click += new System.EventHandler(this.buttonItemEdit_Click);
            // 
            // buttonItemDelete
            // 
            this.buttonItemDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonItemDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonItemDelete.IconSize = 0;
            this.buttonItemDelete.Location = new System.Drawing.Point(354, 9);
            this.buttonItemDelete.Name = "buttonItemDelete";
            this.buttonItemDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonItemDelete.TabIndex = 1;
            this.buttonItemDelete.Text = "刪除";
            this.buttonItemDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonItemDelete.UseVisualStyleBackColor = true;
            this.buttonItemDelete.Click += new System.EventHandler(this.buttonItemDelete_Click);
            // 
            // buttonItemAdd
            // 
            this.buttonItemAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonItemAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonItemAdd.IconSize = 0;
            this.buttonItemAdd.Location = new System.Drawing.Point(192, 9);
            this.buttonItemAdd.Name = "buttonItemAdd";
            this.buttonItemAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonItemAdd.TabIndex = 0;
            this.buttonItemAdd.Text = "新增";
            this.buttonItemAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonItemAdd.UseVisualStyleBackColor = true;
            this.buttonItemAdd.Click += new System.EventHandler(this.buttonItemAdd_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textMedId);
            this.groupBox2.Location = new System.Drawing.Point(12, 214);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(177, 57);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "處方簽";
            // 
            // textMedId
            // 
            this.textMedId.Location = new System.Drawing.Point(6, 21);
            this.textMedId.Name = "textMedId";
            this.textMedId.Size = new System.Drawing.Size(165, 22);
            this.textMedId.TabIndex = 8;
            this.textMedId.Text = "9401";
            this.textMedId.WatermarkText = "輸入MedReqID";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonPat);
            this.groupBox1.Controls.Add(this.textPatId);
            this.groupBox1.Controls.Add(this.textPatSex);
            this.groupBox1.Controls.Add(this.textPatBrithDate);
            this.groupBox1.Controls.Add(this.textPatName);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(177, 167);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "病患資料";
            // 
            // buttonPat
            // 
            this.buttonPat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonPat.IconSize = 0;
            this.buttonPat.Location = new System.Drawing.Point(96, 20);
            this.buttonPat.Name = "buttonPat";
            this.buttonPat.Size = new System.Drawing.Size(75, 23);
            this.buttonPat.TabIndex = 7;
            this.buttonPat.Text = "選擇病人";
            this.buttonPat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonPat.UseVisualStyleBackColor = true;
            this.buttonPat.Click += new System.EventHandler(this.buttonPat_Click);
            // 
            // textPatId
            // 
            this.textPatId.Header = "#";
            this.textPatId.HeaderAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textPatId.Location = new System.Drawing.Point(6, 49);
            this.textPatId.Name = "textPatId";
            this.textPatId.Padding = new System.Windows.Forms.Padding(1);
            this.textPatId.Size = new System.Drawing.Size(165, 14);
            this.textPatId.TabIndex = 6;
            // 
            // textPatSex
            // 
            this.textPatSex.Header = "性別";
            this.textPatSex.Location = new System.Drawing.Point(6, 129);
            this.textPatSex.Name = "textPatSex";
            this.textPatSex.Padding = new System.Windows.Forms.Padding(1);
            this.textPatSex.ReadOnly = true;
            this.textPatSex.Size = new System.Drawing.Size(165, 30);
            this.textPatSex.TabIndex = 5;
            // 
            // textPatBrithDate
            // 
            this.textPatBrithDate.Header = "生日";
            this.textPatBrithDate.Location = new System.Drawing.Point(6, 99);
            this.textPatBrithDate.Name = "textPatBrithDate";
            this.textPatBrithDate.Padding = new System.Windows.Forms.Padding(1);
            this.textPatBrithDate.ReadOnly = true;
            this.textPatBrithDate.Size = new System.Drawing.Size(165, 30);
            this.textPatBrithDate.TabIndex = 4;
            // 
            // textPatName
            // 
            this.textPatName.Header = "姓名";
            this.textPatName.Location = new System.Drawing.Point(6, 69);
            this.textPatName.Name = "textPatName";
            this.textPatName.Padding = new System.Windows.Forms.Padding(1);
            this.textPatName.ReadOnly = true;
            this.textPatName.Size = new System.Drawing.Size(165, 30);
            this.textPatName.TabIndex = 3;
            // 
            // cgIconButton1
            // 
            this.cgIconButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cgIconButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cgIconButton1.IconSize = 0;
            this.cgIconButton1.Location = new System.Drawing.Point(111, 9);
            this.cgIconButton1.Name = "cgIconButton1";
            this.cgIconButton1.Size = new System.Drawing.Size(75, 23);
            this.cgIconButton1.TabIndex = 3;
            this.cgIconButton1.Text = "批次新增";
            this.cgIconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cgIconButton1.UseVisualStyleBackColor = true;
            this.cgIconButton1.Click += new System.EventHandler(this.cgIconButton1_Click);
            // 
            // ObservationCreateForm
            // 
            this.ClientSize = new System.Drawing.Size(646, 337);
            this.Controls.Add(this.buttonUpload);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ObservationCreateForm";
            this.Text = "新增生理數值";
            this.groupBox3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Forms.CgLabelControl textPatId;
        private Forms.CgLabelTextBox textPatSex;
        private Forms.CgLabelTextBox textPatBrithDate;
        private Forms.CgLabelTextBox textPatName;
        private System.Windows.Forms.GroupBox groupBox2;
        private Forms.CgTextBox textMedId;
        private Forms.CgDataGridPanel dgvData;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel1;
        private Forms.CgIconButton buttonItemAdd;
        private Forms.CgIconButton buttonItemDelete;
        private Forms.CgIconButton buttonUpload;
        private Forms.CgIconButton buttonItemEdit;
        private Forms.CgIconButton buttonPat;
        private Forms.CgIconButton cgIconButton1;
    }
}