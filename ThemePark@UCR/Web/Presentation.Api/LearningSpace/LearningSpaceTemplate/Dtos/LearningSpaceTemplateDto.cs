using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities.Wrappers;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningSpace.LearningSpaceTemplate.Dtos
{
    public record LearningSpaceTemplateDto(
        GuidWrapper id,
        string templateName,
        DoubleWrapper sizex,
        DoubleWrapper sizey,
        DoubleWrapper sizez,
        string floorColor,
        string ceilingColor,
        string wallsColor,
        GuidWrapper type);
}
