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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

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
                () => ClearControls(textReqHeader, textReqBody, textRespHeader, textRespBody));
            if (InvokeRequired)
                BeginInvoke(action);
            else
                action();
        }

        public void AppendTransaction(HttpTransaction transaction)
        {
            var action = new Action<HttpTransaction>(t =>
            {
                var idx = listBox1.Items.Add(t);
                listBox1.SelectedIndex = idx;
            });

            if (InvokeRequired)
                BeginInvoke(action, transaction);
            else
                action(transaction);
        }

        public void SetRequest(HttpRequestMessage message, byte[] raw)
        {
            var action = new Action<string, string>((m, b) =>
            {
                textReqHeader.Text = m;
                if (raw != null)
                    textReqBody.Text = b;
            });
            var msg = message?.ToString();
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
            var msg = message?.ToString();
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            HttpTransaction trans = null;
            if (listBox1.SelectedItem != null)
                trans = listBox1.SelectedItem as HttpTransaction;
            SetRequest(trans?.Request, trans?.RequestBody);
            SetResponse(trans?.Response, trans?.ResponseBody);
        }

        public class HttpTransaction
        {
            public HttpTransaction()
            {
                Time = DateTime.Now.ToString("HH:mm:ss.fff");
            }
            public string Time { get; }
            public HttpRequestMessage Request { get; set; }
            public byte[] RequestBody { get; set; }
            public HttpResponseMessage Response { get; set; }
            public byte[] ResponseBody { get; set; }
        }
    }
}
