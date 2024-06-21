using Riok.Mapperly.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningComponents.Whiteboard.Dtos;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningComponents.Whiteboard.Mappers;

[Mapper]
internal partial class WhiteboardDtoMapper
{
    internal static WhiteboardDto FromEntitity(Domain.LearningComponents.Entities.Whiteboard whiteboard)
    {
        return new WhiteboardDto(
            whiteboard.LearningComponentAssetId,
            whiteboard.LearningComponentName.Value,
            whiteboard.SizeX.Value,
            whiteboard.SizeY.Value,
            whiteboard.PositionX.Value,
            whiteboard.PositionY.Value,
            whiteboard.PositionZ.Value,
            whiteboard.RotationX.Value,
            whiteboard.RotationY.Value,
            whiteboard.LearningSpaceId);
    }
    internal static string MediumName(MediumName mediumNameDto)
    {
        return mediumNameDto.Value;
    }

    internal static string shortName(ShortName shortNameDto)
    {
        return shortNameDto.Value;
    }

    internal static double size(Size sizeDto)
    {

        return sizeDto.Value;
    }

    internal static double coordinate(Coordinate coordinateDto)
    {
        return coordinateDto.Value;
    }


}