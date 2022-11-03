
namespace Telemedicine.Meds
{
    partial class MedicationListForm
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
            this.dgvData = new Telemedicine.Forms.CgDataGridPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonCancel = new Telemedicine.Forms.CgIconButton();
            this.buttonInsert = new Telemedicine.Forms.CgIconButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvData
            // 
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.AutoFitColumnWidth = true;
            this.dgvData.InfoBoxVisible = false;
            this.dgvData.Location = new System.Drawing.Point(6, 21);
            this.dgvData.Name = "dgvData";
            this.dgvData.SearchBoxVisible = true;
            this.dgvData.Size = new System.Drawing.Size(411, 211);
            this.dgvData.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvData);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(423, 248);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "藥品查詢";
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonCancel.IconSize = 0;
            this.buttonCancel.Location = new System.Drawing.Point(360, 266);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "離開";
            this.buttonCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonInsert
            // 
            this.buttonInsert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonInsert.IconSize = 0;
            this.buttonInsert.Location = new System.Drawing.Point(279, 266);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(75, 23);
            this.buttonInsert.TabIndex = 5;
            this.buttonInsert.Text = "新增";
            this.buttonInsert.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonInsert.UseVisualStyleBackColor = true;
            this.buttonInsert.Click += new System.EventHandler(this.buttonInsert_Click);
            // 
            // MedicationListForm
            // 
            this.ClientSize = new System.Drawing.Size(447, 301);
            this.Controls.Add(this.buttonInsert);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBox1);
            this.Name = "MedicationListForm";
            this.Text = "藥品清單";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Forms.CgDataGridPanel dgvData;
        private System.Windows.Forms.GroupBox groupBox1;
        private Forms.CgIconButton buttonCancel;
        private Forms.CgIconButton buttonInsert;
    }
}