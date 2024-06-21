using Microsoft.EntityFrameworkCore;
using System.Security.Policy;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Repositories;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.LearningSpace.Repositories;

/// <summary>
/// Creates ApplicationDbContext to perform database operations with cascade
/// </summary>
internal class SqlLearningSpaceCascadeRepository : ILearningSpaceCascadeRepository
{
    /// <summary>
    /// DbContext neccesary to make sql request
    /// </summary>
    private readonly ApplicationDbContext _dbContext;

    /// <summary>
    /// Primary constructor
    /// </summary>
    /// <param name="dbContext">dbContext instance neccesary</param>
    public SqlLearningSpaceCascadeRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// This method return a list of campus releated to a university
    /// </summary>
    /// <param name="university">University string requiered to search</param>
    /// <returns>A list of all campus releated to university</returns>
    public async Task<IEnumerable<string>> GetCampusFromUniversity(string university)
    {
        // Try getting all campus
        try
        {
            return await _dbContext.Campus
            .FromSqlRaw("SELECT CampusName FROM [ThemePark].[Campus] WHERE UniversityName = {0}", university)
            .Select(c => c.CampusName.Value)
            .ToListAsync();
            
        }
        catch (Exception ex)
        {

            Console.WriteLine($"Could not get Campus {ex}");
            Console.WriteLine(ex.Message);
            return Enumerable.Empty<string>();
        }
    }

    /// <summary>
    /// This method return a list of sites releated to a campus
    /// </summary>
    /// <param name="campus">Campus string requiered to search</param>
    /// <returns>A list of all sites releated to campus</returns>
    public async Task<IEnumerable<string>> GetSitesFromCampus(string campus)
    {
        // Try getting all sites
        try
        {
           
            return await _dbContext.Site
            .FromSqlRaw("SELECT SiteName FROM [ThemePark].[Site] WHERE CampusName = {0}", campus)
            .Select(c => c.SiteName.Value)
            .ToListAsync();

        }
        catch (Exception ex)
        {

            Console.WriteLine($"Could not get Sites {ex}");
            Console.WriteLine(ex.Message);
            return Enumerable.Empty<string>();
        }
    }

    /// <summary>
    /// This method return a list of buildings releated to a campus
    /// </summary>
    /// <param name="site">Site string requiered to search</param>
    /// <returns>A list of all buildings realeated to site</returns>
    public async Task<IEnumerable<string>> GetBuildingsFromSite(string site)
    {
        // Try getting all sites
        try
        {
            
            return await _dbContext.Building
               .FromSqlRaw("SELECT BuildingAcronym FROM [ThemePark].[Building] WHERE SiteName = {0}", site)
               .Select(c => c.BuildingAcronym.Value)
               .ToListAsync();

        }
        catch (Exception ex)
        {

            Console.WriteLine($"Could not get Buildings {ex}");
            Console.WriteLine(ex.Message);
            return Enumerable.Empty<string>();
        }
    }

    public async Task<IEnumerable<Level>> GetLevelFromBuilding(Building building)
    {
        // Try getting all sites
        try
        {

            return await _dbContext.Level
                .FromSqlRaw("SELECT * FROM [ThemePark].[Level] WHERE BuildingAcronym = {0} AND SiteName = {1} AND CampusName = {2} AND UniversityName = {3}", building.BuildingAcronym, building.SiteName, building.CampusName, building.UniversityName)
                .ToListAsync();

        }
        catch (Exception ex)
        {

            Console.WriteLine($"Could not get Buildings {ex}");
            Console.WriteLine(ex.Message);
            return Enumerable.Empty<Level>();
        }
    }

    public async Task<IEnumerable<string>> GetBuilding(string site, string campus)
    {
        try
        {
            //return await _dbContext.Building.FromSqlRaw("SELECT BuildingAcronym FROM [ThemePark].[Building]").ToListAsync();

            return await _dbContext.Building
                .FromSqlRaw("SELECT BuildingAcronym FROM [ThemePark].[Building] WHERE SiteName = {0} AND CampusName = {1} ", site, campus)
                .Select(c => c.BuildingAcronym.Value)
                .ToListAsync();

        }
        catch (Exception ex)
        {

            Console.WriteLine($"Could not get Buildings {ex}");
            Console.WriteLine(ex.Message);
            return Enumerable.Empty<string>();
        }
    }
}
