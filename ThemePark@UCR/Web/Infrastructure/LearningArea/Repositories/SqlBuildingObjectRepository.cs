using Microsoft.EntityFrameworkCore;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.LearningArea.Repositories;

internal class SqlBuildingObjectRepository : IBuildingObjectRepository
{
    private readonly ApplicationDbContext _dbContext;

    public SqlBuildingObjectRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<BuildingObject>> GetAllBuildingObjectsAsync()
    {
        try
        {
            return await _dbContext
                .BuildingObject
                .ToListAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new List<BuildingObject>();
        }
    }

    public async Task<IEnumerable<BuildingObject>> GetBuildingObjectsFromLevelAsync(
        GuidValueObject levelId)
    {
        try
        {
            return await _dbContext
                .BuildingObject
                .Where(bo => bo.LevelId == levelId)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new List<BuildingObject>();
        }
    }

    public async Task<BuildingObject> GetBuildingObjectDetailsAsync(
        GuidValueObject buildingId)
    {
        try
        {
            var buildingObject = await _dbContext
                .BuildingObject
                .FindAsync(buildingId);
            if (buildingObject == null)
            {
                return BuildingObject.Invalid;
            }
            return buildingObject;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return BuildingObject.Invalid;
        }
    }

    public async Task<Tuple<bool, string>> AddBuildingObjectToLevelAsync(
        BuildingObject buildingObject)
    {
        string message = "No se pudo agregar el objeto al nivel";
        try
        {
            await _dbContext.BuildingObject.AddAsync(buildingObject);

            var result = await _dbContext.SaveChangesAsync();

            if (result > 0)
            {
                message = "El objeto se agregó al nivel exitosamente";
                return new Tuple<bool, string>(true, message);
            }
            return new Tuple<bool, string>(false, message);
        }
        catch (Exception ex)
        {
            message += $": {ex.Message}";
            return new Tuple<bool, string>(false, message);
        }
    }

    public async Task<Tuple<bool, string>> ModifyBuildingObjectAsync(
        BuildingObject buildingObject)
    {
        string message = "No se pudo modificar el objeto";
        try
        {
            _dbContext.BuildingObject.Update(buildingObject);

            var result = await _dbContext.SaveChangesAsync();

            if (result > 0)
            {
                message = "El objeto se modificó exitosamente";
                return new Tuple<bool, string>(true, message);
            }
            return new Tuple<bool, string>(false, message);
        }
        catch (Exception ex)
        {
            message += $": {ex.Message}";
            return new Tuple<bool, string>(false, message);
        }
    }

    public async Task<Tuple<bool, string>> DeleteBuildingObjectAsync(
        BuildingObject buildingObject)
    {
        string message = "No se pudo eliminar el objeto";
        try
        {
            _dbContext.BuildingObject.Remove(buildingObject);

            var result = await _dbContext.SaveChangesAsync();

            if (result > 0)
            {
                message = "El objeto se eliminó exitosamente";
                return new Tuple<bool, string>(true, message);
            }
            return new Tuple<bool, string>(false, message);
        }
        catch (Exception ex)
        {
            message += $": {ex.Message}";
            return new Tuple<bool, string>(false, message);
        }
    }
}
