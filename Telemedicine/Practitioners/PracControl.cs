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

        public static void PracFormatter(object sender, CgDataGridPanel.FormattingCellEventArgs e)
        {
            var resRef = e.Value as ResourceReference;
            if (resRef != null)
            {
                if (e.Arguments.ElementAtOrDefault(0) as string == "Y")
                {
                    var prac = ControllerBase.Get<Practitioner>().Read(resRef.Reference);
                    var rType = e.Arguments.ElementAtOrDefault(1) as string;
                    switch (rType)
                    {
                        case "0":
                            e.Value = GetHumanName(prac.Name);
                            break;
                        case "1":
                            e.Value = $"{GetHumanName(prac.Name)} ({GetIdentifier(prac.Identifier, SystemId)})";
                            break;
                    }
                }
                else
                    e.Value = resRef.Reference;
            }
        }
    }
}
