using ZipCodeLookupAPI.Models;

namespace ZipCodeLookupAPI.Providers
{
    public interface IAddressProvider
    {
        ZipCodeLookupResponse SendZipCodeLookupRequest(ZipCodeLookupRequest zipCodeLookupRequest);
    }
}
