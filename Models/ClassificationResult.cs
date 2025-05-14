using System.Text.Json.Serialization;

namespace AIImageClassifier.Models
{
    public class ClassificationResult
    {
        [JsonPropertyName("label")]
        public string Label { get; set; }
        [JsonPropertyName("score")]
        public float Score { get; set; }
    }
}
