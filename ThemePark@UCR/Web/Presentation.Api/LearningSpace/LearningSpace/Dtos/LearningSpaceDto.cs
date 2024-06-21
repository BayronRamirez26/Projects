using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities.Wrappers;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningSpace.LearningSpace.Dtos;

public record LearningSpaceDto(
    GuidWrapper LearningSpaceId,
    string LearningSpaceName,
    DoubleWrapper SizeX,
    DoubleWrapper SizeY,
    DoubleWrapper SizeZ,
    string FloorColor,
    string CeilingColor,
    string WallsColor,
    GuidWrapper LevelId,
    GuidWrapper Type);
