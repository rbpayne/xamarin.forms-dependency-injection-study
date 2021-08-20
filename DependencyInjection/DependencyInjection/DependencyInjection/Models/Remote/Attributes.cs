using Newtonsoft.Json;

namespace DependencyInjection.Models.Remote
{
    public class Attributes
    {
        [JsonProperty("PROPER")]
        public string Name { get; set; }
    }
}
