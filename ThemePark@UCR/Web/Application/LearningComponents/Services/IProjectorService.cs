using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Dtos;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Entities;

namespace UCR.ECCI.PI.ThemePark_UCR.Application.LearningComponents.Services;

public interface IProjectorService
{
    public Task<bool> CreateProjectorsAsync(Projector projector);
    public Task<IEnumerable<Projector>> GetProjectorsAsync();
    public Task<bool> ModifyProjectorAsync(Projector projector);
    public Task<bool> DeleteProjectorAsync(Projector projector);
}
