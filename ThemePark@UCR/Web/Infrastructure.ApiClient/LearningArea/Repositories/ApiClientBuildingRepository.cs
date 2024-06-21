using Microsoft.Kiota.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.Responses;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Models;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.LearningArea.Mappers;
using static UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.BuildingId.BuildingIdRequestBuilder;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Buildings.Repositories;

internal class ApiClientBuildingRepository : IBuildingRepository
{
    private readonly ApiClientKiota _apiClient;

    public ApiClientBuildingRepository(ApiClientKiota apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<IEnumerable<DomainWeb.LearningArea.Entities.Building>> GetAllBuildingsAsync()
    {
        var response = await _apiClient.ListBuildings.GetAsync();

        var buildingEntities = response?.Buildings?.Select(BuildingDtoMapper.ToEntity)
            ?? throw new NullReferenceException();

        // Print the color of every building
        Console.WriteLine("ApiClientBuildingRepository:");
        foreach (var building in buildingEntities)
        {
            Console.WriteLine($"Building {building.BuildingName.Value} has walls color {building.WallsColor.Value}" +
                $" and roof color {building.RoofColor.Value}");
        }

        return buildingEntities;
    }


    public async Task<HttpResponse> CreateBuildingAsync(DomainWeb.LearningArea.Entities.Building building)
    {
        try
        {
            var createBuildingCreateRequest = new GetBuildingRequest
            {
                BuildingDto = BuildingToKiotaDtoMapper.ToDto(building)
            };

            var apiResponse = await _apiClient.CreateBuilding.PostAsync(createBuildingCreateRequest);
            if (apiResponse == null)
            {
                return new HttpResponse(false, 400, "Error al crear el edificio.");
            }
            var domainResponse = new HttpResponse(apiResponse.Success ?? false, apiResponse.HttpStatusCode, apiResponse.Message);
            return domainResponse;

        }
        catch (Exception ex)
        {
            throw new Exception("Error al crear la carrera", ex);
        }
    }

    // TODO: this method should receive only the building PK
    public async Task<bool> DeleteBuildingAsync(DomainWeb.LearningArea.Entities.Building building)
    {
        try
        {
            var buildingDeleteRequest = new GetBuildingDeleteRequest
            {
                BuildingAcronym = building.BuildingAcronym.Value,
                CampusName = building.CampusName.Value,
                SiteName = building.SiteName.Value,
                UniversityName = building.UniversityName.Value
            };

            var deleteBuildingResponse = await _apiClient.DeleteBuilding.DeleteAsync(buildingDeleteRequest);

            if (deleteBuildingResponse != null)
            {
                bool response = (bool)deleteBuildingResponse;
                return response;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error al crear la carrera", ex);
        }
    }

    public async Task<HttpResponse> UpdateBuildingAsync(DomainWeb.LearningArea.Entities.Building building)
    {
        try
        {
            var createBuildingCreateRequest = new GetBuildingRequest
            {
                BuildingDto = BuildingToKiotaDtoMapper.ToDto(building)
            };

            var apiResponse = await _apiClient.UpdateBuilding.PutAsync(createBuildingCreateRequest);
            if (apiResponse == null)
            {
                return new HttpResponse(false, 400, "Error al modificar el edificio.");
            }
            var domainResponse = new HttpResponse(apiResponse.Success ?? false, apiResponse.HttpStatusCode, apiResponse.Message);
            return domainResponse;

        }
        catch (Exception ex)
        {
            throw new Exception("Error al crear la carrera", ex);
        }
    }

    public async Task<Guid> GetBuildingId(
        DomainWeb.Shared.ValueObjects.LongName universityName,
        DomainWeb.Shared.ValueObjects.LongName campusName,
        DomainWeb.Shared.ValueObjects.MediumName siteName,
        DomainWeb.Shared.ValueObjects.ShortName buildingAcronym)
    {
        var requestConfiguration = new Action<RequestConfiguration<BuildingIdRequestBuilderGetQueryParameters>>(config =>
        {
            config.QueryParameters = new BuildingIdRequestBuilderGetQueryParameters
            {
                UniversityName = universityName.Value,
                CampusName = campusName.Value,
                SiteName = siteName.Value,
                BuildingAcronym = buildingAcronym.Value
            };
        });

        var buildingId = await _apiClient.BuildingId.GetAsync(requestConfiguration);
        Console.WriteLine($"ApiClient BuildingId: {buildingId}");

        return buildingId ?? throw new NullReferenceException();
    }

    public async Task<DomainWeb.LearningArea.Entities.Building> GetBuildingDetailsAsync(
        DomainWeb.Shared.ValueObjects.GuidValueObject buildingId)
    {
        GetBuildingDetailsRequest request = new GetBuildingDetailsRequest
        {
            BuildingId = buildingId.Value
        };

        var response = await _apiClient.BuildingDetails.PutAsync(request);
        return BuildingDtoMapper.ToEntity(response.BuildingDetails);
    }
}
