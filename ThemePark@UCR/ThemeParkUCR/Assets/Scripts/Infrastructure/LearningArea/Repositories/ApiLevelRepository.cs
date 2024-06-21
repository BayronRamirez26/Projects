using Microsoft.Kiota.Abstractions;
using ModestTree;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.LearningArea.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.Shared.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Infrastructure.LearningArea.Mappers;
using static UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.LevelByBuilding.LevelByBuildingRequestBuilder;
using static UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.LevelById.LevelByIdRequestBuilder;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Infrastructure.LearningArea.Repositories
{
    /// US: PIIB2401G1-93 CAD-CRL-02 List building levels
    /// Task: PIIB2401G1-316 Create Levels sql repository on Infrastructure
    /// Christopher Viquez Aguilar
    /// Daniel Van der Laat Velez
    /// Francisco Ulate
    internal class ApiLevelRepository : ILevelRepository
    {
        private readonly ApiClientKiota _apiClient;

        public ApiLevelRepository(ApiClientKiota apiClient)
        {  
            _apiClient = apiClient;
        }

        public async Task<IEnumerable<Level>> GetLevelsFromBuildingAsync(
            LongName UniversityName, 
            LongName CampusName, 
            MediumName SiteName, 
            ShortName BuildingAcronym)
        {
            var requestConfiguration = new Action<RequestConfiguration<LevelByBuildingRequestBuilderGetQueryParameters>>(config =>
            {
                config.QueryParameters = new LevelByBuildingRequestBuilderGetQueryParameters
                {
                    UniversityName = UniversityName.Value,
                    CampusName = CampusName.Value,
                    SiteName = SiteName.Value,
                    BuildingAcronym = BuildingAcronym.Value
                };
            });

            var getAllLevels = await _apiClient.LevelByBuilding.GetAsync(requestConfiguration);

            var levelEntities = getAllLevels?.Select(LevelDtoMapper.ToEntity)
               ?? throw new NullReferenceException();
            return levelEntities;
        }

        public async Task<Level> GetLevelByIdAsync(Guid id)
        {
            var requestConfiguration = new Action<RequestConfiguration<LevelByIdRequestBuilderGetQueryParameters>>(config =>
            {
                config.QueryParameters = new LevelByIdRequestBuilderGetQueryParameters
                {
                    LevelId = id
                };
            });

            try
            {
                var levelDto = await _apiClient.LevelById.GetAsync(requestConfiguration);
                if (levelDto == null)
                {
                    throw new NullReferenceException();
                }

                Level level = LevelDtoMapper.ToEntity(levelDto);

                return level;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error with GetAsync {ex}");
                Console.WriteLine(ex.Message);

                return null;
            }
        }
    }
}
