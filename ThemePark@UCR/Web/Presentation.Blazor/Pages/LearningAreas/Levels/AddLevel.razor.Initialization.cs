using Microsoft.AspNetCore.Components;
using System.Web;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Components.LearningAreas.Levels;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Services;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages.LearningAreas.Levels;

public partial class AddLevel
{
    protected override async Task OnInitializedAsync()
    {
        base.OnInitialized();

        createPermission = false;

        Console.WriteLine("Checking if user has permission to add levels");
        ValidationService service = new ValidationService();
        createPermission = await service.hasPermition(currentNavigationUser, "Create");
        if (!createPermission)
        {
            initialized = true;
            return;
        }

        // Get the level information from the query parameters
        var uri = new Uri(NavigationManager.Uri);

        // Get the query parameters
        string query = uri.Query;

        // Parse the query parameters
        var queryParams = HttpUtility.ParseQueryString(query);

        // Access the parameters
        level.universityName = queryParams["universityName"];
        level.campusName = queryParams["campusName"];
        level.siteName = queryParams["siteName"];
        level.buildingAcronym = queryParams["buildingAcronym"];

        // Get the existing levels
        await GetExistingLevels();

        // Add the existing levels to the items list
        AddExistingLevelsToItems();

        // Initialize new level
        level.levelId = Guid.NewGuid();
        level.levelNumber = (byte)(existingLevels.Count() + 1);

        // Add new level to items
        AddNewLevelToItems();

        // Sort the items by level number in descending order
        _items = _items.OrderByDescending(item => item.OriginalLevelNumber).ToList();

        initialized = true;
        StateHasChanged();
    }

    private async Task GetExistingLevels()
    {
        LongName currentUniversityName = LongName.Create(level.universityName);
        LongName currentCampusName = LongName.Create(level.campusName);
        MediumName currentSiteName = MediumName.Create(level.siteName);
        ShortName currentBuildingAcronym = ShortName.Create(level.buildingAcronym);

        // Get the existing levels
        existingLevels = await levelService.GetLevelsFromBuildingAsync(
            currentUniversityName,
            currentCampusName,
            currentSiteName,
            currentBuildingAcronym);

        // Get the existing levels DTO
        existingLevelsDto = existingLevels.Select(l => new LevelInfo
        {
            levelId = l.LevelId.Value,
            universityName = l.UniversityName.Value,
            campusName = l.CampusName.Value,
            siteName = l.SiteName.Value,
            buildingAcronym = l.BuildingAcronym.Value,
            levelNumber = l.LevelNumber.Value,
            length = l.SizeX.Value,
            width = l.SizeY.Value,
            height = l.SizeZ.Value,
            wallsColor = l.WallsColor.Value,
            ceilingColor = l.CeilingColor.Value,
            floorColor = l.FloorColor.Value,
            learningSpaceCount = l.LearningSpaceCount.Value
        }).ToList();
    }
}
