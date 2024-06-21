namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningArea.Requests;

public record GetBOTemplatesOfTypeRequest(
    string ObjectType);

public record GetBOTemplatesOfPlaneRequest(
    string Plane);

public record GetBOTemplatesOfTypeAndPlaneRequest(
    string ObjectType, 
    string Plane);
