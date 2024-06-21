using Microsoft.Kiota.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.LearningSpace.Dtos;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.LearningSpaces.Dtos;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Models;
using static UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.DeleteLearningSpace.DeleteLearningSpaceRequestBuilder;
using static UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.GetLearningSpaceById.GetLearningSpaceByIdRequestBuilder;
using static UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.GetLearningSpaceTypeById.GetLearningSpaceTypeByIdRequestBuilder;
using static UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.GetLearningSpaceTypeByLstypeid.GetLearningSpaceTypeByLstypeidRequestBuilder;


namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.LearningSpace.Repositories;

/// <summary>
/// Repository implementation for interacting with learning space data through an API client.
/// </summary>
public class ApiClientLearningSpaceRepository : ILearningSpaceRepository
{


    private readonly ApiClientKiota _apiClient;

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiClientLearningSpaceRepository"/> class with the specified API client.
    /// </summary>
    /// <param name="apiClient">The API client used to communicate with the backend.</param>
    public ApiClientLearningSpaceRepository(ApiClientKiota apiClient)
    {
        _apiClient = apiClient;
    }

    /// <summary>
    /// This method allow to create a learning space an show it in database
    /// </summary>
    /// <param name="learningSpace">Input learning space requiered to add</param>
    /// <returns>Task carrying a bool with result of operation</returns>
    public async Task<bool> CreateLearningSpaceAsync(DomainWeb.LearningSpace.Entities.LearningSpaces learningSpace)
    {
        // Try to map from DomainWeb.LearningSpace to Models.LearningSpace
        try
        {
            var inputLearningSpace = KiotaLearningSpaceDtoMapper.ToEntity(learningSpace);
            
            // Try to use apiClient CreateLearningSpace method
            try
            {
                Console.WriteLine("Entro en el try");
                var output = await _apiClient.CreateLearningspaces.PostAsync(inputLearningSpace);
                Console.WriteLine("-----------------------");
            } catch (Exception ex) {
                Console.WriteLine($"Error with RequestBuilder {ex}");
                Console.WriteLine(ex.Message);
                return false;
            }
        } catch (Exception ex) {
            Console.WriteLine($"Error trying to map from Domain to Models {ex}");
            Console.WriteLine(ex.Message);
            return false;
        }

        return true;
    }



