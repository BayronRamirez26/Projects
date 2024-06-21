using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Entities;

public class Building
{
    public GuidValueObject BuildingId { get; }

    public LongName UniversityName { get; }

    public LongName CampusName { get; }

    public MediumName SiteName { get; }

    public ShortName BuildingAcronym { get; }

    public LongName BuildingName { get; }

    public Coordinate CenterX { get; }

    public Coordinate CenterY { get; }

    public Size Length { get; }

    public Size Width { get; }

    public Angle Rotation { get; }

    public Color WallsColor { get; }

    public Color RoofColor { get; }

    public Size Height { get; }

    public Counter LevelCount { get; }

    // 1 to many relationship with Level weak entity
    public ICollection<Level> Levels { get; set; } = new List<Level>();

    public Building(
        GuidValueObject buildingId,
        LongName universityName,
        LongName campusName,
        MediumName siteName,
        ShortName buildingAcronym,
        LongName buildingName,
        Coordinate centerX,
        Coordinate centerY,
        Size length,
        Size width,
        Angle rotation,
        Color wallsColor,
        Color roofColor,
        Size? height = null,
        Counter? levelCount = null)
    {
        BuildingId = buildingId;
        UniversityName = universityName;
        CampusName = campusName;
        SiteName = siteName;
        BuildingAcronym = buildingAcronym;
        BuildingName = buildingName;
        CenterX = centerX;
        CenterY = centerY;
        Length = length;
        Width = width;
        Rotation = rotation;
        WallsColor = wallsColor;
        RoofColor = roofColor;
        Height = height ?? Size.Create(3);
        LevelCount = levelCount ?? Counter.Create(0);
    }
}
