using BlazorStrap.V5;
using UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Components.LearningAreas.Buildings;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages.LearningAreas.Buildings;

public partial class ModifyBuilding
{
    BSModal modal;

    //private BuildingDto? oldBuilding { get; set; } = new BuildingDto();

    private string _message = "";
    private BuildingInfo building { get; set; } = new BuildingInfo();
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
    private bool isInitializationOver = false;

    private bool initialized = false;
    private bool updatePermission = false;
}