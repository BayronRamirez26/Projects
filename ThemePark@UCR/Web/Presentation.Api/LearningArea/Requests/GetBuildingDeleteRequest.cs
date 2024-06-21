namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningArea.Requests;

/// <summary>
/// Endpoint response for GetBuildings
/// </summary>
/// <param name="Building"></param>
public record GetBuildingDeleteRequest(string UniversityName, string CampusName, string SiteName, string BuildingAcronym);
