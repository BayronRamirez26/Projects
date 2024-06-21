using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Entities;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Repositories;

public interface IWhiteboardRepository
{
    public Task<IEnumerable<Whiteboard>> GetWhiteboardsAsync();
    public Task<bool>CreateWhiteboardAsync(Whiteboard whiteboard);
    public Task<bool> ModifyWhiteboardAsync(Whiteboard whiteboard);
    public Task<bool> DeleteWhiteboardAsync(Whiteboard whiteboard);
}
