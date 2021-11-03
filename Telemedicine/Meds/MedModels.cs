using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telemedicine.Meds
{

    public class MedRoute : Coding
    {
        public MedRoute(string code, string display) : base("http://mtrsoftware.com.tw/Page_L/用法表.htm", code, display)
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
