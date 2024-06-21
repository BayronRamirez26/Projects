using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Dtos;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;


namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.LearningComponents.Repositories;

internal class SqlWhiteboardRepository : IWhiteboardRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<SqlWhiteboardRepository> _logger;

    public SqlWhiteboardRepository(ApplicationDbContext dbContext, ILogger<SqlWhiteboardRepository> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<IEnumerable<Whiteboard>> GetWhiteboardsAsync()
    {
        try
        {
            var result = await _dbContext.LearningComponentDtos
                                         .FromSqlRaw($"EXEC GetWhiteboards")
                                         .ToListAsync();
            if(result == null )
            {
                return Enumerable.Empty<Whiteboard>();
            }
            var whiteboards = result.Select(LearningComponentDto => new Whiteboard
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

            return whiteboards;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving whiteboards");
            throw;
        }
    }

    public async Task<bool> CreateWhiteboardAsync(Whiteboard whiteboard)
    {
        if(whiteboard == null)
        {
            return false;
        }
        try
        {

            var learningComponentName = whiteboard.LearningComponentName.Value;
            var sizeX = whiteboard.SizeX.Value;
            var sizeY = whiteboard.SizeY.Value; 
            var positionX = whiteboard.PositionX.Value;
            var positionY = whiteboard.PositionY.Value;
            var positionZ = whiteboard.PositionZ.Value;
            var rotationX = whiteboard.RotationX.Value;
            var rotationY = whiteboard.RotationY.Value;
            var learningSpaceId = whiteboard.LearningSpaceId.Value;

            await _dbContext.Database.ExecuteSqlRawAsync(
             "EXEC CreateWhiteboard @LearningComponentName, @SizeX, @SizeY, @PositionX, @PositionY, @PositionZ, @RotationX, @RotationY, @LearningSpaceId",
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
    public async Task<bool> ModifyWhiteboardAsync(Whiteboard whiteboard)
    {
        if(whiteboard == null)
        {
            return false;
        }
        try
        {
            var learningComponentAssetId = whiteboard.LearningComponentAssetId;
            var learningComponentName = whiteboard.LearningComponentName.Value;
            var sizeX = whiteboard.SizeX.Value;
            var sizeY = whiteboard.SizeY.Value;
            var positionX = whiteboard.PositionX.Value;
            var positionY = whiteboard.PositionY.Value;
            var positionZ = whiteboard.PositionZ.Value;
            var rotationX = whiteboard.RotationX.Value;
            var rotationY = whiteboard.RotationY.Value;
            var learningSpaceId = whiteboard.LearningSpaceId.Value;

            await _dbContext.Database.ExecuteSqlRawAsync(
                "EXEC UpdateWhiteboard @LearningComponentAssetId, @LearningComponentName, @SizeX, @SizeY, @PositionX, @PositionY, @PositionZ, @RotationX, @RotationY, @LearningSpaceId",
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
            _logger.LogError(ex, "Error modifying whiteboard");
            return false;
        }
    }

    public async Task<bool> DeleteWhiteboardAsync(Whiteboard whiteboard)
    {
        if(whiteboard == null)
        {
            return false;
        }
        try
        {
            var parameter = new SqlParameter("@LearningComponentAssetId", whiteboard.LearningComponentAssetId);

            await _dbContext.Database.ExecuteSqlRawAsync(
                "EXEC DeleteWhiteboard @LearningComponentAssetId",
                parameter);

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting whiteboard");
            return false;
        }
    }
}
