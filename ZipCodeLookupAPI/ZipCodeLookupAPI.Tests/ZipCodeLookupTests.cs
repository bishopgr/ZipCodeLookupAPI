using RestSharp;
using RestSharp.Deserializers;
using System;
using Xunit;
using ZipCodeLookupAPI.Models;
using ZipCodeLookupAPI.Providers;

namespace ZipCodeLookupAPI.Tests
{
    public class ZipCodeLookupTests
    {

        [Fact]
        public void Should_Return_Example_API_Result()
        {

            XmlDeserializer deserializer = new XmlDeserializer();

            var client = new RestClient("https://secure.shippingapis.com/shippingapi.dll?API=ZipCodeLookup&XML=<ZipCodeLookupRequest USERID =\"061MIMUT1289\"><Address ID=\"0\"><Address1>911 Military St</Address1><City>Port Huron</City><State>MI</State></Address></ZipCodeLookupRequest>");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            var address = deserializer.Deserialize<ZipCodeLookupResponse>(response);
            Console.WriteLine(address);
            Assert.NotNull(address);
        }

        [Fact]
        public void Should_Return_Deserialized_Example_API_Result()
        {
            var addressProvider = new AddressProvider(new RestClient());

            var zipCodeLookupRequest = new ZipCodeLookupRequest
            {
                Address = new Address
                {
                    Address1 = "911 Military St",
                    City = "Port Huron",
                    State = "MI"
                }
            };

            var zipCodeResponse = addressProvider.SendZipCodeLookupRequest(zipCodeLookupRequest);

            Assert.NotNull(zipCodeResponse);
            Assert.Equal("PORT HURON", zipCodeResponse.Address.City);
            Assert.Equal("48060", zipCodeResponse.Address.Zip5);
            Assert.Equal("5414", zipCodeResponse.Address.Zip4);
        }
    }
}
