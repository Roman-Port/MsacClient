using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace MsacClient.XmlData
{
    [XmlType("xhdr")]
    public class XhdrPsdField
    {
        [XmlAttribute("mimeType")]
        public string MimeType { get; set; }

        [XmlAttribute("lotId")]
        public string LotId { get; set; }

        [XmlAttribute("trigger")]
        public string Trigger { get; set; }

        [XmlAttribute("flushMemory")]
        public string FlushMemory { get; set; }

        [XmlAttribute("blankScreen")]
        public string BlankScreen { get; set; }
    }
}
