using Microsoft.AspNetCore.Components;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Components.LearningAreas.Levels;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages.LearningAreas.Levels;

public partial class ModifyLevel
{
    private void RefreshModifyLevel()
    {
        NavigationManager.NavigateTo(NavigationManager.Uri, true);
    }

    private void GoToLevelList()
    {
        string uri;
        if (success)
        {
            uri = $"list-levels?universityName={level.universityName}&campusName={level.campusName}&siteName={level.siteName}&buildingAcronym={level.buildingAcronym}&successMessage={"true"}";
        }
        else
        {
            uri = $"list-levels?universityName={level.universityName}&campusName={level.campusName}&siteName={level.siteName}&buildingAcronym={level.buildingAcronym}&successMessage={"false"}";
        }
        NavigationManager.NavigateTo(uri);
    }
}
