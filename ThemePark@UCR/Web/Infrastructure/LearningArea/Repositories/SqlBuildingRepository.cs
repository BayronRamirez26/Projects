using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.LearningArea.Repositories;


internal class SqlBuildingRepository : IBuildingRepository
{
    // DI
    private readonly ApplicationDbContext _dbContext;

    public SqlBuildingRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Building>> GetAllBuildingsAsync()
    {
        var result = await _dbContext.Building.ToListAsync();
        result = result.OrderBy(b => b.BuildingAcronym.Value).ToList();
        return result;
    }

    public async Task<IEnumerable<Building>> GetNeighbourBuildingsFromBuilding(Building currentBuilding)
    {
        var result = await _dbContext.Building
            .Where(b => b.UniversityName == currentBuilding.UniversityName &&
                b.CampusName == currentBuilding.CampusName &&
                b.SiteName == currentBuilding.SiteName &&
                b.BuildingAcronym != currentBuilding.BuildingAcronym)
            .ToListAsync();

        if (result == null)
        {
            return null;
        }
        return result;
    }

    public async Task<IEnumerable<Building>> GetBuildingsFromSiteAsync(
        LongName universityName,
        LongName campusName,
        MediumName siteName)
    {
        return await _dbContext.Building
            .Where(b => 
                b.UniversityName == universityName &&
                b.CampusName == campusName &&
                b.SiteName == siteName)
            .ToListAsync();
    }

    public async Task<bool> CreateBuildingAsync(Building building)
    {
        try
        {
            // Add the building to the context
            _dbContext
                .Building
                .Add(building);

            // Save the changes
            var rowsAffected = await _dbContext.SaveChangesAsync();

            // Return true if the building was added and false if not
            return rowsAffected > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Caught unknown exception: {ex.Message}");
            throw new ApplicationException("Error creando el edificio: " + ex.Message);
        }
    }

    public async Task<bool> UpdateBuildingAsync(Building building)
    {
        try
        {
            // Update the building
            _dbContext
                .Building
                .Update(building);

            // Save the changes
            var rowsAffected = await _dbContext.SaveChangesAsync();

            // Return true if the building was updated and false if not
            return rowsAffected > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Caught unknown exception: {ex.Message}");
            throw new ApplicationException("Error modificando el edificio: " + ex.Message);
        }
    }

    public async Task<bool> DeleteBuildingAsync(
        LongName universityName,
        LongName campusName,
        MediumName siteName,
        ShortName buildingAcronym)
    {   
        try
        {
            // Find the building
            var actualBuilding = await _dbContext
                .Building
                .Where(b => b.UniversityName == universityName &&
                    b.CampusName == campusName &&
                    b.SiteName == siteName &&
                    b.BuildingAcronym == buildingAcronym)
                .FirstOrDefaultAsync();

            // If the building is not found, return false
            if (actualBuilding == null)
            {
                return false;
            }

            // Remove the building from the context
            _dbContext
                .Building
                .Remove(actualBuilding);

            // Save the changes
            var rowsAffected = await _dbContext.SaveChangesAsync();

            // Return true if the building was deleted and false if not
            return rowsAffected > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Caught unknow exception: {ex.Message}");
            throw new ApplicationException("Error deleting building: " + ex.Message);
        }
    }

    public async Task<Guid> GetBuildingIdAsync(
        LongName universityName,
        LongName campusName,
        MediumName siteName,
        ShortName buildingAcronym)
    {
        var building = await _dbContext.Building
            .Where(b => b.UniversityName == universityName &&
                b.CampusName == campusName &&
                b.SiteName == siteName &&
                b.BuildingAcronym == buildingAcronym)
            .FirstOrDefaultAsync();

        if (building == null)
        {
            return Guid.Empty;
        }

        return building.BuildingId.Value;
    }

    public async Task<Building> GetBuildingDetailsAsync(
        GuidValueObject buildingId)
    {
        try
        {
            var building = await _dbContext.Building
                .Where(b => b.BuildingId == buildingId)
                .FirstOrDefaultAsync();
            if (building != null)
            {
                return building;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Caught unknown exception: {ex.Message}");
            throw new ApplicationException("Error obteniendo detalles del edificio: " + ex.Message);
        }
        return Building.Invalid;
    }
}
