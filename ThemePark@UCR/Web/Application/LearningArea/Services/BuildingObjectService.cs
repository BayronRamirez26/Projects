using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Application.LearningArea.Services;

public class BuildingObjectService : IBuildingObjectService
{
    private readonly IBuildingObjectRepository _buildingObjectRepository;

    public BuildingObjectService(IBuildingObjectRepository buildingObjectRepository)
    {
        _buildingObjectRepository = buildingObjectRepository;
    }

    public async Task<IEnumerable<BuildingObject>> GetAllBuildingObjectsAsync()
    {
        return await _buildingObjectRepository.GetAllBuildingObjectsAsync();
    }

    public async Task<IEnumerable<BuildingObject>> GetBuildingObjectsFromLevelAsync(
        GuidValueObject levelId)
    {
        return await _buildingObjectRepository.GetBuildingObjectsFromLevelAsync(levelId);
    }

    public async Task<BuildingObject> GetBuildingObjectDetailsAsync(
        GuidValueObject buildingId)
    {
        return await _buildingObjectRepository.GetBuildingObjectDetailsAsync(buildingId);
    }

    public async Task<Tuple<bool, string>> AddBuildingObjectToLevelAsync(
        BuildingObject buildingObject)
    {
        // TODO: Get the level to get properties, get existing building objects
        // and check if there are collisions with the new building object
        return await _buildingObjectRepository.AddBuildingObjectToLevelAsync(
            buildingObject);
    }

    public async Task<Tuple<bool, string>> ModifyBuildingObjectAsync(
        BuildingObject buildingObject)
    {
        // TODO: Get the level to get properties, get existing building objects
        // and check if there are collisions with the modified building object
        return await _buildingObjectRepository.ModifyBuildingObjectAsync(buildingObject);
    }

    public async Task<Tuple<bool, string>> DeleteBuildingObjectAsync(
        BuildingObject buildingObject)
    {
        return await _buildingObjectRepository.DeleteBuildingObjectAsync(buildingObject);
    }
}
