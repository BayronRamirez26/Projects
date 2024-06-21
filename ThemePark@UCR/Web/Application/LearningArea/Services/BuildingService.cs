using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Dtos;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Validations;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Application.LearningArea.Services;

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
    private readonly ISiteRepository _siteRepository;

    public BuildingService(IBuildingRepository buildingRepository, ISiteRepository siteRepository)
    {
        _buildingRepository = buildingRepository;
        _siteRepository = siteRepository;
    }

    public Task<IEnumerable<Building>> GetAllBuildingsAsync()
    {
        return _buildingRepository.GetAllBuildingsAsync();
    }

    public Task<IEnumerable<Building>> GetNeighbourBuildingsFromBuilding(Building currentBuilding)
    {
        return _buildingRepository.GetNeighbourBuildingsFromBuilding(currentBuilding);
    }

    public Task<bool> CreateBuildingAsync(Building building)
    {
        Site site = _siteRepository.GetSitePropertiesAsync(
            building.UniversityName, 
            building.CampusName, 
            building.SiteName)
        .Result;

        if (site == null)
        {
            return Task.FromResult(false);
        }

        IEnumerable<Building> existingBuildings = _buildingRepository.GetNeighbourBuildingsFromBuilding(building).Result;
        if (existingBuildings == null)
        {
            return Task.FromResult(false);
        }

        bool canCreateBuilding = BuildingValidations.BuildingCanBeCreated(building, existingBuildings, site);
        if (!canCreateBuilding)
        {
            return Task.FromResult(false);
        }

        return _buildingRepository.CreateBuildingAsync(building);
    }

    public Task<bool> DeleteBuildingAsync(
        LongName universityName,
        LongName campusName,
        MediumName siteName,
        ShortName buildingAcronym)
    {
        return _buildingRepository.DeleteBuildingAsync(
            universityName, campusName, siteName, buildingAcronym);
    }

    public Task<bool> UpdateBuildingAsync(Building building)
    {
        Site site = _siteRepository.GetSitePropertiesAsync(
            building.UniversityName,
            building.CampusName,
            building.SiteName)
        .Result;

        if (site == null)
        {
            return Task.FromResult(false);
        }

        IEnumerable<Building> existingBuildings = _buildingRepository.GetNeighbourBuildingsFromBuilding(building).Result;
        if (existingBuildings == null)
        {
            return Task.FromResult(false);
        }

        bool canCreateBuilding = BuildingValidations.BuildingCanBeModified(building, existingBuildings, site);
        if (!canCreateBuilding)
        {
            return Task.FromResult(false);
        }

        return _buildingRepository.UpdateBuildingAsync(building);
    }

    public Task<Guid> GetBuildingIdAsync(
        LongName universityName,
        LongName campusName,
        MediumName siteName,
        ShortName buildingAcronym)
    {
        return _buildingRepository.GetBuildingIdAsync(
            universityName,
            campusName,
            siteName,
            buildingAcronym);
    }

    public Task<IEnumerable<Building>> GetBuildingsFromSiteAsync(
        LongName universityName,
        LongName campusName,
        MediumName siteName)
    {
        return _buildingRepository.GetBuildingsFromSiteAsync(
            universityName,
            campusName,
            siteName);
    }

    public Task<Building> GetBuildingDetailsAsync(
        GuidValueObject buildingId)
    {
        return _buildingRepository.GetBuildingDetailsAsync(buildingId);
    }
}
