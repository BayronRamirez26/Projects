using Riok.Mapperly.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningComponents.Projector.Dtos;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.Projector.Mappers;


[Mapper]
internal partial class ProjectorDtoMapper
{
    internal static ProjectorDto FromEntitiy(Domain.LearningComponents.Entities.Projector projector)
    {
        return new ProjectorDto(
            projector.LearningComponentAssetId,
            projector.LearningComponentName.Value,
            projector.SizeX.Value,
            projector.SizeY.Value,
            projector.PositionX.Value,
            projector.PositionY.Value,
            projector.PositionZ.Value,
            projector.RotationX.Value,
            projector.RotationY.Value,
            projector.LearningSpaceId);
    }

   
}