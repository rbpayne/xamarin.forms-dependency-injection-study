using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using ServiceLocator.Models.Remote;
using ServiceLocator.Utilities;

namespace ServiceLocator.Services
{
    public class ParkService
    {
        private readonly HttpClient _client;

        public ParkService()
        {
            _client = Dependencies.ServiceProvider.GetRequiredService<HttpClient>();
        }

        public async Task<ParkCollection?> GetParks()
        {
            ParkCollection? parkCollection = null;

            try
            {
                var response = await _client.GetAsync(Constants.FindAParkEndpoint);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    parkCollection = JsonConvert.DeserializeObject<ParkCollection>(content);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("\tERROR {0}", e.Message);
                throw;
            }

            return parkCollection;
        }
    }
}
