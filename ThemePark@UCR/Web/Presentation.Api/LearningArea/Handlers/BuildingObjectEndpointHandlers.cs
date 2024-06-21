using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using UCR.ECCI.PI.ThemePark_UCR.Application.LearningArea.Services;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningArea.Dtos;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningArea.Mappers;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningArea.Requests;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningArea.Responses;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningArea.Handlers;

public static class BuildingObjectEndpointHandlers
{
    public static async Task<GetAllBuildingObjectsResponse> GetAllBuildingObjectsAsync(
        [FromServices] IBuildingObjectService buildingObjectService)
    {
        try
        {
            var result = await buildingObjectService
                .GetAllBuildingObjectsAsync();

            var objectsDto = result
                .Select(BuildingObjectDtoMapper.FromEntity);

            return new GetAllBuildingObjectsResponse(objectsDto);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in the mapGet: {ex.Message}");
            Console.WriteLine($"Error in the mapGet: {ex.StackTrace}");

            var emptyList = new List<BuildingObjectDto>();
            return new GetAllBuildingObjectsResponse(emptyList);
        }
    }

    public static async Task<GetBuildingObjectsFromLevelResponse> GetBuildingObjectsFromLevelAsync(
        [FromServices] IBuildingObjectService buildingObjectService,
        [FromBody] GetBuildingObjectsFromLevelRequest request)
    {
        try
        {
            var requestVO = BuildingObjectMapper.ToGuidValueObjectVO(request.LevelId);
            var result = await buildingObjectService
                .GetBuildingObjectsFromLevelAsync(requestVO);

            var objectsDto = result
                .Select(BuildingObjectDtoMapper.FromEntity);

            return new GetBuildingObjectsFromLevelResponse(objectsDto);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in the mapPut: {ex.Message}");
            Console.WriteLine($"Error in the mapPut: {ex.StackTrace}");

            var emptyList = new List<BuildingObjectDto>();
            return new GetBuildingObjectsFromLevelResponse(emptyList);
        }
    }

    /*public async Task<BuildingObject> GetBuildingObjectDetailsAsync(
        GuidValueObject buildingId)*/

    public static async Task<GetBuildingObjectDetailsResponse> GetBuildingObjectDetailsAsync(
        [FromServices] IBuildingObjectService buildingObjectService,
        [FromBody] GetBuildingObjectDetailsRequest request)
    {
        try
        {
            var requestVO = BuildingObjectMapper.ToGuidValueObjectVO(request.ObjectId);
            var result = await buildingObjectService
                .GetBuildingObjectDetailsAsync(requestVO);

            var detailsDto = BuildingObjectDtoMapper.FromEntity(result);
            return new GetBuildingObjectDetailsResponse(detailsDto);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in the mapPut: {ex.Message}");
            Console.WriteLine($"Error in the mapPut: {ex.StackTrace}");

            return new GetBuildingObjectDetailsResponse(null);
        }
    }

    public static async Task<AddBuildingObjectToLevelResponse> AddBuildingObjectToLevelAsync(
        [FromServices] IBuildingObjectService buildingObjectService,
        [FromBody] AddBuildingObjectToLevelRequest request)
    {
        try
        {
            var requestEntity = BuildingObjectMapper.ToEntity(request.BuildingObject);
            var result = await buildingObjectService
                .AddBuildingObjectToLevelAsync(requestEntity);

            return new AddBuildingObjectToLevelResponse(result.Item1, result.Item2);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in the mapPut: {ex.Message}");
            Console.WriteLine($"Error in the mapPut: {ex.StackTrace}");

            return new AddBuildingObjectToLevelResponse(false, "No se pudo agregar el objeto al nivel.");
        }
    }

    public static async Task<ModifyBuildingObjectResponse> ModifyBuildingObjectAsync(
        [FromServices] IBuildingObjectService buildingObjectService,
        [FromBody] ModifyBuildingObjectRequest request)
    {
        try
        {
            var requestEntity = BuildingObjectMapper.ToEntity(request.BuildingObject);
            var result = await buildingObjectService
                .ModifyBuildingObjectAsync(requestEntity);

            return new ModifyBuildingObjectResponse(result.Item1, result.Item2);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in the mapPost: {ex.Message}");
            Console.WriteLine($"Error in the mapPost: {ex.StackTrace}");

            return new ModifyBuildingObjectResponse(false, "No se pudo modificar el objeto.");
        }
    }

    public static async Task<DeleteBuildingObjectResponse> DeleteBuildingObjectAsync(
        [FromServices] IBuildingObjectService buildingObjectService,
        [FromBody] DeleteBuildingObjectRequest request)
    {
        try
        {
            var requestEntity = BuildingObjectMapper.ToEntity(request.BuildingObject);
            var result = await buildingObjectService
                .DeleteBuildingObjectAsync(requestEntity);

            return new DeleteBuildingObjectResponse(result.Item1, result.Item2);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in the mapDelete: {ex.Message}");
            Console.WriteLine($"Error in the mapDelete: {ex.StackTrace}");

            return new DeleteBuildingObjectResponse(false, "No se pudo eliminar el objeto.");
        }
    }
}
