namespace AIImageClassifier.Models
{
    public class ImageInputModel
    {
        public IFormFile ImageFile { get; set; }
        public string UploadedImageBase64 { get; set; }
    }
}
