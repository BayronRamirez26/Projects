using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.Validations.Collisions;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Validations;

public class BuildingValidations
{
    public static bool BuildingCanBeCreated(Building newBuilding, IEnumerable<Building> existingBuildings, Site site)
    {
        CollisionRectangle newRectangle = new(
            newBuilding.CenterX,
            newBuilding.CenterY,
            newBuilding.Length, 
            newBuilding.Width, 
            newBuilding.Rotation);
        IEnumerable<CollisionRectangle> existingRectangles = existingBuildings.Select(b => new CollisionRectangle(
            b.CenterX,
            b.CenterY,
            b.Length, 
            b.Width, 
            b.Rotation));
        CollisionSurface surface = new(
            site.SizeX, 
            site.SizeY);

        bool canCreateBuilding = CollisionValidations.RectangleCanBeCreatedOrModified(newRectangle, existingRectangles, surface);

        return canCreateBuilding;
    }

    public static bool BuildingCanBeModified(Building building, IEnumerable<Building> existingBuildings, Site site)
    {
        // Remove the building to be modified from the list of existing buildings
        //existingBuildings = existingBuildings.Where(b => b != building);
        // implemented on sql GetBuildingsFromSite

        return BuildingCanBeCreated(building, existingBuildings, site);
    }
}
