using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Entities;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Repositories;

public interface IInteractiveScreenRepository
{
    public Task<IEnumerable<InteractiveScreen>> GetInteractiveScreensAsync();
    public Task<bool>CreateInteractiveScreenAsync(InteractiveScreen interactiveScreen);
    public Task<bool> ModifyInteractiveScreenAsync(InteractiveScreen interactiveScreen);
    public Task<bool> DeleteInteractiveScreenAsync(InteractiveScreen interactivinteractiveScreeneScreenDto);
}
