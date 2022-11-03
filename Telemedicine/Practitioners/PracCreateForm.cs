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
    [DomainControl(typeof(Practitioner))]
    public partial class PracCreateForm : DialogBase
    {
        
        public PracCreateForm()
        {
            InitializeComponent();
            DomainControl.Setup(this);
        }

        public Controller<Practitioner> Controller { get; set; }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                var prac = new Practitioner();
                prac.Id = textId.Text.ToNull();                
                prac.Identifier.Add(new Identifier(textIdSys.Text, textIdVal.Text));                
                prac.Name.Add(textName.GetHumanName());
                Controller.Create(prac);
                MsgBoxHelper.Info("建立成功");
            });
        }
    }
}
