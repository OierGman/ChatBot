using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;

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
        private async Task YouTubeMusic(string keyWord)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyC_oVYtu9mGyEaNT42rylHayaVWcFyez0c",
                ApplicationName = this.GetType().ToString()
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
                        videos.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.VideoId));
                        break;
                }
            }
        }
    }
}
