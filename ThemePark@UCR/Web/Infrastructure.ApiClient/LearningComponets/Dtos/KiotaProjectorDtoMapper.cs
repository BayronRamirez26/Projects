using Riok.Mapperly.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;
namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.LearningComponets.Dtos;

[Mapper]
internal static partial class KiotaProjectorDtoMapper
{

    internal static partial DomainWeb.LearningComponents.Entities.Projector ToEntity(Client.Models.Projector projectorDto);
    internal static DomainWeb.LearningComponents.Entities.Projector ToEntity(Client.Models.ProjectorDto aIAssistantDto)
    {
        return new Projector
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
    internal static Client.Models.ProjectorDto FromEntitiy(DomainWeb.LearningComponents.Entities.Projector Projector)
    {
        return new Client.Models.ProjectorDto
        {
            LearningComponentId = Projector.LearningComponentAssetId,
            LearningComponenName = Projector.LearningComponentName.Value,
            PositionX = Projector.PositionX.Value,
            PositionY = Projector.PositionY.Value,
            PositionZ = Projector.PositionZ.Value,
            SizeX = Projector.SizeX.Value,
            SizeY = Projector.SizeY.Value,
            RotationX = Projector.RotationX.Value,
            RotationY = Projector.RotationY.Value,
            LearningSpaceId = ToDto(Projector.LearningSpaceId)
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





