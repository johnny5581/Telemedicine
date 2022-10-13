using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Telemedicine.Controllers;
using Telemedicine.Forms;

namespace Telemedicine.Practitioners
{
    public partial class PracCreateForm : DialogBase
    {
        private PractitionerController _ctrlPrac;
        public PracCreateForm()
        {
            InitializeComponent();
            _ctrlPrac = new PractitionerController(this);
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                var prac = new Practitioner();
                prac.Id = textId.Text.ToNull();
                prac.Identifier.Add(new Identifier(textIdSys.Text, textIdVal.Text));
                prac.Name.Add(new HumanName
                {
                    Text = textName.Text,
                    Family = textName.Text.Substring(0, 1),
                    Given = new List<string> { textName.Text.Substring(1) }
                });
                _ctrlPrac.Create(prac);
                MsgBoxHelper.Info("建立成功");
            });
        }
    }
}
