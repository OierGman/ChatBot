using System.Diagnostics;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Web;
using Chatbot.APIObjects;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;

namespace Chatbot
{
    internal class ChatBotEngine
    {
        [STAThread]
        public static async Task BankHolidays()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://www.gov.uk/bank-holidays.json");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            BankHolidays.Root bankHolDeserializedClass = JsonSerializer.Deserialize<BankHolidays.Root>(responseBody);

            foreach (var x in bankHolDeserializedClass.EnglandAndWales.events)
            {
                if (DateTime.Parse(x.date) > DateTime.Now)
                {
                    APIObjects.BankHolidays.bankHolidays.Add(x);
                }
            }
        }
        public static async Task MrChat(string s)
        {
            // oier wolfram API-Header // 2GVUAG-JERAUGG5QG //
            APIObjects.MrChat.Chat.Clear();

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://api.wolframalpha.com/v1/conversation.jsp?appid=2GVUAG-JERAUGG5QG&input=" + HttpUtility.UrlEncode(s));
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            MrChat.Root chatDeserializedClass = JsonSerializer.Deserialize<MrChat.Root>(responseBody);

            APIObjects.MrChat.Chat.Add(chatDeserializedClass);
        }

        public static async Task Converse(string s, string id, string url)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://" + url + "/api/v1/conversation.jsp?appid=2GVUAG-JERAUGG5QG&conversationid=" + id + "&i=" + HttpUtility.UrlEncode(s));
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            MrChat.Root chatDeserializedClass = JsonSerializer.Deserialize<MrChat.Root>(responseBody);

            APIObjects.MrChat.Chat.Add(chatDeserializedClass);

            APIObjects.MrChat.Chat.RemoveAt(0);
        }

        public async Task<string> YouTubeMusic(string keyWord)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer
            {
                ApiKey = "AIzaSyC_oVYtu9mGyEaNT42rylHayaVWcFyez0c",
                ApplicationName = GetType().ToString()
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = keyWord; // Replace with your search term.
            searchListRequest.MaxResults = 1;

            // Call the search.list method to retrieve results matching the specified query term.
            var searchListResponse = await searchListRequest.ExecuteAsync();

            List<string> videos = new List<string>();

            // Add each result to the appropriate list, and then display the lists of
            // matching videos, channels, and playlists.
            foreach (var searchResult in searchListResponse.Items)
            {
                switch (searchResult.Id.Kind)
                {
                    case "youtube#video":
                        videos.Add($"{searchResult.Snippet.Title} ({searchResult.Id.VideoId})");
                        break;
                }
            }

            using Process myProcess =
                Process.Start(
                    new ProcessStartInfo("https://www.youtube.com/watch?v=" + searchListResponse.Items[0].Id.VideoId)
                    { UseShellExecute = true });
            string responseTitle = searchListResponse.Items[0].Snippet.Title;
            return responseTitle;



        }
        /// <summary>
        /// word api implementation
        /// </summary>
        /// <returns></returns>
        public static async Task Word()
        {
            APIObjects.Word.word.Clear();

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://random-word-api.herokuapp.com/word");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            Regex reg = new Regex("[^a-zA-Z']");
            string result = reg.Replace(responseBody, string.Empty);

            APIObjects.Word.word.Add(result);
        }
        /// <summary>
        /// definitions api implementation
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static async Task GetDef(string s)
        {
            string body;
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://wordsapiv1.p.rapidapi.com/words/" + s + "/definitions"),
                Headers =
                {
                    { "X-RapidAPI-Key", "07adbb3e58msh8ae9c0438cba56ep1ff48bjsn86c5503b3e35" },
                    { "X-RapidAPI-Host", "wordsapiv1.p.rapidapi.com" },
                },
            };

            using (var response0 = await client.SendAsync(request))
            {
                response0.EnsureSuccessStatusCode();
                body = await response0.Content.ReadAsStringAsync();
            }

            Definitions.Defs.Clear();
            /*
            HttpResponseMessage response = await client.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            */
            Definitions.Root defDeserializedClass = JsonSerializer.Deserialize<Definitions.Root>(body);

            Definitions.Defs.Add(defDeserializedClass);
        }




    }
}