    /// <summary>
    /// This method return all learning space available in database
    /// </summary>
    /// <returns>An enumerable with all learning spaces available</returns>
    /// <exception cref="NullReferenceException">Thorw exception if there's a null reference</exception>
    public async Task<IEnumerable<DomainWeb.LearningSpace.Entities.LearningSpaces>> GetLearningSpaceAsync()
    {
        //// Try to use apiClient GetLearningSpace method
        try
        {
            var getLearningSpaceDtos = await _apiClient.ListLearningspaces.GetAsync();

            // Try converting from Models.LearningSpace to DomainWeb.LearningSpace
            try
            {
                var learningSpaceEntitites = getLearningSpaceDtos?.Select(LearningSpaceDtoMapper.ToEntity)
                    ?? throw new NullReferenceException();
                return learningSpaceEntitites;
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
        return Enumerable.Empty<DomainWeb.LearningSpace.Entities.LearningSpaces>();

    }

    /// <summary>
    /// This method allow to update the information about a learning space
    /// </summary>
    /// <param name="learningSpace">Input learning space requiered to add</param>
    /// <returns>Task carrying a bool with result of operation</returns>
    public async Task<bool> ModifyLearningSpaceAsync(DomainWeb.LearningSpace.Entities.LearningSpaces learningSpace)
    {
        //// Try converting from DomainWeb.LearningSpace to Models.LearningSpace
        try
        {
            var inputLearningSpace = KiotaLearningSpaceDtoMapper.ToEntity(learningSpace);

            // to use apiClient ModifyLearningSpace method
            try
            {
                var output = await _apiClient.ModifyLearningSpace.PostAsync(inputLearningSpace);
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
    /// Delete a learning space from the database
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<bool> DeleteLearningSpaceAsync(DomainWeb.LearningSpace.Entities.Wrappers.GuidWrapper id)
    {
        try
        {
            var requestConfiguration = new Action<RequestConfiguration<DeleteLearningSpaceRequestBuilderDeleteQueryParameters>>(config =>
            {
                config.QueryParameters = new DeleteLearningSpaceRequestBuilderDeleteQueryParameters
                {
                    InputGuid = id.Value
                };
            });
            var output = await _apiClient.DeleteLearningSpace.DeleteAsync(requestConfiguration);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error trying to map from Domain to Models {ex}");
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    /// <summary>
    /// Get a learning space from the database
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<DomainWeb.LearningSpace.Entities.LearningSpaces?> GetLearningSpaceFromIdAsync(DomainWeb.LearningSpace.Entities.Wrappers.GuidWrapper id)
    {
        // Try making convertion from GuidWrapper to Guid
        try
        {
            var requestConfiguration = new Action<RequestConfiguration<GetLearningSpaceByIdRequestBuilderPostQueryParameters>>(config =>
            {
                config.QueryParameters = new GetLearningSpaceByIdRequestBuilderPostQueryParameters
                {
                    InputId = id.Value
                };
            });

            // Try using GetLearningSpaceById from API Client
            try
            {
                var output = await _apiClient.GetLearningSpaceById.PostAsync(requestConfiguration);
                return LearningSpaceDtoMapper.ToEntity(output);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error with Request Builder {ex}");
                Console.WriteLine(ex.Message);
                return null;
            }
        } catch (Exception ex)
        {
            Console.WriteLine($"Error trying to map from GuidWrapper to Guid {ex}");
            Console.WriteLine(ex.Message);
            return null;
        }


        
    }

    /// <summary>
    /// Get the learning space type from the database
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<DomainWeb.LearningSpace.Entities.LSType?> GetLSTypeFromIdAsync(DomainWeb.LearningSpace.Entities.Wrappers.GuidWrapper id)
    {
        try
        {
            var requestConfiguration = new Action<RequestConfiguration<GetLearningSpaceTypeByIdRequestBuilderPostQueryParameters>>(config =>
            {
                config.QueryParameters = new GetLearningSpaceTypeByIdRequestBuilderPostQueryParameters
                {
                    InputId = id.Value
                };
            });

            try
            {
                var output = await _apiClient.GetLearningSpaceTypeById.PostAsync(requestConfiguration);
                return LsTypeDtoMapper.ToEntity(output);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error with Request Builder {ex}");
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error trying to map from GuidWrapper to Guid {ex}");
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    /// <summary>
    /// Get the learning spaces by the learning space type id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"></exception>
    public async Task<IEnumerable<DomainWeb.LearningSpace.Entities.LearningSpaces>> GetLearningSpacesByLSTypeIdAsync(DomainWeb.LearningSpace.Entities.Wrappers.GuidWrapper id)
    {
        try
        {
            var requestConfiguration = new Action<RequestConfiguration<GetLearningSpaceTypeByLstypeidRequestBuilderPostQueryParameters>>(config =>
            {
                config.QueryParameters = new GetLearningSpaceTypeByLstypeidRequestBuilderPostQueryParameters
                {
                    InputId = id.Value
                };
            });

            try
            {
                var getLearningSpaceDtos = await _apiClient.GetLearningSpaceTypeByLstypeid.PostAsync(requestConfiguration);
                var learningSpaceEntitites = getLearningSpaceDtos?.Select(LearningSpaceDtoMapper.ToEntity)
                    ?? throw new NullReferenceException();
                return learningSpaceEntitites;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error with Request Builder {ex}");
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error trying to map from GuidWrapper to Guid {ex}");
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public Task<IEnumerable<DomainWeb.LearningComponents.Entities.Projector>> GetProjectorsOfALearningSpacesAsync(DomainWeb.LearningSpace.Entities.Wrappers.GuidWrapper id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<DomainWeb.LearningComponents.Entities.Whiteboard>> GetWhiteboardOfALearningSpacesAsync(DomainWeb.LearningSpace.Entities.Wrappers.GuidWrapper id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<DomainWeb.LearningComponents.Entities.InteractiveScreen>> GetInteractiveScreenOfALearningSpacesAsync(DomainWeb.LearningSpace.Entities.Wrappers.GuidWrapper id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<DomainWeb.LearningSpace.Entities.AccessPoint>> GetAccessPointsOfALearningSpacesAsync(DomainWeb.LearningSpace.Entities.Wrappers.GuidWrapper id)
    {
        throw new NotImplementedException();
    }
}
