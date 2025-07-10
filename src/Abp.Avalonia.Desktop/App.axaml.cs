using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using System.Linq;
using Abp.Avalonia.Desktop.ViewModels;
using Avalonia.Markup.Xaml;
using Abp.Avalonia.Desktop.Views;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using IAbpApplication = Abp.Avalonia.Desktop.Abp.IAbpApplication;

namespace Abp.Avalonia.Desktop;

public partial class App : Application, IAbpApplication
{
    public IAbpApplicationWithInternalServiceProvider AbpApp { get; set; }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var mainWindow = AbpApp.ServiceProvider.GetRequiredService<MainWindow>();
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Avoid duplicate validations from both Avalonia and the CommunityToolkit. 
            // More info: https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
            DisableAvaloniaDataAnnotationValidation();
            desktop.MainWindow = mainWindow;
            //desktop.MainWindow = new MainWindow(new MainWindowViewModel());
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = mainWindow;
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void DisableAvaloniaDataAnnotationValidation()
    {
        // Get an array of plugins to remove
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        // remove each entry found
        foreach (var plugin in dataValidationPluginsToRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }
    }
}