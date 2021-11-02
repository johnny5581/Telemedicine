
namespace Telemedicine
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuData = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPatient = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPatientCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPatientSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.menuObservation = new System.Windows.Forms.ToolStripMenuItem();
            this.menuObservationCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuObservationSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.視窗ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.傳輸監控ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMedReq = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMedReqCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMedReqSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuData,
            this.視窗ToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(784, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // menuData
            // 
            this.menuData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuPatient,
            this.menuObservation,
            this.menuMedReq});
            this.menuData.Name = "menuData";
            this.menuData.Size = new System.Drawing.Size(43, 20);
            this.menuData.Text = "資料";
            // 
            // menuPatient
            // 
            this.menuPatient.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuPatientCreate,
            this.menuPatientSearch});
            this.menuPatient.Name = "menuPatient";
            this.menuPatient.Size = new System.Drawing.Size(180, 22);
            this.menuPatient.Text = "病患";
            // 
            // menuPatientCreate
            // 
            this.menuPatientCreate.Name = "menuPatientCreate";
            this.menuPatientCreate.Size = new System.Drawing.Size(146, 22);
            this.menuPatientCreate.Text = "初診資料建立";
            this.menuPatientCreate.Click += new System.EventHandler(this.menuPatientCreate_Click);
            // 
            // menuPatientSearch
            // 
            this.menuPatientSearch.Name = "menuPatientSearch";
            this.menuPatientSearch.Size = new System.Drawing.Size(146, 22);
            this.menuPatientSearch.Text = "查詢";
            this.menuPatientSearch.Click += new System.EventHandler(this.menuPatientFind_Click);
            // 
            // menuObservation
            // 
            this.menuObservation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuObservationCreate,
            this.menuObservationSearch});
            this.menuObservation.Name = "menuObservation";
            this.menuObservation.Size = new System.Drawing.Size(180, 22);
            this.menuObservation.Text = "生理數值";
            // 
            // menuObservationCreate
            // 
            this.menuObservationCreate.Name = "menuObservationCreate";
            this.menuObservationCreate.Size = new System.Drawing.Size(98, 22);
            this.menuObservationCreate.Text = "新增";
            this.menuObservationCreate.Click += new System.EventHandler(this.menuObservationPersonal_Click);
            // 
            // menuObservationSearch
            // 
            this.menuObservationSearch.Name = "menuObservationSearch";
            this.menuObservationSearch.Size = new System.Drawing.Size(98, 22);
            this.menuObservationSearch.Text = "查詢";
            this.menuObservationSearch.Click += new System.EventHandler(this.menuObservationSearch_Click);
            // 
            // 視窗ToolStripMenuItem
            // 
            this.視窗ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.傳輸監控ToolStripMenuItem});
            this.視窗ToolStripMenuItem.Name = "視窗ToolStripMenuItem";
            this.視窗ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.視窗ToolStripMenuItem.Text = "視窗";
            // 
            // 傳輸監控ToolStripMenuItem
            // 
            this.傳輸監控ToolStripMenuItem.Name = "傳輸監控ToolStripMenuItem";
            this.傳輸監控ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.傳輸監控ToolStripMenuItem.Text = "傳輸監控";
            this.傳輸監控ToolStripMenuItem.Click += new System.EventHandler(this.傳輸監控ToolStripMenuItem_Click);
            // 
            // menuMedReq
            // 
            this.menuMedReq.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMedReqCreate,
            this.menuMedReqSearch});
            this.menuMedReq.Name = "menuMedReq";
            this.menuMedReq.Size = new System.Drawing.Size(180, 22);
            this.menuMedReq.Text = "處方";
            // 
            // menuMedReqCreate
            // 
            this.menuMedReqCreate.Name = "menuMedReqCreate";
            this.menuMedReqCreate.Size = new System.Drawing.Size(180, 22);
            this.menuMedReqCreate.Text = "開立";
            this.menuMedReqCreate.Click += new System.EventHandler(this.menuMedReqCreate_Click);
            // 
            // menuMedReqSearch
            // 
            this.menuMedReqSearch.Name = "menuMedReqSearch";
            this.menuMedReqSearch.Size = new System.Drawing.Size(180, 22);
            this.menuMedReqSearch.Text = "查詢";
            this.menuMedReqSearch.Click += new System.EventHandler(this.menuMedReqSearch_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuData;
        private System.Windows.Forms.ToolStripMenuItem menuObservation;
        private System.Windows.Forms.ToolStripMenuItem menuObservationCreate;
        private System.Windows.Forms.ToolStripMenuItem 視窗ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 傳輸監控ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuObservationSearch;
        private System.Windows.Forms.ToolStripMenuItem menuPatient;
        private System.Windows.Forms.ToolStripMenuItem menuPatientCreate;
        private System.Windows.Forms.ToolStripMenuItem menuPatientSearch;
        private System.Windows.Forms.ToolStripMenuItem menuMedReq;
        private System.Windows.Forms.ToolStripMenuItem menuMedReqCreate;
        private System.Windows.Forms.ToolStripMenuItem menuMedReqSearch;
    }
}

