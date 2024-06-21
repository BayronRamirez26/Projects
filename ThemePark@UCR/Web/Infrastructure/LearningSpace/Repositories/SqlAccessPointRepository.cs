using Microsoft.EntityFrameworkCore;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Repositories;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.LearningSpace.Repositories;

/// <summary>
/// Interface with all services of AccesPoint
/// </summary>
internal class SqlAccesPointRepository : IAccessPointRepository
{
    private readonly ApplicationDbContext _dbContext;

    /// <summary>
    /// Primary constructor
    /// </summary>
    /// <param name="dbContext">DbContext instance need it for make operations to database</param>
    public SqlAccesPointRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Service that create a new access point in database
    /// </summary>
    /// <param name="accessPoint">New AccessPoint instance desired to create</param>
    /// <returns>A Task bool with result of operation</returns>
    public async Task<bool> CreateAccessPointAsync(AccessPoint accessPoint)
    {
        using var transaction = await _dbContext.Database.BeginTransactionAsync();

        _dbContext.AccessPoints.Add(accessPoint);
        await _dbContext.SaveChangesAsync();

        await transaction.CommitAsync();

        return true;
    }

    public Task<bool> DeleteAccessPointAsync(GuidWrapper guid)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Service that returns all access point from database
    /// </summary>
    /// <returns>A list with all AccessPoint available</returns>
    public async Task<IEnumerable<AccessPoint>> GetAccessPointAsync()
    {
        return await _dbContext
            .AccessPoints
            .ToListAsync();
    }

    public async Task<IEnumerable<AccessPoint>> GetAccessPointsFromLevelAsync(GuidWrapper id)
    {
        return await _dbContext.AccessPoints.Where(ap => ap.LevelId == id).ToListAsync();
    }

    /// <summary>
    /// Service that allow to modify an already existing access point
    /// </summary>
    /// <param name="accessPoint">AccessPoint instance desired to change</param>
    /// <returns>A Task bool with result of operation</returns>
    public async Task<bool> ModifyAccessPointAsync(AccessPoint accessPoint)
    {
        _dbContext
            .AccessPoints
            .Update(accessPoint);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Service that delete an existing access point on database
    /// </summary>
    /// <param name="accessPoint">AccessPoint instance desired to delete</param>
    /// <returns>A Task bool with result operation</returns>
    // public Task<bool> DeleteAccessPointAsync(AccessPoint accessPoint);
}
