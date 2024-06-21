using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.Responses;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Repositories;

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


    /// <summary>
    ///     Create a building
    /// </summary>
    /// <param name="building">The building to be created</param>
    /// <returns>
    ///     Returns a boolean indicating if the building was created or not
    /// </returns>
    public Task<HttpResponse> CreateBuildingAsync(Building building);

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
        Building building);

    /// <summary>
    ///   Update a building
    /// </summary>
    /// <param name="building"> The building to be updated</param>
    /// <returns>
    ///     Returns a boolean indicating if the building was updated or not
    /// </returns>
    public Task<HttpResponse> UpdateBuildingAsync(Building building);

    public Task<Guid> GetBuildingId(
        LongName universityName,
        LongName campusName,
        MediumName siteName,
        ShortName buildingAcronym);

    public Task<Building> GetBuildingDetailsAsync(
        GuidValueObject buildingId);
}
