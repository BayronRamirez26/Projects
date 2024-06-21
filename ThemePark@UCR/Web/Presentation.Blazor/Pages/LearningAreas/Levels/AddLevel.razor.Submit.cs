using Microsoft.AspNetCore.Components.Forms;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Components.LearningAreas.Levels;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages.LearningAreas.Levels;

public partial class AddLevel
{
    private async Task OnSubmitAsync(EditContext e)
    {
        success = true;

        if (e.Validate())
        {
            byte zero = 0;
            Level newLevel = new Level(
                GuidValueObject.Create(level.levelId),
                LongName.Create(level.universityName),
                LongName.Create(level.campusName),
                MediumName.Create(level.siteName),
                ShortName.Create(level.buildingAcronym),
                DomainWeb.Shared.ValueObjects.Counter.Create(level.levelNumber),
                DomainWeb.Shared.ValueObjects.Size.Create(level.length),
                DomainWeb.Shared.ValueObjects.Size.Create(level.width),
                DomainWeb.Shared.ValueObjects.Size.Create(level.height),
                Color.Create(level.wallsColor),
                Color.Create(level.floorColor),
                Color.Create(level.ceilingColor),
                DomainWeb.Shared.ValueObjects.Counter.Create(zero)
            );


            bool result = false;
            try
            {
                result = await levelService.CreateLevelAsync(newLevel);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            // Add the current level to the existing levels DTO
            existingLevelsDto.Add(level);

            // Create updated levels list with new level number
            IEnumerable<Level?> updatedLevels = getUpdatedLevels();

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
                modalTitle = "Nivel agregado exitosamente!";
                modalContent = "<p>El nivel fue agregado exitosamente!</p>";
                colorStatus = "#95B60A;";
                messageButton1 = "Agregar otro nivel";
                messageButton2 = "Ir a la lista de niveles";
                success = true;
            }
            else
            {
                // There was an error creating the building
                modalTitle = "Ha habido un error";
                modalContent = "El nivel no pudo ser agregado.\nSurgieron los siguientes errores en su creación:\n";
                colorStatus = "#B14212;";
                messageButton1 = "Volver a agregar nivel";

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
