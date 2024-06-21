using Microsoft.AspNetCore.Mvc;
using UCR.ECCI.PI.ThemePark_UCR.Application.LearningSpace.Services.Interfaces;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningSpace.LearningSpaceTemplate;

public static class LearningSpaceTemplateEndPoints
{

    /// <summary>
    /// Get all LearningSpaceTemplates
    /// </summary>
    /// <param name="templateService"></param>
    /// <returns></returns>
    public static async Task<IEnumerable<Templates>> GetLearningSpaceTemplateAsync([FromServices] ITemplateService templateService)
    {
        return await templateService.GetTemplatesAsync();
    }

    /// <summary>
    /// Modify a LearningSpaceTemplate
    /// </summary>
    /// <param name="templateService"></param>
    /// <param name="newTemplate"></param>
    /// <returns></returns>
    public static async Task<bool> ModifyLearningSpaceTemplateAsync([FromServices] ITemplateService templateService
               , Templates newTemplate)
    {
        return await templateService.ModifyTemplateAsync(newTemplate);
    }

    /// <summary>
    /// Delete a LearningSpaceTemplate
    /// </summary>
    /// <param name="templateService"></param>
    /// <param name="inputGuid"></param>
    /// <returns></returns>
    public static async Task<bool> DeleteLearningSpaceTemplateAsync([FromServices] ITemplateService templateService
               , Guid inputGuid)
    {
        // this delete receive a guid, not a wrapper, where LS receive a wrapper
        return await templateService.DeleteTemplateAsync(inputGuid);
    }

    /// <summary>
    /// Create a new LearningSpaceTemplate
    /// </summary>
    /// <param name="templateService"></param>
    /// <param name="inputTemplate"></param>
    /// <returns></returns>
    public static async Task<bool> CreateLearningSpaceTemplateAsync([FromServices] ITemplateService templateService
                      , Templates inputTemplate)
    {
        return await templateService.CreateTemplateAsync(inputTemplate);
    }

    /// <summary>
    /// Register the endpoints for the LearningSpaceTemplate
    /// </summary>
    /// <param name="routeBuilder"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder RegisterLearningSpaceTemplateEndpoints(this IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder
            .MapGet("/get-Templates", GetLearningSpaceTemplateAsync)
            .WithName("getLSTemplates")
            .WithOpenApi();

        routeBuilder
            .MapPost("/post-modifyTemplate", ModifyLearningSpaceTemplateAsync)
            .WithName("postModifyTemplates")
            .WithOpenApi();

        routeBuilder
            .MapDelete("/delete-template", DeleteLearningSpaceTemplateAsync)
            .WithName("deleteTemplate")
            .WithOpenApi();

        routeBuilder
            .MapPost("/post-Template", CreateLearningSpaceTemplateAsync)
            .WithName("postTemplates")
            .WithOpenApi();

        return routeBuilder;
    }
}
