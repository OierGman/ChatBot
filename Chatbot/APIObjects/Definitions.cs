using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Chatbot.APIObjects
{
    internal class Definitions
    {
        public static List<Definitions.Root> definitions = new List<Definitions.Root>();

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
