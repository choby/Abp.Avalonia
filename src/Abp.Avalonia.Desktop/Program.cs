using Avalonia;
using System;
using Abp.Avalonia.Desktop.Abp;

namespace Abp.Avalonia.Desktop;

sealed class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);
    
    private static AppBuilder BuildAvaloniaApp() => AbpApplicationBuilder.BuildAbpAvaloniaApp<App>();
}