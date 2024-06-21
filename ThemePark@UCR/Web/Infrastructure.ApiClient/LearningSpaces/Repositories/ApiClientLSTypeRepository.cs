using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.LearningSpace.Dtos;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.LearningSpaces.Dtos;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.LearningSpaces.Dtos;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.LearningSpace.Repositories;


/// <summary>
/// Repository implementation for interacting with learning space data through an API client.
/// </summary>
public class ApiClientLSTypeRepository : IlearningSpaceTypeRepository
{
    private readonly ApiClientKiota _apiClient;

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiClientLearningSpaceRepository"/> class with the specified API client.
    /// </summary>
    /// <param name="apiClient">The API client used to communicate with the backend.</param>
    public ApiClientLSTypeRepository(ApiClientKiota apiClient)
    {
        _apiClient = apiClient;
    }

    /// <summary>
    /// This method allow to create a learning space an show it in database
    /// </summary>
    /// <param name="learningSpace">Input learning space requiered to add</param>
    /// <returns>Task carrying a bool with result of operation</returns>
    public async Task<IEnumerable<LSType>> GetLSTypesAsync()
    {
        // Try to map from DomainWeb.LearningSpace to Models.LearningSpace
        // Try to use apiClient GetLearningSpace method
        try
        {
            var getLearningSpaceTypeDtos = await _apiClient.ListLearningspacetypes.GetAsync();

            // Try converting from Models.LearningSpace to DomainWeb.LearningSpace
            try
            {
                var learningSpaceTypeEntitites = getLearningSpaceTypeDtos?.Select(LsTypeDtoMapper.ToEntity)
                    ?? throw new NullReferenceException();
                return learningSpaceTypeEntitites;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error trying to map LearningSpace from Models to Domain {ex}");
                Console.WriteLine(ex.Message);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error with requestBuilder {ex}");
            Console.WriteLine(ex.Message);
        }
        return Enumerable.Empty<DomainWeb.LearningSpace.Entities.LSType>();

    }

    /// <summary>
    /// PostCreateLSTypeAsync method allow to create a new learning space type in database
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public async Task<bool> PostCreateLSTypeAsync(LSType type)
    {
        try
        {
            var inputLearningSpaceType = KiotaLsTypeDtoMapper.ToEntity(type);
            // Try to use apiClient CreateLearningSpace method
            try
            {
                var output = await _apiClient.CreateLearningspaceType.PostAsync(inputLearningSpaceType);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error with RequestBuilder {ex}");
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error trying to map from Domain to Models {ex}");
            Console.WriteLine(ex.Message);
            return false;
        }

        return true;
    }

    /// <summary>
    /// PostDeleteLSTypeAsync method allow to delete a learning space type in database
    /// </summary>
    /// <param name="typeId"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<bool> PostDeleteLSTypeAsync(Guid typeId)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// PostUpdateLSTypeAsync method allow to update a learning space type in database
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public async Task<bool> PostUpdateLSTypeAsync(LSType type)
    {
        try
        {
            var inputLearningSpaceType = KiotaLsTypeDtoMapper.ToEntity(type);

            try
            {
                var output = await _apiClient.ModifyLearningspaceType.PostAsync(inputLearningSpaceType);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error with RequestBuilder {ex}");
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error trying to map from Domain to Models {ex}");
            Console.WriteLine(ex.Message);
            return false;
        }

        return true;
    }
}
