using BlazorStrap.V5;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Components.LearningAreas.Buildings;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages.LearningAreas.Buildings;

public partial class CreateBuilding
{
    BSModal modal;
    private BuildingInfo building { get; set; } = new BuildingInfo();

    // Variables for modal content
    public string modalContent = "";
    public string modalTitle = "";
    public string colorStatus = "";
    public string messageButton1 = "";
    public string messageButton2 = "";
    public bool success = false;
    private bool _validateStatus;
    private bool IsDisabled = true;
    private int expectedValidateData = 4;
    private int validateData = 0;

    private bool initialized = false;
    private bool createPermission = false;
}