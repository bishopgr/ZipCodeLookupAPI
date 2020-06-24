using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using ZipCodeLookupAPI.Models;
using ZipCodeLookupAPI.Providers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZipCodeLookupAPI.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class ZipCodeLookupController : ControllerBase
    {
        private readonly IAddressProvider _addressProvider;
        public ZipCodeLookupController(IAddressProvider addressProvider)
        {
            _addressProvider = addressProvider;
        }
        // GET: api/<ZipCodeLookupController>
        [Microsoft.AspNetCore.Mvc.HttpPost("/api/lookup")]
        public IActionResult Post([Microsoft.AspNetCore.Mvc.FromBody] ZipCodeLookupRequest zipCodeLookupRequest)
        {
            var zipCodeLookupResponse = _addressProvider.SendZipCodeLookupRequest(zipCodeLookupRequest);
            if(zipCodeLookupResponse == null)
            {
                return BadRequest(zipCodeLookupResponse);
            }
            return Ok(zipCodeLookupResponse);
        }
    }
}
