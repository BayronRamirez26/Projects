using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;


namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.LearningComponents.Repositories;

internal class SqlInteractiveScreen : IInteractiveScreenRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<SqlInteractiveScreen> _logger;

    public SqlInteractiveScreen(ApplicationDbContext dbContext, ILogger<SqlInteractiveScreen> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<IEnumerable<InteractiveScreen>> GetInteractiveScreensAsync()
    {

        try
        {
            var result = await _dbContext.LearningComponentDtos
                .FromSql($"EXEC GetInteractiveScreen")
                .ToListAsync();
            var interactiveScreens = result.Select(LearningComponentDto => new InteractiveScreen
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
            return interactiveScreens;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving interactive screens");
            throw;
        }
    }

    public async Task<bool> CreateInteractiveScreenAsync(InteractiveScreen interactiveScreen)
    {
        try
        {
            var learningComponentAssetID = interactiveScreen.LearningComponentAssetId;
            var learningComponentName = interactiveScreen.LearningComponentName.Value;
            var sizeX = interactiveScreen.SizeX.Value;
            var sizeY = interactiveScreen.SizeY.Value;
            var positionX = interactiveScreen.PositionX.Value;
            var positionY = interactiveScreen.PositionY.Value;
            var positionZ = interactiveScreen.PositionZ.Value;
            var rotationX = interactiveScreen.RotationX.Value;
            var rotationY = interactiveScreen.RotationY.Value;
            var learningSpaceId = interactiveScreen.LearningSpaceId.Value;

            await _dbContext.Database.ExecuteSqlRawAsync(
             "EXEC CreateInteractiveScreen @LearningComponentName, @SizeX, @SizeY, @PositionX, @PositionY, @PositionZ, @RotationX, @RotationY, @LearningSpaceId",
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
            _logger.LogError(ex, "Error creating interactive screen");
            return false;
        }

    }
    public async Task<bool> ModifyInteractiveScreenAsync(InteractiveScreen interactiveScreen)
    {
        try
        {
            var learningComponentAssetId = interactiveScreen.LearningComponentAssetId;
            var learningComponentName = interactiveScreen.LearningComponentName.Value;
            var sizeX = interactiveScreen.SizeX.Value;
            var sizeY = interactiveScreen.SizeY.Value;
            var positionX = interactiveScreen.PositionX.Value;
            var positionY = interactiveScreen.PositionY.Value;
            var positionZ = interactiveScreen.PositionZ.Value;
            var rotationX = interactiveScreen.RotationX.Value;
            var rotationY = interactiveScreen.RotationY.Value;
            var learningSpaceId = interactiveScreen.LearningSpaceId.Value;

            await _dbContext.Database.ExecuteSqlRawAsync(
                "EXEC UpdateInteractiveScreen @LearningComponentAssetId, @LearningComponentName, @SizeX, @SizeY, @PositionX, @PositionY, @PositionZ, @RotationX, @RotationY, @LearningSpaceId",
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
            _logger.LogError(ex, "Error modifying interactive screen");
            return false;
        }

    }
    public async Task<bool> DeleteInteractiveScreenAsync(InteractiveScreen interactiveScreen)
    {
        try
        {
            var parameter = new SqlParameter("@LearningComponentAssetId", interactiveScreen.LearningComponentAssetId);

            await _dbContext.Database.ExecuteSqlRawAsync(
                "EXEC DeleteInteractiveScreen @LearningComponentAssetId",
                parameter);

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting interactive screen");
            return false;
        }
    }

}
