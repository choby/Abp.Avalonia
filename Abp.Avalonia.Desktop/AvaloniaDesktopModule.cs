using Abp.Avalonia.EntityFrameworkCore;
using Avalonia.Controls;
using Microsoft.AspNetCore.Identity;
using SukiUI.Controls;
using Volo.Abp.Autofac;
using Volo.Abp.AutoMapper;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.Identity.AspNetCore;
using Volo.Abp.Modularity;

namespace Abp.Avalonia.Desktop;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AvaloniaApplicationModule),
    typeof(AvaloniaEntityFrameworkCoreModule),
    typeof(AbpIdentityAspNetCoreModule)
)]
public class AvaloniaDesktopModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IdentityBuilder>(builder =>
        {
            builder
                .AddDefaultTokenProviders()
                .AddTokenProvider<LinkUserTokenProvider>(LinkUserTokenProviderConsts.LinkUserTokenProviderName)
                .AddSignInManager<AbpSignInManager>()
                .AddUserValidator<AbpIdentityUserValidator>();
        });
    }
    
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        ConfigureAutoMapper();
    }
    
    private void ConfigureAutoMapper()
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<AvaloniaDesktopModule>();
        });
    }
}




