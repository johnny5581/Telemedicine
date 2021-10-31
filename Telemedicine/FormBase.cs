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
    public class FormBase : CgForm, IInteractive
    {
        protected void ClearControls(params Control[] controls)
        {
            foreach(var c in controls)
            {
                var t = c.GetType();
                if (typeof(ComboBox).IsAssignableFrom(t))
                {
                    ((ComboBox)c).SelectedIndex = -1;
                }
                else
                    c.Text = null;
            }
        }

        
        public virtual void Show(Form mainForm)
        {
            MdiParent = mainForm;
            WindowState = FormWindowState.Maximized;
            Show();
        }

        #region Executing
        protected void Execute(Action action)
        {
            TryExecute(action);
        }
        protected void Execute(Action action, Action<Exception> errorHandler)
        {
            TryExecute(action, unexcepted: errorHandler);
        }
        protected T Execute<T>(Func<T> action, Action<Exception> errorHandler)
        {
            T result;
            TryExecute(action, out result, errorHandler);
            return result;
        }
        protected void Execute(EventHandler handler)
        {
            TryExecute(() =>
            {
                if (handler != null)
                    handler(this, EventArgs.Empty);
            });
        }

        protected bool TryExecute(Action action, Action<Exception> unexcepted = null)
        {
            try
            {
                action();
                return true;
            }
            catch (Exception ex)
            {
                (unexcepted ?? UnexceptedHandle).Invoke(ex);
            }
            return false;
        }
        protected bool TryExecute<T>(Func<T> action, out T result, Action<Exception> unexcepted = null)
        {
            try
            {
                result = action();
                return true;
            }
            catch (Exception ex)
            {
                (unexcepted ?? UnexceptedHandle).Invoke(ex);
            }
            result = default(T);
            return false;
        }
        private void UnexceptedHandle(Exception exception)
        {
            MsgBoxHelper.Error(exception.Message, Text);
        }



        #endregion

        #region Interactive
        T IInteractive.SingleSelection<T>(IEnumerable<T> options, Func<T, string> textResolver)
        {
            if(typeof(T) == typeof(Patient))
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
}
