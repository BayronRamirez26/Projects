using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningComponents.InteractiveScreen.Dtos;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningComponents.InteractiveScreen.Responses;
public record GetInteractiveScreenResponse(IEnumerable<InteractiveScreenDto> InteractiveScreenDtos);