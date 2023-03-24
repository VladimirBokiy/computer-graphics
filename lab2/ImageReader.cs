using System.Net.Mime;
using System.Text;
using lab2.Pages;
using System.Drawing;

namespace lab2;

public class ImageReader {
    public List<ShowDirectoryModel.ImageInfo> ReadImageInfo(string path) {
        Console.WriteLine("Начало работы");
        if (!Directory.Exists(path)) {
            Console.WriteLine("Directory not found: " + path);
            return null;
        }
        
        List<ShowDirectoryModel.ImageInfo> res = new List<ShowDirectoryModel.ImageInfo>();
        
        List<String> paths = Directory.GetFiles(path).ToList();
        Console.WriteLine("Пути записаны");
        foreach (var s in paths)
        {
            ShowDirectoryModel.ImageInfo ii = new ShowDirectoryModel.ImageInfo();
            var image = Image.Load(s);
            ii.Height = image.Height;
            ii.Width = image.Width;
            ii.HorizontalResolution = Convert.ToInt32(image.Metadata.HorizontalResolution);
            ii.VerticalResolution = Convert.ToInt32(image.Metadata.VerticalResolution);
            ii.BitDepth = image.PixelType.BitsPerPixel;
            ii.ImagePath = s;
            ii.FileName = s.Split('\\').ToList().Last();
            res.Add(ii);
            Console.WriteLine("Фото " + paths.IndexOf(s) + " сохранено");
        }

        return res;
    }
}