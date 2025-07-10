using Abp.Avalonia.Desktop.Abp;
using Abp.Avalonia.Desktop.Messages;
using Abp.Avalonia.Desktop.ViewModels.Controls;
using CommunityToolkit.Mvvm.Messaging;

namespace Abp.Avalonia.Desktop.Views;

public partial class MusicStoreWindow : AbpSukiWindow
{
    public MusicStoreWindow(MusicStoreAbpViewModel musicStoreAbpViewModel)
    {
        InitializeComponent();
        DataContext = musicStoreAbpViewModel;
        WeakReferenceMessenger.Default.Register<MusicStoreWindow, MusicStoreClosedMessage>(this,
            static (window, message) => window.Close(message.SelectedAlbum));
    }
}