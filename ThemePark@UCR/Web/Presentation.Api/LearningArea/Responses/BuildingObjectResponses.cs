using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningArea.Dtos;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningArea.Responses;

public record GetAllBuildingObjectsResponse(
    IEnumerable<BuildingObjectDto> BuildingObjectList);

public record GetBuildingObjectsFromLevelResponse(
    IEnumerable<BuildingObjectDto> BuildingObjectList);

public record GetBuildingObjectDetailsResponse(
    BuildingObjectDto BuildingObject);

public record AddBuildingObjectToLevelResponse(
    bool Success,
    string Message);

public record ModifyBuildingObjectResponse(
    bool Success,
    string Message);

public record DeleteBuildingObjectResponse(
    bool Success,
    string Message);
