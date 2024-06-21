using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningComponents.Whiteboard.Dtos;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningComponents.Whiteboard.Responses;
public record GetWhiteboardsResponse(IEnumerable<WhiteboardDto> whiteboards);
