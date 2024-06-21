using UCR.ECCI.PI.ThemePark_UCR.Application.LearningSpace.Services.Interfaces;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Repositories;

namespace UCR.ECCI.PI.ThemePark_UCR.Application.LearningSpace.Services.Classes;

/// <summary>
/// Class that defines contract with IAccess Point Services
/// </summary>
public class AccessPointService : IAccessPointService
{

    /// <summary>
    /// Instance to make request in database
    /// </summary>
    private readonly IAccessPointRepository _accessPointRepository;

    /// <summary>
    /// Primary constructor
    /// </summary>
    /// <param name="accessPointRepository"></param>
    public AccessPointService(IAccessPointRepository accessPointRepository)
    {
        _accessPointRepository = accessPointRepository;
    }

    /// <summary>
    /// Service that create a new access point in database
    /// </summary>
    /// <param name="accessPoint">New AccessPoint instance desired to create</param>
    /// <returns>A Task bool with result of operation</returns>
    public async Task<bool> CreateAccessPointAsync(AccessPoint accessPoint)
    {
        return await _accessPointRepository.CreateAccessPointAsync(accessPoint);
    }

    /// <summary>
    /// Service that delete an access point from database
    /// </summary>
    /// <param name="inputGuid"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<bool> DeleteAccessPointAsync(GuidWrapper inputGuid)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Service that returns all access point from database
    /// </summary>
    /// <returns>A list with all AccessPoint available</returns
    public async Task<IEnumerable<AccessPoint>> GetAccessPointAsync()
    {
        return await _accessPointRepository.GetAccessPointAsync();
    }

    public async Task<IEnumerable<AccessPoint>> GetAccessPointsFromLevelAsync(GuidWrapper id)
    {
        return await _accessPointRepository.GetAccessPointsFromLevelAsync(id);
    }

    /// <summary>
    /// Service that allow to modify an already existing access point
    /// </summary>
    /// <param name="accessPoint">AccessPoint instance desired to change</param>
    /// <returns>A Task bool with result of operation</returns>
    public async Task<bool> ModifyAccessPointAsync(AccessPoint accessPoint)
    {
        return await _accessPointRepository.ModifyAccessPointAsync(accessPoint);
    }
}

