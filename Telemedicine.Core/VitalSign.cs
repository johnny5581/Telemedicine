using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telemedicine
{
    public class VitalSign
    {
        public string ItemChn { get; set; }
        public string Item { get; set; }
        public string Category { get; set; }
        public string CodeSystem { get; set; }
        public string Code { get; set; }
        public string Unit { get; set; }
        public string UnitCode { get; set; }


        public static VitalSign BodyHeight = new VitalSign { ItemChn = "身高", Item = "Body Height", Category = "Vital Signs", CodeSystem = "http://loinc.org", Code = "3137-7", Unit = "cm", UnitCode = "cm" };
        public static VitalSign BodyWeight = new VitalSign { ItemChn = "體重", Item = "Body Weight", Category = "Vital Signs", CodeSystem = "http://loinc.org", Code = "29463-7", Unit = "kg", UnitCode = "kg" };
        public static VitalSign BodyTemperature = new VitalSign { ItemChn = "體溫", Item = "Body Temperature", Category = "Vital Signs", CodeSystem = "http://loinc.org", Code = "8310-5", Unit = "Cel", UnitCode = "Cel" };
        public static VitalSign BloodGlucosePostMeal = new VitalSign { ItemChn = "進食後血糖", Item = "Blood Glucose Post Meal", Category = "Laboratory Data", CodeSystem = "http://loinc.org", Code = "87422-2", Unit = "mg/dL", UnitCode = "mg/dL" };
        public static VitalSign BloodGlucosePreMeal = new VitalSign { ItemChn = "進食前血糖", Item = "Blood Glucose Post Meal", Category = "Laboratory Data", CodeSystem = "http://loinc.org", Code = "88365-2", Unit = "mg/dL", UnitCode = "mg/dL" };
        public static VitalSign PercentageOfBodyFat = new VitalSign { ItemChn = "體脂率", Item = "Percentage of body fat Measured", Category = "Vital Signs", CodeSystem = "http://loinc.org", Code = "41982-0", Unit = "%", UnitCode = "%" };
        public static VitalSign GripStrengthHand = new VitalSign { ItemChn = "握力", Item = "Grip strength Hand - right Dynamometer", Category = "Vital Signs", CodeSystem = "http://loinc.org", Code = "83174-3", Unit = "kg", UnitCode = "kg" };
        public static VitalSign Oxygen = new VitalSign { ItemChn = "SPO2血氧飽和濃度", Item = "Oxygen saturation in Arterial blood by Pulse oximetry", Category = "Vital Signs", CodeSystem = "http://loinc.org", Code = "59408-5", Unit = "%", UnitCode = "%" };

        public static VitalSign[] VitalSigns = new VitalSign[]
        {
            BodyHeight, BodyWeight, BodyTemperature, BloodGlucosePostMeal, BloodGlucosePreMeal, GripStrengthHand, Oxygen
        };
    }
}
