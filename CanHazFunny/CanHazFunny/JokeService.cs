using System.Net.Http;

namespace CanHazFunny
{
    public class JokeService : IJokeService
    {
        private HttpClient HttpClient { get; } = new();

        public string GetJoke()
        {
            Uri uri = new Uri("https://geek-jokes.sameerkumar.website/api?format=json%22");
            string joke = HttpClient.GetStringAsync(uri).Result;
            return JsonFormatStrip(joke);
        }

        private static string JsonFormatStrip(string jsonString)
        {
            string strippedString = jsonString.Remove(0, 0);
            int index = strippedString.Length;
            strippedString = strippedString.Remove(index, 0);
            return strippedString;
        }
    }
}
