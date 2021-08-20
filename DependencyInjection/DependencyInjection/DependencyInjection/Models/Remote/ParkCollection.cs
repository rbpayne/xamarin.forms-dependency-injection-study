using System.Collections.Generic;
using Newtonsoft.Json;

namespace DependencyInjection.Models.Remote
{
    public class ParkCollection
    {
        [JsonProperty("features")]
        public List<Park> Parks { get; set; }
    }
}
