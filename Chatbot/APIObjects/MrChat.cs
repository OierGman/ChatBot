using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Chatbot.APIObjects
{
    internal class MrChat
    {
        public static List<MrChat.Root> chat = new List<MrChat.Root>();
        // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
        public class Root
        {
            [JsonPropertyName("result")]
            public string result { get; set; }

            [JsonPropertyName("conversationID")]
            public string conversationID { get; set; }

            [JsonPropertyName("host")]
            public string host { get; set; }

            [JsonPropertyName("s")]
            public string s { get; set; }
        }
    }
}
