using AIImageClassifier.Models;
using AIImageClassifier.Services;
using System.Net.Http.Headers;
using System.Text.Json;

namespace AIImageClassifier.Services
{
    public class HuggingFaceImageClassifier : IImageClassifier
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl = "https://api-inference.huggingface.co/models/microsoft/resnet-50";
        private readonly string _apiToken;

        public HuggingFaceImageClassifier(IConfiguration configuration, HttpClient httpClient)
        {
            _apiToken = configuration["HuggingFace:ApiToken"];
            _httpClient = httpClient;
        }

        public async Task<List<ClassificationResult>> ClassifyAsync(byte[] imageBytes)
        {
            using var request = new HttpRequestMessage(HttpMethod.Post, _apiUrl);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken);
            request.Content = new ByteArrayContent(imageBytes);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Odpowiedź z API: " + json);
            var data = JsonSerializer.Deserialize<List<ClassificationResult>>(json);

            Console.WriteLine("data: " + data.FirstOrDefault().Label);
            return data ?? new List<ClassificationResult>();
        }
    }
}
