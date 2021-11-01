using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telemedicine
{
    public partial class TransactionMonitorDialog : DialogBase
    {
        public TransactionMonitorDialog()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            var action = new MethodInvoker(
                ()=>ClearControls(textReqHeader, textReqBody, textRespHeader, textRespBody));
            if (InvokeRequired)
                BeginInvoke(action);
            else
                action();
        }

        public void SetRequest(HttpRequestMessage message, byte[] raw)
        {
            var action = new Action<string, string>((m, b) =>
            {
                textReqHeader.Text = m;
                if (raw != null)
                    textReqBody.Text = b;
            });
            var msg = message.ToString();
            var body = raw != null
                ? Encoding.UTF8.GetString(raw)
                : null;

            if (InvokeRequired)
                BeginInvoke(action, msg, body);
            else
                action(msg, body);
        }
        public void SetResponse(HttpResponseMessage message, byte[] raw)
        {
            var action = new Action<string, string>((m, b) =>
            {
                textRespHeader.Text = m;
                if (raw != null)
                    textRespBody.Text = b;
            });
            var msg = message.ToString();
            var body = raw != null
                ? Encoding.UTF8.GetString(raw)
                : null;

            if (InvokeRequired)
                BeginInvoke(action, msg, body);
            else
                action(msg, body);
        }

        private void menuClose_Click(object sender, EventArgs e)
        {
            AppRuntime.Current.SetData("Monitor", null);
            Close();
        }

        public override void Show(Form mainForm)
        {
            //base.Show(mainForm);
            Show();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = true;
            base.OnFormClosing(e);
            Hide();
        }
    }
}
