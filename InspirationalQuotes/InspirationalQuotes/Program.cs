using System.Text.Json.Nodes;

namespace InspirationalQuotes
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome to the textual motivator!");
            var quote = await GetDailyQuoteAsync();
            Console.Write("Here's your daily quote: ");
            Console.WriteLine(quote);
        }

        static async Task<string> GetDailyQuoteAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                // API options:
                // https://zenquotes.io/api/today
                // https://quotes.rest/qod?category=inspire -- limit 5/day

                string apiUrl = "https://zenquotes.io/api/today";
                string response = await client.GetStringAsync(apiUrl);

                JsonArray jsonArray = JsonNode.Parse(response) as JsonArray;
                JsonObject quoteObject = jsonArray[0] as JsonObject;

                string quote = quoteObject["q"].ToString();

                return quote;
            }
        }

        // TODO: Find Bible verses that health and fitness--use labs.bible.org API
    }
}