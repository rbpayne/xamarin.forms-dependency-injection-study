using Newtonsoft.Json;

namespace DependencyInjection.Models.Remote
{
    public class Park
    {
        [JsonProperty("attributes")]
        public Attributes Attributes { get; set; }
    }
}
