using Microsoft.AspNetCore.Components;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages.LearningAreas.Buildings;

public partial class CreateBuilding
{
    private void GoToCreateBuilding()
    {
        NavigationManager.NavigateTo(NavigationManager.Uri, true);
    }

    private void GoToListBuildings()
    {
        NavigationManager.NavigateTo("list-buildings");
    }
}