using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.LearningSpace.Entities.Wrappers;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.LearningSpace.Repositories
{
    /// <summary>
    /// Interface with all services of AccesPoint
    /// </summary>
    public interface IAccessPointRepository
    {
        public Task<IEnumerable<AccessPoint>> GetAccessPointsFromLevelAsync(Guid id);
    }
}
