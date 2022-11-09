using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telemedicine
{
    public class VitalSign
    {
        public VitalSign(string code, string item, string itemName, string unit,
            string category = "vital-signs",
            string categoryDisplay = "Vital Signs",
            string codeSystem = "http://loinc.org",
            string categorySystem = "http://terminology.hl7.org/CodeSystem/observation-category",
            string unitSystem = "http://unitsofmeasure.org", List<BodySiteObj> bodySite = null, ValueSpec[] valueSpecs = null)
        {
            Item = item;
            ItemDisplay = itemName;
            Category = category;
            CategorySystem = categorySystem;
            CategoryDisplay = categoryDisplay;
            Code = code;
            CodeSystem = codeSystem;
            Unit = unit;
            UnitSystem = unitSystem;
            BodySite = bodySite;
            ValueSpecs = valueSpecs;
        }

        public string ItemDisplay { get; set; }
        public string Item { get; set; }
        public string Category { get; set; }
        public string CategorySystem { get; set; }
        public string CategoryDisplay { get; set; }
        public string Code { get; set; }
        public string CodeSystem { get; set; }
        public string Unit { get; set; }
        public string UnitSystem { get; set; }
        public List<BodySiteObj> BodySite { get; set; }
        public ValueSpec[] ValueSpecs { get; set; }

        public override string ToString()
        {
            return string.Format("{0} ({1})", ItemDisplay, Item);
        }

        public static VitalSign BodyHeight = new VitalSign("3137-7", "Body Height", "身高", "cm");
        public static VitalSign BodyWeight = new VitalSign("29463-7", "Body Weight", "體重", "kg");
        public static VitalSign BodyTemperature = new VitalSign("8310-5", "Body Temperature", "體溫", "Cel");
        public static VitalSign BloodGlucosePreMeal = new VitalSign("88365-2", "Blood Glucose Pre Meal", "進食前血糖", "mg/dL", "laboratory", "Laboratory");
        public static VitalSign BloodGlucosePostMeal = new VitalSign("87422-2", "Blood Glucose Post Meal", "進食後血糖", "mg/dL", "laboratory", "Laboratory");
        public static VitalSign PercentageOfBodyFat = new VitalSign("41982-0", "Percentage of body fat Measured", "體脂率", "%");
        public static VitalSign GripStrengthHand = new VitalSign("83174-3", "Grip strength Hand - right Dynamometer", "握力", "kg");
        public static VitalSign Oxygen = new VitalSign("59408-5", "Oxygen saturation in Arterial blood by Pulse oximetry", "SPO2血氧飽和濃度", "%");
        public static VitalSign HeartRate = new VitalSign("8867-4", "Heart Rate", "心率", "{beats}/min");
        public static VitalSign SystolicBloodPressure = new VitalSign("8480-6", "Systolic Blood Pressure", "收縮壓", "mm[Hg]");
        public static VitalSign DistolicBloodPressure = new VitalSign("8462-4", "Distolic Blood Pressure", "舒張壓", "mm[Hg]");
        public static VitalSign Capillary = new VitalSign("44963-7", "Capillary refill [Time] of Nail bed", "Capillary refill [Time] of Nail bed", "s", "exam", "Exam");
        public static VitalSign Glucose = new VitalSign("2339-0", "Glucose [Mass/volume] in Blood", "Glucose [Mass/volume] in Blood", "mg/dL", "laboratory", "Laboratory");
        public static VitalSign RespiratoryRate = new VitalSign("9279-1", "Respiratory Rate", "Respiratory Rate", "{counts/min}");
        public static VitalSign BloodPressurePanel = new VitalSign("35094-2", "Blood pressure panel", "血壓", "mmHg", valueSpecs: new ValueSpec[] {
            new ValueSpec(SystolicBloodPressure),
            new ValueSpec(DistolicBloodPressure),
        });


        public CodeableConcept GetCategory()
        {
            return new CodeableConcept(CategorySystem, Category, CategoryDisplay, CategoryDisplay);
        }

        public CodeableConcept GetCode()
        {
            return new CodeableConcept(CodeSystem, Code, Item, ItemDisplay);
        }


        public static List<BodySiteObj> FemoralBodySites
            = new List<BodySiteObj>
            {
                new BodySiteObj("Ward's area", "Ward 三角"),
                new BodySiteObj("Femoral body", "股骨幹"),
                new BodySiteObj("Femoral neck", "股骨頸"),
                new BodySiteObj("Total Femur", "股骨全部"),
            };
        public static VitalSign Femoral = new VitalSign("38263-0", "DXA Femur [T-score] Bone density", "股骨骨密度", "{T-score}"
                                                                , "imaging", "Imaging"
                                                                  , bodySite: FemoralBodySites);
        public static VitalSign LeftFemoral = new VitalSign("80948-3", "DXA Femur - Left [T-score] Bone density", "左股骨骨密度", "{T-score}"
                                                                , "imaging", "Imaging"
                                                                  , bodySite: FemoralBodySites);
        public static VitalSign RightFemoral = new VitalSign("80947-5", "DXA Femur [T-score] Bone density", "右股骨骨密度", "{T-score}"
                                                                , "imaging", "Imaging"
                                                                  , bodySite: FemoralBodySites);
        public static VitalSign LumbarSpine = new VitalSign("38263-0", "DXA Lumbar spine [T-score] Bone density", "腰椎骨密度", "{T-score}"
                                                                , "imaging", "Imaging"
                                                                  , bodySite: new List<BodySiteObj>
                                                                  {
                                                                      new BodySiteObj("Lumbar spine L1", "腰椎第一節"),
                                                                      new BodySiteObj("Lumbar spine L2", "腰椎第二節"),
                                                                      new BodySiteObj("Lumbar spine L3", "腰椎第三節"),
                                                                      new BodySiteObj("Lumbar spine L4", "腰椎第四節"),
                                                                      new BodySiteObj("Lumbar spine L1~L2", "腰椎第一~二節"),
                                                                      new BodySiteObj("Lumbar spine L1~L3", "腰椎第一~三節"),
                                                                      new BodySiteObj("Lumbar spine L1~L4", "腰椎第一~四節"),
                                                                      new BodySiteObj("Lumbar spine L2~L3", "腰椎第二~三節"),
                                                                      new BodySiteObj("Lumbar spine L2~L4", "腰椎第二~四節"),
                                                                      new BodySiteObj("Lumbar spine L3~L4", "腰椎第三~四節"),
                                                                  });
        //public static VitalSign Tempalte = new VitalSign("", "", "", "");

        public static VitalSign ECG_Lead_I = new VitalSign("131329", "MDC_ECG_ELEC_POTL_I", "Lead I", "mm[Hg]", "procedure", "Procedure", "urn:oid:2.16.840.1.113883.6.24");
        public static VitalSign ECG_Lead_II = new VitalSign("131330", "MDC_ECG_ELEC_POTL_II", "Lead II", "mm[Hg]", "procedure", "Procedure", "urn:oid:2.16.840.1.113883.6.24");
        public static VitalSign ECG_Lead_III = new VitalSign("131389", "MDC_ECG_ELEC_POTL_III", "Lead III", "mm[Hg]", "procedure", "Procedure", "urn:oid:2.16.840.1.113883.6.24");
        public static VitalSign ECG_Lead_AVR = new VitalSign("131390", "MDC_ECG_ELEC_POTL_AVR", "Lead AVR", "mm[Hg]", "procedure", "Procedure", "urn:oid:2.16.840.1.113883.6.24");
        public static VitalSign ECG_Lead_AVL = new VitalSign("131391", "MDC_ECG_ELEC_POTL_AVL", "Lead AVL", "mm[Hg]", "procedure", "Procedure", "urn:oid:2.16.840.1.113883.6.24");
        public static VitalSign ECG_Lead_AVF = new VitalSign("131392", "MDC_ECG_ELEC_POTL_AVF", "Lead AVF", "mm[Hg]", "procedure", "Procedure", "urn:oid:2.16.840.1.113883.6.24");
        public static VitalSign ECG_Lead_V1 = new VitalSign("131331", "MDC_ECG_ELEC_POTL_V1", "Lead V1", "mm[Hg]", "procedure", "Procedure", "urn:oid:2.16.840.1.113883.6.24");
        public static VitalSign ECG_Lead_V2 = new VitalSign("131332", "MDC_ECG_ELEC_POTL_V2", "Lead V2", "mm[Hg]", "procedure", "Procedure", "urn:oid:2.16.840.1.113883.6.24");
        public static VitalSign ECG_Lead_V3 = new VitalSign("131333", "MDC_ECG_ELEC_POTL_V3", "Lead V3", "mm[Hg]", "procedure", "Procedure", "urn:oid:2.16.840.1.113883.6.24");
        public static VitalSign ECG_Lead_V4 = new VitalSign("131334", "MDC_ECG_ELEC_POTL_V4", "Lead V4", "mm[Hg]", "procedure", "Procedure", "urn:oid:2.16.840.1.113883.6.24");
        public static VitalSign ECG_Lead_V5 = new VitalSign("131335", "MDC_ECG_ELEC_POTL_V5", "Lead V5", "mm[Hg]", "procedure", "Procedure", "urn:oid:2.16.840.1.113883.6.24");
        public static VitalSign ECG_Lead_V6 = new VitalSign("131336", "MDC_ECG_ELEC_POTL_V6", "Lead V6", "mm[Hg]", "procedure", "Procedure", "urn:oid:2.16.840.1.113883.6.24");

        public static VitalSign ECG = new VitalSign("131328", "MDC_ECG_ELEC_POTL", "心電圖", "mm[Hg]", "procedure", "Procedure", "urn:oid:2.16.840.1.113883.6.24",
            valueSpecs: new ValueSpec[] {
                new ValueSpec(ECG_Lead_I),
                new ValueSpec(ECG_Lead_II),
                new ValueSpec(ECG_Lead_III),
                new ValueSpec(ECG_Lead_AVR),
                new ValueSpec(ECG_Lead_AVL),
                new ValueSpec(ECG_Lead_AVF),
                new ValueSpec(ECG_Lead_V1),
                new ValueSpec(ECG_Lead_V2),
                new ValueSpec(ECG_Lead_V3),
                new ValueSpec(ECG_Lead_V4),
                new ValueSpec(ECG_Lead_V5),
                new ValueSpec(ECG_Lead_V6),
            });
        public class BodySiteObj
        {
            public BodySiteObj(string code, string display, string system = "https://mitw.dicom.org.tw/MITW%20WG2%20Vital%20Sign%20Code%20System.xlsx")
            {
                Code = code;
                CodeDisplay = display;
                CodeSystem = system;
            }
            public string Code { get; set; }
            public string CodeDisplay { get; set; }
            public string CodeSystem { get; set; }
            public CodeableConcept GetCodeableConcept()
            {
                return new CodeableConcept(CodeSystem, Code, CodeDisplay);
            }
            public Coding GetCode()
            {

                return new Coding(CodeSystem, Code, CodeDisplay);
            }
        }


        public class ValueSpec
        {
            public ValueSpec(VitalSign vitalSign)
            {
                VitalSign = vitalSign;
            }

            public VitalSign VitalSign { get; }

            public CodeableConcept GetCodeableConcept()
            {
                return new CodeableConcept(VitalSign.CodeSystem,
                               VitalSign.Code,
                               VitalSign.Item,
                               VitalSign.ItemDisplay);
            }
        }

        public static VitalSign[] VitalSigns { get; private set; }= new VitalSign[]
        {
            BodyHeight,
            BodyWeight,
            BodyTemperature,
            BloodGlucosePostMeal,
            BloodGlucosePreMeal,
            PercentageOfBodyFat,
            GripStrengthHand,
            Oxygen,
            HeartRate,
            BloodPressurePanel,
            SystolicBloodPressure,
            DistolicBloodPressure,
            Femoral,
            LeftFemoral,
            RightFemoral,
            LumbarSpine,
            Capillary,
            RespiratoryRate,
            Glucose,
            ECG,
            ECG_Lead_I,
            ECG_Lead_II,
            ECG_Lead_III,
            ECG_Lead_AVR,
            ECG_Lead_AVL,
            ECG_Lead_AVF,
            ECG_Lead_V1,
            ECG_Lead_V2,
            ECG_Lead_V3,
            ECG_Lead_V4,
            ECG_Lead_V5,
            ECG_Lead_V6,
        };
    }
}
