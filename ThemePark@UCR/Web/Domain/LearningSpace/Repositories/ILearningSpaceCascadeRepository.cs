using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Entities;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Repositories;

/// <summary>
/// This interface contains all services to make request in database.
/// Allows to have a control over cascade request
/// </summary>
public interface ILearningSpaceCascadeRepository
{
    /// <summary>
    /// This method return a list of campus releated to a university
    /// </summary>
    /// <param name="university">University string requiered to search</param>
    /// <returns>A list of all campus releated to university</returns>
    public Task<IEnumerable<string>> GetCampusFromUniversity(string university);

    /// <summary>
    /// This method return a list of sites releated to a campus
    /// </summary>
    /// <param name="campus">Campus string requiered to search</param>
    /// <returns>A list of all sites releated to campus</returns>
    public Task<IEnumerable<string>> GetSitesFromCampus(string campus);

    /// <summary>
    /// This method return a list of buildings releated to a campus
    /// </summary>
    /// <param name="site">Site string requiered to search</param>
    /// <returns>A list of all buildings realeated to site</returns>
    public Task<IEnumerable<string>> GetBuildingsFromSite(string site);


    public Task<IEnumerable<Level>> GetLevelFromBuilding(Building building);

    public Task<IEnumerable<string>> GetBuilding(string site, string campus);
}
