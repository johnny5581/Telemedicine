using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Telemedicine.Forms
{
    public class CgDataListPanel : CgDataPanel
    {
        private ListView listView;
        public CgDataListPanel()
        {

        }

        public override object DataSource
        {
            get { return listView.Items; }
        }
        protected override Control GetDataComponent()
        {
            //return base.GetDataComponent();
            listView = new ListView();
            listView.Activation = ItemActivation.OneClick;
            listView.CheckBoxes = true;
            listView.FullRowSelect = true;
            listView.GridLines = true;
            listView.HideSelection = false;
            listView.UseCompatibleStateImageBehavior = false;
            listView.View = View.Details;
            listView.ShowGroups = false;
            listView.ListViewItemSorter = new ListViewSorter();
            return listView;
        }
        /// <summary>
        /// 增加文字欄位
        /// </summary> 
        public ColumnHeader AddTextColumn(string name, string title, string propertyName = null)
        {
            var column = new DataColumnHeader
            {
                Name = name,
                Text = title,
                Width = -2,
                PropertyName = propertyName,
            };
            listView.Columns.Add(column);
            return column;
        }
        /// <summary>
        /// 增加文字欄位
        /// </summary>        
        public ColumnHeader AddTextColumn<T>(Expression<Func<T, object>> selector, string title = null)
        {
            var property = GetPropertyInfoFromExpression(selector);
            var column = new DataColumnHeader
            {
                Name = property.Name,
                Text = title ?? property.Name,
                Width = -2,
                PropertyName = property.Name,
            };
            listView.Columns.Add(column);
            return column;
        }



        public override void SetSource<T>(IEnumerable<T> list)
        {
            listView.Items.Clear();
            var idx = 0;
            foreach (var obj in list)
            {
                var item = new DataListItem();
                item.Tag = obj;
                item.OriginIndex = idx++;
                for (var i = 0; i < listView.Columns.Count; i++)
                {
                    var column = listView.Columns[i] as DataColumnHeader;
                    var text = column.GetValue(obj);
                    if (i == 0)
                        item.Text = text;
                    else
                        item.SubItems.Add(text);
                }
                listView.Items.Add(item);
                if (AutoFitColumnWidth)
                    listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
        }
        public bool TrySelectRow<T>(Func<T, bool> selector, bool firstOnly = true)
        {
            var flag = false;
            ForEachItem(item =>
            {
                var obj = (T)item.Tag;
                if(selector(obj))
                {
                    if (firstOnly && flag)
                        return;
                    item.Checked = true;
                    flag = true;
                }                
            });
            return flag;
        }
        public override object[] GetSelectedItems()
        {
            if (listView.CheckedItems.Count == 0)
                return new object[0];
            var items = new object[listView.CheckedItems.Count];
            for (var index = 0; index < listView.CheckedItems.Count; index++)
                items[index] = listView.CheckedItems[index].Tag;
            return items;
        }
        public override void ClearSource()
        {
            listView.Items.Clear();
        }

        public override void ClearSelection()
        {
            ForEachItem(item => { item.Checked = false; });
        }

        protected override int GetDataCount(object source)
        {
            if (source == null)
                return 0;
            return (source as ListView.ListViewItemCollection).Count;
        }
        protected override void OnSearching(SearchEventArgs e)
        {
            base.OnSearching(e);
            if (!e.Handled)
            {
                listView.BeginUpdate();
                listView.ShowGroups = false;
                ForEachItem(item =>
                {
                    item.OrderIndex = item.OriginIndex;
                    item.BackColor = Color.Empty;
                });
                if (!string.IsNullOrEmpty(e.Keyword))
                {
                    Func<DataListItem, bool> matchTextDelegate;
                    Func<DataListItem, bool> matchSubTextDelegate;
                    var keyword = e.Keyword;
                    listView.ShowGroups = true;
                    if (SearchIgnoreCase)
                    {
                        keyword = keyword.ToUpper();
                        matchTextDelegate = item => item.Text.ToUpper().Contains(keyword);
                        matchSubTextDelegate = item =>
                        {
                            for (var i = 0; i < item.SubItems.Count; i++)
                            {
                                if (item.SubItems[i].Text.ToUpper().Contains(keyword))
                                    return true;
                            }
                            return false;
                        };
                    }
                    else
                    {
                        matchTextDelegate = item => item.Text.Contains(keyword);
                        matchSubTextDelegate = item =>
                        {
                            for (var i = 0; i < item.SubItems.Count; i++)
                            {
                                if (item.SubItems[i].Text.Contains(keyword))
                                    return true;
                            }
                            return false;
                        };
                    }

                    ForEachItem(item =>
                    {
                        if (matchTextDelegate(item) || matchSubTextDelegate(item))
                        {
                            item.OrderIndex = 1;
                            item.BackColor = Color.Pink;
                        }
                        else
                        {
                            item.OrderIndex = 9;
                            item.BackColor = Color.Empty;
                        }
                    });
                }
                listView.Sort();
                listView.EndUpdate();
            }
        }
        protected void ForEachItem(Action<DataListItem> action)
        {
            for (var i = 0; i < listView.Items.Count; i++)
                action((DataListItem)listView.Items[i]);
        }

        protected class DataListItem : ListViewItem
        {
            public DataListItem()
            {
                OrderIndex = 9;
            }
            /// <summary>
            /// 排序Idx
            /// </summary>
            public int OrderIndex { get; set; }
            public int OriginIndex { get; set; }
        }

        protected class DataColumnHeader : ColumnHeader
        {
            public string PropertyName { get; set; }
            private PropertyInfo _property;
            private bool _propertyFlag;
            public string GetValue(object obj)
            {
                if (obj != null)
                {
                    if (!_propertyFlag)
                    {
                        _property = obj.GetType().GetProperty(PropertyName, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
                        _propertyFlag = true;
                    }

                    if (_property != null)
                    {
                        var value = _property.GetValue(obj, null);
                        var text = Convert.ToString(value);
                        return text;
                    }
                }
                return string.Empty;
            }
        }

        private class ListViewSorter : IComparer
        {
            public int Compare(object x, object y)
            {
                var left = x as DataListItem;
                var right = y as DataListItem;
                if (left == null && right == null)
                    return 0;
                else if (left == null)
                    return -1;
                else if (right == null)
                    return 1;
                else
                {
                    if (left.OrderIndex != right.OrderIndex)
                        return Comparer<int>.Default.Compare(left.OrderIndex, right.OrderIndex);
                    return Comparer<int>.Default.Compare(left.OriginIndex, right.OriginIndex);
                }
            }
        }

    }
}

