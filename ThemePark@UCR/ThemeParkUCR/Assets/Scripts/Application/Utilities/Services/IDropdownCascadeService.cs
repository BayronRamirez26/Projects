
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Application.Utilities.Services
{
    /// <summary>
    /// Defines service functions for managing cascade requests
    /// </summary>
    public interface IDropdownCascadeService
    {
        /// <summary>
        /// This method return a list of campus releated to a university
        /// </summary>
        /// <param name="university">University string requiered to search</param>
        /// <returns>A list of all campus releated to university</returns>
        public Task<IEnumerable<string>> GetCampusFromUniversity(string university);

        /// <summary>
        /// This method return a list of sites releated to a campus
        /// </summary>
        /// <param name="campus">Campus string requiered to search</param>
        /// <returns>A list of all sites releated to campus</returns>
        public Task<IEnumerable<string>> GetSitesFromCampus(string campus);

    }
}
