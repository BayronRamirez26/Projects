using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.LearningSpace.Dtos;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.LearningSpaces.Dtos;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.LearningSpaces.Repositories;

/// <summary>
/// Interface with an instance of API Client that allows to make request to database
/// </summary>
internal class ApiClientAccessPointRepository : IAccessPointRepository
{
    private readonly ApiClientKiota _apiClient;

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiClientLearningSpaceRepository"/> class with the specified API client.
    /// </summary>
    /// <param name="apiClient">The API client used to communicate with the backend.</param>
    public ApiClientAccessPointRepository(ApiClientKiota apiClient)
    {
        _apiClient = apiClient;
    }

    /// <summary>
    /// Service that create a new access point in database
    /// </summary>
    /// <param name="accessPoint">New AccessPoint instance desired to create</param>
    /// <returns>A Task bool with result of operation</returns>
    public async Task<bool> CreateAccessPointAsync(AccessPoint accessPoint)
    {
        // Try to make convertion from Domain.AccessPoint to Models.AccessPoint
        try
        {
            var input = KiotaAccessPointDtoMapper.ToEntity(accessPoint);

            // Try to use API Client CreateAccessPoint
            try
            {
                var output = await _apiClient.CreateAccessPoint.PostAsync(input);

            } catch (Exception ex) {
                Console.WriteLine($"Error with requestBuilder {ex}");
                Console.WriteLine(ex.Message);
                return false;
            }

        } catch (Exception ex) {
            Console.WriteLine($"Error trying to map AccessPoint from Domain to Models {ex}");
            Console.WriteLine(ex.Message);
            return false;
        }

        return true;
    }

    /// <summary>
    /// Service that returns all access point from database
    /// </summary>
    /// <returns>A list with all AccessPoint available</returns>
    public async Task<IEnumerable<AccessPoint>> GetAccessPointAsync()
    {
        //// Try to use apiClient GetLearningSpace method
        try
        {
            var getAccessPointDtos = await _apiClient.ListAccessPoints.GetAsync();

            // Try converting from Models.AccessPoint to Domain.AccessPoint
            try
            {
                var accessPointEntitites = getAccessPointDtos?.Select(AccessPointDtoMapper.ToEntity)
                    ?? throw new NullReferenceException();
                return accessPointEntitites;
            }
            catch (Exception ex) {
                Console.WriteLine($"Error trying to map AccessPoint from Models to Domain {ex}");
                Console.WriteLine(ex.Message);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error with requestBuilder {ex}");
            Console.WriteLine(ex.Message);
        }
        return Enumerable.Empty<AccessPoint>();

    }

    /// <summary>
    /// Service that allow to modify an already existing access point
    /// </summary>
    /// <param name="accessPoint">AccessPoint instance desired to change</param>
    /// <returns>A Task bool with result of operation</returns>
    public async Task<bool> ModifyAccessPointAsync(AccessPoint accessPoint)
    {
        // Try to make convertion from Domain.AccessPoint to Models.AccessPoint
        try
        {
            var input = KiotaAccessPointDtoMapper.ToEntity(accessPoint);

            // Try to use API Client CreateAccessPoint
            try
            {
                var output = await _apiClient.ModifyAccessPoint.PostAsync(input);

            }
            catch (Exception ex) {
                Console.WriteLine($"Error with requestBuilder {ex}");
                Console.WriteLine(ex.Message);
                return false;
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error trying to map AccessPoint from Domain to Models {ex}");
            Console.WriteLine(ex.Message);
            return false;
        }

        return true;
    }

    /// <summary>
    /// Service that delete an existing access point on database
    /// </summary>
    /// <param name="accessPoint">AccessPoint instance desired to delete</param>
    /// <returns>A Task bool with result operation</returns>
    public Task<bool> DeleteAccessPointAsync(AccessPoint accessPoint)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Service that delete an existing access point on database
    /// </summary>
    /// <param name="guid"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<bool> DeleteAccessPointAsync(GuidWrapper guid)
    {
        throw new NotImplementedException();
    }
}
