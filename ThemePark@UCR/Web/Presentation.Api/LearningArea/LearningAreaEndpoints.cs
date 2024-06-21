using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.RegisterCommander;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningArea.Handlers;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.LearningArea;

public static class LearningAreaEndpoints
{

    /*
    AS 04 - Refactorización de funcionalidades - Análisis de Calidad
    Refactorización del program.cs y sus endpoints de Presentation.Api del Backend
    Partes pertenecientes a LearningArea:
    Al menos Building, y si da tiempo Level.

    Jorge Díaz Sagot - C12565
    Francisco Ulate - C07901
    */

    private static readonly List<(IEndpointCommander command,
        string route, string name, Delegate handler)> endpointCommands =
        new List<(IEndpointCommander command, string route, string name, Delegate handler)>
        {
            // building endpoints
            (new PostEndpointCommand(), "/create-building", "CreateBuilding", BuildingEndpointHandlers.CreateBuildingAsync),
            (new PutEndpointCommand(), "/update-building", "UpdateBuilding", BuildingEndpointHandlers.UpdateBuildingAsync),
            (new GetEndpointCommand(), "/list-buildings", "GetAllBuildings", BuildingEndpointHandlers.GetAllBuildingsAsync),
            (new DeleteEndpointCommand(), "/delete-building", "DeleteBuilding",BuildingEndpointHandlers.DeleteBuildingAsync),
            (new GetEndpointCommand(), "/building-id", "GetBuildingId", BuildingEndpointHandlers.GetBuildingIdAsync),
            (new PostEndpointCommand(), "/building-from-site", "GetBuildingsFromSite", BuildingEndpointHandlers.GetBuildingsFromSiteAsync),
            (new PutEndpointCommand(), "building-details", "GetBuildingDetails", BuildingEndpointHandlers.GetBuildingDetailsAsync),
      
            // level endpoints
            (new GetEndpointCommand(), "/level-by-building", "GetLevelsFromBuilding", LevelEndpointHandlers.GetLevelsFromBuildingAsync),
            (new PutEndpointCommand(), "/create-level", "CreateLevel", LevelEndpointHandlers.CreateLevelAsync),
            (new PutEndpointCommand(), "/update-level", "UpdateLevel", LevelEndpointHandlers.UpdateLevelAsync),
            (new DeleteEndpointCommand(), "/delete-level", "DeleteLevel", LevelEndpointHandlers.DeleteLevelAsync),
            (new GetEndpointCommand(), "/level-by-id", "GetLevelById", LevelEndpointHandlers.GetLevelByIdAsync),
            
            // Building Object Template Endpoints
            (new GetEndpointCommand(), "/building-object-types", "GetBOTemplatesObjectTypes", BOTemplateEndpointHandlers.GetBOTemplatesObjectTypesAsync),
            (new GetEndpointCommand(), "/building-object-planes", "GetBOTemplatesPlanes", BOTemplateEndpointHandlers.GetBOTemplatesPlanesAsync),
            (new GetEndpointCommand(), "/list-bo-templates", "GetAllBOTemplates", BOTemplateEndpointHandlers.GetAllBOTemplatesAsync),
            (new PutEndpointCommand(), "/bo-templates-of-type", "GetBOTemplatesOfType", BOTemplateEndpointHandlers.GetBOTemplatesOfTypeAsync),
            (new PutEndpointCommand(), "/bo-templates-of-plane", "GetBOTemplatesOfPlane", BOTemplateEndpointHandlers.GetBOTemplatesOfPlaneAsync),
            (new PutEndpointCommand(), "/bo-templates-of-type-and-plane", "GetBOTemplatesOfTypeAndPlane", BOTemplateEndpointHandlers.GetBOTemplatesOfTypeAndPlaneAsync),
            
            // Building Object Endpoints
            (new GetEndpointCommand(), "/list-building-objects", "GetAllBuildingObjects", BuildingObjectEndpointHandlers.GetAllBuildingObjectsAsync),
            (new PutEndpointCommand(), "/building-objects-from-level", "GetBuildingObjectsFromLevel", BuildingObjectEndpointHandlers.GetBuildingObjectsFromLevelAsync),
            (new PutEndpointCommand(), "/building-object-details", "GetBuildingObjectDetails", BuildingObjectEndpointHandlers.GetBuildingObjectDetailsAsync),
            (new PutEndpointCommand(), "/add-building-object", "AddBuildingObject", BuildingObjectEndpointHandlers.AddBuildingObjectToLevelAsync),
            (new PutEndpointCommand(), "/modify-building-object", "UpdateBuildingObject", BuildingObjectEndpointHandlers.ModifyBuildingObjectAsync),
            (new DeleteEndpointCommand(), "/delete-building-object", "DeleteBuildingObject", BuildingObjectEndpointHandlers.DeleteBuildingObjectAsync)
        };

    /// <summary>
    /// Method that registers the endpoints of a list of commands.
    /// </summary>
    /// <param name="routeBuilder"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder RegisterLearningAreaEndpoints(this IEndpointRouteBuilder routeBuilder)
    {
        // iterate over the endpointCommands list and register each endpoint
        foreach (var (command, route, name, handler) in endpointCommands)
        {
            command.RegisterEndpoints(routeBuilder, route, name, handler);
        }

        return routeBuilder;
    }
}
