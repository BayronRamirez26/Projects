using Microsoft.AspNetCore.Components.Forms;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages.LearningAreas.Buildings;

public partial class CreateBuilding
{
    private async void OnSubmit(EditContext e)
    {
        if (e.Validate())
        {
            var buildingEntity = new Building(
                GuidValueObject.Create(building.BuildingId),
                LongName.Create(building.UniversityName),
                LongName.Create(building.CampusName),
                MediumName.Create(building.SiteName),
                ShortName.Create(building.BuildingAcronym),
                LongName.Create(building.BuildingName),
                Coordinate.Create(building.CenterX),
                Coordinate.Create(building.CenterY),
                Size.Create(building.Length),
                Size.Create(building.Width),
                Angle.Create(building.Rotation),
                Color.Create(building.WallsColor),
                Color.Create(building.RoofColor)
            // counter begins with 0 that is the default value
            );

            var response = await buildingService.CreateBuildingAsync(buildingEntity);

            Console.WriteLine("This is the response: ");
            Console.WriteLine(response);

            if (response.Success)
            {
                // Building was successfully created
                Console.WriteLine("Building was successfully created");
                modalTitle = "Edificio creado exitosamente!";
                modalContent = "<p>El edificio fue creado exitosamente!</p>";
                colorStatus = "#95B60A;";
                messageButton1 = "Crear otro edificio";
                messageButton2 = "Ir a la lista de edificios";
                success = true;
            }
            else
            {
                Console.WriteLine("There was an error creating the building");
                // There was an error creating the building
                modalTitle = "Ha habido un error";
                modalContent = "El edificio no pudo ser creado.\n";
                colorStatus = "#B14212;";
                messageButton1 = "Volver a la creación de edificio";

                // Construct the HTML content for displaying the errors as a list
                modalContent += "<ul>";
                modalContent += $"<li>Error: {response.Message}</li>";
                modalContent += "</ul>";

            }
            // Show the modal
            await modal.ShowAsync();
        }
    }
}