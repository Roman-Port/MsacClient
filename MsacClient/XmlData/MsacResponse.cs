using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace MsacClient.XmlData
{
    [XmlType("MSAC-Response")]
    public class MsacResponse
    {
        [XmlElement("Msg-Info")]
        public MsgInfo MsgInfo { get; set; }

        [XmlElement("Lot-Info")]
        public LotInfo LotInfo { get; set; }

        [XmlAttribute("returnString")]
        public string ReturnString { get; set; }

        [XmlAttribute("uniqueTag")]
        public string UniqueTag { get; set; }

        [XmlAttribute("MSAC-OS")]
        public string MsacOS { get; set; }

        [XmlAttribute("MSAC-Version")]
        public string MsacVersion { get; set; }
    }
}
