using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AIImageClassifier.Models;
using AIImageClassifier.Services;
using System.Reflection;
using Newtonsoft.Json;

namespace AIImageClassifier.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IImageClassifier _classifier;
    private readonly string _apiKey;
    private readonly string _cx;

    public HomeController(ILogger<HomeController> logger, IImageClassifier classifier, IConfiguration configuration)
    {
        _apiKey = configuration["Google:ApiKey"];
        _cx = configuration["Google:cx"];
        _logger = logger;
        _classifier = classifier;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View(new ImageInputModel());
    }

    [HttpPost]
    public async Task<IActionResult> Index(ImageInputModel model)
    {
        if (model.ImageFile != null && model.ImageFile.Length > 0)
        {
            using var ms = new MemoryStream();
            await model.ImageFile.CopyToAsync(ms);
            var imageBytes = ms.ToArray();

            var results = await _classifier.ClassifyAsync(imageBytes);
            model.UploadedImageBase64 = $"data:{model.ImageFile.ContentType};base64,{Convert.ToBase64String(imageBytes)}";

            var imageLabel = results.FirstOrDefault()?.Label;
            var similarImages = await GetSimilarImagesAsync(imageLabel);

            ViewBag.Results = results;
            ViewBag.SimilarImages = similarImages;
        }

        return View(model);
    }

    private async Task<List<string>> GetSimilarImagesAsync(string query)
    {
        var client = new HttpClient();
        var url = $"https://www.googleapis.com/customsearch/v1?q={query}&key={_apiKey}&cx={_cx}&searchType=image&num=5"; // Search for 5 images

        var response = await client.GetStringAsync(url);
        var jsonResponse = JsonConvert.DeserializeObject<dynamic>(response);

        var imageUrls = new List<string>();

        foreach (var item in jsonResponse.items)
        {
            var imageUrl = item.link.ToString();
            imageUrls.Add(imageUrl);
        }

        return imageUrls;
    }
}
