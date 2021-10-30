using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Telemedicine.Forms
{
    public class CgDataPanel : CgUserControl
    {
        #region Static
        private const string CategoryTopPanel = "TopPanel";
        private static string _gInfoFormat;


        public static string GlobalInfoFormat
        {
            get { return _gInfoFormat; }
            set
            {
                _gInfoFormat = value;
                var handler = GlobalInfoFormatChanged;
                if (handler != null)
                    handler(null, EventArgs.Empty);
            }
        }

        public static event EventHandler GlobalInfoFormatChanged;
        #endregion


        private string _infoTextFormat;
        public CgDataPanel()
        {
            InitializeComponent();
            InitializeDataComponent();
            InitializeCustomizeComponents();
            ResetTopHeight();
        }

        #region 屬性
        #region 上方控制面板

        #region 搜尋欄
        [Category(CategoryTopPanel)]
        [DefaultValue(150)]
        public int SearchBoxWidth
        {
            get { return panelSearch.Width; }
            set { panelSearch.Width = value; }
        }
        [Category(CategoryTopPanel)]
        [DefaultValue(null)]
        public string SearchBoxWatermark
        {
            get { return textSearch.WatermarkText; }
            set { textSearch.WatermarkText = value; }
        }
        [Category(CategoryTopPanel)]
        [DefaultValue(false)]
        public bool SearchBoxVisible
        {
            get { return panelSearch.Visible; }
            set { panelSearch.Visible = value; }
        }
        [Category(CategoryTopPanel)]
        [DefaultValue(typeof(Color), "White")]
        public Color SearchBoxBackColor
        {
            get { return panelSearch.BackColor; }
            set
            {
                panelSearch.BackColor
                    = textSearch.BackColor
                    = Commons.GetNonEmptyColor(value, Color.White);
            }
        }
        [Category(CategoryTopPanel)]
        [DefaultValue(false)]
        public bool SearchBoxReadOnly
        {
            get { return textSearch.ReadOnly; }
            set { textSearch.ReadOnly = value; }
        }
        #endregion

        #region 資訊欄
        [Category(CategoryTopPanel)]
        [DefaultValue(150)]
        public int InfoBoxWidth
        {
            get { return panelInfo.Width; }
            set
            {
                panelInfo.Width = value;
                // 調整位置
                panelInfo.Left = panelTop.Width - panelInfo.Width - (DefaultMargin.Horizontal / 2);
            }
        }
        [Category(CategoryTopPanel)]
        [DefaultValue(true)]
        public bool InfoBoxVisible
        {
            get { return panelInfo.Visible; }
            set { panelInfo.Visible = value; }
        }
        [Category(CategoryTopPanel)]
        [DefaultValue(typeof(Color), "White")]
        public Color InfoBoxBackColor
        {
            get { return panelInfo.BackColor; }
            set
            {
                panelInfo.BackColor
                    = textInfo.BackColor
                    = Commons.GetNonEmptyColor(value, Color.White);
            }
        }
        [Category(CategoryTopPanel)]
        [DefaultValue(true)]
        public bool InfoBoxReadOnly
        {
            get { return textInfo.ReadOnly; }
            set { textInfo.ReadOnly = value; }
        }
        [Category(CategoryTopPanel)]
        [DefaultValue(null)]
        public string InfoBoxTextFormat
        {
            get { return _infoTextFormat ?? GlobalInfoFormat; }
            set
            {
                _infoTextFormat = value;
                ChangeInfo();
            }
        }
        #endregion

        [Category(CategoryTopPanel)]
        [DefaultValue(true)]
        public bool TopPanelVisible
        {
            get { return panelTop.Visible; }
            set { panelTop.Visible = value; }
        }
        [Category(CategoryTopPanel)]
        [DefaultValue(typeof(Color), "Control")]
        public Color TopPanelBackColor
        {
            get { return panelTop.BackColor; }
            set { panelTop.BackColor = value; }
        }
        #endregion

        public virtual object DataSource { get; private set; }
        /// <summary>
        /// 持續搜尋
        /// </summary>
        [DefaultValue(false)]
        public bool ContinueSearch { get; set; }
        /// <summary>
        /// 搜尋時忽略大小寫
        /// </summary>
        [DefaultValue(false)]
        public bool SearchIgnoreCase { get; set; }
        /// <summary>
        /// 自動重新調整欄位
        /// </summary>
        [DefaultValue(false)]
        public bool AutoFitColumnWidth { get; set; }
        #endregion

        #region 事件
        public event SearchingEventHandler Searching;
        public event InfoChangingEventHandler InfoChanging;
        #endregion

        #region 公開方法
        public void ChangeInfoText(string text)
        {
            textInfo.Text = text;
        }
        public void PerformInfoChanged()
        {
            ChangeInfo();
        }
        public virtual void SetSource<T>(IEnumerable<T> list)
        {
        }
        public virtual void ClearSource()
        {
        }
        public virtual void ClearSelection()
        {
        }
        public virtual object[] GetSelectedItems()
        {
            return new object[0];
        }
        #endregion




        protected virtual void OnInfoChanging(InfoChangingEventArgs e)
        {
            var handler = InfoChanging;
            if (handler != null)
                handler(this, e);
            if (e.Handled)
                ChangeInfoText(e.Text);
            else
            {
                var format = InfoBoxTextFormat;
                string text = null;
                if (!string.IsNullOrEmpty(format))
                    text = string.Format(format, e.Count);
                ChangeInfoText(text);
            }
        }
        protected void ChangeInfo()
        {
            var source = DataSource;
            var count = GetDataCount(source);
            var args = new InfoChangingEventArgs(source, count);
            OnInfoChanging(args);
        }
        protected virtual void OnSearching(SearchEventArgs e)
        {
            var handler = Searching;
            if (handler != null)
                handler(this, e);
        }
        protected void SearchData()
        {
            var text = string.IsNullOrEmpty(textSearch.Text) ? null : textSearch.Text;
            var args = new SearchEventArgs(text, DataSource);
            OnSearching(args);
        }



        /// <summary>
        /// 取得資料呈現元件
        /// </summary>        
        protected virtual Control GetDataComponent()
        {
            return null;
        }
        /// <summary>
        /// 取得資料數量
        /// </summary>        
        protected virtual int GetDataCount(object source)
        {
            return 0;
        }


        private void IconSearch_Click(object sender, EventArgs e)
        {
            SearchData();
        }
        private void ResetTopHeight()
        {
            // 重設上方面板高度
            // 計算兩個TextBox當前高度，取最大值，再推算出大小

            var thInfo = textInfo.Height;
            var thSearch = textSearch.Height;
            var phInfo = thInfo + Commons.MagicVertical;
            var phSearch = thSearch + Commons.MagicVertical;
            var height = Math.Max(phInfo, phSearch) + DefaultMargin.Vertical;

            panelTop.Height = height;

            panelSearch.Height = phSearch;
            panelInfo.Height = phInfo;
            panelSearch.Top = (height - phSearch) / 2;
            panelInfo.Top = (height - phInfo) / 2;
            iconSearch.Width = iconSearch.Height;
        }


        protected override void OnParentFontChanged(EventArgs e)
        {
            base.OnParentFontChanged(e);
            ResetTopHeight();
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            ResetTopHeight();
        }
        private void TextSearch_FontChanged(object sender, EventArgs e)
        {
            ResetTopHeight();
        }

        private void TextInfo_FontChanged(object sender, EventArgs e)
        {
            ResetTopHeight();
        }

        private void TextSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SearchData();
        }

        private void TextSearch_TextChanged(object sender, EventArgs e)
        {
            if (ContinueSearch)
                SearchData();
        }
        private void CgBaseDataPanel_GlobalInfoFormatChanged(object sender, EventArgs e)
        {
            ChangeInfo();
        }

        protected static PropertyInfo GetPropertyInfoFromExpression(LambdaExpression lambda)
        {
            var memberExp = ExtractMemberExpression(lambda.Body);
            if (memberExp == null)
                throw new ArgumentException("must be member access expression");
            if (memberExp.Member.DeclaringType == null)
                throw new InvalidOperationException("property does not have declaring type");
            return memberExp.Member.DeclaringType.GetProperty(memberExp.Member.Name);
        }
        protected static MemberExpression ExtractMemberExpression(Expression expression)
        {
            if (expression.NodeType == ExpressionType.MemberAccess)
                return ((MemberExpression)expression);
            if (expression.NodeType == ExpressionType.Convert)
            {
                var operand = ((UnaryExpression)expression).Operand;
                return ExtractMemberExpression(operand);
            }
            return null;
        }

        #region Designer
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.TextBox textInfo;
        private System.Windows.Forms.Panel panelSearch;
        private CgTextBox textSearch;
        private System.Windows.Forms.Panel panelInfo;
        private CgIconControl iconSearch;
        private Panel panelData;
        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.textInfo = new System.Windows.Forms.TextBox();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.panelData = new System.Windows.Forms.Panel();
            this.panelTop.SuspendLayout();
            this.panelInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.panelInfo);
            this.panelTop.Controls.Add(this.panelSearch);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(589, 34);
            this.panelTop.TabIndex = 1;
            // 
            // panelInfo
            // 
            this.panelInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelInfo.BackColor = System.Drawing.Color.White;
            this.panelInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInfo.Controls.Add(this.textInfo);
            this.panelInfo.Location = new System.Drawing.Point(436, 3);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Padding = new System.Windows.Forms.Padding(3);
            this.panelInfo.Size = new System.Drawing.Size(150, 24);
            this.panelInfo.TabIndex = 2;
            // 
            // textInfo
            // 
            this.textInfo.BackColor = System.Drawing.Color.White;
            this.textInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textInfo.Location = new System.Drawing.Point(3, 3);
            this.textInfo.Name = "textInfo";
            this.textInfo.ReadOnly = true;
            this.textInfo.Size = new System.Drawing.Size(142, 15);
            this.textInfo.TabIndex = 0;
            // 
            // panelSearch
            // 
            this.panelSearch.BackColor = System.Drawing.Color.White;
            this.panelSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSearch.Location = new System.Drawing.Point(3, 3);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Padding = new System.Windows.Forms.Padding(3);
            this.panelSearch.Size = new System.Drawing.Size(150, 24);
            this.panelSearch.TabIndex = 1;
            this.panelSearch.Visible = false;
            // 
            // panelData
            // 
            this.panelData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelData.Location = new System.Drawing.Point(0, 34);
            this.panelData.Name = "panelData";
            this.panelData.Size = new System.Drawing.Size(589, 317);
            this.panelData.TabIndex = 2;
            // 
            // CgDataPanel
            // 
            this.Controls.Add(this.panelData);
            this.Controls.Add(this.panelTop);
            this.Name = "CgDataPanel";
            this.Size = new System.Drawing.Size(589, 351);
            this.panelTop.ResumeLayout(false);
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            this.ResumeLayout(false);

        }
        private void InitializeDataComponent()
        {
            var control = GetDataComponent();
            if (control != null)
            {
                control.Dock = DockStyle.Fill;
                panelData.Controls.Add(control);
            }
        }
        private void InitializeCustomizeComponents()
        {
            SuspendLayout();
            panelSearch.SuspendLayout();

            textSearch = new CgTextBox();
            iconSearch = new CgIconControl();


            textSearch.FontChanged += TextSearch_FontChanged;
            textInfo.FontChanged += TextInfo_FontChanged;

            GlobalInfoFormatChanged += CgBaseDataPanel_GlobalInfoFormatChanged;

            // icon
            iconSearch.Size = new System.Drawing.Size(textSearch.Height, textSearch.Height);
            iconSearch.Dock = System.Windows.Forms.DockStyle.Right;
            iconSearch.Icon = "FontAwesome.Search";
            iconSearch.AutoIconMouseColor = true;
            iconSearch.IconClickable = true;
            iconSearch.Click += new EventHandler(IconSearch_Click);

            // text
            textSearch.Size = new System.Drawing.Size(100, 22);
            textSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            textSearch.BackColor = panelSearch.BackColor;
            textSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textSearch.FontChanged += TextSearch_FontChanged;
            textSearch.TextChanged += TextSearch_TextChanged;
            textSearch.KeyDown += TextSearch_KeyDown;

            panelSearch.Controls.Add(textSearch);
            panelSearch.Controls.Add(iconSearch);

            textInfo.FontChanged += TextInfo_FontChanged;

            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            ResumeLayout(false);
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing)
                GlobalInfoFormatChanged -= CgBaseDataPanel_GlobalInfoFormatChanged;
            base.Dispose(disposing);
        }
        #endregion


        public delegate void SearchingEventHandler(object sender, SearchEventArgs e);
        public delegate void InfoChangingEventHandler(object sender, InfoChangingEventArgs e);
        public class SearchEventArgs : HandledEventArgs
        {
            public SearchEventArgs(string keyword, object source)
            {
                Keyword = keyword;
            }

            public string Keyword { get; private set; }
        }

        public class InfoChangingEventArgs : HandledEventArgs
        {
            public InfoChangingEventArgs(object source, int count)
            {
                DataSource = source;
                Count = count;
            }

            public object DataSource { get; private set; }
            public int Count { get; private set; }
            public string Text { get; set; }
        }
    }
}

