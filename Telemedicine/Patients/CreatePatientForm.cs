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

namespace Telemedicine.Patients
{
    public partial class CreatePatientForm : DialogBase
    {
        Dictionary<string, Dictionary<string, string>> dictPost = null;
        private PatientController _ctrlPat;
        private Patient _lastPat;
        public CreatePatientForm()
        {
            InitializeComponent();
            _ctrlPat = new PatientController(this);

            Dictionary<string, string> countries = new Dictionary<string, string>();
            //countries.Add("彰化縣", "TW-CHA");
            //countries.Add("嘉義縣", "TW-CYQ");
            //countries.Add("新竹縣", "TW-HSQ");
            //countries.Add("花蓮縣", "TW-HUA");
            //countries.Add("宜蘭縣", "TW-ILA");
            //countries.Add("金門縣", "TW-KIN");
            //countries.Add("連江縣", "TW-LIE");
            //countries.Add("苗栗縣", "TW-MIA");
            //countries.Add("南投縣", "TW-NAN");
            //countries.Add("澎湖縣", "TW-PEN");
            //countries.Add("屏東縣", "TW-PIF");
            //countries.Add("臺東縣", "TW-TTT");
            //countries.Add("雲林縣", "TW-YUN");
            //countries.Add("嘉義市", "TW-CYI");
            //countries.Add("新竹市", "TW-HSZ");
            //countries.Add("基隆市", "TW-KEE");
            //countries.Add("高雄市", "TW-KHH");

            countries.Add("臺北市", "TW-TPE");
            countries.Add("新北市", "TW-NWT");
            countries.Add("桃園市", "TW-TAO");
            //countries.Add("臺南市", "TW-TNN");
            //countries.Add("臺中市", "TW-TXG");

            //comboxInit(comboBoxCountry, dict, 0);

            dictPost = new Dictionary<string, Dictionary<string, string>>();

            //Dictionary<string, string> dict1 = new Dictionary<string, string>();
            //post.Add("中正區", "100");
            //post.Add("大同區", "103");
            //post.Add("中山區", "104");
            //post.Add("松山區", "105");
            //post.Add("大安區", "106");
            //post.Add("萬華區", "108");
            //post.Add("信義區", "110");
            //post.Add("士林區", "111");
            //post.Add("北投區", "112");
            //post.Add("內湖區", "114");
            //post.Add("南港區", "115");
            //post.Add("文山區", "116");
            dictPost.Add("TW-TPE",
                new Dictionary<string, string>
                {
                    { "中正區", "100"},
                    { "大同區", "103"},
                    { "中山區", "104"},
                    { "松山區", "105"},
                    { "大安區", "106"},
                    { "萬華區", "108"},
                    { "信義區", "110"},
                    { "士林區", "111"},
                    { "北投區", "112"},
                    { "內湖區", "114"},
                    { "南港區", "115"},
                    { "文山區", "116"},
                });

            //dict1 = new Dictionary<string, string>();
            //dict1.Add("萬里區", "207");
            //dict1.Add("金山區", "208");
            //dict1.Add("板橋區", "220");
            //dict1.Add("汐止區", "221");
            //dict1.Add("深坑區", "222");
            //dict1.Add("石碇區", "223");
            //dict1.Add("瑞芳區", "224");
            //dict1.Add("平溪區", "226");
            //dict1.Add("雙溪區", "227");
            //dict1.Add("貢寮區", "228");
            //dict1.Add("新店區", "231");
            //dict1.Add("坪林區", "232");
            //dict1.Add("烏來區", "233");
            //dict1.Add("永和區", "234");
            //dict1.Add("中和區", "235");
            //dict1.Add("土城區", "236");
            //dict1.Add("三峽區", "237");
            //dict1.Add("樹林區", "238");
            //dict1.Add("鶯歌區", "239");
            //dict1.Add("三重區", "241");
            //dict1.Add("新莊區", "242");
            //dict1.Add("泰山區", "243");
            //dict1.Add("林口區", "244");
            //dict1.Add("蘆洲區", "247");
            //dict1.Add("五股區", "248");
            //dict1.Add("八里區", "249");
            //dict1.Add("淡水區", "251");
            //dict1.Add("三芝區", "252");
            //dict1.Add("石門區", "253");
            //dictPost.Add("新北市", dict1);
            dictPost.Add("TW-NWT",
                new Dictionary<string, string>
                {
                    {"萬里區", "207"},
                    {"金山區", "208"},
                    {"板橋區", "220"},
                    {"汐止區", "221"},
                    {"深坑區", "222"},
                    {"石碇區", "223"},
                    {"瑞芳區", "224"},
                    {"平溪區", "226"},
                    {"雙溪區", "227"},
                    {"貢寮區", "228"},
                    {"新店區", "231"},
                    {"坪林區", "232"},
                    {"烏來區", "233"},
                    {"永和區", "234"},
                    {"中和區", "235"},
                    {"土城區", "236"},
                    {"三峽區", "237"},
                    {"樹林區", "238"},
                    {"鶯歌區", "239"},
                    {"三重區", "241"},
                    {"新莊區", "242"},
                    {"泰山區", "243"},
                    {"林口區", "244"},
                    {"蘆洲區", "247"},
                    {"五股區", "248"},
                    {"八里區", "249"},
                    {"淡水區", "251"},
                    {"三芝區", "252"},
                    {"石門區", "253"},
                });
            //dict1 = new Dictionary<string, string>();
            //dict1.Add("龜山區", "333");
            //dictPost.Add("桃園市", dict1);

            //comboxInit(comboBoxPostalCode, dictPost["臺北市"], 0);
            dictPost.Add("TW-TAO",
                new Dictionary<string, string>
                {
                    { "龜山區", "333"},
                });
            comboBoxCountry.AddItemRange(countries, r => r.Key, r => r.Value);



            comboBoxCountry.SelectedIndexChanged += (s, ev) =>
            {
                comboBoxPostalCode.Items.Clear();
                if (comboBoxCountry.SelectedIndex != -1)
                {
                    var value = comboBoxCountry.SelectedValue as string;
                    if (value != null)
                    {
                        var postalCodes = dictPost.TryGetValue(value);
                        if (postalCodes != null)
                            comboBoxPostalCode.AddItemRange(postalCodes, r => r.Key, r => r.Value);
                    }
                }
            };

            comboOrg.AddTextItem("Organization/MITW.ForIdentifier");
            comboOrg.AddTextItem("Organization/MITW.ForContact");
            comboOrg.AddTextItem("Organization/MITW.ForPHR");
            comboOrg.AddTextItem("Organization/MITW.ForEMS");
        }

