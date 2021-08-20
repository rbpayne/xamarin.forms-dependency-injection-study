using Newtonsoft.Json;

namespace ServiceLocator.Models.Remote
{
    public class Park
    {
        [JsonProperty("attributes")]
        public Attributes Attributes { get; set; }
    }
}
