using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Telemedicine.Forms
{
    public interface ICgTextBox
    {        
        string WatermarkText { get; set; }
        string Text { get; set; }        
        CharacterCasing CharacterCasing { get; set; }
        HorizontalAlignment TextAlign { get; set; }
        bool ReadOnly { get; set; }
        Color ForeColor { get; set; }
        Color BackColor { get; set; }
        event EventHandler TextChanged;
        event KeyEventHandler KeyDown;
        event KeyPressEventHandler KeyPress;
    }

    public class CgTextBox : TextBox, ICgTextBox
    {
        private string _watermark;
        public CgTextBox()
        {
        }
        [DefaultValue(null)]
        public string WatermarkText
        {
            get { return _watermark; }
            set
            {
                _watermark = value;
                UpdateWatermark();
            }
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            UpdateWatermark();
        }
        private void UpdateWatermark()
        {
            if (IsHandleCreated)
                Native.User32.SendMessage(Handle, 0x1501, 1, _watermark ?? "");
        }
    }
}

