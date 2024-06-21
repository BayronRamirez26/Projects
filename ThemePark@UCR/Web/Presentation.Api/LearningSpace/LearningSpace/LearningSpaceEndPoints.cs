using Microsoft.AspNetCore.Mvc;
using UCR.ECCI.PI.ThemePark_UCR.Application.LearningSpace.Services.Interfaces;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities.Wrappers;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningSpace.LearningSpace;

public static class LearningSpaceEndPoints
{
    /// <summary>
    /// Get all LearningSpaces
    /// </summary>
    /// <param name="learningSpaceService"></param>
    /// <returns></returns>
    public static async Task<IEnumerable<LearningSpaces>> GetLearningSpaceAsync([FromServices] ILearningSpaceService learningSpaceService)
    {
        return await learningSpaceService.GetLearningSpaceAsync();
    }

    /// <summary>
    /// Modify a LearningSpace
    /// </summary>
    /// <param name="learningSpaceService"></param>
    /// <param name="newLearningSpace"></param>
    /// <returns></returns>
    public static async Task<bool> ModifyLearningSpaceAsync([FromServices] ILearningSpaceService learningSpaceService
        , LearningSpaces newLearningSpace)
    {
        return await learningSpaceService.ModifyLearningSpaceAsync(newLearningSpace);
    }

    /// <summary>
    /// Delete a LearningSpace
    /// </summary>
    /// <param name="learningSpaceService"></param>
    /// <param name="inputGuid"></param>
    /// <returns></returns>
    public static async Task<bool> DeleteLearningSpaceAsync([FromServices] ILearningSpaceService learningSpaceService
        , Guid inputGuid)
    {
        var input = GuidWrapper.Create(inputGuid);
        return await learningSpaceService.DeleteLearningSpaceAsync(input);
    }

    /// <summary>
    /// Create a new LearningSpace
    /// </summary>
    /// <param name="learningSpaceService"></param>
    /// <param name="inputLearningSpace"></param>
    /// <returns></returns>
    public static async Task<bool> CreateLearningSpaceAsync([FromServices] ILearningSpaceService learningSpaceService
        , LearningSpaces inputLearningSpace)
    {
        return await learningSpaceService.CreateLearningSpaceAsync(inputLearningSpace);
    }

    /// <summary>
    /// Register the endpoints for the LearningSpace
    /// </summary>
    /// <param name="routeBuilder"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder RegisterLearningSpaceEndpoints(this IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder
            .MapGet("/list-learningspaces", GetLearningSpaceAsync)
            .WithName("GetLearningSpace")
            .WithOpenApi();

        routeBuilder
            .MapPost("/modify-learning-space", ModifyLearningSpaceAsync)
            .WithName("ModifyLearningspaces")
            .WithOpenApi();

        routeBuilder
            .MapDelete("/delete-learningSpace", DeleteLearningSpaceAsync)
            .WithName("DeleteLearningSpace")
            .WithOpenApi();

        routeBuilder
            .MapPost("/create-learningspaces", CreateLearningSpaceAsync)
            .WithName("CreateLearningSpace")
            .WithOpenApi();


        return routeBuilder;
    }

}
