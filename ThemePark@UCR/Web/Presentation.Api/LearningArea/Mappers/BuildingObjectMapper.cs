using Riok.Mapperly.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningArea.Dtos;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningArea.Mappers;

[Mapper]
internal partial class BuildingObjectMapper
{
    internal static partial BuildingObject ToEntity(BuildingObjectDto buildingObject);

    internal static GuidValueObject ToGuidValueObjectVO(Guid objectId)
    {
        return GuidValueObject.Create(objectId);
    }

    internal static MediumName ToMediumNameVO(string mediumName)
    {
        return MediumName.Create(mediumName);
    }

    internal static Size ToSizeVO(double size)
    {
        return Size.Create(size);
    }

    internal static Coordinate ToCoordinateVO(double coordinate)
    {
        return Coordinate.Create(coordinate);
    }

    internal static Angle ToAngleVO(double angle)
    {
        return Angle.Create(angle);
    }

    internal static Color ToColorVO(string color)
    {
        return Color.Create(color);
    }

    internal static Counter ToCounterVO(byte counter)
    {
        return Counter.Create(counter);
    }

    internal static Color? ToColorNullableVO(string? color)
    {
        return color is null ? null : Color.Create(color);
    }

    internal static Counter? ToCounterNullableVO(byte? counter)
    {
        return counter is null ? null : Counter.Create(counter.Value);
    }
}
