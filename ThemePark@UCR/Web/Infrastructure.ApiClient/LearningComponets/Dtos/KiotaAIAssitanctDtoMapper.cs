using Riok.Mapperly.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Dtos;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.LearningComponets.Dtos;

[Mapper]
internal static partial class KiotaAIAssistantDtoMapper
{
    internal static  DomainWeb.LearningComponents.Entities.AIAssistant ToEntity (Client.Models.AIAssistantDto aIAssistantDto)
    {
        return new AIAssistant
            (LComponentID.Create(aIAssistantDto.LearningComponentId),
            MediumName.Create(aIAssistantDto.LearningComponenName),
            Size.Create(aIAssistantDto.SizeX),
            Size.Create(aIAssistantDto.SizeY),
            Coordinate.Create(aIAssistantDto.PositionX),
            Coordinate.Create(aIAssistantDto.PositionY),
            Coordinate.Create(aIAssistantDto.PositionZ),
            Coordinate.Create(aIAssistantDto.RotationX),
            Coordinate.Create(aIAssistantDto.RotationY),
            ToValueObject(aIAssistantDto.LearningSpaceId));
    }
    internal static Client.Models.AIAssistantDto FromEntitiy(DomainWeb.LearningComponents.Entities.AIAssistant aIAssistant)
    {
        return new Client.Models.AIAssistantDto
        {
            LearningComponentId = aIAssistant.LearningComponentAssetId,
            LearningComponenName = aIAssistant.LearningComponentName.Value,
            PositionX = aIAssistant.PositionX.Value,
            PositionY = aIAssistant.PositionY.Value,
            PositionZ = aIAssistant.PositionZ.Value,
            SizeX = aIAssistant.SizeX.Value,
            SizeY = aIAssistant.SizeY.Value,
            RotationX = aIAssistant.RotationX.Value,
            RotationY = aIAssistant.RotationY.Value,
            LearningSpaceId = ToDto(aIAssistant.LearningSpaceId)
        };
    }


    internal static DomainWeb.Shared.ValueObjects.MediumName ToValueOBject(Client.Models.MediumName mediumNameDto)
    {
        return MediumName.Create(mediumNameDto.Value);
    }


    internal static DomainWeb.Shared.ValueObjects.Coordinate ToValueObject(Client.Models.Coordinate coordinateDto)
    {
        return Coordinate.Create((double)coordinateDto.Value);
    }


    internal static DomainWeb.Shared.ValueObjects.Size ToValueObject(Client.Models.Size sizeDto)
    {
        return Size.Create((double)sizeDto.Value);
    }

    internal static DomainWeb.LearningSpace.Entities.Wrappers.GuidWrapper ToValueObject(Client.Models.GuidWrapper guidWrapperDto)
    {
        return GuidWrapper.Create(guidWrapperDto.Value.Value);
    }

    internal static DomainWeb.LearningSpace.Entities.Wrappers.GuidWrapper ToValueObject(GuidWrapper guidWrapperDto)
    {
        return GuidWrapper.Create(guidWrapperDto.Value);
    }
    internal static Client.Models.GuidWrapper ToDto(DomainWeb.LearningSpace.Entities.Wrappers.GuidWrapper guidWrapper)
    {
        return new Client.Models.GuidWrapper
        {
            Value = guidWrapper.Value
        };
    }


}



