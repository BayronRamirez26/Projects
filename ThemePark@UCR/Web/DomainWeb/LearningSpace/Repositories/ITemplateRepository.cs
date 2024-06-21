using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities.Wrappers;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Repositories;

public interface ITemplateRepository
{
    /// <summary>
    /// This method allows to create a template and store it in the database.
    /// </summary>
    /// <param name="template">The template to add.</param>
    /// <returns>A task representing the asynchronous operation, 
    /// containing a boolean indicating the success of the operation.</returns>
    Task<bool> CreateTemplateAsync(Templates template);

    /// <summary>
    /// This method returns all templates available in the database.
    /// </summary>
    /// <returns>A task representing the asynchronous operation, 
    /// containing an enumerable of all available templates.</returns>
    Task<IEnumerable<Templates>> GetTemplatesAsync();

    /// <summary>
    /// This method allows to update the information of an existing template.
    /// </summary>
    /// <param name="template">The template to update.</param>
    /// <returns>A task representing the asynchronous operation, 
    /// containing a boolean indicating the success of the operation.</returns>
    Task<bool> ModifyTemplateAsync(Templates template);

    /// <summary>
    /// This method allows to delete a template from the database.
    /// </summary>
    /// <param name="id">The ID of the template to delete.</param>
    /// <returns>A task representing the asynchronous operation, 
    /// containing a boolean indicating the success of the operation.</returns>
    Task<bool> DeleteTemplateAsync(Guid id);

    /// <summary>
    /// Create whiteboards from a template and store them in the database.
    /// </summary>
    /// <param name="template"></param>
    /// <param name="LearningSpace"></param>
    /// <returns></returns>
    Task<bool> CreateWhiteboardsFromTemplateAsync(Guid template, Guid LearningSpace);

    /// <summary>
    /// Create projectors from a template and store them in the database.
    /// </summary>
    /// <param name="template"></param>
    /// <param name="LearningSpace"></param>
    /// <returns></returns>
    Task<bool> CreateProjectorsFromTemplateAsync(Guid template, Guid LearningSpace);

    /// <summary>
    /// Create interactive screens from a template and store them in the database.
    /// </summary>
    /// <param name="template"></param>
    /// <param name="LearningSpace"></param>
    /// <returns></returns>
    Task<bool> CreateInteractiveScreensFromTemplateAsync(Guid template, Guid LearningSpace);

    Task<IEnumerable<Templates>> GetTemplateFromIdAsync(Guid id);
    /// <summary>
    /// Add a component to a template.
    /// </summary>
    /// <param name="template_Has_Components"></param>
    /// <returns></returns>
    Task<bool> AddComponentToTemplateAsync(Template_Has_Components template_Has_Components);

    Task<IEnumerable<Template_Has_Components>> GetTemplate_Has_ComponentsAsync();

    Task<IEnumerable<Template_Has_Components>> GetComponents_From_TemplateAsync(GuidWrapper id);

    Task<bool> DeleteComponentAsync(GuidWrapper id);

}
