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

        public override bool Equals(object obj)
        {
            if (obj is PsdFields c)
            {
                if (!EqualsHelper(Core, c.Core))
                    return false;
                if (!EqualsHelper(Xhdr, c.Xhdr))
                    return false;
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        private static bool EqualsHelper<T>(T a, T b)
        {
            if (a == null && b != null)
                return false;
            if (b == null && a != null)
                return false;
            if (a != null)
                return a.Equals(b);
            return true;
        }
    }
}
