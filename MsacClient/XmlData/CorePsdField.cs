using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace MsacClient.XmlData
{
    [XmlType("core")]
    public class CorePsdField
    {
        [XmlAttribute("title")]
        public string Title { get; set; }

        [XmlAttribute("artist")]
        public string Artist { get; set; }

        [XmlAttribute("genre")]
        public string Genre { get; set; }

        [XmlAttribute("album")]
        public string Album { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is CorePsdField c)
            {
                return Title == c.Title &&
                    Artist == c.Artist &&
                    Album == c.Album &&
                    Genre == c.Genre;
            }
            return false;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
