
using Microsoft.Kiota.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.Utilities.Repositories;
using static UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.GetCampusofuniversity.GetCampusofuniversityRequestBuilder;
using static UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.GetSiteofcampus.GetSiteofcampusRequestBuilder;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Infrastructure.Utilities.Repositories
{
    internal class ApiDropdownCascadeRepository : IDropdownCascadeRepository
    {
        // DI
        private readonly ApiClientKiota _apiClient;

        public ApiDropdownCascadeRepository(ApiClientKiota apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IEnumerable<string>> GetCampusFromUniversity(string university)
        {
            try
            {
                // Configurar el requestConfiguration con el input
                var requestConfiguration = new Action<RequestConfiguration<GetCampusofuniversityRequestBuilderPostQueryParameters>>(config =>
                {
                    config.QueryParameters = new GetCampusofuniversityRequestBuilderPostQueryParameters
                    {
                        Input = university
                    };
                });
                var output = await _apiClient.GetCampusofuniversity.PostAsync(requestConfiguration);
                return output;

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error trying to get PostAsync statement");
            }

        }

        /// <summary>
        /// Get the sites from a campus
        /// </summary>
        /// <param name="campus"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<IEnumerable<string>> GetSitesFromCampus(string campus)
        {
            try
            {
                // Configurar el requestConfiguration con el input
                var requestConfiguration = new Action<RequestConfiguration<GetSiteofcampusRequestBuilderPostQueryParameters>>(config =>
                {
                    config.QueryParameters = new GetSiteofcampusRequestBuilderPostQueryParameters
                    {
                        Input = campus
                    };
                });
                var output = await _apiClient.GetSiteofcampus.PostAsync(requestConfiguration);
                return output;

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error trying to get PostAsync statement");
            }

        }

    }
}

