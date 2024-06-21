using Microsoft.AspNetCore.Components.Forms;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Components.LearningAreas.Levels;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages.LearningAreas.Levels;

public partial class ModifyLevel
{
    private async Task OnSubmitAsync(EditContext e)
    {
        success = true;

        if (e.Validate())
        {
            // Create updated levels list with new level number
            IEnumerable<Level?> updatedLevels = getUpdatedLevels();

            bool result = false;
            foreach (var updatedLevel in updatedLevels)
            {
                try
                {
                    result = await levelService.UpdateLevelAsync(updatedLevel);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            if (result)
            {
                // Level was successfully created
                success = true;
                GoToLevelList();
            }
            else
            {
                // There was an error creating the building
                modalTitle = "Ha habido un error";
                modalContent = "El nivel no pudo ser modificado.\nSurgieron los siguientes errores en su creación:\n";
                colorStatus = "#B14212;";
                messageButton1 = "Volver a modificar nivel";

                // Read the error message from the response
                var errorMessage = "Error message from the response";

                // Split the error message into individual error items (assuming each error is separated by a newline character)
                var errors = errorMessage.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

                // Construct the HTML content for displaying the errors as a list
                modalContent += "<ul>";
                foreach (var error in errors)
                {
                    modalContent += $"<li>{error}</li>";
                }
                modalContent += "</ul>";

                success = false;
            }
            // Show the modal
            await modal.ShowAsync();
        }
    }
}
