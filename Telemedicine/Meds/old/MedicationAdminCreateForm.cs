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
    public partial class MedicationAdminCreateForm : FormBase
    {
        private MedicationAdministrationController _ctrlMedAdm;
        private MedicationRequestController _ctrlMedReq;
        private PatientController _ctrlPat;
        public MedicationAdminCreateForm()
        {
            InitializeComponent();
            dgvData.AppendColumn<DataGridViewTextBoxColumn>()
                   .Bind<DataModel>(r => r.Id)
                   .ConfigBy(c => c.ReadOnly = c.Frozen = true)
                   .Commit();
            dgvData.AppendColumn<DataGridViewTextBoxColumn>()
                   .Bind<DataModel>(r => r.MedId)
                   .Commit();
            dgvData.AppendColumn<DataGridViewTextBoxColumn>()
                   .Bind<DataModel>(r => r.PatId)
                   .Commit();
            dgvData.AppendColumn<DataGridViewTextBoxColumn>()
                   .Bind<DataModel>(r => r.Quantity)
                   .Commit();
            dgvData.AppendColumn<DataGridViewTextBoxColumn>()
                   .Bind<DataModel>(r => r.Unit)
                   .UseFormatter(DateFormatter)
                   .Commit();
            dgvData.AppendColumn<DataGridViewTextBoxColumn>()
                   .Bind<DataModel>(r => r.Effective)
                   .Commit();
            _ctrlMedReq = new MedicationRequestController(this);
            _ctrlPat = new PatientController(this);
            _ctrlMedAdm = new MedicationAdministrationController(this);
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
                        var pat = d.Selected;
                        textPatId.Text = pat.Id;
                        textPatName.Text = PatientController.GetName(pat);
                        textPatSex.Text = pat.Gender.ToString(false);
                        textPatBrithDate.Text = pat.BirthDate;
                    }
                }
            });
        }
        private void buttonMedReq_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                using (var d = new MedicationRequestListForm())
                {
                    if (d.ShowDialog() == DialogResult.OK)
                    {
                        var req = d.SelectedMedicationRequest;
                        textMedRedId.Text = req.Id;
                        textMedRedId.Tag = req;

                        if (textPatId.Text.IsNullOrEmpty())
                        {
                            var pat = _ctrlPat.Read(req.Subject.Reference);
                            if (pat != null)
                            {
                                textPatId.Text = pat.Id;
                                textPatName.Text = PatientController.GetName(pat);
                                textPatSex.Text = pat.Gender.ToString(false);
                                textPatBrithDate.Text = pat.BirthDate;
                            }
                        }
                    }
                }
            });
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                var list = dgvData.GetSortableSource<DataModel>();
                if (list.Count == 0)
                    throw new InvalidOperationException("沒有用藥紀錄");
                foreach (var item in list)
                {
                    var data = item.Data;
                    _ctrlMedAdm.Create(data);                    
                }
                MsgBoxHelper.Info("建立完成");

            });
        }
        private void buttonItemEdit_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                var item = GetSelectedItem<DataModel>(dgvData);
                using (var d = new MedicationAdminDialog())
                {
                    var data = item.Data;
                    if(item.Data.Effective is Period)
                    {
                        var period = item.Data.Effective as Period;
                        d.MainComponent.DateBegin = new FhirDateTime(period.Start).ToDateTime().Value;
                        d.MainComponent.DateEnd = new FhirDateTime(period.End).ToDateTime().Value;
                        d.MainComponent.DateEndEnabled = true;
                    }
                    else if(item.Data.Effective is FhirDateTime)
                    {
                        var dt = item.Data.Effective as FhirDateTime;
                        d.MainComponent.DateBegin = dt.ToDateTime().Value;
                        d.MainComponent.DateEndEnabled = false;
                    }
                    
                    d.MainComponent.Quantity = item.Quantity;
                    d.MainComponent.Unit = item.Unit;
                    if (d.ShowDialog() == DialogResult.OK)
                    {
                        if(d.MainComponent.DateEndEnabled)                        
                            data.Effective = new Period(new FhirDateTime(d.MainComponent.DateBegin), new FhirDateTime(d.MainComponent.DateEnd));                        
                        else                        
                            data.Effective = new FhirDateTime(d.MainComponent.DateBegin);                        
                        item.ResetEffective();
                        item.Quantity = d.MainComponent.Quantity;
                        item.Unit = d.MainComponent.Unit;
                        dgvData.GetSortableSource<DataModel>().NotifyListChanged(ListChangedType.Reset);
                    }
                }
            });
        }

        private void buttonItemAdd_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                var req = textMedRedId.Tag as MedicationRequest;
                if (req == null)
                    throw new Exception("請選擇處方籤");

                var patId = textPatId.Text;
                if (patId.IsNullOrEmpty())
                    throw new Exception("請選擇病人");

                using (var d = new MedicationAdminDialog())
                {
                    d.MainComponent.Unit = req.DispenseRequest.Quantity.Unit;
                    if(d.ShowDialog() == DialogResult.OK)
                    {
                        var admin = new MedicationAdministration();
                        admin.Status = MedicationAdministration.MedicationAdministrationStatusCodes.InProgress;
                        admin.Subject = req.Subject;
                        admin.Medication = req.Medication;
                        admin.Request = new ResourceReference("MedicationRequest/" + req.Id);
                        if (d.MainComponent.DateEndEnabled)
                            admin.Effective = new Period(new FhirDateTime(d.MainComponent.DateBegin), new FhirDateTime(d.MainComponent.DateEnd));
                        else
                            admin.Effective = new FhirDateTime(d.MainComponent.DateBegin);
                        admin.Dosage = new MedicationAdministration.DosageComponent();
                        var reqDosage = req.DosageInstruction.FirstOrDefault();
                        if(reqDosage != null)
                        {
                            admin.Dosage.Text = reqDosage.Text;
                            admin.Dosage.Route = reqDosage.Route;
                        }
                        admin.Dosage.Dose = new Quantity(d.Quantity, req.DispenseRequest.Quantity.Unit, req.DispenseRequest.Quantity.System);
                        admin.Dosage.Dose.Code = req.DispenseRequest.Quantity.Code;

                        var data = new DataModel(admin);
                        var list = dgvData.GetSortableSource<DataModel>();
                        list.Add(data);
                        list.NotifyListChanged(ListChangedType.ItemAdded, list.Count - 1);
                    }
                }
            });
        }
        private void buttonItemDelete_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                var item = GetSelectedItem<DataModel>(dgvData);
                var list = dgvData.GetSortableSource<DataModel>();
                list.Remove(item);
                list.NotifyListChanged(ListChangedType.Reset);
            });
        }
        private class DataModel : DataModelBase<MedicationAdministration>
        {
            public DataModel(MedicationAdministration data) : base(data, false)
            {
                Id = data.Id;
                if(data.Medication is ResourceReference)
                    MedId = (data.Medication as ResourceReference).Reference;
                else if (data.Medication is CodeableConcept)
                    MedId = (data.Medication as CodeableConcept).Coding.FirstOrDefault()?.Code;
                PatId = data.Subject.Reference;
                Quantity = data.Dosage.Dose.Value.ToString(false);
                Unit = data.Dosage.Dose.Unit;

                ResetEffective();
            }

            public void ResetEffective()
            {
                if (Data.Effective is Period)
                {
                    var period = Data.Effective as Period;
                    Effective = $"{new FhirDateTime(period.Start).ToDateTime().ToString("yyyy-MM-dd")} - {new FhirDateTime(period.End).ToDateTime().ToString("yyyy-MM-dd")}";
                }
                else if (Data.Effective is FhirDateTime)
                    Effective = $"{(Data.Effective as FhirDateTime).ToDateTime().ToString("yyyy-MM-dd")}";
            }
            public string Id { get; set; }
            public string MedId { get; set; }
            public string PatId { get; set; }
            public string Quantity { get; set; }
            public string Unit { get; set; }
            public string Effective { get; set; }
        }


    }
}
