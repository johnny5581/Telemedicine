
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
            this.組織ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.建立ToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.查詢ToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPatient = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPatientCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPatientSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.menuObservation = new System.Windows.Forms.ToolStripMenuItem();
            this.menuObservationCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuObservationSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMedReq = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMedReqCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMedReqSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMedAdm = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMedAdmCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMedAdmSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.注射ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.建立ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查詢ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.檢驗紀錄ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.建立ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.查詢ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.電子病歷文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.建立ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.查詢ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.視窗ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.傳輸監控ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.組織ToolStripMenuItem,
            this.menuPatient,
            this.menuObservation,
            this.menuMedReq,
            this.menuMedAdm,
            this.注射ToolStripMenuItem,
            this.檢驗紀錄ToolStripMenuItem,
            this.電子病歷文件ToolStripMenuItem});
            this.menuData.Name = "menuData";
            this.menuData.Size = new System.Drawing.Size(43, 20);
            this.menuData.Text = "資料";
            // 
            // 組織ToolStripMenuItem
            // 
            this.組織ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.建立ToolStripMenuItem3,
            this.查詢ToolStripMenuItem3});
            this.組織ToolStripMenuItem.Name = "組織ToolStripMenuItem";
            this.組織ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.組織ToolStripMenuItem.Text = "組織";
            // 
            // 建立ToolStripMenuItem3
            // 
            this.建立ToolStripMenuItem3.Name = "建立ToolStripMenuItem3";
            this.建立ToolStripMenuItem3.Size = new System.Drawing.Size(180, 22);
            this.建立ToolStripMenuItem3.Text = "建立";
            this.建立ToolStripMenuItem3.Click += new System.EventHandler(this.建立ToolStripMenuItem3_Click);
            // 
            // 查詢ToolStripMenuItem3
            // 
            this.查詢ToolStripMenuItem3.Name = "查詢ToolStripMenuItem3";
            this.查詢ToolStripMenuItem3.Size = new System.Drawing.Size(180, 22);
            this.查詢ToolStripMenuItem3.Text = "查詢";
            this.查詢ToolStripMenuItem3.Click += new System.EventHandler(this.查詢ToolStripMenuItem3_Click);
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
            this.menuPatientCreate.Size = new System.Drawing.Size(180, 22);
            this.menuPatientCreate.Text = "初診資料建立";
            this.menuPatientCreate.Click += new System.EventHandler(this.menuPatientCreate_Click);
            // 
            // menuPatientSearch
            // 
            this.menuPatientSearch.Name = "menuPatientSearch";
            this.menuPatientSearch.Size = new System.Drawing.Size(180, 22);
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
            this.menuMedReqCreate.Size = new System.Drawing.Size(98, 22);
            this.menuMedReqCreate.Text = "開立";
            this.menuMedReqCreate.Click += new System.EventHandler(this.menuMedReqCreate_Click);
            // 
            // menuMedReqSearch
            // 
            this.menuMedReqSearch.Name = "menuMedReqSearch";
            this.menuMedReqSearch.Size = new System.Drawing.Size(98, 22);
            this.menuMedReqSearch.Text = "查詢";
            this.menuMedReqSearch.Click += new System.EventHandler(this.menuMedReqSearch_Click);
            // 
            // menuMedAdm
            // 
            this.menuMedAdm.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMedAdmCreate,
            this.menuMedAdmSearch});
            this.menuMedAdm.Name = "menuMedAdm";
            this.menuMedAdm.Size = new System.Drawing.Size(180, 22);
            this.menuMedAdm.Text = "用藥紀錄";
            // 
            // menuMedAdmCreate
            // 
            this.menuMedAdmCreate.Name = "menuMedAdmCreate";
            this.menuMedAdmCreate.Size = new System.Drawing.Size(98, 22);
            this.menuMedAdmCreate.Text = "建立";
            this.menuMedAdmCreate.Click += new System.EventHandler(this.menuMedAdmCreate_Click);
            // 
            // menuMedAdmSearch
            // 
            this.menuMedAdmSearch.Name = "menuMedAdmSearch";
            this.menuMedAdmSearch.Size = new System.Drawing.Size(98, 22);
            this.menuMedAdmSearch.Text = "查詢";
            this.menuMedAdmSearch.Click += new System.EventHandler(this.menuMedAdmSearch_Click);
            // 
            // 注射ToolStripMenuItem
            // 
            this.注射ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.建立ToolStripMenuItem,
            this.查詢ToolStripMenuItem});
            this.注射ToolStripMenuItem.Name = "注射ToolStripMenuItem";
            this.注射ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.注射ToolStripMenuItem.Text = "疫苗注射";
            // 
            // 建立ToolStripMenuItem
            // 
            this.建立ToolStripMenuItem.Name = "建立ToolStripMenuItem";
            this.建立ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.建立ToolStripMenuItem.Text = "建立";
            this.建立ToolStripMenuItem.Click += new System.EventHandler(this.建立ToolStripMenuItem_Click);
            // 
            // 查詢ToolStripMenuItem
            // 
            this.查詢ToolStripMenuItem.Name = "查詢ToolStripMenuItem";
            this.查詢ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.查詢ToolStripMenuItem.Text = "查詢";
            this.查詢ToolStripMenuItem.Click += new System.EventHandler(this.查詢ToolStripMenuItem_Click);
            // 
            // 檢驗紀錄ToolStripMenuItem
            // 
            this.檢驗紀錄ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.建立ToolStripMenuItem1,
            this.查詢ToolStripMenuItem1});
            this.檢驗紀錄ToolStripMenuItem.Name = "檢驗紀錄ToolStripMenuItem";
            this.檢驗紀錄ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.檢驗紀錄ToolStripMenuItem.Text = "檢驗紀錄";
            // 
            // 建立ToolStripMenuItem1
            // 
            this.建立ToolStripMenuItem1.Name = "建立ToolStripMenuItem1";
            this.建立ToolStripMenuItem1.Size = new System.Drawing.Size(98, 22);
            this.建立ToolStripMenuItem1.Text = "建立";
            this.建立ToolStripMenuItem1.Click += new System.EventHandler(this.建立ToolStripMenuItem1_Click);
            // 
            // 查詢ToolStripMenuItem1
            // 
            this.查詢ToolStripMenuItem1.Name = "查詢ToolStripMenuItem1";
            this.查詢ToolStripMenuItem1.Size = new System.Drawing.Size(98, 22);
            this.查詢ToolStripMenuItem1.Text = "查詢";
            this.查詢ToolStripMenuItem1.Click += new System.EventHandler(this.查詢ToolStripMenuItem1_Click);
            // 
            // 電子病歷文件ToolStripMenuItem
            // 
            this.電子病歷文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.建立ToolStripMenuItem2,
            this.查詢ToolStripMenuItem2});
            this.電子病歷文件ToolStripMenuItem.Name = "電子病歷文件ToolStripMenuItem";
            this.電子病歷文件ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.電子病歷文件ToolStripMenuItem.Text = "電子病歷文件";
            // 
            // 建立ToolStripMenuItem2
            // 
            this.建立ToolStripMenuItem2.Name = "建立ToolStripMenuItem2";
            this.建立ToolStripMenuItem2.Size = new System.Drawing.Size(98, 22);
            this.建立ToolStripMenuItem2.Text = "建立";
            // 
            // 查詢ToolStripMenuItem2
            // 
            this.查詢ToolStripMenuItem2.Name = "查詢ToolStripMenuItem2";
            this.查詢ToolStripMenuItem2.Size = new System.Drawing.Size(98, 22);
            this.查詢ToolStripMenuItem2.Text = "查詢";
            this.查詢ToolStripMenuItem2.Click += new System.EventHandler(this.查詢ToolStripMenuItem2_Click);
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
        private System.Windows.Forms.ToolStripMenuItem menuMedAdm;
        private System.Windows.Forms.ToolStripMenuItem menuMedAdmCreate;
        private System.Windows.Forms.ToolStripMenuItem menuMedAdmSearch;
        private System.Windows.Forms.ToolStripMenuItem 注射ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 建立ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查詢ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 檢驗紀錄ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 建立ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 查詢ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 電子病歷文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 建立ToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 查詢ToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 組織ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 建立ToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem 查詢ToolStripMenuItem3;
    }
}

