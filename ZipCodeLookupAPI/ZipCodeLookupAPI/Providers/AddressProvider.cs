using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serializers;
using System;
using System.IO;
using System.Net;
using System.Xml;
using System.Xml.Serialization;
using ZipCodeLookupAPI.Models;

namespace ZipCodeLookupAPI.Providers
{
    public class AddressProvider : IAddressProvider
    {
        private readonly IRestClient _restClient;

        public AddressProvider(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public ZipCodeLookupResponse SendZipCodeLookupRequest(ZipCodeLookupRequest zipCodeLookupRequest)
        {
            var deserializer = new XmlDeserializer();
            var request = new RestRequest(Method.GET);

            var lookupRequest = SerializeZipCodeLookupRequest(zipCodeLookupRequest);


            var baseUrl = new Uri($"https://secure.shippingapis.com/shippingapi.dll?API=ZipCodeLookup&XML={lookupRequest}");

            _restClient.BaseUrl = baseUrl;

            var response = _restClient.Execute(request);

            var zipCodeLookupResponse = deserializer.Deserialize<ZipCodeLookupResponse>(response);
            return zipCodeLookupResponse;
        }

        private static string SerializeZipCodeLookupRequest(ZipCodeLookupRequest zipCodeLookupRequest)
        {
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(ZipCodeLookupRequest));
            var settings = new XmlWriterSettings
            {
                Indent = false,
                NewLineHandling = NewLineHandling.None,
                OmitXmlDeclaration = true
            };
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            var sw = new StringWriter();
            var writer = XmlWriter.Create(sw, settings);

            serializer.Serialize(writer, zipCodeLookupRequest, namespaces);

            var lookupRequest = sw.ToString();
            return lookupRequest;
        }

    }
}
