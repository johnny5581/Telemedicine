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

namespace Telemedicine.Vaccs
{
    public partial class VaccListForm : FormBase
    {
        private CompositionController _ctrlComposition;
        private ObservationController _ctrlObs;
        private DateTimePicker dateBeginDate;
        private DateTimePicker dateBeginTime;
        private DateTimePicker dateEndDate;
        private DateTimePicker dateEndTime;
        public VaccListForm()
        {
            InitializeComponent();

            _ctrlComposition = new CompositionController(this);
            _ctrlObs = new ObservationController(this);

            dgvData.AutoGenerateColumns = true;
            comboPatOrg.BindOrganizations("全部");

            dateBeginDate = new DateTimePicker();
            dateBeginDate.CustomFormat = "yyyy-MM-dd";
            dateBeginDate.Format = DateTimePickerFormat.Custom;
            dateBeginDate.Dock = DockStyle.Fill;
            dateBeginTime = new DateTimePicker();
            dateBeginTime.CustomFormat = "HH:mm:ss";
            dateBeginTime.Format = DateTimePickerFormat.Custom;
            dateBeginTime.ShowUpDown = true;
            dateBeginTime.Dock = DockStyle.Fill;
            dateEndDate = new DateTimePicker();
            dateEndDate.CustomFormat = "yyyy-MM-dd";
            dateEndDate.Format = DateTimePickerFormat.Custom;
            dateEndDate.Dock = DockStyle.Fill;
            dateEndTime = new DateTimePicker();
            dateEndTime.CustomFormat = "HH:mm:ss";
            dateEndTime.Format = DateTimePickerFormat.Custom;
            dateEndTime.ShowUpDown = true;
            dateEndTime.Dock = DockStyle.Fill;
            labelDateRange.LayoutPanel.ChangeLayout(
                new ColumnStyle[] { new ColumnStyle(SizeType.Percent, 30), new ColumnStyle(SizeType.Percent, 20), new ColumnStyle(SizeType.Absolute, 20), new ColumnStyle(SizeType.Percent, 30), new ColumnStyle(SizeType.Percent, 20) },
                new RowStyle[] { new RowStyle(SizeType.Percent, 100) });
            labelDateRange.LayoutPanel.AddControlToPosition(dateBeginDate, 0, 0);
            labelDateRange.LayoutPanel.AddControlToPosition(dateBeginTime, 1, 0);
            labelDateRange.LayoutPanel.AddControlToPosition(new Label { Text = "~", TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill }, 2, 0);
            labelDateRange.LayoutPanel.AddControlToPosition(dateEndDate, 3, 0);
            labelDateRange.LayoutPanel.AddControlToPosition(dateEndTime, 4, 0);
        }

