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
using Telemedicine.Orgs;

namespace Telemedicine.Practitioners
{
    [DomainControl(typeof(Practitioner))]
    public partial class PracControl : DomainControl
    {
        public PracControl()
        {
            InitializeComponent();
            
        }

        public override Type ListFormType => typeof(PracListForm);

        [DefaultValue("")]
        public string PracName
        {
            get { return textName.Text; }
            set { textName.Text = value; }
        }

        protected override void ActionItemPicked(object item)
        {
            base.ActionItemPicked(item);
            PracName = (item as Practitioner).Name.FirstOrDefault()?.Text;
        }        
    }
}
