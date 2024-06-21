using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities;

namespace UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.LearningSpace.Services.Interfaces;

public interface ILsTypeServices
{

    /// <summary>
    /// Get all learning space types
    /// </summary>
    /// <returns></returns>
    public Task<IEnumerable<LSType>> GetLSTypesAsync();

    /// <summary>
    /// Create a learning space type by id
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public Task<bool> PostCreateLSTypeAsync(LSType type);

    /// <summary>
    /// Update a learning space type by id
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public Task<bool> PostUpdateLSTypeAsync(LSType type);

    /// <summary>
    /// delete a learning space type by id
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public Task<bool> PostDeleteLSTypeAsync(Guid type);
}
