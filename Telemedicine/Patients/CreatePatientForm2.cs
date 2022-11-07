using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.SessionState;
using System.Windows.Forms;
using Telemedicine.Controllers;
using Telemedicine.Forms;

namespace Telemedicine.Patients
{
    public partial class CreatePatientForm2 : FormBase
    {
        private Patient _source;
        public CreatePatientForm2()
        {
            InitializeComponent();
            // 性別
            comboSex.AddTextItem("男", AdministrativeGender.Male);
            comboSex.AddTextItem("女", AdministrativeGender.Female);
            comboSex.AddTextItem("其他", AdministrativeGender.Other);
            comboSex.AddTextItem("不確定", AdministrativeGender.Unknown);
            comboSex.SelectedIndex = 0;

            // 聯絡人關係
            comboContactRelation.AddTextItem("直系血親", new CodeableConcept("http://terminology.hl7.org/CodeSystem/v2-0131", "N", "Next-of-Kin"));
            comboContactRelation.SelectedIndex = 0;

            // 地區
            comboCity.AddItemRange(ZipMap.Map.Keys, r => r);
            comboCity.SelectedIndexChanged += ComboCity_SelectedIndexChanged;
            comboCity.SelectItem("桃園縣");
            comboDist.SelectItem<ZipMap>(r => r.Zip == 333);


            comboMeta.BindMeta();
            }

        public Controller<Patient> Controller { get; set; }

        public void SetSource(Patient source)
        {
            _source = source;
            textName.SetHumanName(source.Name.ElementAtOrDefault(0));
            textBirthDat.Text = source.BirthDate;
            comboSex.SelectItem(item => ((AdministrativeGender)item.Value) == source.Gender);
            textIdNo.Text = source.Identifier.FirstOrDefault(r => r.System == PatientControl.SystemIdNo)?.Value;
            textChtNo.Text = source.Identifier.FirstOrDefault(r => r.System == PatientControl.SystemChtNo)?.Value;
            textTelecom.Text = source.Telecom.FirstOrDefault(r => r.System == ContactPoint.ContactPointSystem.Phone)?.Value;
            textEmail.Text = source.Telecom.FirstOrDefault(r => r.System == ContactPoint.ContactPointSystem.Email)?.Value;
            textPersonalUrl.Text = source.Telecom.FirstOrDefault(r => r.System == ContactPoint.ContactPointSystem.Url)?.Value;

            var contact = source.Contact.FirstOrDefault();
            if (contact != null)
            {
                textContactName.SetHumanName(contact.Name);
                textContactTelecom.Text = contact.Telecom.FirstOrDefault(r => r.System == ContactPoint.ContactPointSystem.Phone)?.Value;
            }
            ucOrg.Set(source.ManagingOrganization);

            var address = source.Address.FirstOrDefault();
            if (address != null)
            {
                comboCity.SelectItem(address.City);
                comboDist.SelectValue(address.PostalCode.To<short>());
            }
            comboMeta.Text = source.Meta?.Profile?.FirstOrDefault();
        }

