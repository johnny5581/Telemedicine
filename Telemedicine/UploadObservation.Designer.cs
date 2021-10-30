
namespace Telemedicine
{
    partial class UploadObservation
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cgLabelTextBox1 = new Telemedicine.Forms.CgLabelTextBox();
            this.cgLabelTextBox2 = new Telemedicine.Forms.CgLabelTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cgLabelTextBox2);
            this.groupBox1.Controls.Add(this.cgLabelTextBox1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(939, 139);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "病患基本資料";
            // 
            // cgLabelTextBox1
            // 
            this.cgLabelTextBox1.Header = "查詢";
            this.cgLabelTextBox1.Location = new System.Drawing.Point(7, 22);
            this.cgLabelTextBox1.Name = "cgLabelTextBox1";
            this.cgLabelTextBox1.Padding = new System.Windows.Forms.Padding(1);
            this.cgLabelTextBox1.Size = new System.Drawing.Size(217, 24);
            this.cgLabelTextBox1.TabIndex = 0;
            // 
            // cgLabelTextBox2
            // 
            this.cgLabelTextBox2.Header = "查詢";
            this.cgLabelTextBox2.Location = new System.Drawing.Point(7, 52);
            this.cgLabelTextBox2.Name = "cgLabelTextBox2";
            this.cgLabelTextBox2.Padding = new System.Windows.Forms.Padding(1);
            this.cgLabelTextBox2.Size = new System.Drawing.Size(217, 24);
            this.cgLabelTextBox2.TabIndex = 1;
            // 
            // UploadObservation
            // 
            this.ClientSize = new System.Drawing.Size(964, 668);
            this.Controls.Add(this.groupBox1);
            this.Name = "UploadObservation";
            this.Text = "生理數值上傳";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Forms.CgLabelTextBox cgLabelTextBox1;
        private Forms.CgLabelTextBox cgLabelTextBox2;
    }
}