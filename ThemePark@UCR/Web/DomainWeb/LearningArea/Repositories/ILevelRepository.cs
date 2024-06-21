using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Repositories;

/// US: PIIB2401G1-93 CAD-CRL-02 List building levels
/// Task: PIIB2401G1-314 Create Level domain entity and repository
/// Christopher Viquez Aguilar
/// Daniel Van der Laat Velez
/// Francisco Ulate
public interface ILevelRepository
{
    public Task<IEnumerable<Level>> GetLevelsFromBuildingAsync(LongName UniversityName, LongName CampusName, MediumName SiteName, ShortName BuildingAcronym);

    public Task<bool> CreateLevelAsync(Level level);

    public Task<bool> UpdateLevelAsync(Level level);

    public Task<bool> DeleteLevelAsync(Guid id);

    public Task<Level> GetLevelByIdAsync(Guid id);
}
