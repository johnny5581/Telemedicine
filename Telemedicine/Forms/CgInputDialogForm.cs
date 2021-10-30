using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Telemedicine.Forms
{
    public class CgInputDialogForm : CgBaseDialogForm, IInputDialog
    {
        private TextBox textInput;
        public CgInputDialogForm()
        {
        }


        [DefaultValue("")]
        public string InputText
        {
            get { return textInput.Text; }
            set { textInput.Text = value; }
        }
        [DefaultValue(CharacterCasing.Normal)]
        public CharacterCasing CharacterCasing
        {
            get { return textInput.CharacterCasing; }
            set { textInput.CharacterCasing = value; }
        }

        protected override Control GetMainComponent()
        {
            textInput = new TextBox();
            return textInput;
        }
        protected override int GetMainComponentHeight()
        {
            return textInput.Height + DefaultMargin.Vertical;
        }
        public void SetKeyboard(IInputDialogKeyboard keyboard)
        {
            var control = keyboard as Control;
            if (control == null)
                throw new InvalidCastException("keyboard is not control");
            panelLayout.SuspendLayout();
            var height = control.Height;
            control.Dock = DockStyle.Fill;
            panelLayout.Controls.Add(control);
            panelLayout.SetRow(control, 2);
            panelLayout.SetColumn(control, 1);
            keyboard.KeyboardInput += Keyboard_KeyboardInput;
            Height += height;
            panelLayout.ResumeLayout();
        }

        private void Keyboard_KeyboardInput(object sender, KeyboardInputEventArgs e)
        {
            if (e.IsCommand)
                textInput.Text = e.Invoke(textInput.Text);
            else 
            {
                textInput.Focus();
                SendKeys.Send(e.KeyCode);                
            }
        }

        public void SecretInput(char secretChar = '\0')
        {
            if (secretChar == char.MinValue)
                textInput.UseSystemPasswordChar = true;
            else
                textInput.PasswordChar = secretChar;
        }
    }
}

