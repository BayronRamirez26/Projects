using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities.Wrappers;

namespace UCR.ECCI.PI.ThemePark_UCR.Application.LearningSpace.Services.Interfaces;

/// <summary>
/// Defines sevice functions for managing learningSpaces entity.
/// </summary>
public interface ILearningSpaceService
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
    // public Task<bool> DeleteLearningSpaceAsync(LearningSpaces learningSpace);
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
    /// Get all Proyectors by learning spaces
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<IEnumerable<Projector>> GetProjectorsOfALearningSpacesAsync(GuidWrapper id);
    /// <summary>
    /// Get all Whiteboards by learning spaces
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<IEnumerable<Whiteboard>> GetWhiteboardOfALearningSpacesAsync(GuidWrapper id);
    /// <summary>
    /// Get all InteractiveScreens by learning spaces
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<IEnumerable<InteractiveScreen>> GetInteractiveScreenOfALearningSpacesAsync(GuidWrapper id);

    /// <summary>
    /// Get all AccessPoints by learning spaces
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<IEnumerable<AccessPoint>> GetAccessPointsOfALearningSpacesAsync(GuidWrapper id);

}
