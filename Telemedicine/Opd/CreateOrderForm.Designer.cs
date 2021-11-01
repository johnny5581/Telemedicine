
namespace Telemedicine.Opd
{
    partial class CreateOrderForm
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
            this.cgDataGridPanel1 = new Telemedicine.Forms.CgDataGridPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cgLabelTextBox1 = new Telemedicine.Forms.CgLabelTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cgDataGridPanel1
            // 
            this.cgDataGridPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cgDataGridPanel1.Location = new System.Drawing.Point(3, 18);
            this.cgDataGridPanel1.Name = "cgDataGridPanel1";
            this.cgDataGridPanel1.Size = new System.Drawing.Size(253, 339);
            this.cgDataGridPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cgDataGridPanel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 117);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 360);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "病患清單";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cgLabelTextBox1);
            this.groupBox2.Location = new System.Drawing.Point(15, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(256, 98);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "掛號";
            // 
            // cgLabelTextBox1
            // 
            this.cgLabelTextBox1.Header = "識別號";
            this.cgLabelTextBox1.Location = new System.Drawing.Point(7, 22);
            this.cgLabelTextBox1.Name = "cgLabelTextBox1";
            this.cgLabelTextBox1.Padding = new System.Windows.Forms.Padding(1);
            this.cgLabelTextBox1.Size = new System.Drawing.Size(239, 24);
            this.cgLabelTextBox1.TabIndex = 0;
            // 
            // CreateOrderForm
            // 
            this.ClientSize = new System.Drawing.Size(884, 489);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "CreateOrderForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Forms.CgDataGridPanel cgDataGridPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Forms.CgLabelTextBox cgLabelTextBox1;
    }
}