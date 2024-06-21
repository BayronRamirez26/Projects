using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningSpace.LearningSpace.Responses;

public record ListLearningSpaceResponse(IEnumerable<LearningSpaces> learningSpaces);
