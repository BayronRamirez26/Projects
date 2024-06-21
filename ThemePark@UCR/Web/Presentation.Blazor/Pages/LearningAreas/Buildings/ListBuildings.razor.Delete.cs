namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages.LearningAreas.Buildings;

public partial class ListBuildings
{
    private async Task DeleteBuilding()
    {
        var response = await buildingService.DeleteBuildingAsync(_building);

        if (response)
        {
            // Building was successfully deleted
            _buildings = await buildingService.GetAllBuildingsAsync();
            showSuccessDeleteAlert = true;
            colorStatus = "#95B60A";
            modalContent = "El edificio fue eliminado";
            modalTitle = "Edificio eliminado exitosamente!";
        }
        else
        {
            // Building was not deleted
            Console.WriteLine("Building was not deleted");
            showFailDeleteAlert = true;
            colorStatus = "#B14212";
            modalContent = "El edificio no fue eliminado";
            modalTitle = "Edificio no pudo ser eliminado!";
        }
        StateHasChanged(); // Notify the component that the state has changed
        await modalConfirmation.HideAsync();
    }
}