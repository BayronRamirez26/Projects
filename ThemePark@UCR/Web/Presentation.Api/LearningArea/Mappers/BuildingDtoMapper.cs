using Riok.Mapperly.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningArea.Dtos;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningArea.Mappers;

[Mapper]
internal partial class BuildingDtoMapper
{
    internal static partial BuildingDto FromEntity(Building building);

    internal static Guid FromGuidValueObject(GuidValueObject idDto)
    {
        return idDto.Value;
    }

    internal static string? FromLongName(LongName longNameDto)
    {
        return longNameDto.Value;
    }

    internal static string? FromMediumName(MediumName mediumNameDto)
    {
        return mediumNameDto.Value;
    }

    internal static string? FromShortName(ShortName shortNameDto)
    {
        return shortNameDto.Value;
    }

    internal static double FromCoordinate(Coordinate coordinateDto)
    {
        return coordinateDto.Value;
    }

    internal static double FromSize(Size sizeDto)
    {
        return sizeDto.Value;
    }

    internal static double FromAngle(Angle angleDto)
    {
        return angleDto.Value;
    }

    internal static string? FromColor(Color colorDto)
    {
        return colorDto.Value;
    }

    internal static byte FromCounter(Counter counterDto)
    {
        return counterDto.Value;
    }

}
    