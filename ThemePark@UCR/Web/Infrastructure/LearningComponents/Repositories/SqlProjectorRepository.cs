
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.LearningComponents.Repositories;

internal class SqlProjectorRepository : IProjectorRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<SqlProjectorRepository> _logger;

    public SqlProjectorRepository(ApplicationDbContext dbContext, ILogger<SqlProjectorRepository> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<IEnumerable<Projector>> GetProjectorsAsync()
    {
        try
        {
            var result = await _dbContext.LearningComponentDtos
                .FromSql($"EXEC GetProjectors")
                .ToListAsync();
            var projectors = result.Select(LearningComponentDto => new Projector
            (
                LComponentID.Create(LearningComponentDto.LearningComponentAssetId),
                MediumName.Create(LearningComponentDto.LearningComponentName),
                Size.Create(LearningComponentDto.SizeX),
                Size.Create(LearningComponentDto.SizeY),
                Coordinate.Create(LearningComponentDto.PositionX),
                Coordinate.Create(LearningComponentDto.PositionY),
                Coordinate.Create(LearningComponentDto.PositionZ),
                Coordinate.Create(LearningComponentDto.RotationX),
                Coordinate.Create(LearningComponentDto.RotationY),
                GuidWrapper.Create(LearningComponentDto.LearningSpaceId)
            )).ToList();
            return projectors;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving projectors");
            throw;
        }
    }

    public async Task<bool> CreateProjectorAsync(Projector projector)
    {
        try
        {
            var learningComponentAssetID = projector.LearningComponentAssetId;
            var learningComponentName = projector.LearningComponentName.Value;
            var sizeX = projector.SizeX.Value;
            var sizeY = projector.SizeY.Value;
            var positionX = projector.PositionX.Value;
            var positionY = projector.PositionY.Value;
            var positionZ = projector.PositionZ.Value;
            var rotationX = projector.RotationX.Value;
            var rotationY = projector.RotationY.Value;
            var learningSpaceId = projector.LearningSpaceId.Value;

            await _dbContext.Database.ExecuteSqlRawAsync(
             "EXEC CreateProjector @LearningComponentName, @SizeX, @SizeY, @PositionX, @PositionY, @PositionZ, @RotationX, @RotationY, @LearningSpaceId",
             new[]
             {
                new SqlParameter("@LearningComponentName", learningComponentName),
                new SqlParameter("@SizeX", sizeX),
                new SqlParameter("@SizeY", sizeY),
                new SqlParameter("@PositionX", positionX),
                new SqlParameter("@PositionY", positionY),
                new SqlParameter("@PositionZ", positionZ),
                new SqlParameter("@RotationX", rotationX),
                new SqlParameter("@RotationY", rotationY),
                new SqlParameter("@LearningSpaceId", learningSpaceId)
             });
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating whiteboard");
            return false;
        }
    }

    public async Task<bool> ModifyProjectorAsync(Projector projector)
    {
        try
        {
            var learningComponentAssetId = projector.LearningComponentAssetId;
            var learningComponentName = projector.LearningComponentName.Value;
            var sizeX = projector.SizeX.Value;
            var sizeY = projector.SizeY.Value;
            var positionX = projector.PositionX.Value;
            var positionY = projector.PositionY.Value;
            var positionZ = projector.PositionZ.Value;
            var rotationX = projector.RotationX.Value;
            var rotationY = projector.RotationY.Value;
            var learningSpaceId = projector.LearningSpaceId.Value;

            await _dbContext.Database.ExecuteSqlRawAsync(
                "EXEC UpdateProjector @LearningComponentAssetId, @LearningComponentName, @SizeX, @SizeY, @PositionX, @PositionY, @PositionZ, @RotationX, @RotationY, @LearningSpaceId",
                new[]
                {
                new SqlParameter("@LearningComponentAssetId", learningComponentAssetId),
                new SqlParameter("@LearningComponentName", learningComponentName),
                new SqlParameter("@SizeX", sizeX),
                new SqlParameter("@SizeY", sizeY),
                new SqlParameter("@PositionX", positionX),
                new SqlParameter("@PositionY", positionY),
                new SqlParameter("@PositionZ", positionZ),
                new SqlParameter("@RotationX", rotationX),
                new SqlParameter("@RotationY", rotationY),
                new SqlParameter("@LearningSpaceId", learningSpaceId)
                });

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error modifying projector");
            return false;
        }
    }

    public async Task<bool> DeleteProjectorAsync(Projector projector)
    {
        try
        {
            var parameter = new SqlParameter("@LearningComponentAssetId", projector.LearningComponentAssetId);

            await _dbContext.Database.ExecuteSqlRawAsync(
                "EXEC DeleteProjector @LearningComponentAssetId",
                parameter);

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting projector");
            return false;
        }
    }
}
