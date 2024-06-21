using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningArea.Dtos;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningArea.Responses;

public record GetBOTemplatesObjectTypesResponse(
    IEnumerable<string> TypesList);

public record GetBOTemplatesPlanesResponse(
    IEnumerable<string> PlanesList);

public record GetAllBOTemplatesResponse(
    IEnumerable<BOTemplateDto> TemplateList);

public record GetBOTemplatesOfTypeResponse(
    IEnumerable<BOTemplateDto> TemplateList);

public record GetBOTemplatesOfPlaneResponse(
    IEnumerable<BOTemplateDto> TemplateList);

public record GetBOTemplatesOfTypeAndPlaneResponse(
    IEnumerable<BOTemplateDto> TemplateList);
