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
    public partial class CreatePatientForm : FormBase
    {
        Dictionary<string, Dictionary<string, string>> dictPost = null;
        private PatientController _ctrlPat;
        public CreatePatientForm()
        {
            InitializeComponent();
            _ctrlPat = new PatientController(this);
        }
        private void FormPtNew_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            //dict.Add("彰化縣", "TW-CHA");
            //dict.Add("嘉義縣", "TW-CYQ");
            //dict.Add("新竹縣", "TW-HSQ");
            //dict.Add("花蓮縣", "TW-HUA");
            //dict.Add("宜蘭縣", "TW-ILA");
            //dict.Add("金門縣", "TW-KIN");
            //dict.Add("連江縣", "TW-LIE");
            //dict.Add("苗栗縣", "TW-MIA");
            //dict.Add("南投縣", "TW-NAN");
            //dict.Add("澎湖縣", "TW-PEN");
            //dict.Add("屏東縣", "TW-PIF");
            //dict.Add("臺東縣", "TW-TTT");
            //dict.Add("雲林縣", "TW-YUN");
            //dict.Add("嘉義市", "TW-CYI");
            //dict.Add("新竹市", "TW-HSZ");
            //dict.Add("基隆市", "TW-KEE");
            //dict.Add("高雄市", "TW-KHH");
            dict.Add("新北市", "TW-NWT");
            dict.Add("桃園市", "TW-TAO");
            //dict.Add("臺南市", "TW-TNN");
            dict.Add("臺北市", "TW-TPE");
            //dict.Add("臺中市", "TW-TXG");

            comboxInit(comboBoxCountry, dict, 0);
            comboBoxCountry.SelectedIndexChanged += ComboBoxCountry_SelectedIndexChanged;
            dictPost = new Dictionary<string, Dictionary<string, string>>();
            Dictionary<string, string> dict1 = new Dictionary<string, string>();
            dict1.Add("中正區", "100");
            dict1.Add("大同區", "103");
            dict1.Add("中山區", "104");
            dict1.Add("松山區", "105");
            dict1.Add("大安區", "106");
            dict1.Add("萬華區", "108");
            dict1.Add("信義區", "110");
            dict1.Add("士林區", "111");
            dict1.Add("北投區", "112");
            dict1.Add("內湖區", "114");
            dict1.Add("南港區", "115");
            dict1.Add("文山區", "116");
            dictPost.Add("臺北市", dict1);

            dict1 = new Dictionary<string, string>();
            dict1.Add("萬里區", "207");
            dict1.Add("金山區", "208");
            dict1.Add("板橋區", "220");
            dict1.Add("汐止區", "221");
            dict1.Add("深坑區", "222");
            dict1.Add("石碇區", "223");
            dict1.Add("瑞芳區", "224");
            dict1.Add("平溪區", "226");
            dict1.Add("雙溪區", "227");
            dict1.Add("貢寮區", "228");
            dict1.Add("新店區", "231");
            dict1.Add("坪林區", "232");
            dict1.Add("烏來區", "233");
            dict1.Add("永和區", "234");
            dict1.Add("中和區", "235");
            dict1.Add("土城區", "236");
            dict1.Add("三峽區", "237");
            dict1.Add("樹林區", "238");
            dict1.Add("鶯歌區", "239");
            dict1.Add("三重區", "241");
            dict1.Add("新莊區", "242");
            dict1.Add("泰山區", "243");
            dict1.Add("林口區", "244");
            dict1.Add("蘆洲區", "247");
            dict1.Add("五股區", "248");
            dict1.Add("八里區", "249");
            dict1.Add("淡水區", "251");
            dict1.Add("三芝區", "252");
            dict1.Add("石門區", "253");
            dictPost.Add("新北市", dict1);

            dict1 = new Dictionary<string, string>();
            dict1.Add("龜山區", "333");
            dictPost.Add("桃園市", dict1);

            comboxInit(comboBoxPostalCode, dictPost["臺北市"], 0);
        }
        private void ComboBoxCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboxInit(comboBoxPostalCode, dictPost[comboBoxCountry.Text], 0);
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
                    new Hl7.Fhir.Model.HumanName { Text = textBoxName.Text } },
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
                            new Hl7.Fhir.Model.CodeableConcept("http://hl7.org/fhir/ValueSet/patient-contactrelationship", "code", textBoxContactRelationship.Text)
                        },
                        Telecom = new List<Hl7.Fhir.Model.ContactPoint> {
                            new Hl7.Fhir.Model.ContactPoint(Hl7.Fhir.Model.ContactPoint.ContactPointSystem.Fax, Hl7.Fhir.Model.ContactPoint.ContactPointUse.Home, textBoxContactTelecom.Text) },
                    }
                },
                    ManagingOrganization = new Hl7.Fhir.Model.ResourceReference("Organization/MITW.ForIdentifier"),
                    Address = new List<Hl7.Fhir.Model.Address>
                {
                    new Hl7.Fhir.Model.Address
                    {
                        Text = textBoxAddress.Text,
                        PostalCode = comboBoxPostalCode.SelectedValue.ToString(),
                        Country = comboBoxCountry.SelectedValue.ToString(),
                    }
                }
                };
                var pat = _ctrlPat.Create(patient1);
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
