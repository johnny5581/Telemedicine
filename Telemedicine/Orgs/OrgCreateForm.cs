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
                org.Identifier.Add(new Identifier(textIdSys.Text, textIdVal.Text));
                org.Name = textName.Text;
                org.AliasElement.Add(new FhirString(textAlias.Text));
                org.Address.Add(new Address { Country = textCountry.Text });

                Controller.Create(org);
                MsgBoxHelper.Info("建立成功");
            });
        }
    }
}
