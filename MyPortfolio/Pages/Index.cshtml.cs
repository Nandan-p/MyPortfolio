using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace MyPortfolio.Pages;

public class IndexModel(ILogger<IndexModel> logger) : PageModel
{
    private readonly ILogger<IndexModel> _logger = logger;
    public string BackgroundImage { get; set; } = "/img/coding_1280.jpg";

    public void OnGet()
    {
        BackgroundImage = GetBackgroundImage();
    }
    public string GetBackgroundImage()
    {
        var imageFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img");
        string[] images = Directory.GetFiles(imageFolderPath, "*.*")
                                   .Select(Path.GetFileName)
                                   .ToArray();

        int index = DateTime.Now.DayOfWeek.GetHashCode() % images.Length;
        return $"/img/{images[index]}";
    }

}
