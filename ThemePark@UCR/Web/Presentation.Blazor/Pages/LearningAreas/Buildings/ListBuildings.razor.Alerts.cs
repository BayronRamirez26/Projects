using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Entities;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages.LearningAreas.Buildings;

public partial class ListBuildings
{
    private async Task ShowModalOnSubmit(Building building)
    {
        _building = building;
        modalTitle = "Confimación de borrar el edificio";
        modalContent = "<p>¿Está seguro que quiere borrar el edificio " + _building.BuildingAcronym.Value + "?</p>";
        colorStatus = "#B14212;";
        success = true;

        // Show the modal
        await modalConfirmation.ShowAsync();
    }

    private void CloseMe(bool success)
    {
        Console.WriteLine("Closing alert");
        Console.WriteLine(success);
        if (success)
        {
            showSuccessDeleteAlert = false;
            showSuccessModifyAlert = false;
        }
        else
        {
            showFailDeleteAlert = false;
        }
        StateHasChanged();
    }
}