namespace Telemedicine.Meds
{
    partial class MedListDialog
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
            this.buttonInsert = new Telemedicine.Forms.CgIconButton();
            this.buttonCancel = new Telemedicine.Forms.CgIconButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvData = new Telemedicine.Forms.CgDataGridPanel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonInsert
            // 
            this.buttonInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonInsert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonInsert.Location = new System.Drawing.Point(279, 266);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(75, 23);
            this.buttonInsert.TabIndex = 8;
            this.buttonInsert.Text = "新增";
            this.buttonInsert.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonInsert.UseVisualStyleBackColor = true;
            this.buttonInsert.Click += new System.EventHandler(this.buttonInsert_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonCancel.Location = new System.Drawing.Point(360, 266);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "離開";
            this.buttonCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgvData);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(423, 248);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "藥品查詢";
            // 
            // dgvData
            // 
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.AutoFitColumnWidth = true;
            this.dgvData.InfoBoxVisible = false;
            this.dgvData.Location = new System.Drawing.Point(6, 21);
            this.dgvData.Name = "dgvData";
            this.dgvData.SearchBoxVisible = true;
            this.dgvData.Size = new System.Drawing.Size(411, 211);
            this.dgvData.TabIndex = 0;
            // 
            // MedListDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 299);
            this.Controls.Add(this.buttonInsert);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBox1);
            this.Name = "MedListDialog";
            this.Text = "MedListDialog";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Forms.CgIconButton buttonInsert;
        private Forms.CgIconButton buttonCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private Forms.CgDataGridPanel dgvData;
    }
}