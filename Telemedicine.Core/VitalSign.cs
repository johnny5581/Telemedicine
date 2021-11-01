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
            string unitSystem = "http://unitsofmeasure.org")
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
            
        }
        public string ItemDisplay { get; set; }
        public string Item { get; set; }
        public string Category { get; set; }
        public string CategorySystem { get; set; }
        public string CategoryDisplay { get; set; }
        public string Code { get; set; }
        public string CodeSystem { get; set; }
        public string CodeDisplay { get; set; }
        public string Unit { get; set; }
        public string UnitCode { get; set; }
        public string UnitSystem { get; set; }

        public override string ToString()
        {
            return string.Format("{0} ({1})", ItemDisplay, Item);
        }

        public static VitalSign BodyHeight = new VitalSign("3137-7", "Body Height", "身高", "cm");
        public static VitalSign BodyWeight = new VitalSign("29463-7","Body Weight", "體重", "kg");
        public static VitalSign BodyTemperature = new VitalSign("8310-5", "Body Temperature", "體溫", "Cel");
        public static VitalSign BloodGlucosePreMeal = new VitalSign("88365-2", "Blood Glucose Post Meal", "進食前血糖", "mg/dL", "Laboratory Data");
        public static VitalSign BloodGlucosePostMeal = new VitalSign("87422-2", "Blood Glucose Post Meal", "進食後血糖", "mg/dL", "Laboratory Data");
        public static VitalSign PercentageOfBodyFat = new VitalSign("41982-0", "Percentage of body fat Measured", "體脂率", "%");
        public static VitalSign GripStrengthHand = new VitalSign("83174-3", "Grip strength Hand - right Dynamometer", "握力", "kg");
        public static VitalSign Oxygen = new VitalSign("59408-5", "Oxygen saturation in Arterial blood by Pulse oximetry", "SPO2血氧飽和濃度", "%");
        public static VitalSign[] VitalSigns = new VitalSign[]
        {
            BodyHeight, BodyWeight, BodyTemperature, BloodGlucosePostMeal, BloodGlucosePreMeal, GripStrengthHand, Oxygen
        };
    }
}
