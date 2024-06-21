using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Application.LearningArea.Services;


public class LevelService : ILevelService
{
    private readonly ILevelRepository _levelRepository;
    private readonly IBuildingRepository _buildingRepository;

    public LevelService(ILevelRepository levelRepository, IBuildingRepository buildingRepository)
    {
        _levelRepository = levelRepository;
        _buildingRepository = buildingRepository;
    }

    public Task<IEnumerable<Level>> GetLevelsFromBuildingAsync(LongName UniversityName, LongName CampusName, MediumName SiteName, ShortName BuildingAcronym)
    {
        return _levelRepository.GetLevelsFromBuildingAsync(UniversityName, CampusName, SiteName, BuildingAcronym);
    }

    public async Task<bool> CreateLevelAsync(Level level)
    {
        var buildingId = await GetBuildingId(
            level.UniversityName,
            level.CampusName,
            level.SiteName,
            level.BuildingAcronym);
        level.BuildingId = buildingId;
        return await _levelRepository.CreateLevelAsync(level);
    }

    public async Task<bool> DeleteLevelAsync(Level level)
    {
        var buildingId = await GetBuildingId(
            level.UniversityName,
            level.CampusName,
            level.SiteName,
            level.BuildingAcronym);
        level.BuildingId = buildingId;
        return await _levelRepository.DeleteLevelAsync(level);
    }

    public Task<Level> GetLevelByIdAsync(Guid id)
    {
        return _levelRepository.GetLevelByIdAsync(id);
    }

    public async Task<bool> UpdateLevelAsync(Level level)
    {
        var buildingId = await GetBuildingId(
            level.UniversityName,
            level.CampusName,
            level.SiteName,
            level.BuildingAcronym);
        level.BuildingId = buildingId;
        return await _levelRepository.UpdateLevelAsync(level);
    }

    private async Task<GuidValueObject> GetBuildingId(
        LongName universityName,
        LongName campusName,
        MediumName siteName,
        ShortName buildingAcronym)
    {
        var result = await _buildingRepository
            .GetBuildingIdAsync(
            universityName, 
            campusName, 
            siteName, 
            buildingAcronym);
        return GuidValueObject.Create(result);
    }
}
