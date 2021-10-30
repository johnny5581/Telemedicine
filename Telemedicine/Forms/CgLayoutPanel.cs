using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Telemedicine.Forms
{
    [ProvideProperty("LayoutSize", typeof(Control))]
    public class CgLayoutPanel : CgTableLayoutPanel, IExtenderProvider
    {
        private bool _flgEditing;
        private Dictionary<Control, TableLayoutPanelCellPosition> _posCache;
        public CgLayoutPanel()
        {
        }
        #region 屬性
        /// <summary>
        /// 是否處在編輯模式下
        /// </summary>
        public bool EditMode
        {
            get { return _flgEditing; }
        }
        public LayoutSize LayoutSize
        {
            get
            {
                return new LayoutSize(ColumnCount, RowCount);
            }
        }
        #endregion

        #region 事件
        public event ControlPositionChangedEventHandler ControlPositionChanged;
        public event ControlLayoutSizeChangedEventHandler ControlLayoutSizeChanged;
        public event EventHandler LayoutSizeChanged;
        #endregion

        public Dictionary<Control, TableLayoutPanelCellPosition> GetPositionMap()
        {
            var map = new Dictionary<Control, TableLayoutPanelCellPosition>();
            foreach (Control control in Controls)
                map.Add(control, GetPositionFromControl(control));
            return map;
        }


        public void BeginEdit()
        {
            _flgEditing = true;
            BeginEdit(ref _posCache);
        }
        public void EndEdit()
        {
            List<ControlPositionChangedEventArgs> eventArgs;
            EndEdit(ref _posCache, out eventArgs);
            foreach (var arg in eventArgs)
                OnControlPositionChanged(arg);
            _flgEditing = false;
        }

        public TableLayoutPanelCellPosition? GetCellPosition(Point location)
        {
            int row = -1, column = -1;
            float x = 0f, y = 0f;
            for (var index = 0; index < RowCount; index++)
            {
                var style = RowStyles[index];
                switch (style.SizeType)
                {
                    case SizeType.Absolute:
                        y += style.Height;
                        break;
                    case SizeType.Percent:
                        y += style.Height / 100 * Height;
                        break;
                }
                if (y > location.Y)
                {
                    row = index;
                    break;
                }
            }
            for (var index = 0; index < ColumnCount; index++)
            {
                var style = ColumnStyles[index];
                switch (style.SizeType)
                {
                    case SizeType.Absolute:
                        x += style.Width;
                        break;
                    case SizeType.Percent:
                        x += style.Width / 100 * Width;
                        break;
                }
                if (x > location.X)
                {
                    column = index;
                    break;
                }
            }

            if (column != -1 && row != -1)
                return new TableLayoutPanelCellPosition(column, row);
            return null;
        }
        public bool ValidatePosition(TableLayoutPanelCellPosition position)
        {
            return ValidatePosition(position, ColumnCount, RowCount);
        }
        public bool ValidatePosition(int column, int row)
        {
            return ValidatePosition(new TableLayoutPanelCellPosition(column, row));
        }



        public Control GetControlFromPosition(TableLayoutPanelCellPosition position)
        {
            return GetControlFromPosition(position.Column, position.Row);
        }

        public void SetCellPosition(Control control, int column, int row)
        {
            SetCellPosition(control, new TableLayoutPanelCellPosition(column, row));
        }
        public void SetControlLayoutSize(Control control, LayoutSize layoutSize, Action<Control, TableLayoutPanelCellPosition> overlapHandler)
        {
            var flag = overlapHandler != null;
            Dictionary<Control, TableLayoutPanelCellPosition> map = null;
            if (flag)
            {
                map = new Dictionary<Control, TableLayoutPanelCellPosition>();
                BeginEdit(ref map);
            }
            var position = GetPositionFromControl(control);
            RemoveControlsFromPosition(position, layoutSize, false);
            var actualWidth = GetLength(position.Column, LayoutSize.Width, Orientation.Horizontal);
            var actualHeight = GetLength(position.Column, LayoutSize.Height, Orientation.Vertical);
            SetColumnSpan(control, actualWidth);
            SetRowSpan(control, actualHeight);
            if (flag)
            {
                List<ControlPositionChangedEventArgs> eventArgs;
                EndEdit(ref map, out eventArgs);
                foreach (var args in eventArgs)
                    overlapHandler(args.Control, args.OldPosition);
            }
            OnControlLayoutSizeChanged(new ControlLayoutSizeChangeEventArgs(control, layoutSize));
        }
        public void SetControlLayoutSize(Control control, LayoutSize layoutSize)
        {
            SetControlLayoutSize(control, layoutSize, null);
        }

        public void AddControlToPosition(Control control, int column, int row)
        {
            Controls.Add(control, column, row);
        }
        public void AddControlToPosition(Control control, TableLayoutPanelCellPosition position)
        {
            AddControlToPosition(control, position.Column, position.Row);
        }

        public void RemoveControlFromPosition(TableLayoutPanelCellPosition position)
        {
            var control = GetControlFromPosition(position);
            if (control != null)
                RemoveControl(control);
        }
        public void RemoveControlFromPosition(int column, int row)
        {
            RemoveControlFromPosition(new TableLayoutPanelCellPosition(column, row));
        }
        public void RemoveControlsFromPosition(TableLayoutPanelCellPosition position, LayoutSize size, bool includeRoot)
        {
            for (var row = position.Row; row < position.Row + size.Height; row++)
            {
                for (var column = position.Column; column < position.Column + size.Width; column++)
                {
                    if ((row != position.Row && column != position.Column) || includeRoot)
                    {
                        var p = new TableLayoutPanelCellPosition(column, row);
                        RemoveControlFromPosition(p);
                    }
                }
            }
        }
        public void RemoveControl(Control control)
        {
            Controls.Remove(control);
        }



        public void ChangeLayout(LayoutSize size, Action<Control, TableLayoutPanelCellPosition> outOfRangeControlHandler = null)
        {
            ChangeLayout(size.Width, size.Height, outOfRangeControlHandler);
        }
        public void ChangeLayout(int column, int row, Action<Control, TableLayoutPanelCellPosition> outOfRangeControlHandler = null)
        {
            var width = 100f / column;
            var height = 100f / row;
            var columnWidths = Enumerable.Repeat(width, column).ToArray();
            var rowHeights = Enumerable.Repeat(height, row).ToArray();
            ChangeLayout(columnWidths, rowHeights, outOfRangeControlHandler);
        }
        public void ChangeLayout(float[] columnWidths, float[] rowHeights, Action<Control, TableLayoutPanelCellPosition> outOfRangeControlHandler = null)
        {
            var columnStyles = columnWidths.Select(r => new ColumnStyle(SizeType.Percent, r)).ToArray();
            var rowStyles = rowHeights.Select(r => new RowStyle(SizeType.Percent, r)).ToArray();
            ChangeLayout(columnStyles, rowStyles, outOfRangeControlHandler);
        }
        public void ChangeLayout(ColumnStyle[] columnStyles, RowStyle[] rowStyles, Action<Control, TableLayoutPanelCellPosition> outOfRangeControlHandler = null)
        {            
            foreach(Control control in Controls)
            {
                var position = GetPositionFromControl(control);
                if (!ValidatePosition(position, columnStyles.Length, rowStyles.Length) && outOfRangeControlHandler != null)
                    outOfRangeControlHandler(control, position);
            }
            SuspendLayout();
            ColumnStyles.Clear();
            RowStyles.Clear();
            foreach (var style in columnStyles)
                ColumnStyles.Add(style);
            foreach (var style in rowStyles)
                RowStyles.Add(style);
            ColumnCount = columnStyles.Length;
            RowCount = rowStyles.Length;            
            ResumeLayout(true);

            OnLayoutSizeChanged();
        }


        #region IExtenderProvider
        [DefaultValue(typeof(Size), "1,1")]
        public LayoutSize GetLayoutSize(Control control)
        {
            var rowSpan = GetRowSpan(control);
            var columnSpan = GetColumnSpan(control);
            return new LayoutSize(columnSpan, rowSpan);
        }
        public void SetLayoutSize(Control control, LayoutSize size)
        {
            if (size.IsEmpty)
                throw new InvalidOperationException("invalid layout size");
            SetColumnSpan(control, size.Width);
            SetRowSpan(control, size.Height);            
        }
        #endregion


        protected virtual void OnControlPositionChanged(ControlPositionChangedEventArgs e)
        {
            var handler = ControlPositionChanged;
            if (handler != null)
                handler(this, e);
        }
        protected virtual void OnControlLayoutSizeChanged(ControlLayoutSizeChangeEventArgs e)
        {
            var handler = ControlLayoutSizeChanged;
            if (handler != null)
                handler(this, e);
        }
        protected virtual void OnLayoutSizeChanged()
        {
            var handler = LayoutSizeChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
        protected void BeginEdit(ref Dictionary<Control, TableLayoutPanelCellPosition> map)
        {
            if (map != null)
                throw new InvalidOperationException("current is editing");
            map = GetPositionMap();
        }
        protected void EndEdit(ref Dictionary<Control, TableLayoutPanelCellPosition> map, out List<ControlPositionChangedEventArgs> eventArgs)
        {
            eventArgs = new List<ControlPositionChangedEventArgs>();
            if (map != null)
            {
                var current = GetPositionMap();

                // 紀錄已經不再的類別
                foreach (var control in map.Keys)
                {
                    if (!current.ContainsKey(control))
                        eventArgs.Add(new ControlPositionChangedEventArgs(control, ControlPositionChangedTypes.Remove) { OldPosition = _posCache[control] });
                }

                // 處理 新增移動
                foreach (var control in current.Keys)
                {
                    // 原本就不存在，新增
                    if (!map.ContainsKey(control))
                        eventArgs.Add(new ControlPositionChangedEventArgs(control, ControlPositionChangedTypes.Add) { NewPosition = current[control] });
                    // 原本就有但是位置變化，
                    else if (!map[control].Equals(current[control]))
                        eventArgs.Add(new ControlPositionChangedEventArgs(control, ControlPositionChangedTypes.Move) { OldPosition = _posCache[control], NewPosition = current[control] });
                }
                map = null;
            }
        }

        protected int GetLength(int srcIndex, int value, Orientation orientation)
        {
            var lastPositionValue = orientation == Orientation.Horizontal ? ColumnCount : RowCount;
            var lastPositionIndex = lastPositionValue - 1;
            var minIndex = Math.Min(lastPositionIndex, srcIndex + value - 1);
            var actualLength = minIndex - srcIndex + 1;
            return actualLength;
        }

        public static bool ValidatePosition(TableLayoutPanelCellPosition position, int width, int height)
        {
            return position.Column < width && position.Row < height;
        }

        public delegate void ControlPositionChangedEventHandler(object sender, ControlPositionChangedEventArgs e);
        public delegate void ControlLayoutSizeChangedEventHandler(object sender, ControlLayoutSizeChangeEventArgs e);
        public class ControlPositionChangedEventArgs : ControlEventArgs
        {
            public ControlPositionChangedEventArgs(Control control, ControlPositionChangedTypes changedType) : base(control)
            {
                ChangedType = changedType;
            }
            public ControlPositionChangedTypes ChangedType { get; private set; }
            public TableLayoutPanelCellPosition OldPosition { get; internal set; }
            public TableLayoutPanelCellPosition NewPosition { get; internal set; }
        }
        public enum ControlPositionChangedTypes
        {
            Add, Remove, Move
        }
        public class ControlLayoutSizeChangeEventArgs : ControlEventArgs
        {
            public ControlLayoutSizeChangeEventArgs(Control control, LayoutSize newSize) : base(control)
            {
                NewSize = newSize;
            }

            public LayoutSize NewSize { get; private set; }
        }
    }
    /// <summary>
    /// 排版大小
    /// </summary>    
    public struct LayoutSize : IEquatable<LayoutSize>
    {
        public static readonly LayoutSize Default = new LayoutSize(1, 1);
        private int _width;
        private int _height;
        public LayoutSize(int width, int height)
        {
            _width = width;
            _height = height;
        }

        public int Width
        {
            get { return _width; }
            set
            {
                ValidateSizeValue(value);
                _width = value;
            }
        }

        public int Height
        {
            get { return _height; }
            set
            {
                ValidateSizeValue(value);
                _height = value;
            }
        }
        public bool IsEmpty
        {
            get { return !Validate(_width) || !Validate(_height); }
        }

        private void ValidateSizeValue(int value)
        {
            if (!Validate(value))
                throw new InvalidOperationException("size must large than 0");
        }
        private static bool Validate(int value)
        {
            return value > 0;
        }

        public bool Equals(LayoutSize other)
        {
            return IsEmpty == other.IsEmpty && Width == other.Width && Height == other.Height;
        }

        public static implicit operator Size(LayoutSize layoutSize)
        {
            return new Size(layoutSize.Width, layoutSize.Height);
        }

        public static implicit operator LayoutSize(Size size)
        {
            return new LayoutSize(size.Width, size.Height);
        }
    }
}

