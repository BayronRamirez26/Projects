using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.Tests.Unit.LearningArea.Fixtures;

public class BOTemplateValueObjectsFixture
{
    private readonly Guid kTemplateIdValue = new Guid();
    private const string kObjectTypeValue = "Interactivo";
    private const string kPlaneValue = "Piso";
    private const string kObjectNameValue = "Sillón";
    private const double kDefaultLengthValue = 0.9;
    private const double kDefaultWidthValue = 0.9;
    private const double kDefaultHeightValue = 1.0;
    private const byte kColorAmountValue = 3;
    private const string kColor1NameValue = "Estructura";
    private const string kDefaultColor1Value = "#2F4F4F";
    private const string kColor2NameValue = "Cojines";
    private const string kDefaultColor2Value = "#8B4513";
    private const string kColor3NameValue = "Apoyabrazos";
    private const string kDefaultColor3Value = "#000000";

    public enum Context
    {
        WithValidNotNullParameters,
        WithNullColor2Name,
        WithNullDefaultColor2,
        WithNullColor3Name,
        WithNullDefaultColor3,
        WithInvalidTemplateId,
        WithInvalidObjectType,
        WithInvalidPlane,
        WithInvalidObjectName,
        WithInvalidDefaultLength,
        WithInvalidDefaultWidth,
        WithInvalidDefaultHeight,
        WithInvalidColorAmount,
        WithInvalidColor1Name,
        WithInvalidDefaultColor1,
        WithInvalidColor2Name,
        WithInvalidDefaultColor2,
        WithInvalidColor3Name,
        WithInvalidDefaultColor3
    }

    public GuidValueObject TemplateId { get; private set; }
    public MediumName ObjectType { get; private set; }
    public MediumName Plane { get; private set; }
    public MediumName ObjectName { get; private set; }
    public Size DefaultLength { get; private set; }
    public Size DefaultWidth { get; private set; }
    public Size DefaultHeight { get; private set; }
    public Counter ColorAmount { get; private set; }
    public MediumName Color1Name { get; private set; }
    public Color DefaultColor1 { get; private set; }
    public MediumName Color2Name { get; private set; }
    public Color DefaultColor2 { get; private set; }
    public MediumName Color3Name { get; private set; }
    public Color DefaultColor3 { get; private set; }

    public BOTemplateValueObjectsFixture()
    {
        TemplateId = GuidValueObject.Create(kTemplateIdValue);
        ObjectType = MediumName.Create(kObjectTypeValue);
        Plane = MediumName.Create(kPlaneValue);
        ObjectName = MediumName.Create(kObjectNameValue);
        DefaultLength = Size.Create(kDefaultLengthValue);
        DefaultWidth = Size.Create(kDefaultWidthValue);
        DefaultHeight = Size.Create(kDefaultHeightValue);
        ColorAmount = Counter.Create(kColorAmountValue);
        Color1Name = MediumName.Create(kColor1NameValue);
        DefaultColor1 = Color.Create(kDefaultColor1Value);
        Color2Name = MediumName.Create(kColor2NameValue);
        DefaultColor2 = Color.Create(kDefaultColor2Value);
        Color3Name = MediumName.Create(kColor3NameValue);
        DefaultColor3 = Color.Create(kDefaultColor3Value);
    }

    public void ChangeContext(Context context)
    {
        switch (context)
        {
            case Context.WithValidNotNullParameters:
                TemplateId = GuidValueObject.Create(kTemplateIdValue);
                ObjectType = MediumName.Create(kObjectTypeValue);
                Plane = MediumName.Create(kPlaneValue);
                ObjectName = MediumName.Create(kObjectNameValue);
                DefaultLength = Size.Create(kDefaultLengthValue);
                DefaultWidth = Size.Create(kDefaultWidthValue);
                DefaultHeight = Size.Create(kDefaultHeightValue);
                ColorAmount = Counter.Create(kColorAmountValue);
                Color1Name = MediumName.Create(kColor1NameValue);
                DefaultColor1 = Color.Create(kDefaultColor1Value);
                Color2Name = MediumName.Create(kColor2NameValue);
                DefaultColor2 = Color.Create(kDefaultColor2Value);
                Color3Name = MediumName.Create(kColor3NameValue);
                DefaultColor3 = Color.Create(kDefaultColor3Value);
                break;
            case Context.WithNullColor2Name:
                Color2Name = null;
                break;
            case Context.WithNullDefaultColor2:
                DefaultColor2 = null;
                break;
            case Context.WithNullColor3Name:
                Color3Name = null;
                break;
            case Context.WithNullDefaultColor3:
                DefaultColor3 = null;
                break;
            case Context.WithInvalidTemplateId:
                TemplateId = GuidValueObject.Create(null);
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
            case Context.WithInvalidDefaultLength:
                DefaultLength = Size.Create(-1.0);
                break;
            case Context.WithInvalidDefaultWidth:
                DefaultWidth = Size.Create(-1.0);
                break;
            case Context.WithInvalidDefaultHeight:
                DefaultHeight = Size.Create(-1.0);
                break;
            case Context.WithInvalidColorAmount:
                ColorAmount = Counter.Create(null);
                break;
            case Context.WithInvalidColor1Name:
                Color1Name = MediumName.Create(string.Empty);
                break;
            case Context.WithInvalidDefaultColor1:
                DefaultColor1 = Color.Create(string.Empty);
                break;
            case Context.WithInvalidColor2Name:
                Color2Name = MediumName.Create(string.Empty);
                break;
            case Context.WithInvalidDefaultColor2:
                DefaultColor2 = Color.Create(string.Empty);
                break;
            case Context.WithInvalidColor3Name:
                Color3Name = MediumName.Create(string.Empty);
                break;
            case Context.WithInvalidDefaultColor3:
                DefaultColor3 = Color.Create(string.Empty);
                break;
            default:
                break;
        }
    }
}
