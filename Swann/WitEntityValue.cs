using Newtonsoft.Json;

namespace Swann
{
    public class WitEntityValue
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("confidence")]
        public double Confidence { get; set; }
    }
}
