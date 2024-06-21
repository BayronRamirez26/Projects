using BlazorStrap.V5;
using Microsoft.AspNetCore.Components;
using System.Web;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Dtos;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages.LearningAreas.Levels;

public partial class ListLevels
{
    // search Level functions
    private string searchString = "";
    private bool SearchCall(Level element) => Search(element, searchString);
    private bool Search(Level element, string searchString)
    {
        if (string.IsNullOrWhiteSpace(searchString))
            return true;
        if (element.BuildingAcronym.Value.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if (element.LevelNumber.Value.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;

        return false;
    }
}
