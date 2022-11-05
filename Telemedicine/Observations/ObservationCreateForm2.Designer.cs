namespace Telemedicine.Observations
{
    partial class ObservationCreateForm2
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
            this.medRequestControl1 = new Telemedicine.Meds.MedRequestControl();
            this.serviceRequestControl1 = new Telemedicine.Services.ServiceRequestControl();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvData = new Telemedicine.Forms.CgDataGridPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonItemAddBatch = new Telemedicine.Forms.CgIconButton();
            this.buttonItemAddEKG = new Telemedicine.Forms.CgIconButton();
            this.buttonItemEdit = new Telemedicine.Forms.CgIconButton();
            this.buttonItemDelete = new Telemedicine.Forms.CgIconButton();
            this.buttonItemAdd = new Telemedicine.Forms.CgIconButton();
            this.buttonUpload = new Telemedicine.Forms.CgIconButton();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // patientControl1
            // 
            this.patientControl1.Location = new System.Drawing.Point(12, 12);
            this.patientControl1.Name = "patientControl1";
            this.patientControl1.Size = new System.Drawing.Size(236, 176);
            this.patientControl1.TabIndex = 0;
            this.patientControl1.Title = "Patient";
            // 
            // medRequestControl1
            // 
            this.medRequestControl1.Location = new System.Drawing.Point(12, 194);
            this.medRequestControl1.Name = "medRequestControl1";
            this.medRequestControl1.Size = new System.Drawing.Size(236, 134);
            this.medRequestControl1.TabIndex = 1;
            this.medRequestControl1.Title = "MedicationRequest";
            // 
            // serviceRequestControl1
            // 
            this.serviceRequestControl1.Location = new System.Drawing.Point(12, 334);
            this.serviceRequestControl1.Name = "serviceRequestControl1";
            this.serviceRequestControl1.Size = new System.Drawing.Size(236, 88);
            this.serviceRequestControl1.TabIndex = 2;
            this.serviceRequestControl1.Title = "ServiceRequest";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dgvData);
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Location = new System.Drawing.Point(254, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(534, 468);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "紀錄";
            // 
            // dgvData
            // 
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.InfoBoxVisible = false;
            this.dgvData.Location = new System.Drawing.Point(3, 53);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(528, 412);
            this.dgvData.TabIndex = 3;
            this.dgvData.TopPanelVisible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonItemAddBatch);
            this.panel1.Controls.Add(this.buttonItemAddEKG);
            this.panel1.Controls.Add(this.buttonItemEdit);
            this.panel1.Controls.Add(this.buttonItemDelete);
            this.panel1.Controls.Add(this.buttonItemAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(528, 35);
            this.panel1.TabIndex = 0;
            // 
            // buttonItemAddBatch
            // 
            this.buttonItemAddBatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonItemAddBatch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonItemAddBatch.Location = new System.Drawing.Point(207, 5);
            this.buttonItemAddBatch.Name = "buttonItemAddBatch";
            this.buttonItemAddBatch.Size = new System.Drawing.Size(75, 23);
            this.buttonItemAddBatch.TabIndex = 5;
            this.buttonItemAddBatch.Text = "批次新增";
            this.buttonItemAddBatch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonItemAddBatch.UseVisualStyleBackColor = true;
            this.buttonItemAddBatch.Click += new System.EventHandler(this.buttonItemAddBatch_Click);
            // 
            // buttonItemAddEKG
            // 
            this.buttonItemAddEKG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonItemAddEKG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonItemAddEKG.Location = new System.Drawing.Point(126, 5);
            this.buttonItemAddEKG.Name = "buttonItemAddEKG";
            this.buttonItemAddEKG.Size = new System.Drawing.Size(75, 23);
            this.buttonItemAddEKG.TabIndex = 4;
            this.buttonItemAddEKG.Text = "新增EKG";
            this.buttonItemAddEKG.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonItemAddEKG.UseVisualStyleBackColor = true;
            this.buttonItemAddEKG.Click += new System.EventHandler(this.buttonItemAddEKG_Click);
            // 
            // buttonItemEdit
            // 
            this.buttonItemEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonItemEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonItemEdit.Location = new System.Drawing.Point(369, 5);
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
            this.buttonItemDelete.Location = new System.Drawing.Point(450, 5);
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
            this.buttonItemAdd.Location = new System.Drawing.Point(288, 5);
            this.buttonItemAdd.Name = "buttonItemAdd";
            this.buttonItemAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonItemAdd.TabIndex = 0;
            this.buttonItemAdd.Text = "新增";
            this.buttonItemAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonItemAdd.UseVisualStyleBackColor = true;
            this.buttonItemAdd.Click += new System.EventHandler(this.buttonItemAdd_Click);
            // 
            // buttonUpload
            // 
            this.buttonUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonUpload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonUpload.Location = new System.Drawing.Point(12, 426);
            this.buttonUpload.Name = "buttonUpload";
            this.buttonUpload.Size = new System.Drawing.Size(236, 51);
            this.buttonUpload.TabIndex = 6;
            this.buttonUpload.Text = "上傳";
            this.buttonUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonUpload.UseVisualStyleBackColor = true;
            this.buttonUpload.Click += new System.EventHandler(this.buttonUpload_Click);
            // 
            // ObservationCreateForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 508);
            this.Controls.Add(this.buttonUpload);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.serviceRequestControl1);
            this.Controls.Add(this.medRequestControl1);
            this.Controls.Add(this.patientControl1);
            this.Name = "ObservationCreateForm2";
            this.Text = "建立生理數值";
            this.groupBox3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Patients.PatientControl patientControl1;
        private Meds.MedRequestControl medRequestControl1;
        private Services.ServiceRequestControl serviceRequestControl1;
        private System.Windows.Forms.GroupBox groupBox3;
        private Forms.CgDataGridPanel dgvData;
        private System.Windows.Forms.Panel panel1;
        private Forms.CgIconButton buttonItemAddEKG;
        private Forms.CgIconButton buttonItemEdit;
        private Forms.CgIconButton buttonItemDelete;
        private Forms.CgIconButton buttonItemAdd;
        private Forms.CgIconButton buttonUpload;
        private Forms.CgIconButton buttonItemAddBatch;
    }
}