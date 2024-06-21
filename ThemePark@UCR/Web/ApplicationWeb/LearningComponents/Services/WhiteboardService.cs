using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Dtos;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Repositories;

namespace UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.LearningComponents.Services;

public class WhiteboardService : IWhiteboardService
{

    private readonly IWhiteboardRepository whiteboardRepository;

    public WhiteboardService (IWhiteboardRepository whiteboardRepository)
    {
        this.whiteboardRepository = whiteboardRepository;
    }

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
