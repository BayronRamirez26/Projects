using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Repositories;

/// <summary>
/// Interface for the University Repository
/// </summary>
public interface IBuildingRepository
{
    /// <summary>
    ///     List all buildings
    /// </summary>
    /// <returns>
    ///     Returns the buildings list
    /// </returns>
    public Task<IEnumerable<Building>> GetAllBuildingsAsync();

    public Task<IEnumerable<Building>> GetNeighbourBuildingsFromBuilding(Building currentBuilding);

    public Task<IEnumerable<Building>> GetBuildingsFromSiteAsync(
        LongName universityName,
        LongName campusName,
        MediumName siteName);

    /// <summary>
    ///     Create a building
    /// </summary>
    /// <param name="building">The building to be created</param>
    /// <returns>
    ///     Returns a boolean indicating if the building was created or not
    /// </returns>
    public Task<bool> CreateBuildingAsync(Building building);

    /// <summary>
    ///     Delete a building
    /// </summary>
    /// <param name="universityName">The university name</param>"
    /// <param name="campusName">The campus name</param>"
    /// <param name="siteName">The site name</param>"
    /// <param name="buildingAcronym">The building acronym</param>"
    /// <returns>
    ///     Returns a boolean indicating if the building was deleted or not
    /// </returns>
    public Task<bool> DeleteBuildingAsync(
        LongName universityName,
        LongName campusName,
        MediumName siteName,
        ShortName buildingAcronym);

    /// <summary>
    ///   Update a building
    /// </summary>
    /// <param name="building"> The building to be updated</param>
    /// <returns>
    ///     Returns a boolean indicating if the building was updated or not
    /// </returns>
    public Task<bool> UpdateBuildingAsync(Building building);

    public Task<Guid> GetBuildingIdAsync(
        LongName universityName,
        LongName campusName,
        MediumName siteName,
        ShortName buildingAcronym);

    public Task<Building> GetBuildingDetailsAsync(
        GuidValueObject buildingId);
}