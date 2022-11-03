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
            this.SuspendLayout();
            // 
            // patientControl1
            // 
            this.patientControl1.Location = new System.Drawing.Point(12, 12);
            this.patientControl1.Name = "patientControl1";
            this.patientControl1.Size = new System.Drawing.Size(236, 198);
            this.patientControl1.TabIndex = 0;
            this.patientControl1.Title = "Patient";
            // 
            // ObservationCreateForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.patientControl1);
            this.Name = "ObservationCreateForm2";
            this.Text = "建立生理數值";
            this.ResumeLayout(false);

        }

        #endregion

        private Patients.PatientControl patientControl1;
    }
}