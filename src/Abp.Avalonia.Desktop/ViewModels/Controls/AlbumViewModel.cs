using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Abp.Avalonia.Desktop.Abp;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using ReactiveUI;

namespace Abp.Avalonia.Desktop.ViewModels.Controls;

public partial class AlbumViewModel : ObservableObject
{
    public string Artist { get; set; }

    public string Title  { get; set; }
    
    public string CoverUrl { get; set; }
    
    
    private static HttpClient _httpClient = new();
    private string CachePath => $"./Cache/{SanitizeFileName(Artist)} - {SanitizeFileName(Title)}";

    
    [ObservableProperty] public partial Bitmap? Cover { get; private set; }

    public async Task LoadCoverAsync()
    {
        await using (var imageStream = await this.LoadCoverBitmapAsync())
        {
            Cover = await Task.Run(() => Bitmap.DecodeToWidth(imageStream, 400));
        }
    }
    
    private async Task<Stream> LoadCoverBitmapAsync()
    {
        if (File.Exists(CachePath + ".bmp"))
        {
            return File.OpenRead(CachePath + ".bmp");
        }
        else
        {
            var data = await _httpClient.GetByteArrayAsync(CoverUrl);
            return new MemoryStream(data);
        }
    }
    
    private static string SanitizeFileName(string input)
    {
        foreach (var c in Path.GetInvalidFileNameChars())
        {
            input = input.Replace(c, '_');
        }
        return input;
    }
    
}