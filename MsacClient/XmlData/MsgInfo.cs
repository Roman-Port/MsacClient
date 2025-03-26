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

        [XmlAttribute("fileDestination")]
        public string FileDestination { get; set; }

        [XmlAttribute("fileSize")]
        public string FileSize { get; set; }

        [XmlAttribute("offset")]
        public string Offset { get; set; }

        [XmlAttribute("startTime")]
        public string StartTime { get; set; }

        [XmlAttribute("fileName")]
        public string FileName { get; set; }

        [XmlAttribute("songDuration")]
        public string SongDuration { get; set; } // seconds, integer

        [XmlAttribute("triggerType")]
        public string TriggerType { get; set; }

        [XmlAttribute("cancelPrior")]
        public string CancelPrior { get; set; } // TRUE or FALSE

        [XmlAttribute("uniqueTag")]
        public string UniqueTag { get; set; }
    }
}
