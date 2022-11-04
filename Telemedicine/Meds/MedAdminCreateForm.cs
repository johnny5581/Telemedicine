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
    public partial class MedAdminCreateForm : FormBase
    {
        public MedAdminCreateForm()
        {
            InitializeComponent();
        }
        public Controller<MedicationAdministration> Controller { get; set; }

        private void buttonItemAdd_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                var req = medRequestControl1.GetModel() as MedicationRequest;

                var medAdm = new MedicationAdministration();
                medAdm.Status = MedicationAdministration.MedicationAdministrationStatusCodes.InProgress;
                medAdm.Subject = req.Subject;
                medAdm.Medication = req.Medication;
                medAdm.Request = medRequestControl1.GetResourceReference();

                var reqDosage = req.DosageInstruction.FirstOrDefault();
                medAdm.Dosage = new MedicationAdministration.DosageComponent
                {
                    Text = reqDosage?.Text,
                    Route = reqDosage?.Route,
                    Dose = new Quantity(0, req.DispenseRequest.Quantity.Unit, req.DispenseRequest.Quantity.System)
                    {
                        Code = req.DispenseRequest.Quantity.Code
                    },
                };
                medAdm.Effective = new FhirDateTime(DateTime.Today);
                using (var d = new MedAdminItemForm())
                {
                    d.SetMedicationAdministration(medAdm);
                    if (d.ShowDialog() == DialogResult.OK)
                    {
                        medAdm.Dosage.Dose.Value = d.Quantity;
                        medAdm.Effective = d.Effective;

                        var data = new DataModel(medAdm);
                        var list = dgvData.GetSortableSource<DataModel>();
                        list.Add(data);
                        list.NotifyListChanged(ListChangedType.ItemAdded, list.Count - 1);
                    }
                }
            });
        }

        private void buttonItemEdit_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                var item = GetSelectedItem<DataModel>(dgvData);
                var medAdm = item.Data;
                using (var d = new MedAdminItemForm())
                {
                    d.SetMedicationAdministration(medAdm);
                    if (d.ShowDialog() == DialogResult.OK)
                    {
                        medAdm.Dosage.Dose.Value = d.Quantity;
                        medAdm.Effective = d.Effective;

                        var list = dgvData.GetSortableSource<DataModel>();
                        list.NotifyListChanged(ListChangedType.ItemChanged);
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

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                var list = dgvData.GetSortableSource<DataModel>();
                if (list.Count == 0)
                    throw new InvalidOperationException("沒有用藥紀錄");
                var created = 0;
                for (var i = 0; i<list.Count; i++)
                {
                    if (list[i].Id == null)
                    {
                        list[i].Id = Controller.Create(list[i].Data);
                        list.NotifyListChanged(ListChangedType.ItemChanged, i);
                        created++;
                    }
                }
                if(created > 0)
                    MsgBoxHelper.Info("建立完成");
                else
                    MsgBoxHelper.Info("沒有新增的用藥紀錄");
            });
        }


        private class DataModel : DataModelBase<MedicationAdministration>
        {
            public DataModel(MedicationAdministration data) : base(data, false)
            {
                Id = data.Id;
                if (data.Medication is ResourceReference)
                    MedId = (data.Medication as ResourceReference).Reference;
                else if (data.Medication is CodeableConcept)
                    MedId = (data.Medication as CodeableConcept).Coding?.FirstOrDefault()?.Code;
                PatId = data.Subject?.Reference;
                Quantity = data.Dosage?.Dose?.Value.ToString(false);
                Unit = data.Dosage?.Dose?.Unit;

                ResetEffective();
            }

            public void ResetEffective()
            {
                Effective = DomainControl.GetPeriod(Data.Effective);                
            }
            public string Id { get; set; }
            public string MedId { get; set; }
            public string PatId { get; set; }
            public string Quantity { get; set; }
            public string Unit { get; set; }
            public string Effective { get; set; }
        }

        private void medRequestControl1_ItemPicked(object sender, EventArgs e)
        {
            Execute(() =>
            {
                dgvData.ClearSource();
                var medAdms = Controller.Search("request=" + medRequestControl1.GetResourceReference().Reference);
                var dataList = medAdms.Select(r => new DataModel(r));
                dgvData.SetSource(dataList);
            });
        }
    }
}
