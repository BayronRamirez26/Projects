using Riok.Mapperly.Abstractions;
using System;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Infrastructure.ApiClient.LearningArea.Mappers
{
    /// <summary>
    /// Building DTO mapper, receive building DTO and map to entity
    /// VO = Value Object
    /// </summary>
    [Mapper]
    internal static partial class BuildingDtoMapper
    {
        internal static partial Building ToEntity(
            ThemePark_UCR.Infrastructure.ApiClient.Client.Models.BuildingDto buildingDto);

        internal static GuidValueObject ToGuidVO(Guid? guidDto)
        {
            return GuidValueObject.Create(guidDto);
        }
    
        internal static LongName ToLongNameVO(string? longNameDto)
        {
            return LongName.Create(longNameDto);
        }

        internal static MediumName ToMediumNameVO(string? mediumNameDto)
        {
            return MediumName.Create(mediumNameDto);
        }

        internal static ShortName ToShortNameVO(string? shortNameDto)
        {
            return ShortName.Create(shortNameDto);
        }

        internal static Coordinate ToCoordinateVO(double? coordinateDto)
        {
            return Coordinate.Create(coordinateDto);
        }

        internal static Size ToSizeVO(double? sizeDto)
        {
            return Size.Create(sizeDto);
        }

        internal static Angle ToAngleVO(double? angleDto)
        {
            return Angle.Create(angleDto);
        }

        internal static Color ToColorVo(string? colorDto)
        {
            return Color.Create(colorDto);
        }

        internal static Counter ToCounterVO(int? counterDto)
        {
            return Counter.Create((byte?)counterDto);
        }
    }
}
