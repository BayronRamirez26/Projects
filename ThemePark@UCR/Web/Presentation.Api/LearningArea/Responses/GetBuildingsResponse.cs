using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningArea.Dtos;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningArea.Responses;

/// <summary>
/// Endpoint response for GetBuildings
/// </summary>
/// <param name="Buildings"></param>
public record GetBuildingsResponse(IEnumerable<BuildingDto> Buildings);
