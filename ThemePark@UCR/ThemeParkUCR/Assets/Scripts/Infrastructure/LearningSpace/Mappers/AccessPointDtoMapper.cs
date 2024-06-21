using Riok.Mapperly.Abstractions;
using System;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.LearningSpace.Entities.Wrappers;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Infrastructure.LearningSpaces.Mappers
{
    [Mapper]
    public static partial class AccessPointDtoMapper
    {
        // This is the method that will be called to map the AccessPointDto to the AccessPoint entity

        public static partial AccessPoint ToEntity(ThemePark_UCR.Infrastructure.ApiClient.Client.Models.AccessPoint accessPoint);

        // This is the method that will be called to return the GuidWrapper value object
        public static GuidWrapper ToValueObject(ThemePark_UCR.Infrastructure.ApiClient.Client.Models.GuidWrapper guidWrapper)
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
}
