using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningComponents.AIAssistant;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningComponents.InteractiveScreen;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningComponents.Projector;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningComponents.Whiteboard;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningComponents;

public static class LearningComponentsEndpoints
{
    public static IEndpointRouteBuilder RegisterLearningComponentsEndpoints(this IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.RegisterWhiteboardEndpoints();
        routeBuilder.RegisterProjectorEndpoints();
        routeBuilder.RegisterAIAssistantEndpoints();
        routeBuilder.RegisterInteractiveScreenEndpoints();

        return routeBuilder;
    }
}


