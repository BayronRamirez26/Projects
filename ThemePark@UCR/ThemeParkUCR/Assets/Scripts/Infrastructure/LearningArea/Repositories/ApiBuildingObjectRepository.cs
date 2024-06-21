using System.Collections.Generic;
using System.Threading.Tasks;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.LearningArea.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Infrastructure.LearningArea.Repositories
{
    internal class ApiBuildingObjectRepository : IBuildingObjectRepository
    {
        private readonly ApiClientKiota _apiClient;

        public ApiBuildingObjectRepository(ApiClientKiota apiClient)
        {
            _apiClient = apiClient;
        }

        public Task<IEnumerable<BuildingObject>> GetAllBuildingObjectsAsync()
        {
            throw new System.NotImplementedException();
        }


        public Task<IEnumerable<BuildingObject>> GetBuildingObjectsFromLevelAsync(
            GuidValueObject levelId)
        {
            throw new System.NotImplementedException();
        }

        public Task<BuildingObject> GetBuildingObjectDetailsAsync(
            GuidValueObject buildingId)
        {
            throw new System.NotImplementedException();
        }
    }
}
