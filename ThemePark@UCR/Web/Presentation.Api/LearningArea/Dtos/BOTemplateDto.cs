namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningArea.Dtos;

public record BOTemplateDto(
    Guid TemplateId,
    string? ObjectType,
    string? Plane,
    string? ObjectName,
    double DefaultLength,
    double DefaultWidth,
    double DefaultHeight,
    byte ColorAmount,
    string? Color1Name,
    string? DefaultColor1,
    string? Color2Name = null,
    string? DefaultColor2 = null,
    string? Color3Name = null,
    string? DefaultColor3 = null);
