using Riok.Mapperly.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Models;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.LearningArea.Mappers;

[Mapper]
internal static partial class BuildingToKiotaDtoMapper
{
    internal static partial BuildingDto ToDto(DomainWeb.LearningArea.Entities.Building building);

    internal static Guid FromGuidVO(DomainWeb.Shared.ValueObjects.GuidValueObject guidVO)
    {
        return guidVO.Value;
    }

    internal static string? FromLongNameVO(DomainWeb.Shared.ValueObjects.LongName longNameVO)
    {
        return longNameVO.Value;
    }

    internal static string? FromMediumNameVO(DomainWeb.Shared.ValueObjects.MediumName mediumNameDto)
    {
        return mediumNameDto.Value;
    }

    internal static string? FromShortNameVO(DomainWeb.Shared.ValueObjects.ShortName shortNameVO)
    {
        return shortNameVO.Value;
    }

    internal static double? FromCoordinateVO(DomainWeb.Shared.ValueObjects.Coordinate coordinateVO)
    {
        return coordinateVO.Value;
    }

    internal static double? FromSizeVO(DomainWeb.Shared.ValueObjects.Size sizeVO)
    {
        return sizeVO.Value;
    }

    internal static double? FromAngleVO(DomainWeb.Shared.ValueObjects.Angle angleVO)
    {
        return angleVO.Value;
    }

    internal static string? FromColorVO(DomainWeb.Shared.ValueObjects.Color colorVO)
    {
        return colorVO.Value;
    }

    internal static int? FromCounterVO(DomainWeb.Shared.ValueObjects.Counter counterVO)
    {
        return counterVO.Value;
    }

}