        private void ComboCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            var city = comboCity.SelectedValue as string;
            if (city != null)
            {
                comboDist.Items.Clear();
                comboDist.AddItemRange(ZipMap.Map[city], r => r.Dist, r => r.Zip);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                if (_source == null)
                {
                    // new 
                    var pat = new Patient();
                    var identifierIdNo = new Identifier(PatientControl.SystemIdNo, textIdNo.Text);
                    identifierIdNo.Type = new CodeableConcept("http://terminology.hl7.org/CodeSystem/v2-0203", "NI");
                    var identifierChtNo = new Identifier(PatientControl.SystemChtNo, textChtNo.Text);
                    identifierChtNo.Type = new CodeableConcept("http://terminology.hl7.org/CodeSystem/v2-0203", "MR");
                    pat.Identifier.Add(identifierIdNo);
                    pat.Identifier.Add(identifierChtNo);
                    pat.Active = true;
                    pat.Deceased = new FhirBoolean(checkDead.Checked);
                    pat.Gender = (AdministrativeGender)comboSex.SelectedValue;
                    pat.Name.Add(textName.GetHumanName());
                    pat.BirthDate = textBirthDat.Text;
                    pat.Telecom.Add(new ContactPoint(ContactPoint.ContactPointSystem.Phone, ContactPoint.ContactPointUse.Mobile, textTelecom.Text));
                    pat.Telecom.Add(new ContactPoint(ContactPoint.ContactPointSystem.Email, ContactPoint.ContactPointUse.Home, textEmail.Text));
                    pat.Telecom.Add(new ContactPoint(ContactPoint.ContactPointSystem.Url, ContactPoint.ContactPointUse.Home, textPersonalUrl.Text));
                    pat.ManagingOrganization = ucOrg.GetResourceReference();
                    var address = new Address();
                    address.PostalCode = Convert.ToString(comboDist.SelectedValue);
                    address.City = comboCity.Text;
                    address.District = comboDist.Text;
                    address.Country = "TW";
                    address.Line = textAddress.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                    address.Text = $"{address.PostalCode} {address.City}{address.District}{address.Line.ToString("")}";
                    pat.Address.Add(address);

                    var contact = new Patient.ContactComponent();
                    contact.Name = textContactName.GetHumanName();
                    contact.Relationship.Add(comboContactRelation.SelectedValue as CodeableConcept);
                    contact.Telecom.Add(new ContactPoint(ContactPoint.ContactPointSystem.Phone, ContactPoint.ContactPointUse.Home, textContactTelecom.Text));
                    pat.Contact.Add(contact);

                    pat.Meta = comboMeta.GetMeta();
                    Controller.Create(pat);

                    MsgBoxHelper.Info("建立完成");
                }
                else
                {
                    var pat = _source;
                    var identifierIdNo = new Identifier(PatientControl.SystemIdNo, textIdNo.Text);
                    identifierIdNo.Type = new CodeableConcept("http://terminology.hl7.org/CodeSystem/v2-0203", "NI");
                    var identifierChtNo = new Identifier(PatientControl.SystemChtNo, textChtNo.Text);
                    identifierChtNo.Type = new CodeableConcept("http://terminology.hl7.org/CodeSystem/v2-0203", "MR");
                    for (var i = 0; i < pat.Identifier.Count; i++)
                    {
                        if (pat.Identifier[i].System == PatientControl.SystemIdNo)
                            pat.Identifier[i].Value = textIdNo.Text;
                        else if (pat.Identifier[i].System == PatientControl.SystemChtNo)
                            pat.Identifier[i].Value = textChtNo.Text;
                    }

                    pat.Deceased = new FhirBoolean(checkDead.Checked);
                    pat.Gender = (AdministrativeGender)comboSex.SelectedValue;
                    while (pat.Name.Count > 0)
                        pat.Name.RemoveAt(0);
                    pat.Name.Add(textName.GetHumanName());
                    pat.BirthDate = textBirthDat.Text;

                    for (var i = 0; i < pat.Telecom.Count; i++)
                    {
                        if (pat.Telecom[i].System == ContactPoint.ContactPointSystem.Phone)
                            pat.Telecom[i].Value = textTelecom.Text;
                        else if (pat.Telecom[i].System == ContactPoint.ContactPointSystem.Email)
                            pat.Telecom[i].Value = textEmail.Text;
                        else if (pat.Telecom[i].System == ContactPoint.ContactPointSystem.Url)
                            pat.Telecom[i].Value = textPersonalUrl.Text;
                    }

                    pat.ManagingOrganization = ucOrg.GetResourceReference();
                    if (pat.Address.Count > 0)
                        pat.Address.RemoveAt(0);
                    var address = new Address();
                    address.PostalCode = Convert.ToString(comboDist.SelectedValue);
                    address.City = comboCity.Text;
                    address.District = comboDist.Text;
                    address.Country = "TW";
                    address.Line = textAddress.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                    address.Text = $"{address.PostalCode} {address.City}{address.District}{address.Line.ToString("")}";
                    pat.Address.Add(address);

                    if (pat.Contact.Count > 0)
                        pat.Contact.RemoveAt(0);
                    var contact = new Patient.ContactComponent();
                    contact.Name = textContactName.GetHumanName();
                    contact.Relationship.Add(comboContactRelation.SelectedValue as CodeableConcept);
                    contact.Telecom.Add(new ContactPoint(ContactPoint.ContactPointSystem.Phone, ContactPoint.ContactPointUse.Home, textContactTelecom.Text));
                    pat.Contact.Add(contact);
                    pat.Meta = comboMeta.GetMeta();
                    Controller.Update(pat);

                    MsgBoxHelper.Info("建立完成");



                    DialogResult = DialogResult.OK;
                }
            });
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public class ZipMap
        {
            private static readonly Dictionary<string, List<ZipMap>> _repository;
            static ZipMap()
            {
                var list = new List<ZipMap>
                   {
                       new ZipMap() { City = "基隆市", Dist = "仁愛區", Zip = 200 },
                       new ZipMap() { City = "基隆市", Dist = "信義區", Zip = 201 },
                       new ZipMap() { City = "基隆市", Dist = "中正區", Zip = 202 },
                       new ZipMap() { City = "基隆市", Dist = "中山區", Zip = 203 },
                       new ZipMap() { City = "基隆市", Dist = "安樂區", Zip = 204 },
                       new ZipMap() { City = "基隆市", Dist = "暖暖區", Zip = 205 },
                       new ZipMap() { City = "基隆市", Dist = "七堵區", Zip = 206 },

                       new ZipMap() { City = "台北市", Dist = "中正區", Zip = 100 },
                       new ZipMap() { City = "台北市", Dist = "大同區", Zip = 103 },
                       new ZipMap() { City = "台北市", Dist = "中山區", Zip = 104 },
                       new ZipMap() { City = "台北市", Dist = "松山區", Zip = 105 },
                       new ZipMap() { City = "台北市", Dist = "大安區", Zip = 106 },
                       new ZipMap() { City = "台北市", Dist = "萬華區", Zip = 108 },
                       new ZipMap() { City = "台北市", Dist = "信義區", Zip = 110 },
                       new ZipMap() { City = "台北市", Dist = "士林區", Zip = 111 },
                       new ZipMap() { City = "台北市", Dist = "北投區", Zip = 112 },
                       new ZipMap() { City = "台北市", Dist = "內湖區", Zip = 114 },
                       new ZipMap() { City = "台北市", Dist = "南港區", Zip = 115 },
                       new ZipMap() { City = "台北市", Dist = "文山區", Zip = 116 },

                       new ZipMap() { City = "新北市", Dist = "萬里區", Zip = 207 },
                       new ZipMap() { City = "新北市", Dist = "金山區", Zip = 208 },
                       new ZipMap() { City = "新北市", Dist = "板橋區", Zip = 220 },
                       new ZipMap() { City = "新北市", Dist = "汐止區", Zip = 221 },
                       new ZipMap() { City = "新北市", Dist = "深坑區", Zip = 222 },
                       new ZipMap() { City = "新北市", Dist = "石碇區", Zip = 223 },
                       new ZipMap() { City = "新北市", Dist = "瑞芳區", Zip = 224 },
                       new ZipMap() { City = "新北市", Dist = "平溪區", Zip = 226 },
                       new ZipMap() { City = "新北市", Dist = "雙溪區", Zip = 227 },
                       new ZipMap() { City = "新北市", Dist = "貢寮區", Zip = 228 },
                       new ZipMap() { City = "新北市", Dist = "新店區", Zip = 231 },
                       new ZipMap() { City = "新北市", Dist = "坪林區", Zip = 232 },
                       new ZipMap() { City = "新北市", Dist = "烏來區", Zip = 233 },
                       new ZipMap() { City = "新北市", Dist = "永和區", Zip = 234 },
                       new ZipMap() { City = "新北市", Dist = "中和區", Zip = 235 },
                       new ZipMap() { City = "新北市", Dist = "土城區", Zip = 236 },
                       new ZipMap() { City = "新北市", Dist = "三峽區", Zip = 237 },
                       new ZipMap() { City = "新北市", Dist = "樹林區", Zip = 238 },
                       new ZipMap() { City = "新北市", Dist = "鶯歌區", Zip = 239 },
                       new ZipMap() { City = "新北市", Dist = "三重區", Zip = 241 },
                       new ZipMap() { City = "新北市", Dist = "新莊區", Zip = 242 },
                       new ZipMap() { City = "新北市", Dist = "泰山區", Zip = 243 },
                       new ZipMap() { City = "新北市", Dist = "林口區", Zip = 244 },
                       new ZipMap() { City = "新北市", Dist = "蘆洲區", Zip = 247 },
                       new ZipMap() { City = "新北市", Dist = "五股區", Zip = 248 },
                       new ZipMap() { City = "新北市", Dist = "八里區", Zip = 249 },
                       new ZipMap() { City = "新北市", Dist = "淡水區", Zip = 251 },
                       new ZipMap() { City = "新北市", Dist = "三芝區", Zip = 252 },
                       new ZipMap() { City = "新北市", Dist = "石門區", Zip = 253 },

                       new ZipMap() { City = "桃園縣", Dist = "中壢市", Zip = 320 },
                       new ZipMap() { City = "桃園縣", Dist = "平鎮市", Zip = 324 },
                       new ZipMap() { City = "桃園縣", Dist = "龍潭鄉", Zip = 325 },
                       new ZipMap() { City = "桃園縣", Dist = "楊梅市", Zip = 326 },
                       new ZipMap() { City = "桃園縣", Dist = "新屋鄉", Zip = 327 },
                       new ZipMap() { City = "桃園縣", Dist = "觀音鄉", Zip = 328 },
                       new ZipMap() { City = "桃園縣", Dist = "桃園市", Zip = 330 },
                       new ZipMap() { City = "桃園縣", Dist = "龜山鄉", Zip = 333 },
                       new ZipMap() { City = "桃園縣", Dist = "八德市", Zip = 334 },
                       new ZipMap() { City = "桃園縣", Dist = "大溪鎮", Zip = 335 },
                       new ZipMap() { City = "桃園縣", Dist = "復興鄉", Zip = 336 },
                       new ZipMap() { City = "桃園縣", Dist = "大園鄉", Zip = 337 },
                       new ZipMap() { City = "桃園縣", Dist = "蘆竹鄉", Zip = 338 },

                       new ZipMap() { City = "新竹縣", Dist = "竹北市", Zip = 302 },
                       new ZipMap() { City = "新竹縣", Dist = "湖口鄉", Zip = 303 },
                       new ZipMap() { City = "新竹縣", Dist = "新豐鄉", Zip = 304 },
                       new ZipMap() { City = "新竹縣", Dist = "新埔鎮", Zip = 305 },
                       new ZipMap() { City = "新竹縣", Dist = "關西鎮", Zip = 306 },
                       new ZipMap() { City = "新竹縣", Dist = "芎林鄉", Zip = 307 },
                       new ZipMap() { City = "新竹縣", Dist = "寶山鄉", Zip = 308 },
                       new ZipMap() { City = "新竹縣", Dist = "竹東鎮", Zip = 310 },
                       new ZipMap() { City = "新竹縣", Dist = "五峰鄉", Zip = 311 },
                       new ZipMap() { City = "新竹縣", Dist = "橫山鄉", Zip = 312 },
                       new ZipMap() { City = "新竹縣", Dist = "尖石鄉", Zip = 313 },
                       new ZipMap() { City = "新竹縣", Dist = "北埔鄉", Zip = 314 },
                       new ZipMap() { City = "新竹縣", Dist = "峨眉鄉", Zip = 315 },

                       new ZipMap() { City = "苗栗縣", Dist = "竹南鎮", Zip = 350 },
                       new ZipMap() { City = "苗栗縣", Dist = "頭份鎮", Zip = 351 },
                       new ZipMap() { City = "苗栗縣", Dist = "三灣鄉", Zip = 352 },
                       new ZipMap() { City = "苗栗縣", Dist = "南庄鄉", Zip = 353 },
                       new ZipMap() { City = "苗栗縣", Dist = "獅潭鄉", Zip = 354 },
                       new ZipMap() { City = "苗栗縣", Dist = "後龍鎮", Zip = 356 },
                       new ZipMap() { City = "苗栗縣", Dist = "通霄鎮", Zip = 357 },
                       new ZipMap() { City = "苗栗縣", Dist = "苑裡鎮", Zip = 358 },
                       new ZipMap() { City = "苗栗縣", Dist = "苗栗市", Zip = 360 },
                       new ZipMap() { City = "苗栗縣", Dist = "造橋鄉", Zip = 361 },
                       new ZipMap() { City = "苗栗縣", Dist = "頭屋鄉", Zip = 362 },
                       new ZipMap() { City = "苗栗縣", Dist = "公館鄉", Zip = 363 },
                       new ZipMap() { City = "苗栗縣", Dist = "大湖鄉", Zip = 364 },
                       new ZipMap() { City = "苗栗縣", Dist = "泰安鄉", Zip = 365 },
                       new ZipMap() { City = "苗栗縣", Dist = "銅鑼鄉", Zip = 366 },
                       new ZipMap() { City = "苗栗縣", Dist = "三義鄉", Zip = 367 },
                       new ZipMap() { City = "苗栗縣", Dist = "西湖鄉", Zip = 368 },
                       new ZipMap() { City = "苗栗縣", Dist = "卓蘭鎮", Zip = 369 },

                       new ZipMap() { City = "台中市", Dist = "中區", Zip = 400  },
                       new ZipMap() { City = "台中市", Dist = "東區", Zip = 401  },
                       new ZipMap() { City = "台中市", Dist = "南區", Zip = 402  },
                       new ZipMap() { City = "台中市", Dist = "西區", Zip = 403  },
                       new ZipMap() { City = "台中市", Dist = "北區", Zip = 404  },
                       new ZipMap() { City = "台中市", Dist = "北屯區", Zip = 406  },
                       new ZipMap() { City = "台中市", Dist = "西屯區", Zip = 407  },
                       new ZipMap() { City = "台中市", Dist = "南屯區", Zip = 408  },
                       new ZipMap() { City = "台中市", Dist = "太平區", Zip = 411  },
                       new ZipMap() { City = "台中市", Dist = "大里區", Zip = 412  },
                       new ZipMap() { City = "台中市", Dist = "霧峰區", Zip = 413  },
                       new ZipMap() { City = "台中市", Dist = "烏日區", Zip = 414  },
                       new ZipMap() { City = "台中市", Dist = "豐原區", Zip = 420  },
                       new ZipMap() { City = "台中市", Dist = "后里區", Zip = 421  },
                       new ZipMap() { City = "台中市", Dist = "石岡區", Zip = 422  },
                       new ZipMap() { City = "台中市", Dist = "東勢區", Zip = 423  },
                       new ZipMap() { City = "台中市", Dist = "和平區", Zip = 424  },
                       new ZipMap() { City = "台中市", Dist = "新社區", Zip = 426  },
                       new ZipMap() { City = "台中市", Dist = "潭子區", Zip = 427  },
                       new ZipMap() { City = "台中市", Dist = "大雅區", Zip = 428  },
                       new ZipMap() { City = "台中市", Dist = "神岡區", Zip = 429  },
                       new ZipMap() { City = "台中市", Dist = "大肚區", Zip = 432  },
                       new ZipMap() { City = "台中市", Dist = "沙鹿區", Zip = 433  },
                       new ZipMap() { City = "台中市", Dist = "龍井區", Zip = 434  },
                       new ZipMap() { City = "台中市", Dist = "梧棲區", Zip = 435  },
                       new ZipMap() { City = "台中市", Dist = "清水區", Zip = 436  },
                       new ZipMap() { City = "台中市", Dist = "大甲區", Zip = 437  },
                       new ZipMap() { City = "台中市", Dist = "外埔區", Zip = 438  },
                       new ZipMap() { City = "台中市", Dist = "大安區", Zip = 439  },

                       new ZipMap() { City = "彰化縣", Dist = "彰化市", Zip = 500 },
                       new ZipMap() { City = "彰化縣", Dist = "芬園鄉", Zip = 502 },
                       new ZipMap() { City = "彰化縣", Dist = "花壇鄉", Zip = 503 },
                       new ZipMap() { City = "彰化縣", Dist = "秀水鄉", Zip = 504 },
                       new ZipMap() { City = "彰化縣", Dist = "鹿港鎮", Zip = 505 },
                       new ZipMap() { City = "彰化縣", Dist = "福興鄉", Zip = 506 },
                       new ZipMap() { City = "彰化縣", Dist = "線西鄉", Zip = 507 },
                       new ZipMap() { City = "彰化縣", Dist = "和美鎮", Zip = 508 },
                       new ZipMap() { City = "彰化縣", Dist = "伸港鄉", Zip = 509 },
                       new ZipMap() { City = "彰化縣", Dist = "員林鎮", Zip = 510 },
                       new ZipMap() { City = "彰化縣", Dist = "社頭鄉", Zip = 511 },
                       new ZipMap() { City = "彰化縣", Dist = "永靖鄉", Zip = 512 },
                       new ZipMap() { City = "彰化縣", Dist = "埔心鄉", Zip = 513 },
                       new ZipMap() { City = "彰化縣", Dist = "溪湖鎮", Zip = 514 },
                       new ZipMap() { City = "彰化縣", Dist = "大村鄉", Zip = 515 },
                       new ZipMap() { City = "彰化縣", Dist = "埔鹽鄉", Zip = 516 },
                       new ZipMap() { City = "彰化縣", Dist = "田中鎮", Zip = 520 },
                       new ZipMap() { City = "彰化縣", Dist = "北斗鎮", Zip = 521 },
                       new ZipMap() { City = "彰化縣", Dist = "田尾鄉", Zip = 522 },
                       new ZipMap() { City = "彰化縣", Dist = "埤頭鄉", Zip = 523 },
                       new ZipMap() { City = "彰化縣", Dist = "溪州鄉", Zip = 524 },
                       new ZipMap() { City = "彰化縣", Dist = "竹塘鄉", Zip = 525 },
                       new ZipMap() { City = "彰化縣", Dist = "二林鎮", Zip = 526 },
                       new ZipMap() { City = "彰化縣", Dist = "大城鄉", Zip = 527 },
                       new ZipMap() { City = "彰化縣", Dist = "芳苑鄉", Zip = 528 },
                       new ZipMap() { City = "彰化縣", Dist = "二水鄉", Zip = 530 },

                       new ZipMap() { City = "南投縣", Dist = "南投市", Zip = 540 },
                       new ZipMap() { City = "南投縣", Dist = "中寮鄉", Zip = 541 },
                       new ZipMap() { City = "南投縣", Dist = "草屯鎮", Zip = 542 },
                       new ZipMap() { City = "南投縣", Dist = "國姓鄉", Zip = 544 },
                       new ZipMap() { City = "南投縣", Dist = "埔里鎮", Zip = 545 },
                       new ZipMap() { City = "南投縣", Dist = "仁愛鄉", Zip = 546 },
                       new ZipMap() { City = "南投縣", Dist = "名間鄉", Zip = 551 },
                       new ZipMap() { City = "南投縣", Dist = "集集鎮", Zip = 552 },
                       new ZipMap() { City = "南投縣", Dist = "水里鄉", Zip = 553 },
                       new ZipMap() { City = "南投縣", Dist = "魚池鄉", Zip = 555 },
                       new ZipMap() { City = "南投縣", Dist = "信義鄉", Zip = 556 },
                       new ZipMap() { City = "南投縣", Dist = "竹山鎮", Zip = 557 },
                       new ZipMap() { City = "南投縣", Dist = "鹿谷鄉", Zip = 558 },

                       new ZipMap() { City = "雲林縣", Dist = "斗南鎮", Zip = 630 },
                       new ZipMap() { City = "雲林縣", Dist = "大埤鄉", Zip = 631 },
                       new ZipMap() { City = "雲林縣", Dist = "虎尾鎮", Zip = 632 },
                       new ZipMap() { City = "雲林縣", Dist = "土庫鎮", Zip = 633 },
                       new ZipMap() { City = "雲林縣", Dist = "褒忠鄉", Zip = 634 },
                       new ZipMap() { City = "雲林縣", Dist = "東勢鄉", Zip = 635 },
                       new ZipMap() { City = "雲林縣", Dist = "台西鄉", Zip = 636 },
                       new ZipMap() { City = "雲林縣", Dist = "崙背鄉", Zip = 637 },
                       new ZipMap() { City = "雲林縣", Dist = "麥寮鄉", Zip = 638 },
                       new ZipMap() { City = "雲林縣", Dist = "斗六市", Zip = 640 },
                       new ZipMap() { City = "雲林縣", Dist = "林內鄉", Zip = 643 },
                       new ZipMap() { City = "雲林縣", Dist = "古坑鄉", Zip = 646 },
                       new ZipMap() { City = "雲林縣", Dist = "莿桐鄉", Zip = 647 },
                       new ZipMap() { City = "雲林縣", Dist = "西螺鎮", Zip = 648 },
                       new ZipMap() { City = "雲林縣", Dist = "二崙鄉", Zip = 649 },
                       new ZipMap() { City = "雲林縣", Dist = "北港鎮", Zip = 651 },
                       new ZipMap() { City = "雲林縣", Dist = "水林鄉", Zip = 652 },
                       new ZipMap() { City = "雲林縣", Dist = "口湖鄉", Zip = 653 },
                       new ZipMap() { City = "雲林縣", Dist = "四湖鄉", Zip = 654 },
                       new ZipMap() { City = "雲林縣", Dist = "元長鄉", Zip = 655 },

                       new ZipMap() { City = "嘉義縣", Dist = "番路鄉", Zip = 602 },
                       new ZipMap() { City = "嘉義縣", Dist = "梅山鄉", Zip = 603 },
                       new ZipMap() { City = "嘉義縣", Dist = "竹崎鄉", Zip = 604 },
                       new ZipMap() { City = "嘉義縣", Dist = "阿里山鄉", Zip = 605 },
                       new ZipMap() { City = "嘉義縣", Dist = "中埔鄉", Zip = 606 },
                       new ZipMap() { City = "嘉義縣", Dist = "大埔鄉", Zip = 607 },
                       new ZipMap() { City = "嘉義縣", Dist = "水上鄉", Zip = 608 },
                       new ZipMap() { City = "嘉義縣", Dist = "鹿草鄉", Zip = 611 },
                       new ZipMap() { City = "嘉義縣", Dist = "太保市", Zip = 612 },
                       new ZipMap() { City = "嘉義縣", Dist = "朴子市", Zip = 613 },
                       new ZipMap() { City = "嘉義縣", Dist = "東石鄉", Zip = 614 },
                       new ZipMap() { City = "嘉義縣", Dist = "六腳鄉", Zip = 615 },
                       new ZipMap() { City = "嘉義縣", Dist = "新港鄉", Zip = 616 },
                       new ZipMap() { City = "嘉義縣", Dist = "民雄鄉", Zip = 621 },
                       new ZipMap() { City = "嘉義縣", Dist = "大林鎮", Zip = 622 },
                       new ZipMap() { City = "嘉義縣", Dist = "溪口鄉", Zip = 623 },
                       new ZipMap() { City = "嘉義縣", Dist = "義竹鄉", Zip = 624 },
                       new ZipMap() { City = "嘉義縣", Dist = "布袋鎮", Zip = 625 },

                       new ZipMap() { City = "台南市", Dist = "中西區", Zip =  700 },
                       new ZipMap() { City = "台南市", Dist = "東區", Zip =  701 },
                       new ZipMap() { City = "台南市", Dist = "南區", Zip =  702 },
                       new ZipMap() { City = "台南市", Dist = "北區", Zip =  704 },
                       new ZipMap() { City = "台南市", Dist = "安平區", Zip = 708 },
                       new ZipMap() { City = "台南市", Dist = "安南區", Zip = 709 },
                       new ZipMap() { City = "台南市", Dist = "永康區", Zip = 710 },
                       new ZipMap() { City = "台南市", Dist = "歸仁區", Zip = 711 },
                       new ZipMap() { City = "台南市", Dist = "新化區", Zip = 712 },
                       new ZipMap() { City = "台南市", Dist = "左鎮區", Zip = 713 },
                       new ZipMap() { City = "台南市", Dist = "玉井區", Zip = 714 },
                       new ZipMap() { City = "台南市", Dist = "楠西區", Zip = 715 },
                       new ZipMap() { City = "台南市", Dist = "南化區", Zip = 716 },
                       new ZipMap() { City = "台南市", Dist = "仁德區", Zip = 717 },
                       new ZipMap() { City = "台南市", Dist = "關廟區", Zip = 718 },
                       new ZipMap() { City = "台南市", Dist = "龍崎區", Zip = 719 },
                       new ZipMap() { City = "台南市", Dist = "官田區", Zip = 720 },
                       new ZipMap() { City = "台南市", Dist = "麻豆區", Zip = 721 },
                       new ZipMap() { City = "台南市", Dist = "佳里區", Zip = 722 },
                       new ZipMap() { City = "台南市", Dist = "西港區", Zip = 723 },
                       new ZipMap() { City = "台南市", Dist = "七股區", Zip = 724 },
                       new ZipMap() { City = "台南市", Dist = "將軍區", Zip = 725 },
                       new ZipMap() { City = "台南市", Dist = "學甲區", Zip = 726 },
                       new ZipMap() { City = "台南市", Dist = "北門區", Zip = 727 },
                       new ZipMap() { City = "台南市", Dist = "新營區", Zip = 730 },
                       new ZipMap() { City = "台南市", Dist = "後壁區", Zip = 731 },
                       new ZipMap() { City = "台南市", Dist = "白河區", Zip = 732 },
                       new ZipMap() { City = "台南市", Dist = "東山區", Zip = 733 },
                       new ZipMap() { City = "台南市", Dist = "六甲區", Zip = 734 },
                       new ZipMap() { City = "台南市", Dist = "下營區", Zip = 735 },
                       new ZipMap() { City = "台南市", Dist = "柳營區", Zip = 736 },
                       new ZipMap() { City = "台南市", Dist = "鹽水區", Zip = 737 },
                       new ZipMap() { City = "台南市", Dist = "善化區", Zip = 741 },
                       new ZipMap() { City = "台南市", Dist = "大內區", Zip = 742 },
                       new ZipMap() { City = "台南市", Dist = "山上區", Zip = 743 },
                       new ZipMap() { City = "台南市", Dist = "新市區", Zip = 744 },
                       new ZipMap() { City = "台南市", Dist = "安定區", Zip = 745 },

                       new ZipMap() { City = "高雄市", Dist = "新興區", Zip = 800 },
                       new ZipMap() { City = "高雄市", Dist = "前金區", Zip = 801 },
                       new ZipMap() { City = "高雄市", Dist = "苓雅區", Zip = 802 },
                       new ZipMap() { City = "高雄市", Dist = "鹽埕區", Zip = 803 },
                       new ZipMap() { City = "高雄市", Dist = "鼓山區", Zip = 804 },
                       new ZipMap() { City = "高雄市", Dist = "旗津區", Zip = 805 },
                       new ZipMap() { City = "高雄市", Dist = "前鎮區", Zip = 806 },
                       new ZipMap() { City = "高雄市", Dist = "三民區", Zip = 807 },
                       new ZipMap() { City = "高雄市", Dist = "楠梓區", Zip = 811 },
                       new ZipMap() { City = "高雄市", Dist = "小港區", Zip = 812 },
                       new ZipMap() { City = "高雄市", Dist = "左營區", Zip = 813 },
                       new ZipMap() { City = "高雄市", Dist = "仁武區", Zip = 814 },
                       new ZipMap() { City = "高雄市", Dist = "大社區", Zip = 815 },
                       new ZipMap() { City = "高雄市", Dist = "岡山區", Zip = 820 },
                       new ZipMap() { City = "高雄市", Dist = "路竹區", Zip = 821 },
                       new ZipMap() { City = "高雄市", Dist = "阿蓮區", Zip = 822 },
                       new ZipMap() { City = "高雄市", Dist = "田寮區", Zip = 823 },
                       new ZipMap() { City = "高雄市", Dist = "燕巢區", Zip = 824 },
                       new ZipMap() { City = "高雄市", Dist = "橋頭區", Zip = 825 },
                       new ZipMap() { City = "高雄市", Dist = "梓官區", Zip = 826 },
                       new ZipMap() { City = "高雄市", Dist = "彌陀區", Zip = 827 },
                       new ZipMap() { City = "高雄市", Dist = "永安區", Zip = 828 },
                       new ZipMap() { City = "高雄市", Dist = "湖內區", Zip = 829 },
                       new ZipMap() { City = "高雄市", Dist = "鳳山區", Zip = 830 },
                       new ZipMap() { City = "高雄市", Dist = "大寮區", Zip = 831 },
                       new ZipMap() { City = "高雄市", Dist = "林園區", Zip = 832 },
                       new ZipMap() { City = "高雄市", Dist = "鳥松區", Zip = 833 },
                       new ZipMap() { City = "高雄市", Dist = "大樹區", Zip = 840 },
                       new ZipMap() { City = "高雄市", Dist = "旗山區", Zip = 842 },
                       new ZipMap() { City = "高雄市", Dist = "美濃區", Zip = 843 },
                       new ZipMap() { City = "高雄市", Dist = "六龜區", Zip = 844 },
                       new ZipMap() { City = "高雄市", Dist = "內門區", Zip = 845 },
                       new ZipMap() { City = "高雄市", Dist = "杉林區", Zip = 846 },
                       new ZipMap() { City = "高雄市", Dist = "甲仙區", Zip = 847 },
                       new ZipMap() { City = "高雄市", Dist = "桃源區", Zip = 848 },
                       new ZipMap() { City = "高雄市", Dist = "那瑪夏區", Zip = 849 },
                       new ZipMap() { City = "高雄市", Dist = "茂林區", Zip = 851 },
                       new ZipMap() { City = "高雄市", Dist = "茄萣區", Zip = 852 },

                       new ZipMap() { City = "屏東縣", Dist = "屏東市", Zip = 900 },
                       new ZipMap() { City = "屏東縣", Dist = "三地門鄉", Zip = 901 },
                       new ZipMap() { City = "屏東縣", Dist = "霧台鄉", Zip = 902 },
                       new ZipMap() { City = "屏東縣", Dist = "瑪家鄉", Zip = 903 },
                       new ZipMap() { City = "屏東縣", Dist = "九如鄉", Zip = 904 },
                       new ZipMap() { City = "屏東縣", Dist = "里港鄉", Zip = 905 },
                       new ZipMap() { City = "屏東縣", Dist = "高樹鄉", Zip = 906 },
                       new ZipMap() { City = "屏東縣", Dist = "鹽埔鄉", Zip = 907 },
                       new ZipMap() { City = "屏東縣", Dist = "長治鄉", Zip = 908 },
                       new ZipMap() { City = "屏東縣", Dist = "麟洛鄉", Zip = 909 },
                       new ZipMap() { City = "屏東縣", Dist = "竹田鄉", Zip = 911 },
                       new ZipMap() { City = "屏東縣", Dist = "內埔鄉", Zip = 912 },
                       new ZipMap() { City = "屏東縣", Dist = "萬丹鄉", Zip = 913 },
                       new ZipMap() { City = "屏東縣", Dist = "潮州鎮", Zip = 920 },
                       new ZipMap() { City = "屏東縣", Dist = "泰武鄉", Zip = 921 },
                       new ZipMap() { City = "屏東縣", Dist = "來義鄉", Zip = 922 },
                       new ZipMap() { City = "屏東縣", Dist = "萬巒鄉", Zip = 923 },
                       new ZipMap() { City = "屏東縣", Dist = "崁頂鄉", Zip = 924 },
                       new ZipMap() { City = "屏東縣", Dist = "新埤鄉", Zip = 925 },
                       new ZipMap() { City = "屏東縣", Dist = "南州鄉", Zip = 926 },
                       new ZipMap() { City = "屏東縣", Dist = "林邊鄉", Zip = 927 },
                       new ZipMap() { City = "屏東縣", Dist = "東港鎮", Zip = 928 },
                       new ZipMap() { City = "屏東縣", Dist = "琉球鄉", Zip = 929 },
                       new ZipMap() { City = "屏東縣", Dist = "佳冬鄉", Zip = 931 },
                       new ZipMap() { City = "屏東縣", Dist = "新園鄉", Zip = 932 },
                       new ZipMap() { City = "屏東縣", Dist = "枋寮鄉", Zip = 940 },
                       new ZipMap() { City = "屏東縣", Dist = "枋山鄉", Zip = 941 },
                       new ZipMap() { City = "屏東縣", Dist = "春日鄉", Zip = 942 },
                       new ZipMap() { City = "屏東縣", Dist = "獅子鄉", Zip = 943 },
                       new ZipMap() { City = "屏東縣", Dist = "車城鄉", Zip = 944 },
                       new ZipMap() { City = "屏東縣", Dist = "牡丹鄉", Zip = 945 },
                       new ZipMap() { City = "屏東縣", Dist = "恆春鎮", Zip = 946 },
                       new ZipMap() { City = "屏東縣", Dist = "滿州鄉", Zip = 947 },

                       new ZipMap() { City = "台東縣", Dist = "台東市", Zip = 950 },
                       new ZipMap() { City = "台東縣", Dist = "綠島鄉", Zip = 951 },
                       new ZipMap() { City = "台東縣", Dist = "蘭嶼鄉", Zip = 952 },
                       new ZipMap() { City = "台東縣", Dist = "延平鄉", Zip = 953 },
                       new ZipMap() { City = "台東縣", Dist = "卑南鄉", Zip = 954 },
                       new ZipMap() { City = "台東縣", Dist = "鹿野鄉", Zip = 955 },
                       new ZipMap() { City = "台東縣", Dist = "關山鎮", Zip = 956 },
                       new ZipMap() { City = "台東縣", Dist = "海端鄉", Zip = 957 },
                       new ZipMap() { City = "台東縣", Dist = "池上鄉", Zip = 958 },
                       new ZipMap() { City = "台東縣", Dist = "東河鄉", Zip = 959 },
                       new ZipMap() { City = "台東縣", Dist = "成功鎮", Zip = 961 },
                       new ZipMap() { City = "台東縣", Dist = "長濱鄉", Zip = 962 },
                       new ZipMap() { City = "台東縣", Dist = "太麻里鄉", Zip = 963 },
                       new ZipMap() { City = "台東縣", Dist = "金峰鄉", Zip = 964 },
                       new ZipMap() { City = "台東縣", Dist = "大武鄉", Zip = 965 },
                       new ZipMap() { City = "台東縣", Dist = "達仁鄉", Zip = 966 },

                       new ZipMap() { City = "花蓮縣", Dist = "花蓮市", Zip = 970 },
                       new ZipMap() { City = "花蓮縣", Dist = "新城鄉", Zip = 971 },
                       new ZipMap() { City = "花蓮縣", Dist = "秀林鄉", Zip = 972 },
                       new ZipMap() { City = "花蓮縣", Dist = "吉安鄉", Zip = 973 },
                       new ZipMap() { City = "花蓮縣", Dist = "壽豐鄉", Zip = 974 },
                       new ZipMap() { City = "花蓮縣", Dist = "鳳林鎮", Zip = 975 },
                       new ZipMap() { City = "花蓮縣", Dist = "光復鄉", Zip = 976 },
                       new ZipMap() { City = "花蓮縣", Dist = "豐濱鄉", Zip = 977 },
                       new ZipMap() { City = "花蓮縣", Dist = "瑞穗鄉", Zip = 978 },
                       new ZipMap() { City = "花蓮縣", Dist = "萬榮鄉", Zip = 979 },
                       new ZipMap() { City = "花蓮縣", Dist = "玉里鎮", Zip = 981 },
                       new ZipMap() { City = "花蓮縣", Dist = "卓溪鄉", Zip = 982 },
                       new ZipMap() { City = "花蓮縣", Dist = "富里鄉", Zip = 983 },

                       new ZipMap() { City = "新竹市", Dist = "", Zip = 300 },
                       new ZipMap() { City = "新竹市", Dist = "東區", Zip =300 },
                       new ZipMap() { City = "新竹市", Dist = "北區", Zip =300 },
                       new ZipMap() { City = "新竹市", Dist = "香山區", Zip =300 },

                       new ZipMap() { City = "嘉義市", Dist = "", Zip = 600 },
                       new ZipMap() { City = "嘉義市", Dist = "東區", Zip = 600 },
                       new ZipMap() { City = "嘉義市", Dist = "西區", Zip = 600 }
                   };
                _repository = list.GroupBy(r => r.City).ToDictionary(r => r.Key, r => r.ToList());
            }
            public static Dictionary<string, List<ZipMap>> Map
            {
                get { return _repository; }
            }

            public string City { get; set; }
            public string Dist { get; set; }
            public short Zip { get; set; }


        }


    }

}
