using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities;
/// <summary>
/// This represents the LearningSpace entity in our system.
/// </summary>
public class LearningSpaces
{
    /// <summary>
    /// This is the main constructor for the LearningSpaces entity
    /// </summary>
    /// <param name="universityName">Full name of the university</param>
    /// <param name="campusName">Full name of the campus</param>
    /// <param name="siteName">Medium name of the site</param>
    /// <param name="buildingAcronym">Acronym of the building</param>
    /// <param name="levelNumber">Level number</param>
    /// <param name="learningSpaceID">ID of the learning space</param>
    /// <param name="learningSpaceName">Name of the learning space</param>
    /// <param name="name">Short name of the learning space</param>
    /// <param name="sizex">Size in the x direction</param>
    /// <param name="sizey">Size in the y direction</param>
    /// <param name="sizez">Size in the z direction</param>
    /// <param name="floorAssetId">ID of the floor asset</param>
    /// <param name="ceilingAssetId">ID of the ceiling asset</param>
    public LearningSpaces(
            GuidWrapper learningSpaceId,
            ShortName learningSpaceName,
            DoubleWrapper sizex,
            DoubleWrapper sizey,
            DoubleWrapper sizez,
            MediumName floorColor,
            MediumName ceilingColor,
            MediumName wallsColor,
            GuidWrapper? levelId,
            GuidWrapper type
        )
    {
        LearningSpaceId = learningSpaceId;
        LearningSpaceName = learningSpaceName;
        SizeX = sizex;
        SizeY = sizey;
        SizeZ = sizez;
        FloorColor = floorColor;
        CeilingColor = ceilingColor;
        WallsColor = wallsColor;
        LevelId = levelId;
        Type = type;
    }

    /// <summary>
    /// LearningSpaces constructor with default values
    /// </summary>
    internal LearningSpaces() : this(
        new GuidWrapper(Guid.NewGuid()),
        new ShortName("Default Name"),
        new DoubleWrapper(0.0),
        new DoubleWrapper(0.0),
        new DoubleWrapper(0.0),
        new MediumName("Default Floor Color"), // TODO: change to actual color
        new MediumName("Default Ceiling Color"), // TODO: change to actual color
        new MediumName("Default Walls Color"), // TODO: change to actual color
        new GuidWrapper(Guid.NewGuid()),
        new GuidWrapper(Guid.Empty)
        )
    {
        Console.WriteLine("LearningSpaces object created with default values.");
    }


    public GuidWrapper LearningSpaceId { get; } // Guid LearningSpaceId
    public ShortName LearningSpaceName { get; }    // ShortName learningSpaceName
    public DoubleWrapper SizeX { get; }    // double sizex
    public DoubleWrapper SizeY { get; }    // double sizey
    public DoubleWrapper SizeZ { get; }    // double sizez
    public MediumName FloorColor { get; }    // MediumName floorColor
    public MediumName CeilingColor { get; }    // MediumName ceilingColor
    public MediumName WallsColor { get; }    // MediumName wallsColor,
    public GuidWrapper? LevelId { get; }    // Guid LevelId
    public GuidWrapper Type { get; }    // MediumName Type
    public ICollection<AccessPoint> accessPoints { get; set; } = new List<AccessPoint>();
}
