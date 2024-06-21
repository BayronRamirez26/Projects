using Microsoft.AspNetCore.Mvc;
using UCR.ECCI.PI.ThemePark_UCR.Application.LearningComponents.Services;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningComponents.Whiteboard.Dtos;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningComponents.Whiteboard.Mappers;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningComponents.Whiteboard.Responses;
using DomainWhiteboard = UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Entities.Whiteboard;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningComponents.Whiteboard;

public static class WhiteboardEndpoints
{
    public static async Task<GetWhiteboardsResponse> GetWhiteboardsAsync([FromServices] IWhiteboardService whiteboardService)
    {
        var whiteboardsEntities = await whiteboardService.GetWhiteboardsAsync();
        var whiteboardDtos = whiteboardsEntities.Select(WhiteboardDtoMapper.FromEntitity);
        return new GetWhiteboardsResponse(whiteboardDtos);
    }

    public static async Task<IResult> CreateWhiteboardAsync([FromServices] IWhiteboardService whiteboardService, WhiteboardDto whiteboardDto)
    {
        
               

        try
        {
             DomainWhiteboard whiteboard = new DomainWhiteboard(
             MediumName.Create(whiteboardDto.learningComponenName),
             Size.Create(whiteboardDto.sizeX),
             Size.Create(whiteboardDto.sizeY),
             Coordinate.Create(whiteboardDto.positionX),
             Coordinate.Create(whiteboardDto.positionY),
             Coordinate.Create(whiteboardDto.positionZ),
             Coordinate.Create(whiteboardDto.rotationX),
             Coordinate.Create(whiteboardDto.rotationY),
             GuidWrapper.Create(whiteboardDto.learningSpaceId.Value)
             );



            var success = await whiteboardService.CreateWhiteboardsAsync(whiteboard);

            Console.WriteLine($"Result: {success}");
            if (success == false)
            {
                return Results.BadRequest("Whitebooard could not be created");
            }

            // Return a successful response
            return Results.Created($"/create-whiteboard/{whiteboardDto.learningComponenName}", whiteboardDto);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in the mapPost: {ex.Message}");
            Console.WriteLine($"Error in the mapPost: {ex.StackTrace}");
            return Results.BadRequest("Whiteboard could not be created: " + ex.Message);
        }
    }
    public static async Task<IResult> ModifyWhiteboardAsync(
        [FromServices] IWhiteboardService whiteboardService, WhiteboardDto whiteboardDto)
    {
        try
        {
             DomainWhiteboard whiteboard = new DomainWhiteboard(
             LComponentID.Create(whiteboardDto.learningComponentId),
             MediumName.Create(whiteboardDto.learningComponenName),
             Size.Create(whiteboardDto.sizeX),
             Size.Create(whiteboardDto.sizeY),
             Coordinate.Create(whiteboardDto.positionX),
             Coordinate.Create(whiteboardDto.positionY),
             Coordinate.Create(whiteboardDto.positionZ),
             Coordinate.Create(whiteboardDto.rotationX),
             Coordinate.Create(whiteboardDto.rotationY),
             GuidWrapper.Create(whiteboardDto.learningSpaceId.Value)
             );


            var success = await whiteboardService.ModifyWhiteboardAsync(whiteboard);

            if (success == false)
            {
                return Results.BadRequest("Whiteboard could not be modified");
            }

            return Results.Created($"/modify-AIAssistant/{whiteboardDto.learningComponenName}", whiteboardDto);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in the mapPut: {ex.Message}");
            Console.WriteLine($"Error in the mapPut: {ex.StackTrace}");
            return Results.BadRequest("Whiteboard could not be modified: " + ex.Message);
        }

    }

    public static async Task<IResult> DeleteWhiteboardAsync(
        [FromServices] IWhiteboardService whiteboardService, [FromBody ]WhiteboardDto whiteboardDto)
    {
        try
        {
            DomainWhiteboard whiteboard = new DomainWhiteboard(
             LComponentID.Create(whiteboardDto.learningComponentId),
             MediumName.Create(whiteboardDto.learningComponenName),
             Size.Create(whiteboardDto.sizeX),
             Size.Create(whiteboardDto.sizeY),
             Coordinate.Create(whiteboardDto.positionX),
             Coordinate.Create(whiteboardDto.positionY),
             Coordinate.Create(whiteboardDto.positionZ),
             Coordinate.Create(whiteboardDto.rotationX),
             Coordinate.Create(whiteboardDto.rotationY),
             GuidWrapper.Create(whiteboardDto.learningSpaceId.Value)
             );


            var success = await whiteboardService.DeleteWhiteboardAsync(whiteboard);

            if (success == false)
            {
                return Results.BadRequest("Whiteboard could not be deleted");
            }

            return Results.Created($"/modify-whiteboard/{whiteboardDto.learningComponenName}", whiteboardDto);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in the mapPut: {ex.Message}");
            Console.WriteLine($"Error in the mapPut: {ex.StackTrace}");
            return Results.BadRequest("Whiteboard could not be deleted: " + ex.Message);
        }

    }

    public static IEndpointRouteBuilder RegisterWhiteboardEndpoints(this IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder
            .MapGet("/list-whiteboards", GetWhiteboardsAsync)
            .WithName("List-Whiteboards")
            .WithTags("LearningComponentsEndpoints")
            .WithOpenApi();

        routeBuilder
            .MapPost("/create-whiteboard", CreateWhiteboardAsync)
            .WithName("Create-Whiteboards")
            .WithTags("LearningComponentsEndpoints")
            .WithOpenApi();

        routeBuilder
           .MapPost("/modify-whiteboards", ModifyWhiteboardAsync)
           .WithName("Modify-Whiteboards")
           .WithTags("LearningComponentsEndpoints")
           .WithOpenApi();

        routeBuilder
           .MapDelete("/Delete-whiteboards", DeleteWhiteboardAsync)
           .WithName("Delete-Whiteboards")
           .WithTags("LearningComponentsEndpoints")
           .WithOpenApi();


        return routeBuilder;
    }
}