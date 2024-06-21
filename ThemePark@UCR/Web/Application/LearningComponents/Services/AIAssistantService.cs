using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Repositories;

namespace UCR.ECCI.PI.ThemePark_UCR.Application.LearningComponents.Services;

public class AIAssistantService(IAIAssistantRepository AIAssistantRepository) : IAIAssistantService
{

    private readonly IAIAssistantRepository _AIAssistantRepository = AIAssistantRepository;

    public Task<bool> CreateAIAssistantsAsync(AIAssistant aIAssistant)
    {
        return _AIAssistantRepository.CreateAIAssistantAsync(aIAssistant);
    }

    public Task<IEnumerable<AIAssistant>> GetAIAssistantsAsync()
    {
        return _AIAssistantRepository.GetAIAssistantAsync();
    }

    public Task<bool> ModifyAIAssistantAsync(AIAssistant AIAssistant)
    {
        return _AIAssistantRepository.ModifyAIAssistantAsync(AIAssistant);
    }

    public Task<bool> DeleteAIAssistantAsync(AIAssistant aIAssistant)
    {
        return _AIAssistantRepository.DeleteAIAssistantAsync(aIAssistant);
    }
}
