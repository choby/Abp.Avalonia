using Xunit;

namespace Abp.Avalonia.EntityFrameworkCore;

[CollectionDefinition(AvaloniaTestConsts.CollectionDefinitionName)]
public class AvaloniaEntityFrameworkCoreCollection : ICollectionFixture<AvaloniaEntityFrameworkCoreFixture>
{

}
