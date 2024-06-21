using UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Services;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages.LearningAreas.Buildings;

public partial class CreateBuilding
{
    protected override async Task OnInitializedAsync()
    {
        base.OnInitialized();

        createPermission = false;

        Console.WriteLine("Checking if user has permission to create buildings");
        ValidationService service = new ValidationService();
        createPermission = await service.hasPermition(currentNavigationUser, "Create");
        if (createPermission)
        {
            Console.WriteLine("User has permission to create buildings");
        }

        initialized = true;
    }
}