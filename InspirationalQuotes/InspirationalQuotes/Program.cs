using System.Text.Json.Nodes;

namespace InspirationalQuotes
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Here's your daily motivation:");
            var quote = await GetDailyQuoteAsync();
            Console.WriteLine(quote);
        }

        static async Task<string> GetDailyQuoteAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                // API options:
                //https://zenquotes.io/api/today
                //https://quotes.rest/qod?category=inspire
                string apiUrl = "https://zenquotes.io/api/today";
                string response = await client.GetStringAsync(apiUrl);

                JsonArray jsonArray = JsonNode.Parse(response) as JsonArray;
                JsonObject quoteObject = jsonArray[0] as JsonObject;

                string quote = quoteObject["q"].ToString();

                return quote;
            }
        }
    }
}