using Hl7.Fhir.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Telemedicine.Controllers;
using Telemedicine.Forms;

namespace Telemedicine.Patients
{
    [DomainControl(typeof(Patient))]
    public partial class PatientListForm2 : ListForm
    {
        public PatientListForm2()
        {
            InitializeComponent();
            comboOrg.BindOrganizations("全部");
            IsEditable = true;
        }
        public Controller<Patient> Controller { get; set; }
        
        protected override void SetupDataGridPanel(CgDataGridPanel dgvData)
        {
            base.SetupDataGridPanel(dgvData);
            dgvData.AddTextColumn<Patient>(r => r.Name, "姓名", formatter: HumanNamesFormatter);
            dgvData.AddTextColumn<Patient>(r => r.Identifier, "身分證", formatter: IdentifierFormatter, arguments: new string[] { PatientControl.SystemIdNo });
            dgvData.AddTextColumn<Patient>(r => r.Identifier, "病歷號", formatter: IdentifierFormatter, arguments: new string[] { PatientControl.SystemChtNo });
            dgvData.AddTextColumn<Patient>(r => r.Gender, "性別");
            dgvData.AddTextColumn<Patient>(r => r.BirthDate, "生日");
        }
        protected override IEnumerable GetSearchDomainResult(List<string> criterias)
        {
            AddCriteria(criterias, "identifier", textIdentifier.Text);
            AddCriteria(criterias, "name", textName.Text);
            AddCriteria(criterias, "organization", comboOrg.SelectedValue as string);            
            return Controller.Search(criterias);
        }
        protected override bool ActionDelete(object item)
        {
            if(MsgBoxHelper.YesNo("是否要刪除 #" + DomainControl.GetResourceId(item)))
            {
                Controller.Delete(item as Patient);
                return true;
            }
            return base.ActionDelete(item);
        }
        protected override bool ActionEdit(object item)
        {
            var pat = item as Patient;
            using (var d = new CreatePatientForm2())
            {
                d.SetSource(pat);
                if(d.ShowDialog() == DialogResult.OK)
                {
                    return true;
                }
            }
            return base.ActionEdit(item);
        }
    }
}
