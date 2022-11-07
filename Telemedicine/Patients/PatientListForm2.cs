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
            dgvData.AddTextColumn<Patient>(r => r.Telecom, "聯絡電話", formatter: TlcomForate);
            dgvData.AddTextColumn<Patient>(r => r.Address, "聯絡地址", formatter: AdrForate);
            dgvData.AddTextColumn<Patient>(r => r.Contact, "緊急聯絡人", formatter: ConForate, arguments: new string[] { "緊急聯絡人" });
            dgvData.AddTextColumn<Patient>(r => r.Contact, "關係", formatter: ConForate, arguments: new string[] { "關係" });
            dgvData.AddTextColumn<Patient>(r => r.Contact, "聯絡人連絡電話", formatter: ConForate, arguments: new string[] { "聯絡人連絡電話" });
            dgvData.AddTextColumn<Patient>(r => r.Telecom, "電子信箱", formatter: TlcomForate, arguments: new string[] { "電子信箱" });
        }


        public void ConForate(object sender, CgDataGridPanel.FormattingCellEventArgs e)
        {
            var names = e.Value as IEnumerable<Patient.ContactComponent>;
            if (names != null)
            {
                string system = Convert.ToString(e.Arguments.ElementAtOrDefault(0));
                if (system == "緊急聯絡人")
                {
                    string x = names.FirstOrDefault()?.Name?.Text;
                    e.Value = x;
                }
                else if (system == "關係")
                {
                    string ct = names.FirstOrDefault()?.Relationship.FirstOrDefault()?.Text;
                    e.Value = ct;
                }
                else if (system == "聯絡人連絡電話")
                {
                    string ctp = names.FirstOrDefault()?.Telecom.FirstOrDefault()?.Value;
                    e.Value = ctp;
                }
            }    
        }
        public void AdrForate(object sender, CgDataGridPanel.FormattingCellEventArgs e)
        {
            var names = e.Value as IEnumerable<Address>;
            if (names != null)
            {
                var name = names.FirstOrDefault();
                e.Value = name?.Text;
            }
        }
        public void TlcomForate(object sender, CgDataGridPanel.FormattingCellEventArgs e)
        {
            var names = e.Value as IEnumerable<ContactPoint>;
            if (names != null)
            {
                string system = Convert.ToString(e.Arguments.ElementAtOrDefault(0));
                if (system == "電子信箱")
                {
                    var x = names.FirstOrDefault(y => y.System== ContactPoint.ContactPointSystem.Email);
                    var z = x?.ValueElement?.Value;
                    e.Value = z;
                }
                else
                {
                    var name = names.FirstOrDefault();
                    e.Value = name?.Value;
                }
            }
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
