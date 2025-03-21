using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace MsacClient.XmlData
{
    [XmlType("MSAC-Request")]
    public class MsacRequest
    {
        [XmlElement("Msg-Info")]
        public MsgInfo MsgInfo { get; set; }
        
        [XmlElement("PSD-Fields")]
        public PsdFields PsdFields { get; set; }
    }
}
