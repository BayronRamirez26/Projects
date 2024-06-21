

using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Dtos;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.LearningComponets.Dtos;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.LearningComponets.Repositories;

public class ApiClientInteractiveScreenRepository : IInteractiveScreenRepository
{
    private readonly Client.ApiClientKiota _apiClient;

    public ApiClientInteractiveScreenRepository(Client.ApiClientKiota apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<bool> CreateInteractiveScreenAsync(InteractiveScreen InteractiveScreen)
    {
        try
        {
            var inputLearningComponent = KiotaInteractiveScreenDtoMapper.FromEntitiy(InteractiveScreen);

            try
            {
                var output = await _apiClient.CreateInteractivescreen.PostAsync(inputLearningComponent);
                Console.WriteLine("-----------------------");
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
            Console.WriteLine($"Could not map InteractiveScreen {ex}");
            Console.WriteLine(ex.Message);
            return false;
        }
        return true;
    }

    public async Task<IEnumerable<InteractiveScreen>> GetInteractiveScreensAsync()
    {
        try
        {
            var response = await _apiClient.ListInteractivescreens.GetAsync();
            try
            {
                var iaAssistants = response.InteractiveScreenDtos?.Select(KiotaInteractiveScreenDtoMapper.ToEntity) ?? throw new NullReferenceException(); ;
                return iaAssistants;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error trying to Map InteractiveScreen {ex}");
                Console.WriteLine(ex.Message);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error with request {ex}");
            Console.WriteLine(ex.Message);
        }
        return Enumerable.Empty<InteractiveScreen>();
    }

    public async Task<bool> ModifyInteractiveScreenAsync(InteractiveScreen InteractiveScreen)
    {
        try
        {
            var inputLearningComponent = KiotaInteractiveScreenDtoMapper.FromEntitiy(InteractiveScreen);

            try
            {
                var output = await _apiClient.ModifyInteractivescreen.PostAsync(inputLearningComponent);
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

            Console.WriteLine($"Could not map InteractiveScrens {ex}");
            Console.WriteLine(ex.Message);
            return false;
        }
        return true;

    }

    public async Task<bool> DeleteInteractiveScreenAsync(InteractiveScreen InteractiveScreen)
    {
        try
        {
            var InteractiveScreenEntity = KiotaInteractiveScreenDtoMapper.FromEntitiy(InteractiveScreen);

            var response = await _apiClient.DeleteInteractivescreen.DeleteAsync(InteractiveScreenEntity);
            return true;

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error trying to delete InteractiveScreen API{ex}");
            Console.WriteLine(ex.Message);
            return false;
        }
    }

}