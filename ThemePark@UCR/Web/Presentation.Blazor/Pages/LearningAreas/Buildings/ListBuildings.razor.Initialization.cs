using Microsoft.AspNetCore.Components;
using System.Web;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Services;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages.LearningAreas.Buildings;

public partial class ListBuildings
{
    protected override async Task OnInitializedAsync()
    {
        base.OnInitialized();

        initialized = false;
        readPermission = false;
        updatePermission = false;
        deletePermission = false;

        Console.WriteLine("Checking if user has permission to view building list");
        ValidationService service = new ValidationService();
        readPermission = await service.hasPermition(currentNavigationUser, "Read");
        if (!readPermission)
        {
            initialized = true;
            return;
        }
        updatePermission = await service.hasPermition(currentNavigationUser, "Update");
        if (updatePermission)
        {
            Console.WriteLine("User has permission to update buildings");
        }
        deletePermission = await service.hasPermition(currentNavigationUser, "Delete");
        if (deletePermission)
        {
            Console.WriteLine("User has permission to delete buildings");
        }

        // Obtener el objeto Building de la URL
        var uri = new Uri(NavigationManager.Uri);

        // Get the query parameters
        string query = uri.Query;

        // Parse the query parameters
        var queryParams = HttpUtility.ParseQueryString(query);

        successMessageUrl = queryParams["successMessage"];

        if (successMessageUrl == "true")
        {
            showSuccessModifyAlert = true;
        }

        _buildings = await buildingService.GetAllBuildingsAsync();

        initialized = true;
    }
}
