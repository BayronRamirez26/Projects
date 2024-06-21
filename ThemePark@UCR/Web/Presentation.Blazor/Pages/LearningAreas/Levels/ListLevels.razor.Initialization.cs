using BlazorStrap.V5;
using Microsoft.AspNetCore.Components;
using System.Web;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Dtos;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Services;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages.LearningAreas.Levels;

public partial class ListLevels
{
    protected override async Task OnInitializedAsync()
    {

        base.OnInitialized();

        initialized = false;
        readPermission = false;
        updatePermission = false;
        deletePermission = false;

        Console.WriteLine("Checking if user has permission to view level list");
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
            Console.WriteLine("User has permission to update levels");
        }
        deletePermission = await service.hasPermition(currentNavigationUser, "Delete");
        if (deletePermission)
        {
            Console.WriteLine("User has permission to delete levels");
        }

        // Obtener el objeto Building de la URL
        var uri = new Uri(NavigationManager.Uri);

        // Get the query parameters
        string query = uri.Query;

        // Parse the query parameters
        var queryParams = HttpUtility.ParseQueryString(query);

        // Access the parameters
        string universityNameUrl = queryParams["universityName"];
        string campusNameUrl = queryParams["campusName"];
        string siteNameUrl = queryParams["siteName"];
        string levelAcronymUrl = queryParams["buildingAcronym"];
        successMessageUrl = queryParams["successMessage"];

        if (successMessageUrl == "true")
        {
            showSuccessModifyAlert = true;
        }

        universityName = LongName.Create(universityNameUrl);
        campusName = LongName.Create(campusNameUrl);
        siteName = MediumName.Create(siteNameUrl);
        levelAcronym = ShortName.Create(levelAcronymUrl);

        _levels = await LevelService.GetLevelsFromBuildingAsync(universityName, campusName, siteName, levelAcronym);

        initialized = true;
    }
}