using UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.LearningSpace.Services.Interfaces;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Repositories;

namespace UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.LearningSpace.Services.Classes;

internal class LsTypeServices : ILsTypeServices
{
    private readonly IlearningSpaceTypeRepository _learningSpaceTypeRepository;

    /// <summary>
    /// LsTypeServices constructor
    /// </summary>
    /// <param name="learningSpaceTypeRepository"></param>
    public LsTypeServices(IlearningSpaceTypeRepository learningSpaceTypeRepository)
    {
        _learningSpaceTypeRepository = learningSpaceTypeRepository;
    }

    /// <summary>
    /// Get all learning space types
    /// </summary>
    /// <returns></returns>
    public async  Task<IEnumerable<LSType>> GetLSTypesAsync()
    {
        return await _learningSpaceTypeRepository.GetLSTypesAsync();
    }

    /// <summary>
    /// Create a learning space type by id
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public async Task<bool> PostCreateLSTypeAsync(LSType type)
    {
        return await _learningSpaceTypeRepository.PostCreateLSTypeAsync(type);
    }

    /// <summary>
    /// Update a learning space type by id
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public async Task<bool> PostUpdateLSTypeAsync(LSType type)
    {
        return await  _learningSpaceTypeRepository.PostUpdateLSTypeAsync(type);
    }

    /// <summary>
    /// delete a learning space type by id
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public async Task<bool> PostDeleteLSTypeAsync(Guid type)
    {
        return await _learningSpaceTypeRepository.PostDeleteLSTypeAsync(type);
    }
}
