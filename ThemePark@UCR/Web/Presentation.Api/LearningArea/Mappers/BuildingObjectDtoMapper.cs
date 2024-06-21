using Riok.Mapperly.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningArea.Dtos;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningArea.Mappers;

[Mapper]
internal partial class BuildingObjectDtoMapper
{
    internal static partial BuildingObjectDto FromEntity(BuildingObject buildingObject);

    internal static Guid FromGuidValueObject(GuidValueObject objectIdDto)
    {
        return objectIdDto.Value;
    }

    internal static string? FromMediumName(MediumName mediumNameDto)
    {
        return mediumNameDto.Value;
    }

    internal static double FromSize(Size sizeDto)
    {
        return sizeDto.Value;
    }

    internal static double FromCoordinate(Coordinate coordinateDto)
    {
        return coordinateDto.Value;
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

    internal static string? FromColorNullable(Color? colorDto)
    {
        return colorDto?.Value;
    }

    internal static byte? FromCounterNullable(Counter? counterDto)
    {
        return counterDto?.Value;
    }
}
