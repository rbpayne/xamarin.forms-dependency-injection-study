using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ServiceLocatorStatic.Models.Remote;
using ServiceLocatorStatic.Utilities;

namespace ServiceLocatorStatic.Services
{
    public class ParkService
    {
        private readonly HttpClient _client;

        public ParkService()
        {
            _client = Dependencies.HttpClient;
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
