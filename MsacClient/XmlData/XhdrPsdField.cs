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

        [XmlAttribute("blankScreen")]
        public string BlankScreen { get; set; }
    }
}
