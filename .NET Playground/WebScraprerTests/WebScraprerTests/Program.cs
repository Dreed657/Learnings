using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebScraprerTests
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            int count = 0;
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/89.0.4389.82 Safari/537.36 Edg/89.0.774.50");
            var currentStatus = HttpStatusCode.OK;

            do
            {
                var result = await client.GetAsync("https://www.dotabuff.com/players/66296404/matches?enhance=overview&page=1");
                Console.WriteLine($"#{count} {result.StatusCode}");

                currentStatus = result.StatusCode;
                count++;
            } while (currentStatus == HttpStatusCode.OK);
        }
    }
}
