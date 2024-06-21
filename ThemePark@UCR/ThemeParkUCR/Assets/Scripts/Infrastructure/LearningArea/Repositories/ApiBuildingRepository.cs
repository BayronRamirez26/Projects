using Microsoft.Kiota.Abstractions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.LearningArea.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.Shared.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Infrastructure.ApiClient.LearningArea.Mappers;
using static UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.BuildingId.BuildingIdRequestBuilder;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Infrastructure.LearningArea.Repositories
{

    internal class ApiBuildingRepository : IBuildingRepository
    {
        // DI
        private readonly ApiClientKiota _apiClient;

        public ApiBuildingRepository(ApiClientKiota apiClient)
        {
            _apiClient = apiClient;
        }

        public Task<IEnumerable<Building>> GetNeighbourBuildingsFromBuilding(Building currentBuilding)
        {
            //return await _apiClient.GetNeighbourBuildingsFromBuildingAsync(currentBuilding);
            throw new System.Exception("Not implemented");
        }

        public async Task<IEnumerable<Building>> GetBuildingsFromSiteAsync(
            LongName universityName,
            LongName campusName,
            MediumName siteName)
        {

            var response = await _apiClient.BuildingFromSite.PostAsync(new ThemePark_UCR.Infrastructure.ApiClient.Client.Models.GetBuildingsFromSiteRequest
            {
                UniversityName = universityName.Value,
                CampusName = campusName.Value,
                SiteName = siteName.Value
            });

            var buildings = response?.Buildings.Select(BuildingDtoMapper.ToEntity)
                ?? throw new NullReferenceException();

            return buildings ?? throw new NullReferenceException();
        }
      
        public async Task<Guid> GetBuildingIdAsync(
            LongName universityName,
            LongName campusName,
            MediumName siteName,
            ShortName buildingAcronym)
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
    }
}
