using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Telemedicine.Forms
{
    public interface ICgComboBox
    {
        int ItemCount { get; }        
        CgComboBox.ComboBoxItem SelectedComboItem { get; }
        ComboBox.ObjectCollection Items { get; }
        object SelectedItem { get; }
        object SelectedValue { get; set; }
        int SelectedIndex { get; set; }
        string SelectedText { get; set; }
        ComboBoxStyle DropDownStyle { get; set; }

        event EventHandler SelectedIndexChanged;
        event CgComboBox.DrawItemStyleEventHandler DrawItemStyle;

        int AddItem(CgComboBox.ComboBoxItem cbItem);
        int AddItem(object item);
        int AddItem(object item, string text, object value);
        int AddItem<T, V>(T item, Func<T, string> textResolver, Func<T, V> valueResolver);
        int AddItem<T>(T item, Func<T, string> textResolver);
        void AddItemRange<T, V>(IEnumerable<T> items, Func<T, string> textResolver, Func<T, V> valueResolver);
        void AddItemRange<T>(IEnumerable<T> items, Func<T, string> textResolver);
        int AddTextItem(string text);
        int AddTextItem(string text, object value);
        void AddTextItemRange(string[] texts, object[] values);
        CgComboBox.ComboBoxItem GetComboBoxItem(int index);
        int GetIndexOfItem<T>(T item, IEqualityComparer<T> comparer = null, Func<object, T> converter = null);
        int GetIndexOfItemText(string text, StringComparison comparison = StringComparison.OrdinalIgnoreCase);
        int GetIndexOfItemValue<T>(T value, IEqualityComparer<T> comparer = null, Func<object, T> converter = null);
        void PerformSelectedIndexChanged();
        int SelectItem(Func<CgComboBox.ComboBoxItem, bool> selector);
        int SelectItem<T>(Func<T, bool> itemSelector, Func<object, T> converter = null);
        int SelectItem<T>(T item, IEqualityComparer<T> comparer = null, Func<object, T> converter = null);
        int SelectValue<T>(Func<T, bool> itemSelector, Func<object, T> converter = null);
        int SelectValue<T>(T value, IEqualityComparer<T> comparer = null, Func<object, T> converter = null);
        
    }

    public class CgComboBox : ComboBox, ICgComboBox
    {
        public CgComboBox()
        {
            DisplayMember = "Text";
            ValueMember = "Value";
            DrawItem += CgComboBox_DrawItem;
            DrawMode = DrawMode.OwnerDrawVariable;
        }

        #region ??????
        public event DrawItemStyleEventHandler DrawItemStyle;
        #endregion

        #region ??????
        /// <summary>
        /// ??????????????????????????????<see cref="ComboBoxItem"/>
        /// </summary>
        public ComboBoxItem SelectedComboItem
        {
            get
            {
                var index = SelectedIndex;
                if (index == -1) return null;
                return GetComboBoxItem(index);
            }
        }
        /// <summary>
        /// ????????????????????????????????????
        /// </summary>
        public new object SelectedItem
        {
            get
            {
                var cbItem = SelectedComboItem;
                if (cbItem == null) return null;
                return cbItem.Item;
            }
        }
        /// <summary>
        /// ???????????????????????????
        /// </summary>
        public int ItemCount
        {
            get { return Items.Count; }
        }

        public new object SelectedValue
        {
            get
            {
                var cbItem = SelectedComboItem;
                if (cbItem == null)
                    return null;
                return cbItem.Value;
            }
            set
            {
                var comparer = CreateComparer(value);
                var index = comparer == null ? GetIndexOfObjectValue(value) : GetIndexOfItem(cbItem => comparer.Equals(cbItem.Value, value));
                SelectedIndex = index;
            }
        }
        #endregion


        #region ????????????
        /// <summary>
        /// ?????????????????????<see cref="ComboBoxItem"/>
        /// </summary>        
        public ComboBoxItem GetComboBoxItem(int index)
        {
            return Items[index] as ComboBoxItem;
        }
        /// <summary>
        /// ??????????????????????????????
        /// </summary>        
        public int GetIndexOfItemText(string text, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
        {
            return GetIndexOfItem(cbItem => string.Equals(text, cbItem.Text, comparison));
        }
        /// <summary>
        /// ??????????????????????????????
        /// </summary>    
        public int GetIndexOfItemValue<T>(T value, IEqualityComparer<T> comparer = null, Func<object, T> converter = null)
        {
            if (comparer == null)
                comparer = EqualityComparer<T>.Default;
            if (converter == null)
                converter = v => (T)v;
            return GetIndexOfItem(cbItem => comparer.Equals(value, converter(cbItem.Value)));
        }
        /// <summary>
        /// ??????????????????????????????
        /// </summary>    
        public int GetIndexOfItem<T>(T item, IEqualityComparer<T> comparer = null, Func<object, T> converter = null)
        {
            if (comparer == null)
                comparer = EqualityComparer<T>.Default;
            if (converter == null)
                converter = v => (T)v;
            return GetIndexOfItem(cbItem => comparer.Equals(item, converter(cbItem.Item)));
        }
        /// <summary>
        /// ??????????????????????????????
        /// </summary>        
        public int SelectItem(Func<ComboBoxItem, bool> selector)
        {
            return SelectedIndex = GetIndexOfItem(selector);
        }
        /// <summary>
        /// ??????????????????????????????
        /// </summary>   
        public int SelectItem<T>(Func<T, bool> itemSelector, Func<object, T> converter = null)
        {
            if (converter == null)
                converter = v => (T)v;
            return SelectItem(cbItem => itemSelector(converter(cbItem.Item)));
        }
        /// <summary>
        /// ??????????????????????????????
        /// </summary>   
        public int SelectItem<T>(T item, IEqualityComparer<T> comparer = null, Func<object, T> converter = null)
        {
            return SelectedIndex = GetIndexOfItem(item, comparer, converter);
        }
        /// <summary>
        /// ??????????????????????????????
        /// </summary>   
        public int SelectValue<T>(Func<T, bool> itemSelector, Func<object, T> converter = null)
        {
            if (converter == null)
                converter = v => (T)v;
            return SelectItem(cbItem => itemSelector(converter(cbItem.Value)));
        }
        /// <summary>
        /// ??????????????????????????????
        /// </summary>   
        public int SelectValue<T>(T value, IEqualityComparer<T> comparer = null, Func<object, T> converter = null)
        {
            return SelectedIndex = GetIndexOfItemValue(value, comparer, converter);
        }

        /// <summary>
        /// ????????????
        /// </summary>
        public int AddItem(ComboBoxItem cbItem)
        {
            var index = Items.Add(cbItem);
            var measureWidth = TextRenderer.MeasureText(cbItem.Text, Font ?? DefaultFont).Width + Commons.MagicHorizonal;
            if (measureWidth > DropDownWidth)
                DropDownWidth = measureWidth;
            return index;
        }
        /// <summary>
        /// ????????????
        /// </summary>
        public int AddItem(object item, string text, object value)
        {
            var cbItem = new ComboBoxItem(item, text, value);
            return AddItem(cbItem);
        }
        /// <summary>
        /// ????????????
        /// </summary>
        public int AddItem<T, V>(T item, Func<T, string> textResolver, Func<T, V> valueResolver)
        {
            var cbItem = new ComboBoxItem(item, textResolver, valueResolver);
            return AddItem(cbItem);
        }
        /// <summary>
        /// ????????????
        /// </summary>
        public int AddItem<T>(T item, Func<T, string> textResolver)
        {
            return AddItem(item, textResolver, r => r);
        }
        /// <summary>
        /// ????????????
        /// </summary>
        public int AddItem(object item)
        {
            var cbItem = item as ComboBoxItem;
            if (cbItem != null)
                return AddItem(cbItem);
            return AddItem(item, r => r.ToString());
        }
        /// <summary>
        /// ??????????????????
        /// </summary>
        public void AddItemRange<T, V>(IEnumerable<T> items, Func<T, string> textResolver, Func<T, V> valueResolver)
        {
            foreach (var item in items)
                AddItem(item, textResolver, valueResolver);
        }
        /// <summary>
        /// ??????????????????
        /// </summary>
        public void AddItemRange<T>(IEnumerable<T> items, Func<T, string> textResolver)
        {
            foreach (var item in items)
                AddItem(item, textResolver);
        }
        /// <summary>
        /// ??????????????????
        /// </summary>
        public int AddTextItem(string text)
        {
            var cbItem = new ComboBoxItem(text);
            return AddItem(cbItem);
        }
        /// <summary>
        /// ??????????????????
        /// </summary>
        public int AddTextItem(string text, object value)
        {
            var cbItem = new ComboBoxItem(text, text, value);
            return AddItem(cbItem);
        }
        /// <summary>
        /// ????????????????????????
        /// </summary>
        public void AddTextItemRange(string[] texts, object[] values)
        {
            for (var i = 0; i < texts.Length; i++)
            {
                var cbItem = new ComboBoxItem(texts[i], texts[i], values[i]);
                AddItem(cbItem);
            }
        }

        public void PerformSelectedIndexChanged()
        {
            OnSelectedIndexChanged(EventArgs.Empty);
        }
        #endregion

        protected int GetIndexOfItem(Func<ComboBoxItem, bool> comparison)
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (comparison(GetComboBoxItem(i)))
                    return i;
            }
            return -1;
        }
        protected virtual void OnDrawItemStyle(DrawItemStyleEventArgs e)
        {
            var handler = DrawItemStyle;
            if (handler != null)
                handler(this, e);
        }
        protected int GetIndexOfObjectValue(object value)
        {
            return GetIndexOfItem(cbItem => cbItem.Value == value);
        }

        private static IEqualityComparer CreateComparer(object value)
        {
            IEqualityComparer comparer = null;
            if (value != null)
            {
                var property = typeof(EqualityComparer<>).MakeGenericType(value.GetType()).GetProperty("Default", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
                if (property != null)
                    comparer = (IEqualityComparer)property.GetValue(null, null);
            }
            return comparer;
        }

        private void CgComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            var item = e.Index < 0 ? null : GetComboBoxItem(e.Index);
            var ev = new DrawItemStyleEventArgs(e, item);
            OnDrawItemStyle(ev);
            e.Graphics.FillRectangle(new SolidBrush(ev.BackColor), e.Bounds);
            e.Graphics.DrawString(GetItemText(item), ev.Font, new SolidBrush(ev.ForeColor), e.Bounds);
        }
        public class ComboBoxItem : OptionItem
        {
            public ComboBoxItem(object item) : base(item)
            {
            }

            public ComboBoxItem(string text) : base(text)
            {
            }

            public ComboBoxItem(object item, Delegate textResolver, Delegate valueResolver) : base(item, textResolver, valueResolver)
            {
            }

            public ComboBoxItem(object item, string text, object value) : base(item, text, value)
            {
            }
        }

        public delegate void DrawItemStyleEventHandler(object sender, DrawItemStyleEventArgs e);
        public class DrawItemStyleEventArgs : EventArgs
        {
            public DrawItemStyleEventArgs(DrawItemEventArgs e, ComboBoxItem item)
            {
                BackColor = e.BackColor;
                ForeColor = e.ForeColor;
                Font = e.Font;
                Item = item;
            }

            public Color BackColor { get; set; }
            public Color ForeColor { get; set; }
            public Font Font { get; set; }
            public ComboBoxItem Item { get; private set; }
            public bool IsEmpty
            {
                get { return Item == null; }
            }
        }
    }
}

