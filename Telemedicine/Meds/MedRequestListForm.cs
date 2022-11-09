using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telemedicine.Controllers;
using Telemedicine.Forms;
using Telemedicine.Patients;

namespace Telemedicine.Meds
{
    [DomainControl(typeof(MedicationRequest))]
    public partial class MedRequestListForm : ListForm
    {
        public MedRequestListForm()
        {
            InitializeComponent();

            comboPatOrg.BindOrganizations("全部");
            comboStatus.Bind<MedicationRequest.medicationrequestStatus>("全部");
        }

        public Controller<MedicationRequest> Controller { get; set; }

        protected override void SetupDataGridPanel(CgDataGridPanel dgvData)
        {
            base.SetupDataGridPanel(dgvData);
            dgvData.AddTextColumn<ViewModel>(r => r.Status);
            dgvData.AddTextColumn<ViewModel>(r => r.Intent);
            dgvData.AddTextColumn<ViewModel>(r => r.Medication);
            dgvData.AddTextColumn<ViewModel>(r => r.Subject);
            dgvData.AddTextColumn<ViewModel>(r => r.AuthoredOn);
            dgvData.AddTextColumn<ViewModel>(r => r.DosageInstruction);
            dgvData.AddTextColumn<ViewModel>(r => r.DispenseRequest);
        }

        private static void MedDispenseFormatter(object sender, CgDataGridPanel.FormattingCellEventArgs e)
        {
            var dispense = e.Value as MedicationRequest.DispenseRequestComponent;
            if (dispense != null)
            {
                e.Value = $"{dispense.Quantity?.Value}{dispense.Quantity?.Unit}, {dispense.ExpectedSupplyDuration?.Value}{dispense.ExpectedSupplyDuration?.Unit}";
            }
        }

        public static void MedDosageFormatter(object sender, CgDataGridPanel.FormattingCellEventArgs e)
        {
            var dosages = e.Value as List<Dosage>;
            if (dosages != null)
            {
                e.Value = dosages.ToString(",", r => GetInstruction(r));
            }
        }

        public static string GetInstruction(Dosage dosage)
        {
            var timing = dosage.Timing.Code.Text ?? dosage.Timing.Code.Coding.ToString("+", r => r.Display ?? r.Code);
            var routes = dosage.Route.Text ?? dosage.Route.Coding.ToString("+", r => r.Display ?? r.Code);
            if (dosage.Text.IsNotNullOrEmpty())
                return $"{timing}, {routes} ({dosage.Text})";
            return $"{timing}, {routes}";
        }



        public static void MedFormatter(object sender, CgDataGridPanel.FormattingCellEventArgs e)
        {
            var dataType = e.Value as DataType;
            if (dataType != null)
                e.Value = MedControl.GetMedText(dataType);
        }

        protected override IEnumerable GetSearchDomainResult(List<string> criterias)
        {
            AddCriteria(criterias, "subject", textSubject.Text);
            AddCriteria(criterias, "subject.identifier", textPatIdentifier.Text);
            AddCriteria(criterias, "status", Convert.ToString(comboStatus.SelectedValue).StrToLower());
            AddCriteria(criterias, "code", textMedId.Text);
            AddCriteria(criterias, "subject.organization", comboPatOrg.SelectedValue as string);

            return Controller.Search(criterias);
        }
        protected override Tuple<Type, IEnumerable> GetSearchResult(List<string> criterias)
        {
            var list = GetSearchDomainResult(criterias).OfType<MedicationRequest>();
            var res = new Dictionary<string, object>();
            var dataList = list.Select(r => new ViewModel(r, res)).ToList();
            return Tuple.Create<Type, IEnumerable>(typeof(ViewModel), dataList);
        }
        protected override bool ActionDelete(object item)
        {
            if (MsgBoxHelper.YesNo("是否要刪除 #" + DomainControl.GetResourceId(item)))
            {
                Controller.Delete((item as ViewModel).Data);
                return true;
            }
            return base.ActionDelete(item);
        }

        public class ViewModel : DataModelBase<MedicationRequest>
        {
            public ViewModel(MedicationRequest data, Dictionary<string, object> res) : base(data)
            {
                Status = Convert.ToString(data.Status);
                Intent = Convert.ToString(data.Intent);

                var medCode = data.Medication as CodeableConcept;
                if(medCode != null)
                {
                    Medication = DomainControl.GetCodeableConcept(medCode);
                }
                var medRes = data.Medication as ResourceReference;
                if(medRes != null)
                {
                    var med = res.GetOrCreate(medRes.Reference, r => ControllerBase.Get<Medication>().TryRead(r)) as Medication;
                    Medication = $"{med.Id} ({DomainControl.GetCodeableConcept(med.Code)})";
                }

                var pat = res.GetOrCreate(data.Subject?.Reference ?? "", r => ControllerBase.Get<Patient>().TryRead(r)) as Patient;
                if(pat != null)
                {
                    Subject = $"{DomainControl.GetHumanName(pat.Name)} ({DomainControl.GetIdentifier(pat.Identifier, PatientControl.SystemIdNo)},{DomainControl.GetIdentifier(pat.Identifier, PatientControl.SystemChtNo)})";
                }

                DosageInstruction = GetInstruction(data.DosageInstruction?.FirstOrDefault());
                var dispense = data.DispenseRequest;
                if(dispense != null)
                    DispenseRequest = $"{dispense.Quantity?.Value}{dispense.Quantity?.Unit}, {dispense.ExpectedSupplyDuration?.Value}{dispense.ExpectedSupplyDuration?.Unit}";
            }
            public string Id { get; set; }

            public string Status { get; set; }
            public string Intent { get; set; }
            public string Medication { get; set; }
            public string Subject { get; set; }
            public string AuthoredOn { get; set; }
            public string DosageInstruction { get; set; }
            public string DispenseRequest { get; set; }
        }
    }
}
