namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Dtos;

public class LevelDto
{
    public Guid LevelId { get; set; }
    public string? UniversityName { get; set; }
    public string? CampusName { get; set; }
    public string? SiteName { get; set; }
    public string? BuildingAcronym { get; set; }
    public byte LevelNumber { get; set; }
    public double SizeX { get; set; }
    public double SizeY { get; set; }
    public double SizeZ { get; set; }
    public string? WallsColor { get; set; }
    public string? FloorColor { get; set; }
    public string? CeilingColor { get; set; }
    public byte LearningSpaceCount { get; set; }
}