        public void LoadPatient(Patient patient)
        {
            _lastPat = patient;
            textBoxName.Text = PatientController.GetName(patient.Name);
            textBoxBirthdate.Text = patient.BirthDate;
            switch (patient.Gender)
            {
                case AdministrativeGender.Male:
                    radioButtonMale.Checked = true;
                    break;
                case AdministrativeGender.Female:
                    radioButtonFemale.Checked = true;
                    break;
                case AdministrativeGender.Unknown:
                    radioButtonUnknown.Checked = true;
                    break;
                default:
                    break;
            }
            textBoxIdentifier.Text = PatientController.GetIdentifier(patient);
            textBoxTelecom.Text = PatientController.GetTelecom(patient);

            var addr = patient.Address.FirstOrDefault();
            if (addr != null)
            {
                foreach (var d in dictPost)
                {
                    if (d.Value.Any(kv => kv.Value == addr.PostalCode))
                    {
                        comboBoxCountry.SelectItem(item => item.Value as string == d.Key);
                        comboBoxPostalCode.SelectItem(item => item.Value as string == addr.PostalCode);
                        break;
                    }
                }
                
                var prefix = addr.PostalCode + addr.Country + addr.District + addr.City;
                textBoxAddress1.Text = addr.Text.Replace(prefix, "");
            }

            var emrContract = patient.Contact.FirstOrDefault();
            if (emrContract != null)
            {
                textBoxContactName.Text = PatientController.GetName(emrContract.Name);
                textBoxContactRelationship.Text = emrContract.Relationship.FirstOrDefault()?.Text;
                textBoxContactTelecom.Text = PatientController.GetTelecom(emrContract.Telecom);
            }

            var org = patient.ManagingOrganization.ReferenceElement.Value;
            comboOrg.SelectItem(item => item.Text == org);


            textBoxBirthdate.ReadOnly = true;
            textBoxIdentifier.ReadOnly = true;

        }

        private void FormPtNew_Load(object sender, EventArgs e)
        {
            
        }
        private void ComboBoxCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboxInit(comboBoxPostalCode, dictPost[comboBoxCountry.Text], 0);
        }

