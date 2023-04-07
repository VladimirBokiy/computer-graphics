using AForge.Imaging.Filters;
using AForge.Math;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SixLabors.ImageSharp.Advanced;
using SixLabors.ImageSharp.Processing.Processors.Filters;
using SixLabors.ImageSharp.Processing.Processors.Normalization;

namespace lab3.Pages;

public class ComparisonModel : PageModel
{
    private readonly ILogger<ComparisonModel> _logger;

    public ComparisonModel(ILogger<ComparisonModel> logger)
    {
        _logger = logger;
        
    }
    
    [BindProperty]
    public string FolderPath { get; set; }
    
    public class ImagePaths
    {
        public string Original { get; set; }
        public string Blurred { get; set; }
        public string Contrasted { get; set; }
        public string HistogramRGB { get; set; }
        public string HistogramHSV { get; set; }
    }

    public ImagePaths Paths { get; set; }

    public void OnGet(string path)  
    {
        FolderPath = "wwwroot/img/" + path;
        Console.WriteLine("Gogi Path: " + FolderPath);
        Paths = new ImagePaths();
        Paths.Original = "/img/" + path;
        Paths.Blurred = GetBlurredImage(FolderPath);
        Paths.Contrasted = GetContrastedImage(FolderPath);
        Paths.HistogramRGB = GetHistogramEqualizationRgb(FolderPath);
        Paths.HistogramHSV = GetHistogramEqualizationHsv(FolderPath);
    }

    

    public String GetBlurredImage(string path)
    {
        string outPath = "wwwroot/img/blurred.jpg";
        using (Image image = Image.Load(path))
        {
            image.Mutate(x => x.GaussianBlur(10)); 
            image.Save(outPath);  
        }
        return outPath.Substring(7);
    }
    
    public String GetContrastedImage(string path)
    {
        string outPath = "wwwroot/img/contrasted.jpg";
        var image = Image.Load(path);
        image.Mutate(x => ContrastExtensions.Contrast(x, 1.5f));
        image.Save(outPath);
        return outPath.Substring(7);
    }

    public String GetHistogramEqualizationRgb(string path)
    {
        string outPath = "wwwroot/img/equalized-rgb.jpg";
        
        var options = new HistogramEqualizationOptions();
        options.Method = HistogramEqualizationMethod.AutoLevel;
        options.SyncChannels = false;
        options.LuminanceLevels =500;
            
        var image = Image.Load(path);
        image.Mutate(x => HistogramEqualizationExtensions
            .HistogramEqualization(x, options));
        image.Save(outPath);
        return outPath.Substring(7);
    }
    
    public String GetHistogramEqualizationHsv(string path)
    {
        string outPath = "wwwroot/img/equalized-hsv.jpg";
        var options = new HistogramEqualizationOptions();
        options.Method = HistogramEqualizationMethod.AutoLevel;
        options.SyncChannels = false; 
        options.LuminanceLevels = 300;

        var image = Image.Load(path);
        image.Mutate(x => HistogramEqualizationExtensions
            .HistogramEqualization(x, options));
        image.Save(outPath);
        return outPath.Substring(7);
    }

}