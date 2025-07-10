using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Abp.Avalonia.Pages;

[Collection(AvaloniaTestConsts.CollectionDefinitionName)]
public class Index_Tests : AvaloniaWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
