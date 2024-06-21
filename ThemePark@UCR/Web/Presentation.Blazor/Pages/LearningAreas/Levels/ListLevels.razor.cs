using BlazorStrap.V5;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Dtos;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages.LearningAreas.Levels;

public partial class ListLevels
{

    //Modal
    BSModal? modalConfirmation;
    Level _level;

    public string modalContent = "";
    public string modalTitle = "";
    public string colorStatus = "";
    public string buttonColorStatus = "";

    public bool success = false;

    // Alert variables
    private bool showSuccessDeleteAlert = false;
    private bool showFailDeleteAlert = false;
    private bool showSuccessModifyAlert = false;

    // HTML attributes
    private bool dense = false;
    private bool hover = true;
    private bool striped = false;
    private bool bordered = false;

    // List of Levels
    private IEnumerable<Level>? _levels;
    private LevelDto? levelDto { get; set; } = new LevelDto();

    // Object attributes
    LongName universityName;
    LongName campusName;
    MediumName siteName;
    ShortName levelAcronym;
    string successMessageUrl;

    private bool initialized = false;
    private bool readPermission = false;
    private bool updatePermission = false;
    private bool deletePermission = false;
}
