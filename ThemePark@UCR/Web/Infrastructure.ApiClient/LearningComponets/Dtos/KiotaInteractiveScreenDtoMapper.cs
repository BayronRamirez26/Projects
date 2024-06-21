using Riok.Mapperly.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.LearningComponets.Dtos;

[Mapper]
internal static partial class KiotaInteractiveScreenDtoMapper
{

    internal static partial DomainWeb.LearningComponents.Entities.InteractiveScreen ToEntity(Client.Models.InteractiveScreen screenDtos);

    internal static DomainWeb.LearningComponents.Entities.InteractiveScreen ToEntity(Client.Models.InteractiveScreenDto aIAssistantDto)
    {
        return new InteractiveScreen
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
    internal static Client.Models.InteractiveScreenDto FromEntitiy(DomainWeb.LearningComponents.Entities.InteractiveScreen interactiveScreen)
    {
        return new Client.Models.InteractiveScreenDto
        {
            LearningComponentId = interactiveScreen.LearningComponentAssetId,
            LearningComponenName = interactiveScreen.LearningComponentName.Value,
            PositionX = interactiveScreen.PositionX.Value,
            PositionY = interactiveScreen.PositionY.Value,
            PositionZ = interactiveScreen.PositionZ.Value,
            SizeX = interactiveScreen.SizeX.Value,
            SizeY = interactiveScreen.SizeY.Value,
            RotationX = interactiveScreen.RotationX.Value,
            RotationY = interactiveScreen.RotationY.Value,
            LearningSpaceId = ToDto(interactiveScreen.LearningSpaceId)
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



