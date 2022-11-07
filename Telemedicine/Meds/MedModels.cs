using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telemedicine.Meds
{
    public class MedRoute2 : Coding
    {
        public MedRoute2(string code, string display) : base("http://hitstdio.ntunhs.edu.tw/ig/twcore/ValueSet-medication-path-tw.html", code, display)
        {
        }
        public override string ToString()
        {
            return string.Format("{0} ({1})", Display, Code);
        }
        //public static readonly MedRoute XX = new MedRoute(
        public static readonly MedRoute2 AD = new MedRoute2("AD", "右耳");
        public static readonly MedRoute2 AS = new MedRoute2("AS", "左耳");
        public static readonly MedRoute2 AU = new MedRoute2("AU", "每耳");
        public static readonly MedRoute2 ET = new MedRoute2("ET", "氣內切");
        public static readonly MedRoute2 CAR = new MedRoute2("CAR", "漱口用");
        public static readonly MedRoute2 HD = new MedRoute2("HD", "皮下灌注");
        public static readonly MedRoute2 IC = new MedRoute2("IC", "皮內注射");
        public static readonly MedRoute2 IA = new MedRoute2("IA", "動脈注射");
        public static readonly MedRoute2 IE = new MedRoute2("IE", "脊髓硬膜內注射");
        public static readonly MedRoute2 IM = new MedRoute2("IM", "肌肉注射");
        public static readonly MedRoute2 IV = new MedRoute2("IV", "靜脈注射");
        public static readonly MedRoute2 IP = new MedRoute2("IP", "腹腔注射");
        public static readonly MedRoute2 ICV = new MedRoute2("ICV", "腦室注射");
        public static readonly MedRoute2 IMP = new MedRoute2("IMP", "植入");
        public static readonly MedRoute2 INHL = new MedRoute2("INHL", "吸入");
        public static readonly MedRoute2 IS = new MedRoute2("IS", "關節腔內注射");
        public static readonly MedRoute2 IT = new MedRoute2("IT", "椎骨內注射");
        public static readonly MedRoute2 IVA = new MedRoute2("IVA", "靜脈添加");
        public static readonly MedRoute2 IVD = new MedRoute2("IVD", "靜脈點滴滴入");
        public static readonly MedRoute2 IVI = new MedRoute2("IVI", "玻璃體內注射");
        public static readonly MedRoute2 IVP = new MedRoute2("IVP", "靜脈注入");
        public static readonly MedRoute2 LA = new MedRoute2("LA", "局部麻醉");
        public static readonly MedRoute2 LI = new MedRoute2("LI", "局部注射");
        public static readonly MedRoute2 NA = new MedRoute2("NA", "鼻用");
        public static readonly MedRoute2 OD = new MedRoute2("OD", "右眼");
        public static readonly MedRoute2 OS = new MedRoute2("OS", "左眼");
        public static readonly MedRoute2 OU = new MedRoute2("OU", "每眼");
        public static readonly MedRoute2 PO = new MedRoute2("PO", "口眼");
        public static readonly MedRoute2 SC = new MedRoute2("SC", "皮下注射");
        public static readonly MedRoute2 SCI = new MedRoute2("SCI", "結膜下注射");
        public static readonly MedRoute2 SKIN = new MedRoute2("SKIN", "皮膚用");
        public static readonly MedRoute2 SL = new MedRoute2("SL", "舌下");
        public static readonly MedRoute2 SPI = new MedRoute2("SPI", "脊髓");
        public static readonly MedRoute2 RECT = new MedRoute2("RECT", "肛門用");
        public static readonly MedRoute2 TOPI = new MedRoute2("TOPI", "局部塗擦（與LA易混淆）");
        public static readonly MedRoute2 TRN = new MedRoute2("TRN", "全靜脈營養劑");
        public static readonly MedRoute2 VAG = new MedRoute2("VAG", "陰道用");
        public static readonly MedRoute2 IRRIG = new MedRoute2("IRRIG", "沖洗(irrigation)");
        public static readonly MedRoute2 EXT = new MedRoute2("EXT", "外用");
        public static readonly MedRoute2 XX = new MedRoute2("XX", "其他");

        public static readonly MedRoute2[] Routes = new MedRoute2[]
        {
                AD ,
                AS ,
                AU ,
                ET ,
                CAR,
                HD ,
                IC ,
                IA ,
                IE ,
                IM ,
                IV ,
                IP ,
                ICV,
                IMP,
                INHL,
                IS ,
                IT ,
                IVA,
                IVD,
                IVI,
                IVP,
                LA ,
                LI ,
                NA ,
                OD ,
                OS ,
                OU ,
                PO ,
                SC ,
                SCI,
                SKIN,
                SL ,
                SPI,
                RECT,
                TOPI,
                TRN ,
                VAG ,
                IRRIG,
                EXT,
                XX ,
        };

    }
    public class MedRoute : Coding
    {
        public MedRoute(string code, string display) : base("https://twcore.mohw.gov.tw/fhir/CodeSystem/medication-path-tw", code, display)
        {
        }
        public override string ToString()
        {
            return string.Format("{0} ({1})", Display, Code);
        }
        //public static readonly MedRoute XX = new MedRoute(
        public static readonly MedRoute AD = new MedRoute("AD", "右耳");
        public static readonly MedRoute AS = new MedRoute("AS", "左耳");
        public static readonly MedRoute AU = new MedRoute("AU", "每耳");
        public static readonly MedRoute ET = new MedRoute("ET", "氣內切");
        public static readonly MedRoute CAR = new MedRoute("CAR", "漱口用");
        public static readonly MedRoute HD = new MedRoute("HD", "皮下灌注");
        public static readonly MedRoute IC = new MedRoute("IC", "皮內注射");
        public static readonly MedRoute IA = new MedRoute("IA", "動脈注射");
        public static readonly MedRoute IE = new MedRoute("IE", "脊髓硬膜內注射");
        public static readonly MedRoute IM = new MedRoute("IM", "肌肉注射");
        public static readonly MedRoute IV = new MedRoute("IV", "靜脈注射");
        public static readonly MedRoute IP = new MedRoute("IP", "腹腔注射");
        public static readonly MedRoute ICV = new MedRoute("ICV", "腦室注射");
        public static readonly MedRoute IMP = new MedRoute("IMP", "植入");
        public static readonly MedRoute INHL = new MedRoute("INHL", "吸入");
        public static readonly MedRoute IS = new MedRoute("IS", "關節腔內注射");
        public static readonly MedRoute IT = new MedRoute("IT", "椎骨內注射");
        public static readonly MedRoute IVA = new MedRoute("IVA", "靜脈添加");
        public static readonly MedRoute IVD = new MedRoute("IVD", "靜脈點滴滴入");
        public static readonly MedRoute IVI = new MedRoute("IVI", "玻璃體內注射");
        public static readonly MedRoute IVP = new MedRoute("IVP", "靜脈注入");
        public static readonly MedRoute LA = new MedRoute("LA", "局部麻醉");
        public static readonly MedRoute LI = new MedRoute("LI", "局部注射");
        public static readonly MedRoute NA = new MedRoute("NA", "鼻用");
        public static readonly MedRoute OD = new MedRoute("OD", "右眼");
        public static readonly MedRoute OS = new MedRoute("OS", "左眼");
        public static readonly MedRoute OU = new MedRoute("OU", "每眼");
        public static readonly MedRoute PO = new MedRoute("PO", "口眼");
        public static readonly MedRoute SC = new MedRoute("SC", "皮下注射");
        public static readonly MedRoute SCI = new MedRoute("SCI", "結膜下注射");
        public static readonly MedRoute SKIN = new MedRoute("SKIN", "皮膚用");
        public static readonly MedRoute SL = new MedRoute("SL", "舌下");
        public static readonly MedRoute SPI = new MedRoute("SPI", "脊髓");
        public static readonly MedRoute RECT = new MedRoute("RECT", "肛門用");
        public static readonly MedRoute TOPI = new MedRoute("TOPI", "局部塗擦（與LA易混淆）");
        public static readonly MedRoute TRN = new MedRoute("TRN", "全靜脈營養劑");
        public static readonly MedRoute VAG = new MedRoute("VAG", "陰道用");
        public static readonly MedRoute IRRIG = new MedRoute("IRRIG", "沖洗(irrigation)");
        public static readonly MedRoute EXT = new MedRoute("EXT", "外用");
        public static readonly MedRoute XX = new MedRoute("XX", "其他");

        public static readonly MedRoute[] Routes = new MedRoute[]
        {
                AD ,
                AS ,
                AU ,
                ET ,
                CAR,
                HD ,
                IC ,
                IA ,
                IE ,
                IM ,
                IV ,
                IP ,
                ICV,
                IMP,
                INHL,
                IS ,
                IT ,
                IVA,
                IVD,
                IVI,
                IVP,
                LA ,
                LI ,
                NA ,
                OD ,
                OS ,
                OU ,
                PO ,
                SC ,
                SCI,
                SKIN,
                SL ,
                SPI,
                RECT,
                TOPI,
                TRN ,
                VAG ,
                IRRIG,
                EXT,
                XX ,
        };

    }
    public class MedTiming : Coding
    {
        private float _quantity;
        public MedTiming(string code, string display, float quantityPerDay) : base("http://terminology.hl7.org/CodeSystem/v3-GTSAbbreviation", code, display)
        {
            _quantity = quantityPerDay;
        }

        public int Quantity
        {
            get
            {
                if (_quantity < 1)
                    return 1;
                return (int)Math.Ceiling(_quantity);
            }
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})", Display, Code);
        }


        public static readonly MedTiming BID = new MedTiming("BID", "BID", 2);
        public static readonly MedTiming TID = new MedTiming("TID", "TID", 3);
        public static readonly MedTiming QID = new MedTiming("QID", "QID", 4);
        public static readonly MedTiming AM = new MedTiming("AM", "AM", 1);
        public static readonly MedTiming PM = new MedTiming("PM", "PM", 1);
        public static readonly MedTiming QD = new MedTiming("QD", "QD", 1);
        public static readonly MedTiming QOD = new MedTiming("QOD", "QOD", 0.5F);
        public static readonly MedTiming Q1H = new MedTiming("Q1H", "every hour", 24);
        public static readonly MedTiming Q2H = new MedTiming("Q2H", "every 2 hours", 12);
        public static readonly MedTiming Q3H = new MedTiming("Q3H", "every 3 hours", 8);
        public static readonly MedTiming Q4H = new MedTiming("Q4H", "Q4H", 6);
        public static readonly MedTiming Q6H = new MedTiming("Q6H", "Q6H", 4);
        public static readonly MedTiming Q8H = new MedTiming("Q8H", "every 8 hours", 3);
        public static readonly MedTiming BED = new MedTiming("BED", "at bedtime", 1);

        public static readonly MedTiming[] Timings = new MedTiming[]
        {
                 BID,
                 TID,
                 QID,
                 AM,
                 PM,
                 QD,
                 QOD,
                 Q1H,
                 Q2H,
                 Q3H,
                 Q4H,
                 Q6H,
                 Q8H,
                 BED,
        };
    }
    public class MedUnit : Coding
    {
        public MedUnit(string code, string display) : base("http://terminology.hl7.org/CodeSystem/v3-orderableDrugForm", code, display)
        {
        }
        public override string ToString()
        {
            return string.Format("{0} ({1})", Display, Code);
        }

        public static MedUnit TAB = new MedUnit("TAB", "Tablet");
        public static MedUnit SWAB = new MedUnit("SWAB", "Swab");

        public static MedUnit[] Units = new MedUnit[]
        {
            TAB, SWAB
        };
    }
}
