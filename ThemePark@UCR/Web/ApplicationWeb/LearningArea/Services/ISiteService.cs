using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Dtos;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.LearningArea.Services;

public interface ISiteService
{
    public Task<Site> GetSitePropertiesAsync(
        LongName universityName, 
        LongName campusName, 
        MediumName siteName);
}
