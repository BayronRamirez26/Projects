using Microsoft.EntityFrameworkCore;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Repositories;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.LearningSpace.Repositories;

/// <summary>
/// Creates ApplicationDbContext to perform database operations on tables of learning spaces
/// </summary>
internal class SqlLearningSpaceRepository : ILearningSpaceRepository
{
    /// <summary>
    /// DbContext neccesary to make sql request
    /// </summary>
    private readonly ApplicationDbContext _dbContext;

    /// <summary>
    /// Primary constructor
    /// </summary>
    /// <param name="dbContext">dbContext instance neccesary</param>
    public SqlLearningSpaceRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// This method allow to create a learning space an show it in database
    /// </summary>
    /// <param name="learningSpace">Input learning space requiered to add</param>
    /// <returns>Task carrying a bool with result of operation</returns>
    public async Task<bool> CreateLearningSpaceAsync(LearningSpaces learningSpace)
    {
        //if (learningSpace.LevelId.Value == Guid.Empty)
        //{
        //    learningSpace.LevelId = null;
        //}
        // Try adding the learning space in database

        using var transaction = await _dbContext.Database.BeginTransactionAsync();


        try
        {
            await _dbContext
            .LearningSpaces
            .AddAsync(learningSpace);

            // Try saving changes
            try
            {
                await _dbContext
                    .SaveChangesAsync();

            } catch (Exception ex) {

                Console.WriteLine($"Could save changes {ex}");
                Console.WriteLine(ex.Message);
                return false;
            }

            transaction.Commit();

        } catch (Exception ex) {

            Console.WriteLine($"Could not create LearningSpace {ex}");
            Console.WriteLine(ex.Message);
            return false;
        }

        return true;
    }

    /// <summary>
    /// This method return all learning space available in database
    /// </summary>
    /// <returns>An enumerable with all learning spaces available</returns>
    public async Task<IEnumerable<LearningSpaces>> GetLearningSpaceAsync()
    {
        // Try getting learning spaces
        try
        {
            return await _dbContext
                .LearningSpaces
                .ToListAsync();

        } catch (Exception ex) {

            Console.WriteLine($"Could not get LearningSpaces {ex}");
            Console.WriteLine(ex.Message);
            return Enumerable.Empty<LearningSpaces>();
        }
        return Enumerable.Empty<LearningSpaces>(); 
    }

    /// <summary>
    /// This method allow to update the information about a learning space
    /// </summary>
    /// <param name="learningSpace">Input learning space requiered to add</param>
    /// <returns>Task carrying a bool with result of operation</returns>
    public async Task<bool> ModifyLearningSpaceAsync(LearningSpaces learningSpace)
    {
        using var transaction = await _dbContext.Database.BeginTransactionAsync();

        // Try updating the LearningSpace
        try
        {
            _dbContext
                .LearningSpaces
                .Update(learningSpace);

            // Try saving changes
            try
            {
                await _dbContext
                    .SaveChangesAsync();

            } catch (Exception ex) {

                Console.WriteLine($"Error saving changes {ex}");
                Console.WriteLine(ex.Message);
                return false;
            }

            transaction.Commit();

        }
        catch (Exception ex) {

            Console.WriteLine($"Error updating LearningSpace {ex}");
            Console.WriteLine(ex.Message);
            return false;
        }

        return true;
    }

    /// <summary>
    /// This method allow to delete a learning space in database
    /// </summary>
    /// <param name="learningSpace">Input learning space requiered to delete</param>
    /// <returns>Task carrying a bool with result of operation</returns>
    public async Task<bool> DeleteLearningSpaceAsync(GuidWrapper id)
    {
        using var transaction = await _dbContext.Database.BeginTransactionAsync();

        var learningSpace = await _dbContext.LearningSpaces.FindAsync(id);
        if (learningSpace == null)
        {
            return false;
        }

        _dbContext.LearningSpaces.Remove(learningSpace);
        await _dbContext.SaveChangesAsync();
        transaction.Commit();

        return true;
    }

