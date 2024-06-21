using System.Collections.Generic;
using System.Threading.Tasks;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.LearningSpace.Entities;
using System;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Application.LearningArea.Services
{
    public interface IAccessPointService
    {
        public Task<IEnumerable<AccessPoint>> GetAccessPointsFromLevelAsync(Guid id);

    }
}
