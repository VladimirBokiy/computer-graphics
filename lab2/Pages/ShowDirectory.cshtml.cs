using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab2.Pages;

public class ShowDirectoryModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    
    private readonly ImageReader _imageReader;

    [BindProperty]
    public List<ImageInfo> Info { get; set; }
    
    [BindProperty]
    public string FolderPath { get; set; }
    

    public ShowDirectoryModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
        _imageReader = new ImageReader();
    }

    public void OnGet(string path)
    {
        Console.WriteLine("Вызван обработчик страницы");
        FolderPath = path;
        Info = _imageReader.ReadImageInfo(FolderPath);
        Console.WriteLine("Информация готова к отображению.");
    }

    public class ImageInfo {
        public string FileName { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int HorizontalResolution { get; set; }
        public int VerticalResolution { get; set; }
        public int BitDepth { get; set; }
        public string CompressionType { get; set; }
        public string ImagePath { get; set; }
    }
}