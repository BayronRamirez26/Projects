using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Dtos;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.Responses;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.LearningArea.Services;

public interface IBuildingService
{
    public Task<IEnumerable<Building>> GetAllBuildingsAsync();

    public Task<HttpResponse> CreateBuildingAsync(Building building);

    public Task<HttpResponse> UpdateBuildingAsync(Building building);

    public Task<bool> DeleteBuildingAsync(Building building);

    public Task<Guid> GetBuildingId(
        LongName universityName,
        LongName campusName,
        MediumName siteName,
        ShortName buildingAcronym);

    public Task<Building> GetBuildingDetailsAsync(
        GuidValueObject buildingId);
}
