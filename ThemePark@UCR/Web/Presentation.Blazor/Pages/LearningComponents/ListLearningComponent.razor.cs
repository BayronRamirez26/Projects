using Microsoft.AspNetCore.Components;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Services;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages.LearningComponents;
public partial class ListLearningComponent
{
    private bool dense = false;
    private bool hover = true;
    private bool striped = false;
    private bool bordered = false;
    private string searchString = "";

    private IEnumerable<string>? lcomponents = new List<string> { "Pizarras", "Proyectores", "Asistentes de IA", "Pantallas interactivas" };


    private bool SearchCall(dynamic element) => Search(element, searchString);
    private bool Search(dynamic element, string searchString)
    {
        if (string.IsNullOrWhiteSpace(searchString))
            return true;

        if (element.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;

        return false;
    }

    private void OnItemClick(string item)
    {
        string selectedComponent = item;
        NavigationManager.NavigateTo($"/list-component/{selectedComponent}");
    }
}

