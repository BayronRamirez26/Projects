using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Repositories;

namespace UCR.ECCI.PI.ThemePark_UCR.Application.LearningComponents.Services;

public class InteractiveScreenService : IInteractiveScreenService
{

    private readonly IInteractiveScreenRepository _InteractiveScreenRepository;

    public InteractiveScreenService (IInteractiveScreenRepository InteractiveScreenRepository)
    {
        this._InteractiveScreenRepository = InteractiveScreenRepository;
    }

    public Task<bool> CreateInteractiveScreensAsync(InteractiveScreen interactiveScreen)
    {
        return _InteractiveScreenRepository.CreateInteractiveScreenAsync(interactiveScreen);
    }

    public Task<IEnumerable<InteractiveScreen>> GetInteractiveScreensAsync()
    {
        return _InteractiveScreenRepository.GetInteractiveScreensAsync();
    }

    public Task<bool> ModifyInteractiveScreenAsync(InteractiveScreen interactiveScreen)
    {
        return _InteractiveScreenRepository.ModifyInteractiveScreenAsync(interactiveScreen);
    }
    public Task<bool> DeleteInteractiveScreenAsync(InteractiveScreen interactiveScreen)
    {
        return _InteractiveScreenRepository.DeleteInteractiveScreenAsync(interactiveScreen);
    }
}
