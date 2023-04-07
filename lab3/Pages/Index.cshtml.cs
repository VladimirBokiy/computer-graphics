using AForge.Imaging.Filters;
using AForge.Math;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SixLabors.ImageSharp.Advanced;
using SixLabors.ImageSharp.Processing.Processors.Filters;
using SixLabors.ImageSharp.Processing.Processors.Normalization;

namespace lab3.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }
    
    [BindProperty]
    public string Path { get; set; }


    public void OnGet()
    {
        
    }

    public IActionResult OnPost()
    {
        return RedirectToPage("Comparison", new {path = Path });
    }
}   