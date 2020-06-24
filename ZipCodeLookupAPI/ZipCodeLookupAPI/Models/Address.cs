using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZipCodeLookupAPI.Models
{
    public class Address
    {
        [XmlAttribute]
        public int ID { get; set; }

        [XmlElement]
        public string FirmName { get; set; }
        [XmlElement]
        public string Address1 { get; set; }
        [XmlElement]
        public string Address2 { get; set; }
        [XmlElement]
        public string City { get; set; }
        [XmlElement]
        public string State { get; set; }

        [XmlElement]
        public string Urbanization { get; set; }
        [XmlElement]
        public string Zip5 { get; set; }
        [XmlElement]
        public string Zip4 { get; set; }

    }
}
