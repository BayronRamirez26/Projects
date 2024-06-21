using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Dtos;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Application.LearningArea.Services;

internal class SiteService : ISiteService
{
    private readonly ISiteRepository _siteRepository;

    public SiteService(ISiteRepository siteRepository)
    {
        _siteRepository = siteRepository;
    }

    public async Task<Site> GetSitePropertiesAsync(
        LongName universityName, 
        LongName campusName, 
        MediumName siteName)
    {
        return await _siteRepository.GetSitePropertiesAsync(
            universityName, 
            campusName, 
            siteName);
    }
}
