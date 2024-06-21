using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.LearningArea.Services;


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

    public Task<bool> CreateLevelAsync(Level level)
    {
        var result = _levelRepository.CreateLevelAsync(level);
        return result;
    }

    public async Task<bool> DeleteLevelAsync(Guid id)
    {
        return await _levelRepository.DeleteLevelAsync(id);
    }

    public Task<Level> GetLevelByIdAsync(Guid id)
    {
        return _levelRepository.GetLevelByIdAsync(id);
    }

    public Task<bool> UpdateLevelAsync(Level level)
    {
        return _levelRepository.UpdateLevelAsync(level);
    }
}
