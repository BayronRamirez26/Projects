using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.Tests.Unit.LearningArea.Fixtures;

public class BuildingObjectValueObjectsFixture
{
    private readonly Guid kObjectIdValue = new Guid();
    private readonly Guid kLevelIdValue = new Guid();
    private const string kObjectTypeValue = "Interactivo";
    private const string kPlaneValue = "Piso";
    private const string kObjectNameValue = "Sillón";
    private const double kLengthValue = 0.9;
    private const double kWidthValue = 0.9;
    private const double kHeightValue = 1.0;
    private const double kCenterXValue = 25.0;
    private const double kCenterYValue = 25.0;
    private const double kRotationValue = 45.0;
    private const byte kColorAmountValue = 3;
    private const string kColor1Value = "#2F4F4F";
    private const string kColor2Value = "#8B4513";
    private const string kColor3Value = "#000000";
    private const byte kWallIdValue = 1;

    public enum Context
    {
        WithValidNotNullParameters,
        WithNullColor2,
        WithNullColor3,
        WithNullWallId,
        WithInvalidObjectId,
        WithInvalidLevelId,
        WithInvalidObjectType,
        WithInvalidPlane,
        WithInvalidObjectName,
        WithInvalidLength,
        WithInvalidWidth,
        WithInvalidHeight,
        WithInvalidColorAmount,
        WithInvalidCenterX,
        WithInvalidCenterY,
        WithInvalidRotation,
        WithInvalidColor1,
        WithInvalidColor2,
        WithInvalidColor3,
        WithInvalidWallId
    }

    public GuidValueObject ObjectId { get; private set; }
    public GuidValueObject LevelId { get; private set; }
    public MediumName ObjectType { get; private set; }
    public MediumName Plane { get; private set; }
    public MediumName ObjectName { get; private set; }
    public Size Length { get; private set; }
    public Size Width { get; private set; }
    public Size Height { get; private set; }
    public Coordinate CenterX { get; private set; }
    public Coordinate CenterY { get; private set; }
    public Angle Rotation { get; private set; }
    public Counter ColorAmount { get; private set; }
    public Color Color1 { get; private set; }
    public Color Color2 { get; private set; }
    public Color Color3 { get; private set; }
    public Counter WallId { get; private set; }

    public BuildingObjectValueObjectsFixture()
    {
        ObjectId = GuidValueObject.Create(kObjectIdValue);
        LevelId = GuidValueObject.Create(kLevelIdValue);
        ObjectType = MediumName.Create(kObjectTypeValue);
        Plane = MediumName.Create(kPlaneValue);
        ObjectName = MediumName.Create(kObjectNameValue);
        Length = Size.Create(kLengthValue);
        Width = Size.Create(kWidthValue);
        Height = Size.Create(kHeightValue);
        CenterX = Coordinate.Create(kCenterXValue);
        CenterY = Coordinate.Create(kCenterYValue);
        Rotation = Angle.Create(kRotationValue);
        ColorAmount = Counter.Create(kColorAmountValue);
        Color1 = Color.Create(kColor1Value);
        Color2 = Color.Create(kColor2Value);
        Color3 = Color.Create(kColor3Value);
        WallId = Counter.Create(kWallIdValue);
    }

    public void ChangeContext(Context context)
    {
        switch (context)
        {
            case Context.WithValidNotNullParameters:
                ObjectId = GuidValueObject.Create(kObjectIdValue);
                LevelId = GuidValueObject.Create(kLevelIdValue);
                ObjectType = MediumName.Create(kObjectTypeValue);
                Plane = MediumName.Create(kPlaneValue);
                ObjectName = MediumName.Create(kObjectNameValue);
                Length = Size.Create(kLengthValue);
                Width = Size.Create(kWidthValue);
                Height = Size.Create(kHeightValue);
                CenterX = Coordinate.Create(kCenterXValue);
                CenterY = Coordinate.Create(kCenterYValue);
                Rotation = Angle.Create(kRotationValue);
                ColorAmount = Counter.Create(kColorAmountValue);
                Color1 = Color.Create(kColor1Value);
                Color2 = Color.Create(kColor2Value);
                Color3 = Color.Create(kColor3Value);
                WallId = Counter.Create(kWallIdValue);
                break;
            case Context.WithNullColor2:
                Color2 = null;
                break;
            case Context.WithNullColor3:
                Color3 = null;
                break;
            case Context.WithNullWallId:
                WallId = null;
                break;
            case Context.WithInvalidObjectId:
                ObjectId = GuidValueObject.Create(null);
                break;
            case Context.WithInvalidLevelId:
                LevelId = GuidValueObject.Create(null);
                break;
            case Context.WithInvalidObjectType:
                ObjectType = MediumName.Create(string.Empty);
                break;
            case Context.WithInvalidPlane:
                Plane = MediumName.Create(string.Empty);
                break;
            case Context.WithInvalidObjectName:
                ObjectName = MediumName.Create(string.Empty);
                break;
            case Context.WithInvalidLength:
                Length = Size.Create(-1.0);
                break;
            case Context.WithInvalidWidth:
                Width = Size.Create(-1.0);
                break;
            case Context.WithInvalidHeight:
                Height = Size.Create(-1.0);
                break;
            case Context.WithInvalidCenterX:
                CenterX = Coordinate.Create(double.NaN);
                break;
            case Context.WithInvalidCenterY:
                CenterY = Coordinate.Create(double.NaN);
                break;
            case Context.WithInvalidRotation:
                Rotation = Angle.Create(400);
                break;
            case Context.WithInvalidColorAmount:
                ColorAmount = Counter.Create(null);
                break;
            case Context.WithInvalidColor1:
                Color1 = Color.Create(string.Empty);
                break;
            case Context.WithInvalidColor2:
                Color2 = Color.Create(string.Empty);
                break;
            case Context.WithInvalidColor3:
                Color3 = Color.Create(string.Empty);
                break;
            case Context.WithInvalidWallId:
                WallId = Counter.Create(null);
                break;
            default:
                break;
        }
    }
}
