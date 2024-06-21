using Riok.Mapperly.Abstractions;
using System;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Models;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Infrastructure.LearningArea.Mappers
{
    [Mapper]
    internal static partial class BuildingToKiotaDtoMapper
    {
        internal static partial BuildingDto ToDto(Domain.LearningArea.Entities.Building building);

        internal static Guid? FromGuidVO(Domain.Shared.ValueObjects.GuidValueObject guidVO)
        {
            return guidVO.Value;
        }

        internal static string? FromLongNameVO(Domain.Shared.ValueObjects.LongName longNameVO)
        {
            return longNameVO.Value;
        }

        internal static string? FromMediumNameVO(Domain.Shared.ValueObjects.MediumName mediumNameDto)
        {
            return mediumNameDto.Value;
        }

        internal static string? FromShortNameVO(Domain.Shared.ValueObjects.ShortName shortNameVO)
        {
            return shortNameVO.Value;
        }

        internal static double? FromCoordinateVO(Domain.Shared.ValueObjects.Coordinate coordinateVO)
        {
            return coordinateVO.Value;
        }

        internal static double? FromSizeVO(Domain.Shared.ValueObjects.Size sizeVO)
        {
            return sizeVO.Value;
        }

        internal static double? FromAngleVO(Domain.Shared.ValueObjects.Angle angleVO)
        {
            return angleVO.Value;
        }

        internal static string? FromColorVO(Domain.Shared.ValueObjects.Color colorVO)
        {
            return colorVO.Value;
        }

        internal static int? FromCounterVO(Domain.Shared.ValueObjects.Counter counterVO)
        {
            return counterVO.Value;
        }

    }
}
