using Newtonsoft.Json;

namespace NoDependencyInjection.Models.Remote
{
    public class Attributes
    {
        [JsonProperty("PROPER")]
        public string Name { get; set; }
    }
}
