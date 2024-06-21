using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Application.LearningArea.Services
{
    public interface IBuildingService
    {
        public Task<IEnumerable<Building>> GetNeighbourBuildingsFromBuilding(Building currentBuilding);

        public Task<IEnumerable<Building>> GetBuildingsFromSiteAsync(
            LongName universityName,
            LongName campusName,
            MediumName siteName);

        public Task<Guid> GetBuildingIdAsync(
            LongName universityName,
            LongName campusName,
            MediumName siteName,
            ShortName buildingAcronym);
    }
}
