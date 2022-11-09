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
using Telemedicine.Patients;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Telemedicine.Observations
{
    public partial class ObservationCreateForm2 : FormBase
    {
        public ObservationCreateForm2()
        {
            InitializeComponent();
            dgvData.AddTextColumn<Observation>(r => r.Id, "#");

            dgvData.AddTextColumn<Observation>(r => r.Category, "類型", formatter: (s, ev) => ListForm.GenericFormatter<CodeableConcept>(ev, r => r.Text));
            dgvData.AddTextColumn<Observation>(r => r.Code, "項目", formatter: (s, ev) => ListForm.GenericFormatter<CodeableConcept>(ev, r => r.Coding.ToString(", ", m => m.Display)));
            dgvData.AddTextColumn<Observation>(r => r.Code, "代碼", formatter: (s, ev) => ListForm.GenericFormatter<CodeableConcept>(ev, r => r.Coding.ToString(", ", m => m.Code)));
            dgvData.AddTextColumn<Observation>(r => r.BodySite, "部位", formatter: (s, ev) => ListForm.GenericFormatter<CodeableConcept>(ev, r => r.Coding.ToString(", ", m => m.Code)));
            dgvData.AddTextColumn<Observation>(r => r.Value, "值", formatter: ObservationListForm2.ObservationValueFormatter);
            dgvData.AddTextColumn<Observation>(r => r.Effective, "日期", formatter: ListForm.PeriodFormatter);
            dgvData.AddTextColumn<Observation>(r => r.Status, "狀態");

            comboMeta.BindMeta();
        }
        public Controller<Observation> Controller { get; set; }

        private void buttonItemAdd_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                using (var d = new ObservationItemForm())
                {
                    if (d.ShowDialog() == DialogResult.OK)
                    {
                        var vs = d.VitalSign;
                        var obs = new Observation();
                        obs.Status = ObservationStatus.Final;
                        obs.Category.Add(vs.GetCategory());
                        obs.Code = vs.GetCode();
                        obs.Effective = d.Effective;
                        obs.BodySite = d.BodySite?.GetCodeableConcept();
                        var values = d.GetValues();
                        if (vs.ValueSpecs != null)
                        {
                            for (var i = 0; i < vs.ValueSpecs.Length; i++)
                            {
                                var valueSpec = vs.ValueSpecs[i];
                                var component = new Observation.ComponentComponent();
                                component.Code = new CodeableConcept(valueSpec.VitalSign.CodeSystem, valueSpec.VitalSign.Code, valueSpec.VitalSign.Item, valueSpec.VitalSign.ItemDisplay);
                                component.Value = new Quantity(values[i].Value, valueSpec.VitalSign.Unit, valueSpec.VitalSign.UnitSystem);
                                obs.Component.Add(component);
                            }
                        }
                        else
                        {
                            obs.Value = new Quantity(values[0].Value, vs.Unit, vs.UnitSystem);
                        }

                        var list = dgvData.GetSortableSource<Observation>();
                        list.Add(obs);
                        list.NotifyListChanged(ListChangedType.ItemAdded, list.Count - 1);
                    }
                }
            });
        }
        private void buttonItemAddBatch_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                using (var d = new ObservationItemForm())
                {
                    d.BatchMode = true;
                    d.Insert += (s, ev) =>
                    {
                        var vs = d.VitalSign;
                        var obs = new Observation();
                        obs.Status = ObservationStatus.Final;
                        obs.Category.Add(vs.GetCategory());
                        obs.Code = vs.GetCode();
                        obs.Effective = d.Effective;
                        obs.BodySite = d.BodySite?.GetCodeableConcept();
                        var values = d.GetValues();
                        if (vs.ValueSpecs != null)
                        {
                            for (var i = 0; i < vs.ValueSpecs.Length; i++)
                            {
                                var valueSpec = vs.ValueSpecs[i];
                                var component = new Observation.ComponentComponent();
                                component.Code = new CodeableConcept(vs.CodeSystem, vs.Code, vs.Item, vs.ItemDisplay);
                                component.Value = new Quantity(values[i].Value, valueSpec.VitalSign.Unit, valueSpec.VitalSign.UnitSystem);
                                obs.Component.Add(component);
                            }
                        }
                        else
                        {
                            obs.Value = new Quantity(values[0].Value, vs.Unit, vs.UnitSystem);
                        }

                        var list = dgvData.GetSortableSource<Observation>();
                        list.Add(obs);
                        list.NotifyListChanged(ListChangedType.ItemAdded, list.Count - 1);
                    };
                    d.ShowDialog();
                }
            });
        }
        private void buttonItemEdit_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                var obs = GetSelectedItem<Observation>(dgvData);
                using (var d = new ObservationItemForm())
                {
                    d.SetObservation(obs);
                    if (d.ShowDialog() == DialogResult.OK)
                    {
                        var vs = d.VitalSign;
                        obs.BodySite = d.BodySite?.GetCodeableConcept();
                        var values = d.GetValues();
                        if (vs.ValueSpecs != null)
                        {
                            for (var i = 0; i < vs.ValueSpecs.Length; i++)
                            {
                                var valueSpec = vs.ValueSpecs[i];
                                var component = new Observation.ComponentComponent();
                                component.Code = new CodeableConcept(vs.CodeSystem, vs.Code, vs.Item, vs.ItemDisplay);
                                component.Value = new Quantity(values[i].Value, valueSpec.VitalSign.Unit, valueSpec.VitalSign.UnitSystem);
                                obs.Component.Add(component);
                            }
                        }
                        else
                        {
                            obs.Value = new Quantity(values[0].Value, vs.Unit, vs.UnitSystem);
                        }

                        var list = dgvData.GetSortableSource<Observation>();
                        list.NotifyListChanged(ListChangedType.ItemChanged, list.IndexOf(obs));
                    }
                }
            });
        }

        private void buttonItemDelete_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                var item = GetSelectedItem<Observation>(dgvData);
                if (item.Id != null)
                {
                    Controller.Delete(item);
                }
                else
                {

                    var list = dgvData.GetSortableSource<Observation>();
                    list.Remove(item);
                    list.NotifyListChanged(ListChangedType.Reset);
                }
            });
        }

        private void buttonItemAddEKG_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                using (var d = new ObservationECGForm())
                {
                    if (d.ShowDialog() == DialogResult.OK)
                    {
                        var vs = VitalSign.ECG;
                        var obs = new Observation();
                        obs.Status = ObservationStatus.Final;
                        obs.Category.Add(vs.GetCategory());
                        obs.Code = vs.GetCode();
                        obs.Effective = d.Effective;
                        obs.Component = d.GetObservationComponents();
                        var list = dgvData.GetSortableSource<Observation>();
                        list.Add(obs);
                        list.NotifyListChanged(ListChangedType.ItemAdded, list.Count - 1);
                    }
                }
            });
        }

        private void buttonUpload_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                if (patientControl1.Id.IsNullOrEmpty())
                    throw new Exception("沒有選擇病患");
                var list = dgvData.GetSortableSource<Observation>();
                if (list.Count == 0)
                    throw new Exception("沒有新增數值");
                var faileds = new List<Observation>();
                foreach (var observation in list)
                {
                    if (observation.Id == null)
                    {
                        Execute(() =>
                        {
                            if (observation?.Code?.Coding?.FirstOrDefault()?.Code == VitalSign.ECG.Code)
                            {
                                observation.Subject = new ResourceReference("Patient/VT.SC4.Inpatient");
                                observation.BasedOn.Add(new ResourceReference("ServiceRequest/VT.SC4.ServiceRequest"));

                                observation.Meta = new Meta
                                {
                                    Profile = new List<string>() 
                                    {
                                        "https://hapi.fhir.tw/fhir/StructureDefinition/ObservationForEMS.ECG"
                                    }
                                };
                            }
                            else
                            {
                                observation.Subject = patientControl1.GetResourceReference();
                                if (medRequestControl1.Id.IsNotNullOrEmpty())
                                    observation.BasedOn.Add(medRequestControl1.GetResourceReference());
                                else if (serviceRequestControl1.Id.IsNotNullOrEmpty())
                                    observation.BasedOn.Add(serviceRequestControl1.GetResourceReference());
                                observation.Meta = comboMeta.GetMeta();
                            }
                            observation.Id = Controller.Create(observation);
                            list.NotifyListChanged(ListChangedType.ItemChanged, list.IndexOf(observation));
                        }, ex =>
                        {
                            faileds.Add(observation);
                        });
                    }
                }
                if (faileds.Count == 0)
                    MsgBoxHelper.Info("上傳成功");
                else
                    MsgBoxHelper.Info("上傳失敗: " + faileds.Count);

            });
        }

    }
}
