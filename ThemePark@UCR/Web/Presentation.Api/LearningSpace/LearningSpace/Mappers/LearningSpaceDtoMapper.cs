using Riok.Mapperly.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningSpace.LearningSpace.Dtos;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningSpace.Mappers;

[Mapper]
public partial class LearningSpaceDtoMapper
{
    public static partial LearningSpaceDto FromEntityToDto(LearningSpaces learningSpaces);
}
