
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
            this.menuObservation = new System.Windows.Forms.ToolStripMenuItem();
            this.menuObservationPersonal = new System.Windows.Forms.ToolStripMenuItem();
            this.醫令上傳ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.視窗ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.傳輸監控ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuObservationSearch = new System.Windows.Forms.ToolStripMenuItem();
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
            this.menuObservation});
            this.menuData.Name = "menuData";
            this.menuData.Size = new System.Drawing.Size(43, 20);
            this.menuData.Text = "資料";
            // 
            // menuObservation
            // 
            this.menuObservation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuObservationPersonal,
            this.menuObservationSearch,
            this.醫令上傳ToolStripMenuItem});
            this.menuObservation.Name = "menuObservation";
            this.menuObservation.Size = new System.Drawing.Size(180, 22);
            this.menuObservation.Text = "生理數值";
            // 
            // menuObservationPersonal
            // 
            this.menuObservationPersonal.Name = "menuObservationPersonal";
            this.menuObservationPersonal.Size = new System.Drawing.Size(180, 22);
            this.menuObservationPersonal.Text = "個人上傳";
            this.menuObservationPersonal.Click += new System.EventHandler(this.menuObservationPersonal_Click);
            // 
            // 醫令上傳ToolStripMenuItem
            // 
            this.醫令上傳ToolStripMenuItem.Name = "醫令上傳ToolStripMenuItem";
            this.醫令上傳ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.醫令上傳ToolStripMenuItem.Text = "醫令上傳";
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
            // 
            // menuObservationSearch
            // 
            this.menuObservationSearch.Name = "menuObservationSearch";
            this.menuObservationSearch.Size = new System.Drawing.Size(180, 22);
            this.menuObservationSearch.Text = "查詢";
            this.menuObservationSearch.Click += new System.EventHandler(this.menuObservationSearch_Click);
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
        private System.Windows.Forms.ToolStripMenuItem menuObservationPersonal;
        private System.Windows.Forms.ToolStripMenuItem 醫令上傳ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 視窗ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 傳輸監控ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuObservationSearch;
    }
}

