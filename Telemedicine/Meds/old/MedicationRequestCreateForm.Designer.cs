
namespace Telemedicine.Meds
{
    partial class MedicationRequestCreateForm
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvData = new Telemedicine.Forms.CgDataGridPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonItemEdit = new Telemedicine.Forms.CgIconButton();
            this.buttonItemDelete = new Telemedicine.Forms.CgIconButton();
            this.buttonItemAdd = new Telemedicine.Forms.CgIconButton();
            this.groupPat = new System.Windows.Forms.GroupBox();
            this.radioPatIPD = new System.Windows.Forms.RadioButton();
            this.radioPatOPD = new System.Windows.Forms.RadioButton();
            this.buttonPat = new Telemedicine.Forms.CgIconButton();
            this.textPatId = new Telemedicine.Forms.CgLabelControl();
            this.textPatSex = new Telemedicine.Forms.CgLabelTextBox();
            this.textPatBrithDate = new Telemedicine.Forms.CgLabelTextBox();
            this.textPatName = new Telemedicine.Forms.CgLabelTextBox();
            this.buttonCreate = new Telemedicine.Forms.CgIconButton();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupPat.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dgvData);
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Location = new System.Drawing.Point(195, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(409, 222);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "給藥";
            // 
            // dgvData
            // 
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.InfoBoxVisible = false;
            this.dgvData.Location = new System.Drawing.Point(3, 56);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(403, 163);
            this.dgvData.TabIndex = 1;
            this.dgvData.TopPanelVisible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonItemEdit);
            this.panel1.Controls.Add(this.buttonItemDelete);
            this.panel1.Controls.Add(this.buttonItemAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(403, 38);
            this.panel1.TabIndex = 0;
            // 
            // buttonItemEdit
            // 
            this.buttonItemEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonItemEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonItemEdit.Location = new System.Drawing.Point(244, 9);
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
            this.buttonItemDelete.Location = new System.Drawing.Point(325, 9);
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
            this.buttonItemAdd.Location = new System.Drawing.Point(163, 9);
            this.buttonItemAdd.Name = "buttonItemAdd";
            this.buttonItemAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonItemAdd.TabIndex = 0;
            this.buttonItemAdd.Text = "新增";
            this.buttonItemAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonItemAdd.UseVisualStyleBackColor = true;
            this.buttonItemAdd.Click += new System.EventHandler(this.buttonItemAdd_Click);
            // 
            // groupPat
            // 
            this.groupPat.Controls.Add(this.radioPatIPD);
            this.groupPat.Controls.Add(this.radioPatOPD);
            this.groupPat.Controls.Add(this.buttonPat);
            this.groupPat.Controls.Add(this.textPatId);
            this.groupPat.Controls.Add(this.textPatSex);
            this.groupPat.Controls.Add(this.textPatBrithDate);
            this.groupPat.Controls.Add(this.textPatName);
            this.groupPat.Location = new System.Drawing.Point(12, 12);
            this.groupPat.Name = "groupPat";
            this.groupPat.Size = new System.Drawing.Size(177, 222);
            this.groupPat.TabIndex = 2;
            this.groupPat.TabStop = false;
            this.groupPat.Text = "病患資料";
            // 
            // radioPatIPD
            // 
            this.radioPatIPD.AutoSize = true;
            this.radioPatIPD.Location = new System.Drawing.Point(6, 187);
            this.radioPatIPD.Name = "radioPatIPD";
            this.radioPatIPD.Size = new System.Drawing.Size(47, 16);
            this.radioPatIPD.TabIndex = 9;
            this.radioPatIPD.Text = "住院";
            this.radioPatIPD.UseVisualStyleBackColor = true;
            // 
            // radioPatOPD
            // 
            this.radioPatOPD.AutoSize = true;
            this.radioPatOPD.Checked = true;
            this.radioPatOPD.Location = new System.Drawing.Point(6, 165);
            this.radioPatOPD.Name = "radioPatOPD";
            this.radioPatOPD.Size = new System.Drawing.Size(47, 16);
            this.radioPatOPD.TabIndex = 8;
            this.radioPatOPD.TabStop = true;
            this.radioPatOPD.Text = "門診";
            this.radioPatOPD.UseVisualStyleBackColor = true;
            // 
            // buttonPat
            // 
            this.buttonPat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
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
            this.textPatId.Size = new System.Drawing.Size(165, 14);
            this.textPatId.TabIndex = 6;
            // 
            // textPatSex
            // 
            this.textPatSex.Header = "性別";
            this.textPatSex.Location = new System.Drawing.Point(6, 129);
            this.textPatSex.Name = "textPatSex";
            this.textPatSex.ReadOnly = true;
            this.textPatSex.Size = new System.Drawing.Size(165, 30);
            this.textPatSex.TabIndex = 5;
            // 
            // textPatBrithDate
            // 
            this.textPatBrithDate.Header = "生日";
            this.textPatBrithDate.Location = new System.Drawing.Point(6, 99);
            this.textPatBrithDate.Name = "textPatBrithDate";
            this.textPatBrithDate.ReadOnly = true;
            this.textPatBrithDate.Size = new System.Drawing.Size(165, 30);
            this.textPatBrithDate.TabIndex = 4;
            // 
            // textPatName
            // 
            this.textPatName.Header = "姓名";
            this.textPatName.Location = new System.Drawing.Point(6, 69);
            this.textPatName.Name = "textPatName";
            this.textPatName.ReadOnly = true;
            this.textPatName.Size = new System.Drawing.Size(165, 30);
            this.textPatName.TabIndex = 3;
            // 
            // buttonCreate
            // 
            this.buttonCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCreate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonCreate.Location = new System.Drawing.Point(460, 240);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(144, 53);
            this.buttonCreate.TabIndex = 6;
            this.buttonCreate.Text = "建立";
            this.buttonCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // MedicationRequestCreateForm
            // 
            this.ClientSize = new System.Drawing.Size(616, 305);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupPat);
            this.Name = "MedicationRequestCreateForm";
            this.Text = "開立處方籤";
            this.groupBox3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupPat.ResumeLayout(false);
            this.groupPat.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupPat;
        private Forms.CgIconButton buttonPat;
        private Forms.CgLabelControl textPatId;
        private Forms.CgLabelTextBox textPatSex;
        private Forms.CgLabelTextBox textPatBrithDate;
        private Forms.CgLabelTextBox textPatName;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel1;
        private Forms.CgIconButton buttonItemDelete;
        private Forms.CgIconButton buttonItemAdd;
        private System.Windows.Forms.RadioButton radioPatIPD;
        private System.Windows.Forms.RadioButton radioPatOPD;
        private Forms.CgIconButton buttonCreate;
        private Forms.CgDataGridPanel dgvData;
        private Forms.CgIconButton buttonItemEdit;
    }
}