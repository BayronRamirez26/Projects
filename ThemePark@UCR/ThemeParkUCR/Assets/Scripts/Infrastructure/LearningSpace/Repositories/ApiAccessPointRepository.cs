using Microsoft.Kiota.Abstractions;
using System;
using System.Threading.Tasks;
using System.Linq;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.LearningSpace.Entities.Wrappers;
using static UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.ListAccessPointsFromLevel.ListAccessPointsFromLevelRequestBuilder;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.LearningSpace.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Infrastructure.LearningSpaces.Mappers;
using System.Collections.Generic;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Infrastructure.LearningSpace.Repositories
{
    /// <summary>
    /// Interface with all services of AccesPoint
    /// </summary>
    public class ApiAccessPointRepository : IAccessPointRepository
    {

        private readonly ApiClientKiota _apiClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClientLearningSpaceRepository"/> class with the specified API client.
        /// </summary>
        /// <param name="apiClient">The API client used to communicate with the backend.</param>
        public ApiAccessPointRepository(ApiClientKiota apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IEnumerable<AccessPoint>> GetAccessPointsFromLevelAsync(Guid id)
        {
            // build the request configuration and send the request
            // ListAccessPointsFromLevelRequestBuilderGetQueryParameters
            var requestConfiguration = new Action<RequestConfiguration<ListAccessPointsFromLevelRequestBuilderGetQueryParameters>>(config =>
            {
                config.QueryParameters = new ListAccessPointsFromLevelRequestBuilderGetQueryParameters
                {
                    Guid = id
                };
            });

            var accessPointDtos = await _apiClient.ListAccessPointsFromLevel.GetAsync(requestConfiguration);
            var accessPoints = accessPointDtos?.Select(AccessPointDtoMapper.ToEntity)
               ?? throw new NullReferenceException();
            return accessPoints;
        }
    }
}
