namespace Telemedicine.Orgs
{
    partial class OrgCreateForm
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
            this.textIdSys = new Telemedicine.Forms.CgLabelTextBox();
            this.textIdVal = new Telemedicine.Forms.CgLabelTextBox();
            this.textName = new Telemedicine.Forms.CgLabelTextBox();
            this.textAlias = new Telemedicine.Forms.CgLabelTextBox();
            this.textCountry = new Telemedicine.Forms.CgLabelTextBox();
            this.buttonCreate = new Telemedicine.Forms.CgIconButton();
            this.textId = new Telemedicine.Forms.CgLabelTextBox();
            this.SuspendLayout();
            // 
            // textIdSys
            // 
            this.textIdSys.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textIdSys.Header = "機構系統";
            this.textIdSys.Location = new System.Drawing.Point(12, 50);
            this.textIdSys.Name = "textIdSys";
            this.textIdSys.Size = new System.Drawing.Size(404, 30);
            this.textIdSys.TabIndex = 0;
            this.textIdSys.Text = "https://ma.mohw.gov.tw";
            // 
            // textIdVal
            // 
            this.textIdVal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textIdVal.Header = "機構代碼";
            this.textIdVal.Location = new System.Drawing.Point(12, 86);
            this.textIdVal.Name = "textIdVal";
            this.textIdVal.Size = new System.Drawing.Size(404, 30);
            this.textIdVal.TabIndex = 1;
            this.textIdVal.Text = "1132070011";
            // 
            // textName
            // 
            this.textName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textName.Header = "機構名稱";
            this.textName.Location = new System.Drawing.Point(12, 122);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(404, 30);
            this.textName.TabIndex = 2;
            this.textName.Text = "長庚醫療財團法人林口長庚紀念醫院";
            // 
            // textAlias
            // 
            this.textAlias.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textAlias.Header = "機構別稱";
            this.textAlias.Location = new System.Drawing.Point(12, 158);
            this.textAlias.Name = "textAlias";
            this.textAlias.Size = new System.Drawing.Size(404, 30);
            this.textAlias.TabIndex = 3;
            this.textAlias.Text = "CGMH";
            // 
            // textCountry
            // 
            this.textCountry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textCountry.Header = "機構國籍";
            this.textCountry.Location = new System.Drawing.Point(12, 194);
            this.textCountry.Name = "textCountry";
            this.textCountry.Size = new System.Drawing.Size(404, 30);
            this.textCountry.TabIndex = 4;
            this.textCountry.Text = "TW";
            // 
            // buttonCreate
            // 
            this.buttonCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCreate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonCreate.Location = new System.Drawing.Point(272, 252);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(144, 53);
            this.buttonCreate.TabIndex = 7;
            this.buttonCreate.Text = "建立";
            this.buttonCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // textId
            // 
            this.textId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textId.Header = "#";
            this.textId.HeaderAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textId.Location = new System.Drawing.Point(12, 12);
            this.textId.Name = "textId";
            this.textId.Size = new System.Drawing.Size(404, 30);
            this.textId.TabIndex = 8;
            // 
            // OrgCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 317);
            this.Controls.Add(this.textId);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.textCountry);
            this.Controls.Add(this.textAlias);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.textIdVal);
            this.Controls.Add(this.textIdSys);
            this.Name = "OrgCreateForm";
            this.Text = "建立組織";
            this.ResumeLayout(false);

        }

        #endregion

        private Forms.CgLabelTextBox textIdSys;
        private Forms.CgLabelTextBox textIdVal;
        private Forms.CgLabelTextBox textName;
        private Forms.CgLabelTextBox textAlias;
        private Forms.CgLabelTextBox textCountry;
        private Forms.CgIconButton buttonCreate;
        private Forms.CgLabelTextBox textId;
    }
}