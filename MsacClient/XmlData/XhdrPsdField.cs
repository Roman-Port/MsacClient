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

        public override bool Equals(object obj)
        {
            if (obj is XhdrPsdField c)
            {
                return MimeType == c.MimeType &&
                    LotId == c.LotId &&
                    Trigger == c.Trigger &&
                    FlushMemory == c.FlushMemory &&
                    BlankScreen == c.BlankScreen;
            }
            return false;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
