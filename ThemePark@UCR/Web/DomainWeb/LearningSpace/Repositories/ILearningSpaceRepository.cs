using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Repositories;

/// <summary>
/// Connects data with SqlLearningSpaceRepository to convert service functions 
/// into sql functionalities
/// </summary>
public interface ILearningSpaceRepository
{
    /// <summary>
    /// This method allow to create a learning space an show it in database
    /// </summary>
    /// <param name="learningSpace">Input learning space requiered to add</param>
    /// <returns>Task carrying a bool with result of operation</returns>
    public Task<bool> CreateLearningSpaceAsync(LearningSpaces learningSpace);

    /// <summary>
    /// This method return all learning space available in database
    /// </summary>
    /// <returns>An enumerable with all learning spaces available</returns>
    public Task<IEnumerable<LearningSpaces>> GetLearningSpaceAsync();

    /// <summary>
    /// This method allow to update the information about a learning space
    /// </summary>
    /// <param name="learningSpace">Input learning space requiered to add</param>
    /// <returns>Task carrying a bool with result of operation</returns>
    public Task<bool> ModifyLearningSpaceAsync(LearningSpaces learningSpace);

    /// <summary>
    /// This method allow to delete a learning space in database
    /// </summary>
    /// <param name="learningSpace">Input learning space requiered to delete</param>
    /// <returns>Task carrying a bool with result of operation</returns>
    public Task<bool> DeleteLearningSpaceAsync(GuidWrapper id);

    /// <summary>
    /// This method allow to get a LearningSpace from an ID given
    /// </summary>
    /// <param name="id">Input Guid requiered to search</param>
    /// <returns>Task<LearningSpace> with the result of operation</LearningSpace></returns>
    public Task<LearningSpaces?> GetLearningSpaceFromIdAsync(GuidWrapper id);

    /// <summary>
    /// This method allow to get a LSType from an ID given
    /// </summary>
    /// <param name="id">Input Guid requiered to search</param>
    /// <returns>Task<LSType> with the result of operation</LSType></returns>
    public Task<LSType?> GetLSTypeFromIdAsync(GuidWrapper id);

    /// <summary>
    /// Get all learning spaces by lsTypeId
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<IEnumerable<LearningSpaces>> GetLearningSpacesByLSTypeIdAsync(GuidWrapper id);

    /// <summary>
    /// This method allows to get all projectors from a LearningSpace
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<IEnumerable<Projector>> GetProjectorsOfALearningSpacesAsync(GuidWrapper id);


}
