using Riok.Mapperly.Abstractions;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningSpace.LearningSpaceTemplate.Dtos;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningSpace.LearningSpaceTemplate.Mappers;

[Mapper]
public partial class LearningSpaceTemplateDtoMapper
{
    public static partial LearningSpaceTemplateDto FromEntityToDto(Templates learningSpaceTemplates);
}
