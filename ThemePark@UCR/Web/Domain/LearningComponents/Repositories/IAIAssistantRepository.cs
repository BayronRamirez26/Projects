using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Entities;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Repositories;

public interface IAIAssistantRepository
{
    public Task<IEnumerable<AIAssistant>> GetAIAssistantAsync();
    public Task<bool>CreateAIAssistantAsync(AIAssistant aIAssistant);
    public Task<bool> ModifyAIAssistantAsync(AIAssistant aIAssistant);
    public Task<bool> DeleteAIAssistantAsync(AIAssistant aIAssistant);
}
