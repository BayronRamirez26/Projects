using Riok.Mapperly.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.LearningArea.Mappers;


[Mapper]
internal static partial class SiteDtoMapper
{
    internal static partial Site ToEntity(Site siteDto);

    internal static LongName ToValueObject(
        LongName longNameDto)
    {
        return LongName.Create(longNameDto.Value);
    }

    internal static MediumName ToValueObject(
        MediumName mediumNameDto)
    {
        return MediumName.Create(mediumNameDto.Value);
    }

    internal static Size ToValueObject(
        Size sizeDto)
    {
        return Size.Create((double)sizeDto.Value);
    }
}

