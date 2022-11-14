using System.Text.Json.Serialization;

namespace Chatbot.APIObjects
{
    internal class Definitions
    {
        public static List<Root> Defs = new List<Root>();

        // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
        public class Definition
        {
            [JsonPropertyName("definition")]
            public string definition { get; set; }

            [JsonPropertyName("partOfSpeech")]
            public string partOfSpeech { get; set; }
        }

        public class Root
        {
            [JsonPropertyName("word")]
            public string word { get; set; }

            [JsonPropertyName("definitions")]
            public List<Definition> definitions { get; set; }
        }
    }
}
