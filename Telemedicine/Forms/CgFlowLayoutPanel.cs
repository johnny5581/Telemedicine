using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Telemedicine.Forms
{
    public class CgFlowLayoutPanel : FlowLayoutPanel
    {
        private bool _autoResizeChildFlag;
        private Padding _autoMarginSize;
        private bool _autoMarginFlag;
        public CgFlowLayoutPanel()
        {
            DoubleBuffered = true;
            AutoScroll = true;
            WrapContents = false;
        }
        public event ResizingChildEventHandler ResizingChild;
        [DefaultValue(false)]
        public bool AutoResizeChild
        {
            get { return _autoResizeChildFlag; }
            set
            {
                _autoResizeChildFlag = value;
                AutoResizeChildControls();
            }
        }
        [DefaultValue(typeof(Padding), "0")]
        public Padding AutoMarginSize
        {
            get { return _autoMarginSize; }
            set
            {
                _autoMarginSize = value;
                AutoResizeChildMargin();
            }
        }
        [DefaultValue(false)]
        public bool AutoMargin
        {
            get { return _autoMarginFlag; }
            set
            {
                _autoMarginFlag = value;
                AutoResizeChildMargin();
            }
        }
        [DefaultValue(true)]
        public new bool AutoScroll
        {
            get { return base.AutoScroll; }
            set
            {
                base.AutoScroll = value;
                if (AutoResizeChild)
                    ResizeAllChilds();
            }
        }
        public void ResizeAllChilds()
        {
            ResizeChilds();
        }
        protected virtual void ResizeChilds(Control control = null)
        {
            var args = new ResizingChildEventArgs();
            switch (FlowDirection)
            {
                case FlowDirection.TopDown:
                case FlowDirection.BottomUp:
                    var offsetWidth = AutoScroll ? (SystemInformation.VerticalScrollBarWidth * 2) : 0;
                    args.PreferredWidth = Width - Padding.Horizontal - offsetWidth;
                    args.Orientation = ScrollBars.Horizontal;
                    break;
                case FlowDirection.LeftToRight:
                case FlowDirection.RightToLeft:
                    var offsetHeight = AutoScroll ? (SystemInformation.HorizontalScrollBarHeight * 2) : 0;
                    args.PreferredHeight = Height - Padding.Vertical - offsetHeight;
                    args.Orientation = ScrollBars.Vertical;
                    break;
            }
            OnResizingChild(args);
            if (control != null)
                args.SetControlSize(control);
            else
                foreach (Control ctrl in Controls)
                    args.SetControlSize(ctrl);
        }
        protected virtual void OnResizingChild(ResizingChildEventArgs e)
        {
            var handler = ResizingChild;
            if (handler != null)
                handler(this, e);
        }

        private void AutoResizeChildControls()
        {
            if (_autoResizeChildFlag)
                ResizeChilds();
        }
        private void AutoResizeChildControl(Control control)
        {
            if (_autoResizeChildFlag)
                ResizeChilds(control);
        }
        private void AutoResizeChildMargin()
        {
            if (_autoMarginFlag)
            {
                foreach (Control ctrl in Controls)
                    ctrl.Margin = _autoMarginSize;
            }
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            AutoResizeChildControls();
        }
        public delegate void ResizingChildEventHandler(object sender, ResizingChildEventArgs e);
        public class ResizingChildEventArgs : EventArgs
        {
            public ResizingChildEventArgs()
            {
                PreferredWidth = -1;
                PreferredHeight = -1;
                Orientation = ScrollBars.None;
                UseMargin = true;
            }

            public int PreferredWidth { get; set; }
            public int PreferredHeight { get; set; }
            public ScrollBars Orientation { get; set; }
            public Func<Control, int, int, Size> ControlSizeDelegate { get; set; }
            public bool UseMargin { get; set; }

            public void SetControlSize(Control control)
            {
                int width = PreferredWidth, height = PreferredHeight;
                if (ControlSizeDelegate != null)
                {
                    var size = ControlSizeDelegate(control, width, height);
                    width = size.Width;
                    height = size.Height;
                }
                else if (UseMargin)
                {
                    width -= control.Margin.Horizontal;
                    height -= control.Margin.Vertical;
                }

                switch (Orientation)
                {
                    case ScrollBars.Both:
                        control.Size = new Size(width, height);
                        break;
                    case ScrollBars.Horizontal:
                        control.Width = width;
                        break;
                    case ScrollBars.Vertical:
                        control.Height = height;
                        break;
                }
            }
        }
    }
}

