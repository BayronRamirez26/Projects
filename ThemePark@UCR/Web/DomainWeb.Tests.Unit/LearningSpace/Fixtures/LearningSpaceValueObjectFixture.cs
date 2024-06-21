using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Tests.Unit.LearningSpace.Fixtures;
public class LearningSpaceValueObjectFixture
{
    // Input Battery for WithValidParameters
    // This battery is the default use for constructor of fixture
    private Guid inputLearningSpaceId = Guid.NewGuid();
    private const string inputLearningSpaceName = "Testing";
    private const double inputSizex = 10.5;
    private const double inputSizey = 20.5;
    private const double inputSizez = 30.5;
    private const string inputFloorColor = "Floor Color";
    private const string inputCeilingColor = "Ceiling Color";
    private const string inputWallsColor = "Walls Color";
    private Guid inputLevelId = Guid.NewGuid();
    private Guid inputType = Guid.NewGuid();

    public enum actualContext
    {
        WithValidParameters,
        WithNullLearningSpaceId,
        WithNullLevelId,
        WithNullType,
        WithBoundaryCoordinateZeroValue,
        WithBoundaryCoordinatesNegative,
        WithMaxValues,
        WithPositiveInfinity,
        WithNegativeInfinity,
        WithNaN,
        WithExtremeSizeValues,
        WithIllegalCharactersInShortName,
        WithLongerShortNameThatAllow,
        WithIllegalCharactersInMediumName,
        WithLongerMediumNameThatAllow
    };

    public GuidWrapper LearningSpaceId { get; private set; } // Guid LearningSpaceId
    public ShortName LearningSpaceName { get; private set; }    // ShortName learningSpaceName
    public DoubleWrapper SizeX { get; private set; }    // double sizex
    public DoubleWrapper SizeY { get; private set; }    // double sizey
    public DoubleWrapper SizeZ { get; private set; }    // double sizez
    public MediumName FloorColor { get; private set; }    // MediumName floorColor
    public MediumName CeilingColor { get; private set; }    // MediumName ceilingColor
    public MediumName WallsColor { get; private set; }    // MediumName wallsColor,
    public GuidWrapper? LevelId { get; private set; }    // Guid LevelId
    public GuidWrapper Type { get; private set; }    // MediumName Type

    public LearningSpaceValueObjectFixture()
    {
        LearningSpaceId = GuidWrapper.Create(inputLearningSpaceId);
        LearningSpaceName = ShortName.Create(inputLearningSpaceName);
        SizeX = DoubleWrapper.Create(inputSizex);
        SizeY = DoubleWrapper.Create(inputSizey);
        SizeZ = DoubleWrapper.Create(inputSizez);
        FloorColor = MediumName.Create(inputFloorColor);
        CeilingColor = MediumName.Create(inputCeilingColor);
        WallsColor = MediumName.Create(inputWallsColor);
        LevelId = GuidWrapper.Create(inputLevelId);
        Type = GuidWrapper.Create(inputType);
    }

