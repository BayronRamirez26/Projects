using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.SiteProperties;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.LearningArea.Repositories;


public class ApiClientSiteRepository : ISiteRepository
{
    private readonly ApiClientKiota _apiClient;

    public ApiClientSiteRepository(ApiClientKiota apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<Site> GetSitePropertiesAsync(
        LongName universityName,
        LongName campusName,
        MediumName siteName)
    {
        string universityNameValue = universityName.Value;
        string campusNameValue = campusName.Value;
        string siteNameValue = siteName.Value;

        var queryParameter = new SitePropertiesRequestBuilder.SitePropertiesRequestBuilderPostQueryParameters
        {
            UniversityName = universityNameValue,
            CampusName = campusNameValue,
            SiteName = siteNameValue
        };

        // var siteDto = await _apiClient.SiteProperties.PostAsync(requestConfig => requestConfig.QueryParameters = queryParameter);

        //if (siteDto == null)
        //{
        //    throw new NullReferenceException("Invalid site");
        //}

        //var site = SiteDtoMapper.ToEntity(siteDto);

        //return site;
        throw new NotImplementedException();
    }
}

