using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Tests.Unit.LearningArea.Fixtures;

public class LevelValueObjectsFixture
{
    private readonly Guid kLevelIdValue = new Guid();
    private const string kUniversityNameValue = "Universidad de Costa Rica";
    private const string kCampusNameValue = "Sede Rodrigo Facio";
    private const string kSiteNameValue = "Finca 1";
    private const string kBuildingAcronymValue = "IF";
    private const byte kLevelNumberValue = 1;
    private const double kSizeXValue = 10.0;
    private const double kSizeYValue = 20.0;
    private const double kSizeZValue = 15.0;
    private const string kWallsColorValue = "#2F4F4F";
    private const string kFloorColorValue = "#8B4513";
    private const string kCeilingColorValue = "#8B4513";
    private const byte kLearningSpaceCountValue = 3;

    public enum Context
    {
        WithValidNotNullParameters,
        WithNullLearningSpaceCount,
        WithInvalidLevelId,
        WithInvalidUniversityName,
        WithInvalidCampusName,
        WithInvalidSiteName,
        WithInvalidBuildingAcronym,
        WithInvalidLevelNumber,
        WithInvalidSizeX,
        WithInvalidSizeY,
        WithInvalidSizeZ,
        WithInvalidWallsColor,
        WithInvalidFloorColor,
        WithInvalidCeilingColor,
        WithInvalidLearningSpaceCount
    }

    public GuidValueObject LevelId { get; private set; }
    public LongName UniversityName { get; private set; }
    public LongName CampusName { get; private set; }
    public MediumName SiteName { get; private set; }
    public ShortName BuildingAcronym { get; private set; }
    public Counter LevelNumber { get; private set; }
    public Size SizeX { get; private set; }
    public Size SizeY { get; private set; }
    public Size SizeZ { get; private set; }
    public Color WallsColor { get; private set; }
    public Color FloorColor { get; private set; }
    public Color CeilingColor { get; private set; }
    public Counter LearningSpaceCount { get; private set; }

    public LevelValueObjectsFixture()
    {
        LevelId = GuidValueObject.Create(kLevelIdValue);
        UniversityName = LongName.Create(kUniversityNameValue);
        CampusName = LongName.Create(kCampusNameValue);
        SiteName = MediumName.Create(kSiteNameValue);
        BuildingAcronym = ShortName.Create(kBuildingAcronymValue);
        LevelNumber = Counter.Create(kLevelNumberValue);
        SizeX = Size.Create(kSizeXValue);
        SizeY = Size.Create(kSizeYValue);
        SizeZ = Size.Create(kSizeZValue);
        WallsColor = Color.Create(kWallsColorValue);
        FloorColor = Color.Create(kFloorColorValue);
        CeilingColor = Color.Create(kCeilingColorValue);
        LearningSpaceCount = Counter.Create(kLearningSpaceCountValue);
    }

    public void ChangeContext(Context context)
    {
       switch (context)
       {
            case Context.WithValidNotNullParameters:
                LevelId = GuidValueObject.Create(kLevelIdValue);
                UniversityName = LongName.Create(kUniversityNameValue);
                CampusName = LongName.Create(kCampusNameValue);
                SiteName = MediumName.Create(kSiteNameValue);
                BuildingAcronym = ShortName.Create(kBuildingAcronymValue);
                LevelNumber = Counter.Create(kLevelNumberValue);
                SizeX = Size.Create(kSizeXValue);
                SizeY = Size.Create(kSizeYValue);
                SizeZ = Size.Create(kSizeZValue);
                WallsColor = Color.Create(kWallsColorValue);
                FloorColor = Color.Create(kFloorColorValue);
                CeilingColor = Color.Create(kCeilingColorValue);
                LearningSpaceCount = Counter.Create(kLearningSpaceCountValue);
                break;
            case Context.WithNullLearningSpaceCount:
                LearningSpaceCount = null;
                break;
            case Context.WithInvalidLevelId:
                LevelId = GuidValueObject.Create(null);
                break;
            case Context.WithInvalidUniversityName:
                UniversityName = LongName.Create(string.Empty);
                break;
            case Context.WithInvalidCampusName:
                CampusName = LongName.Create(string.Empty);
                break;
            case Context.WithInvalidSiteName:
                SiteName = MediumName.Create(string.Empty);
                break;
            case Context.WithInvalidBuildingAcronym:
                BuildingAcronym = ShortName.Create(string.Empty);
                break;
            case Context.WithInvalidLevelNumber:
                LevelNumber = Counter.Create(null);
                break;
            case Context.WithInvalidSizeX:
                SizeX = Size.Create(-1.0);
                break;
            case Context.WithInvalidSizeY:
                SizeY = Size.Create(-1.0);
                break;
            case Context.WithInvalidSizeZ:
                SizeZ = Size.Create(-1.0);
                break;
            case Context.WithInvalidWallsColor:
                WallsColor = Color.Create(string.Empty);
                break;
            case Context.WithInvalidFloorColor:
                FloorColor = Color.Create(string.Empty);
                break;
            case Context.WithInvalidCeilingColor:
                CeilingColor = Color.Create(string.Empty);
                break;
            case Context.WithInvalidLearningSpaceCount:
                LearningSpaceCount = Counter.Create(null);
                break;
            default:
                break;
        }
    }
}
