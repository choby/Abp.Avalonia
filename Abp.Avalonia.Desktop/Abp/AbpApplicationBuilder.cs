using System;
using System.IO;
using Avalonia;
using Avalonia.ReactiveUI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;

namespace Abp.Avalonia.Desktop.Abp;

public static class AbpApplicationBuilder
{
    public static AppBuilder BuildAbpAvaloniaApp<TApp>(string[] args) where TApp : Application,IAbpApplication, new()
    {
        var appBuilder = AppBuilder.Configure(appFactory: () =>
        {
            var app = new TApp();
            // IConfiguration configuration = new ConfigurationBuilder()
            //     .SetBasePath(Directory.GetCurrentDirectory())
            //     .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            //     .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ENVIRONMENT")}.json", optional: true, reloadOnChange: true)
            //     .AddEnvironmentVariables()
            //     .AddCommandLine(args)
            //     .Build();
            app.AbpApp = AbpApplicationFactory.Create<AvaloniaDesktopModule>(options =>
            {
                options.UseAutofac();
                // options.Services.ReplaceConfiguration(configuration);
            });
            app.AbpApp.Initialize();
            
            return app;
        });
        appBuilder.UsePlatformDetect()
            .UseReactiveUI()
            .WithInterFont()
            .LogToTrace();

        return appBuilder;
    }
}