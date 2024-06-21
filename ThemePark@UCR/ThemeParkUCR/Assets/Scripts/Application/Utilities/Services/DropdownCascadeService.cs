
using System.Collections.Generic;
using System.Threading.Tasks;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.Utilities.Repositories;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Application.Utilities.Services
{
    /// <summary>
    /// This class makes all requests to repository about cascade on create learning space
    /// </summary>
    internal class DropdownCascadeService : IDropdownCascadeService
    {
        /// <summary>
        /// Instance for make request in database about cascade
        /// </summary>
        private readonly IDropdownCascadeRepository _cascadeRepository;

        /// <summary>
        /// Primary constructor
        /// </summary>
        /// <param name="cascadeRepository">ILearningSapceCascadeRepository instance neccesary</param>
        public DropdownCascadeService(IDropdownCascadeRepository cascadeRepository)
        {
            _cascadeRepository = cascadeRepository;
        }

        /// <summary>
        /// This method return a list of campus releated to a university
        /// </summary>
        /// <param name="university">University string requiered to search</param>
        /// <returns>A list of all campus releated to university</returns>
        public async Task<IEnumerable<string>> GetCampusFromUniversity(string university)
        {
            return await _cascadeRepository.GetCampusFromUniversity(university);
        }

        /// <summary>
        /// This method return a list of sites releated to a campus
        /// </summary>
        /// <param name="campus">Campus string requiered to search</param>
        /// <returns>A list of all sites releated to campus</returns>
        public async Task<IEnumerable<string>> GetSitesFromCampus(string campus)
        {
            return await _cascadeRepository.GetSitesFromCampus(campus);
        }
    
    }
}
