namespace Telemedicine.Meds
{
    partial class MedAdminCreateForm
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
            this.medRequestControl1 = new Telemedicine.Meds.MedRequestControl();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvData = new Telemedicine.Forms.CgDataGridPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonItemEdit = new Telemedicine.Forms.CgIconButton();
            this.buttonItemDelete = new Telemedicine.Forms.CgIconButton();
            this.buttonItemAdd = new Telemedicine.Forms.CgIconButton();
            this.buttonCreate = new Telemedicine.Forms.CgIconButton();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // medRequestControl1
            // 
            this.medRequestControl1.Location = new System.Drawing.Point(12, 12);
            this.medRequestControl1.Name = "medRequestControl1";
            this.medRequestControl1.Size = new System.Drawing.Size(285, 139);
            this.medRequestControl1.TabIndex = 0;
            this.medRequestControl1.Title = "MedicationRequest";
            this.medRequestControl1.ItemPicked += new System.EventHandler(this.medRequestControl1_ItemPicked);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dgvData);
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Location = new System.Drawing.Point(303, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(410, 373);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "用藥紀錄";
            // 
            // dgvData
            // 
            this.dgvData.AutoFitColumnWidth = true;
            this.dgvData.AutoGenerateColumns = true;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.InfoBoxVisible = false;
            this.dgvData.Location = new System.Drawing.Point(3, 56);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(404, 314);
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
            this.panel1.Size = new System.Drawing.Size(404, 38);
            this.panel1.TabIndex = 0;
            // 
            // buttonItemEdit
            // 
            this.buttonItemEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonItemEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonItemEdit.Location = new System.Drawing.Point(245, 9);
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
            this.buttonItemDelete.Location = new System.Drawing.Point(326, 9);
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
            this.buttonItemAdd.Location = new System.Drawing.Point(164, 9);
            this.buttonItemAdd.Name = "buttonItemAdd";
            this.buttonItemAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonItemAdd.TabIndex = 0;
            this.buttonItemAdd.Text = "新增";
            this.buttonItemAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonItemAdd.UseVisualStyleBackColor = true;
            this.buttonItemAdd.Click += new System.EventHandler(this.buttonItemAdd_Click);
            // 
            // buttonCreate
            // 
            this.buttonCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCreate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonCreate.Location = new System.Drawing.Point(12, 332);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(285, 53);
            this.buttonCreate.TabIndex = 7;
            this.buttonCreate.Text = "建立";
            this.buttonCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // MedAdminCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 397);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.medRequestControl1);
            this.Name = "MedAdminCreateForm";
            this.Text = "用藥紀錄";
            this.groupBox3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MedRequestControl medRequestControl1;
        private System.Windows.Forms.GroupBox groupBox3;
        private Forms.CgDataGridPanel dgvData;
        private System.Windows.Forms.Panel panel1;
        private Forms.CgIconButton buttonItemEdit;
        private Forms.CgIconButton buttonItemDelete;
        private Forms.CgIconButton buttonItemAdd;
        private Forms.CgIconButton buttonCreate;
    }
}