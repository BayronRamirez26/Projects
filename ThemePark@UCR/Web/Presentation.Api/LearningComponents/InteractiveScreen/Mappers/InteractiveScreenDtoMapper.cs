using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningComponents.InteractiveScreen.Dtos;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningComponents.InteractiveScreen.Mappers;

internal partial class InteractiveScreenDtoMapper
{
    internal static InteractiveScreenDto FromEntitity(Domain.LearningComponents.Entities.InteractiveScreen interactiveScreen)
    {
        return new InteractiveScreenDto(
            interactiveScreen.LearningComponentAssetId,
            interactiveScreen.LearningComponentName.Value,
            interactiveScreen.SizeX.Value,
            interactiveScreen.SizeY.Value,
            interactiveScreen.PositionX.Value,
            interactiveScreen.PositionY.Value,
            interactiveScreen.PositionZ.Value,
            interactiveScreen.RotationX.Value,
            interactiveScreen.RotationY.Value,
            interactiveScreen.LearningSpaceId);
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
