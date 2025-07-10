using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Abp.Avalonia.Desktop.Abp;
using Abp.Avalonia.Desktop.Messages;
using Abp.Avalonia.Desktop.ViewModels.Controls;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Configuration;
using ReactiveUI;
using Volo.Abp.DependencyInjection;

namespace Abp.Avalonia.Desktop.ViewModels;

public partial class MainWindowViewModel : AbpViewModel
{
    public ObservableCollection<AlbumViewModel> Albums { get; } = new();

    public ICommand BuyMusicCommand { get; }

    public MainWindowViewModel()
    {
        BuyMusicCommand = ReactiveCommand.Create(async () =>
        {
            await AddAlbumAsync();
        });
    }
    
    [RelayCommand]
    private async Task AddAlbumAsync()
    {
        // Send the message to the previously registered handler and await the selected album
        var album = await WeakReferenceMessenger.Default.Send(new PurchaseAlbumMessage());
        if (album is not null)
        {
            Albums.Add(album);
        }
    }
}