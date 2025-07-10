using Abp.Avalonia.Desktop.ViewModels.Controls;

namespace Abp.Avalonia.Desktop.Messages;

public class MusicStoreClosedMessage(AlbumViewModel selectedAlbum)
{
    public AlbumViewModel SelectedAlbum { get; } = selectedAlbum;
}