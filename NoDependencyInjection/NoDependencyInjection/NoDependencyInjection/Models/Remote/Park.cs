using System.Collections.Generic;
using Newtonsoft.Json;

namespace NoDependencyInjection.Models.Remote
{
    public class Park
    {
        [JsonProperty("attributes")]
        public Attributes Attributes { get; set; }
    }
}