    /// <summary>
    /// This method allow to get a LearningSpace from an ID given
    /// </summary>
    /// <param name="id">Input Guid requiered to search</param>
    /// <returns>Task<LearningSpace> with the result of operation</LearningSpace></returns>
    public async Task<LearningSpaces?> GetLearningSpaceFromIdAsync(GuidWrapper id)
    {
        var learningSpace = await _dbContext.LearningSpaces.FindAsync(id);
        if (learningSpace == null)
        {
            //var output = new LearningSpaces();
            return null;
        }

        return learningSpace;
    }

    /// <summary>
    /// This method allow to get a LSType from an ID given
    /// </summary>
    /// <param name="id">Input Guid requiered to search</param>
    /// <returns>Task<LSType> with the result of operation</LSType></returns>
    public async Task<LSType?> GetLSTypeFromIdAsync(GuidWrapper id)
    {
        var LSType = await _dbContext.LSTypes.FindAsync(id.Value);
        if (LSType == null)
        {
            return null;
        }

        return LSType;
    }

    /// <summary>
    /// Get all learning spaces by lsTypeId
    /// </summary>
    /// <param name="id">Id neccesary</param>
    /// <returns>Learning Spaces related to a type</returns>
    public async Task<IEnumerable<LearningSpaces>> GetLearningSpacesByLSTypeIdAsync(GuidWrapper id)
    {
        try
        {
            // Obtener todos los LearningSpaces que tienen el ID del LSType especificado
            return await _dbContext.LearningSpaces.Where(ls => ls.Type == id).ToListAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Could not get LearningSpaces by LSType ID: {ex}");
            Console.WriteLine(ex.Message);
            return Enumerable.Empty<LearningSpaces>();
        }
    }

    /// <summary>
    /// Get all projectors for ProjectorsOfLearningSpace
    /// </summary>
    /// <param name="id">Id neccesary</param>
    /// <returns>Return a Enumarable with a list of projectors</returns>
    public async Task<IEnumerable<Projector>> GetProjectorsOfALearningSpacesAsync(GuidWrapper id)
    {
        // Try getting learning spaces
        try
        {
            return await _dbContext
                .Projectors
                .Where(pr => pr.LearningSpaceId == id)
                .ToListAsync();

        }
        catch (Exception ex)
        {

            Console.WriteLine($"Could not get Projectors {ex}");
            Console.WriteLine(ex.Message);
            return Enumerable.Empty<Projector>();
        }
    }

    public async Task<IEnumerable<Whiteboard>> GetWhiteboardOfALearningSpacesAsync(GuidWrapper id)
    {
        // Try getting learning spaces
        try
        {
            return await _dbContext
                .Whiteboard
                .Where(w => w.LearningSpaceId == id)
                .ToListAsync();

        }
        catch (Exception ex)
        {

            Console.WriteLine($"Could not get Projectors {ex}");
            Console.WriteLine(ex.Message);
            return Enumerable.Empty<Whiteboard>();
        }
    }

    public async Task<IEnumerable<InteractiveScreen>> GetInteractiveScreenOfALearningSpacesAsync(GuidWrapper id)
    {
        // Try getting learning spaces
        try
        {
            return await _dbContext
                .InteractiveScreens
                .Where(isc => isc.LearningSpaceId == id)
                .ToListAsync();

        }
        catch (Exception ex)
        {

            Console.WriteLine($"Could not get Projectors {ex}");
            Console.WriteLine(ex.Message);
            return Enumerable.Empty<InteractiveScreen>();
        }
    }

    public async Task<IEnumerable<AccessPoint>> GetAccessPointsOfALearningSpacesAsync(GuidWrapper id)
    {
        // Try getting learning spaces
        try
        {
            return await _dbContext
                .AccessPoints
                .Where(isc => isc.LearningSpaceId == id)
                .ToListAsync();

        }
        catch (Exception ex)
        {

            Console.WriteLine($"Could not get Projectors {ex}");
            Console.WriteLine(ex.Message);
            return Enumerable.Empty<AccessPoint>();
        }
    }

}
