using System.Threading.Tasks;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Dtos;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Repositories;

public interface ISiteRepository
{
    public Task<Site> GetSitePropertiesAsync(
        LongName universityName, 
        LongName campusName, 
        MediumName siteName);
}
