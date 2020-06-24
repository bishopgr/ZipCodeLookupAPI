using System.Xml.Serialization;

namespace ZipCodeLookupAPI.Models
{
    public class ZipCodeLookupRequest
    {
        [XmlAttribute]
        public string USERID { get; set; };

        [XmlElement]
        public Address Address { get; set; }

        public ZipCodeLookupRequest()
        {
            Address = new Address();
        }

    }
}
