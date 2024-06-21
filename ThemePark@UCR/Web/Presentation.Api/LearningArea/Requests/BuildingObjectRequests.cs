using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningArea.Dtos;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningArea.Requests;

public record GetBuildingObjectsFromLevelRequest(
    Guid LevelId);

public record AddBuildingObjectToLevelRequest(
    BuildingObjectDto BuildingObject);

public record GetBuildingObjectDetailsRequest(
    Guid ObjectId);

public record ModifyBuildingObjectRequest(
    BuildingObjectDto BuildingObject);

public record DeleteBuildingObjectRequest(
    BuildingObjectDto BuildingObject);