    public void ChangeContext(actualContext inputContext)
    {
        switch (inputContext)
        {
            case actualContext.WithValidParameters:
                LearningSpaceId = GuidWrapper.Create(inputLearningSpaceId);
                LearningSpaceName = ShortName.Create(inputLearningSpaceName);
                SizeX = DoubleWrapper.Create(inputSizex);
                SizeY = DoubleWrapper.Create(inputSizey);
                SizeZ = DoubleWrapper.Create(inputSizez);
                FloorColor = MediumName.Create(inputFloorColor);
                CeilingColor = MediumName.Create(inputCeilingColor);
                WallsColor = MediumName.Create(inputWallsColor);
                LevelId = GuidWrapper.Create(inputLevelId);
                Type = GuidWrapper.Create(inputType);
                break;
            case actualContext.WithNullLearningSpaceId:
                LearningSpaceId = null; // Set to null for the test case
                LearningSpaceName = ShortName.Create(inputLearningSpaceName);
                SizeX = DoubleWrapper.Create(inputSizex);
                SizeY = DoubleWrapper.Create(inputSizey);
                SizeZ = DoubleWrapper.Create(inputSizez);
                FloorColor = MediumName.Create(inputFloorColor);
                CeilingColor = MediumName.Create(inputCeilingColor);
                WallsColor = MediumName.Create(inputWallsColor);
                LevelId = GuidWrapper.Create(inputLevelId);
                Type = GuidWrapper.Create(inputType);
                break;
            case actualContext.WithNullLevelId:
                LearningSpaceId = GuidWrapper.Create(inputLearningSpaceId);
                LearningSpaceName = ShortName.Create(inputLearningSpaceName);
                SizeX = DoubleWrapper.Create(inputSizex);
                SizeY = DoubleWrapper.Create(inputSizey);
                SizeZ = DoubleWrapper.Create(inputSizez);
                FloorColor = MediumName.Create(inputFloorColor);
                CeilingColor = MediumName.Create(inputCeilingColor);
                WallsColor = MediumName.Create(inputWallsColor);
                LevelId = null; // Set to null for the test case
                Type = GuidWrapper.Create(inputType);
                break;
            case actualContext.WithNullType:
                LearningSpaceId = GuidWrapper.Create(inputLearningSpaceId);
                LearningSpaceName = ShortName.Create(inputLearningSpaceName);
                SizeX = DoubleWrapper.Create(inputSizex);
                SizeY = DoubleWrapper.Create(inputSizey);
                SizeZ = DoubleWrapper.Create(inputSizez);
                FloorColor = MediumName.Create(inputFloorColor);
                CeilingColor = MediumName.Create(inputCeilingColor);
                WallsColor = MediumName.Create(inputWallsColor);
                LevelId = GuidWrapper.Create(inputLevelId);
                Type = null; // Set to null for the test case
                break;
            case actualContext.WithBoundaryCoordinateZeroValue:
                // Define values for boundary coordinate test case
                LearningSpaceId = GuidWrapper.Create(inputLearningSpaceId);
                LearningSpaceName = ShortName.Create(inputLearningSpaceName);
                SizeX = DoubleWrapper.Create(0.0);
                SizeY = DoubleWrapper.Create(0.0);
                SizeZ = DoubleWrapper.Create(0.0);
                FloorColor = MediumName.Create(inputFloorColor);
                CeilingColor = MediumName.Create(inputCeilingColor);
                WallsColor = MediumName.Create(inputWallsColor);
                LevelId = GuidWrapper.Create(inputLevelId);
                Type = GuidWrapper.Create(inputType);
                break;
            case actualContext.WithBoundaryCoordinatesNegative:
                // Define values for boundary coordinate test case
                LearningSpaceId = GuidWrapper.Create(inputLearningSpaceId);
                LearningSpaceName = ShortName.Create(inputLearningSpaceName);
                SizeX = DoubleWrapper.Create(-10.5);
                SizeY = DoubleWrapper.Create(-20.5);
                SizeZ = DoubleWrapper.Create(-30.5);
                FloorColor = MediumName.Create(inputFloorColor);
                CeilingColor = MediumName.Create(inputCeilingColor);
                WallsColor = MediumName.Create(inputWallsColor);
                LevelId = GuidWrapper.Create(inputLevelId);
                Type = GuidWrapper.Create(inputType);
                break;
            case actualContext.WithMaxValues:
                LearningSpaceId = GuidWrapper.Create(inputLearningSpaceId);
                LearningSpaceName = ShortName.Create(inputLearningSpaceName);
                SizeX = DoubleWrapper.Create(double.MaxValue);
                SizeY = DoubleWrapper.Create(double.MinValue);
                SizeZ = DoubleWrapper.Create(0);
                FloorColor = MediumName.Create(inputFloorColor);
                CeilingColor = MediumName.Create(inputCeilingColor);
                WallsColor = MediumName.Create(inputWallsColor);
                LevelId = GuidWrapper.Create(inputLevelId);
                Type = GuidWrapper.Create(inputType);
                break;
            case actualContext.WithPositiveInfinity:
                LearningSpaceId = GuidWrapper.Create(inputLearningSpaceId);
                LearningSpaceName = ShortName.Create(inputLearningSpaceName);
                SizeX = DoubleWrapper.Create(double.PositiveInfinity);
                SizeY = DoubleWrapper.Create(double.PositiveInfinity);
                SizeZ = DoubleWrapper.Create(double.PositiveInfinity);
                FloorColor = MediumName.Create(inputFloorColor);
                CeilingColor = MediumName.Create(inputCeilingColor);
                WallsColor = MediumName.Create(inputWallsColor);
                LevelId = GuidWrapper.Create(inputLevelId);
                Type = GuidWrapper.Create(inputType);
                break;
            case actualContext.WithNegativeInfinity:
                LearningSpaceId = GuidWrapper.Create(inputLearningSpaceId);
                LearningSpaceName = ShortName.Create(inputLearningSpaceName);
                SizeX = DoubleWrapper.Create(double.NegativeInfinity);
                SizeY = DoubleWrapper.Create(double.NegativeInfinity);
                SizeZ = DoubleWrapper.Create(double.NegativeInfinity);
                FloorColor = MediumName.Create(inputFloorColor);
                CeilingColor = MediumName.Create(inputCeilingColor);
                WallsColor = MediumName.Create(inputWallsColor);
                LevelId = GuidWrapper.Create(inputLevelId);
                Type = GuidWrapper.Create(inputType);
                break;
            case actualContext.WithNaN:
                LearningSpaceId = GuidWrapper.Create(inputLearningSpaceId);
                LearningSpaceName = ShortName.Create(inputLearningSpaceName);
                SizeX = DoubleWrapper.Create(double.NaN);
                SizeY = DoubleWrapper.Create(double.NaN);
                SizeZ = DoubleWrapper.Create(double.NaN);
                FloorColor = MediumName.Create(inputFloorColor);
                CeilingColor = MediumName.Create(inputCeilingColor);
                WallsColor = MediumName.Create(inputWallsColor);
                LevelId = GuidWrapper.Create(inputLevelId);
                Type = GuidWrapper.Create(inputType);
                break;
            case actualContext.WithExtremeSizeValues:
                // Define values for extreme size test case
                LearningSpaceId = GuidWrapper.Create(inputLearningSpaceId);
                LearningSpaceName = ShortName.Create(inputLearningSpaceName);
                SizeX = DoubleWrapper.Create(double.MaxValue * 2);
                SizeY = DoubleWrapper.Create(double.MinValue * 2);
                SizeZ = DoubleWrapper.Create(double.MaxValue * 3);
                FloorColor = MediumName.Create(inputFloorColor);
                CeilingColor = MediumName.Create(inputCeilingColor);
                WallsColor = MediumName.Create(inputWallsColor);
                LevelId = GuidWrapper.Create(inputLevelId);
                Type = GuidWrapper.Create(inputType);
                break;
            case actualContext.WithIllegalCharactersInShortName:
                LearningSpaceId = GuidWrapper.Create(inputLearningSpaceId);
                LearningSpaceName = null;
                SizeX = DoubleWrapper.Create(inputSizex);
                SizeY = DoubleWrapper.Create(inputSizey);
                SizeZ = DoubleWrapper.Create(inputSizez);
                FloorColor = MediumName.Create(inputFloorColor);
                CeilingColor = MediumName.Create(inputCeilingColor);
                WallsColor = MediumName.Create(inputWallsColor);
                LevelId = GuidWrapper.Create(inputLevelId);
                Type = GuidWrapper.Create(inputType);
                break;
            case actualContext.WithLongerShortNameThatAllow:
                LearningSpaceId = GuidWrapper.Create(inputLearningSpaceId);
                LearningSpaceName = null;
                SizeX = DoubleWrapper.Create(inputSizex);
                SizeY = DoubleWrapper.Create(inputSizey);
                SizeZ = DoubleWrapper.Create(inputSizez);
                FloorColor = MediumName.Create(inputFloorColor);
                CeilingColor = MediumName.Create(inputCeilingColor);
                WallsColor = MediumName.Create(inputWallsColor);
                LevelId = GuidWrapper.Create(inputLevelId);
                Type = GuidWrapper.Create(inputType);
                break;
            case actualContext.WithIllegalCharactersInMediumName:
                LearningSpaceId = GuidWrapper.Create(inputLearningSpaceId);
                LearningSpaceName = ShortName.Create(inputLearningSpaceName);
                SizeX = DoubleWrapper.Create(inputSizex);
                SizeY = DoubleWrapper.Create(inputSizey);
                SizeZ = DoubleWrapper.Create(inputSizez);
                FloorColor = null;
                CeilingColor = MediumName.Create(inputCeilingColor);
                WallsColor = MediumName.Create(inputWallsColor);
                LevelId = GuidWrapper.Create(inputLevelId);
                Type = GuidWrapper.Create(inputType);
                break;
            case actualContext.WithLongerMediumNameThatAllow:
                LearningSpaceId = GuidWrapper.Create(inputLearningSpaceId);
                LearningSpaceName = ShortName.Create(inputLearningSpaceName);
                SizeX = DoubleWrapper.Create(inputSizex);
                SizeY = DoubleWrapper.Create(inputSizey);
                SizeZ = DoubleWrapper.Create(inputSizez);
                FloorColor = null;
                CeilingColor = MediumName.Create(inputCeilingColor);
                WallsColor = MediumName.Create(inputWallsColor);
                LevelId = GuidWrapper.Create(inputLevelId);
                Type = GuidWrapper.Create(inputType);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(inputContext), inputContext, null);
        }
    }  


}
