using Microsoft.AspNetCore.Mvc;
using UCR.ECCI.PI.ThemePark_UCR.Application.LearningArea.Services;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningArea.Mappers;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningArea.Requests;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningArea.Responses;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningArea.Handlers;

public static class BuildingEndpointHandlers
{

    public static async Task<GetBuildingResponse> CreateBuildingAsync(
        [FromServices] IBuildingService buildingService, [FromBody] GetBuildingRequest buildingRequest)
    {
        try
        {
            // return await buildingService.CreateBuildingAsync(buildingDto);
            var success = await buildingService.CreateBuildingAsync(BuildingMapper.ToEntity(buildingRequest.BuildingDto));

            Console.WriteLine($"Result: {success}");
            if (success == false)
            {
                return new GetBuildingResponse(false, StatusCodes.Status400BadRequest, "El edificio colisiona con otro.");
            }

            // Return a successful response
            return new GetBuildingResponse(true, StatusCodes.Status201Created, "Edificio creado exitosamente");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in the mapPost: {ex.Message}");
            Console.WriteLine($"Error in the mapPost: {ex.StackTrace}");
            return new GetBuildingResponse(false, StatusCodes.Status400BadRequest, "No se pudo guardar el edificio, este ya fue creado.");
        }
    }


    public static async Task<GetBuildingsResponse> GetAllBuildingsAsync(
        [FromServices] IBuildingService buildingService)
    {
        var buildingsEntities = await buildingService.GetAllBuildingsAsync();
        var buildingDtos = buildingsEntities.Select(BuildingDtoMapper.FromEntity);

        return new GetBuildingsResponse(buildingDtos);
    }


    public static async Task<GetBuildingResponse> UpdateBuildingAsync(
        [FromServices] IBuildingService buildingService, [FromBody] GetBuildingRequest buildingRequest)
    {
        try
        {
            var success = await buildingService.UpdateBuildingAsync(BuildingMapper.ToEntity(buildingRequest.BuildingDto));

            if (success == false)
            {
                return new GetBuildingResponse(false, StatusCodes.Status400BadRequest, "El edificio colisiona con otro.");
            }

            // Return a successful response
            return new GetBuildingResponse(true, StatusCodes.Status200OK, "Edificio modificado exitosamente");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in the mapPut: {ex.Message}");
            Console.WriteLine($"Error in the mapPut: {ex.StackTrace}");
            return new GetBuildingResponse(false, StatusCodes.Status400BadRequest, "No se pudo modificar el edificio, este tiene el nombre ya tomado.");
        }

    }

    public static async Task<bool> DeleteBuildingAsync(
        [FromServices] IBuildingService buildingService, [FromBody] GetBuildingDeleteRequest deleteRequest)
    {
        try
        {
            var buildingsEntities = await buildingService.DeleteBuildingAsync(
                BuildingMapper.ToLongNameVO(deleteRequest.UniversityName),
                BuildingMapper.ToLongNameVO(deleteRequest.CampusName),
                BuildingMapper.ToMediumNameVO(deleteRequest.SiteName),
                BuildingMapper.ToShortNameVO(deleteRequest.BuildingAcronym)
            );
            return buildingsEntities;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }

    }


    public static async Task<Guid> GetBuildingIdAsync(
        [FromServices] IBuildingService buildingService,
        string universityName,
        string campusName,
        string siteName,
        string buildingAcronym)
    {
        try
        {
            return await buildingService.GetBuildingIdAsync(
                LongName.Create(universityName),
                LongName.Create(campusName),
                MediumName.Create(siteName),
                ShortName.Create(buildingAcronym));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return Guid.Empty;
        }
    }

    public static async Task<GetBuildingsResponse> GetBuildingsFromSiteAsync(
        [FromServices] IBuildingService buildingService,
        [FromBody] GetBuildingsFromSiteRequest getBuildingsFromSiteRequest)
    {
        var buildingsEntities = await buildingService.GetBuildingsFromSiteAsync(
            LongName.Create(getBuildingsFromSiteRequest.UniversityName),
            LongName.Create(getBuildingsFromSiteRequest.CampusName),
            MediumName.Create(getBuildingsFromSiteRequest.SiteName)
        );
        var buildingDtos = buildingsEntities.Select(BuildingDtoMapper.FromEntity);

        return new GetBuildingsResponse(buildingDtos);
    }

    public static async Task<GetBuildingDetailsResponse> GetBuildingDetailsAsync(
        [FromServices] IBuildingService buildingService,
        [FromBody] GetBuildingDetailsRequest request)
    {
        try
        {
            var buildingEntity = await buildingService.GetBuildingDetailsAsync(
                GuidValueObject.Create(request.BuildingId)
            );
            var buildingDto = BuildingDtoMapper.FromEntity(buildingEntity);
            return new GetBuildingDetailsResponse(buildingDto);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            var invalidDto = BuildingDtoMapper.FromEntity(Building.Invalid);
            return new GetBuildingDetailsResponse(invalidDto);
        }
    }
}

