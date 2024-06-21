using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningSpace.LearningSpaceTemplate.Responses;

public record ListLearningSpaceTemplateResponse(IEnumerable<Templates> templates);
