using Abp.Avalonia.Desktop.ViewModels.Controls;
using Abp.Avalonia.iTunes;
using AutoMapper;

namespace Abp.Avalonia.Desktop;

public class AvaloniaDesktopAutoMapperProfile : Profile
{
    public AvaloniaDesktopAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<AlbumDto, AlbumViewModel>()
            .ForMember(d=>d.Cover, o=>o.Ignore());
    }
}
