/*
  Copyright (c) 2011-2012, HL7, Inc
  All rights reserved.
  
  Redistribution and use in source and binary forms, with or without modification, 
  are permitted provided that the following conditions are met:
  
   * Redistributions of source code must retain the above copyright notice, this 
     list of conditions and the following disclaimer.
   * Redistributions in binary form must reproduce the above copyright notice, 
     this list of conditions and the following disclaimer in the documentation 
     and/or other materials provided with the distribution.
   * Neither the name of HL7 nor the names of its contributors may be used to 
     endorse or promote products derived from this software without specific 
     prior written permission.
  
  THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND 
  ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED 
  WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. 
  IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, 
  INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT 
  NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR 
  PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, 
  WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
  ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE 
  POSSIBILITY OF SUCH DAMAGE.
  

*/


using Hl7.Fhir.Introspection;
using Hl7.Fhir.Specification;
using Hl7.Fhir.Utility;
using System;
using System.Runtime.Serialization;
using S = Hl7.Fhir.ElementModel.Types;

namespace Hl7.Fhir.Model
{
    [Serializable]
    [FhirType("codeOfT")]
    [DataContract]
    [System.Diagnostics.DebuggerDisplay(@"\{Value={Value}}")]
    public class Code<T> : PrimitiveType, INullableValue<T>, ISystemAndCode where T : struct
    {
        static Code()
        {
            if (!typeof(T).IsEnum())
                throw new ArgumentException("T must be an enumerated type");
        }

        public override string TypeName => "code";

        public Code() : this(null) { }

        public Code(T? value)
        {
            Value = value;
        }

        // Primitive value of element
        [FhirElement("value", IsPrimitiveValue = true, XmlSerialization = XmlRepresentation.XmlAttr, InSummary = true, Order = 30)]
        [DataMember]
        public T? Value
        {
            get => ObjectValue != null ? EnumUtility.ParseLiteral<T>((string)ObjectValue) : null;

            set => ObjectValue = value != null ? ((Enum)(object)value).GetLiteral() : null;
        }

        string ISystemAndCode.System => ((Enum)(object)Value).GetSystem();

        string ISystemAndCode.Code => ObjectValue as string; // this is the literal

        public S.Code ToSystemCode() => new S.Code(((ISystemAndCode)this).System, ObjectValue as string, display: null, version: null);
    }
}
