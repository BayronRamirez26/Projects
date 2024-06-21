using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities.Wrappers;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningComponents.InteractiveScreen.Dtos;

/// <summary>
/// 
/// </summary>
/// <param name="learningComponenName"></param>
/// <param name="sizeX"></param>
/// <param name="sizeY"></param>
/// <param name="positionX"></param>
/// <param name="positionY"></param>
/// <param name="positionZ"></param>
public record InteractiveScreenDto(int learningComponentId, string learningComponenName, double sizeX, double sizeY, double positionX, double positionY, double positionZ, double rotationX, double rotationY, GuidWrapper learningSpaceId);
