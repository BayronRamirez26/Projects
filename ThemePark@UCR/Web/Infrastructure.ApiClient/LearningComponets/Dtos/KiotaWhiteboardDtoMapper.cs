using Riok.Mapperly.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities.Wrappers;
namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.LearningComponets.Dtos;

[Mapper]
internal static partial class KiotaWhiteboardDtoMapper
{

    internal static partial DomainWeb.LearningComponents.Entities.Whiteboard ToEntity(Client.Models.Whiteboard Whiteboard);
    internal static DomainWeb.LearningComponents.Entities.Whiteboard ToEntity(Client.Models.WhiteboardDto whiteboardDto)
    {
        return new Whiteboard
            (LComponentID.Create(whiteboardDto.LearningComponentId),
            MediumName.Create(whiteboardDto.LearningComponenName),
            Size.Create(whiteboardDto.SizeX),
            Size.Create(whiteboardDto.SizeY),
            Coordinate.Create(whiteboardDto.PositionX),
            Coordinate.Create(whiteboardDto.PositionY),
            Coordinate.Create(whiteboardDto.PositionZ),
            Coordinate.Create(whiteboardDto.RotationX),
            Coordinate.Create(whiteboardDto.RotationY),
            ToValueObject(whiteboardDto.LearningSpaceId));
    }
    internal static Client.Models.WhiteboardDto FromEntitiy(DomainWeb.LearningComponents.Entities.Whiteboard Whiteboard)
    {
        return new Client.Models.WhiteboardDto
        {
            LearningComponentId = Whiteboard.LearningComponentAssetId,
            LearningComponenName = Whiteboard.LearningComponentName.Value,
            PositionX = Whiteboard.PositionX.Value,
            PositionY = Whiteboard.PositionY.Value,
            PositionZ = Whiteboard.PositionZ.Value,
            SizeX = Whiteboard.SizeX.Value,
            SizeY = Whiteboard.SizeY.Value,
            RotationX = Whiteboard.RotationX.Value,
            RotationY = Whiteboard.RotationY.Value,
            LearningSpaceId = ToDto(Whiteboard.LearningSpaceId)
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



