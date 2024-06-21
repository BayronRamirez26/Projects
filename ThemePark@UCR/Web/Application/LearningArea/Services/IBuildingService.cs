using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Dtos;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Application.LearningArea.Services;

public interface IBuildingService
{
    public Task<IEnumerable<Building>> GetAllBuildingsAsync();

    public Task<IEnumerable<Building>> GetNeighbourBuildingsFromBuilding(Building currentBuilding);

    public Task<IEnumerable<Building>> GetBuildingsFromSiteAsync(
        LongName universityName,
        LongName campusName,
        MediumName siteName);

    public Task<bool> CreateBuildingAsync(Building building);

    public Task<bool> UpdateBuildingAsync(Building building);

    public Task<bool> DeleteBuildingAsync(
        LongName universityName,
        LongName campusName,
        MediumName siteName,
        ShortName buildingAcronym);

    public Task<Guid> GetBuildingIdAsync(
        LongName universityName,
        LongName campusName,
        MediumName siteName,
        ShortName buildingAcronym);

    public Task<Building> GetBuildingDetailsAsync(
        GuidValueObject buildingId);
}
