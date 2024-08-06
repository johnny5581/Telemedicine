using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telemedicine.Controllers;
using Telemedicine.Forms;

namespace Telemedicine.Orgs
{    
    public partial class OrgCreateForm : DialogBase
    {        
        public OrgCreateForm()
        {
            InitializeComponent();
        }
        public Controller<Organization> Controller { get; set; }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                var org = new Organization();
                org.Id = textId.Text.ToNull();
                var identifier = new Identifier(textIdSys.Text, textIdVal.Text);
                identifier.Type = new CodeableConcept("https://twcore.mohw.gov.tw/fhir/CodeSystem/v2-0203", "HOI");
                org.Identifier.Add(identifier);
                org.Name = textName.Text;
                org.AliasElement.Add(new FhirString(textAlias.Text));
                org.Address.Add(new Address { Country = textCountry.Text });
                Controller.Create(org);
                MsgBoxHelper.Info("建立成功");
            });
        }
    }
}
