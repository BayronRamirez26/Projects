namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningArea.Dtos;

public record BuildingObjectDto(
    Guid ObjectId,
    Guid LevelId,
    string? ObjectType,
    string? Plane,
    string? ObjectName,
    double Length,
    double Width,
    double Height,
    double CenterX,
    double CenterY,
    double Rotation,
    byte ColorAmount,
    string? Color1,
    string? Color2 = null,
    string? Color3 = null,
    byte? WallId = null);
