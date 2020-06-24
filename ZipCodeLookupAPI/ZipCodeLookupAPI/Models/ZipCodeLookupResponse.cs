using System.Xml.Serialization;

namespace ZipCodeLookupAPI.Models
{
    public class ZipCodeLookupResponse
    {
        [XmlElement]
        public Address Address { get; set; }
    }
}
