using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.LearningArea.Services;

public interface ILevelService
{
    public Task<IEnumerable<Level>> GetLevelsFromBuildingAsync(LongName UniversityName, LongName CampusName, MediumName SiteName, ShortName BuildingAcronym);

    public Task<bool> CreateLevelAsync(Level level);

    public Task<bool> UpdateLevelAsync(Level level);

    public Task<bool> DeleteLevelAsync(Guid id);

    public Task<Level> GetLevelByIdAsync(Guid id);
}
