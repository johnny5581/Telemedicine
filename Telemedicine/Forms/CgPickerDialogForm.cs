using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Telemedicine.Forms
{
    public class CgPickerDialogForm : CgBaseDialogForm, IPickerDialog
    {
        private CgFlowLayoutPanel panelFlowLayout;
        private object[] _selectedItems;
        public object[] SelectedItems
        {
            get { return _selectedItems ?? new object[0]; }
        }
        public bool MultiSelection { get; set; }
        public Delegate Selector { get; set; }

        public void AddItem(PickerDialog.PickerItem item)
        {
            var creation = GetControlCreation();
            var control = creation();
            control.Text = item.Text;
            control.Tag = item;
            panelFlowLayout.Controls.Add(control);
            
            if(Selector != null)
            {
                var @checked = (bool)Selector.DynamicInvoke(item.Item);
                if (@checked)
                {
                    var property = GetCheckedProperty();
                    property.SetValue(control, true, null);
                }
            }
            
            panelFlowLayout.ResizeAllChilds();
        }

        public void AddItems(IEnumerable<PickerDialog.PickerItem> items)
        {
            var creation = GetControlCreation();

            foreach (var item in items)
            {
                var control = creation();
                control.Text = item.Text;
                control.Tag = item;
                panelFlowLayout.Controls.Add(control);

                if (Selector != null)
                {
                    var @checked = (bool)Selector.DynamicInvoke(item.Item);
                    if (@checked)
                    {
                        var property = GetCheckedProperty();
                        property.SetValue(control, true, null);
                    }
                }
            }
            panelFlowLayout.ResizeAllChilds();
        }

        public void ClearItems()
        {
            panelFlowLayout.Controls.Clear();
        }

        private Func<Control> GetControlCreation()
        {
            return MultiSelection
                ? new Func<Control>(() => new CheckBox())
                : new Func<Control>(() => new RadioButton());
        }
        private PropertyInfo GetCheckedProperty()
        {
            return MultiSelection 
                ? typeof(CheckBox).GetProperty("Checked") 
                : typeof(RadioButton).GetProperty("Checked");
        }

        protected override Control GetMainComponent()
        {
            panelFlowLayout = new CgFlowLayoutPanel();
            panelFlowLayout.FlowDirection = FlowDirection.TopDown;
            panelFlowLayout.AutoScroll = true;
            panelFlowLayout.AutoResizeChild = true;
            panelFlowLayout.BorderStyle = BorderStyle.Fixed3D;
            panelFlowLayout.BackColor = Color.White;
            return panelFlowLayout;
        }
        protected override int GetMainComponentHeight()
        {
            return WinMonitor.GetPrimaryScaled(150);
        }
        protected override void OnPositiveClicking(CancelEventArgs e)
        {
            base.OnPositiveClicking(e);
            var property = GetCheckedProperty();
            var selectedItems = new List<object>();
            foreach (Control control in panelFlowLayout.Controls)
            {
                var @checked = (bool)property.GetValue(control, null);
                if (@checked)
                {
                    var item = control.Tag as PickerDialog.PickerItem;
                    selectedItems.Add(item.Value);
                }
            }

            if (selectedItems.Count == 0)
            {
                MsgBoxHelper.Warning("No data selected", Text);
                e.Cancel = true;
                return;
            }
            _selectedItems = selectedItems.ToArray();
        }
    }
}

