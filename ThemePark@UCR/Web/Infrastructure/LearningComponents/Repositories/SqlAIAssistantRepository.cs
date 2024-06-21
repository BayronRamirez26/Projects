
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Repositories;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.LearningComponents.Repositories;

internal class SqlAIAssistantRepository(ApplicationDbContext dbContext) : IAIAssistantRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task<bool> CreateAIAssistantAsync(AIAssistant aIAssistant)
    {
        if (aIAssistant == null)
        {
            return false;
        }
        try
        {
            await _dbContext
            .AIAssistants
            .AddAsync(aIAssistant);
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could save changes {ex}");
                Console.WriteLine(ex.Message);
                return false;
            }

        }
        catch (Exception ex)
        {

            Console.WriteLine($"Could not create AI Assistant {ex}");
            Console.WriteLine(ex.Message);
            return false;
        }
        return true;
    }

    public async Task<IEnumerable<AIAssistant>> GetAIAssistantAsync()
    {
        var result = await _dbContext.AIAssistants.ToListAsync();
        if(result.IsNullOrEmpty())
        {
            return Enumerable.Empty<AIAssistant>();
        }
        return result;

    }

    public async Task<bool> ModifyAIAssistantAsync(AIAssistant aIAssistant)
    {
        if(aIAssistant == null)
        {
            return false;
        }
        try
        {
            _dbContext
            .AIAssistants
            .Update(aIAssistant);

            try
            {
                var rowsAffected = await _dbContext.SaveChangesAsync();
                if (rowsAffected > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not save changes {ex}");
                Console.WriteLine(ex.Message);
                return false;
            }

        }
        catch (Exception ex)
        {

            Console.WriteLine($"Could not modify AI Assistant {ex}");
            Console.WriteLine(ex.Message);
            return false;
        }
        return true;

    }

    public async Task<bool> DeleteAIAssistantAsync(AIAssistant aIAssistant)
    {
        if(aIAssistant == null)
        {
            return false;
        }
        try
        {
            _dbContext
                .AIAssistants
                .Remove(aIAssistant);

            var rowsAffected = await _dbContext.SaveChangesAsync();

            return rowsAffected > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Caught unknow exception: {ex.Message}");
            throw new ApplicationException("Error deleting AIAssistant: " + ex.Message);
        }
    }
}
