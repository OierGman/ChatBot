using System.Text.Json.Serialization;

namespace Chatbot.APIObjects
{
    internal class WordKnowledge
    {
        public class Definition
        {
            [JsonPropertyName("definition")]
            public string definition { get; set; }

            [JsonPropertyName("synonyms")]
            public List<object> synonyms { get; set; }

            [JsonPropertyName("antonyms")]
            public List<object> antonyms { get; set; }

            [JsonPropertyName("example")]
            public string example { get; set; }
        }

        public class License
        {
            [JsonPropertyName("name")]
            public string name { get; set; }

            [JsonPropertyName("url")]
            public string url { get; set; }
        }

        public class Meaning
        {
            [JsonPropertyName("partOfSpeech")]
            public string partOfSpeech { get; set; }

            [JsonPropertyName("definitions")]
            public List<Definition> definitions { get; set; }

            [JsonPropertyName("synonyms")]
            public List<string> synonyms { get; set; }

            [JsonPropertyName("antonyms")]
            public List<string> antonyms { get; set; }
        }

        public class Phonetic
        {
            [JsonPropertyName("audio")]
            public string audio { get; set; }

            [JsonPropertyName("sourceUrl")]
            public string sourceUrl { get; set; }

            [JsonPropertyName("license")]
            public License license { get; set; }

            [JsonPropertyName("text")]
            public string text { get; set; }
        }
        public class Root
        {
            [JsonPropertyName("word")]
            public string word { get; set; }

            [JsonPropertyName("phonetics")]
            public List<Phonetic> phonetics { get; set; }

            [JsonPropertyName("meanings")]
            public List<Meaning> meanings { get; set; }

            [JsonPropertyName("license")]
            public License license { get; set; }

            [JsonPropertyName("sourceUrls")]
            public List<string> sourceUrls { get; set; }

        }
    }
}
