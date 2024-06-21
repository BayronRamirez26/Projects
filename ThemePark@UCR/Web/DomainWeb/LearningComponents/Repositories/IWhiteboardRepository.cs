using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Entities;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Repositories;

public interface IWhiteboardRepository
{
    public Task<IEnumerable<Whiteboard>> GetWhiteboardsAsync();
    public Task<bool>CreateWhiteboardAsync(Whiteboard whiteboardDto);
    public Task<bool> ModifyWhiteboardAsync(Whiteboard whiteboardDto);
    public Task<bool> DeleteWhiteboardAsync(Whiteboard whiteboardDto);
}
