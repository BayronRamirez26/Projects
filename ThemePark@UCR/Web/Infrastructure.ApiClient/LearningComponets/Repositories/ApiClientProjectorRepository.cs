

using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Dtos;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.LearningComponets.Dtos;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.LearningComponets.Repositories;

public class ApiClientProjectorRepositoy : IProjectorRepository
{
    private readonly Client.ApiClientKiota _apiClient;

    public ApiClientProjectorRepositoy(Client.ApiClientKiota apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<bool> CreateProjectorAsync(Projector Projector)
    {
        try
        {
            var inputLearningComponent = KiotaProjectorDtoMapper.FromEntitiy(Projector);

            try
            {
                var output = await _apiClient.CreateProjector.PostAsync(inputLearningComponent);
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
            Console.WriteLine($"Could not create projector {ex}");
            Console.WriteLine(ex.Message);
            return false;
        }
        return true;
    }

    public async Task<IEnumerable<Projector>> GetProjectorsAsync()
    {
        try
        {
            var response = await _apiClient.ListProjectors.GetAsync();
            try
            {
                var iaAssistants = response.ProjectorsDto?.Select(KiotaProjectorDtoMapper.ToEntity) ?? throw new NullReferenceException(); ;
                return iaAssistants;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error trying to Map Projector {ex}");
                Console.WriteLine(ex.Message);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error with request {ex}");
            Console.WriteLine(ex.Message);
        }
        return Enumerable.Empty<Projector>();
    }

    public async Task<bool> ModifyProjectorAsync(Projector Projector)
    {
        try
        {
            var inputLearningComponent = KiotaProjectorDtoMapper.FromEntitiy(Projector);

            try
            {
                var output = await _apiClient.ModifyProjector.PostAsync(inputLearningComponent);
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

            Console.WriteLine($"Could not modify Projector {ex}");
            Console.WriteLine(ex.Message);
            return false;
        }
        return true;

    }

    public async Task<bool> DeleteProjectorAsync(Projector Projector)
    {
        try
        {
            var ProjectorEntity = KiotaProjectorDtoMapper.FromEntitiy(Projector);

            var response = await _apiClient.DeleteProjector.DeleteAsync(ProjectorEntity);
            return true;

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error trying to delete Projector API{ex}");
            Console.WriteLine(ex.Message);
            return false;
        }
    }

}