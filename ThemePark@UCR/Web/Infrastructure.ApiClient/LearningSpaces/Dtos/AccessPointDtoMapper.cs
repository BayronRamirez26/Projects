using Riok.Mapperly.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities.Wrappers;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.LearningSpaces.Dtos;

[Mapper]
public static partial class AccessPointDtoMapper
{
    // This is the method that will be called to map the AccessPointDto to the AccessPoint entity

    public static partial DomainWeb.LearningSpace.Entities.AccessPoint ToEntity(Models.AccessPoint accessPoint);

    // This is the method that will be called to return the GuidWrapper value object
    public static GuidWrapper ToValueObject(Models.GuidWrapper guidWrapper)
    {
        if (guidWrapper.Value != null)
        {
            // If the Guid exist assign the already existing value
            return GuidWrapper.Create(guidWrapper.Value.Value);
        }
        else
        {
            // If no Guid is recieved create a new one
            return GuidWrapper.Create(Guid.NewGuid());
        }
    }
}
