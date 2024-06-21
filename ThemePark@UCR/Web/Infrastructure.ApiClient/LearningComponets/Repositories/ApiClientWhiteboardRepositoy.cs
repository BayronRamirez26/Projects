using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Dtos;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.LearningComponets.Dtos;
using WhiteboardDto = UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Dtos.WhiteboardDto;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.LearningComponets.Repositories;

public class ApiClientWhiteboardRepositoy : IWhiteboardRepository
{
    private readonly Client.ApiClientKiota _apiClient;

    public ApiClientWhiteboardRepositoy(Client.ApiClientKiota apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<bool> CreateWhiteboardAsync(Whiteboard Whiteboard)
    {
        try
        {
            var inputLearningComponent = KiotaWhiteboardDtoMapper.FromEntitiy(Whiteboard);

            try
            {;
                var output = await _apiClient.CreateWhiteboard.PostAsync(inputLearningComponent);
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
            Console.WriteLine($"Could not create AI Assistant {ex}");
            Console.WriteLine(ex.Message);
            return false;
        }
        return true;
    }

    public async Task<IEnumerable<Whiteboard>> GetWhiteboardsAsync()
    {
        try
        {
            var response = await _apiClient.ListWhiteboards.GetAsync();
            try
            {
                var iaAssistants = response.Whiteboards?.Select(KiotaWhiteboardDtoMapper.ToEntity) ?? throw new NullReferenceException(); ;
                return iaAssistants;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error trying to Map Whiteboard {ex}");
                Console.WriteLine(ex.Message);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error with request {ex}");
            Console.WriteLine(ex.Message);
        }
        return Enumerable.Empty<Whiteboard>();
    }

    public async Task<bool> ModifyWhiteboardAsync(Whiteboard Whiteboard)
    {
        try
        {
            var inputLearningComponent = KiotaWhiteboardDtoMapper.FromEntitiy(Whiteboard);

            try
            {
                var output = await _apiClient.ModifyWhiteboards.PostAsync(inputLearningComponent);
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

            Console.WriteLine($"Could not modify Whiteboard {ex}");
            Console.WriteLine(ex.Message);
            return false;
        }
        return true;

    }

    public async Task<bool> DeleteWhiteboardAsync(Whiteboard Whiteboard)
    {
        try
        {
            var WhiteboardEntity = KiotaWhiteboardDtoMapper.FromEntitiy(Whiteboard);

            var response = await _apiClient.DeleteWhiteboards.DeleteAsync(WhiteboardEntity);
            return true;

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error trying to delete Whiteboard API{ex}");
            Console.WriteLine(ex.Message);
            return false;
        }
    }
}