using Microsoft.Kiota.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Repositories;
using static UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.GetBuilding.GetBuildingRequestBuilder;
using static UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.GetBuildingofsite.GetBuildingofsiteRequestBuilder;
using static UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.GetCampusofuniversity.GetCampusofuniversityRequestBuilder;
using static UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.GetSiteofcampus.GetSiteofcampusRequestBuilder;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.LearningSpaces.Repositories;

/// <summary>
/// Repository implementation for interacting with learning space cascade data through an API client.
/// </summary>
public class ApiClientLearningSpaceCascadeRepository : ILearningSpaceCascadeRepository
{
    private readonly ApiClientKiota _apiClient;

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiClientLearningSpaceCascadeRepository"/> class with the specified API client.
    /// </summary>
    /// <param name="apiClient">The API client used to communicate with the backend.</param>
    public ApiClientLearningSpaceCascadeRepository(ApiClientKiota apiClient)
    {
        _apiClient = apiClient;
    }

    /// <summary>
    /// Get the campus from a university
    /// </summary>
    /// <param name="university"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
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

    /// <summary>
    /// Get the buildings from a site
    /// </summary>
    /// <param name="site"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public async Task<IEnumerable<string>> GetBuildingsFromSite(string site)
    {
        try
        {
            // Configurar el requestConfiguration con el input
            var requestConfiguration = new Action<RequestConfiguration<GetBuildingofsiteRequestBuilderPostQueryParameters>>(config =>
            {
                config.QueryParameters = new GetBuildingofsiteRequestBuilderPostQueryParameters
                {
                    Input = site
                };
            });
            var output = await _apiClient.GetBuildingofsite.PostAsync(requestConfiguration);
            return output;

        }
        catch (Exception ex)
        {
            throw new ArgumentException("Error trying to get PostAsync statement");
        }
        
    }

    public async Task<IEnumerable<Level>> GetLevelFromBuilding(Building building)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<string>> GetBuilding(string site, string campus)
    {
        try
        {
            // Configurar el requestConfiguration con el input
            var requestConfiguration = new Action<RequestConfiguration<GetBuildingRequestBuilderGetQueryParameters>>(config =>
            {
                config.QueryParameters = new GetBuildingRequestBuilderGetQueryParameters
                {
                    CampusName = campus,
                    SiteName = site
                };
            });

            var output = await _apiClient.GetBuilding.GetAsync(requestConfiguration);
            return output;
        }
        catch (Exception ex)
        {
            throw new ArgumentException("Error trying to get PostAsync statement");
        }
    }
}
