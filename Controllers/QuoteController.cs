using dolar_api.Clases;
using dolar_api.Resource;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace dolar_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        [HttpGet(Name = "BlueQuote")]
        public async Task<string> GetBlueQuote()
        {
            DolarAPI api = new DolarAPI();
            return await api.GetBlueQuote();
        }

        [HttpPost(Name = "SpecificQuote")]
        public async Task<string> GetCurrencyQuote([FromBody] Currency currency)
        {
            DolarAPI api = new DolarAPI();
            return await api.GetSpecificQuote(currency);
        }
    }
}
