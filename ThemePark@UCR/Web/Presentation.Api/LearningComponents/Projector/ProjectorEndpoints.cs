using Microsoft.AspNetCore.Mvc;
using UCR.ECCI.PI.ThemePark_UCR.Application.LearningComponents.Services;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningComponents.Projector.Dtos;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningComponents.Whiteboard.Responses;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.Projector.Mappers;
using DomainProjector = UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Entities.Projector;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningComponents.Projector;
public static class ProjectorEndpoints
{
    public static async Task<GetProjectorResponse> GetProjectorsAsync([FromServices] IProjectorService projectorService)
    {
        var projectorEntities = await projectorService.GetProjectorsAsync();
        var projectorDto = projectorEntities.Select(ProjectorDtoMapper.FromEntitiy);
        return new GetProjectorResponse(projectorDto);
    }

    public static async Task<IResult> CreateProjectorAsync([FromServices] IProjectorService projectorService, ProjectorDto projectorDto)
    {
        try
        {
            DomainProjector projector = new DomainProjector(
             LComponentID.Create(projectorDto.learningComponentId),
             MediumName.Create(projectorDto.learningComponenName),
             Size.Create(projectorDto.sizeX),
             Size.Create(projectorDto.sizeY),
             Coordinate.Create(projectorDto.positionX),
             Coordinate.Create(projectorDto.positionY),
             Coordinate.Create(projectorDto.positionZ),
             Coordinate.Create(projectorDto.rotationX),
             Coordinate.Create(projectorDto.rotationY),
             GuidWrapper.Create(projectorDto.learningSpaceId.Value)
             );

            var success = await projectorService.CreateProjectorsAsync(projector);

            Console.WriteLine($"Result: {success}");
            if (success == false)
            {
                return Results.BadRequest("Projector could not be created");
            }

            // Return a successful response
            return Results.Created($"/create-projector/{projectorDto.learningComponenName}", projectorDto);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in the mapPost: {ex.Message}");
            Console.WriteLine($"Error in the mapPost: {ex.StackTrace}");
            return Results.BadRequest("Projector could not be created: " + ex.Message);
        }
    }

    public static async Task<IResult> ModifyProjectorAsync(
        [FromServices] IProjectorService projectorService, ProjectorDto projectorDto)
    {
        try
        {
            DomainProjector projector = new DomainProjector(
             LComponentID.Create(projectorDto.learningComponentId),
             MediumName.Create(projectorDto.learningComponenName),
             Size.Create(projectorDto.sizeX),
             Size.Create(projectorDto.sizeY),
             Coordinate.Create(projectorDto.positionX),
             Coordinate.Create(projectorDto.positionY),
             Coordinate.Create(projectorDto.positionZ),
             Coordinate.Create(projectorDto.rotationX),
             Coordinate.Create(projectorDto.rotationY),
             GuidWrapper.Create(projectorDto.learningSpaceId.Value)
             );

            var success = await projectorService.ModifyProjectorAsync(projector);

            if (success == false)
            {
                return Results.BadRequest("Projector could not be modified");
            }

            return Results.Created($"/modify-projector/{projectorDto.learningComponenName}", projectorDto);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in the mapPut: {ex.Message}");
            Console.WriteLine($"Error in the mapPut: {ex.StackTrace}");
            return Results.BadRequest("projector could not be modified: " + ex.Message);
        }

    }

    public static async Task<IResult> DeleteProjectorAsync(
        [FromServices] IProjectorService projectorService, [FromBody] ProjectorDto projectorDto)
    {
        try
        {
            DomainProjector projector = new DomainProjector(
             LComponentID.Create(projectorDto.learningComponentId),
             MediumName.Create(projectorDto.learningComponenName),
             Size.Create(projectorDto.sizeX),
             Size.Create(projectorDto.sizeY),
             Coordinate.Create(projectorDto.positionX),
             Coordinate.Create(projectorDto.positionY),
             Coordinate.Create(projectorDto.positionZ),
             Coordinate.Create(projectorDto.rotationX),
             Coordinate.Create(projectorDto.rotationY),
             GuidWrapper.Create(projectorDto.learningSpaceId.Value)
             );

            var success = await projectorService.DeleteProjectorAsync(projector);

            if (success == false)
            {
                return Results.BadRequest("Projector could not be deleted");
            }

            return Results.Created($"/Delete-projector/{projectorDto}", projectorDto);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in the mapPut: {ex.Message}");
            Console.WriteLine($"Error in the mapPut: {ex.StackTrace}");
            return Results.BadRequest("Projector could not be deleted: " + ex.Message);
        }

    }

    public static IEndpointRouteBuilder RegisterProjectorEndpoints(this IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder
            .MapGet("/list-projectors", GetProjectorsAsync)
            .WithName("List-Projectors")
            .WithTags("LearningComponentsEndpoints")
            .WithOpenApi();

        routeBuilder
            .MapPost("/create-projector", CreateProjectorAsync)
            .WithName("Create-Projectors")
            .WithTags("LearningComponentsEndpoints")
            .WithOpenApi();

        routeBuilder
            .MapPost("/modify-projector", ModifyProjectorAsync)
            .WithName("Modify-Projectors")
            .WithTags("LearningComponentsEndpoints")
            .WithOpenApi();
        routeBuilder
            .MapDelete("/delete-projector", DeleteProjectorAsync)
            .WithName("Delete-Projectors")
            .WithTags("LearningComponentsEndpoints")
            .WithOpenApi();


        return routeBuilder;
    }
}