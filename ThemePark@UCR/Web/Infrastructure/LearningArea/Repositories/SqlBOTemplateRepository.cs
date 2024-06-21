using Microsoft.EntityFrameworkCore;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.LearningArea.Repositories;

internal class SqlBOTemplateRepository : IBOTemplateRepository
{
    private readonly ApplicationDbContext _dbContext;

    public SqlBOTemplateRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<MediumName>> GetBOTemplatesObjectTypesAsync()
    {
        try
        {
            return await _dbContext
                .BOTemplate
                .Select(b => b.ObjectType)
                .Distinct()
                .ToListAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return new List<MediumName>();
        }
    }

    public async Task<IEnumerable<MediumName>> GetBOTemplatesPlanesAsync()
    {
        try
        {
            return await _dbContext
                .BOTemplate
                .Select(b => b.Plane)
                .Distinct()
                .ToListAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return new List<MediumName>();
        }
    }

    public async Task<IEnumerable<BOTemplate>> GetAllBOTemplatesAsync()
    {
        try
        {
            return await _dbContext
            .BOTemplate
            .ToListAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new List<BOTemplate>();
        }
    }

    public async Task<IEnumerable<BOTemplate>> GetBOTemplatesOfTypeAsync(
        MediumName objectType)
    {
        try
        {
            return await _dbContext
                .BOTemplate
                .Where(bo => bo.ObjectType == objectType)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new List<BOTemplate>();
        }
    }

    public async Task<IEnumerable<BOTemplate>> GetBOTemplatesOfPlaneAsync(
        MediumName plane)
    {
        try
        {
            return await _dbContext
                .BOTemplate
                .Where(bo => bo.Plane == plane)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new List<BOTemplate>();
        }
    }

    public async Task<IEnumerable<BOTemplate>> GetBOTemplatesOfTypeAndPlaneAsync(
        MediumName objectType,
        MediumName plane)
    {
        try
        {
            return await _dbContext
                .BOTemplate
                .Where(bo => bo.ObjectType == objectType && bo.Plane == plane)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new List<BOTemplate>();
        }
    }
}
