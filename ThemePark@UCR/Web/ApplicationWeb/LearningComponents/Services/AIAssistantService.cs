using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Dtos;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Repositories;

namespace UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.LearningComponents.Services;

public class AIAssistantService : IAIAssistantService
{

    private readonly IAIAssistantRepository _AIAssistantRepository;

    public AIAssistantService (IAIAssistantRepository AIAssistantRepository)
    {
        this._AIAssistantRepository = AIAssistantRepository;
    }

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
