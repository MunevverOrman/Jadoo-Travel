using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace JadooTravel.Services
{
    public class OpenAiTravelService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public OpenAiTravelService(IConfiguration configuration, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _apiKey = configuration["Groq:ApiKey"]
                      ?? throw new Exception("Groq ApiKey bulunamadı");
        }

        // DİKKAT: languageCode parametresi eklendi (tr, en, fr)
        public async Task<string> GetPlacesForCityAsync(string city, string languageCode)
        {
            // 1) Dile göre system ve user mesajlarını hazırla
            string systemContent;
            string userContent;

            switch (languageCode)
            {
                case "tr":
                    systemContent =
                        "Sen bir seyahat rehberisin. Kullanıcının verdiği şehir için Türkçe olarak 5 tane gezilecek yer liste. " +
                        "Her madde şu formatta olsun: '1. Yer Adı: 2-3 cümlelik kısa açıklama...'. " +
                        "Genel giriş veya kapanış cümlesi yazma, sadece liste ver.";
                    userContent = $"{city} şehrinde gezilecek yerleri listele.";
                    break;

                case "fr":
                    systemContent =
                        "Tu es un guide de voyage. Pour la ville donnée, liste en français 5 lieux à visiter. " +
                        "Chaque point doit suivre ce format : '1. Nom du lieu : description courte de 2-3 phrases...'. " +
                        "N’écris pas d’introduction ni de conclusion, donne uniquement la liste.";
                    userContent = $"Liste les lieux à visiter dans la ville de {city}.";
                    break;

                default: // en
                    systemContent =
                        "You are a travel guide. For the given city, list 5 places to visit in English. " +
                        "Each item should follow this format: '1. Place Name: short 2-3 sentence description...'. " +
                        "Do not write any introduction or closing sentence, only return the list.";
                    userContent = $"List places to visit in {city}.";
                    break;
            }

            var body = new
            {
                model = "llama-3.1-8b-instant",
                messages = new[]
                {
                    new
                    {
                        role = "system",
                        content = systemContent
                    },
                    new
                    {
                        role = "user",
                        content = userContent
                    }
                },
                temperature = 0.7
            };

            var json = JsonSerializer.Serialize(body);

            var request = new HttpRequestMessage(
                HttpMethod.Post,
                "https://api.groq.com/openai/v1/chat/completions");

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request);

            if (response.StatusCode == (HttpStatusCode)429)
            {
                return languageCode switch
                {
                    "tr" => "Şu anda ücretsiz Groq kotası aşıldı. Birkaç dakika sonra tekrar dene.",
                    "fr" => "Le quota Groq gratuit a été dépassé. Réessaie dans quelques minutes.",
                    _ => "The free Groq quota has been exceeded. Please try again in a few minutes."
                };
            }

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();

                var prefix = languageCode switch
                {
                    "tr" => "AI servisi bir hata döndürdü:",
                    "fr" => "Le service d’IA a renvoyé une erreur :",
                    _ => "The AI service returned an error:"
                };

                return $"{prefix} {response.StatusCode}\n{errorContent}";
            }

            var responseString = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(responseString);

            var content = doc.RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString();

            return content ?? (languageCode switch
            {
                "tr" => "Sonuç alınamadı.",
                "fr" => "Aucun résultat obtenu.",
                _ => "No result received."
            });
        }
    }
}
