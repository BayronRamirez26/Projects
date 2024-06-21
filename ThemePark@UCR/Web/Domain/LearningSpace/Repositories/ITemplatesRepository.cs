using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities.Wrappers;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Repositories;

/// <summary>
/// Connects data with SqlLearningSpaceRepository to convert service functions 
/// into sql functionalities
/// </summary>
public interface ITemplateRepository
{
    /// <summary>
    /// This method allows to create a template and store it in the database.
    /// </summary>
    /// <param name="template">The template to add.</param>
    /// <returns>A task representing the asynchronous operation, containing a boolean indicating the success of the operation.</returns>
    Task<bool> CreateTemplateAsync(Templates template);

    /// <summary>
    /// This method returns all templates available in the database.
    /// </summary>
    /// <returns>A task representing the asynchronous operation, containing an enumerable of all available templates.</returns>
    Task<IEnumerable<Templates>> GetTemplatesAsync();

    /// <summary>
    /// This method allows to update the information of an existing template.
    /// </summary>
    /// <param name="template">The template to update.</param>
    /// <returns>A task representing the asynchronous operation, containing a boolean indicating the success of the operation.</returns>
    Task<bool> ModifyTemplateAsync(Templates template);

    /// <summary>
    /// This method allows to delete a template from the database.
    /// </summary>
    /// <param name="id">The ID of the template to delete.</param>
    /// <returns>A task representing the asynchronous operation, containing a boolean indicating the success of the operation.</returns>
    Task<bool> DeleteTemplateAsync(Guid id);

    Task<bool> CreateWhiteboardsFromTemplateAsync(Guid template, Guid LearningSpace);

    Task<bool> CreateProjectorsFromTemplateAsync(Guid template, Guid LearningSpace);

    Task<bool> CreateInteractiveScreensFromTemplateAsync(Guid template, Guid LearningSpace);

    Task<IEnumerable<Templates>> GetTemplateFromIdAsync(Guid templateId);

    Task<bool> AddComponentToTemplateAsync(Template_Has_Components template_Has_Components);

    Task<IEnumerable<Template_Has_Components>> GetTemplate_Has_ComponentsAsync();

    Task<IEnumerable<Template_Has_Components>> GetComponentsFromTemplateAsync(GuidWrapper id);

    Task<bool> DeleteComponentAsync(GuidWrapper id);
}