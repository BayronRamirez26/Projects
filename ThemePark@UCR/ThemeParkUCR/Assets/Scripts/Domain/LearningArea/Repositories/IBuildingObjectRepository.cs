using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.LearningArea.Repositories
{
    public interface IBuildingObjectRepository
    {
        public Task<IEnumerable<BuildingObject>> GetAllBuildingObjectsAsync();

        public Task<IEnumerable<BuildingObject>> GetBuildingObjectsFromLevelAsync(
            GuidValueObject levelId);

        public Task<BuildingObject> GetBuildingObjectDetailsAsync(
            GuidValueObject buildingId);

    }
}
