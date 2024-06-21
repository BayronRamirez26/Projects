using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Application.LearningArea.Services;

public interface IBuildingObjectService
{
    public Task<IEnumerable<BuildingObject>> GetAllBuildingObjectsAsync();

    public Task<IEnumerable<BuildingObject>> GetBuildingObjectsFromLevelAsync(
        GuidValueObject levelId);

    public Task<BuildingObject> GetBuildingObjectDetailsAsync(
        GuidValueObject buildingId);

    public Task<Tuple<bool, string>> AddBuildingObjectToLevelAsync(
        BuildingObject buildingObject);

    public Task<Tuple<bool, string>> ModifyBuildingObjectAsync(
        BuildingObject buildingObject);

    public Task<Tuple<bool, string>> DeleteBuildingObjectAsync(
        BuildingObject buildingObject);
}
