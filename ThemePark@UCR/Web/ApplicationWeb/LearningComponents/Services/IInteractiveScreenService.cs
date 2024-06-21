using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Dtos;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Entities;

namespace UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.LearningComponents.Services;

public interface IInteractiveScreenService
{
    public Task<bool> CreateInteractiveScreensAsync(InteractiveScreen interactiveScreen);
    public Task<IEnumerable<InteractiveScreen>> GetInteractiveScreensAsync();
    public Task<bool> ModifyInteractiveScreenAsync(InteractiveScreen interactiveScreen);
    public Task<bool> DeleteInteractiveScreenAsync(InteractiveScreen interactiveScreen);
}
