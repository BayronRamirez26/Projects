using Microsoft.AspNetCore.Components.Forms;
using System.Text;
using System.Text.Json;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages.LearningAreas.Buildings;

public partial class ModifyBuilding
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
            );

            var response = await buildingService.UpdateBuildingAsync(buildingEntity);

            if (response.Success)
            {
                // Building was successfully created
                Console.WriteLine("Building was successfully modified");
                success = true;
                GoToBuildingList();
            }
            else
            {
                Console.WriteLine("There was an error creating the building");
                // There was an error creating the building
                modalTitle = "Ha habido un error";
                modalContent = "El edificio no pudo ser creado.\nSurgieron los siguientes errores en su creación:\n";
                colorStatus = "#B14212;";
                messageButton1 = "Seguir modificando edificio";
                messageButton2 = "Ir a la lista de edificios";

                // Construct the HTML content for displaying the errors as a list
                modalContent += "<ul>";
                modalContent += $"<li>Error: {response.Message}</li>";
                modalContent += "</ul>";

                // Show the modal
                await modal.ShowAsync();
            }
        }
    }
}