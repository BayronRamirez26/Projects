namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Dtos;

public class BuildingDto
{
    public Guid BuildingId { get; set; }
    public string? UniversityName { get; set; }
    public string? CampusName { get; set; }
    public string? SiteName { get; set; }
    public string? BuildingAcronym { get; set; }
    public string? BuildingName { get; set; }
    public double CenterX { get; set; }
    public double CenterY { get; set; }
    public double Length { get; set; }
    public double Width { get; set; }
    public double Rotation { get; set; }
    public string? WallsColor { get; set; }
    public string? RoofColor { get; set; }
    public double Height { get; set; }
    public byte LevelCount { get; set; }
}