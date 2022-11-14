using System.Text.Json.Serialization;

namespace Chatbot.APIObjects
{
    internal class MrChat
    {
        public static List<MrChat.Root> Chat = new List<MrChat.Root>();
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
