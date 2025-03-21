using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace MsacClient.XmlData
{
    [XmlRoot("HDRadio-Envelope")]
    public class HDRadioEnvelope
    {
        [XmlElement("MSAC-Request")]
        public MsacRequest MsacRequest { get; set; }
        
        [XmlElement("MSAC-Response")]
        public MsacResponse MsacResponse { get; set; }
    }
}
