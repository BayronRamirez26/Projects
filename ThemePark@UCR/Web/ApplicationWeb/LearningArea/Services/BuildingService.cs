using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Dtos;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.Responses;

namespace UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.LearningArea.Services;

/*
 Actividad 3 Pair Programming
Sara Espinoza B92771
Jorge Sagot C12565
* CAD-CRB-03 Modify properties 
* CAD-CRB-04 Delete Building
* CAD-CRB-14 Building colissions on update
 */

public class BuildingService : IBuildingService
{
    private readonly IBuildingRepository _buildingRepository;

    public BuildingService(IBuildingRepository buildingRepository)
    {
        _buildingRepository = buildingRepository;
    }

    public Task<IEnumerable<Building>> GetAllBuildingsAsync()
    {
        return _buildingRepository.GetAllBuildingsAsync();
    }

    public Task<HttpResponse> CreateBuildingAsync(Building building)
    {
        return _buildingRepository.CreateBuildingAsync(building);
    }

    public Task<bool> DeleteBuildingAsync(Building building)
    {
        return _buildingRepository.DeleteBuildingAsync(building);
    }

    public Task<HttpResponse> UpdateBuildingAsync(Building building)
    {
        return _buildingRepository.UpdateBuildingAsync(building);
    }

    public Task<Guid> GetBuildingId(
        LongName universityName,
        LongName campusName,
        MediumName siteName,
        ShortName buildingAcronym)
    {
        return _buildingRepository.GetBuildingId(
            universityName, 
            campusName, 
            siteName,
            buildingAcronym);
    }

    public Task<Building> GetBuildingDetailsAsync(
        GuidValueObject buildingId)
    {
        return _buildingRepository.GetBuildingDetailsAsync(buildingId);
    }
}
