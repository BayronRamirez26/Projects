using BlazorStrap.V5;
using Microsoft.AspNetCore.Components;
using System.Web;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Dtos;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages.LearningAreas.Levels;

public partial class ListLevels
{
    private void GoToListBuildings()
    {
        NavigationManager.NavigateTo("list-buildings");
    }

    private void GoToAddLevel()
    {
        NavigationManager.NavigateTo("add-level?"
            + "universityName=" + universityName.Value
            + "&campusName=" + campusName.Value
            + "&siteName=" + siteName.Value
            + "&buildingAcronym=" + levelAcronym.Value
        );
    }

    private void ModifyLevel(Level level)
    {
        NavigationManager.NavigateTo($"/modify-Level?"
            + "universityName=" + level.UniversityName.Value
            + "&campusName=" + level.CampusName.Value
            + "&siteName=" + level.SiteName.Value
            + "&buildingAcronym=" + level.BuildingAcronym.Value
            + "&levelNumber=" + level.LevelNumber.Value
        );
    }
}