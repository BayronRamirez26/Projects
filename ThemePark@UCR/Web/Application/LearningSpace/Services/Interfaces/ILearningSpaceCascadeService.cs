﻿using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Entities;

namespace UCR.ECCI.PI.ThemePark_UCR.Application.LearningSpace.Services.Interfaces;

/// <summary>
/// Defines service functions for managing cascade requests
/// </summary>
public interface ILearningSpaceCascadeService
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

    public Task<IEnumerable<string>> GetBuilding(string siteName, string campusName);


}
