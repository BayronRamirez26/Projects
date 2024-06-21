using UCR.ECCI.PI.ThemePark_UCR.Unity.Application.LearningArea.Services;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.LearningArea.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.Shared.ValueObjects;
using System;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Application.LearningArea.Services
{
    /*
     Actividad 3 Pair Programming
    Sara Espinoza B92771
    Jorge Sagot C12565
    * CAD-CRB-03 Modify properties 
    * CAD-CRB-04 Delete Building
    * CAD-CRB-14 Building colissions on update
     */

    public class BuildingService : IBuildingService
    {
        private readonly IBuildingRepository _buildingRepository;

        public BuildingService(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }

        public Task<IEnumerable<Building>> GetNeighbourBuildingsFromBuilding(Building currentBuilding)
        {
            return _buildingRepository.GetNeighbourBuildingsFromBuilding(currentBuilding);
        }

        public Task<IEnumerable<Building>> GetBuildingsFromSiteAsync(
            LongName universityName,
            LongName campusName,
            MediumName siteName)
        {
            return _buildingRepository.GetBuildingsFromSiteAsync(
                universityName, 
                campusName, 
                siteName);
        }

        public Task<Guid> GetBuildingIdAsync(
            LongName universityName,
            LongName campusName,
            MediumName siteName,
            ShortName buildingAcronym)
        {
            return _buildingRepository.GetBuildingIdAsync(
                universityName, 
                campusName, 
                siteName,
                buildingAcronym);
        }
    }
}
