using Newtonsoft.Json;

namespace ServiceLocator.Models.Remote
{
    public class Attributes
    {
        [JsonProperty("PROPER")]
        public string Name { get; set; }
    }
}
