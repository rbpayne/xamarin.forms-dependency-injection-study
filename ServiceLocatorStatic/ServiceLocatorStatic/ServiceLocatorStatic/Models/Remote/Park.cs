using Newtonsoft.Json;

namespace ServiceLocatorStatic.Models.Remote
{
    public class Park
    {
        [JsonProperty("attributes")]
        public Attributes Attributes { get; set; }
    }
}
