using Microsoft.AspNetCore.Mvc;
using UCR.ECCI.PI.ThemePark_UCR.Application.LearningComponents.Services;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningComponents.AIAssistant.Dtos;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.AIAssistant.Mappers;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;
using DomainAssistant = UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Entities.AIAssistant;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities.Wrappers;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningComponents.AIAssistant;

public static class AIAssistantEndpoints
{
    public static async Task<GetAIAssistantResponse> GetAIAssistantsAsync([FromServices] IAIAssistantService aiAssistantService)
    {
        var aiAssistantEntities = await aiAssistantService.GetAIAssistantsAsync();
        var aiAssistantDtos = aiAssistantEntities.Select(AIAssistantDtoMapper.FromEntitiy);
        return new GetAIAssistantResponse(aiAssistantDtos);
    }

    public static async Task<IResult> CreateAIAssistantAsync([FromServices] IAIAssistantService aIAssistantService, AIAssistantDto aIAssistantDto)
    {
        try
        {
             DomainAssistant assistant = new DomainAssistant(
             MediumName.Create(aIAssistantDto.learningComponenName),
             Size.Create(aIAssistantDto.sizeX),
             Size.Create(aIAssistantDto.sizeY),
             Coordinate.Create(aIAssistantDto.positionX),
             Coordinate.Create(aIAssistantDto.positionY),
             Coordinate.Create(aIAssistantDto.positionZ),
             Coordinate.Create(aIAssistantDto.rotationX),
             Coordinate.Create(aIAssistantDto.rotationY),
             GuidWrapper.Create(aIAssistantDto.learningSpaceId.Value)
             );

            var success = await aIAssistantService.CreateAIAssistantsAsync(assistant);

            Console.WriteLine($"Result: {success}");
            if (success == false)
            {
                return Results.BadRequest("AIAssistant could not be created");
            }

            // Return a successful response
            return Results.Created($"/create-AIAssistant/{aIAssistantDto.learningComponenName}", aIAssistantDto);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in the mapPost: {ex.Message}");
            Console.WriteLine($"Error in the mapPost: {ex.StackTrace}");
            return Results.BadRequest("AIAssistant could not be created: " + ex.Message);
        }
    }

    public static async Task<IResult> ModifyAIAssistantAsync(
        [FromServices] IAIAssistantService assistantService, AIAssistantDto aIAssistantDto)
    {
        try
        {
             DomainAssistant assistant = new DomainAssistant(
                 LComponentID.Create(aIAssistantDto.learningComponentId),
                 MediumName.Create(aIAssistantDto.learningComponenName),
                 Size.Create(aIAssistantDto.sizeX),
                 Size.Create(aIAssistantDto.sizeY),
                 Coordinate.Create(aIAssistantDto.positionX),
                 Coordinate.Create(aIAssistantDto.positionY),
                 Coordinate.Create(aIAssistantDto.positionZ),
                 Coordinate.Create(aIAssistantDto.rotationX),
                 Coordinate.Create(aIAssistantDto.rotationY),
                 GuidWrapper.Create(aIAssistantDto.learningSpaceId.Value)
             );
            var success = await assistantService.ModifyAIAssistantAsync(assistant);

            if (success == false)
            {
                return Results.BadRequest("AI Assistant could not be modified");
            }

            return Results.Created($"/modify-AIAssistant/{aIAssistantDto.learningComponenName}", aIAssistantDto);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in the mapPut: {ex.Message}");
            Console.WriteLine($"Error in the mapPut: {ex.StackTrace}");
            return Results.BadRequest("AI Assistant could not be modified: " + ex.Message);
        }

    }

    public static async Task<IResult> DeleteAIAssistantAsync(
        [FromServices] IAIAssistantService assistantService, [FromBody] AIAssistantDto aIAssistantDto)
    {
        try
        {
            DomainAssistant assistant = new DomainAssistant(
                 LComponentID.Create(aIAssistantDto.learningComponentId),
                 MediumName.Create(aIAssistantDto.learningComponenName),
                 Size.Create(aIAssistantDto.sizeX),
                 Size.Create(aIAssistantDto.sizeY),
                 Coordinate.Create(aIAssistantDto.positionX),
                 Coordinate.Create(aIAssistantDto.positionY),
                 Coordinate.Create(aIAssistantDto.positionZ),
                 Coordinate.Create(aIAssistantDto.rotationX),
                 Coordinate.Create(aIAssistantDto.rotationY),
                 GuidWrapper.Create(aIAssistantDto.learningSpaceId.Value)
             );

            var success = await assistantService.DeleteAIAssistantAsync(assistant);

            if (success == false)
            {
                return Results.BadRequest("AI Assistant could not be deleted");
            }

            return Results.Created($"/delete-AIAssistant/{aIAssistantDto.learningComponenName}", aIAssistantDto);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in the mapPut: {ex.Message}");
            Console.WriteLine($"Error in the mapPut: {ex.StackTrace}");
            return Results.BadRequest("AI Assistant could not be deleted: " + ex.Message);
        }

    }



    public static IEndpointRouteBuilder RegisterAIAssistantEndpoints(this IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder
            .MapGet("/list-aiassistants", GetAIAssistantsAsync)
            .WithName("List-AIAssistant")
            .WithTags("LearningComponentsEndpoints")
            .WithOpenApi();

        routeBuilder
            .MapPost("/create-aiassistant", CreateAIAssistantAsync)
            .WithName("Create-AIAssistant")
            .WithTags("LearningComponentsEndpoints")
            .WithOpenApi();

        routeBuilder
           .MapPost("/modify-aiassistant", ModifyAIAssistantAsync)
           .WithName("Modify-AIAssistant")
           .WithTags("LearningComponentsEndpoints")
           .WithOpenApi();

        routeBuilder
            .MapDelete("/delete-aiassistant", DeleteAIAssistantAsync)
            .WithName("Delete-AIAssistant")
            .WithTags("LearningComponentsEndpoints")
            .WithOpenApi();

        return routeBuilder;

    }
}