using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.LearningArea.Repositories;

/// US: PIIB2401G1-93 CAD-CRL-02 List building levels
/// Task: PIIB2401G1-316 Create Levels sql repository on Infrastructure
/// Christopher Viquez Aguilar
/// Daniel Van der Laat Velez
/// Francisco Ulate
internal class SqlLevelRepository : ILevelRepository
{
    private readonly ApplicationDbContext _dbcontext;

    public SqlLevelRepository(ApplicationDbContext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    public async Task<IEnumerable<Level>> GetLevelsFromBuildingAsync(LongName UniversityName, LongName CampusName, MediumName SiteName, ShortName BuildingAcronym)
    {
        return await _dbcontext.Level
            .Where(l => l.BuildingAcronym == BuildingAcronym
                && l.SiteName == SiteName
                && l.CampusName == CampusName
                && l.UniversityName == UniversityName)
            .OrderBy(l => l.LevelNumber)
            .ToListAsync();
    }

    public async Task<bool> CreateLevelAsync(Level Levels)
    {
        try
        {
            _dbcontext
                .Level
                .Add(Levels);
            var rowsAffected = await _dbcontext
                .SaveChangesAsync();
            return rowsAffected > 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    public async Task<bool> UpdateLevelAsync(Level Levels)
    {
        try
        {
            _dbcontext
                .Level
                .Update(Levels);
            var rowsAffected = await _dbcontext
                .SaveChangesAsync();
            return rowsAffected > 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    public async Task<bool> DeleteLevelAsync(Level level)
    {
        try
        {
            _dbcontext
                .Level
                .Remove(level);
            return await _dbcontext
                .SaveChangesAsync() > 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    public async Task<Level> GetLevelByIdAsync(Guid id)
    {
        GuidValueObject guidVO = GuidValueObject.Create(id);
        return await _dbcontext.Level.FindAsync(guidVO);
    }
}
