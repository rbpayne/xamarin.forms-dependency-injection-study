using System.Collections.Generic;
using Newtonsoft.Json;

namespace ServiceLocatorStatic.Models.Remote
{
    public class ParkCollection
    {
        [JsonProperty("features")]
        public List<Park> Parks { get; set; }
    }
}
