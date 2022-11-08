using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Chatbot
{
    internal class ChatBotEngine
    {
        public static async Task BankHolidays()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://www.gov.uk/bank-holidays.json");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            APIObjects.BankHolidays.Root bankHolDeserializedClass = JsonSerializer.Deserialize<APIObjects.BankHolidays.Root>(responseBody);

            foreach (var x in bankHolDeserializedClass.EnglandAndWales.events)
            {
                if (DateTime.Parse(x.date) > DateTime.Now)
                {
                    APIObjects.BankHolidays.bankHolidays.Add(x);
                }
            }
        }

        public static async Task Joke()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://v2.jokeapi.dev/joke/Christmas");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            APIObjects.Jokes.Root jokeDeserializedClass = JsonSerializer.Deserialize<APIObjects.Jokes.Root>(responseBody);

            APIObjects.Jokes.joke.Add(jokeDeserializedClass);
        }
    }
}
