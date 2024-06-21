using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Repositories;

namespace UCR.ECCI.PI.ThemePark_UCR.Application.LearningComponents.Services;

public class WhiteboardService(IWhiteboardRepository whiteboardRepository) : IWhiteboardService
{

    private readonly IWhiteboardRepository whiteboardRepository = whiteboardRepository;

    public Task<bool> CreateWhiteboardsAsync(Whiteboard whiteboard)
    {
        return whiteboardRepository.CreateWhiteboardAsync(whiteboard);
    }

    public Task<IEnumerable<Whiteboard>> GetWhiteboardsAsync()
    {
        return whiteboardRepository.GetWhiteboardsAsync();
    }

    public Task<bool> ModifyWhiteboardAsync(Whiteboard whiteboard)
    {
        return whiteboardRepository.ModifyWhiteboardAsync(whiteboard);
    }
    public Task<bool> DeleteWhiteboardAsync(Whiteboard whiteboard)
    {
        return whiteboardRepository.DeleteWhiteboardAsync(whiteboard);
    }
}
