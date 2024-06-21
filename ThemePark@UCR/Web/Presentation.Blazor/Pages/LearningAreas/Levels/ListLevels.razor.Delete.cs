using BlazorStrap.V5;
using Microsoft.AspNetCore.Components;
using System.Web;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Dtos;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages.LearningAreas.Levels;

public partial class ListLevels
{
    private async void DeleteLevel()
    {
        //Guid levelGuid = Guid.Parse(levelId);
        var response = await LevelService.DeleteLevelAsync(_level.LevelId.Value);

        if (response)
        {
            // Level was successfully deleted
            _levels = await LevelService.GetLevelsFromBuildingAsync(universityName, campusName, siteName, levelAcronym);
            showSuccessDeleteAlert = true;
            colorStatus = "#95B60A";
            modalContent = "El nivel fue eliminado";
            modalTitle = "Nivel eliminado exitosamente!";
        }
        else
        {
            // Level was not deleted
            Console.WriteLine("Level was not deleted");
            showFailDeleteAlert = true;
            colorStatus = "#B14212";
            modalContent = "El nivel no fue eliminado";
            modalTitle = "Nivel no pudo ser eliminado!";

        }
        StateHasChanged(); // Notify the component that the state has changed
        await modalConfirmation.HideAsync();
    }
}