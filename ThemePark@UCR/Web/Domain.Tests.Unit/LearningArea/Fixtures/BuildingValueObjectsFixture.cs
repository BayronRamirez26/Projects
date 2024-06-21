using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.Tests.Unit.LearningArea.Fixtures;

public class BuildingValueObjectsFixture
{
    private readonly Guid kBuildingIdValue = new Guid();
    private const string kUniversityNameValue = "Universidad de Costa Rica";
    private const string kCampusNameValue = "Sede Rodrigo Facio";
    private const string kSiteNameValue = "Finca 1";
    private const string kBuildingAcronymValue = "IF";
    private const string kBuildingNameValue = "Informatica";
    private const double kCenterXValue = 250.0;
    private const double kCenterYValue = 250.0;
    private const double kLengthValue = 70.0;
    private const double kWidthValue = 50.0;
    private const double kRotationValue = 45.0;
    private const string kWallsColorValue = "#2F4F4F";
    private const string kRoofColorValue = "#8B4513";
    private const double kHeightValue = 10.0;
    public const byte kLevelCountValue = 3;

    public enum Context
    {
        WithValidNotNullParameters,
        WithNullHeight,
        WithNullLevelCount,
        WithInvalidBuildingId,
        WithInvalidUniversityName,
        WithInvalidCampusName,
        WithInvalidSiteName,
        WithInvalidBuildingAcronym,
        WithInvalidBuildingName,
        WithInvalidCenterX,
        WithInvalidCenterY,
        WithInvalidLength,
        WithInvalidWidth,
        WithInvalidRotation,
        WithInvalidWallsColor,
        WithInvalidRoofColor,
        WithInvalidHeight,
        WithInvalidLevelCount
    }

    public GuidValueObject BuildingId { get; private set; }
    public LongName UniversityName { get; private set; }
    public LongName CampusName { get; private set; }
    public MediumName SiteName { get; private set; }
    public ShortName BuildingAcronym { get; private set; }
    public LongName BuildingName { get; private set; }
    public Coordinate CenterX { get; private set; }
    public Coordinate CenterY { get; private set; }
    public Size Length { get; private set; }
    public Size Width { get; private set; }
    public Angle Rotation { get; private set; }
    public Color WallsColor { get; private set; }
    public Color RoofColor { get; private set; }
    public Size Height { get; private set; }
    public Counter LevelCount { get; private set; }

    public BuildingValueObjectsFixture()
    {
        BuildingId = GuidValueObject.Create(kBuildingIdValue);
        UniversityName = LongName.Create(kUniversityNameValue);
        CampusName = LongName.Create(kCampusNameValue);
        SiteName = MediumName.Create(kSiteNameValue);
        BuildingAcronym = ShortName.Create(kBuildingAcronymValue);
        BuildingName = LongName.Create(kBuildingNameValue);
        CenterX = Coordinate.Create(kCenterXValue);
        CenterY = Coordinate.Create(kCenterYValue);
        Length = Size.Create(kLengthValue);
        Width = Size.Create(kWidthValue);
        Rotation = Angle.Create(kRotationValue);
        WallsColor = Color.Create(kWallsColorValue);
        RoofColor = Color.Create(kRoofColorValue);
        Height = Size.Create(kHeightValue);
        LevelCount = Counter.Create(kLevelCountValue);
    }

    public void ChangeContext(Context context)
    {
        switch (context)
        {
            case Context.WithValidNotNullParameters:
                BuildingId = GuidValueObject.Create(kBuildingIdValue);
                UniversityName = LongName.Create(kUniversityNameValue);
                CampusName = LongName.Create(kCampusNameValue);
                SiteName = MediumName.Create(kSiteNameValue);
                BuildingAcronym = ShortName.Create(kBuildingAcronymValue);
                BuildingName = LongName.Create(kBuildingNameValue);
                CenterX = Coordinate.Create(kCenterXValue);
                CenterY = Coordinate.Create(kCenterYValue);
                Length = Size.Create(kLengthValue);
                Width = Size.Create(kWidthValue);
                Rotation = Angle.Create(kRotationValue);
                WallsColor = Color.Create(kWallsColorValue);
                RoofColor = Color.Create(kRoofColorValue);
                Height = Size.Create(kHeightValue);
                LevelCount = Counter.Create(kLevelCountValue);
                break;
            case Context.WithNullHeight:
                Height = null;
                break;
            case Context.WithNullLevelCount:
                LevelCount = null;
                break;
            case Context.WithInvalidBuildingId:
                BuildingId = GuidValueObject.Create(null);
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
            case Context.WithInvalidBuildingName:
                BuildingName = LongName.Create(string.Empty);
                break;
            case Context.WithInvalidCenterX:
                CenterX = Coordinate.Create(Double.NaN);
                break;
            case Context.WithInvalidCenterY:
                CenterY = Coordinate.Create(Double.NaN);
                break;
            case Context.WithInvalidLength:
                Length = Size.Create(-1.0);
                break;
            case Context.WithInvalidWidth:
                Width = Size.Create(-1.0);
                break;
            case Context.WithInvalidRotation:
                Rotation = Angle.Create(400);
                break;
            case Context.WithInvalidWallsColor:
                WallsColor = Color.Create(string.Empty);
                break;
            case Context.WithInvalidRoofColor:
                RoofColor = Color.Create(string.Empty);
                break;
            case Context.WithInvalidHeight:
                Height = Size.Create(-1.0);
                break;
            case Context.WithInvalidLevelCount:
                LevelCount = Counter.Create(null);
                break;
            default:
                break;
        }
    }
}
