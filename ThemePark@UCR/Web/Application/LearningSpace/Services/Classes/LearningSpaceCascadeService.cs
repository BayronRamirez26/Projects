using UCR.ECCI.PI.ThemePark_UCR.Application.LearningSpace.Services.Interfaces;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Repositories;

namespace UCR.ECCI.PI.ThemePark_UCR.Application.LearningSpace.Services.Classes;

/// <summary>
/// This class makes all requests to repository about cascade on create learning space
/// </summary>
internal class LearningSpaceCascadeService : ILearningSpaceCascadeService
{
    /// <summary>
    /// Instance for make request in database about cascade
    /// </summary>
    private readonly ILearningSpaceCascadeRepository _cascadeRepository;

    /// <summary>
    /// Primary constructor
    /// </summary>
    /// <param name="cascadeRepository">ILearningSapceCascadeRepository instance neccesary</param>
    public LearningSpaceCascadeService(ILearningSpaceCascadeRepository cascadeRepository)
    {
        _cascadeRepository = cascadeRepository;
    }

    /// <summary>
    /// This method return a list of campus releated to a university
    /// </summary>
    /// <param name="university">University string requiered to search</param>
    /// <returns>A list of all campus releated to university</returns>
    public async Task<IEnumerable<string>> GetCampusFromUniversity(string university)
    {
        return await _cascadeRepository.GetCampusFromUniversity(university);
    }

    /// <summary>
    /// This method return a list of sites releated to a campus
    /// </summary>
    /// <param name="campus">Campus string requiered to search</param>
    /// <returns>A list of all sites releated to campus</returns>
    public async Task<IEnumerable<string>> GetSitesFromCampus(string campus)
    {
        return await _cascadeRepository.GetSitesFromCampus(campus);
    }

    /// <summary>
    /// This method return a list of buildings releated to a campus
    /// </summary>
    /// <param name="site">Site string requiered to search</param>
    /// <returns>A list of all buildings realeated to site</returns>
    public async Task<IEnumerable<string>> GetBuildingsFromSite(string site)
    {
        return await _cascadeRepository.GetBuildingsFromSite(site);
    }

    public async Task<IEnumerable<Level>> GetLevelFromBuilding(Building building)
    {
        return await _cascadeRepository.GetLevelFromBuilding(building);
    }

    public async Task<IEnumerable<string>> GetBuilding(string siteName, string campusName)
    {
        return await _cascadeRepository.GetBuilding(siteName, campusName);
        
    }
    
}
