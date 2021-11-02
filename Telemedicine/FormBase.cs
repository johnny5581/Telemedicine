using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telemedicine.Forms;

namespace Telemedicine
{
    public static class FormHelper
    {
        public static void BindVitalSigns(this ICgComboBox comboBox, string notSpecifyText = null)
        {
            comboBox.Items.Clear();
            int index = -1;
            if (notSpecifyText != null)
                index = comboBox.AddTextItem(notSpecifyText, null);
            comboBox.AddItemRange(VitalSign.VitalSigns, r => r.ToString(false), r => r.Code);
            comboBox.SelectedIndex = index == -1 ? VitalSign.VitalSigns.Length - 1 : index;
        }

        public static void BindOrganizations(this ICgComboBox comboBox, string notSpecifyText = null)
        {
            comboBox.Items.Clear();
            int index = -1;
            if (notSpecifyText != null)
                index = comboBox.AddTextItem(notSpecifyText, null);
            
            comboBox.AddTextItem("Organization/MITW.ForIdentifier");
            comboBox.AddTextItem("Organization/MITW.ForContact");
            comboBox.AddTextItem("Organization/MITW.ForPHR");
            comboBox.AddTextItem("Organization/MITW.ForEMS");

            comboBox.SelectedIndex = index == -1 ? comboBox.Items.Count - 1 : index;
        }



        public static void ClearControls(params Control[] controls)
        {
            foreach (var c in controls)
            {
                var t = c.GetType();
                if (typeof(ComboBox).IsAssignableFrom(t))
                {
                    ((ComboBox)c).SelectedIndex = -1;
                }
                else if (typeof(DateTimePicker).IsAssignableFrom(t))
                {
                    ((DateTimePicker)c).Value = DateTime.Now;
                }
                else if (typeof(ComboBox).IsAssignableFrom(t))
                    ((ComboBox)c).SelectedIndex = 0;
                else
                    c.Text = null;
            }
        }
        public static bool TryExecute(string name, Action action, Action<Exception> unexcepted = null)
        {
            try
            {
                action();
                return true;
            }
            catch (Exception ex)
            {
                if (unexcepted != null)
                    unexcepted(ex);
                else
                    UnexceptedHandle(name, ex);
            }
            return false;
        }
        public static bool TryExecute<T>(string name, Func<T> action, out T result, Action<Exception> unexcepted = null)
        {
            try
            {
                result = action();
                return true;
            }
            catch (Exception ex)
            {
                if (unexcepted != null)
                    unexcepted(ex);
                else
                    UnexceptedHandle(name, ex);
            }
            result = default(T);
            return false;
        }
        public static void UnexceptedHandle(string name, Exception exception)
        {
            MsgBoxHelper.Error(exception.Message, name);
        }
    }
    public class FormBase : CgForm, IInteractive
    {
        protected void ClearControls(params Control[] controls)
        {
            FormHelper.ClearControls(controls);
        }


        public virtual void Show(Form mainForm)
        {
            MdiParent = mainForm;
            WindowState = FormWindowState.Maximized;
            Show();
        }

        protected T GetSelectedItem<T>(CgDataGridPanel panel, bool throwOnError = true)
        {
            var item = (T)panel.GetSelectedItem();
            if (item == null && throwOnError)
                throw new Exception("沒有選擇任何資料");
            return item;
        }

        #region Executing
        protected void Execute(Action action)
        {
            FormHelper.TryExecute(Text, action);
        }
        protected void Execute(Action action, Action<Exception> errorHandler)
        {
            FormHelper.TryExecute(Text, action, unexcepted: errorHandler);
        }
        protected T Execute<T>(Func<T> action, Action<Exception> errorHandler)
        {
            T result;
            FormHelper.TryExecute(Text, action, out result, errorHandler);
            return result;
        }
        protected void Execute(EventHandler handler)
        {
            FormHelper.TryExecute(Text, () =>
            {
                if (handler != null)
                    handler(this, EventArgs.Empty);
            });
        }
        #endregion

        #region Interactive
        T IInteractive.SingleSelection<T>(IEnumerable<T> options, Func<T, string> textResolver)
        {
            if (typeof(T) == typeof(Patient))
            {
                var d = new Patients.PatientPickerDialog();
                d.LoadPatients((IEnumerable<Patient>)options);
                if (d.ShowDialog() == DialogResult.OK)
                    return (T)(object)d.SelectedPatient;
                else
                    return default(T);
            }
            return PickerDialog.GetSelection(this, "please select one", options, textResolver);
        }
        #endregion
    }


    public class DialogBase : FormBase
    {
        public DialogBase()
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
        }
        public override void Show(Form mainForm)
        {
            //base.Show(mainForm);

            ShowDialog();
        }
    }

    public class UserControlBase : CgUserControl, IInteractive
    {
        protected void ClearControls(params Control[] controls)
        {
            FormHelper.ClearControls(controls);
        }

        #region Executing
        protected void Execute(Action action)
        {
            FormHelper.TryExecute(FindForm()?.Text ?? Text, action);
        }
        protected void Execute(Action action, Action<Exception> errorHandler)
        {
            FormHelper.TryExecute(FindForm()?.Text ?? Text, action, unexcepted: errorHandler);
        }
        protected T Execute<T>(Func<T> action, Action<Exception> errorHandler)
        {
            T result;
            FormHelper.TryExecute(FindForm()?.Text ?? Text, action, out result, errorHandler);
            return result;
        }
        protected void Execute(EventHandler handler)
        {
            FormHelper.TryExecute(FindForm()?.Text ?? Text, () =>
            {
                if (handler != null)
                    handler(this, EventArgs.Empty);
            });
        }
        #endregion

        #region Interactive
        T IInteractive.SingleSelection<T>(IEnumerable<T> options, Func<T, string> textResolver)
        {
            if (typeof(T) == typeof(Patient))
            {
                var d = new Patients.PatientPickerDialog();
                d.LoadPatients((IEnumerable<Patient>)options);
                if (d.ShowDialog() == DialogResult.OK)
                    return (T)(object)d.SelectedPatient;
                else
                    return default(T);
            }
            return PickerDialog.GetSelection(this, "please select one", options, textResolver);
        }
        #endregion
    }
}
