using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Abp.Avalonia.Desktop.Abp;
using Abp.Avalonia.Desktop.Messages;
using Abp.Avalonia.iTunes;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using DynamicData;
using ReactiveUI;

namespace Abp.Avalonia.Desktop.ViewModels.Controls;

public partial class MusicStoreAbpViewModel : AbpViewModel
{
    
    private iTunesService _iTunesService;
    public ObservableCollection<AlbumViewModel> SearchResults { get; } = new();
    public ICommand ComfirmBuyMusicCommand { get; }
    [ObservableProperty] public partial string? SearchText { get ; set ; }

    [ObservableProperty] public partial bool IsBusy { get ; set ; }
    [ObservableProperty] public partial AlbumViewModel? SelectedAlbum { get; set; }
    
    private CancellationTokenSource? _cancellationTokenSource;
    
    public MusicStoreAbpViewModel(iTunesService iTunesService)
    {
        _iTunesService = iTunesService;
        this.WhenAnyValue(x => x.SearchText)
            .Throttle(TimeSpan.FromMilliseconds(400))
            .ObserveOn(RxApp.MainThreadScheduler)
            .Subscribe(DoSearch!);

        this.ComfirmBuyMusicCommand = ReactiveCommand.Create(async () => await BuyMusicAsync());
    }

    private async void DoSearch(string searchText)
    {
        if(string.IsNullOrWhiteSpace(searchText))
            return;
        _cancellationTokenSource?.Cancel();
        _cancellationTokenSource = new CancellationTokenSource();
        var cancellationToken = _cancellationTokenSource.Token;
        this.IsBusy = true;
        this.SearchResults.Clear();
        
        if (!string.IsNullOrWhiteSpace(searchText))
        {
            var albums = await _iTunesService.SearchAsync(searchText);
            this.SearchResults.AddRange(ObjectMapper.Map<IEnumerable<AlbumDto>, IEnumerable<AlbumViewModel>>(albums));
        }
       
        if (!cancellationToken.IsCancellationRequested)
        {
            LoadCovers(cancellationToken);
        }
        this.IsBusy = false;
    }
    
    private async void LoadCovers(CancellationToken cancellationToken)
    {
        
        foreach (var album in SearchResults)
        {
            await album.LoadCoverAsync();

            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }
        }
    }

    [RelayCommand]
    private async Task BuyMusicAsync()
    {
        if (this.SelectedAlbum != null)
        {
            WeakReferenceMessenger.Default.Send(new MusicStoreClosedMessage(this.SelectedAlbum));
        }
    }
}