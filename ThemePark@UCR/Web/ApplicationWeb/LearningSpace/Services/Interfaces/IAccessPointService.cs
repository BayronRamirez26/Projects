using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities.Wrappers;


namespace UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.LearningSpace.Services.Interfaces;

/// <summary>
/// Interface with all services of AccesPoint
/// </summary>
public interface IAccessPointService
{
    /// <summary>
    /// Service that create a new access point in database
    /// </summary>
    /// <param name="accessPoint">New AccessPoint instance desired to create</param>
    /// <returns>A Task bool with result of operation</returns>
    public Task<bool> CreateAccessPointAsync(AccessPoint accessPoint);

    /// <summary>
    /// Service that returns all access point from database
    /// </summary>
    /// <returns>A list with all AccessPoint available</returns>
    public Task<IEnumerable<AccessPoint>> GetAccessPointAsync();

    /// <summary>
    /// Service that allow to modify an already existing access point
    /// </summary>
    /// <param name="accessPoint">AccessPoint instance desired to change</param>
    /// <returns>A Task bool with result of operation</returns>
    public Task<bool> ModifyAccessPointAsync(AccessPoint accessPoint);

    /// <summary>
    /// Service that delete an existing access point on database
    /// </summary>
    /// <param name="accessPoint">AccessPoint instance desired to delete</param>
    /// <returns>A Task bool with result operation</returns>
    public Task<bool> DeleteAccessPointAsync(GuidWrapper inputGuid);
}

