using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Dtos;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Entities;

namespace UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.LearningComponents.Services;

public interface IAIAssistantService
{
    public Task<bool> CreateAIAssistantsAsync(AIAssistant aIAssistant);
    public Task<IEnumerable<AIAssistant>> GetAIAssistantsAsync();
    public Task<bool> ModifyAIAssistantAsync(AIAssistant aIAssistant);
    public Task<bool> DeleteAIAssistantAsync(AIAssistant aIAssistant);
}
