using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Telemedicine.Forms.Keyboards
{
    public class NumberKeyboard : CgUserControl, IInputDialogKeyboard
    {
        public NumberKeyboard()
        {
            InitializeComponent();
            InitializeKeyboardComponents();
        }
        public event KeyboardInputEventHandler KeyboardInput;

        public bool UseDotButton
        {
            get
            {
                var button = panelLayout.GetControlFromPosition(0, 3);
                return button != null && button.Visible;
            }
            set
            {
                var button = panelLayout.GetControlFromPosition(0, 3);
                if (button != null)
                    button.Visible = value;
            }
        }

        private void NumberButton_Click(object sender, EventArgs e)
        {
            var handler = KeyboardInput;
            if (handler != null)
            {
                var number = (sender as Control).Tag as string;
                var args = new KeyboardInputEventArgs(number, KeyboardInputEventArgs.ModeDirect);
                handler(this, args);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var handler = KeyboardInput;
            if (handler != null)
            {
                var args = new KeyboardInputEventArgs("{BS}", KeyboardInputEventArgs.ModeKeyCode);
                handler(this, args);
            }
        }
        private Button CreateTextButton(string text)
        {
            return new Button()
            {
                Text = text,
                Dock = DockStyle.Fill,
                Tag = text,
            };
        }

        #region Designer
        private CgLayoutPanel panelLayout;
        private void InitializeComponent()
        {
            this.panelLayout = new CgLayoutPanel();
            this.SuspendLayout();
            // 
            // panelLayout
            // 
            this.panelLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLayout.Location = new System.Drawing.Point(0, 0);
            this.panelLayout.Name = "panelLayout";
            this.panelLayout.TabIndex = 0;
            // 
            // NumberKeyboard
            // 
            this.Controls.Add(this.panelLayout);
            this.Name = "NumberKeyboard";
            this.Size = new System.Drawing.Size(150, 150);
            this.ResumeLayout(false);

        }
        private void InitializeKeyboardComponents()
        {
            // 設定行列: 數字鍵盤 3x4
            panelLayout.ChangeLayout(3, 4);

            // 數字鍵盤
            var btnZero = CreateTextButton("0");
            btnZero.Click += NumberButton_Click;
            panelLayout.AddControlToPosition(btnZero, 1, 3);

            for (var i = 1; i <= 9; i++)
            {
                var btnNumber = CreateTextButton(i.ToString());
                btnNumber.Click += NumberButton_Click;

                var position = new TableLayoutPanelCellPosition(
                    ((i - 1) % panelLayout.ColumnCount),
                    2-((i - 1) / panelLayout.ColumnCount));
                panelLayout.AddControlToPosition(btnNumber, position);
            }

            // 功能鍵
            var btnDot = CreateTextButton(".");
            btnDot.Visible = false;
            btnDot.Click += NumberButton_Click;
            panelLayout.AddControlToPosition(btnDot, 0, 3);

            var btnDel = CreateTextButton("←");
            btnDel.Click += DeleteButton_Click;
            panelLayout.AddControlToPosition(btnDel, 2, 3);
        }



        #endregion
    }
}

