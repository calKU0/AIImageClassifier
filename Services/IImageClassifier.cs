using AIImageClassifier.Models;

namespace AIImageClassifier.Services
{
    public interface IImageClassifier
    {
        Task<List<ClassificationResult>> ClassifyAsync(byte[] imageBytes);
    }
}
