

using Microsoft.EntityFrameworkCore;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Dtos;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.LearningComponets.Dtos;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.LearningComponets.Repositories;

public class ApiClientAIAssistantRepository : IAIAssistantRepository
{
    private readonly Client.ApiClientKiota _apiClient;

    public ApiClientAIAssistantRepository(Client.ApiClientKiota apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<bool> CreateAIAssistantAsync(AIAssistant aIAssistant)
    {
        try
        {
            var inputLearningComponent = KiotaAIAssistantDtoMapper.FromEntitiy(aIAssistant);
            
            try
            {
                var output = await _apiClient.CreateAiassistant.PostAsync(inputLearningComponent);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error with request {ex}");
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Could not map AI Assistant {ex}");
            Console.WriteLine(ex.Message);
            return false;
        }
        return true;
    }

    public async Task<IEnumerable<AIAssistant>> GetAIAssistantAsync()
    {
        try
        {
            var response = await _apiClient.ListAiassistants.GetAsync();
            try
            {
                var iaAssistants = response.AiAssistantsDto?.Select(KiotaAIAssistantDtoMapper.ToEntity) ?? throw new NullReferenceException(); ;
                return iaAssistants;
            }catch(Exception ex)
            {
                Console.WriteLine($"Error trying to Map AIAssistant {ex}");
                Console.WriteLine(ex.Message);
            }
        }catch (Exception ex)
        {
            Console.WriteLine($"Error with request {ex}");
            Console.WriteLine(ex.Message);
        }
        return Enumerable.Empty<AIAssistant>();
    }

    public async Task<bool> ModifyAIAssistantAsync(AIAssistant aIAssistant)
    {
        try
        {
            var inputLearningComponent = KiotaAIAssistantDtoMapper.FromEntitiy(aIAssistant);

            try
            {
                var output = await _apiClient.ModifyAiassistant.PostAsync(inputLearningComponent);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error with request {ex}");
                Console.WriteLine(ex.Message);
                return false;
            }

        }
        catch (Exception ex)
        {

            Console.WriteLine($"Could not map AI Assistant {ex}");
            Console.WriteLine(ex.Message);
            return false;
        }
        return true;

    }

    public async Task<bool> DeleteAIAssistantAsync(AIAssistant aIAssistant)
    {
        try
        {
            var aIAssistantEntity = KiotaAIAssistantDtoMapper.FromEntitiy(aIAssistant);
            
              var response =   await _apiClient.DeleteAiassistant.DeleteAsync(aIAssistantEntity);
              return true;

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error trying to delete AIAssistant API{ex}");
            Console.WriteLine(ex.Message);
            return false;
        }
    }
}