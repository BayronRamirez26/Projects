using Riok.Mapperly.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Entities;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.LearningArea.Mappers;

/// <summary>
/// Building DTO mapper, receive building DTO and map to entity
/// VO = Value Object
/// </summary>
[Mapper]
internal static partial class BuildingDtoMapper
{
    internal static partial DomainWeb.LearningArea.Entities.Building ToEntity(Client.Models.BuildingDto buildingDto);

    internal static DomainWeb.Shared.ValueObjects.GuidValueObject ToGuidVO(Guid? guidDto)
    {
        return DomainWeb.Shared.ValueObjects.GuidValueObject.Create(guidDto);
    }
    
    internal static DomainWeb.Shared.ValueObjects.LongName ToLongNameVO(string? longNameDto)
    {
        return DomainWeb.Shared.ValueObjects.LongName.Create(longNameDto);
    }

    internal static DomainWeb.Shared.ValueObjects.MediumName ToMediumNameVO(string? mediumNameDto)
    {
        return DomainWeb.Shared.ValueObjects.MediumName.Create(mediumNameDto);
    }

    internal static DomainWeb.Shared.ValueObjects.ShortName ToShortNameVO(string? shortNameDto)
    {
        return DomainWeb.Shared.ValueObjects.ShortName.Create(shortNameDto);
    }

    internal static DomainWeb.Shared.ValueObjects.Coordinate ToCoordinateVO(double? coordinateDto)
    {
        return DomainWeb.Shared.ValueObjects.Coordinate.Create(coordinateDto);
    }

    internal static DomainWeb.Shared.ValueObjects.Size ToSizeVO(double? sizeDto)
    {
        return DomainWeb.Shared.ValueObjects.Size.Create(sizeDto);
    }

    internal static DomainWeb.Shared.ValueObjects.Size ToSizeVO(double sizeDto)
    {
        return DomainWeb.Shared.ValueObjects.Size.Create(sizeDto);
    }

    internal static DomainWeb.Shared.ValueObjects.Angle ToAngleVO(double? angleDto)
    {
        return DomainWeb.Shared.ValueObjects.Angle.Create(angleDto);
    }

    internal static DomainWeb.Shared.ValueObjects.Color ToColorVo(string? colorDto)
    {
        return DomainWeb.Shared.ValueObjects.Color.Create(colorDto);
    }

    internal static DomainWeb.Shared.ValueObjects.Counter ToCounterVO(int counterDto)
    {
        return DomainWeb.Shared.ValueObjects.Counter.Create((byte?)counterDto);
    }
}
