using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iTunesSearch.Library;

namespace Abp.Avalonia.iTunes;

public class iTunesService : AvaloniaAppService
{
    private iTunesSearchManager _iTunesSearchManager;

    public iTunesService(iTunesSearchManager iTunesSearchManager)
    {
        _iTunesSearchManager = iTunesSearchManager;
    }
    
    public async Task<IEnumerable<AlbumDto>> SearchAsync(string searchTerm)
    {
       

        var query = await _iTunesSearchManager.GetAlbumsAsync(searchTerm, countryCode:"cn")
            .ConfigureAwait(false);
                
        return query.Albums.Select(x =>
            new AlbumDto(x.ArtistName, x.CollectionName, 
                x.ArtworkUrl100.Replace("100x100bb", "600x600bb")));
    }
}