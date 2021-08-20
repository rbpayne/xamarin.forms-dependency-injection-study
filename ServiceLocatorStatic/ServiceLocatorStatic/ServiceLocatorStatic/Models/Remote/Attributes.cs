using Newtonsoft.Json;

namespace ServiceLocatorStatic.Models.Remote
{
    public class Attributes
    {
        [JsonProperty("PROPER")]
        public string Name { get; set; }
    }
}
