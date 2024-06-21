using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Dtos;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Repositories;

namespace UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.LearningComponents.Services;

public class ProjectorService : IProjectorService
{

    private readonly IProjectorRepository _ProjectorRepository;

    public ProjectorService (IProjectorRepository projectorRepository)
    {
        this._ProjectorRepository = projectorRepository;
    }

    public Task<bool> CreateProjectorsAsync(Projector projector)
    {
        return _ProjectorRepository.CreateProjectorAsync(projector);
    }

    public Task<IEnumerable<Projector>> GetProjectorsAsync()
    {
        return _ProjectorRepository.GetProjectorsAsync();
    }

    public Task<bool> ModifyProjectorAsync(Projector projector)
    {
        return _ProjectorRepository.ModifyProjectorAsync(projector);
    }
    public Task<bool> DeleteProjectorAsync(Projector projector)
    {
        return _ProjectorRepository.DeleteProjectorAsync(projector);
    }
}
