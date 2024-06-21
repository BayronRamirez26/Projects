using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Dtos;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Entities;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Repositories;

public interface IProjectorRepository
{
    public Task<IEnumerable<Projector>> GetProjectorsAsync();
    public Task<bool>CreateProjectorAsync(Projector projector);
    public Task<bool> ModifyProjectorAsync(Projector projector);
    public Task<bool> DeleteProjectorAsync(Projector projector);
}
