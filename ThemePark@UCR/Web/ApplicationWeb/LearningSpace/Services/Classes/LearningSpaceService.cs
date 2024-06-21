using UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.LearningSpace.Services.Interfaces;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Repositories;

namespace UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.LearningSpace.Services.Classes;

/// <summary>
/// This class makes all requests to repository about learning spaces
/// </summary>
internal class LearningSpaceService : ILearningSpaceService
{
    /// <summary>
    /// Instance of ILearningSpaceRepository to connect with repository
    /// </summary>
    private readonly ILearningSpaceRepository _learningRepository;

    /// <summary>
    /// Primary constructor
    /// </summary>
    /// <param name="learningRepository">ILearningSpaceRepository instance neccesary</param>
    public LearningSpaceService(ILearningSpaceRepository learningRepository)
    {
        _learningRepository = learningRepository;
    }

    /// <summary>
    /// This method allow to create a learning space an show it in database
    /// </summary>
    /// <param name="learningSpace">Input learning space requiered to add</param>
    /// <returns>Task carrying a bool with result of operation</returns>
    public async Task<bool> CreateLearningSpaceAsync(LearningSpaces learningSpace)
    {
        return await _learningRepository.CreateLearningSpaceAsync(learningSpace); 
    }

    /// <summary>
    /// This method return all learning space available in database
    /// </summary>
    /// <returns>An enumerable with all learning spaces available</returns>
    public async Task<IEnumerable<LearningSpaces>> GetLearningSpaceAsync()
    {
        return await _learningRepository.GetLearningSpaceAsync();
    }

    /// <summary>
    /// This method allow to update the information about a learning space
    /// </summary>
    /// <param name="learningSpace">Input learning space requiered to add</param>
    /// <returns>Task carrying a bool with result of operation</returns>
    public async Task<bool> ModifyLearningSpaceAsync(LearningSpaces learningSpace)
    {
        return await _learningRepository.ModifyLearningSpaceAsync(learningSpace);
    }

    /// <summary>
    /// This method allow to delete a learning space in database
    /// </summary>
    /// <param name="learningSpace">Input learning space requiered to delete</param>
    /// <returns>Task carrying a bool with result of operation</returns>
    // public Task<bool> DeleteLearningSpaceAsync(LearningSpaces learningSpace);
    public async Task<bool> DeleteLearningSpaceAsync(GuidWrapper id)
    {
        return await _learningRepository.DeleteLearningSpaceAsync(id);
    }

    /// <summary>
    /// This method allow to get a LearningSpace from an ID given
    /// </summary>
    /// <param name="id">Input Guid requiered to search</param>
    /// <returns>Task<LearningSpace> with the result of operation</LearningSpace></returns>
    public async Task<LearningSpaces?> GetLearningSpaceFromIdAsync(GuidWrapper id)
    {
        return await _learningRepository.GetLearningSpaceFromIdAsync(id);
    }

    /// <summary>
    /// This method allow to get a LSType from an ID given
    /// </summary>
    /// <param name="id">Input Guid requiered to search</param>
    /// <returns>Task<LSType> with the result of operation</LSType></returns>
    public async Task<LSType?> GetLSTypeFromIdAsync(GuidWrapper id)
    {
        return await _learningRepository.GetLSTypeFromIdAsync(id);
    }

    /// <summary>
    /// This method allow to get a LearningSpace from an ID given
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<IEnumerable<LearningSpaces>> GetLearningSpacesByLSTypeIdAsync(GuidWrapper id)
    {
        return await _learningRepository.GetLearningSpacesByLSTypeIdAsync(id);
    }

    /// <summary>
    /// This method allows to get all projectors from a LearningSpace
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<IEnumerable<Projector>> GetProjectorsOfALearningSpacesAsync(GuidWrapper id)
    {
        return await _learningRepository.GetProjectorsOfALearningSpacesAsync(id);
    }
}