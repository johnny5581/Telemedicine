
namespace Telemedicine
{
    partial class TransactionMonitorDialog
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
            this.textReqHeader = new Telemedicine.Forms.CgRichTextBox();
            this.groupReq = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textReqBody = new Telemedicine.Forms.CgRichTextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.textRespHeader = new Telemedicine.Forms.CgRichTextBox();
            this.textRespBody = new Telemedicine.Forms.CgRichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.groupReq.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textReqHeader
            // 
            this.textReqHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textReqHeader.Location = new System.Drawing.Point(0, 0);
            this.textReqHeader.Name = "textReqHeader";
            this.textReqHeader.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.textReqHeader.Size = new System.Drawing.Size(202, 121);
            this.textReqHeader.TabIndex = 0;
            this.textReqHeader.Text = "";
            // 
            // groupReq
            // 
            this.groupReq.Controls.Add(this.splitContainer1);
            this.groupReq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupReq.Location = new System.Drawing.Point(0, 0);
            this.groupReq.Name = "groupReq";
            this.groupReq.Size = new System.Drawing.Size(208, 417);
            this.groupReq.TabIndex = 1;
            this.groupReq.TabStop = false;
            this.groupReq.Text = "Request";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 18);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textReqHeader);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textReqBody);
            this.splitContainer1.Size = new System.Drawing.Size(202, 396);
            this.splitContainer1.SplitterDistance = 121;
            this.splitContainer1.TabIndex = 0;
            // 
            // textReqBody
            // 
            this.textReqBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textReqBody.Location = new System.Drawing.Point(0, 0);
            this.textReqBody.Name = "textReqBody";
            this.textReqBody.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.textReqBody.Size = new System.Drawing.Size(202, 271);
            this.textReqBody.TabIndex = 1;
            this.textReqBody.Text = "";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 24);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupReq);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer2.Size = new System.Drawing.Size(624, 417);
            this.splitContainer2.SplitterDistance = 208;
            this.splitContainer2.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.splitContainer3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(412, 417);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Response";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 18);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.textRespHeader);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.textRespBody);
            this.splitContainer3.Size = new System.Drawing.Size(406, 396);
            this.splitContainer3.SplitterDistance = 120;
            this.splitContainer3.TabIndex = 0;
            // 
            // textRespHeader
            // 
            this.textRespHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textRespHeader.Location = new System.Drawing.Point(0, 0);
            this.textRespHeader.Name = "textRespHeader";
            this.textRespHeader.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.textRespHeader.Size = new System.Drawing.Size(406, 120);
            this.textRespHeader.TabIndex = 0;
            this.textRespHeader.Text = "";
            // 
            // textRespBody
            // 
            this.textRespBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textRespBody.Location = new System.Drawing.Point(0, 0);
            this.textRespBody.Name = "textRespBody";
            this.textRespBody.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.textRespBody.Size = new System.Drawing.Size(406, 272);
            this.textRespBody.TabIndex = 1;
            this.textRespBody.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuClose});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(624, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuClose
            // 
            this.menuClose.Name = "menuClose";
            this.menuClose.Size = new System.Drawing.Size(43, 20);
            this.menuClose.Text = "關閉";
            this.menuClose.Click += new System.EventHandler(this.menuClose_Click);
            // 
            // TransactionMonitorDialog
            // 
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TransactionMonitorDialog";
            this.groupReq.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Forms.CgRichTextBox textReqHeader;
        private System.Windows.Forms.GroupBox groupReq;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Forms.CgRichTextBox textReqBody;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private Forms.CgRichTextBox textRespHeader;
        private Forms.CgRichTextBox textRespBody;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuClose;
    }
}