        private void ActionSearch()
        {
            dgvData.ClearSource();
            var id = textId.Text;
            var patId = textSubject.Text;
            var patIdentifier = textPatIdentifier.Text;
            var patOrg = comboPatOrg.SelectedValue as string;

            dgvData.ClearSource();

            //var client = _ctrlComposition.GetClient();
            //string valueSetId = null;
            //string[] compositionIds = null;
            //if (patId.IsNotNullOrEmpty() || patIdentifier.IsNotNullOrEmpty() | patOrg.IsNotNullOrEmpty())
            //{
            //    // search composition
            //    var compositionCriteria = new List<string>();
            //    if (patId.IsNotNullOrEmpty())
            //        compositionCriteria.Add("patient=" + patId);
            //    if (patIdentifier.IsNotNullOrEmpty())
            //        compositionCriteria.Add("patient.identifier=" + patIdentifier);
            //    if (patOrg.IsNotNullOrEmpty())
            //        compositionCriteria.Add("patient.organization=" + patOrg);
            //    var compositions = _ctrlComposition.Search(compositionCriteria);
            //    compositionIds = compositions.Select(r => r.Id).ToArray();

            //    //// create new valueset
            //    //var valueSet = new ValueSet();
            //    //valueSet.Status = PublicationStatus.Active;
            //    //valueSet.Compose = new ValueSet.ComposeComponent();
            //    //var include = new ValueSet.ConceptSetComponent();
            //    ////foreach (var compositionId in compositionIds)
            //    ////{
            //    ////    var concept = new ValueSet.ConceptReferenceComponent();
            //    ////    concept.Code = compositionId;
            //    ////    include.Concept.Add(concept);
            //    ////}
            //    //include.ValueSet = compositionIds;
            //    //include.System = "http://www.cgmh.org.tw";
            //    //valueSet.Compose.Include.Add(include);
            //    //valueSet.Url = "urn:valueset:" + Guid.NewGuid().ToString();
            //    //var newValueSet = client.Create(valueSet);
            //    //valueSetId = newValueSet.Id;
            //}

            //var list = new List<Bundle>();
            //if(compositionIds != null && compositionIds.Length > 0)
            //{
            //    foreach(var compositionId in compositionIds)
            //    {
            //        var criteria = new List<string>();
            //        if (id.IsNotNullOrEmpty())
            //            criteria.Add("_id=" + id);
            //        criteria.Add("composition=" + compositionId);
            //        //if (valueSetId.IsNotNullOrEmpty())
            //        //    criteria.Add("composition:in=" + valueSetId);
            //        if (checkDateRange.Checked)
            //        {
            //            var begin = dateBeginDate.Value.Date + dateBeginTime.Value.TimeOfDay;
            //            var end = dateEndDate.Value.Date + dateEndTime.Value.TimeOfDay;
            //            var datBegin = begin.ToString("yyyy-MM-dd");
            //            var datEnd = end.ToString("yyyy-MM-dd");
            //            criteria.Add("date=gt" + datBegin);
            //            criteria.Add("date=lt" + datEnd);
            //        }
            //        var reqs = _ctrlBundle.Search(criteria);
            //        list.AddRange(reqs);
            //    }
            //}
            //else
            //{
            //    var criteria = new List<string>();
            //    if (id.IsNotNullOrEmpty())
            //        criteria.Add("_id=" + id);
            //    //if (valueSetId.IsNotNullOrEmpty())
            //    //    criteria.Add("composition:in=" + valueSetId);
            //    if (checkDateRange.Checked)
            //    {
            //        var begin = dateBeginDate.Value.Date + dateBeginTime.Value.TimeOfDay;
            //        var end = dateEndDate.Value.Date + dateEndTime.Value.TimeOfDay;
            //        var datBegin = begin.ToString("yyyy-MM-dd");
            //        var datEnd = end.ToString("yyyy-MM-dd");
            //        criteria.Add("date=gt" + datBegin);
            //        criteria.Add("date=lt" + datEnd);
            //    }
            //    var reqs = _ctrlBundle.Search(criteria);
            //    list.AddRange(reqs);
            //}
            var criteria = new List<string>();
            if (patId.IsNotNullOrEmpty())
                criteria.Add("patient=" + patId);
            if (patIdentifier.IsNotNullOrEmpty())
                criteria.Add("patient.identifier=" + patIdentifier);
            if (patOrg.IsNotNullOrEmpty())
                criteria.Add("patient.organization=" + patOrg);
            if (id.IsNotNullOrEmpty())
                criteria.Add("_id=" + id);
            if (checkDateRange.Checked)
            {
                var begin = dateBeginDate.Value.Date + dateBeginTime.Value.TimeOfDay;
                var end = dateEndDate.Value.Date + dateEndTime.Value.TimeOfDay;
                var datBegin = begin.ToString("yyyy-MM-dd");
                var datEnd = end.ToString("yyyy-MM-dd");
                criteria.Add("date=gt" + datBegin);
                criteria.Add("date=lt" + datEnd);
            }
            var list = _ctrlObs.Search(criteria);
            var dataList = list.Select(r => new DataModel(r)).ToList();
            dgvData.SetSource(dataList);
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Execute(ActionSearch);
        }

        private class DataModel : DataModelBase<Observation>
        {
            public DataModel(Observation data) : base(data)
            {
            }

            [DisplayName("#")]
            public string Id { get; set; }
        }
        private void menuDelete_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                var item = GetSelectedItem<DataModel>(dgvData);
                _ctrlComposition.GetClient().Delete(item.Data);
                MsgBoxHelper.Info("刪除成功");
                ActionSearch();
            });
        }
    }
}
