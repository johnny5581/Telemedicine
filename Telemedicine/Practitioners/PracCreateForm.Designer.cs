namespace Telemedicine.Practitioners
{
    partial class PracCreateForm
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
            this.textId = new Telemedicine.Forms.CgLabelTextBox();
            this.textName = new Telemedicine.Forms.CgLabelTextBox();
            this.textIdVal = new Telemedicine.Forms.CgLabelTextBox();
            this.textIdSys = new Telemedicine.Forms.CgLabelTextBox();
            this.buttonCreate = new Telemedicine.Forms.CgIconButton();
            this.SuspendLayout();
            // 
            // textId
            // 
            this.textId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textId.Header = "#";
            this.textId.HeaderAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textId.Location = new System.Drawing.Point(12, 12);
            this.textId.Name = "textId";
            this.textId.Size = new System.Drawing.Size(265, 30);
            this.textId.TabIndex = 12;
            // 
            // textName
            // 
            this.textName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textName.Header = "姓名";
            this.textName.Location = new System.Drawing.Point(12, 122);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(265, 30);
            this.textName.TabIndex = 11;
            this.textName.Text = "王曉明";
            // 
            // textIdVal
            // 
            this.textIdVal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textIdVal.Header = "識別碼";
            this.textIdVal.Location = new System.Drawing.Point(12, 86);
            this.textIdVal.Name = "textIdVal";
            this.textIdVal.Size = new System.Drawing.Size(265, 30);
            this.textIdVal.TabIndex = 10;
            this.textIdVal.Text = "XYZ";
            // 
            // textIdSys
            // 
            this.textIdSys.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textIdSys.Header = "識別系統";
            this.textIdSys.Location = new System.Drawing.Point(12, 50);
            this.textIdSys.Name = "textIdSys";
            this.textIdSys.Size = new System.Drawing.Size(265, 30);
            this.textIdSys.TabIndex = 9;
            this.textIdSys.Text = "https://www.cgmh.org.tw";
            // 
            // buttonCreate
            // 
            this.buttonCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCreate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonCreate.Location = new System.Drawing.Point(133, 168);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(144, 53);
            this.buttonCreate.TabIndex = 13;
            this.buttonCreate.Text = "建立";
            this.buttonCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // PracCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 233);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.textId);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.textIdVal);
            this.Controls.Add(this.textIdSys);
            this.Name = "PracCreateForm";
            this.Text = "PracCreateForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Forms.CgLabelTextBox textId;
        private Forms.CgLabelTextBox textName;
        private Forms.CgLabelTextBox textIdVal;
        private Forms.CgLabelTextBox textIdSys;
        private Forms.CgIconButton buttonCreate;
    }
}