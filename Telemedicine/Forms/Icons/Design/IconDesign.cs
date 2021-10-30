using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Telemedicine.Forms.Icons.Design
{
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.None)]
    public class IconEditor : UITypeEditor
    {
        private IWindowsFormsEditorService _edSvc;
        private object _selectedItem;
        private bool _clearClicked;
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            if (context != null && context.Instance != null)
                return UITypeEditorEditStyle.DropDown;
            return base.GetEditStyle(context);
        }
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (context != null && context.Instance != null && provider != null)
            {
                _edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
                if (_edSvc != null)
                {
                    var control = CreateControl(value);
                    _edSvc.DropDownControl(control);
                    value = _clearClicked ? null : GetValue(_selectedItem, value);
                }
            }
            return value;
        }
        private static object GetValue(object item, object _defaultValue)
        {
            if (item == null)
                return _defaultValue;
            //var packId = IconInfoAttribute.GetPackId(item.GetType());
            var packId = item.GetType().Name;
            return string.Format("{0}.{1}", packId, item);
        }

        private Control CreateControl(object value)
        {
            var panel = new Panel { Height = 200 };
            var tab = new TabControl { Height = 200, Dock = DockStyle.Fill };
            var listViews = new List<ListView>();
            foreach (var pack in IconPack.Packs)
            {
                var page = new TabPage();
                var info = pack.Info;
                var thumbnails = pack.Thumbnails;

                page.Text = info.Id;

                var list = new ListView
                {
                    Dock = DockStyle.Fill,
                    MultiSelect = false,
                    View = View.Details,
                    HeaderStyle = ColumnHeaderStyle.None,
                    FullRowSelect = true,

                };
                listViews.Add(list);
                list.Columns.Add("name", -2);
                list.MouseDoubleClick += List_MouseDoubleClick;
                var names = Enum.GetNames(info.IconEnumType);
                var values = Enum.GetValues(info.IconEnumType);
                var items = new ListViewItem[names.Length];
                for (var i = 0; i < names.Length; i++)
                {
                    items[i] = new ListViewItem(names[i]);
                    items[i].ImageKey = names[i].ToUpper();
                    items[i].Tag = values.GetValue(i);
                }
                list.Items.AddRange(items);
                list.Tag = items;
                list.SmallImageList = thumbnails[0];
                var searchPanel = new Panel
                {
                    Height = 28,
                    BorderStyle = BorderStyle.FixedSingle,
                    Dock = DockStyle.Top,
                    Padding = new Padding(1),
                };
                var searchText = new TextBox
                {
                    Dock = DockStyle.Fill,
                    BorderStyle = BorderStyle.None,
                    Tag = list
                };
                var closeButton = new Button
                {
                    Text = "Clear",
                    Dock = DockStyle.Right,
                };

                searchText.TextChanged += SearchText_TextChanged;
                closeButton.Click += CloseButton_Click;
                searchPanel.Controls.Add(searchText);
                searchPanel.Controls.Add(closeButton);


                page.Controls.Add(list);
                page.Controls.Add(searchPanel);

                tab.TabPages.Add(page);
            }
            panel.Controls.Add(tab);
            return panel;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            _clearClicked = true;
            _edSvc.CloseDropDown();
        }

        private void SearchText_TextChanged(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            var text = textBox.Text.ToUpper();
            var list = textBox.Tag as ListView;
            var items = list.Tag as ListViewItem[];
            list.Items.Clear();
            if (!string.IsNullOrEmpty(text))
                items = items.Where(r => r.Text.ToUpper().Contains(text)).ToArray();
            list.Items.AddRange(items);
        }

        private void List_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var listView = sender as ListView;
            var items = listView.SelectedItems;
            if (items.Count > 0)
                _selectedItem = items[0].Tag;
            _edSvc.CloseDropDown();
        }
    }

    public class IconConverter : TypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value == null)
            {
                return null;
            }
            else if (value.GetType() == typeof(string))
            {
                var id = (string)value;
                if (string.IsNullOrEmpty(id))
                    return null;
                try
                {
                    var match = Regex.Match(id, @"([A-Za-z0-9_]+)\.([A-Za-z0-9_]+)");
                    if (match.Success)
                    {
                        var packId = match.Groups[1].Value;
                        var iconName = match.Groups[2].Value;
                        var pack = IconPack.GetIconPack(packId);
                        if (pack != null)
                        {
                            var name = Enum.GetNames(pack.Info.IconEnumType).FirstOrDefault(r => string.Equals(r, iconName, StringComparison.OrdinalIgnoreCase));
                            if (name != null)
                                return pack.Info.Id + "." + name;
                        }
                    }
                    else
                    {
                        foreach (var pack in IconPack.Packs)
                        {
                            var name = Enum.GetNames(pack.Info.IconEnumType).FirstOrDefault(r => string.Equals(r, id, StringComparison.OrdinalIgnoreCase));
                            if (name != null)
                                return pack.Info.Id + "." + name;
                        }
                    }
                }
                catch
                {
                    throw new InvalidCastException("can not convert to Icon object");
                }
            }
            else if (value.GetType().GetCustomAttributes(typeof(IconInfoAttribute), false).Length > 0)
            {
                return value;
            }
            return base.ConvertFrom(context, culture, value);
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }
    }
}

