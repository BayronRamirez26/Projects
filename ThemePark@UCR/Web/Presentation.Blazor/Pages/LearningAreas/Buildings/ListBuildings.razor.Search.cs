using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Entities;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages.LearningAreas.Buildings;

public partial class ListBuildings
{
    // search building functions
    private string searchString = "";
    private bool SearchCall(Building element) => Search(element, searchString);
    private bool Search(Building element, string searchString)
    {
        if (string.IsNullOrWhiteSpace(searchString))
            return true;
        if (element.UniversityName.Value.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if (element.CampusName.Value.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if (element.SiteName.Value.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if (element.BuildingAcronym.Value.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if (element.BuildingName.Value.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;

        return false;
    }
}