namespace Telemedicine.Meds
{
    partial class MedRequestCreateForm
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
            this.patientControl1 = new Telemedicine.Patients.PatientControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cgFlowLayoutPanel1 = new Telemedicine.Forms.CgFlowLayoutPanel();
            this.radioSourceOpd = new System.Windows.Forms.RadioButton();
            this.radioSourceIpd = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvData = new Telemedicine.Forms.CgDataGridPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonItemEdit = new Telemedicine.Forms.CgIconButton();
            this.buttonItemDelete = new Telemedicine.Forms.CgIconButton();
            this.buttonItemAdd = new Telemedicine.Forms.CgIconButton();
            this.buttonCreate = new Telemedicine.Forms.CgIconButton();
            this.comboMeta = new Telemedicine.Forms.CgLabelComboBox();
            this.groupBox1.SuspendLayout();
            this.cgFlowLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // patientControl1
            // 
            this.patientControl1.Location = new System.Drawing.Point(20, 20);
            this.patientControl1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.patientControl1.Name = "patientControl1";
            this.patientControl1.Size = new System.Drawing.Size(351, 291);
            this.patientControl1.TabIndex = 0;
            this.patientControl1.Title = "Patient";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.cgFlowLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(20, 382);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(351, 275);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "處方資訊";
            // 
            // cgFlowLayoutPanel1
            // 
            this.cgFlowLayoutPanel1.AutoMargin = true;
            this.cgFlowLayoutPanel1.AutoMarginSize = new System.Windows.Forms.Padding(0);
            this.cgFlowLayoutPanel1.AutoResizeChild = true;
            this.cgFlowLayoutPanel1.Controls.Add(this.radioSourceOpd);
            this.cgFlowLayoutPanel1.Controls.Add(this.radioSourceIpd);
            this.cgFlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cgFlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.cgFlowLayoutPanel1.Location = new System.Drawing.Point(4, 26);
            this.cgFlowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cgFlowLayoutPanel1.Name = "cgFlowLayoutPanel1";
            this.cgFlowLayoutPanel1.Size = new System.Drawing.Size(343, 245);
            this.cgFlowLayoutPanel1.TabIndex = 0;
            this.cgFlowLayoutPanel1.WrapContents = false;
            // 
            // radioSourceOpd
            // 
            this.radioSourceOpd.AutoSize = true;
            this.radioSourceOpd.Location = new System.Drawing.Point(4, 4);
            this.radioSourceOpd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioSourceOpd.Name = "radioSourceOpd";
            this.radioSourceOpd.Size = new System.Drawing.Size(69, 22);
            this.radioSourceOpd.TabIndex = 0;
            this.radioSourceOpd.TabStop = true;
            this.radioSourceOpd.Text = "門診";
            this.radioSourceOpd.UseVisualStyleBackColor = true;
            // 
            // radioSourceIpd
            // 
            this.radioSourceIpd.AutoSize = true;
            this.radioSourceIpd.Location = new System.Drawing.Point(4, 34);
            this.radioSourceIpd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioSourceIpd.Name = "radioSourceIpd";
            this.radioSourceIpd.Size = new System.Drawing.Size(69, 22);
            this.radioSourceIpd.TabIndex = 1;
            this.radioSourceIpd.TabStop = true;
            this.radioSourceIpd.Text = "住院";
            this.radioSourceIpd.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dgvData);
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Location = new System.Drawing.Point(380, 18);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(802, 550);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "給藥";
            // 
            // dgvData
            // 
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.InfoBoxVisible = false;
            this.dgvData.InfoBoxWidth = 224;
            this.dgvData.Location = new System.Drawing.Point(4, 83);
            this.dgvData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvData.Name = "dgvData";
            this.dgvData.SearchBoxWidth = 224;
            this.dgvData.Size = new System.Drawing.Size(794, 463);
            this.dgvData.TabIndex = 1;
            this.dgvData.TopPanelVisible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonItemEdit);
            this.panel1.Controls.Add(this.buttonItemDelete);
            this.panel1.Controls.Add(this.buttonItemAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(4, 26);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 57);
            this.panel1.TabIndex = 0;
            // 
            // buttonItemEdit
            // 
            this.buttonItemEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonItemEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonItemEdit.Location = new System.Drawing.Point(555, 14);
            this.buttonItemEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonItemEdit.Name = "buttonItemEdit";
            this.buttonItemEdit.Size = new System.Drawing.Size(112, 34);
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
            this.buttonItemDelete.Location = new System.Drawing.Point(676, 14);
            this.buttonItemDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonItemDelete.Name = "buttonItemDelete";
            this.buttonItemDelete.Size = new System.Drawing.Size(112, 34);
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
            this.buttonItemAdd.Location = new System.Drawing.Point(434, 14);
            this.buttonItemAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonItemAdd.Name = "buttonItemAdd";
            this.buttonItemAdd.Size = new System.Drawing.Size(112, 34);
            this.buttonItemAdd.TabIndex = 0;
            this.buttonItemAdd.Text = "新增";
            this.buttonItemAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonItemAdd.UseVisualStyleBackColor = true;
            this.buttonItemAdd.Click += new System.EventHandler(this.buttonItemAdd_Click);
            // 
            // buttonCreate
            // 
            this.buttonCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCreate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonCreate.Location = new System.Drawing.Point(966, 578);
            this.buttonCreate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(216, 80);
            this.buttonCreate.TabIndex = 7;
            this.buttonCreate.Text = "建立";
            this.buttonCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // comboMeta
            // 
            this.comboMeta.Header = "META";
            this.comboMeta.Location = new System.Drawing.Point(20, 319);
            this.comboMeta.Margin = new System.Windows.Forms.Padding(2);
            this.comboMeta.Name = "comboMeta";
            this.comboMeta.Padding = new System.Windows.Forms.Padding(2);
            this.comboMeta.Size = new System.Drawing.Size(351, 40);
            this.comboMeta.TabIndex = 12;
            // 
            // MedRequestCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 675);
            this.Controls.Add(this.comboMeta);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.patientControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MedRequestCreateForm";
            this.Text = "開立處方簽";
            this.groupBox1.ResumeLayout(false);
            this.cgFlowLayoutPanel1.ResumeLayout(false);
            this.cgFlowLayoutPanel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Patients.PatientControl patientControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Forms.CgFlowLayoutPanel cgFlowLayoutPanel1;
        private System.Windows.Forms.RadioButton radioSourceOpd;
        private System.Windows.Forms.RadioButton radioSourceIpd;
        private System.Windows.Forms.GroupBox groupBox3;
        private Forms.CgDataGridPanel dgvData;
        private System.Windows.Forms.Panel panel1;
        private Forms.CgIconButton buttonItemEdit;
        private Forms.CgIconButton buttonItemDelete;
        private Forms.CgIconButton buttonItemAdd;
        private Forms.CgIconButton buttonCreate;
        private Forms.CgLabelComboBox comboMeta;
    }
}