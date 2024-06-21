using Microsoft.AspNetCore.Components;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Components.LearningAreas.Levels;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages.LearningAreas.Levels;

public partial class AddLevel
{
    private void GoToLevelCreate()
    {
        NavigationManager.NavigateTo(NavigationManager.Uri, true);
    }

    private void GoToLevelList()
    {
        string uri = $"list-levels?universityName={level.universityName}&campusName={level.campusName}&siteName={level.siteName}&buildingAcronym={level.buildingAcronym}";
        NavigationManager.NavigateTo(uri);
    }
}
