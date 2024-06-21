using Microsoft.Kiota.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.GetTemplateFromId;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.LearningSpace.Dtos;
using static UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.CreateInteractiveScreenFromTemplate.CreateInteractiveScreenFromTemplateRequestBuilder;
using static UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.CreateProjectorFromTemplate.CreateProjectorFromTemplateRequestBuilder;
using static UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.CreateWhiteboardFromTemplate.CreateWhiteboardFromTemplateRequestBuilder;
using static UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.DeleteTemplate.DeleteTemplateRequestBuilder;
using static UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.DeleteTemplate_has_component.DeleteTemplate_has_componentRequestBuilder;
using static UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.GetComponentsFromTemplate.GetComponentsFromTemplateRequestBuilder;
using static UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.GetLearningSpaceById.GetLearningSpaceByIdRequestBuilder;
using static UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.GetTemplateFromId.GetTemplateFromIdRequestBuilder;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.LearningSpace.Repositories;

public class ApiClientTemplateRepository : ITemplateRepository
{

    private readonly ApiClientKiota _apiClient;

    /// <summary>
    /// ApiClientTemplateRepository constructor
    /// </summary>
    /// <param name="apiClient"></param>
    public ApiClientTemplateRepository(ApiClientKiota apiClient)
    {
        _apiClient = apiClient;
    }

    /// <summary>
    /// Create a interactive screen from a template
    /// </summary>
    /// <param name="template"></param>
    /// <param name="LearningSpace"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<bool> CreateInteractiveScreensFromTemplateAsync(Guid template, Guid learningSpace)
    {
        var requestConfiguration = new Action<RequestConfiguration<CreateInteractiveScreenFromTemplateRequestBuilderPostQueryParameters>>(config =>
        {
            config.QueryParameters = new CreateInteractiveScreenFromTemplateRequestBuilderPostQueryParameters
            {
                TemplateId = template,
                LearningSpaceId = learningSpace // Assuming LearningSpaceId is needed in the query parameters
            };
        });

        var result = await _apiClient.CreateInteractiveScreenFromTemplate.PostAsync(requestConfiguration);
        return (bool)result;
    }


    /// <summary>
    /// Create a projector from a template
    /// </summary>
    /// <param name="template"></param>
    /// <param name="LearningSpace"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<bool> CreateProjectorsFromTemplateAsync(Guid template, Guid learningSpace)
    {
        var requestConfiguration = new Action<RequestConfiguration<CreateProjectorFromTemplateRequestBuilderPostQueryParameters>>(config =>
        {
            config.QueryParameters = new CreateProjectorFromTemplateRequestBuilderPostQueryParameters
            {
                TemplateId = template,
                LearningSpaceId = learningSpace // Assuming LearningSpaceId is needed in the query parameters
            };
        });

        var result = await _apiClient.CreateProjectorFromTemplate.PostAsync(requestConfiguration);
        return (bool)result;
    }


    /// <summary>
    /// Create whiteboards from a template
    /// </summary>
    /// <param name="template"></param>
    /// <param name="LearningSpace"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<bool> CreateWhiteboardsFromTemplateAsync(Guid template, Guid learningSpace)
    {
        var requestConfiguration = new Action<RequestConfiguration<CreateWhiteboardFromTemplateRequestBuilderPostQueryParameters>>(config =>
        {
            config.QueryParameters = new CreateWhiteboardFromTemplateRequestBuilderPostQueryParameters
            {
                TemplateId = template,
                LearningSpaceId = learningSpace // Assuming LearningSpaceId is needed in the query parameters
            };
        });

        var result = await _apiClient.CreateWhiteboardFromTemplate.PostAsync(requestConfiguration);
        return (bool)result;
    }


