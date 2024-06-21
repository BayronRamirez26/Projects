using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Dtos;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Application.LearningArea.Services;

public interface ISiteService
{
    public Task<Site> GetSitePropertiesAsync(
        LongName universityName, 
        LongName campusName, 
        MediumName siteName);
}
