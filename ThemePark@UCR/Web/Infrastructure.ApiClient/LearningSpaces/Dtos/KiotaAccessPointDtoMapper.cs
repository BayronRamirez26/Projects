using Riok.Mapperly.Abstractions;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.LearningSpaces.Dtos;

[Mapper]
public static partial class KiotaAccessPointDtoMapper
{
    // Map from Domain AccessPoint to Model access point
    public static partial Models.AccessPoint ToEntity(DomainWeb.LearningSpace.Entities.AccessPoint accessPoint);
}
