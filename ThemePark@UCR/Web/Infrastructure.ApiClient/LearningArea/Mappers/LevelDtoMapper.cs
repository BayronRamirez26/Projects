using Riok.Mapperly.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.LearningArea.Mappers;

[Mapper]
internal static partial class LevelDtoMapper
{

    internal static partial Level ToEntity(Models.Level LevelDto);

    internal static GuidValueObject ToValueObject(Models.GuidValueObject guidValueObjectDto)
    {
        return GuidValueObject.Create(guidValueObjectDto.Value);
    }
    
    internal static LongName ToValueObject(Models.LongName longNameDto)
    {
        return LongName.Create(longNameDto.Value);
    }

    internal static MediumName ToValueObject(Models.MediumName mediumNameDto)
    {
        return MediumName.Create(mediumNameDto.Value);
    }

    internal static ShortName ToValueObject(Models.ShortName shortNameDto)
    {
        return ShortName.Create(shortNameDto.Value);
    }

    internal static DomainWeb.Shared.ValueObjects.Counter ToValueObject(Models.Counter counterDto)
    {
        return DomainWeb.Shared.ValueObjects.Counter.Create((byte)counterDto.Value);
    }

    internal static DomainWeb.Shared.ValueObjects.Size ToValueObject(Models.Size sizeDto)
    {
        return DomainWeb.Shared.ValueObjects.Size.Create((double)sizeDto.Value);
    }

    internal static Angle ToValueObject(Models.Angle angleDto)
    {
        return Angle.Create((double)angleDto.Value);
    }

    internal static DomainWeb.Shared.ValueObjects.Coordinate ToValueObject(Models.Coordinate coordinateDto)
    {
        return DomainWeb.Shared.ValueObjects.Coordinate.Create((double)coordinateDto.Value);
    }

    internal static Color ToValueObject(Client.Models.Color colorDto)
    {
        return Color.Create(colorDto.Value);
    }

    internal static Building ToValueObject(Client.Models.Building buildingDto)
    {
       return new Building(
        ToValueObject(buildingDto.BuildingId),
        ToValueObject(buildingDto.UniversityName),
        ToValueObject(buildingDto.CampusName),
        ToValueObject(buildingDto.SiteName),
        ToValueObject(buildingDto.BuildingAcronym),
        ToValueObject(buildingDto.BuildingName),
        ToValueObject(buildingDto.CenterX),
        ToValueObject(buildingDto.CenterY),
        ToValueObject(buildingDto.Length),
        ToValueObject(buildingDto.Width),
        ToValueObject(buildingDto.Rotation),
        ToValueObject(buildingDto.WallsColor),
        ToValueObject(buildingDto.RoofColor),
        ToValueObject(buildingDto.Height),
        ToValueObject(buildingDto.LevelCount)
      );
    }
}
