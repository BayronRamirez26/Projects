using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UCR.ECCI.PI.ThemePark_UCR.Application.LearningArea.Services;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningArea.Dtos;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningArea.Mappers;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningArea.Requests;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningArea.Responses;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningArea.Handlers;

public static class BOTemplateEndpointHandlers
{
    public static async Task<GetBOTemplatesObjectTypesResponse> GetBOTemplatesObjectTypesAsync(
        [FromServices] IBOTemplateService templateService)
    {
        try
        {
            var result = await templateService
                .GetBOTemplatesObjectTypesAsync();

            var typesDto = result
                .Select(BOTemplateDtoMapper.FromMediumName);

            return new GetBOTemplatesObjectTypesResponse(typesDto);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in the mapGet: {ex.Message}");
            Console.WriteLine($"Error in the mapGet: {ex.StackTrace}");

            var emptyList = new List<string>();
            return new GetBOTemplatesObjectTypesResponse(emptyList);
        }
    }

    public static async Task<GetBOTemplatesPlanesResponse> GetBOTemplatesPlanesAsync(
        [FromServices] IBOTemplateService templateService)
    {
        try
        {
            var result = await templateService
                .GetBOTemplatesPlanesAsync();

            var typesDto = result
                .Select(BOTemplateDtoMapper.FromMediumName);

            return new GetBOTemplatesPlanesResponse(typesDto);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in the mapGet: {ex.Message}");
            Console.WriteLine($"Error in the mapGet: {ex.StackTrace}");

            var emptyList = new List<string>();
            return new GetBOTemplatesPlanesResponse(emptyList);
        }
    }

    public static async Task<GetAllBOTemplatesResponse> GetAllBOTemplatesAsync(
        [FromServices] IBOTemplateService templateService)
    {
        try
        {
            var result = await templateService
                .GetAllBOTemplatesAsync();

            var templatesDto = result
                .Select(BOTemplateDtoMapper.FromEntity);

            return new GetAllBOTemplatesResponse(templatesDto);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in the mapGet: {ex.Message}");
            Console.WriteLine($"Error in the mapGet: {ex.StackTrace}");
            
            var emptyList = new List<BOTemplateDto>();
            return new GetAllBOTemplatesResponse(emptyList);
        }
    }

    public static async Task<GetBOTemplatesOfTypeResponse> GetBOTemplatesOfTypeAsync(
        [FromServices] IBOTemplateService templateService, 
        [FromBody] GetBOTemplatesOfTypeRequest request)
    {
        try
        {
            var requestVO = BOTemplateMapper.ToMediumNameVO(request.ObjectType);
            var result = await templateService
                .GetBOTemplatesOfTypeAsync(requestVO);

            var templatesDto = result
                .Select(BOTemplateDtoMapper.FromEntity);

            return new GetBOTemplatesOfTypeResponse(templatesDto);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in the mapPut: {ex.Message}");
            Console.WriteLine($"Error in the mapPut: {ex.StackTrace}");
            
            var emptyList = new List<BOTemplateDto>();
            return new GetBOTemplatesOfTypeResponse(emptyList);
        }
    }

    public static async Task<GetBOTemplatesOfPlaneResponse> GetBOTemplatesOfPlaneAsync(
        [FromServices] IBOTemplateService templateService, 
        [FromBody] GetBOTemplatesOfPlaneRequest request)
    {
        try
        {
            var requestVO = BOTemplateMapper.ToMediumNameVO(request.Plane);
            var result = await templateService
                .GetBOTemplatesOfPlaneAsync(requestVO);

            var templatesDto = result
                .Select(BOTemplateDtoMapper.FromEntity);

            return new GetBOTemplatesOfPlaneResponse(templatesDto);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in the mapPut: {ex.Message}");
            Console.WriteLine($"Error in the mapPut: {ex.StackTrace}");
            
            var emptyList = new List<BOTemplateDto>();
            return new GetBOTemplatesOfPlaneResponse(emptyList);
        }
    }

    public static async Task<GetBOTemplatesOfTypeAndPlaneResponse> GetBOTemplatesOfTypeAndPlaneAsync(
        [FromServices] IBOTemplateService templateService, 
        [FromBody] GetBOTemplatesOfTypeAndPlaneRequest request)
    {
        try
        {
            var objectTypeVO = BOTemplateMapper.ToMediumNameVO(request.ObjectType);
            var planeVO = BOTemplateMapper.ToMediumNameVO(request.Plane);
            var result = await templateService
                .GetBOTemplatesOfTypeAndPlaneAsync(objectTypeVO, planeVO);

            var templatesDto = result
                .Select(BOTemplateDtoMapper.FromEntity);

            return new GetBOTemplatesOfTypeAndPlaneResponse(templatesDto);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in the mapPut: {ex.Message}");
            Console.WriteLine($"Error in the mapPut: {ex.StackTrace}");
            
            var emptyList = new List<BOTemplateDto>();
            return new GetBOTemplatesOfTypeAndPlaneResponse(emptyList);
        }
    }
}
