using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Telemedicine.Forms
{
    public class CgInputDialogForm : CgBaseMessageDialogForm, IInputDialog
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
            if (e.Mode == KeyboardInputEventArgs.ModeCommand)
                textInput.Text = e.Invoke(textInput.Text, textInput.SelectionStart, textInput.SelectionLength);
            else if (e.Mode == KeyboardInputEventArgs.ModeDirect)
                textInput.SelectedText = e.Code;
            else if(e.Mode == KeyboardInputEventArgs.ModeKeyCode)
            {
                /**
                 * Windows 11: 基於UAC安全理由，需再App.Config加入以下設定
                 * <appSettings>
                 *   <add key="SendKeys" value="SendInput"/>
                 * </appSettings>
                 */
                textInput.Focus();
                SendKeys.Send(e.Code);
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

