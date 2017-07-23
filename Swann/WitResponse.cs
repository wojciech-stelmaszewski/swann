using System.Collections.Generic;
using Newtonsoft.Json;

namespace Swann
{
    public class WitResponse
    {
        [JsonProperty("msg_id")]
        public string MessageId { get; set; }

        [JsonProperty("_text")]
        public string Text { get; set; }

        [JsonProperty("entities")]
        public IDictionary<string, IEnumerable<WitEntityValue>> Entities { get; set; }
    }
}
