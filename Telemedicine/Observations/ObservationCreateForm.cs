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

namespace Telemedicine.Observations
{
    public partial class ObservationCreateForm : FormBase
    {
        private ObservationController _ctrlObs;
        public ObservationCreateForm()
        {
            InitializeComponent();

            _ctrlObs = new ObservationController(this);
            dgvData.AddTextColumn<ObservationData>(r => r.Effecitve);
            dgvData.AddTextColumn<ObservationData>(r => r.Category);
            dgvData.AddTextColumn<ObservationData>(r => r.Item);
            dgvData.AddTextColumn<ObservationData>(r => r.Code);
            dgvData.AddTextColumn<ObservationData>(r => r.Value);
            dgvData.AddTextColumn<ObservationData>(r => r.Unit);
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

        private void buttonItemAdd_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                using (var d = new ObservationDialog())
                {
                    if (d.ShowDialog() == DialogResult.OK)
                    {
                        var observation = d.MainComponent.GetModel();
                        var list = dgvData.GetSortableSource<ObservationData>();
                        list.Add(new ObservationData(observation));
                        list.NotifyListChanged(ListChangedType.Reset);
                    }
                }
            });
        }

        private void buttonItemEdit_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                using (var d = new ObservationDialog())
                {
                    var item = GetSelectedItem<ObservationData>(dgvData);
                    d.MainComponent.LoadModel(item.Data);
                    if (d.ShowDialog() == DialogResult.OK)
                    {
                        var list = dgvData.GetSortableSource<ObservationData>();
                        list.NotifyListChanged(ListChangedType.Reset);
                    }
                }
            });
        }

        private void buttonItemDelete_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                var item = GetSelectedItem<ObservationData>(dgvData);
                var list = dgvData.GetSortableSource<ObservationData>();
                list.Remove(item);
                list.NotifyListChanged(ListChangedType.Reset);
            });
        }

        private void buttonUpload_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                if (textPatId.Text.IsNullOrEmpty())
                    throw new Exception("沒有選擇病患");

                var list = dgvData.GetSortableSource<ObservationData>().Select(r => r.Data).ToList();
                if (list.Count == 0)
                    throw new Exception("沒有新增數值");
                //else if (list.Count == 1)
                //{
                //    var observation = list[0];
                //    observation.Subject = new ResourceReference("Patient/" + textPatId.Text);
                //    if (textMedId.Text.IsNotNullOrEmpty())
                //        observation.BasedOn.Add(new ResourceReference("MedicationRequest/" + textMedId.Text));
                //    _ctrlObs.Create(observation);
                //}
                //else
                //{
                //    var bundle = new Bundle();
                //    bundle.Type = Bundle.BundleType.Transaction;
                //    for (var i = 0; i < list.Count; i++)
                //    {
                //        list[i].Subject = new ResourceReference("Patient/" + textPatId.Text);
                //        if (textMedId.Text.IsNotNullOrEmpty())
                //            list[i].BasedOn.Add(new ResourceReference("MedicationRequest/" + textMedId.Text));
                //        bundle.Entry.Add(new Bundle.EntryComponent { Resource = list[i] });
                //    }
                //    _ctrlObs.CreateBundle(bundle);
                //}

                foreach (var observation in list)
                {
                    observation.Subject = new ResourceReference("Patient/" + textPatId.Text);
                    if (textMedId.Text.IsNotNullOrEmpty())
                        observation.BasedOn.Add(new ResourceReference("MedicationRequest/" + textMedId.Text));
                    _ctrlObs.Create(observation);
                }
                MsgBoxHelper.Info("上傳成功");
                dgvData.ClearSource();
            });
        }



        private class ObservationData : DataModelBase<Observation>
        {
            public ObservationData(Observation data) : base(data, false)
            {
                Id = data.Id;
                PatId = data.Subject?.Reference;
                MedId = data.BasedOn.FirstOrDefault()?.Reference;
                Category = data.Category.ToString(", ", r => r.Text);
                Item = data.Code.Coding.ToString(", ", r => r.Display);
                Code = data.Code.Coding.ToString(", ", r => r.Code);
                var quantity = data.Value as Quantity;
                if (data.Code.Coding[0].Code == VitalSign.BloodPressurePanel.Code)
                {
                    var sbp = data.Component.FirstOrDefault(r => r.Code.Coding.FirstOrDefault()?.Code == VitalSign.SystolicBloodPressure.Code);
                    var dbp = data.Component.FirstOrDefault(r => r.Code.Coding.FirstOrDefault()?.Code == VitalSign.DistolicBloodPressure.Code);
                    Value = $"SBP:{(sbp?.Value as Quantity)?.Value}, DBP: {(dbp?.Value as Quantity)?.Value}";
                }
                else
                    Value = quantity?.Value.ToString(false);
                Unit = quantity?.Unit;
                Effecitve = (data.Effective as FhirDateTime).ToDateTime().ToString("yyyy-MM-dd HH:mm:ss");

            }
            [DisplayName("#")]
            public string Id { get; set; }
            [DisplayName("病患")]
            public string PatId { get; set; }
            public string MedId { get; set; }
            public string Category { get; set; }
            public string Item { get; set; }
            public string Code { get; set; }
            public string Value { get; set; }
            public string Unit { get; set; }
            public string Effecitve { get; set; }
        }

        private void cgIconButton1_Click(object sender, EventArgs e)
        {
            var vs = VitalSign.BloodPressurePanel;
            var baseTime = new DateTime(2020, 7, 1);
            var list = dgvData.GetSortableSource<ObservationData>();
            for (var d = 0; d < 7; d++)
            {
                for (var s = 0; s < 2; s++)
                {

                    var observation = new Observation();
                    observation.Status = ObservationStatus.Final;
                    observation.Category.Add(new CodeableConcept(vs.CategorySystem, vs.Category, vs.CategoryDisplay));
                    observation.Code = new CodeableConcept(vs.CodeSystem, vs.Code, vs.Item, vs.ItemDisplay);
                    observation.Effective = new FhirDateTime(baseTime.AddDays(d).GetDateTimeAt(null, null, null, s == 0 ? 8 : 20, 0, 0));

                    var sbp = new Observation.ComponentComponent();
                    sbp.Code = new CodeableConcept(VitalSign.SystolicBloodPressure.CodeSystem,
                        VitalSign.SystolicBloodPressure.Code,
                        VitalSign.SystolicBloodPressure.Item,
                        VitalSign.SystolicBloodPressure.ItemDisplay);
                    sbp.Value = GetValueQuantity((80+d+s).ToString(), VitalSign.SystolicBloodPressure);
                    observation.Component.Add(sbp);

                    var dbp = new Observation.ComponentComponent();
                    dbp.Code = new CodeableConcept(VitalSign.DistolicBloodPressure.CodeSystem,
                        VitalSign.DistolicBloodPressure.Code,
                        VitalSign.DistolicBloodPressure.Item,
                        VitalSign.DistolicBloodPressure.ItemDisplay);
                    dbp.Value = GetValueQuantity((110+d+s).ToString(), VitalSign.DistolicBloodPressure);
                    observation.Component.Add(dbp);
                    var data = new ObservationData(observation);
                    list.Add(data);
                }
            }
            list.NotifyListChanged(ListChangedType.Reset);
        }
        public Quantity GetValueQuantity(string valueText, VitalSign vs, bool throwOnError = true)
        {
            var value = valueText.ToNullable<decimal>();
            if (value == null && throwOnError)
                throw new FormatException("can't convert value to decimal: " + valueText);
            var quantity = new Quantity(value.Value, vs.Unit, vs.UnitSystem);
            return quantity;
        }
    }
}
