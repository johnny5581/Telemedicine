using Hl7.Fhir.Introspection;
using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telemedicine.Controllers;
using Telemedicine.Forms;

namespace Telemedicine.Meds
{
    public partial class MedRequestCreateForm : FormBase
    {
        public MedRequestCreateForm()
        {
            InitializeComponent();

            dgvData.AutoGenerateColumns = true;
            dgvData.AutoFitColumnWidth = true;
            comboMeta.BindMeta();
        }
        public Controller<MedicationRequest> Controller { get; set; }
        private void buttonItemAdd_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                using (var d = new MedListDialog())
                {
                    d.Insert += (s, ev) =>
                    {
                        var med = ev.Med;
                        var list = dgvData.GetSortableSource<MedicationData>();
                        var data = new MedicationData(med);
                        if (list.Count > 0)
                        {
                            data.Timing = list[0].Timing;
                            data.Route = list[0].Route;
                            data.Instruction = list[0].Instruction;
                            data.From = list[0].From;
                            data.To = list[0].To;
                            data.Unit = list[0].Unit;
                        }
                        list.Add(data);
                        list.NotifyListChanged(ListChangedType.Reset);
                    };
                    d.ShowDialog();
                }
            });
        }
        private void buttonItemEdit_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                var item = GetSelectedItem<MedicationData>(dgvData);
                using (var d = new MedRequestItemForm())
                {
                    d.SetMedication(item.Data);
                    d.Timing = item.Timing;
                    d.Route = item.Route;
                    d.Unit = item.Unit;
                    d.From = item.From;
                    d.To = item.To;
                    d.Instruction = item.Instruction;
                    if (d.ShowDialog() == DialogResult.OK)
                    {
                        item.Timing = d.Timing;
                        item.Route = d.Route;
                        item.From = d.From;
                        item.To = d.To;
                        item.Instruction = d.Instruction;
                        item.Unit = d.Unit;
                        dgvData.GetSortableSource<MedicationData>().NotifyListChanged(ListChangedType.Reset);
                    }
                }
            });
        }
        private void buttonItemDelete_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                var item = GetSelectedItem<MedicationData>(dgvData);
                var list = dgvData.GetSortableSource<MedicationData>();
                list.Remove(item);
                list.NotifyListChanged(ListChangedType.Reset);
            });
        }
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                var list = dgvData.GetSortableSource<MedicationData>();
                if (list.Count == 0)
                    throw new InvalidOperationException("沒有藥物資訊");
                foreach (var item in list)
                {
                    var data = item.Data;
                    var request = new MedicationRequest();
                    var patId = patientControl1.Id;
                    if (patId.IsNullOrEmpty())
                        throw new InvalidOperationException("請先選擇病人");
                    request.Status = MedicationRequest.medicationrequestStatus.Active;
                    request.Intent = MedicationRequest.medicationRequestIntent.Order;
                    string code = null, display = null, text = null;
                    if (radioSourceOpd.Checked)
                    {
                        code = "outpatient";
                        display = "Outpatient";
                        text = "門診";
                    }
                    else if (radioSourceIpd.Checked)
                    {
                        code = "inpatient";
                        display = "Inpatient";
                        text = "住院";
                    }
                    else
                    {
                        code = "community";
                        display = "Community";
                        text = "其他";
                    }
                    request.Category.Add(new CodeableConcept("http://terminology.hl7.org/CodeSystem/medicationrequest-category", code, display, text));
                    request.Medication = new MedicationReference("Medication/" + data.Id);

                    //var medCode = data.Code.Coding?.FirstOrDefault();
                    //request.Medication = new MedicationCodeableConcept(medCode?.System, medCode?.Code, medCode?.Display, medCode?.Display);
                    request.Subject = new ResourceReference("Patient/" + patId);
                    request.AuthoredOn = DateTime.Today.ToString("yyyy-MM-dd");
                    request.Meta = comboMeta.GetMeta();
                    var dosage = new Dosage();
                    dosage.Sequence = 1;
                    dosage.Text = item.Instruction;
                    dosage.Timing = new Timing();
                    dosage.Timing.Code = new CodeableConcept();
                    dosage.Timing.Code.Coding.Add(item.Timing);
                    dosage.Route = new CodeableConcept();
                    dosage.Route.Coding.Add(item.Route);
                    request.DosageInstruction.Add(dosage);
                    request.DispenseRequest = new MedicationRequest.DispenseRequestComponent();
                    request.DispenseRequest.ValidityPeriod = new Period(new FhirDateTime(item.From), new FhirDateTime(item.To));

                    var quantity = new Quantity(item.Quantity, item.Unit.Code, item.Unit.System);
                    quantity.Code = item.Unit.Code;
                    request.DispenseRequest.Quantity = quantity;

                    var duration = new Duration();
                    duration.Value = item.Days;
                    duration.Unit = "days";
                    duration.System = "http://unitsofmeasure.org";
                    duration.Code = "d";
                    request.DispenseRequest.ExpectedSupplyDuration = duration;
                    request.DispenseRequest.NumberOfRepeatsAllowed = 1;

                    Controller.Create(request);
                }
                MsgBoxHelper.Info("建立完成");
            });
        }
        [FhirType("Reference")]
        public class MedicationReference : ResourceReference
        {
            public MedicationReference()
            {
            }

            public MedicationReference(string reference) : base(reference)
            {
            }

            public MedicationReference(string reference, string display) : base(reference, display)
            {
            }

            public override string TypeName => "Reference";

        }
        [Serializable]
        [DataContract]
        [FhirType("CodeableConcept", "http://hl7.org/fhir/StructureDefinition/CodeableConcept")]
        public class MedicationCodeableConcept : CodeableConcept
        {
            public MedicationCodeableConcept()
            {
            }

            public MedicationCodeableConcept(string system, string code, string text = null) : base(system, code, text)
            {
            }

            public MedicationCodeableConcept(string system, string code, string display, string text) : base(system, code, display, text)
            {
            }
        }
        private class MedicationData : DataModelBase<Medication>
        {
            public MedicationData(Medication data) : base(data, false)
            {
                Id = data.Id;
                Text = data.Code.Text;

                From = To = DateTime.Today;
            }

            public string Id { get; set; }
            public string Text { get; set; }
            public MedTiming Timing { get; set; }
            public MedRoute Route { get; set; }
            public DateTime From { get; set; }
            public DateTime To { get; set; }
            public string Instruction { get; set; }
            public MedUnit Unit { get; set; }

            public int Quantity
            {
                get
                {
                    return (Days * Timing?.Quantity) ?? 0;
                }
            }

            public int Days
            {
                get { return (To - From).Days; }
            }
        }


    }
}
