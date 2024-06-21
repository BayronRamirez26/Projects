using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Dtos;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Entities;

namespace UCR.ECCI.PI.ThemePark_UCR.Application.LearningComponents.Services;

public interface IAIAssistantService
{
    public Task<bool> CreateAIAssistantsAsync(AIAssistant aIAssistant);
    public Task<IEnumerable<AIAssistant>> GetAIAssistantsAsync();
    public Task<bool> ModifyAIAssistantAsync(AIAssistant aIAssistant);
    public Task<bool> DeleteAIAssistantAsync(AIAssistant aIAssistant);
}
