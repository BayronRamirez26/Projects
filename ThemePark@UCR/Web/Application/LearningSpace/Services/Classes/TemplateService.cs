using UCR.ECCI.PI.ThemePark_UCR.Application.LearningSpace.Services.Interfaces;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Repositories;

namespace UCR.ECCI.PI.ThemePark_UCR.Application.LearningSpace.Services.Classes;

/// <summary>
/// This class makes all requests to repository about learning spaces
/// </summary>
internal class TemplateService : ITemplateService
{
    /// <summary>
    /// Instance of ILearningSpaceRepository to connect with repository
    /// </summary>
    private readonly ITemplateRepository _templateRepository;

    /// <summary>
    /// Primary constructor
    /// </summary>
    /// <param name="learningRepository">ILearningSpaceRepository instance neccesary</param>
    public TemplateService(ITemplateRepository learningRepository)
    {
        _templateRepository = learningRepository;
    }

    public async Task<bool> CreateTemplateAsync(Templates template)
    {
        return await _templateRepository.CreateTemplateAsync(template);
    }

    public async Task<bool> DeleteTemplateAsync(Guid id)
    {
        return await _templateRepository.DeleteTemplateAsync(id);
    }

    public async Task<IEnumerable<Templates>> GetTemplatesAsync()
    {
        return await _templateRepository.GetTemplatesAsync();
    }

    public async Task<bool> ModifyTemplateAsync(Templates template)
    {
        return await _templateRepository.ModifyTemplateAsync(template);
    }

    public async Task<bool> CreateWhiteboardsFromTemplateAsync(Guid Template, Guid LearningSpace)
    {
        return await _templateRepository.CreateWhiteboardsFromTemplateAsync(Template, LearningSpace);
    }

    public async Task<bool> CreateProjectorsFromTemplateAsync(Guid Template, Guid LearningSpace)
    {
        return await _templateRepository.CreateProjectorsFromTemplateAsync(Template, LearningSpace);
    }


    public async Task<bool> CreateInteractiveScreensFromTemplateAsync(Guid Template, Guid LearningSpace)
    {
        return await _templateRepository.CreateInteractiveScreensFromTemplateAsync(Template, LearningSpace);
    }

    public async Task<IEnumerable<Templates>> GetTemplateFromIdAsync(Guid id)
    {
        return await _templateRepository.GetTemplateFromIdAsync(id);
    }

    public async Task<bool> AddComponentToTemplateAsync(Template_Has_Components template_Has_Components)
    {
        return await _templateRepository.AddComponentToTemplateAsync(template_Has_Components);
    }

    public async Task<IEnumerable<Template_Has_Components>> GetTemplate_Has_ComponentsAsync()
    {
        return await _templateRepository.GetTemplate_Has_ComponentsAsync();
    }

    public async Task<IEnumerable<Template_Has_Components>> GetComponentsFromTemplateAsync(GuidWrapper id)
    {
        //throw new NotImplementedException();
        return await _templateRepository.GetComponentsFromTemplateAsync(id);
    }

    public async Task<bool> DeleteComponentAsync(GuidWrapper id)
    {
        return await _templateRepository.DeleteComponentAsync(id);
    }
}