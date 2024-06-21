using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Dtos;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.LearningArea.Repositories;

internal class SqlSiteRepository : ISiteRepository
{
    private readonly ApplicationDbContext _dbContext;

    public SqlSiteRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Site> GetSitePropertiesAsync(
        LongName universityName, 
        LongName campusName, 
        MediumName siteName)
    {        
        var result = await _dbContext.Site
            .Where(s => s.UniversityName == universityName &&
                s.CampusName == campusName &&
                s.SiteName == siteName)
            .FirstOrDefaultAsync();

        if (result == null)
        {
            return null;
        }

        return result;
    }
}
