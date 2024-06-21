using BlazorStrap.V5;
using Microsoft.AspNetCore.Components;
using System.Web;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Dtos;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages.LearningAreas.Levels;

public partial class ListLevels
{
    private async void ShowModalOnSubmit(Level level)
    {
        _level = level;
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
        // StateHasChanged();
    }
}