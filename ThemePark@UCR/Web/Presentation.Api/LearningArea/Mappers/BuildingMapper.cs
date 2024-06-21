using Riok.Mapperly.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningArea.Dtos;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningArea.Mappers;

[Mapper]
internal partial class BuildingMapper
{
    internal static partial Building ToEntity(BuildingDto building);

    internal static GuidValueObject ToGuidValueObjectVO(Guid buildingId)
    {
        return GuidValueObject.Create(buildingId);
    }

    internal static LongName ToLongNameVO(string longName)
    {
        return LongName.Create(longName);
    }

    internal static MediumName ToMediumNameVO(string mediumName)
    {
        return MediumName.Create(mediumName);
    }

    internal static ShortName ToShortNameVO(string shortName)
    {
        return ShortName.Create(shortName);
    }

    internal static Coordinate ToCoordinateVO(double coordinate)
    {
        return Coordinate.Create(coordinate);
    }

    internal static Size ToSizeVO(double size)
    {
        return Size.Create(size);
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

}
