using Microsoft.AspNetCore.Builder;
using Abp.Avalonia;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
builder.Environment.ContentRootPath = GetWebProjectContentRootPathHelper.Get("Abp.Avalonia.Web.csproj"); 
await builder.RunAbpModuleAsync<AvaloniaWebTestModule>(applicationName: "Abp.Avalonia.Web");

public partial class Program
{
}
