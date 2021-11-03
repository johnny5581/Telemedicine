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

namespace Telemedicine.Meds
{
    public partial class MedicationRequestCreateForm : FormBase
    {
        private MedicationRequestController _ctrlMedReq;
        public MedicationRequestCreateForm()
        {
            InitializeComponent();
            dgvData.AppendColumn<DataGridViewTextBoxColumn>()
                   .Bind<MedicationData>(r => r.Id)
                   .ConfigBy(c => c.ReadOnly = c.Frozen = true)
                   .Commit();
            dgvData.AppendColumn<DataGridViewTextBoxColumn>()
                   .Bind<MedicationData>(r => r.Text)
                   .ConfigBy(c => c.ReadOnly = c.Frozen = true)
                   .Commit();
            dgvData.AppendColumn<DataGridViewTextBoxColumn>()
                   .Bind<MedicationData>(r => r.Timing)
                   .Commit();
            dgvData.AppendColumn<DataGridViewTextBoxColumn>()
                   .Bind<MedicationData>(r => r.Route)
                   .Commit();
            dgvData.AppendColumn<DataGridViewTextBoxColumn>()
                   .Bind<MedicationData>(r => r.Unit)
                   .Commit();
            dgvData.AppendColumn<DataGridViewTextBoxColumn>()
                   .Bind<MedicationData>(r => r.DateBegin)
                   .UseFormatter(DateFormatter)
                   .Commit();
            dgvData.AppendColumn<DataGridViewTextBoxColumn>()
                   .Bind<MedicationData>(r => r.DateEnd)
                   .UseFormatter(DateFormatter)
                   .Commit();
            _ctrlMedReq = new MedicationRequestController(this);
        }

        private void DateFormatter(object sender, CgDataGridPanel.FormattingCellEventArgs e)
        {
            e.Value = ((DateTime)e.Value).ToString("yyyy-MM-dd") ?? "";
            e.FormattingApplied = true;
        }

        private void buttonPat_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                using (var d = new Patients.PatientListForm())
                {
                    if (d.ShowDialog() == DialogResult.OK)
                    {
                        var pat = d.SelectedPatient;
                        textPatId.Text = pat.Id;
                        textPatName.Text = PatientController.GetName(pat);
                        textPatSex.Text = pat.Gender.ToString(false);
                        textPatBrithDate.Text = pat.BirthDate;
                    }
                }
            });
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                var list = dgvData.GetSortableSource<MedicationData>();
                if (list.Count == 0)
                    throw new InvalidOperationException("沒有藥物資訊");
                foreach(var item in list)
                {
                    var data = item.Data;
                    var request = new MedicationRequest();
                    var patId = textPatId.Text;
                    if (patId.IsNullOrEmpty())
                        throw new InvalidOperationException("請先選擇病人");
                    request.Status = MedicationRequest.medicationrequestStatus.Active;
                    request.Intent = MedicationRequest.medicationRequestIntent.Order;
                    string code = null, display = null, text = null;
                    if (radioPatOPD.Checked)
                    {
                        code = "outpatient";
                        display = "Outpatient";
                        text = "門診";
                    }
                    else if (radioPatIPD.Checked)
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
                    request.Medication = new ResourceReference("Medication/" + data.Id);
                    request.Subject = new ResourceReference("Patient/" + textPatId.Text);
                    request.AuthoredOn = DateTime.Today.ToString("yyyy-MM-dd");
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
                    request.DispenseRequest.ValidityPeriod = new Period(new FhirDateTime(item.DateBegin), new FhirDateTime(item.DateEnd));

                    var quantity = new Quantity(item.Quantity, item.Unit.Code, item.Unit.System);
                    quantity.Code = item.Unit.Code;
                    request.DispenseRequest.Quantity = quantity;

                    var duration = new Duration();
                    duration.Value = item.Days;
                    duration.Unit = "days";
                    duration.System = "http://unitsofmeasure.org";
                    duration.Code = "d";
                    request.DispenseRequest.ExpectedSupplyDuration = duration;

                    _ctrlMedReq.Create(request);
                }
                MsgBoxHelper.Info("建立完成");
            });
        }

        private void buttonItemAdd_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                using (var d = new MedicationListForm())
                {
                    d.Insert += (s, ev) =>
                    {
                        var med = d.GetCurrentMedication();
                        var list = dgvData.GetSortableSource<MedicationData>();
                        var data = new MedicationData(med);
                        if(list.Count > 0)
                        {
                            data.Timing = MedTiming.Timings.FirstOrDefault(r=>r.Code == list[0].Timing.Code);
                            data.Route = MedRoute.Routes.FirstOrDefault(r => r.Code == list[0].Route.Code);
                            data.DateBegin = list[0].DateBegin;
                            data.DateEnd = list[0].DateEnd;
                        }
                        list.Add(data);
                        list.NotifyListChanged(ListChangedType.Reset);
                    };
                    d.ShowDialog();
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
        private class MedicationData : DataModelBase<Medication>
        {
            public MedicationData(Medication data) : base(data, false)
            {
                Id = data.Id;
                Text = data.Code.Text;

                DateBegin = DateEnd = DateTime.Today;
            }

            public string Id { get; set; }
            public string Text { get; set; }
            public MedTiming Timing { get; set; }
            public MedRoute Route { get; set; }
            public DateTime DateBegin { get; set; }
            public DateTime DateEnd { get; set; }
            public string Instruction { get; set; }
            public MedUnit Unit { get; set; }

            public int Quantity
            {
                get
                {
                    return Days * Timing.Quantity;
                }
            }

            public int Days
            {
                get { return (DateEnd - DateBegin).Days; }
            }
        }

        private void buttonItemEdit_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                var item = GetSelectedItem<MedicationData>(dgvData);
                using (var d = new MedicationRequestDialog())
                {
                    d.MainComponent.Timing = item.Timing;
                    d.MainComponent.Route = item.Route;
                    d.MainComponent.DateBegin = item.DateBegin;
                    d.MainComponent.DateEnd = item.DateEnd;
                    d.MainComponent.Instruction = item.Instruction;
                    d.MainComponent.Unit = item.Unit;
                    if (d.ShowDialog() == DialogResult.OK)
                    {
                        item.Timing = d.MainComponent.Timing;
                        item.Route = d.MainComponent.Route;
                        item.DateBegin = d.MainComponent.DateBegin;
                        item.DateEnd = d.MainComponent.DateEnd;
                        item.Instruction = d.MainComponent.Instruction;
                        item.Unit = d.MainComponent.Unit;
                        dgvData.GetSortableSource<MedicationData>().NotifyListChanged(ListChangedType.Reset);
                    }
                }
            });
        }
    }


}
