using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Dtos;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Entities;

namespace UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.LearningComponents.Services;

public interface IWhiteboardService
{
    public Task<bool> CreateWhiteboardsAsync(Whiteboard whiteboard);
    public Task<IEnumerable<Whiteboard>> GetWhiteboardsAsync();
    public Task<bool> ModifyWhiteboardAsync(Whiteboard whiteboard);
    public Task<bool> DeleteWhiteboardAsync(Whiteboard whiteboard);
}
