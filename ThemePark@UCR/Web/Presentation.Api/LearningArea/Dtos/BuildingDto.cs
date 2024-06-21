namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningArea.Dtos;

/// <summary>
/// Data Transfer Object for Building
/// </summary>
/// <param name="UniversityName">University Name of the Building</param>
/// <param name="CampusName">Campus Name of the Building</param>
/// <param name="SiteName">Site Name of the Building</param>
/// <param name="BuildingAcronym"></param>
/// <param name="BuildingName"></param>
/// <param name="CenterX">Position X of the center of the building</param>
/// <param name="CenterY">Position Y of the center of the building</param>
/// <param name="Length"></param>
/// <param name="Width"></param>
/// <param name="Rotation">Rotation in degrees of the building</param>
/// <param name="LevelCount">Number of levels of the building</param>
public record BuildingDto(
    Guid BuildingId, 
    string? UniversityName, 
    string? CampusName, 
    string? SiteName, 
    string? BuildingAcronym, 
    string? BuildingName, 
    double CenterX, 
    double CenterY, 
    double Length, 
    double Width, 
    double Rotation, 
    string? WallsColor, 
    string? RoofColor, 
    double Height, 
    byte LevelCount);
