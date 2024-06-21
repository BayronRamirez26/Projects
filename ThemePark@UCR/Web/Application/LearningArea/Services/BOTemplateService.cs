using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Application.LearningArea.Services;

public class BOTemplateService : IBOTemplateService
{
    private readonly IBOTemplateRepository _boTemplateRepository;

    public BOTemplateService(IBOTemplateRepository boTemplateRepository)
    {
        _boTemplateRepository = boTemplateRepository;
    }

    public async Task<IEnumerable<MediumName>> GetBOTemplatesObjectTypesAsync()
    {
        return await _boTemplateRepository.GetBOTemplatesObjectTypesAsync();
    }

    public async Task<IEnumerable<MediumName>> GetBOTemplatesPlanesAsync()
    {
        return await _boTemplateRepository.GetBOTemplatesPlanesAsync();
    }

    public async Task<IEnumerable<BOTemplate>> GetAllBOTemplatesAsync()
    {
        return await _boTemplateRepository.GetAllBOTemplatesAsync();
    }

    public async Task<IEnumerable<BOTemplate>> GetBOTemplatesOfTypeAsync(
        MediumName objectType)
    {
        return await _boTemplateRepository.GetBOTemplatesOfTypeAsync(objectType);
    }

    public async Task<IEnumerable<BOTemplate>> GetBOTemplatesOfPlaneAsync(
        MediumName plane)
    {
        return await _boTemplateRepository.GetBOTemplatesOfPlaneAsync(plane);
    }

    public async Task<IEnumerable<BOTemplate>> GetBOTemplatesOfTypeAndPlaneAsync(
        MediumName objectType, 
        MediumName plane)
    {
        return await _boTemplateRepository.GetBOTemplatesOfTypeAndPlaneAsync(
            objectType, 
            plane);
    }
}
