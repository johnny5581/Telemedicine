using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telemedicine.Forms;

namespace Telemedicine
{
    public class FormBase : CgForm
    {
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
    }
}
