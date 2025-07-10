using Abp.Avalonia.Desktop.Abp;
using Abp.Avalonia.Desktop.Messages;
using Abp.Avalonia.Desktop.ViewModels;
using Abp.Avalonia.Desktop.ViewModels.Controls;
using CommunityToolkit.Mvvm.Messaging;

namespace Abp.Avalonia.Desktop.Views;

public partial class MainWindow : AbpSukiWindow
{
    private MusicStoreWindow musicStoreWindow => LazyServiceProvider.LazyGetRequiredService<MusicStoreWindow>();
    public MainWindow(MainWindowViewModel mainWindowViewModel)
    {
        InitializeComponent();
        DataContext = mainWindowViewModel;
        WeakReferenceMessenger.Default.Register<MainWindow, PurchaseAlbumMessage>(this, (window, message) =>
        {
            var dialog = musicStoreWindow;
            message.Reply(dialog.ShowDialog<AlbumViewModel?>(window));
        });
    }
}