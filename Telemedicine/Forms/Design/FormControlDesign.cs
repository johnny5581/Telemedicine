using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Telemedicine.Forms.Design
{
    public class FormControlEditor : UITypeEditor
    {
        private IWindowsFormsEditorService _editorService;
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            //return base.EditValue(context, provider, value);

            _editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if (_editorService != null)
            {
                var instance = (Control)context.Instance;
                if (instance != null)
                {
                    //System.Diagnostics.Debugger.Break();
                    var cointainer = instance.Container;
                    if (cointainer != null)
                    {
                        var controls = cointainer.Components.OfType<Control>().Where(r => !string.IsNullOrEmpty(r.Name)).OrderBy(r => r.Name).ToArray();
                        if (controls.Length > 0)
                        {
                            var lb = new ListBox();
                            lb.SelectionMode = SelectionMode.One;
                            lb.SelectedValueChanged += DropDownListBox_SelectedValueChanged;
                            lb.DisplayMember = "Name";
                            foreach (var control in controls)
                            {
                                var index = lb.Items.Add(control);
                                if (control.Equals(value))
                                    lb.SelectedIndex = index;
                            }
                            _editorService.DropDownControl(lb);
                            if (lb.SelectedItem != null)
                                return lb.SelectedItem;
                        }
                    }
                }
            }
            return value;
        }

        private void DropDownListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            _editorService.CloseDropDown();
        }
    }
}

