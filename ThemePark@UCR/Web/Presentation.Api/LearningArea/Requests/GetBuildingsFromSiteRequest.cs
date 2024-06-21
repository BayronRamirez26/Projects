namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningArea.Requests;

/// <summary>
/// Endpoint response for GetBuildings
/// </summary>
/// <param name="Building"></param>
public record GetBuildingsFromSiteRequest(string UniversityName, string CampusName, string SiteName);
