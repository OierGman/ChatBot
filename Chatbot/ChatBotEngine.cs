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

            APIObjects.BankHolidays.Root myDeserializedClass = JsonSerializer.Deserialize<APIObjects.BankHolidays.Root>(responseBody);
        }
    }
}
