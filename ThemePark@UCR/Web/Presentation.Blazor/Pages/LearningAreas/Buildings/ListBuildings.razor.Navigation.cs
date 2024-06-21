using Microsoft.AspNetCore.Components;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Entities;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages.LearningAreas.Buildings;

public partial class ListBuildings
{
    private void ListLevels(Building building)
    {
        // put the validated values in the navigate directly
        NavigationManager.NavigateTo($"/list-levels?"
            + "universityName=" + building.UniversityName.Value
            + "&campusName=" + building.CampusName.Value
            + "&siteName=" + building.SiteName.Value
            + "&buildingAcronym=" + building.BuildingAcronym.Value
        );
    }

    private void ModifyBuilding(Building building)
    {
        // put the validated values in the navigate directly
        NavigationManager.NavigateTo($"/modify-building?"
            + "universityName=" + building.UniversityName.Value
            + "&campusName=" + building.CampusName.Value
            + "&siteName=" + building.SiteName.Value
            + "&buildingAcronym=" + building.BuildingAcronym.Value
            + "&buildingName=" + building.BuildingName.Value
            + "&centerX=" + building.CenterX.Value
            + "&centerY=" + building.CenterY.Value
            + "&length=" + building.Length.Value
            + "&width=" + building.Width.Value
            + "&rotation=" + building.Rotation.Value
        );
    }
}