using Microsoft.AspNetCore.Components;
using System.Web;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Services;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages.LearningAreas.Buildings;

public partial class ModifyBuilding
{
    protected override async Task OnInitializedAsync()
    {
        base.OnInitialized();

        updatePermission = false;

        Console.WriteLine("Checking if user has permission to modify buildings");
        ValidationService service = new ValidationService();
        updatePermission = await service.hasPermition(currentNavigationUser, "Update");
        if (!updatePermission)
        {
            initialized = true;
            return;
        }

        // Obtener el objeto Building de la URL
        var uri = new Uri(NavigationManager.Uri);

        // Get the query parameters
        string query = uri.Query;

        // Parse the query parameters
        var queryParams = HttpUtility.ParseQueryString(query);

        // Access the parameters;
        building.UniversityName = queryParams["UniversityName"];
        building.CampusName = queryParams["CampusName"];
        building.SiteName = queryParams["SiteName"];
        building.BuildingAcronym = queryParams["BuildingAcronym"];
        building.BuildingName = queryParams["BuildingName"];
        building.CenterX = queryParams["CenterX"] == null ? 0 : int.Parse(queryParams["CenterX"]);
        building.CenterY = queryParams["CenterY"] == null ? 0 : int.Parse(queryParams["CenterY"]);
        building.Length = queryParams["Length"] == null ? 0 : int.Parse(queryParams["Length"]);
        building.Width = queryParams["Width"] == null ? 0 : int.Parse(queryParams["Width"]);
        building.Rotation = queryParams["Rotation"] == null ? 0 : int.Parse(queryParams["Rotation"]);

        building.BuildingId = await buildingService.GetBuildingId(
            LongName.Create(building.UniversityName),
            LongName.Create(building.CampusName),
            MediumName.Create(building.SiteName),
            ShortName.Create(building.BuildingAcronym));
        Console.WriteLine($"Blazor BuildingId: {building.BuildingId}");

        Building buildingToUpdate = await buildingService
            .GetBuildingDetailsAsync(GuidValueObject.Create(building.BuildingId));
        building.WallsColor = buildingToUpdate.WallsColor.Value;
        building.RoofColor = buildingToUpdate.RoofColor.Value;

        await GetCampuses(building.UniversityName);
        await GetSites(building.CampusName);
        isInitializationOver = true;

        initialized = true;
        StateHasChanged();
    }
}