using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Entities;

public class BOTemplate
{
    public GuidValueObject TemplateId { get; }
    public MediumName ObjectType { get; }
    public MediumName Plane { get; }
    public MediumName ObjectName { get; }
    public Size DefaultLength { get; }
    public Size DefaultWidth { get; }
    public Size DefaultHeight { get; }
    public Counter ColorAmount { get; }
    public MediumName Color1Name { get; }
    public Color DefaultColor1 { get; }
    public MediumName? Color2Name { get; }
    public Color? DefaultColor2 { get; }
    public MediumName? Color3Name { get; }
    public Color? DefaultColor3 { get; }

    public BOTemplate(
    GuidValueObject templateId,
    MediumName objectType,
    MediumName plane,
    MediumName objectName,
    Size defaultLength,
    Size defaultWidth,
    Size defaultHeight,
    Counter colorAmount,
    MediumName color1Name,
    Color defaultColor1,
    MediumName? color2Name = null,
    Color? defaultColor2 = null,
    MediumName? color3Name = null,
    Color? defaultColor3 = null)
    {
        TemplateId = templateId;
        ObjectType = objectType;
        Plane = plane;
        ObjectName = objectName;
        DefaultLength = defaultLength;
        DefaultWidth = defaultWidth;
        DefaultHeight = defaultHeight;
        ColorAmount = colorAmount;
        Color1Name = color1Name;
        DefaultColor1 = defaultColor1;
        Color2Name = color2Name ?? null;
        DefaultColor2 = defaultColor2 ?? null;
        Color3Name = color3Name ?? null;
        DefaultColor3 = defaultColor3 ?? null;
    }

    public static readonly BOTemplate Invalid = new(
        GuidValueObject.Invalid,
        MediumName.Invalid,
        MediumName.Invalid,
        MediumName.Invalid,
        Size.Invalid,
        Size.Invalid,
        Size.Invalid,
        Counter.Invalid,
        MediumName.Invalid,
        Color.Invalid);
}
