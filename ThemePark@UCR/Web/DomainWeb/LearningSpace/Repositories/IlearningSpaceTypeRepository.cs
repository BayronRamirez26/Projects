using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Repositories;

/// <summary>
/// Interface with all services realted to types of LearningSpace
/// </summary>
public interface IlearningSpaceTypeRepository
{
    /// <summary>
    /// Method that allows to create a LearningSpaceType
    /// </summary>
    /// <param name="type">LSType neccesary to create</param>
    /// <returns>A bool with the result of the operation</returns>
    public Task<bool> PostCreateLSTypeAsync(LSType type);

    /// <summary>
    /// Method that get a list of all LearningSpaceTypes available
    /// </summary>
    /// <returns>A list with all LST found</returns>
    public Task<IEnumerable<LSType>> GetLSTypesAsync();

    /// <summary>
    /// Method that allows to update an existing Learning Space Type
    /// </summary>
    /// <param name="type">LSType desired to update</param>
    /// <returns>A bool with result of the operation</returns>
    public Task<bool> PostUpdateLSTypeAsync(LSType type);

    /// <summary>
    /// Method that allows to delete an existing Learning Space Type
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public Task<bool> PostDeleteLSTypeAsync(Guid type);
}
