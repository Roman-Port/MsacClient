using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace MsacClient.XmlData
{
    [XmlType("Lot-Info")]
    public class LotInfo
    {
        [XmlAttribute("lotId")]
        public string LotId { get; set; }

        [XmlAttribute("expirationDate")]
        public string ExpirationDate { get; set; }
    }
}
