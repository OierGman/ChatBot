using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Chatbot.APIObjects
{
    internal class Jokes
    {
        public static List<Jokes.Root> joke = new List<Jokes.Root>();
        // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
        public class Flags
        {
            [JsonPropertyName("nsfw")]
            public bool nsfw { get; set; }

            [JsonPropertyName("religious")]
            public bool religious { get; set; }

            [JsonPropertyName("political")]
            public bool political { get; set; }

            [JsonPropertyName("racist")]
            public bool racist { get; set; }

            [JsonPropertyName("sexist")]
            public bool sexist { get; set; }

            [JsonPropertyName("explicit")]
            public bool @explicit { get; set; }
        }

        public class Root
        {
            [JsonPropertyName("error")]
            public bool error { get; set; }

            [JsonPropertyName("category")]
            public string category { get; set; }

            [JsonPropertyName("type")]
            public string type { get; set; }

            [JsonPropertyName("setup")]
            public string setup { get; set; }

            [JsonPropertyName("delivery")]
            public string delivery { get; set; }

            [JsonPropertyName("flags")]
            public Flags flags { get; set; }

            [JsonPropertyName("id")]
            public int id { get; set; }

            [JsonPropertyName("safe")]
            public bool safe { get; set; }

            [JsonPropertyName("lang")]
            public string lang { get; set; }
        }

    }
}
