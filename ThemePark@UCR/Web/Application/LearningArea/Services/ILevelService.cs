using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Application.LearningArea.Services;

public interface ILevelService
{
    public Task<IEnumerable<Level>> GetLevelsFromBuildingAsync(LongName UniversityName, LongName CampusName, MediumName SiteName, ShortName BuildingAcronym);

    public Task<bool> CreateLevelAsync(Level level);

    public Task<bool> UpdateLevelAsync(Level level);

    public Task<bool> DeleteLevelAsync(Level level);

    public Task<Level> GetLevelByIdAsync(Guid id);
}
