using Riok.Mapperly.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningComponents.AIAssistant.Dtos;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.AIAssistant.Mappers;


[Mapper]
internal partial class AIAssistantDtoMapper
{
    internal static AIAssistantDto FromEntitiy(Domain.LearningComponents.Entities.AIAssistant aIAssistant)
    {
        return new AIAssistantDto(
            aIAssistant.LearningComponentAssetId,
            aIAssistant.LearningComponentName.Value,
            aIAssistant.SizeX.Value,
            aIAssistant.SizeY.Value,
            aIAssistant.PositionX.Value,
            aIAssistant.PositionY.Value,
            aIAssistant.PositionZ.Value,
            aIAssistant.RotationX.Value,
            aIAssistant.RotationY.Value,
            aIAssistant.LearningSpaceId);
    }

    internal static string MediumName(MediumName mediumNameDto)
    {
        return mediumNameDto.Value;
    }

    internal static string shortName(ShortName shortNameDto)
    {
        return shortNameDto.Value;
    }

    internal static double size(Size sizeDto) {
    
    return sizeDto.Value;
    }

    internal static double coordinate(Coordinate coordinateDto)
    {
        return coordinateDto.Value;
    }
}