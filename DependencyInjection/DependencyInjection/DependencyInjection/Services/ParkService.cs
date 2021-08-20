using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using DependencyInjection.Models.Remote;
using DependencyInjection.Utilities;
using Newtonsoft.Json;

namespace DependencyInjection.Services
{
    public class ParkService
    {
        private readonly HttpClient _client;

        public ParkService(HttpClient client)
        {
            _client = client;
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