    /// <summary>
    /// Create a template
    /// </summary>
    /// <param name="template"></param>
    /// <returns></returns>
    public async Task<bool> CreateTemplateAsync(Templates template)
    {
        // Try to map from DomainWeb.LearningSpace to Models.LearningSpace
        try
        {
            var inputTemplate = KiotaTemplatesDtoMapper.ToEntity(template);
            // Try to use apiClient CreateLearningSpace method
            try
            {
                var output = await _apiClient.PostTemplate.PostAsync(inputTemplate);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error with RequestBuilder {ex}");
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error trying to map from Domain to Models {ex}");
            Console.WriteLine(ex.Message);
            return false;
        }

        return true;
    }

    /// <summary>
    /// Delete a template
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<bool> DeleteTemplateAsync(Guid id)
    {
        try
        {
            var requestConfiguration = new Action<RequestConfiguration<DeleteTemplateRequestBuilderDeleteQueryParameters>>(config =>
            {
                config.QueryParameters = new DeleteTemplateRequestBuilderDeleteQueryParameters
                {
                    InputGuid = id
                };
            });
            var output = await _apiClient.DeleteTemplate.DeleteAsync(requestConfiguration);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error trying to map from Domain to Models {ex}");
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    /// <summary>
    /// Get all templates
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"></exception>
    public async Task<IEnumerable<Templates>> GetTemplatesAsync()
    {
        try
        {
            var getTemplatesDtos = await _apiClient.GetTemplates.GetAsync();

            // Try converting from Models.LearningSpace to DomainWeb.LearningSpace
            try
            {
                var templatesEntitites = getTemplatesDtos?.Select(TemplatesDtoMapper.ToEntity)
                    ?? throw new NullReferenceException();
                return templatesEntitites;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error trying to map LearningSpace from Models to Domain {ex}");
                Console.WriteLine(ex.Message);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error with requestBuilder {ex}");
            Console.WriteLine(ex.Message);
        }
        return Enumerable.Empty<DomainWeb.LearningSpace.Entities.Templates>();
    }

    /// <summary>
    /// Modify a template
    /// </summary>
    /// <param name="template"></param>
    /// <returns></returns>
    public async Task<bool> ModifyTemplateAsync(Templates template)
    {
        //// Try converting from DomainWeb.LearningSpace to Models.LearningSpace
        try
        {
            var inputTemplate = KiotaTemplatesDtoMapper.ToEntity(template);

            // to use apiClient ModifyLearningSpace method
            try
            {
                var output = await _apiClient.PostModifyTemplate.PostAsync(inputTemplate);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error with RequestBuilder {ex}");
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error trying to map from Domain to Models {ex}");
            Console.WriteLine(ex.Message);
            return false;
        }

        return true;
    }

    public async Task<IEnumerable<Templates>> GetTemplateFromIdAsync(Guid id)
    {
        try
        {
            var requestConfiguration = new Action<RequestConfiguration<GetTemplateFromIdRequestBuilderGetQueryParameters>>(config =>
            {
                config.QueryParameters = new GetTemplateFromIdRequestBuilderGetQueryParameters
                {
                    Id = id
                };
            });

            try
            {
                var output = await _apiClient.GetTemplateFromId.GetAsync(requestConfiguration);
                var templatesEntitites = output?.Select(TemplatesDtoMapper.ToEntity)
                    ?? throw new NullReferenceException();
                return templatesEntitites;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error with Request Builder {ex}");
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error trying to map from GuidWrapper to Guid {ex}");
            Console.WriteLine(ex.Message);
            return null;
        }

    }

    /// <summary>
    /// Add a component to a template
    /// </summary>
    /// <param name="template_Has_Components"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<bool> AddComponentToTemplateAsync(Template_Has_Components template_Has_Components)
    {
        // Try to map from DomainWeb.LearningSpace to Models.LearningSpace
        try
        {
            var inputTemplate = KiotaTemplate_Has_ComponentDtoMapper.ToEntity(template_Has_Components);
            // inputTemplate.ComponentType.Value = template_Has_Components.Component_type.Value;
            // Try to use apiClient CreateLearningSpace method
            try
            {
                Console.WriteLine("XXXXXXXXasdasdasdasdaXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
                //Console.WriteLine(template_Has_Components.Component_type.Value);
               //  Console.WriteLine("y el valor?");
                var output = await _apiClient.CreateTemplateHasComponents.PostAsync(inputTemplate);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error with RequestBuilder {ex}");
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error trying to map from Domain to Models {ex}");
            Console.WriteLine(ex.Message);
            return false;
        }

        return true;
    }

    public async Task<IEnumerable<Template_Has_Components>> GetTemplate_Has_ComponentsAsync()
    {
        try
        {
            var getTemplatesDtos = await _apiClient.GetTemplate_has_components.GetAsync();

            // Try converting from Models.LearningSpace to DomainWeb.LearningSpace
            try
            {
                var templatesEntitites = getTemplatesDtos?.Select(Template_Has_ComponentsDtoMapper.ToEntity)
                    ?? throw new NullReferenceException();
                return templatesEntitites;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error trying to map LearningSpace from Models to Domain {ex}");
                Console.WriteLine(ex.Message);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error with requestBuilder {ex}");
            Console.WriteLine(ex.Message);
        }
        return Enumerable.Empty<DomainWeb.LearningSpace.Entities.Template_Has_Components>();
    }

    public async Task<IEnumerable<Template_Has_Components>> GetComponents_From_TemplateAsync(GuidWrapper id)
    {
        try
        {
            var requestConfiguration = new Action<RequestConfiguration<GetComponentsFromTemplateRequestBuilderGetQueryParameters>>(config =>
            {
                config.QueryParameters = new GetComponentsFromTemplateRequestBuilderGetQueryParameters
                {
                    Id = id.Value
                };
            });
            
            try
            {
                var output = await _apiClient.GetComponentsFromTemplate.GetAsync(requestConfiguration);
                var templatesEntitites = output?.Select(Template_Has_ComponentsDtoMapper.ToEntity)
                    ?? throw new NullReferenceException();
                return templatesEntitites;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error trying to map LearningSpace from Models to Domain {ex}");
                Console.WriteLine(ex.Message);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error with requestBuilder {ex}");
            Console.WriteLine(ex.Message);
        }
        return Enumerable.Empty<DomainWeb.LearningSpace.Entities.Template_Has_Components>();
    }

    public async Task<bool> DeleteComponentAsync(GuidWrapper id)
    {
        try
        {
            var requestConfiguration = new Action<RequestConfiguration<DeleteTemplate_has_componentRequestBuilderDeleteQueryParameters>>(config =>
            {
                config.QueryParameters = new DeleteTemplate_has_componentRequestBuilderDeleteQueryParameters
                {
                    Id = id.Value
                };
            });
            var output = await _apiClient.DeleteTemplate_has_component.DeleteAsync(requestConfiguration);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error trying to map from Domain to Models {ex}");
            Console.WriteLine(ex.Message);
            return false;
        }

    }

}