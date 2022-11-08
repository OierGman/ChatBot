using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Chatbot.APIObjects
{
    internal class BankHolidays
    {
        // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
        public class EnglandAndWales
        {
            [JsonPropertyName("division")]
            public string division { get; set; }

            [JsonPropertyName("events")]
            public List<Event> events { get; set; }
        }

        public class Event
        {
            [JsonPropertyName("title")]
            public string title { get; set; }

            [JsonPropertyName("date")]
            public string date { get; set; }

            [JsonPropertyName("notes")]
            public string notes { get; set; }

            [JsonPropertyName("bunting")]
            public bool bunting { get; set; }
        }

        public class NorthernIreland
        {
            [JsonPropertyName("division")]
            public string division { get; set; }

            [JsonPropertyName("events")]
            public List<Event> events { get; set; }
        }

        public class Root
        {
            [JsonPropertyName("england-and-wales")]
            public EnglandAndWales EnglandAndWales { get; set; }

            [JsonPropertyName("scotland")]
            public Scotland scotland { get; set; }

            [JsonPropertyName("northern-ireland")]
            public NorthernIreland NorthernIreland { get; set; }
        }

        public class Scotland
        {
            [JsonPropertyName("division")]
            public string division { get; set; }

            [JsonPropertyName("events")]
            public List<Event> events { get; set; }
        }


    }
}
