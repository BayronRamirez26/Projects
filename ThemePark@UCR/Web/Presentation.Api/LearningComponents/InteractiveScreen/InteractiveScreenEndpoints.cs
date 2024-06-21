using Microsoft.AspNetCore.Mvc;
using UCR.ECCI.PI.ThemePark_UCR.Application.LearningComponents.Services;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningComponents.InteractiveScreen.Dtos;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningComponents.InteractiveScreen.Mappers;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningComponents.InteractiveScreen.Responses;
using DomainInteractiveScreen = UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Entities.InteractiveScreen;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningComponents.InteractiveScreen;

public static class InteractiveScreenEndpoints
{
    public static async Task<GetInteractiveScreenResponse> GetInteractiveScreensAsync([FromServices] IInteractiveScreenService interactiveScreenService)
    {
        var interactiveScreenEntities = await interactiveScreenService.GetInteractiveScreensAsync();
        var interactiveScreenDtos = interactiveScreenEntities.Select(InteractiveScreenDtoMapper.FromEntitity);
        return new GetInteractiveScreenResponse(interactiveScreenDtos);
    }

    public static async Task<IResult> CreateInteractiveScreensAsync([FromServices] IInteractiveScreenService interactiveScreenService, InteractiveScreenDto interactiveScreenDto)
    {
        try
        {
            DomainInteractiveScreen interactiveScreen = new DomainInteractiveScreen(
                 MediumName.Create(interactiveScreenDto.learningComponenName),
                 Size.Create(interactiveScreenDto.sizeX),
                 Size.Create(interactiveScreenDto.sizeY),
                 Coordinate.Create(interactiveScreenDto.positionX),
                 Coordinate.Create(interactiveScreenDto.positionY),
                 Coordinate.Create(interactiveScreenDto.positionZ),
                 Coordinate.Create(interactiveScreenDto.rotationX),
                 Coordinate.Create(interactiveScreenDto.rotationY),
                 GuidWrapper.Create(interactiveScreenDto.learningSpaceId.Value)
             );

            var success = await interactiveScreenService.CreateInteractiveScreensAsync(interactiveScreen);

            Console.WriteLine($"Result: {success}");
            if (success == false)
            {
                return Results.BadRequest("Interactive Screent could not be created");
            }

            // Return a successful response
            return Results.Created($"/create-InteractiveScreen/{interactiveScreenDto.learningComponenName}", interactiveScreenDto);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in the mapPost: {ex.Message}");
            Console.WriteLine($"Error in the mapPost: {ex.StackTrace}");
            return Results.BadRequest("Interactive Screen could not be created: " + ex.Message);
        }
    }

    public static async Task<IResult> ModifyInteractiveScreenAsync([FromServices] IInteractiveScreenService interactiveScreenService, InteractiveScreenDto interactiveScreenDto)
    {
        try
        {

            DomainInteractiveScreen interactiveScreen = new DomainInteractiveScreen(
                 LComponentID.Create(interactiveScreenDto.learningComponentId),
                 MediumName.Create(interactiveScreenDto.learningComponenName),
                 Size.Create(interactiveScreenDto.sizeX),
                 Size.Create(interactiveScreenDto.sizeY),
                 Coordinate.Create(interactiveScreenDto.positionX),
                 Coordinate.Create(interactiveScreenDto.positionY),
                 Coordinate.Create(interactiveScreenDto.positionZ),
                 Coordinate.Create(interactiveScreenDto.rotationX),
                 Coordinate.Create(interactiveScreenDto.rotationY),
                 GuidWrapper.Create(interactiveScreenDto.learningSpaceId.Value)
             );

            var success = await interactiveScreenService.ModifyInteractiveScreenAsync(interactiveScreen);

            Console.WriteLine($"Result: {success}");
            if (success == false)
            {
                return Results.BadRequest("Interactive screen could not be modified");
            }

            // Return a successful response
            return Results.Created($"/modify-InteractiveScreen/{interactiveScreenDto.learningComponenName}", interactiveScreenDto);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in the mapPost: {ex.Message}");
            Console.WriteLine($"Error in the mapPost: {ex.StackTrace}");
            return Results.BadRequest("Interactive Screen could not be modify: " + ex.Message);
        }
    }

    public static async Task<IResult> DeleteInteractiveScreenAsync([FromServices] IInteractiveScreenService interactiveScreenService, [FromBody] InteractiveScreenDto interactiveScreenDto)
    {
        try
        {

            DomainInteractiveScreen interactiveScreen = new DomainInteractiveScreen(
                 LComponentID.Create(interactiveScreenDto.learningComponentId),
                 MediumName.Create(interactiveScreenDto.learningComponenName),
                 Size.Create(interactiveScreenDto.sizeX),
                 Size.Create(interactiveScreenDto.sizeY),
                 Coordinate.Create(interactiveScreenDto.positionX),
                 Coordinate.Create(interactiveScreenDto.positionY),
                 Coordinate.Create(interactiveScreenDto.positionZ),
                 Coordinate.Create(interactiveScreenDto.rotationX),
                 Coordinate.Create(interactiveScreenDto.rotationY),
                 GuidWrapper.Create(interactiveScreenDto.learningSpaceId.Value)
             );

            var success = await interactiveScreenService.DeleteInteractiveScreenAsync(interactiveScreen);

            Console.WriteLine($"Result: {success}");
            if (success == false)
            {
                return Results.BadRequest("Interactive screen could not be Deleted");
            }

            // Return a successful response
            return Results.Created($"/modify-InteractiveScreen/{interactiveScreenDto.learningComponenName}", interactiveScreenDto);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in the mapPost: {ex.Message}");
            Console.WriteLine($"Error in the mapPost: {ex.StackTrace}");
            return Results.BadRequest("Interactive Screen could not be deleted: " + ex.Message);
        }
    }


    public static IEndpointRouteBuilder RegisterInteractiveScreenEndpoints(this IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder
            .MapGet("/list-interactivescreens", GetInteractiveScreensAsync)
            .WithName("List-InteractiveScreens")
            .WithTags("LearningComponentsEndpoints")
            .WithOpenApi();

        routeBuilder
            .MapPost("/create-interactivescreen", CreateInteractiveScreensAsync)
            .WithName("Create-InteractiveScreen")
            .WithTags("LearningComponentsEndpoints")
            .WithOpenApi();

        routeBuilder
            .MapPost("/modify-interactivescreen", ModifyInteractiveScreenAsync)
            .WithName("Modify-InteractiveScreen")
            .WithTags("LearningComponentsEndpoints")
            .WithOpenApi();

        routeBuilder
            .MapDelete("/delete-interactivescreen", DeleteInteractiveScreenAsync)
            .WithName("Delete-InteractiveScreen")
            .WithTags("LearningComponentsEndpoints")
            .WithOpenApi();

        return routeBuilder;
    }
}