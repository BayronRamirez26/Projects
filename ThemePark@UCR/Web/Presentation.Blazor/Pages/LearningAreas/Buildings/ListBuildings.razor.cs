using BlazorStrap.V5;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Entities;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages.LearningAreas.Buildings;

public partial class ListBuildings
{
    // Modal
    BSModal? modalConfirmation;
    Building? _building;

    public string modalContent = "";
    public string modalTitle = "";
    public string colorStatus = "";
    public const string acceptMessage = "Aceptar";
    public const string cancelMenssage = "Cancelar";
    public bool success = false;

    // Alert variables
    private bool showSuccessDeleteAlert = false;
    private bool showFailDeleteAlert = false;
    private bool showSuccessModifyAlert = false;

    // HTML attributes
    private readonly bool dense = false;
    private readonly bool hover = true;
    private readonly bool striped = false;
    private readonly bool bordered = false;

    // URL variables
    string? successMessageUrl;

    // List of buildings
    private IEnumerable<Building>? _buildings;

    private bool initialized = false;
    private bool readPermission = false;
    private bool updatePermission = false;
    private bool deletePermission = false;
}