        private void ActionSave(Patient pat)
        {
            if (_lastPat == null)
                _ctrlPat.Create(pat);
            else
            {
                pat.Id = _lastPat.Id;
                _ctrlPat.Update(pat);
            }

        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {

            Execute(() =>
            {
                //使用身分證檢核有無重複
                //有   詢問是否更新
                //沒有 要新增
                var whereObj = new
                {
                    resourceType = "Patient",
                };
                string pGendetr = "Unknown";
                if (radioButtonMale.Checked)
                    pGendetr = "male";
                if (radioButtonFemale.Checked)
                    pGendetr = "female";
                //Patient patient = new Patient
                //{
                //    identifier = textBoxIdentifier.Text,
                //    active = true,
                //    name = textBoxName.Text,
                //    gender = pGendetr,
                //    birthdate = textBoxBirthdate.Text,
                //    telecom = textBoxTelecom.Text,
                //};
                var pG = Hl7.Fhir.Model.AdministrativeGender.Unknown;
                switch (pGendetr)
                {
                    case "male":
                        pG = Hl7.Fhir.Model.AdministrativeGender.Male;
                        break;
                    case "female":
                        pG = Hl7.Fhir.Model.AdministrativeGender.Female;
                        break;
                    default:
                        break;
                }
                Hl7.Fhir.Model.Patient patient1 = new Hl7.Fhir.Model.Patient
                {
                    Identifier = new List<Hl7.Fhir.Model.Identifier>
                    {
                        new Hl7.Fhir.Model.Identifier("https://www.dicom.org.tw/cs/identityCardNumber_tw", textBoxIdentifier.Text),
                        new Hl7.Fhir.Model.Identifier("https://www.cgmh.org.tw", textBoxIdentifier.Text),
                    },
                    Active = true,
                    Name = new List<Hl7.Fhir.Model.HumanName> {
                    new Hl7.Fhir.Model.HumanName
                    {
                        Text = textBoxName.Text,
                        Family =textBoxName.Text.Substring(0,1),
                        Given = new List<string>
                        {
                            textBoxName.Text.Substring(1)
                        },
                    } },
                    Gender = pG,
                    BirthDate = textBoxBirthdate.Text,   //1970-01-01
                    Telecom = new List<Hl7.Fhir.Model.ContactPoint> {
                    new Hl7.Fhir.Model.ContactPoint(Hl7.Fhir.Model.ContactPoint.ContactPointSystem.Fax, Hl7.Fhir.Model.ContactPoint.ContactPointUse.Home, textBoxTelecom.Text) },
                    Contact = new List<Hl7.Fhir.Model.Patient.ContactComponent>
                    {
                        new Hl7.Fhir.Model.Patient.ContactComponent
                        {
                            Name = new Hl7.Fhir.Model.HumanName
                            {
                                Text = textBoxContactName.Text ,
                                Family =textBoxContactName.Text.Substring(0,1),
                                Given = new List<string>
                                {
                                    textBoxContactName.Text.Substring(1)
                                },
                            },
                            Relationship = new List<Hl7.Fhir.Model.CodeableConcept>
                            {
                                new Hl7.Fhir.Model.CodeableConcept("http://hl7.org/fhir/ValueSet/patient-contactrelationship",
                                                                    "N", textBoxContactRelationship.Text)
                            },
                            Telecom = new List<Hl7.Fhir.Model.ContactPoint> {
                                new Hl7.Fhir.Model.ContactPoint(Hl7.Fhir.Model.ContactPoint.ContactPointSystem.Fax, Hl7.Fhir.Model.ContactPoint.ContactPointUse.Home, textBoxContactTelecom.Text) },
                        }
                    },
                    ManagingOrganization = new Hl7.Fhir.Model.ResourceReference("Organization/MITW.ForContact"),
                    Address = new List<Hl7.Fhir.Model.Address>
                    {
                        new Hl7.Fhir.Model.Address
                        {
                            Text = comboBoxPostalCode.SelectedValue.ToString()+"臺灣"+ comboBoxCountry.Text+comboBoxPostalCode.Text+textBoxAddress1.Text,
                            PostalCode = comboBoxPostalCode.SelectedValue.ToString(),
                            Country ="臺灣",
                            District = comboBoxCountry.Text.ToString(),
                            City = comboBoxPostalCode.Text.ToString(),
                        }
                    }
                };
                ActionSave(patient1);
                MsgBoxHelper.Info("建立成功");
            });
        }
        public static void comboxInit(object sender, object dictData, int selectIndex)
        {
            (sender as ComboBox).DisplayMember = "Key";
            (sender as ComboBox).ValueMember = "Value";
            (sender as ComboBox).DataSource = new BindingSource(dictData, null);
            (sender as ComboBox).SelectedIndex = selectIndex;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
