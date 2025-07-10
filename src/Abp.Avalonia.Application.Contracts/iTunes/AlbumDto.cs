using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Abp.Avalonia.iTunes;

public class AlbumDto
{
    public string Artist { get; set; }
    public string Title { get; set; }
    public string CoverUrl { get; set; }
   
    public AlbumDto(string artist, string title, string coverUrl)
    {
        Artist = artist;
        Title = title;
        CoverUrl = coverUrl;
    }

    
    
    
}