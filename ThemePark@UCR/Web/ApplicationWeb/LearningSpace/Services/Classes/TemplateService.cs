using UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.LearningSpace.Services.Interfaces;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Repositories;

namespace UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.LearningSpace.Services.Classes;

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

    /// <summary>
    /// Create a template and store it in the database using the sql repository
    /// </summary>
    /// <param name="template"></param>
    /// <returns></returns>
    public async Task<bool> CreateTemplateAsync(Templates template)
    {
        return await _templateRepository.CreateTemplateAsync(template);
    }

    /// <summary>
    /// Delete a template from the database using the sql repository
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<bool> DeleteTemplateAsync(Guid id)
    {
        return await _templateRepository.DeleteTemplateAsync(id);
    }

    /// <summary>
    /// Get all templates from the database using the sql repository
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<Templates>> GetTemplatesAsync()
    {
        return await _templateRepository.GetTemplatesAsync();
    }

    /// <summary>
    /// Modify a template in the database using the sql repository
    /// </summary>
    /// <param name="template"></param>
    /// <returns></returns>
    public async Task<bool> ModifyTemplateAsync(Templates template)
    {
        return await _templateRepository.ModifyTemplateAsync(template);
    }

    /// <summary>
    /// Create whiteboards from a template and store them in the database using the sql repository
    /// </summary>
    /// <param name="Template"></param>
    /// <param name="LearningSpace"></param>
    /// <returns></returns>
    public async Task<bool> CreateWhiteboardsFromTemplateAsync(Guid Template, Guid LearningSpace)
    {
        return await _templateRepository.CreateWhiteboardsFromTemplateAsync(Template, LearningSpace);
    }

    /// <summary>
    /// Create projectors from a template and store them in the database using the sql repository
    /// </summary>
    /// <param name="Template"></param>
    /// <param name="LearningSpace"></param>
    /// <returns></returns>
    public async Task<bool> CreateProjectorsFromTemplateAsync(Guid Template, Guid LearningSpace)
    {
        return await _templateRepository.CreateProjectorsFromTemplateAsync(Template, LearningSpace);
    }

    /// <summary>
    /// Create interactive screens from a template and store them in the database using the sql repository
    /// </summary>
    /// <param name="Template"></param>
    /// <param name="LearningSpace"></param>
    /// <returns></returns>
    public async Task<bool> CreateInteractiveScreensFromTemplateAsync(Guid Template, Guid LearningSpace)
    {
        return await _templateRepository.CreateInteractiveScreensFromTemplateAsync(Template, LearningSpace);
    }

    public async Task<IEnumerable<Templates>> GetTemplateFromIdAsync(Guid id)
    {
        return await _templateRepository.GetTemplateFromIdAsync(id);
    }

    /// <summary>
    /// Add a component to a template using the sql repository
    /// </summary>
    /// <param name="template_Has_Components"></param>
    /// <returns></returns>
    public async Task<bool> AddComponentToTemplateAsync(Template_Has_Components template_Has_Components)
    {
        Console.WriteLine("SERVICIOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO");
        Console.WriteLine(template_Has_Components.Component_type);
        return await _templateRepository.AddComponentToTemplateAsync(template_Has_Components);
    }

    public Task<IEnumerable<Template_Has_Components>> GetTemplate_Has_ComponentsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Template_Has_Components>> GetComponents_From_TemplateAsync(GuidWrapper id)
    {
        return await _templateRepository.GetComponents_From_TemplateAsync(id);
    }

    public async Task<bool> DeleteComponentAsync(GuidWrapper id)
    {
        return await _templateRepository.DeleteComponentAsync(id);
    }
}