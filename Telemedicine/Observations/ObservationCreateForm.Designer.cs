
namespace Telemedicine.Observations
{
    partial class ObservationCreateForm
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
            this.textSearchPat = new Telemedicine.Forms.CgTextBox();
            this.textId = new Telemedicine.Forms.CgLabelControl();
            this.textSex = new Telemedicine.Forms.CgLabelTextBox();
            this.textBrithDate = new Telemedicine.Forms.CgLabelTextBox();
            this.textName = new Telemedicine.Forms.CgLabelTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textMedSearch = new Telemedicine.Forms.CgTextBox();
            this.textMedId = new Telemedicine.Forms.CgLabelControl();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textSearchPat);
            this.groupBox1.Controls.Add(this.textId);
            this.groupBox1.Controls.Add(this.textSex);
            this.groupBox1.Controls.Add(this.textBrithDate);
            this.groupBox1.Controls.Add(this.textName);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(177, 167);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "病患資料";
            // 
            // textSearchPat
            // 
            this.textSearchPat.Location = new System.Drawing.Point(6, 21);
            this.textSearchPat.Name = "textSearchPat";
            this.textSearchPat.Size = new System.Drawing.Size(165, 22);
            this.textSearchPat.TabIndex = 7;
            this.textSearchPat.WatermarkText = "輸入查詢後按下Enter";
            // 
            // textId
            // 
            this.textId.Header = "#";
            this.textId.HeaderAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textId.Location = new System.Drawing.Point(6, 49);
            this.textId.Name = "textId";
            this.textId.Padding = new System.Windows.Forms.Padding(1);
            this.textId.Size = new System.Drawing.Size(165, 14);
            this.textId.TabIndex = 6;
            // 
            // textSex
            // 
            this.textSex.Header = "性別";
            this.textSex.Location = new System.Drawing.Point(6, 129);
            this.textSex.Name = "textSex";
            this.textSex.Padding = new System.Windows.Forms.Padding(1);
            this.textSex.ReadOnly = true;
            this.textSex.Size = new System.Drawing.Size(165, 24);
            this.textSex.TabIndex = 5;
            // 
            // textBrithDate
            // 
            this.textBrithDate.Header = "生日";
            this.textBrithDate.Location = new System.Drawing.Point(6, 99);
            this.textBrithDate.Name = "textBrithDate";
            this.textBrithDate.Padding = new System.Windows.Forms.Padding(1);
            this.textBrithDate.ReadOnly = true;
            this.textBrithDate.Size = new System.Drawing.Size(165, 24);
            this.textBrithDate.TabIndex = 4;
            // 
            // textName
            // 
            this.textName.Header = "姓名";
            this.textName.Location = new System.Drawing.Point(6, 69);
            this.textName.Name = "textName";
            this.textName.Padding = new System.Windows.Forms.Padding(1);
            this.textName.ReadOnly = true;
            this.textName.Size = new System.Drawing.Size(165, 24);
            this.textName.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textMedId);
            this.groupBox2.Controls.Add(this.textMedSearch);
            this.groupBox2.Location = new System.Drawing.Point(12, 186);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(177, 85);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "處方簽";
            // 
            // textMedSearch
            // 
            this.textMedSearch.Location = new System.Drawing.Point(6, 21);
            this.textMedSearch.Name = "textMedSearch";
            this.textMedSearch.Size = new System.Drawing.Size(165, 22);
            this.textMedSearch.TabIndex = 8;
            this.textMedSearch.WatermarkText = "輸入查詢後按下Enter";
            // 
            // textMedId
            // 
            this.textMedId.Header = "#";
            this.textMedId.HeaderAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textMedId.Location = new System.Drawing.Point(6, 49);
            this.textMedId.Name = "textMedId";
            this.textMedId.Padding = new System.Windows.Forms.Padding(1);
            this.textMedId.Size = new System.Drawing.Size(165, 14);
            this.textMedId.TabIndex = 9;
            // 
            // ObservationCreateForm
            // 
            this.ClientSize = new System.Drawing.Size(646, 487);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ObservationCreateForm";
            this.Text = "建立醫囑資料";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Forms.CgLabelControl textId;
        private Forms.CgLabelTextBox textSex;
        private Forms.CgLabelTextBox textBrithDate;
        private Forms.CgLabelTextBox textName;
        private Forms.CgTextBox textSearchPat;
        private System.Windows.Forms.GroupBox groupBox2;
        private Forms.CgTextBox textMedSearch;
        private Forms.CgLabelControl textMedId;
    }
}