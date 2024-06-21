using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Entities;
/// US: PIIB2401G1-93 CAD-CRL-02 List building levels
/// Task: PIIB2401G1-314 Create Level domain entity and repository
/// Christopher Viquez Aguilar
/// Daniel Van der Laat Velez
/// Francisco Ulate
public class Level
{
    public GuidValueObject LevelId { get; } // PK
    public LongName UniversityName { get; } // FK
    public LongName CampusName { get; } // FK
    public MediumName SiteName { get; } // FK
    public ShortName BuildingAcronym { get; } // FK
    public Counter LevelNumber { get; }
    public Size SizeX { get; }
    public Size SizeY { get; }
    public Size SizeZ { get; }
    public Color WallsColor { get; }
    public Color FloorColor { get; }
    public Color CeilingColor { get; }
    public Counter LearningSpaceCount { get; }

    // TODO: Add LearningSpace entity relationship
    // public List<LearningSpace> LearningSpaces { get; } = new List<LearningSpace>();
    // TODO: Add LevelId here and to LearningSpace entity
    // public Guid LevelId { get; }


    // entity relationships
    public Building? Building { get; set; } = null!;

    public Level(
        GuidValueObject levelId,
        LongName universityName,
        LongName campusName,
        MediumName siteName,
        ShortName buildingAcronym,
        Counter levelNumber,
        Size sizeX,
        Size sizeY,
        Size sizeZ,
        Color? wallsColor = null,
        Color? floorColor = null,
        Color? ceilingColor = null,
        Counter? learningSpaceCount = null)
    {
        LevelId = levelId;
        UniversityName = universityName;
        CampusName = campusName;
        SiteName = siteName;
        BuildingAcronym = buildingAcronym;
        LevelNumber = levelNumber;
        SizeX = sizeX;
        SizeY = sizeY;
        SizeZ = sizeZ;
        WallsColor = wallsColor ?? Color.Create("#FFFFFF");
        FloorColor = floorColor ?? Color.Create("#FFFFFF");
        CeilingColor = ceilingColor ?? Color.Create("#FFFFFF");
        LearningSpaceCount = learningSpaceCount ?? Counter.Create(0);
    }
}
