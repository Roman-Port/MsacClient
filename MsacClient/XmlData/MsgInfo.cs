using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace MsacClient.XmlData
{
    [XmlType("Msg-Info")]
    public class MsgInfo
    {
        [XmlAttribute("msgType")]
        public string MsgType { get; set; }

        [XmlAttribute("inputFormat")]
        public string InputFormat { get; set; }

        [XmlAttribute("outputFormat")]
        public string OutputFormat { get; set; }

        [XmlAttribute("protocol")]
        public string Protocol { get; set; }

        [XmlAttribute("location")]
        public string Location { get; set; }

        [XmlAttribute("audioProgram")]
        public string AudioProgram { get; set; }

        [XmlAttribute("dataServiceName")]
        public string DataServiceName { get; set; }

        [XmlAttribute("state")]
        public string State { get; set; }
    }
}
