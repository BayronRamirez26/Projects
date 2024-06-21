using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningComponents.Projector.Dtos;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningComponents.Whiteboard.Responses;
/// <summary>
/// 
/// </summary>
/// <param name="projectors"></param>
public record GetProjectorResponse(IEnumerable<ProjectorDto> projectorsDto);