using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace MsacClient.XmlData
{
    [XmlType("PSD-Fields")]
    public class PsdFields
    {
        [XmlElement("core")]
        public CorePsdField Core { get; set; }
        
        [XmlElement("xhdr")]
        public XhdrPsdField Xhdr { get; set; }
    }
}
