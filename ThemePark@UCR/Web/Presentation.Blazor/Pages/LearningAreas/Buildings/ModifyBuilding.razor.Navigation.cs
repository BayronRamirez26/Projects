using Microsoft.AspNetCore.Components;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages.LearningAreas.Buildings;

public partial class ModifyBuilding
{
    private void GoToBuildingCreate()
    {
        NavigationManager.NavigateTo(NavigationManager.Uri, true);
    }

    private void GoToBuildingList()
    {
        string uri;
        if (success)
        {
            uri = $"list-buildings?successMessage={"true"}";
        }
        else
        {
            uri = $"list-buildings?successMessage={"false"}";
        }
        NavigationManager.NavigateTo(uri);
    }
}