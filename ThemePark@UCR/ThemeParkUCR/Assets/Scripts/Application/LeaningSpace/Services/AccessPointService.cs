using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.LearningArea.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.LearningSpace.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Application.LearningArea.Services
{

    public class AccessPointService : IAccessPointService
    {
        private readonly IAccessPointRepository _accessPointRepository;

        public AccessPointService(IAccessPointRepository accessPointRepository)
        {
            _accessPointRepository = accessPointRepository;
        }

        public Task<IEnumerable<AccessPoint>> GetAccessPointsFromLevelAsync(Guid id)
        {
            return _accessPointRepository.GetAccessPointsFromLevelAsync(id);
        }
    }
}
