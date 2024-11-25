using dolar_api.Clases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;

namespace dolar_api.Resource
{
    public class DolarAPI
    {
        public async Task<string> GetBlueQuote()
        {
            string responseBody = string.Empty;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://dolarapi.com/v1/dolares/blue");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
                response.EnsureSuccessStatusCode();

                responseBody = response.Content.ReadAsStringAsync().Result;
            }

            return responseBody;
        }

        public async Task<string> GetSpecificQuote(Currency currency)
        {
            string responseBody = string.Empty;
            using (var client = new HttpClient()) 
            { 

                switch (currency.Code.ToLower())
                {
                case "bolsa":
                    client.BaseAddress = new Uri("https://dolarapi.com/v1/dolares/bolsa");
                    break;
                case "blue":
                    client.BaseAddress = new Uri("https://dolarapi.com/v1/euro/blue");
                    break;
                case "cripto":
                    client.BaseAddress = new Uri("https://dolarapi.com/v1/reales/cripto");
                    break;
                default:
                    throw new ArgumentException("Invalid currency code");
                }

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
                response.EnsureSuccessStatusCode();

                responseBody = response.Content.ReadAsStringAsync().Result;
            }

            return responseBody;
        }
    }
}
