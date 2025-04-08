using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace LostInTranslation
{
    internal class TranslatorService
    {
        private readonly string subscriptionKey = "5aeCGi1O3QGPMyanYhh5Kp0czphq2bTx58dLivWVntRKogeKuoF6JQQJ99BDACsaGQgXJ3w3AAAbACOGru1D";
        private readonly string endpoint = "https://api.cognitive.microsofttranslator.com";
        private readonly string region = "switzerlandwest"; // z. B. 'westeurope', 'northeurope', je nach Azure-Region

        public async Task<string> TranslateText(string text, string toLanguage)
        {
            if (string.IsNullOrWhiteSpace(text)) return string.Empty;

            string route = $"/translate?api-version=3.0&to={toLanguage}";
            object[] body = new object[] { new { Text = text } };
            var requestBody = Newtonsoft.Json.JsonConvert.SerializeObject(body);

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Region", region);

            using var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(endpoint + route),
                Content = new StringContent(requestBody, Encoding.UTF8, "application/json")
            };

            HttpResponseMessage response = await client.SendAsync(request);
            string result = await response.Content.ReadAsStringAsync();

            var jsonResult = JArray.Parse(result);
            string translatedText = jsonResult[0]["translations"][0]["text"].ToString();

            return translatedText;
        }
    }
}
