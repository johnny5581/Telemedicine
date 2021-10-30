using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Telemedicine.Forms
{
    public class CgDataGridPanel : CgDataPanel
    {
        private bool _sortableBindingList = false;
        private HashSet<string> _escapeList = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        private readonly Dictionary<DataGridViewColumn, List<FormattingCellEventItem>> _cellFormatEventItems
            = new Dictionary<DataGridViewColumn, List<FormattingCellEventItem>>();
        private bool _merged;
        private DataGridView dataGridView;
        public CgDataGridPanel()
        {
        }

        #region 屬性
        public DataGridView DataGridView
        {
            get { return dataGridView; }
        }
        [DefaultValue(false)]
        public bool AutoGenerateColumns
        {
            get { return dataGridView.AutoGenerateColumns; }
            set { dataGridView.AutoGenerateColumns = value; }
        }
        [DefaultValue(false), EditorBrowsable(EditorBrowsableState.Never)]
        public bool SuspendRowChanged { get; set; }
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HashSet<string> AutoFitEscapedColumns
        {
            get { return _escapeList; }
        }
        [DefaultValue(false)]
        public bool MergeColumnHeaders
        {
            get { return _merged; }
            set
            {
                if (value != _merged)
                {
                    _merged = value;
                    OnMergedChanged();
                }
            }
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override object DataSource
        {
            get { return dataGridView.DataSource; }
        }

        #endregion

        #region 事件
        public event SelectedRowChangedEventHandler SelectedRowChanged;
        public event DataSelectedEventHandler DataSelected;
        #endregion

        /// <summary>
        /// 取得可排序陣列
        /// </summary>        
        public SortableBindingList<T> GetSortableSource<T>()
        {
            SortableBindingList<T> list = null;
            if (dataGridView.DataSource != null)
            {
                list = dataGridView.DataSource as SortableBindingList<T>;
                if (list == null)
                    throw new InvalidCastException("can not convert to SortableBindingList<" + typeof(T).Name + ">");
            }
            else
            {
                SetBindingListSource(null, typeof(T));
            }
            return list;
        }
        public void SetSource(DataTable table)
        {
            _sortableBindingList = false;
            dataGridView.DataSource = table;
        }

        public override void SetSource<T>(IEnumerable<T> list)
        {
            SetBindingListSource(list, typeof(T));
        }
        public int[] SelectRow(Func<DataGridViewRow, bool> selector, bool firstOnly = true)
        {
            var selectedIndexes = new List<int>();
            for (var index = 0; index < dataGridView.Rows.Count; index++)
            {
                if (selector(dataGridView.Rows[index]))
                {
                    dataGridView.Rows[index].Selected = true;
                    dataGridView.FirstDisplayedScrollingRowIndex = index;
                    selectedIndexes.Add(index);
                    if (!dataGridView.MultiSelect || firstOnly)
                        break;
                }
            }
            return selectedIndexes.ToArray();
        }

        public int[] SelectRow<T>(Func<T, bool> itemSelector, bool firstOnly = true)
        {
            return SelectRow(row =>
            {
                var item = (T)row.DataBoundItem;
                return itemSelector(item);
            }, firstOnly);
        }

        public bool TrySelectRow(Func<DataGridViewRow, bool> selector, bool firstOnly = true)
        {
            var indexes = SelectRow(selector, firstOnly);
            return indexes.Length > 0;
        }

        public bool TrySelectRow<T>(Func<T, bool> selector, bool firstOnly = true)
        {
            var indexes = SelectRow(selector, firstOnly);
            return indexes.Length > 0;
        }
        /// <summary>
        /// 轉成Csv格式
        /// </summary>
        /// <param name="separator">分隔符號</param>
        /// <param name="header">包含標題</param>
        public string ToCsv(string separator = ",", bool header = true, Func<object, string> fieldConvert = null)
        {
            var sb = new StringBuilder();
            var columns = dataGridView.Columns.OfType<DataGridViewColumn>().Where(column => column.Visible);
            if (fieldConvert == null)
                fieldConvert = v => Commons.Quote(v);
            if (header)
            {
                var headerLine = string.Join(separator, columns.Select(column => fieldConvert(column.HeaderText)));
                sb.AppendLine(headerLine);
            }
            for (var index = 0; index < dataGridView.Rows.Count; index++)
            {
                var row = dataGridView.Rows[index];
                var line = string.Join(separator, columns.Select(column => fieldConvert(row.Cells[column.Name].FormattedValue)));
                sb.AppendLine(line);
            }
            return sb.ToString();
        }

        
        public object GetSelectedItem()
        {
            object item = null;
            if (dataGridView.SelectedRows.Count > 0)
            {
                item = dataGridView.SelectedRows[0].DataBoundItem;
            }
            return item;
        }
        public override object[] GetSelectedItems()
        {
            if (dataGridView.SelectedRows.Count == 0)
                return new object[0];
            var items = new object[dataGridView.SelectedRows.Count];
            for (var index = 0; index < dataGridView.SelectedRows.Count; index++)
                items[index] = dataGridView.SelectedRows[index].DataBoundItem;
            return items;
        }
        
        public ColumnBuilder<T> AppendColumn<T>() where T : DataGridViewColumn
        {
            return new ColumnBuilder<T>(this);
        }
        public override void ClearSource()
        {
            if (dataGridView.DataSource != null)
            {
                if (_sortableBindingList)
                    (dataGridView.DataSource as IBindingList).Clear();
                else
                    (dataGridView.DataSource as DataTable).Rows.Clear();
            }
        }
        public override void ClearSelection()
        {
            dataGridView.ClearSelection();
        }
        public DataGridViewTextBoxColumn AddTextColumn(string name, string title, string propertyName = null, FormattingCellEventHandler formatter = null, object[] arguments = null)
        {
            var builder = AppendColumn<DataGridViewTextBoxColumn>();
            builder.Bind(name, propertyName, title);
            if (formatter != null)
                builder.UseFormatter(formatter, arguments);
            return builder.Commit();
        }
        /// <summary>
        /// 增加文字欄位
        /// </summary>        
        public DataGridViewTextBoxColumn AddTextColumn<T>(Expression<Func<T, object>> selector, string title = null, FormattingCellEventHandler formatter = null, string[] arguments = null)
        {
            var builder = AppendColumn<DataGridViewTextBoxColumn>();
            builder.Bind(selector, title);
            if (formatter != null)
                builder.UseFormatter(formatter, arguments);
            return builder.Commit();
        }



        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (!DesignMode && dataGridView != null)
                ResizeColumnHeadersHeight();
        }
        protected virtual void OnMergedChanged()
        {
            if (_merged)
            {
                dataGridView.Scroll += DataGridView_Scroll;
                dataGridView.Paint += DataGridView_Paint;
                dataGridView.CellPainting += DataGridView_CellPainting;
                dataGridView.ColumnWidthChanged += DataGridView_ColumnWidthChanged;
                ResizeColumnHeadersHeight();
            }
            else
            {
                dataGridView.Scroll -= DataGridView_Scroll;
                dataGridView.Paint -= DataGridView_Paint;
                dataGridView.CellPainting -= DataGridView_CellPainting;
                dataGridView.ColumnWidthChanged -= DataGridView_ColumnWidthChanged;
            }
        }

        protected override int GetDataCount(object source)
        {
            //return base.GetDataCount(source);
            if (source == null)
                return 0;
            return _sortableBindingList ? (source as IBindingList).Count : (source as DataTable).Rows.Count;
        }
        protected virtual void OnSelectedRowChanged(SelectedRowChangedEventArgs e)
        {
            var handler = SelectedRowChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        protected virtual void OnDataSelected(DataSelectedEventArgs e)
        {
            var handler = DataSelected;
            if (handler != null)
            {
                handler(this, e);
            }
        }


        private void AppendColumn(DataGridViewColumn column, List<FormattingCellEventItem> eventItems)
        {
            dataGridView.Columns.Add(column);
            if (eventItems != null && eventItems.Count > 0)
                _cellFormatEventItems.Add(column, eventItems);
        }

        private ISortableBindingList SetBindingListSource(IEnumerable source, Type sourceType)
        {
            var suspendSetting = SuspendRowChanged;
            SuspendRowChanged = true;
            _sortableBindingList = true;
            var sortableBindingListType = typeof(SortableBindingList<>).MakeGenericType(sourceType);
            ISortableBindingList bindingList = null;
            var createFlag = false;
            if (dataGridView.DataSource != null)
            {
                var originalType = dataGridView.DataSource.GetType();
                if (originalType.IsAssignableFrom(sortableBindingListType)
                    || (originalType.IsGenericType && originalType.GetGenericArguments()[0].IsAssignableFrom(sourceType)))
                {
                    bindingList = dataGridView.DataSource as ISortableBindingList;

                    // 先清除DataSource，避免操作影響畫面過於嚴重
                    dataGridView.DataSource = null;
                    bindingList.SuspendListChanged = true;
                    bindingList.Clear();
                    foreach (var item in source)
                        bindingList.Add(item);
                    bindingList.SuspendListChanged = false;
                    bindingList.ChangeList();
                    // 重新綁定回去
                    dataGridView.DataSource = bindingList;
                }
                else
                {
                    throw new InvalidOperationException("invalid source type");
                }
            }
            else
            {
                bindingList = source == null
                    ? (ISortableBindingList)Activator.CreateInstance(sortableBindingListType)
                    : (ISortableBindingList)Activator.CreateInstance(sortableBindingListType, source);
                dataGridView.DataSource = bindingList;
                createFlag = true;
            }
            if (AutoFitColumnWidth)
            {
                FitColumnsWidth();
            }            
            if (createFlag)
            {
                bindingList.ListChanged += new ListChangedEventHandler(SortableBindingList_ListChanged);
                bindingList.ChangeList();
            }
            dataGridView.ClearSelection();
            SuspendRowChanged = suspendSetting;            
            return bindingList;
        }

        private void ResizeColumnHeadersHeight()
        {
            dataGridView.AutoResizeColumnHeadersHeight();
            if (dataGridView.Columns.OfType<IMergedDataGridViewColumn>().Count() > 0)
                dataGridView.ColumnHeadersHeight *= 2;
        }

        private void FitColumnsWidth()
        {
            var mode = dataGridView.Rows.Count > 0
                ? DataGridViewAutoSizeColumnMode.AllCells
                : DataGridViewAutoSizeColumnMode.ColumnHeader;
            for (var index = 0; index < dataGridView.Columns.Count; index++)
            {
                var column = dataGridView.Columns[index];
                if (AutoFitEscapedColumns.Contains(column.Name))
                    continue;
                dataGridView.AutoResizeColumn(index, mode);
            }
        }
        protected override void OnSearching(SearchEventArgs e)
        {
            base.OnSearching(e);
            if (!e.Handled)
            {
                // clear selection                
                dataGridView.ClearSelection();

                var bindingList = dataGridView.DataSource as ISortableBindingList;
                if (bindingList != null)
                {
                    var suspendSetting = SuspendRowChanged;
                    SuspendRowChanged = true;
                    if (string.IsNullOrEmpty(e.Keyword))
                    {
                        bindingList.Filter(o => true);
                    }
                    else
                    {
                        var columns = dataGridView.Columns.OfType<DataGridViewColumn>().ToArray();
                        var propertyCache = new Dictionary<string, PropertyInfo>();
                        var valueGetters = columns.Select(r => new Func<object, object>(m =>
                        {
                            PropertyInfo p;
                            if (!propertyCache.TryGetValue(r.DataPropertyName, out p))
                            {
                                p = m.GetType().GetProperty(r.DataPropertyName);
                                propertyCache.Add(r.DataPropertyName, p);
                            }
                            if (p == null) return null;
                            return p.GetValue(m, null);
                        }));

                        bindingList.Filter(o =>
                        {
                            return valueGetters.Any(valueGetter =>
                            {
                                var value = valueGetter(o);
                                if (value == null) return false;
                                var text = Convert.ToString(value);
                                var keyword = e.Keyword;
                                if(SearchIgnoreCase)
                                {
                                    text = text.ToUpper();
                                    keyword = keyword.ToUpper();
                                }
                                return text.Contains(keyword);
                            });
                        });
                    }
                    // 清除所選的項目
                    dataGridView.ClearSelection();
                    SuspendRowChanged = suspendSetting;
                }
            }
        }
        private void SortableBindingList_ListChanged(object sender, ListChangedEventArgs e)
        {
            ChangeInfo();
        }
        private void DataGridView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            var rect = dataGridView.DisplayRectangle;
            rect.Height = dataGridView.ColumnHeadersHeight / 2;
            dataGridView.Invalidate(rect);
        }

        private void DataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex > -1)
            {
                var rect = e.CellBounds;
                rect.Y += e.CellBounds.Height / 2;
                rect.Height = e.CellBounds.Height / 2;
                e.PaintBackground(rect, true);
                e.PaintContent(rect);
                e.Handled = true;
            }
        }

        private void DataGridView_Paint(object sender, PaintEventArgs e)
        {
            for (var colIndex = 0; colIndex < dataGridView.ColumnCount; colIndex++)
            {
                var column = dataGridView.Columns[colIndex];
                IMergedDataGridViewColumn mergedColumn = column as IMergedDataGridViewColumn;
                if (mergedColumn != null)
                {
                    var cellRect = dataGridView.GetCellDisplayRectangle(colIndex, -1, true);
                    var key = mergedColumn.MergedKey;
                    var appendWidth = 0;
                    var count = 0;
                    for (var mergedIndex = colIndex + 1; mergedIndex < dataGridView.ColumnCount; mergedIndex++)
                    {
                        var nextColumn = dataGridView.Columns[mergedIndex];
                        var nextMergedColumn = nextColumn as IMergedDataGridViewColumn;
                        if (nextMergedColumn == null || nextMergedColumn.MergedKey != key)
                            break;
                        appendWidth += dataGridView.GetCellDisplayRectangle(mergedIndex, -1, true).Width;
                        count++;
                    }
                    var style = dataGridView.EnableHeadersVisualStyles ? dataGridView.DefaultCellStyle : dataGridView.ColumnHeadersDefaultCellStyle;
                    var mergedRect = new Rectangle(cellRect.X, cellRect.Y, cellRect.Width + appendWidth, cellRect.Height / 2);
                    using (var mergedBack = new SolidBrush(style.BackColor))
                    {
                        e.Graphics.FillRectangle(mergedBack, mergedRect);
                        var gridPen = (Pen)dataGridView.GetType().GetProperty("GridPen", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(dataGridView, null);
                        var gridColor = gridPen.Color;
                        gridPen = new Pen(ControlPaint.LightLight(gridColor));
                        e.Graphics.DrawRectangle(gridPen, mergedRect);
                        TextRenderer.DrawText(e.Graphics, key, dataGridView.ColumnHeadersDefaultCellStyle.Font, mergedRect, style.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                    }
                    colIndex += count;
                }
            }
        }

        private void DataGridView_Scroll(object sender, ScrollEventArgs e)
        {
            var rect = dataGridView.DisplayRectangle;
            rect.Height = dataGridView.ColumnHeadersHeight / 2;
            dataGridView.Invalidate(rect);
        }
        private void DataGridView_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            var dataGridView = sender as DataGridView;
            if (dataGridView.IsCurrentCellInEditMode)
                dataGridView.EndEdit();
        }

        private void DataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            var dataGridView = sender as DataGridView;
            var column = dataGridView.Columns[e.ColumnIndex];
            if (column is DataGridViewCheckBoxColumn)
            {
                dataGridView.BeginEdit(false);
            }
        }
        private void DataGridView_ColumnRemoved(object sender, DataGridViewColumnEventArgs e)
        {
            _cellFormatEventItems.Remove(e.Column);
        }

        private void DataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (SuspendRowChanged) return;
            if (dataGridView.MultiSelect) return; // 多選不會跳事件
            var selectedRow = dataGridView.SelectedRows.Count == 0 ? null : dataGridView.SelectedRows[0];
            var args = new SelectedRowChangedEventArgs(selectedRow);
            OnSelectedRowChanged(args);
        }

        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var args = new FormattingCellEventArgs(dataGridView, e);
            try
            {
                List<FormattingCellEventItem> eventItems;
                if (_cellFormatEventItems.TryGetValue(args.Column, out eventItems))
                {
                    foreach (var eventItem in eventItems)
                    {
                        eventItem.Invoke(args);
                        if (args.FormattingApplied)
                            break;
                    }
                }
            }
            catch { }
        }

        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return; // 沒有選擇任何一筆資料
            var selectedRow = dataGridView.Rows[e.RowIndex];
            var args = new DataSelectedEventArgs(selectedRow, _sortableBindingList);
            OnDataSelected(args);
        }

        protected override Control GetDataComponent()
        {
            //return base.GetDataComponent();
            dataGridView = new DataGridView();
            dataGridView.AutoGenerateColumns = false;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.RowHeadersVisible = false;
            dataGridView.MultiSelect = false;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.RowTemplate.Height = 24;                    
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;            
            dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            DataGridView.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                BackColor = ColorTranslator.FromHtml("#00797B"),
                ForeColor = ColorTranslator.FromHtml("#FFFFFF"),
                SelectionBackColor = ColorTranslator.FromHtml("#FF7F7F"),
                SelectionForeColor = ColorTranslator.FromHtml("#000000"),
                WrapMode = DataGridViewTriState.False,                
            };
            DataGridView.DefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                BackColor = SystemColors.Window,
                ForeColor = SystemColors.ControlText,
                SelectionBackColor = ColorTranslator.FromHtml("#FFFF80"),
                SelectionForeColor = ColorTranslator.FromHtml("#000000"),
                WrapMode = DataGridViewTriState.False,
            };
            dataGridView.CellDoubleClick += DataGridView_CellDoubleClick;
            dataGridView.CellFormatting += DataGridView_CellFormatting;
            dataGridView.SelectionChanged += DataGridView_SelectionChanged;
            dataGridView.CellMouseDown += DataGridView_CellMouseDown;
            dataGridView.CellMouseUp += DataGridView_CellMouseUp;
            dataGridView.ColumnRemoved += DataGridView_ColumnRemoved;

            return dataGridView;
        }
        public interface IMergedDataGridViewColumn
        {
            string MergedKey { get; }
        }
        public class DataGridViewMergedTextBoxColumn : DataGridViewTextBoxColumn, IMergedDataGridViewColumn
        {
            public string MergedKey { get; set; }
            public DataGridViewMergedTextBoxColumn()
            {
                DefaultHeaderCellType = typeof(DataGridViewMergedHeaderCell);
            }
        }
        public class DataGridViewMergedHeaderCell : DataGridViewColumnHeaderCell
        {
            protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates dataGridViewElementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
            {
                base.Paint(graphics,
                    clipBounds,
                    clipBounds,
                    rowIndex,
                    dataGridViewElementState,
                    value,
                    formattedValue,
                    errorText,
                    cellStyle,
                    advancedBorderStyle,
                    paintParts);
            }
        }

        #region Formatters
        public static void RoundFloatFormatter(object sender, FormattingCellEventArgs e)
        {
            var value = (double?)e.Value;
            var format = e.Arguments.ElementAtOrDefault(0) as string;
            if (value.HasValue && format != null)
            {
                var formattedValue = value.Value.ToString(format);
                e.Value = formattedValue;
                e.FormattingApplied = true;
            }
        }

        public static void DateTimeFormatter(object sender, FormattingCellEventArgs e)
        {
            var value = (DateTime?)e.Value;
            var format = e.Arguments.ElementAtOrDefault(0) as string;
            if (value.HasValue && format != null)
            {
                var formattedValue = value.Value.ToString(format);
                e.Value = formattedValue;
                e.FormattingApplied = true;
            }
        }
        public static void TextDatFormatter(object sender, FormattingCellEventArgs e)
        {
            var value = e.Value as string;
            var outputFormat = e.Arguments.ElementAtOrDefault(1) as string;
            if (!string.IsNullOrEmpty(value) && !string.IsNullOrEmpty(outputFormat))
            {
                var inputFormat = e.Arguments.ElementAtOrDefault(0) as string;
                string formattedValue = null;
                DateTime time;
                if (inputFormat != null && DateTime.TryParseExact(value, inputFormat, null, DateTimeStyles.None, out time))
                    formattedValue = time.ToString(outputFormat);
                else
                {
                    var inputFormats = e.Arguments.ElementAtOrDefault(2) as string[];
                    if (inputFormats != null)
                    {
                        for (var i = 0; i < inputFormats.Length; i++)
                        {
                            if (DateTime.TryParseExact(value, inputFormats[i], null, DateTimeStyles.None, out time))
                            {
                                formattedValue = time.ToString(outputFormat);
                                break;
                            }
                        }
                    }
                    else
                    {
                        //TODO: convert time
                        //time = InternalDateTimeHelper.ConvertTo(value, )
                    }


                }
                if (formattedValue != null)
                {
                    e.Value = formattedValue;
                    e.FormattingApplied = true;
                }
            }
        }
        public static void BooleanFormatter(object sender, FormattingCellEventArgs e)
        {
            var value = (bool?)e.Value;
            var positive = e.Arguments.ElementAtOrDefault(0) as string;
            var negative = e.Arguments.ElementAtOrDefault(1) as string;
            if (value.HasValue)
            {
                var formattedValue = value.Value ? (positive ?? "Y") : (negative ?? "N");
                e.Value = formattedValue;
                e.FormattingApplied = true;
            }
        }
        #endregion

        public class ColumnBuilder<T> where T : DataGridViewColumn
        {
            private readonly CgDataGridPanel _panel;
            private Delegate _creation;
            private List<DelegateBag> _configurations
                = new List<DelegateBag>();
            private List<FormattingCellEventItem> _formattingEventItems
                = new List<FormattingCellEventItem>();

            public ColumnBuilder(CgDataGridPanel panel)
            {
                _panel = panel;
            }

            public T Commit()
            {
                var column = (T)(_creation == null
                    ? Activator.CreateInstance(typeof(T))
                    : _creation.DynamicInvoke());
                foreach (var action in _configurations)
                    action.Invoke(column);
                _panel.AppendColumn(column, _formattingEventItems);
                return column;
            }

            public ColumnBuilder<T> CreateBy(Func<T> creation)
            {
                _creation = creation;
                return this;
            }
            public ColumnBuilder<T> ConfigBy(Action<T> configuration)
            {
                _configurations.Add(new DelegateBag(configuration));
                return this;
            }
            public ColumnBuilder<T> ConfigBy<TArg>(Action<T, TArg> configuration, TArg arg)
            {
                _configurations.Add(new DelegateBag(configuration, new object[] { arg }));
                return this;
            }
            public ColumnBuilder<T> ConfigBy<TArg1, TArg2>(Action<T, TArg1, TArg2> configuration, TArg1 arg1, TArg2 arg2)
            {
                _configurations.Add(new DelegateBag(configuration, new object[] { arg1, arg2 }));
                return this;
            }
            public ColumnBuilder<T> ConfigBy<TArg1, TArg2, TArg3>(Action<T, TArg1, TArg2, TArg3> configuration, TArg1 arg1, TArg2 arg2, TArg3 arg3)
            {
                _configurations.Add(new DelegateBag(configuration, new object[] { arg1, arg2, arg3 }));
                return this;
            }
            public ColumnBuilder<T> ConfigBy(Delegate configuration, params object[] args)
            {
                _configurations.Add(new DelegateBag(configuration, args));
                return this;
            }
            public ColumnBuilder<T> UseFormatter(FormattingCellEventHandler handler, params object[] args)
            {
                _formattingEventItems.Add(new FormattingCellEventItem(_panel, handler, args));
                return this;
            }
            #region 設定欄位
            public ColumnBuilder<T> UseSortable(DataGridViewColumnSortMode mode)
            {
                return ConfigBy((c, v) => c.SortMode = v, mode);
            }
            public ColumnBuilder<T> UseFillWeight(float weight)
            {
                return ConfigBy((c, v) => c.FillWeight = v, weight);
            }
            public ColumnBuilder<T> UseWidth(int width)
            {
                return ConfigBy((c, v) => c.Width = v, width);
            }
            public ColumnBuilder<T> UseHeaderTextAlign(DataGridViewContentAlignment align)
            {
                return ConfigBy((c, v) => c.HeaderCell.Style.Alignment = v, align);
            }
            public ColumnBuilder<T> UseTextAlign(DataGridViewContentAlignment align)
            {
                return ConfigBy((c, v) => c.DefaultCellStyle.Alignment = v, align);
            }
            public ColumnBuilder<T> Bind(string name, string propertyName = null, string title = null, string tooltip = null)
            {
                return ConfigBy(new Action<T, string, string, string, string>((c, v1, v2, v3, v4) =>
                {
                    c.Name = v1;
                    c.DataPropertyName = v2 ?? v1;
                    c.HeaderText = v3 ?? v1;
                    c.ToolTipText = v4 ?? c.HeaderText;
                }), name, propertyName, title, tooltip);
            }
            public ColumnBuilder<T> Bind<TModel>(Expression<Func<TModel, object>> selector, string title = null, string tooltip = null)
            {
                return ConfigBy(new Action<T, LambdaExpression, string, string>((c, v1, v2, v3) =>
                {
                    var property = GetPropertyInfoFromExpression(v1);
                    if (property == null)
                        throw new InvalidOperationException("no property found");
                    c.Name = property.Name;
                    c.DataPropertyName = property.Name;
                    c.HeaderText = title ?? Commons.GetDisplayName(property);
                    c.ToolTipText = tooltip ?? c.HeaderText;
                }), selector, title, tooltip);
            }

            #endregion

            
            private class DelegateBag
            {
                private readonly Delegate _delegate;
                private readonly object[] _args;

                public DelegateBag(Delegate @delegate)
                {
                    _delegate = @delegate;
                }
                public DelegateBag(Delegate @delegate, object[] args) : this(@delegate)
                {
                    _args = args;
                }
                public void Invoke(T column)
                {
                    var args = new object[] { column }; // 必要參數
                    if (_args != null && _args.Length > 0)
                        args = args.Concat(_args).ToArray();
                    _delegate.DynamicInvoke(args);
                }
            }
        }



        private class FormattingCellEventItem
        {
            private readonly CgDataGridPanel _panel;
            private readonly FormattingCellEventHandler _handler;
            private readonly object[] _args;

            public FormattingCellEventItem(CgDataGridPanel panel, FormattingCellEventHandler handler, object[] args)
            {
                _panel = panel;
                _handler = handler;
                _args = args;
            }

            public void Invoke(FormattingCellEventArgs e)
            {
                e.Arguments = _args;
                _handler(_panel, e);
            }
        }
        public delegate void FormattingCellEventHandler(object sender, FormattingCellEventArgs e);
        public delegate void SelectedRowChangedEventHandler(object sender, SelectedRowChangedEventArgs e);
        public delegate void DataSelectedEventHandler(object sender, DataSelectedEventArgs e);


        public class SelectedRowChangedEventArgs : EventArgs
        {
            public SelectedRowChangedEventArgs(DataGridViewRow row)
            {
                Row = row;

            }
            public bool IsEmpty
            {
                get { return Row == null; }
            }
            public DataGridViewRow Row { get; private set; }
        }

        public class DataSelectedEventArgs : EventArgs
        {
            public DataSelectedEventArgs(DataGridViewRow row, bool sortableBindingList)
            {
                if (sortableBindingList)
                    Data = row.DataBoundItem;
                else
                    Data = row;
                Index = row.Index;
            }
            public object Data { get; private set; }
            public int Index { get; private set; }
            public bool IsEmpty
            {
                get { return Data == null; }
            }
        }

        public class FormattingCellEventArgs : EventArgs
        {
            private readonly DataGridViewCellFormattingEventArgs e;
            private object[] _args;

            public FormattingCellEventArgs(DataGridView dataGridview, DataGridViewCellFormattingEventArgs args)
            {
                DataGridView = dataGridview;
                e = args;
            }
            public DataGridView DataGridView { get; private set; }

            public DataGridViewColumn Column
            {
                get { return DataGridView.Columns[e.ColumnIndex]; }
            }
            public DataGridViewRow Row
            {
                get { return DataGridView.Rows[e.RowIndex]; }
            }
            public DataGridViewCell Cell
            {
                get { return Row.Cells[e.ColumnIndex]; }
            }
            public int ColumnIndex
            {
                get { return e.ColumnIndex; }
            }
            public int RowIndex
            {
                get { return e.RowIndex; }
            }

            public bool FormattingApplied
            {
                get { return e.FormattingApplied; }
                set { e.FormattingApplied = value; }
            }
            public object Value
            {
                get { return e.Value; }
                set { e.Value = value; }
            }
            public Type DesiredType
            {
                get { return e.DesiredType; }
            }
            public bool IsEmpty
            {
                get { return Value == null; }
            }
            public DataGridViewCellStyle CellStyle
            {
                get { return e.CellStyle; }
                set { e.CellStyle = value; }
            }
            internal DataGridViewCellFormattingEventArgs DataGridViewCellFormattingEventArgs
            {
                get { return e; }
            }
            public object[] Arguments
            {
                get { return _args ?? new object[0]; }
                set { _args = value; }
            }
        }
    }
}

