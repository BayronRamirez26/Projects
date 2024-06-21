using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Dtos;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Entities;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Repositories;

public interface IAIAssistantRepository
{
    public Task<IEnumerable<AIAssistant>> GetAIAssistantAsync();
    public Task<bool>CreateAIAssistantAsync(AIAssistant aIAssistant);
    public Task<bool> ModifyAIAssistantAsync(AIAssistant aIAssistant);
    public Task<bool> DeleteAIAssistantAsync(AIAssistant aIAssistant);
}
